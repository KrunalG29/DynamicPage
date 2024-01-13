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

public partial class list_pro_employee_wise_vehicle_assign_mst : COMM_SessionCheck
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

 case "employee_wise_vehicle_assign_mst":
                Manageemployee_wise_vehicle_assign_mst();
                break;

#region employee_wise_vehicle_assign_mst

    public void Manageemployee_wise_vehicle_assign_mst()
    {
        if (Request.Form["del_ewvam_id"] != null && !string.IsNullOrEmpty(Request.Form["del_ewvam_id"]))
        {
            Deleteemployee_wise_vehicle_assign_mst(Handle.ToInt32(Request.Form["del_ewvam_id"].ToString()));
        }
        else if (Request.Form["gewvam_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gewvam_user_id"] ))
        {
            Getemployee_wise_vehicle_assign_mst();
        }
        else if (Request.Form["dlv_ewvam_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ewvam_user_id"]))
        {
            Getemployee_wise_vehicle_assign_mstDeletedLog();
        }
        else if (Request.Form["slv_ewvam_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ewvam_id"] ))
        {
            Getemployee_wise_vehicle_assign_mstLog();
        }
    }

    #region Deleteemployee_wise_vehicle_assign_mst
    /// <summary>
    /// use to delete employee_wise_vehicle_assign_mst by passing employee_wise_vehicle_assign_mst id
    /// </summary>    
    public void Deleteemployee_wise_vehicle_assign_mst(int ewvam_id)
    {
        if (db_pro_employee_wise_vehicle_assign_mst.Delete(ewvam_id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress,Handle.ToInt32(Session["comp_id"])))
            Response.Write("1");
        else
            Response.Write("0");
    }
    #endregion

    #region Getemployee_wise_vehicle_assign_mst
    /// <summary>
    /// use to get all employee_wise_vehicle_assign_mst
    /// </summary>
    public void Getemployee_wise_vehicle_assign_mst()
    {
        if (Request.Form["gewvam_user_id"] != null && !string.IsNullOrEmpty(Request.Form["gewvam_user_id"]))
        {
            DataTable dt = db_pro_employee_wise_vehicle_assign_mst.Get_pro_employee_wise_vehicle_assign_mst_select(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region Getemployee_wise_vehicle_assign_mstLog
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void Getemployee_wise_vehicle_assign_mstLog()
    {
        if (Request.Form["slv_ewvam_id"] != null && !string.IsNullOrEmpty(Request.Form["slv_ewvam_id"]))
        {
            DataTable dt = db_pro_employee_wise_vehicle_assign_mst.Get_pro_employee_wise_vehicle_assign_mstLog(Handle.ToInt32(Request.Form["slv_ewvam_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #region Getemployee_wise_vehicle_assign_mstDeletedLog
    /// <summary>
    /// use to get all employee_wise_vehicle_assign_mst
    /// </summary>
    public void Getemployee_wise_vehicle_assign_mstDeletedLog()
    {
        if (Request.Form["dlv_ewvam_user_id"] != null && !string.IsNullOrEmpty(Request.Form["dlv_ewvam_user_id"]) )
        {
            DataTable dt = db_pro_employee_wise_vehicle_assign_mst.Get_pro_employee_wise_vehicle_assign_mstDeletedLog(Handle.ToInt32(Session["user_id"]),Handle.ToInt32(Session["comp_id"]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }
    }
    #endregion

    #endregion
*/
