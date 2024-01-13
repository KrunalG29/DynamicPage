
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
/// Summary description for db_Isrp_upload_udeechya_content_detail
/// </summary>
public class db_Isrp_upload_udeechya_content_detail
{
    public db_Isrp_upload_udeechya_content_detail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_Isrp_upload_udeechya_content_detail_select Function
    /// <summary>
    /// This function use to get all Isrp_upload_udeechya_content_detail table data.
    /// </summary>
    /// <returns>This function is return all Isrp_upload_udeechya_content_detail data table</returns>
    public static DataTable Get_Isrp_upload_udeechya_content_detail_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_upload_udeechya_content_detail_select";

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

    #region Get_Isrp_upload_udeechya_content_detailLog Function
    /// <summary>
    /// This function is used to get log of _Isrp_upload_udeechya_content_detail by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_Isrp_upload_udeechya_content_detailLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_upload_udeechya_content_detail_log_select";

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

    #region Get_Isrp_upload_udeechya_content_detailDeletedLog Function
    public static DataTable Get_Isrp_upload_udeechya_content_detailDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_upload_udeechya_content_detail_del_log_select";

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
    
    #region Get All Isrp_upload_udeechya_content_detail Function
    /// <summary>
    /// This function use to get all Isrp_upload_udeechya_content_detail table data.
    /// </summary>
    /// <returns>This function is return all Isrp_upload_udeechya_content_detail data table</returns>
    public static DataTable GetAll_Isrp_upload_udeechya_content_detail()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_upload_udeechya_content_detail_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_Isrp_upload_udeechya_content_detail_ByID Function
    /// <summary>
    /// This function is use to get Isrp_upload_udeechya_content_detail data by iuucd_id
    /// </summary>
    /// <param name="iuucd_id">Pass iuucd_id</param>
    /// <returns>Return datatable in Isrp_upload_udeechya_content_detail data</returns>
    public static DataTable Get_Isrp_upload_udeechya_content_detail_ByID(int iuucd_id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Isrp_upload_udeechya_content_detail_selectby_id";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@iuucd_id";
        param.Value = iuucd_id;
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
    /// This function is use to update the Isrp_upload_udeechya_content_detail data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_Isrp_upload_udeechya_content_detail</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_Isrp_upload_udeechya_content_detail obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_upload_udeechya_content_detail_update";
        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_id";
        param.Value = obj.iuucd_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_institute_id";
        param.Value = obj.iuucd_institute_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_iuuc_id";
        param.Value = obj.iuucd_iuuc_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_file_path";
        param.Value = obj.iuucd_file_path;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_description";
        param.Value = obj.iuucd_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_file_name";
        param.Value = obj.iuucd_file_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Is_Status";
        param.Value = obj.iuucd_Is_Status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Is_Delete";
        param.Value = obj.iuucd_Is_Delete;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_By";
        param.Value = obj.iuucd_Created_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_Date";
        param.Value = obj.iuucd_Created_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_Ip";
        param.Value = obj.iuucd_Created_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_By";
        param.Value = obj.iuucd_Modify_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_Date";
        param.Value = obj.iuucd_Modify_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_Ip";
        param.Value = obj.iuucd_Modify_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_By";
        param.Value = obj.iuucd_Deleted_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_Date";
        param.Value = obj.iuucd_Deleted_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_Ip";
        param.Value = obj.iuucd_Deleted_Ip;
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
    /// This function is insert data in to the Isrp_upload_udeechya_content_detail data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_Isrp_upload_udeechya_content_detail</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_Isrp_upload_udeechya_content_detail obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_upload_udeechya_content_detail_insert";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_id";
        param.Value = obj.iuucd_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_institute_id";
        param.Value = obj.iuucd_institute_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_iuuc_id";
        param.Value = obj.iuucd_iuuc_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_file_path";
        param.Value = obj.iuucd_file_path;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_description";
        param.Value = obj.iuucd_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_file_name";
        param.Value = obj.iuucd_file_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Is_Status";
        param.Value = obj.iuucd_Is_Status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Is_Delete";
        param.Value = obj.iuucd_Is_Delete;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_By";
        param.Value = obj.iuucd_Created_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_Date";
        param.Value = obj.iuucd_Created_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Created_Ip";
        param.Value = obj.iuucd_Created_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_By";
        param.Value = obj.iuucd_Modify_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_Date";
        param.Value = obj.iuucd_Modify_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Modify_Ip";
        param.Value = obj.iuucd_Modify_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_By";
        param.Value = obj.iuucd_Deleted_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_Date";
        param.Value = obj.iuucd_Deleted_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "iuucd_Deleted_Ip";
        param.Value = obj.iuucd_Deleted_Ip;
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
    /// This function is used to delete the Isrp_upload_udeechya_content_detail data by iuucd_id
    /// </summary>
    /// <param name="id">Pass integer iuucd_id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if Isrp_upload_udeechya_content_detail data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_upload_udeechya_content_detail_delete";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@iuucd_id";
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