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

public partial class list_entt_vendor : COMM_SessionCheck
{
    #region MASTER PAGE
    public void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["MasterPage"] != null)
        {
            this.MasterPageFile = Handle.ToString(Session["MasterPage"]);
        }
    }
    #endregion MASTER PAGE

    #region Global Declaration
    public int insert_flag = 0;
    public int edit_flag = 0;
    public int delete_flag = 0;
    public int export_flag = 0;
    public int viewLog_flag = 0;
    public int deletedViewLog_flag = 0;
    public int copy_flag = 0;
    public int status_flag = 0;
    public int view_flag = 0;
    #endregion
    
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["alertmessage"] != null && !string.IsNullOrEmpty(Handle.ToString(Session["alertmessage"])))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "messageSuccess('" + Session["alertmessage"] + "');hide(); ", true);
                Session["alertmessage"] = null;
            }
            GetRightsData();
        }
    }
    #endregion

    #region GetRightsData
    public void GetRightsData()
    {
        DataTable dtPermission = db_Menu.GetAllPermissions(DAL_Utilities.getpagenamefolder(), Handle.ToInt32(Session["user_id"]));
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
                DataRow[] drStatus = dtPermission.Select("uwp_per_id=4");
                status_flag = (drStatus.Length > 0 ? 1 : 0);
                DataRow[] drView = dtPermission.Select("uwp_per_id=5");
                view_flag = (drView.Length > 0 ? 1 : 0);
                DataRow[] drExport = dtPermission.Select("uwp_per_id=6");
                export_flag = (drExport.Length > 0 ? 1 : 0);
                DataRow[] drViewLog = dtPermission.Select("uwp_per_id=7");
                viewLog_flag = (drViewLog.Length > 0 ? 1 : 0);
                DataRow[] drDeletedLogView = dtPermission.Select("uwp_per_id=8");
                deletedViewLog_flag = (drDeletedLogView.Length > 0 ? 1 : 0);
            }
        }
    }
    #endregion

    #region Encrypt_Decrypt
    [System.Web.Services.WebMethod]
    public static string Edit_Item_Type(int itm_id)
    {
        string JSONString = string.Empty;
        string Decrypt = Incrypt_Decrypt.Encrypt_Decrypt.Encrypt(Handle.ToString(itm_id));
        string url = Handle.ToString("from_entt_vendor.aspx?id=" + Decrypt + "");
        JSONString = url;
        return JSONString;
    }

    [System.Web.Services.WebMethod]
    public static string View_data_view(int itm_id)
    {
        string JSONString = string.Empty;
        string Decrypt = Incrypt_Decrypt.Encrypt_Decrypt.Encrypt(Handle.ToString(itm_id));
        string url = Handle.ToString("from_entt_vendor.aspx?vid=" + Decrypt + ");
        JSONString = url;
        return JSONString;
    }
    #endregion
}

/*

 case "vendor":
                Managevendor();
                break;

#region vendor

    public void Managevendor()
    {
        if (Request.Form["del_ven_id"] != null && !string.IsNullOrEmpty(Request.Form["del_ven_id"]))
        {
            Deletevendor(Handle.ToInt32(Request.Form["del_ven_id"].ToString()));
        }
        else if (Request.Form["gven_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gven_user_id"] ))
        {
            Getvendor();
        }
        else if (Request.Form["dlv_ven_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ven_user_id"]))
        {
            GetvendorDeletedLog();
        }
        else if (Request.Form["slv_ven_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ven_id"] ))
        {
            GetvendorLog();
        }
    }

    #region Deletevendor
    /// <summary>
    /// use to delete vendor by passing vendor id
    /// </summary>    
    public void Deletevendor(int ven_id)
    {
        if (BAL_entt_vendor_mst.Delete(ven_id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress,Handle.ToInt32(Session["comp_id"])))
            Response.Write("1");
        else
            Response.Write("0");
    }
    #endregion

    #region Getvendor
    /// <summary>
    /// use to get all vendor
    /// </summary>
    public void Getvendor()
    {
        if (Request.Form["gven_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gven_user_id"]))
        {
            DataTable dt = BAL_entt_vendor_mst.GetBAL_entt_vendor_mst_select(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetvendorLog
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void GetvendorLog()
    {
        if (Request.Form["slv_ven_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ven_id"]))
        {
            DataTable dt = BAL_entt_vendor_mst.GetBAL_entt_vendor_mstLog(Handle.ToInt32(Request.Form["slv_ven_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region GetvendorDeletedLog
    /// <summary>
    /// use to get all vendor
    /// </summary>
    public void GetvendorDeletedLog()
    {
        if (Request.Form["dlv_ven_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ven_user_id"]) )
        {
            DataTable dt = BAL_entt_vendor_mst.GetBAL_entt_vendor_mstDeletedLog(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #endregion
*/
