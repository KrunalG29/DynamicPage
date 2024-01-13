
//This file is generated programmatically
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;
using infinity;

/// <summary>
/// Summary description for db_iERP_task_log
/// </summary>
public class db_iERP_task_log
{

    public static string conString = @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=nothing1plus_SampleDB;User ID=nothing1plus_SampleDB;Password=DBSamplePW;Persist Security Info=True;";
    public db_iERP_task_log()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get_iERP_task_log_select Function
    /// <summary>
    /// This function use to get all iERP_task_log table data.
    /// </summary>
    /// <returns>This function is return all iERP_task_log data table</returns>
    public static DataTable Get_iERP_task_log_select()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_select";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Get_iERP_task_log_select Function
    /// <summary>
    /// This function use to get all iERP_task_log table data.
    /// </summary>
    /// <returns>This function is return all iERP_task_log data table</returns>
    public static DataTable Get_iERP_task_log_select_comp()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_select_comp";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Get_iERP_task_logLog Function
    /// <summary>
    /// This function is used to get log of _iERP_task_log by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_iERP_task_logLog(Int32 id, Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_iERP_task_log_log_select";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@id";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@comp_id";
        param.Value = comp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Get_iERP_task_logDeletedLog Function
    public static DataTable Get_iERP_task_logDeletedLog(Int32 userId, Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_iERP_task_log_del_log_select";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@user_id";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@comp_id";
        param.Value = comp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Get All iERP_task_log Function
    /// <summary>
    /// This function use to get all iERP_task_log table data.
    /// </summary>
    /// <returns>This function is return all iERP_task_log data table</returns>
    public static DataTable GetAll_iERP_task_log()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_iERP_task_log_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion

    #region Get_iERP_task_log_ByID Function
    /// <summary>
    /// This function is use to get iERP_task_log data by id
    /// </summary>
    /// <param name="id">Pass id</param>
    /// <returns>Return datatable in iERP_task_log data</returns>
    public static DataTable Get_iERP_task_log_ByID(int id, Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_selectby_id " + id +",1";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion

    #region Update Function
    /// <summary>
    /// This function is use to update the iERP_task_log data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_iERP_task_log</param>
    /// <returns>PROP_db_return property value</returns>
    public static DataTable Update(PROP_iERP_task_log obj)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_update " + obj.task_id + ",'" + obj.task_log + "','" + obj.task_comp + "'," + obj.id;

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Insert Function
    /// <summary>
    /// This function is insert data in to the iERP_task_log data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_iERP_task_log</param>
    /// <returns>PROP_db_return property value</returns>
    public static DataTable Insert(PROP_iERP_task_log obj)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_insert " + obj.task_id + ",'" + obj.task_log + "','" + obj.task_comp +"'";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Delete Function
    /// <summary>
    /// This function is used to delete the iERP_task_log data by id
    /// </summary>
    /// <param name="id">Pass integer id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if iERP_task_log data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id, int userId, string ip, Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_iERP_task_log_delete";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@id";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@user_id";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ip";
        param.Value = ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@comp_id";
        param.Value = comp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);


        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region GetIdByName Function
    public static DataTable GetIdByName(Int32 task_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        comm.CommandText = "exec i_iERP_task_log_IdByName " + task_id;
        // return the result table
        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion
}