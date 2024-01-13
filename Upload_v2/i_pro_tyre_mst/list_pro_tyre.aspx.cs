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

public partial class list_pro_tyre : COMM_SessionCheck
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

 case "":
                Manage();
                break;

#region 

    public void Manage()
    {
        if (Request.Form["del_tm_id"] != null && !string.IsNullOrEmpty(Request.Form["del_tm_id"]))
        {
            Delete(Handle.ToInt32(Request.Form["del_tm_id"].ToString()));
        }
        else if (Request.Form["gtm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gtm_user_id"] ))
        {
            Get();
        }
        else if (Request.Form["dlv_tm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_tm_user_id"]))
        {
            GetDeletedLog();
        }
        else if (Request.Form["slv_tm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_tm_id"] ))
        {
            GetLog();
        }
    }

    #region Delete
    /// <summary>
    /// use to delete  by passing  id
    /// </summary>    
    public void Delete(int tm_id)
    {
        if (db_pro_tyre_mst.Delete(tm_id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress,Handle.ToInt32(Session["comp_id"])))
            Response.Write("1");
        else
            Response.Write("0");
    }
    #endregion

    #region Get
    /// <summary>
    /// use to get all 
    /// </summary>
    public void Get()
    {
        if (Request.Form["gtm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gtm_user_id"]))
        {
            DataTable dt = db_pro_tyre_mst.Get_pro_tyre_mst_select(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetLog
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void GetLog()
    {
        if (Request.Form["slv_tm_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_tm_id"]))
        {
            DataTable dt = db_pro_tyre_mst.Get_pro_tyre_mstLog(Handle.ToInt32(Request.Form["slv_tm_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetDeletedLog
    /// <summary>
    /// use to get all 
    /// </summary>
    public void GetDeletedLog()
    {
        if (Request.Form["dlv_tm_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_tm_user_id"]) )
        {
            DataTable dt = db_pro_tyre_mst.Get_pro_tyre_mstDeletedLog(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #endregion
*/
