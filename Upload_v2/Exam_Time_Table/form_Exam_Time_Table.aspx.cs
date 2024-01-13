using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_Exam_Time_Table : COMM_SessionCheck
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Edit data    
                edit(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            btn_save.Enabled = false;
            //Save data to table
            PROP_Exam_Time_Table PropObj = new PROP_Exam_Time_Table();
            PropObj.ett_Id = txt_ett_Id.Text;
            PropObj.ett_Institute_Id = txt_ett_Institute_Id.Text;
            PropObj.ett_Faculty_Id = Handle.ToDouble(txt_ett_Faculty_Id.Text);
            PropObj.ett_Program_Id = Handle.ToDateTime(txt_ett_Program_Id.Text);
            PropObj.ett_Semester_Id = .GetIdByName(txt_ett_Semester_Id.Text);
            PropObj.ett_Exam_Id = Handle.ToInt32(ddl_ett_Exam_Id.SelectedValue);
            PropObj.ett_Gap_Day = (chk_ett_Gap_Day.Checked == true ? 1 : 0);
            PropObj.ett_Seq_No = Handle.ToInt32(rdo_ett_Seq_No.SelectedValue);
            PropObj.ett_Component_Id = txt_ett_Component_Id.Text;
            PropObj.ett_Session_Id = txt_ett_Session_Id.Text;
            PropObj.ett_Exam_Date = Handle.ToDouble(txt_ett_Exam_Date.Text);
            PropObj.ett_Exam_Start_Time = Handle.ToDateTime(txt_ett_Exam_Start_Time.Text);
            PropObj.ett_Exam_End_Time = .GetIdByName(txt_ett_Exam_End_Time.Text);
            PropObj.ett_Sub_Type_Id = Handle.ToInt32(ddl_ett_Sub_Type_Id.SelectedValue);
            PropObj.ett_Is_Status = (chk_ett_Is_Status.Checked == true ? 1 : 0);
            PropObj.ett_Is_Delete = Handle.ToInt32(rdo_ett_Is_Delete.SelectedValue);
            PropObj.ett_Created_By = txt_ett_Created_By.Text;
            PropObj.ett_Created_Date = txt_ett_Created_Date.Text;
            PropObj.ett_Created_Ip = Handle.ToDouble(txt_ett_Created_Ip.Text);
            PropObj.ett_Modify_By = Handle.ToDateTime(txt_ett_Modify_By.Text);
            PropObj.ett_Modify_Date = .GetIdByName(txt_ett_Modify_Date.Text);
            PropObj.ett_Modify_Ip = Handle.ToInt32(ddl_ett_Modify_Ip.SelectedValue);
            PropObj.ett_Deleted_By = (chk_ett_Deleted_By.Checked == true ? 1 : 0);
            PropObj.ett_Deleted_Date = Handle.ToInt32(rdo_ett_Deleted_Date.SelectedValue);
            PropObj.ett_Deleted_Ip = txt_ett_Deleted_Ip.Text;
            //Request.UserHostAddress;

            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PROP_db_return ret = BAL_Exam_Time_Table.Insert_Exam_Time_Table(PropObj);
                if (ret.id > 0)
                {
                    Session["alertmessage"] = Handle.ToString(ret.alertMessage);
                    Response.Redirect("list_Exam_Time_Table.aspx");
                }
                else
                {
                    lbl_alert_msg.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret = BAL_Exam_Time_Table.Insert_Exam_Time_Table(PropObj);
                if (ret.id > 0)
                {
                    Session["alertmessage"] = Handle.ToString(ret.alertMessage);
                    Response.Redirect("list_Exam_Time_Table.aspx");
                }
                else
                {
                    lbl_alert_msg.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }

            btn_save.Enabled = true;
        }

    }
    public void edit(int id)
    {
        DataTable dt = BAL_Exam_Time_Table.GetBAL_Exam_Time_Table_ByID(id, Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {

            txt_ett_Id.Text = dt.Rows[0]["ett_Id"].ToString();
            txt_ett_Id.Enabled = false;
            txt_ett_Institute_Id.Text = dt.Rows[0]["ett_Institute_Id"].ToString();
            txt_ett_Faculty_Id.Text = dt.Rows[0]["ett_Faculty_Id"].ToString();
            txt_ett_Program_Id.Text = dt.Rows[0]["ett_Program_Id"].ToString();
            txt_ett_Semester_Id.Text = dt.Rows[0]["ett_Semester_Id"].ToString();
            ddl_ett_Exam_Id.SelectedValue = dt.Rows[0]["ett_Exam_Id"].ToString();
            chk_ett_Gap_Day.Checked = dt.Rows[0]["ett_Gap_Day"].ToString();
            rdo_ett_Seq_No.SelectedValue = dt.Rows[0]["ett_Seq_No"].ToString();
            txt_ett_Component_Id.Text = dt.Rows[0]["ett_Component_Id"].ToString();
            txt_ett_Session_Id.Text = dt.Rows[0]["ett_Session_Id"].ToString();
            txt_ett_Exam_Date.Text = dt.Rows[0]["ett_Exam_Date"].ToString();
            txt_ett_Exam_Start_Time.Text = dt.Rows[0]["ett_Exam_Start_Time"].ToString();
            txt_ett_Exam_End_Time.Text = dt.Rows[0]["ett_Exam_End_Time"].ToString();
            ddl_ett_Sub_Type_Id.SelectedValue = dt.Rows[0]["ett_Sub_Type_Id"].ToString();
            chk_ett_Is_Status.Checked = dt.Rows[0]["ett_Is_Status"].ToString();
            rdo_ett_Is_Delete.SelectedValue = dt.Rows[0]["ett_Is_Delete"].ToString();
            rdo_ett_Is_Delete.Enabled = false;
            txt_ett_Created_By.Text = dt.Rows[0]["ett_Created_By"].ToString();
            txt_ett_Created_Date.Text = dt.Rows[0]["ett_Created_Date"].ToString();
            txt_ett_Created_Ip.Text = dt.Rows[0]["ett_Created_Ip"].ToString();
            txt_ett_Modify_By.Text = dt.Rows[0]["ett_Modify_By"].ToString();
            txt_ett_Modify_By.Enabled = false;
            txt_ett_Modify_Date.Text = dt.Rows[0]["ett_Modify_Date"].ToString();
            txt_ett_Modify_Date.Enabled = false;
            ddl_ett_Modify_Ip.SelectedValue = dt.Rows[0]["ett_Modify_Ip"].ToString();
            ddl_ett_Modify_Ip.Enabled = false;
            chk_ett_Deleted_By.Checked = dt.Rows[0]["ett_Deleted_By"].ToString();
            rdo_ett_Deleted_Date.SelectedValue = dt.Rows[0]["ett_Deleted_Date"].ToString();
            txt_ett_Deleted_Ip.Text = dt.Rows[0]["ett_Deleted_Ip"].ToString();
        }
    }

}


/*

#region Put below functions to appropriate  file 
#endregion
*/
