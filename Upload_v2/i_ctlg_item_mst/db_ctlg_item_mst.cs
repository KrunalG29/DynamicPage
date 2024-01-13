
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
/// Summary description for db_ctlg_item_mst
/// </summary>
public class db_ctlg_item_mst
{
    public db_ctlg_item_mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_ctlg_item_mst_select Function
    /// <summary>
    /// This function use to get all ctlg_item_mst table data.
    /// </summary>
    /// <returns>This function is return all ctlg_item_mst data table</returns>
    public static DataTable Get_ctlg_item_mst_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_ctlg_item_mst_select";

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

    #region Get_ctlg_item_mstLog Function
    /// <summary>
    /// This function is used to get log of _ctlg_item_mst by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_ctlg_item_mstLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_ctlg_item_mst_log_select";

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

    #region Get_ctlg_item_mstDeletedLog Function
    public static DataTable Get_ctlg_item_mstDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_ctlg_item_mst_del_log_select";

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
    
    #region Get All ctlg_item_mst Function
    /// <summary>
    /// This function use to get all ctlg_item_mst table data.
    /// </summary>
    /// <returns>This function is return all ctlg_item_mst data table</returns>
    public static DataTable GetAll_ctlg_item_mst()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_ctlg_item_mst_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_ctlg_item_mst_ByID Function
    /// <summary>
    /// This function is use to get ctlg_item_mst data by id
    /// </summary>
    /// <param name="id">Pass id</param>
    /// <returns>Return datatable in ctlg_item_mst data</returns>
    public static DataTable Get_ctlg_item_mst_ByID(int id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "i_ctlg_item_mst_selectby_id";
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
    /// This function is use to update the ctlg_item_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_ctlg_item_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_ctlg_item_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_ctlg_item_mst_update";
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
        param.ParameterName = "itm_name";
        param.Value = obj.itm_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_code";
        param.Value = obj.itm_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_cat_id";
        param.Value = obj.itm_cat_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_tax_free";
        param.Value = obj.itm_is_tax_free;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_tax_class";
        param.Value = obj.itm_tax_class;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_HSN_code";
        param.Value = obj.itm_HSN_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_sales_invoice_series_code";
        param.Value = obj.itm_sales_invoice_series_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_allow_nagative_stock";
        param.Value = obj.itm_allow_nagative_stock;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_uom";
        param.Value = obj.itm_uom;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_quality";
        param.Value = obj.itm_manage_quality;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_attributes";
        param.Value = obj.itm_manage_attributes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_tool";
        param.Value = obj.itm_is_tool;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_allow_trading";
        param.Value = obj.itm_allow_trading;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ref_id";
        param.Value = obj.itm_ref_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ref_type";
        param.Value = obj.itm_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_reorder_level";
        param.Value = obj.itm_reorder_level;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_expire_duration";
        param.Value = obj.itm_expire_duration;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_photo";
        param.Value = obj.itm_photo;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_original_photo";
        param.Value = obj.itm_original_photo;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_special";
        param.Value = obj.itm_is_special;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_unit_conv_req";
        param.Value = obj.itm_unit_conv_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_short_name";
        param.Value = obj.itm_short_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_packing_mat";
        param.Value = obj.itm_is_packing_mat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_item_formula";
        param.Value = obj.itm_item_formula;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_print_name";
        param.Value = obj.itm_print_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_specification";
        param.Value = obj.itm_specification;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_parent_id";
        param.Value = obj.itm_parent_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_com_generate";
        param.Value = obj.itm_is_com_generate;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_wastage_itm_id";
        param.Value = obj.itm_wastage_itm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mng_sr_no_flag";
        param.Value = obj.itm_mng_sr_no_flag;
        param.DbType = DbType.;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_max_stock_level";
        param.Value = obj.itm_max_stock_level;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_key";
        param.Value = obj.itm_key;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_lock";
        param.Value = obj.itm_purchase_lock;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_batch";
        param.Value = obj.itm_manage_batch;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_drawing";
        param.Value = obj.itm_drawing;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_original_drawing";
        param.Value = obj.itm_original_drawing;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_item_type";
        param.Value = obj.itm_item_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_parent_code_id";
        param.Value = obj.itm_parent_code_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_relative_code_id";
        param.Value = obj.itm_relative_code_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_sequre";
        param.Value = obj.itm_is_sequre;
        param.DbType = DbType.;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approval_status";
        param.Value = obj.itm_approval_status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approve_dt";
        param.Value = obj.itm_approve_dt;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approve_by";
        param.Value = obj.itm_approve_by;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_hold_reject_reason";
        param.Value = obj.itm_hold_reject_reason;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_gross_weight";
        param.Value = obj.itm_gross_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_net_weight";
        param.Value = obj.itm_net_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_psquare";
        param.Value = obj.itm_is_psquare;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_brand_name";
        param.Value = obj.itm_brand_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ER6_item";
        param.Value = obj.itm_ER6_item;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ER6_group";
        param.Value = obj.itm_ER6_group;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_barcode_desc";
        param.Value = obj.itm_barcode_desc;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_warranty_terms";
        param.Value = obj.itm_warranty_terms;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_packing_size";
        param.Value = obj.itm_packing_size;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_length";
        param.Value = obj.itm_length;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_volumn_in";
        param.Value = obj.itm_volumn_in;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_model_no";
        param.Value = obj.itm_model_no;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_drawing_no";
        param.Value = obj.itm_drawing_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_revision_no";
        param.Value = obj.itm_revision_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_certificate_id";
        param.Value = obj.itm_certificate_id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_trolly_type";
        param.Value = obj.itm_trolly_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_width";
        param.Value = obj.itm_width;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_height";
        param.Value = obj.itm_height;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_dimension";
        param.Value = obj.itm_dimension;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mfg_lead_time";
        param.Value = obj.itm_mfg_lead_time;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_lead_time";
        param.Value = obj.itm_purchase_lead_time;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_location";
        param.Value = obj.itm_location;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_remark";
        param.Value = obj.itm_remark;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_technical_code";
        param.Value = obj.itm_technical_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_in_ward_inspection";
        param.Value = obj.itm_is_in_ward_inspection;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_in_inspection_type";
        param.Value = obj.itm_in_inspection_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_out_ward_inspection";
        param.Value = obj.itm_is_out_ward_inspection;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_out_inspection_type";
        param.Value = obj.itm_out_inspection_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_batch_no";
        param.Value = obj.itm_is_batch_no;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_bom";
        param.Value = obj.itm_is_bom;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_job_work_issue";
        param.Value = obj.itm_is_job_work_issue;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_raw_material_type";
        param.Value = obj.itm_raw_material_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_description";
        param.Value = obj.itm_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_code1";
        param.Value = obj.itm_code1;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_model_without_par";
        param.Value = obj.itm_model_without_par;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_main_cat";
        param.Value = obj.itm_group_main_cat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_sub_group";
        param.Value = obj.itm_sub_group;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_sub_cat";
        param.Value = obj.itm_group_sub_cat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_show_in_summery";
        param.Value = obj.itm_show_in_summery;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_for_id";
        param.Value = obj.itm_purchase_for_id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_letter_remark";
        param.Value = obj.itm_letter_remark;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_occasion_ids";
        param.Value = obj.itm_occasion_ids;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_with_product";
        param.Value = obj.itm_group_with_product;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_uom_per_unit_price";
        param.Value = obj.itm_uom_per_unit_price;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_grade";
        param.Value = obj.itm_grade;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_composition_cess_applicable";
        param.Value = obj.itm_composition_cess_applicable;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_weight_bridge_item";
        param.Value = obj.itm_is_weight_bridge_item;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mng_waste_stk";
        param.Value = obj.itm_mng_waste_stk;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_material_approval_req";
        param.Value = obj.itm_material_approval_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_stk_at_department_req";
        param.Value = obj.itm_stk_at_department_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_display_in_daily_activity";
        param.Value = obj.itm_display_in_daily_activity;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_freight_applicable";
        param.Value = obj.itm_freight_applicable;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_applicable_taxes_for";
        param.Value = obj.itm_applicable_taxes_for;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_hsn_info_req";
        param.Value = obj.itm_hsn_info_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_service_info_req";
        param.Value = obj.itm_service_info_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_has_multiple_gst_slab";
        param.Value = obj.itm_has_multiple_gst_slab;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_rcm_force";
        param.Value = obj.itm_is_rcm_force;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ITC_eligible";
        param.Value = obj.itm_ITC_eligible;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ITC_eligible_effective_from";
        param.Value = obj.itm_ITC_eligible_effective_from;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_forced_ITC_ineligible";
        param.Value = obj.itm_forced_ITC_ineligible;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "itm_forced_ITC_ineligible_effective_from";
        param.Value = obj.itm_forced_ITC_ineligible_effective_from;
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
    /// This function is insert data in to the ctlg_item_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_ctlg_item_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_ctlg_item_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_ctlg_item_mst_insert";

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
        param.ParameterName = "itm_name";
        param.Value = obj.itm_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_code";
        param.Value = obj.itm_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_cat_id";
        param.Value = obj.itm_cat_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_tax_free";
        param.Value = obj.itm_is_tax_free;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_tax_class";
        param.Value = obj.itm_tax_class;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_HSN_code";
        param.Value = obj.itm_HSN_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_sales_invoice_series_code";
        param.Value = obj.itm_sales_invoice_series_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_allow_nagative_stock";
        param.Value = obj.itm_allow_nagative_stock;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_uom";
        param.Value = obj.itm_uom;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_quality";
        param.Value = obj.itm_manage_quality;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_attributes";
        param.Value = obj.itm_manage_attributes;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_tool";
        param.Value = obj.itm_is_tool;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_allow_trading";
        param.Value = obj.itm_allow_trading;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ref_id";
        param.Value = obj.itm_ref_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ref_type";
        param.Value = obj.itm_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_reorder_level";
        param.Value = obj.itm_reorder_level;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_expire_duration";
        param.Value = obj.itm_expire_duration;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_photo";
        param.Value = obj.itm_photo;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_original_photo";
        param.Value = obj.itm_original_photo;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_special";
        param.Value = obj.itm_is_special;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_unit_conv_req";
        param.Value = obj.itm_unit_conv_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_short_name";
        param.Value = obj.itm_short_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_packing_mat";
        param.Value = obj.itm_is_packing_mat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_item_formula";
        param.Value = obj.itm_item_formula;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_print_name";
        param.Value = obj.itm_print_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_specification";
        param.Value = obj.itm_specification;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_parent_id";
        param.Value = obj.itm_parent_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_com_generate";
        param.Value = obj.itm_is_com_generate;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_wastage_itm_id";
        param.Value = obj.itm_wastage_itm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mng_sr_no_flag";
        param.Value = obj.itm_mng_sr_no_flag;
        param.DbType = DbType.;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_max_stock_level";
        param.Value = obj.itm_max_stock_level;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_key";
        param.Value = obj.itm_key;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_lock";
        param.Value = obj.itm_purchase_lock;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_manage_batch";
        param.Value = obj.itm_manage_batch;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_drawing";
        param.Value = obj.itm_drawing;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_original_drawing";
        param.Value = obj.itm_original_drawing;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_item_type";
        param.Value = obj.itm_item_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_parent_code_id";
        param.Value = obj.itm_parent_code_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_relative_code_id";
        param.Value = obj.itm_relative_code_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_sequre";
        param.Value = obj.itm_is_sequre;
        param.DbType = DbType.;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approval_status";
        param.Value = obj.itm_approval_status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approve_dt";
        param.Value = obj.itm_approve_dt;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_approve_by";
        param.Value = obj.itm_approve_by;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_hold_reject_reason";
        param.Value = obj.itm_hold_reject_reason;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_gross_weight";
        param.Value = obj.itm_gross_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_net_weight";
        param.Value = obj.itm_net_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_psquare";
        param.Value = obj.itm_is_psquare;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_brand_name";
        param.Value = obj.itm_brand_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ER6_item";
        param.Value = obj.itm_ER6_item;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ER6_group";
        param.Value = obj.itm_ER6_group;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_barcode_desc";
        param.Value = obj.itm_barcode_desc;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_warranty_terms";
        param.Value = obj.itm_warranty_terms;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_packing_size";
        param.Value = obj.itm_packing_size;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_length";
        param.Value = obj.itm_length;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_volumn_in";
        param.Value = obj.itm_volumn_in;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_model_no";
        param.Value = obj.itm_model_no;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_drawing_no";
        param.Value = obj.itm_drawing_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_revision_no";
        param.Value = obj.itm_revision_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_certificate_id";
        param.Value = obj.itm_certificate_id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_trolly_type";
        param.Value = obj.itm_trolly_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_width";
        param.Value = obj.itm_width;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_height";
        param.Value = obj.itm_height;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_dimension";
        param.Value = obj.itm_dimension;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mfg_lead_time";
        param.Value = obj.itm_mfg_lead_time;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_lead_time";
        param.Value = obj.itm_purchase_lead_time;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_location";
        param.Value = obj.itm_location;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_remark";
        param.Value = obj.itm_remark;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_technical_code";
        param.Value = obj.itm_technical_code;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_in_ward_inspection";
        param.Value = obj.itm_is_in_ward_inspection;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_in_inspection_type";
        param.Value = obj.itm_in_inspection_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_out_ward_inspection";
        param.Value = obj.itm_is_out_ward_inspection;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_out_inspection_type";
        param.Value = obj.itm_out_inspection_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_batch_no";
        param.Value = obj.itm_is_batch_no;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_bom";
        param.Value = obj.itm_is_bom;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_job_work_issue";
        param.Value = obj.itm_is_job_work_issue;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_raw_material_type";
        param.Value = obj.itm_raw_material_type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_description";
        param.Value = obj.itm_description;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_code1";
        param.Value = obj.itm_code1;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_model_without_par";
        param.Value = obj.itm_model_without_par;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_main_cat";
        param.Value = obj.itm_group_main_cat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_sub_group";
        param.Value = obj.itm_sub_group;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_sub_cat";
        param.Value = obj.itm_group_sub_cat;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_show_in_summery";
        param.Value = obj.itm_show_in_summery;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_purchase_for_id";
        param.Value = obj.itm_purchase_for_id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_letter_remark";
        param.Value = obj.itm_letter_remark;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_occasion_ids";
        param.Value = obj.itm_occasion_ids;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_group_with_product";
        param.Value = obj.itm_group_with_product;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_uom_per_unit_price";
        param.Value = obj.itm_uom_per_unit_price;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_grade";
        param.Value = obj.itm_grade;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_composition_cess_applicable";
        param.Value = obj.itm_composition_cess_applicable;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_weight_bridge_item";
        param.Value = obj.itm_is_weight_bridge_item;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_mng_waste_stk";
        param.Value = obj.itm_mng_waste_stk;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_material_approval_req";
        param.Value = obj.itm_material_approval_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_stk_at_department_req";
        param.Value = obj.itm_stk_at_department_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_display_in_daily_activity";
        param.Value = obj.itm_display_in_daily_activity;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_freight_applicable";
        param.Value = obj.itm_freight_applicable;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_applicable_taxes_for";
        param.Value = obj.itm_applicable_taxes_for;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_hsn_info_req";
        param.Value = obj.itm_hsn_info_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_service_info_req";
        param.Value = obj.itm_service_info_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_has_multiple_gst_slab";
        param.Value = obj.itm_has_multiple_gst_slab;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_is_rcm_force";
        param.Value = obj.itm_is_rcm_force;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ITC_eligible";
        param.Value = obj.itm_ITC_eligible;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_ITC_eligible_effective_from";
        param.Value = obj.itm_ITC_eligible_effective_from;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_forced_ITC_ineligible";
        param.Value = obj.itm_forced_ITC_ineligible;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "itm_forced_ITC_ineligible_effective_from";
        param.Value = obj.itm_forced_ITC_ineligible_effective_from;
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
    /// This function is used to delete the ctlg_item_mst data by id
    /// </summary>
    /// <param name="id">Pass integer id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if ctlg_item_mst data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_ctlg_item_mst_delete";

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