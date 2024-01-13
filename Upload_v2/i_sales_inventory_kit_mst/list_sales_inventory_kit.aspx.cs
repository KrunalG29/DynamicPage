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

public partial class list_sales_inventory_kit : COMM_SessionCheck
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

 case "Kit_Master":
                ManageKit_Master();
                break;

#region Kit_Master

    public void ManageKit_Master()
    {
        if (Request.Form["del_ikm_id"] != null && !string.IsNullOrEmpty(Request.Form["del_ikm_id"]))
        {
            DeleteKit_Master(Handle.ToInt32(Request.Form["del_ikm_id"].ToString()));
        }
        else if (Request.Form["gikm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gikm_user_id"] ))
        {
            GetKit_Master();
        }
        else if (Request.Form["dlv_ikm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ikm_user_id"]))
        {
            GetKit_MasterDeletedLog();
        }
        else if (Request.Form["slv_ikm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ikm_id"] ))
        {
            GetKit_MasterLog();
        }
    }

    #region DeleteKit_Master
    /// <summary>
    /// use to delete Kit_Master by passing Kit_Master id
    /// </summary>    
    public void DeleteKit_Master(int ikm_id)
    {
        if (db_sales_inventory_kit_mst.Delete(ikm_id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress,Handle.ToInt32(Session["comp_id"])))
            Response.Write("1");
        else
            Response.Write("0");
    }
    #endregion

    #region GetKit_Master
    /// <summary>
    /// use to get all Kit_Master
    /// </summary>
    public void GetKit_Master()
    {
        if (Request.Form["gikm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gikm_user_id"]))
        {
            DataTable dt = db_sales_inventory_kit_mst.Get_sales_inventory_kit_mst_select(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetKit_MasterLog
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void GetKit_MasterLog()
    {
        if (Request.Form["slv_ikm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ikm_id"]))
        {
            DataTable dt = db_sales_inventory_kit_mst.Get_sales_inventory_kit_mstLog(Handle.ToInt32(Request.Form["slv_ikm_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetKit_MasterDeletedLog
    /// <summary>
    /// use to get all Kit_Master
    /// </summary>
    public void GetKit_MasterDeletedLog()
    {
        if (Request.Form["dlv_ikm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ikm_user_id"]) )
        {
            DataTable dt = db_sales_inventory_kit_mst.Get_sales_inventory_kit_mstDeletedLog(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #endregion
*/
