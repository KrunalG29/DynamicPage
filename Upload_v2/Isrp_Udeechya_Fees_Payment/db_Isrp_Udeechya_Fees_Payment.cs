
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
/// Summary description for db_Isrp_Udeechya_Fees_Payment
/// </summary>
public class db_Isrp_Udeechya_Fees_Payment
{
    public db_Isrp_Udeechya_Fees_Payment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_Isrp_Udeechya_Fees_Payment_select Function
    /// <summary>
    /// This function use to get all Isrp_Udeechya_Fees_Payment table data.
    /// </summary>
    /// <returns>This function is return all Isrp_Udeechya_Fees_Payment data table</returns>
    public static DataTable Get_Isrp_Udeechya_Fees_Payment_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_select";

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

    #region Get_Isrp_Udeechya_Fees_PaymentLog Function
    /// <summary>
    /// This function is used to get log of _Isrp_Udeechya_Fees_Payment by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_Isrp_Udeechya_Fees_PaymentLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_log_select";

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

    #region Get_Isrp_Udeechya_Fees_PaymentDeletedLog Function
    public static DataTable Get_Isrp_Udeechya_Fees_PaymentDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_del_log_select";

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
    
    #region Get All Isrp_Udeechya_Fees_Payment Function
    /// <summary>
    /// This function use to get all Isrp_Udeechya_Fees_Payment table data.
    /// </summary>
    /// <returns>This function is return all Isrp_Udeechya_Fees_Payment data table</returns>
    public static DataTable GetAll_Isrp_Udeechya_Fees_Payment()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_Isrp_Udeechya_Fees_Payment_ByID Function
    /// <summary>
    /// This function is use to get Isrp_Udeechya_Fees_Payment data by ufp_id
    /// </summary>
    /// <param name="ufp_id">Pass ufp_id</param>
    /// <returns>Return datatable in Isrp_Udeechya_Fees_Payment data</returns>
    public static DataTable Get_Isrp_Udeechya_Fees_Payment_ByID(int ufp_id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_selectby_id";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ufp_id";
        param.Value = ufp_id;
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
    /// This function is use to update the Isrp_Udeechya_Fees_Payment data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_Isrp_Udeechya_Fees_Payment</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_Isrp_Udeechya_Fees_Payment obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_update";
        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "ufp_id";
        param.Value = obj.ufp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_institute_id";
        param.Value = obj.ufp_institute_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_year_id";
        param.Value = obj.ufp_year_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_application_no";
        param.Value = obj.ufp_application_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_description";
        param.Value = obj.ufp_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_user_type";
        param.Value = obj.ufp_user_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_fees_amount";
        param.Value = obj.ufp_fees_amount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_payment_status";
        param.Value = obj.ufp_payment_status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_ifcu_id";
        param.Value = obj.ufp_ifcu_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Is_Status";
        param.Value = obj.ufp_Is_Status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Is_Delete";
        param.Value = obj.ufp_Is_Delete;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_By";
        param.Value = obj.ufp_Created_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_Date";
        param.Value = obj.ufp_Created_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_Ip";
        param.Value = obj.ufp_Created_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_By";
        param.Value = obj.ufp_Modify_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_Date";
        param.Value = obj.ufp_Modify_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_Ip";
        param.Value = obj.ufp_Modify_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_By";
        param.Value = obj.ufp_Deleted_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_Date";
        param.Value = obj.ufp_Deleted_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_Ip";
        param.Value = obj.ufp_Deleted_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_payment_date";
        param.Value = obj.ufp_payment_date;
        param.DbType = DbType.DateTime;
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
    /// This function is insert data in to the Isrp_Udeechya_Fees_Payment data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_Isrp_Udeechya_Fees_Payment</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_Isrp_Udeechya_Fees_Payment obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_insert";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "ufp_id";
        param.Value = obj.ufp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_institute_id";
        param.Value = obj.ufp_institute_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_year_id";
        param.Value = obj.ufp_year_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_application_no";
        param.Value = obj.ufp_application_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_description";
        param.Value = obj.ufp_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_user_type";
        param.Value = obj.ufp_user_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_fees_amount";
        param.Value = obj.ufp_fees_amount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_payment_status";
        param.Value = obj.ufp_payment_status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_ifcu_id";
        param.Value = obj.ufp_ifcu_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Is_Status";
        param.Value = obj.ufp_Is_Status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Is_Delete";
        param.Value = obj.ufp_Is_Delete;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_By";
        param.Value = obj.ufp_Created_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_Date";
        param.Value = obj.ufp_Created_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Created_Ip";
        param.Value = obj.ufp_Created_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_By";
        param.Value = obj.ufp_Modify_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_Date";
        param.Value = obj.ufp_Modify_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Modify_Ip";
        param.Value = obj.ufp_Modify_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_By";
        param.Value = obj.ufp_Deleted_By;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_Date";
        param.Value = obj.ufp_Deleted_Date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_Deleted_Ip";
        param.Value = obj.ufp_Deleted_Ip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "ufp_payment_date";
        param.Value = obj.ufp_payment_date;
        param.DbType = DbType.DateTime;
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
    /// This function is used to delete the Isrp_Udeechya_Fees_Payment data by ufp_id
    /// </summary>
    /// <param name="id">Pass integer ufp_id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if Isrp_Udeechya_Fees_Payment data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "Isrp_Udeechya_Fees_Payment_delete";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ufp_id";
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