
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
/// Summary description for db_std_instrument_entry_mst
/// </summary>
public class db_std_instrument_entry_mst
{
    public db_std_instrument_entry_mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_std_instrument_entry_mst_select Function
    /// <summary>
    /// This function use to get all std_instrument_entry_mst table data.
    /// </summary>
    /// <returns>This function is return all std_instrument_entry_mst data table</returns>
    public static DataTable Get_std_instrument_entry_mst_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_std_instrument_entry_mst_select";

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

    #region Get_std_instrument_entry_mstLog Function
    /// <summary>
    /// This function is used to get log of _std_instrument_entry_mst by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_std_instrument_entry_mstLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_std_instrument_entry_mst_log_select";

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

    #region Get_std_instrument_entry_mstDeletedLog Function
    public static DataTable Get_std_instrument_entry_mstDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_std_instrument_entry_mst_del_log_select";

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
    
    #region Get All std_instrument_entry_mst Function
    /// <summary>
    /// This function use to get all std_instrument_entry_mst table data.
    /// </summary>
    /// <returns>This function is return all std_instrument_entry_mst data table</returns>
    public static DataTable GetAll_std_instrument_entry_mst()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_std_instrument_entry_mst_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_std_instrument_entry_mst_ByID Function
    /// <summary>
    /// This function is use to get std_instrument_entry_mst data by id
    /// </summary>
    /// <param name="id">Pass id</param>
    /// <returns>Return datatable in std_instrument_entry_mst data</returns>
    public static DataTable Get_std_instrument_entry_mst_ByID(int id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "i_std_instrument_entry_mst_selectby_id";
        // create a new parameter
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

    #region Update Function
    /// <summary>
    /// This function is use to update the std_instrument_entry_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_std_instrument_entry_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_std_instrument_entry_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_std_instrument_entry_mst_update";
        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "id";
        param.Value = obj.id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "comp_id";
        param.Value = obj.comp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "status";
        param.Value = obj.status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "modify_by";
        param.Value = obj.modify_by;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "modify_ip";
        param.Value = obj.modify_ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_dept_id";
        param.Value = obj.siem_dept_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_name";
        param.Value = obj.siem_instr_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_gf_no";
        param.Value = obj.siem_gf_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_make";
        param.Value = obj.siem_instr_make;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_model_no";
        param.Value = obj.siem_model_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_sr_no";
        param.Value = obj.siem_instr_sr_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_pur_date";
        param.Value = obj.siem_instr_pur_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_avg_lifecycle";
        param.Value = obj.siem_avg_lifecycle;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_calib_req";
        param.Value = obj.siem_calib_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_calib_date";
        param.Value = obj.siem_instr_calib_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_calib_frequency";
        param.Value = obj.siem_calib_frequency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_next_calib_date";
        param.Value = obj.siem_next_calib_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_range";
        param.Value = obj.siem_range;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_LC";
        param.Value = obj.siem_LC;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_size";
        param.Value = obj.siem_size;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_class";
        param.Value = obj.siem_class;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_go";
        param.Value = obj.siem_go;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "siem_no_go";
        param.Value = obj.siem_no_go;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

         
        param = comm.CreateParameter();
        param.ParameterName = "@out_id";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@alert_msg";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.String;
        param.Size = 300;
        comm.Parameters.Add(param);       

        PROP_db_return retObj = new PROP_db_return();
        int resultval = gda.ExecuteNonQuery(comm);
        retObj.id = Handle.ToInt32(comm.Parameters["@out_id"].Value);
        retObj.alertMessage = Handle.ToString(comm.Parameters["@alert_msg"].Value);
        return retObj;
    }
    #endregion

    #region Insert Function
    /// <summary>
    /// This function is insert data in to the std_instrument_entry_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_std_instrument_entry_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_std_instrument_entry_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_std_instrument_entry_mst_insert";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "comp_id";
        param.Value = obj.comp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "status";
        param.Value = obj.status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "create_by";
        param.Value = obj.create_by;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "create_ip";
        param.Value = obj.create_ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_dept_id";
        param.Value = obj.siem_dept_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_name";
        param.Value = obj.siem_instr_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_gf_no";
        param.Value = obj.siem_gf_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_make";
        param.Value = obj.siem_instr_make;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_model_no";
        param.Value = obj.siem_model_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_sr_no";
        param.Value = obj.siem_instr_sr_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_pur_date";
        param.Value = obj.siem_instr_pur_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_avg_lifecycle";
        param.Value = obj.siem_avg_lifecycle;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_calib_req";
        param.Value = obj.siem_calib_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_instr_calib_date";
        param.Value = obj.siem_instr_calib_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_calib_frequency";
        param.Value = obj.siem_calib_frequency;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_next_calib_date";
        param.Value = obj.siem_next_calib_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_range";
        param.Value = obj.siem_range;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_LC";
        param.Value = obj.siem_LC;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_size";
        param.Value = obj.siem_size;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_class";
        param.Value = obj.siem_class;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_go";
        param.Value = obj.siem_go;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "siem_no_go";
        param.Value = obj.siem_no_go;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "@out_id";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@alert_msg";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.String;
        param.Size = 300;
        comm.Parameters.Add(param);       

        PROP_db_return retObj = new PROP_db_return();
        int resultval = gda.ExecuteNonQuery(comm);
        retObj.id = Handle.ToInt32(comm.Parameters["@out_id"].Value);
        retObj.alertMessage = Handle.ToString(comm.Parameters["@alert_msg"].Value);
        return retObj;
    }
    #endregion

    #region Delete Function
    /// <summary>
    /// This function is used to delete the std_instrument_entry_mst data by id
    /// </summary>
    /// <param name="id">Pass integer id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if std_instrument_entry_mst data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_std_instrument_entry_mst_delete";

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

    
}