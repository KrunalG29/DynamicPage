
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
/// Summary description for db_acct_bank_statement_payment_mst
/// </summary>
public class db_acct_bank_statement_payment_mst
{
    public db_acct_bank_statement_payment_mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_acct_bank_statement_payment_mst_select Function
    /// <summary>
    /// This function use to get all acct_bank_statement_payment_mst table data.
    /// </summary>
    /// <returns>This function is return all acct_bank_statement_payment_mst data table</returns>
    public static DataTable Get_acct_bank_statement_payment_mst_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_acct_bank_statement_payment_mst_select";

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

    #region Get_acct_bank_statement_payment_mstLog Function
    /// <summary>
    /// This function is used to get log of _acct_bank_statement_payment_mst by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_acct_bank_statement_payment_mstLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_acct_bank_statement_payment_mst_log_select";

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

    #region Get_acct_bank_statement_payment_mstDeletedLog Function
    public static DataTable Get_acct_bank_statement_payment_mstDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_acct_bank_statement_payment_mst_del_log_select";

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
    
    #region Get All acct_bank_statement_payment_mst Function
    /// <summary>
    /// This function use to get all acct_bank_statement_payment_mst table data.
    /// </summary>
    /// <returns>This function is return all acct_bank_statement_payment_mst data table</returns>
    public static DataTable GetAll_acct_bank_statement_payment_mst()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_acct_bank_statement_payment_mst_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_acct_bank_statement_payment_mst_ByID Function
    /// <summary>
    /// This function is use to get acct_bank_statement_payment_mst data by id
    /// </summary>
    /// <param name="id">Pass id</param>
    /// <returns>Return datatable in acct_bank_statement_payment_mst data</returns>
    public static DataTable Get_acct_bank_statement_payment_mst_ByID(int id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "i_acct_bank_statement_payment_mst_selectby_id";
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
    /// This function is use to update the acct_bank_statement_payment_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_acct_bank_statement_payment_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_acct_bank_statement_payment_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_acct_bank_statement_payment_mst_update_test";
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
        param.ParameterName = "bpm_bam_id";
        param.Value = obj.bpm_bam_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_date";
        param.Value = obj.bpm_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_from_date";
        param.Value = obj.bpm_from_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_to_date";
        param.Value = obj.bpm_to_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ven_ids";
        param.Value = obj.bpm_ven_ids;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_is_approved";
        param.Value = obj.bpm_is_approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_approval_date";
        param.Value = obj.bpm_approval_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_total_amount";
        param.Value = obj.bpm_total_amount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ipm_id";
        param.Value = obj.bpm_ipm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_is_issued";
        param.Value = obj.bpm_is_issued;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_hold_or_reject_reasons";
        param.Value = obj.bpm_hold_or_reject_reasons;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_payment_flag";
        param.Value = obj.bpm_payment_flag;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ven_grp_id";
        param.Value = obj.bpm_ven_grp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_branch_id";
        param.Value = obj.bpm_branch_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_entt_ref_type";
        param.Value = obj.bpm_entt_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_pay_mode";
        param.Value = obj.bpm_pay_mode;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_cheque_no";
        param.Value = obj.bpm_cheque_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_instrument_type";
        param.Value = obj.bpm_instrument_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_instrument_date";
        param.Value = obj.bpm_instrument_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_deposit_date";
        param.Value = obj.bpm_deposit_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_payment_type";
        param.Value = obj.bpm_payment_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bank_account_to";
        param.Value = obj.bpm_bank_account_to;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_cash_account";
        param.Value = obj.bpm_cash_account;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bam_account_number";
        param.Value = obj.bpm_bam_account_number;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bam_account_number_to";
        param.Value = obj.bpm_bam_account_number_to;
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
    /// This function is insert data in to the acct_bank_statement_payment_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_acct_bank_statement_payment_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_acct_bank_statement_payment_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_acct_bank_statement_payment_mst_insert_test";

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
        param.ParameterName = "bpm_bam_id";
        param.Value = obj.bpm_bam_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_date";
        param.Value = obj.bpm_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_from_date";
        param.Value = obj.bpm_from_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_to_date";
        param.Value = obj.bpm_to_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ven_ids";
        param.Value = obj.bpm_ven_ids;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_is_approved";
        param.Value = obj.bpm_is_approved;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_approval_date";
        param.Value = obj.bpm_approval_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_total_amount";
        param.Value = obj.bpm_total_amount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ipm_id";
        param.Value = obj.bpm_ipm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_is_issued";
        param.Value = obj.bpm_is_issued;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_hold_or_reject_reasons";
        param.Value = obj.bpm_hold_or_reject_reasons;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_payment_flag";
        param.Value = obj.bpm_payment_flag;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_ven_grp_id";
        param.Value = obj.bpm_ven_grp_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_branch_id";
        param.Value = obj.bpm_branch_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_entt_ref_type";
        param.Value = obj.bpm_entt_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_pay_mode";
        param.Value = obj.bpm_pay_mode;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_cheque_no";
        param.Value = obj.bpm_cheque_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_instrument_type";
        param.Value = obj.bpm_instrument_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_instrument_date";
        param.Value = obj.bpm_instrument_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_deposit_date";
        param.Value = obj.bpm_deposit_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_payment_type";
        param.Value = obj.bpm_payment_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bank_account_to";
        param.Value = obj.bpm_bank_account_to;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_cash_account";
        param.Value = obj.bpm_cash_account;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bam_account_number";
        param.Value = obj.bpm_bam_account_number;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "bpm_bam_account_number_to";
        param.Value = obj.bpm_bam_account_number_to;
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
    /// This function is used to delete the acct_bank_statement_payment_mst data by id
    /// </summary>
    /// <param name="id">Pass integer id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if acct_bank_statement_payment_mst data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_acct_bank_statement_payment_mst_delete";

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