using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using infinity;

/// <summary>
/// Class contains generic data access functionality to be accessed from 
/// the business tier
/// </summary>
public class DAL_GenericDataAccess
{
    // static constructor 
    static DAL_GenericDataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    /// <summary>
    /// this function execute passed command as executeReader so user can get the data
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>return command result as datatable</returns>
    public DataTable ExecuteSelectCommand(DbCommand command)
    {

        // The DataTable to be returned 
        DataTable table;

        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the data connection 
            command.Connection.Open();

            // Execute the command and save the results in a DataTable
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            // Close the reader 
            reader.Close();
        }
        catch (Exception exd)
        {
            //Utilities.LogError(ex);
            throw exd;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        return table;
    }
    /// <summary>
    /// this function execute passed command as executeReader so user can get the data
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>return command result as dataSet</returns>
    public DataSet ExecuteSelectCommandDataset(DbCommand command)
    {

        // The DataTable to be returned 
        DataSet table = new DataSet();

        // Execute the command making sure the connection gets closed in the end
        try
        {
            DbProviderFactory factory =
            DbProviderFactories.GetFactory(DAL_WebConfiguration.DbProviderName);


            // Open the data connection 
            command.Connection.Open();

            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            // Fill the DataTable.

            adapter.Fill(table);
        }
        catch (Exception exd)
        {
            //Utilities.LogError(ex);
            throw exd;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        return table;
    }
    /// <summary>
    /// this function execute passed update, delete and insert command
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>return number of rows effected by command</returns>
    public int ExecuteNonQuery(DbCommand command)
    {
        // The number of affected rows 
        int affectedRows = -1;

        foreach (DbParameter p in command.Parameters)
        {
            if (p.DbType == DbType.String)
            {
                if (Handle.ToString(p.Value) == "")
                {
                    p.Value = DBNull.Value;
                }
            }
        }

        DbCommand com = command;

        if (com.Connection.State == ConnectionState.Open)
            com.Connection.Close();

        if (command.Connection.State == ConnectionState.Open)
            command.Connection.Close();

        DbTransaction dbTraOriginal = null;

        //Create BackUp DATABASE Transaction Here

        DbTransaction dbTraBack = null;
        try
        {
            string checkDbAutoBackup = DAL_WebConfiguration.DbBackupAuto;
            if (checkDbAutoBackup == "1")
            {
                com.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionStringBackup;

                if (com.Connection.State == ConnectionState.Closed)
                    com.Connection.Open();

                dbTraBack = com.Connection.BeginTransaction();

                com.Transaction = dbTraBack;


                dbTraBack.Commit();

                com.Connection.Close();
                com.Dispose();
            }

            //Create Original DATABASE Transaction Here

            try
            {
                command.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;
                // Execute the command and get the number of affected rows

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                dbTraOriginal = command.Connection.BeginTransaction();

                command.Transaction = dbTraOriginal;
                affectedRows = command.ExecuteNonQuery();

                //dbTraOriginal.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;

                dbTraOriginal.Commit();
            }
            catch
            {
                try
                {
                    dbTraOriginal.Rollback();
                }
                catch { }
            }
            finally
            {
                command.Connection.Close();
            }
        }
        catch
        {
            try
            {
                dbTraBack.Rollback();
            }
            catch
            { }




            int backup = 0;
            int backup_check = 0;

            if (backup != 1 || backup_check != 1)
            {
                //Create Original DATABASE Transaction Here
                //DbTransaction dbTraOriginal = null;
                try
                {
                    command.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;
                    // Execute the command and get the number of affected rows

                    if (command.Connection.State == ConnectionState.Closed)
                        command.Connection.Open();

                    dbTraOriginal = command.Connection.BeginTransaction();

                    command.Transaction = dbTraOriginal;
                    affectedRows = command.ExecuteNonQuery();

                    //dbTraOriginal.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;

                    dbTraOriginal.Commit();
                }
                catch
                {
                    try
                    {
                        dbTraOriginal.Rollback();
                    }
                    catch { }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }
        finally
        {
            com.Connection.Close();
            com.Dispose();
        }


        // return the number of affected rows
        return affectedRows;
    }
    // execute a select command and return a single result as a string
    /// <summary>
    /// this method execute passed command and return single value as string
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>command result as string</returns>
    public string ExecuteScalar(DbCommand command)
    {
        // The value to be returned 
        string value = "";

        DbCommand com = command;

        if (com.Connection.State == ConnectionState.Open)
            com.Connection.Close();

        if (command.Connection.State == ConnectionState.Open)
            command.Connection.Close();

        //Create BackUp DATABASE Transaction Here
        DbTransaction dbTraBack = null;
        try
        {
            string checkDbAutoBackup = DAL_WebConfiguration.DbBackupAuto;
            if (checkDbAutoBackup == "1")
            {
                com.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionStringBackup;

                if (com.Connection.State == ConnectionState.Closed)
                    com.Connection.Open();

                dbTraBack = com.Connection.BeginTransaction();

                com.Transaction = dbTraBack;

                dbTraBack.Commit();
            }
        }
        catch
        {
            try
            {
                dbTraBack.Rollback();
            }
            catch
            { }
        }
        finally
        {
            com.Connection.Close();
            com.Dispose();
        }

        //Create Original DATABASE Transaction Here
        DbTransaction dbTraOriginal = null;
        try
        {
            command.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;
            // Execute the command and get the number of affected rows

            if (command.Connection.State == ConnectionState.Closed)
                command.Connection.Open();

            dbTraOriginal = command.Connection.BeginTransaction();

            command.Transaction = dbTraOriginal;
            //affectedRows = command.ExecuteNonQuery();
            value = command.ExecuteScalar().ToString();

            //dbTraOriginal.Connection.ConnectionString = DAL_WebConfiguration.DbConnectionString;

            dbTraOriginal.Commit();
        }
        catch
        {
            try
            {
                dbTraOriginal.Rollback();
            }
            catch { }
        }
        finally
        {
            command.Connection.Close();
        }
        // return the result
        return value;
    }





    // creates and prepares a new DbCommand object on a new connection
    /// <summary>
    /// this method used to create new instance of Db_Command
    /// </summary>
    /// <returns>return new created instance of DbCommand</returns>
    public DbCommand CreateCommand()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;

        // Obtain the database provider name
        string dataProviderName = DAL_WebConfiguration.DbProviderName;

        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        // Obtain a database specific connection object
        DbConnection conn = factory.CreateConnection();

        // Set the connection string
        conn.ConnectionString = connectionString;

        // Create a database specific command object
        DbCommand comm = conn.CreateCommand();

        // Set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;

        // Return the initialized command object
        return comm;
    }

    public DbCommand CreateCommand(String ConStr)
    {
        // Obtain the database connection string
        string connectionString = ConStr;

        // Obtain the database provider name
        string dataProviderName = DAL_WebConfiguration.DbProviderName;

        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        // Obtain a database specific connection object
        DbConnection conn = factory.CreateConnection();

        // Set the connection string
        conn.ConnectionString = connectionString;

        // Create a database specific command object
        DbCommand comm = conn.CreateCommand();

        // Return the initialized command object
        return comm;
    }

    /// <summary>
    /// this method execute passed command and return single value as string
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>command result as string</returns>
    public string ExecuteScalar_ForSelectedProject(DbCommand command)
    {
        // The value to be returned 
        string value = "";

        if (command.Connection.State == ConnectionState.Open)
            command.Connection.Close();

        //Create Original DATABASE Transaction Here
        DbTransaction dbTraOriginal = null;
        try
        {
            if (command.Connection.State == ConnectionState.Closed)
                command.Connection.Open();

            dbTraOriginal = command.Connection.BeginTransaction();

            command.Transaction = dbTraOriginal;
            //affectedRows = command.ExecuteNonQuery();
            value = command.ExecuteScalar().ToString();

            dbTraOriginal.Commit();
        }
        catch
        {
            try
            {
                dbTraOriginal.Rollback();
            }
            catch { }
        }
        finally
        {
            command.Connection.Close();
        }
        // return the result
        return value;
    }

    // creates and prepares a new DbCommand object on a log database new connection
    /// <summary>
    /// this method used to create new instance of Db_Command
    /// </summary>
    /// <returns>return new created instance of DbCommand</returns>
    public DbCommand CreateLogCommand()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbLogConnectionString;

        // Obtain the database provider name
        string dataProviderName = DAL_WebConfiguration.DbLogProviderName;

        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        // Obtain a database specific connection object
        DbConnection conn = factory.CreateConnection();

        // Set the connection string
        conn.ConnectionString = connectionString;

        // Create a database specific command object
        DbCommand comm = conn.CreateCommand();

        // Set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;

        // Return the initialized command object
        return comm;
    }

    // execute a select command and return a single result as a string from second db containing log tables
    /// <summary>
    /// this method execute passed command and return single value as string
    /// </summary>
    /// <param name="command">pass object of dbCommand</param>
    /// <returns>command result as string</returns>
    public string ExecuteScalar_Log(DbCommand command)
    {
        // The value to be returned 
        string value = "";

        DbCommand com = command;

        if (com.Connection.State == ConnectionState.Open)
            com.Connection.Close();

        if (command.Connection.State == ConnectionState.Open)
            command.Connection.Close();


        //Create Original DATABASE Transaction Here
        DbTransaction dbTraOriginal = null;
        try
        {
            command.Connection.ConnectionString = DAL_WebConfiguration.DbLogConnectionString;
            // Execute the command and get the number of affected rows

            if (command.Connection.State == ConnectionState.Closed)
                command.Connection.Open();

            dbTraOriginal = command.Connection.BeginTransaction();

            command.Transaction = dbTraOriginal;
            //affectedRows = command.ExecuteNonQuery();
            value = command.ExecuteScalar().ToString();

            //dbTraOriginal.Connection.ConnectionString = DAL_WebConfiguration.DbLogConnectionString;

            dbTraOriginal.Commit();
        }
        catch
        {
            try
            {
                dbTraOriginal.Rollback();
            }
            catch { }
        }
        finally
        {
            command.Connection.Close();
        }
        // return the result
        return value;
    }


    /// <summary>
    /// get server name from connection string
    /// </summary>
    /// <returns>server name as string</returns>
    public string ServerName()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;

        // Create sql connection string builder
        SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder(connectionString);

        //return server name
        string servername = constr.DataSource.ToString();
        return servername;
    }
    /// <summary>
    /// get database name from connection string
    /// </summary>
    /// <returns>data base name as string</returns>
    public string database()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;

