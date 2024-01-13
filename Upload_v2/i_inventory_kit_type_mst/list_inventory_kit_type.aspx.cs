using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
using System.Web.Services;
using Newtonsoft.Json;
using AjaxControlToolkit;

public partial class list_inventory_kit_type : COMM_SessionCheck
{
    public int insert_flag = 0;
    public int edit_flag = 0;
    public int delete_flag = 0;
    public int export_flag = 0;
    public int viewLog_flag = 0;
    public int deletedViewLog_flag = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            GetRightsData();
        }        
    }

    public void GetRightsData()
    {
        
         DataTable dtPermission = db_Menu.GetAllPermissions(DAL_Utilities.getpagename(), Handle.ToInt32(Session["user_id"]));        
        if (dtPermission != null && dtPermission.Rows.Count > 0)
        {
            if (dtPermission.Rows[0]["MenuID"].ToString() != "0")
            {
                DataRow[] drInsert = dtPermission.Select("uwp_per_id=1");
                insert_flag = (drInsert.Length > 0 ? 1 : 0);
                DataRow[] drEdit = dtPermission.Select("uwp_per_id=2");
                edit_flag = (drEdit.Length > 0 ? 1 : 0);
                DataRow[] drDelete = dtPermission.Select("uwp_per_id=3");
                delete_flag = (drDelete.Length > 0 ? 1 : 0);
                DataRow[] drExport = dtPermission.Select("uwp_per_id=5");
                export_flag = (drExport.Length > 0 ? 1 : 0);
                DataRow[] drViewLog = dtPermission.Select("uwp_per_id=6");
                viewLog_flag = (drViewLog.Length > 0 ? 1 : 0);
                DataRow[] drDeletedLogView = dtPermission.Select("uwp_per_id=7");
                deletedViewLog_flag = (drDeletedLogView.Length > 0 ? 1 : 0);
            }
            else
            {
                insert_flag = 1;
                edit_flag = 1;
                delete_flag = 1;
                export_flag = 1;
                viewLog_flag = 1;
                deletedViewLog_flag = 1;
            }
        }
    }   
}

/*

 case "Manage_Kit_Type_Master":
                ManageManage_Kit_Type_Master();
                break;

#region Manage_Kit_Type_Master

    public void ManageManage_Kit_Type_Master()
    {
        if (Request.Form["del_ktm_id"] != null && !string.IsNullOrEmpty(Request.Form["del_ktm_id"]))
        {
            DeleteManage_Kit_Type_Master(Handle.ToInt32(Request.Form["del_ktm_id"].ToString()));
        }
        else if (Request.Form["gktm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gktm_user_id"] ))
        {
            GetManage_Kit_Type_Master();
        }
        else if (Request.Form["dlv_ktm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ktm_user_id"]))
        {
            GetManage_Kit_Type_MasterDeletedLog();
        }
        else if (Request.Form["slv_ktm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ktm_id"] ))
        {
            GetManage_Kit_Type_MasterLog();
        }
    }

    #region DeleteManage_Kit_Type_Master
    /// <summary>
    /// use to delete Manage_Kit_Type_Master by passing Manage_Kit_Type_Master id
    /// </summary>    
    public void DeleteManage_Kit_Type_Master(int ktm_id)
    {
        if (db_inventory_kit_type_mst.Delete(ktm_id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress,Handle.ToInt32(Session["comp_id"])))
            Response.Write("1");
        else
            Response.Write("0");
    }
    #endregion

    #region GetManage_Kit_Type_Master
    /// <summary>
    /// use to get all Manage_Kit_Type_Master
    /// </summary>
    public void GetManage_Kit_Type_Master()
    {
        if (Request.Form["gktm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gktm_user_id"]))
        {
            DataTable dt = db_inventory_kit_type_mst.Get_inventory_kit_type_mst_select(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetManage_Kit_Type_MasterLog
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void GetManage_Kit_Type_MasterLog()
    {
        if (Request.Form["slv_ktm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ktm_id"]))
        {
            DataTable dt = db_inventory_kit_type_mst.Get_inventory_kit_type_mstLog(Handle.ToInt32(Request.Form["slv_ktm_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetManage_Kit_Type_MasterDeletedLog
    /// <summary>
    /// use to get all Manage_Kit_Type_Master
    /// </summary>
    public void GetManage_Kit_Type_MasterDeletedLog()
    {
        if (Request.Form["dlv_ktm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ktm_user_id"]) )
        {
            DataTable dt = db_inventory_kit_type_mst.Get_inventory_kit_type_mstDeletedLog(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #endregion
*/
