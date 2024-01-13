
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
/// Summary description for db_purc_weigh_bridge_in_mst
/// </summary>
public class db_purc_weigh_bridge_in_mst
{
    public db_purc_weigh_bridge_in_mst()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     #region Get_purc_weigh_bridge_in_mst_select Function
    /// <summary>
    /// This function use to get all purc_weigh_bridge_in_mst table data.
    /// </summary>
    /// <returns>This function is return all purc_weigh_bridge_in_mst data table</returns>
    public static DataTable Get_purc_weigh_bridge_in_mst_select(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_purc_weigh_bridge_in_mst_select";

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

    #region Get_purc_weigh_bridge_in_mstLog Function
    /// <summary>
    /// This function is used to get log of _purc_weigh_bridge_in_mst by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get_purc_weigh_bridge_in_mstLog(Int32 id,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_purc_weigh_bridge_in_mst_log_select";

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

    #region Get_purc_weigh_bridge_in_mstDeletedLog Function
    public static DataTable Get_purc_weigh_bridge_in_mstDeletedLog(Int32 userId,Int32 comp_id)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_purc_weigh_bridge_in_mst_del_log_select";

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
    
    #region Get All purc_weigh_bridge_in_mst Function
    /// <summary>
    /// This function use to get all purc_weigh_bridge_in_mst table data.
    /// </summary>
    /// <returns>This function is return all purc_weigh_bridge_in_mst data table</returns>
    public static DataTable GetAll_purc_weigh_bridge_in_mst()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_purc_weigh_bridge_in_mst_select_all";

        /// return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion
    
    
    #region Get_purc_weigh_bridge_in_mst_ByID Function
    /// <summary>
    /// This function is use to get purc_weigh_bridge_in_mst data by id
    /// </summary>
    /// <param name="id">Pass id</param>
    /// <returns>Return datatable in purc_weigh_bridge_in_mst data</returns>
    public static DataTable Get_purc_weigh_bridge_in_mst_ByID(int id,Int32 comp_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "i_purc_weigh_bridge_in_mst_selectby_id";
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
    /// This function is use to update the purc_weigh_bridge_in_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_purc_weigh_bridge_in_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Update(PROP_purc_weigh_bridge_in_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_purc_weigh_bridge_in_mst_update";
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
        param.ParameterName = "wbi_date";
        param.Value = obj.wbi_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_no";
        param.Value = obj.wbi_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ven_id";
        param.Value = obj.wbi_ven_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_tra_id";
        param.Value = obj.wbi_tra_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_id";
        param.Value = obj.wbi_ref_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_type";
        param.Value = obj.wbi_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_challan_no";
        param.Value = obj.wbi_ref_challan_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_itm_id";
        param.Value = obj.wbi_itm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_vehicle_no";
        param.Value = obj.wbi_vehicle_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_gross_qty";
        param.Value = obj.wbi_gross_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_tare_qty";
        param.Value = obj.wbi_tare_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_net_qty";
        param.Value = obj.wbi_net_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_weigh_bridge_id";
        param.Value = obj.wbi_weigh_bridge_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_truck_weight";
        param.Value = obj.wbi_truck_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_driver_name";
        param.Value = obj.wbi_driver_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_driver_contact_no";
        param.Value = obj.wbi_driver_contact_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_current_status";
        param.Value = obj.wbi_current_status;
        param.DbType = DbType.Int32;
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
    /// This function is insert data in to the purc_weigh_bridge_in_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_purc_weigh_bridge_in_mst</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert(PROP_purc_weigh_bridge_in_mst obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_purc_weigh_bridge_in_mst_insert";

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
        param.ParameterName = "wbi_date";
        param.Value = obj.wbi_date;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_no";
        param.Value = obj.wbi_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ven_id";
        param.Value = obj.wbi_ven_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_tra_id";
        param.Value = obj.wbi_tra_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_id";
        param.Value = obj.wbi_ref_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_type";
        param.Value = obj.wbi_ref_type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_ref_challan_no";
        param.Value = obj.wbi_ref_challan_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_itm_id";
        param.Value = obj.wbi_itm_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_vehicle_no";
        param.Value = obj.wbi_vehicle_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_gross_qty";
        param.Value = obj.wbi_gross_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_tare_qty";
        param.Value = obj.wbi_tare_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_net_qty";
        param.Value = obj.wbi_net_qty;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_weigh_bridge_id";
        param.Value = obj.wbi_weigh_bridge_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_truck_weight";
        param.Value = obj.wbi_truck_weight;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_driver_name";
        param.Value = obj.wbi_driver_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_driver_contact_no";
        param.Value = obj.wbi_driver_contact_no;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        
        
        param = comm.CreateParameter();
        param.ParameterName = "wbi_current_status";
        param.Value = obj.wbi_current_status;
        param.DbType = DbType.Int32;
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
    /// This function is used to delete the purc_weigh_bridge_in_mst data by id
    /// </summary>
    /// <param name="id">Pass integer id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if purc_weigh_bridge_in_mst data is deleted then true otherwise false</returns>
    public static Boolean Delete(int id,int userId,string ip,Int32 comp_id)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_purc_weigh_bridge_in_mst_delete";

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