        // Create sql connection string builder
        SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder(connectionString);

        //return server name
        string database = constr.InitialCatalog.ToString();
        return database;
    }

    /// <summary>
    /// get log database name from log connection string of web config
    /// </summary>
    /// <returns>data base name as string</returns>
    public string databaseLog()
    {
        // Obtain the database connection string  of log database
        string connectionString = DAL_WebConfiguration.DbLogConnectionString;

        // Create sql connection string builder
        SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder(connectionString);

        //return database of log  
        string dbLog = constr.InitialCatalog.ToString();
        return dbLog;
    }


    /// <summary>
    /// get user id from connection string
    /// </summary>
    /// <returns>return userID as string</returns>
    public string userID()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;

        // Create sql connection string builder
        SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder(connectionString);

        //return server name
        string user = constr.UserID.ToString();
        return user;
    }
    /// <summary>
    /// get password from connection string
    /// </summary>
    /// <returns>password of database as string</returns>
    public string Password()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;

        // Create sql connection string builder
        SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder(connectionString);

        //return server name
        string pass = constr.Password.ToString();
        return pass;
    }
    /// <summary>
    /// this method over write all the connection info of crystal report
    /// </summary>
    /// <param name="tbl">pass the crystal report database table like rpt.database.tables</param>


    // creates and prepares a new DbCommand object on a new connection(For QueryText)
    public DbCommand CreateCommand4QueryText()
    {
        // Obtain the database provider name
        string dataProviderName = DAL_WebConfiguration.DbProviderName;
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;
        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
        // Obtain a database specific connection object
        DbConnection conn = factory.CreateConnection();
        // Set the connection string
        conn.ConnectionString = connectionString;
        // Create a database specific command object
        DbCommand comm = conn.CreateCommand();
        // Set the command type to stored procedure
        comm.CommandType = CommandType.Text;
        // Return the initialized command object
        return comm;
    }

    public SqlCommand CreateCommand4QueryTextSql()
    {
        // Obtain the database connection string
        string connectionString = DAL_WebConfiguration.DbConnectionString;
        // Obtain a database specific connection object
        SqlConnection conn = new SqlConnection(connectionString);
        // Create a database specific command object
        SqlCommand comm = conn.CreateCommand();
        // Set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;
        // Return the initialized command object
        return comm;
    }

    /// <summary>
    /// this method over write all the connection info of crystal report
    /// </summary>
    /// <param name="tbl">pass the crystal report database table like rpt.database.tables</param>

}
