using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_hrhr_employee_loan_application_entry : COMM_SessionCheck
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {    
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Edit data    
                editManage_emp_loan_application_entry(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
    }protected void btnSave_Click(object sender, EventArgs e)
    {  
        if(Page.IsValid)
        {
            btnSave.Enabled = false;
            //Save data to table
            PROP_hrhr_employee_loan_application_entry_mst PropObj = new PROP_hrhr_employee_loan_application_entry_mst();
PropObj.ela_loan_req_date = Handle.ToDateTime(txt_ela_loan_req_date.Text);
PropObj.ela_date_of_confirm = Handle.ToDateTime(txt_ela_date_of_confirm.Text);
PropObj.ela_emp_id = .GetIdByName(txt_ela_emp_id.Text);
PropObj.ela_eligibilty_of_emp = Handle.ToDouble(txt_ela_eligibilty_of_emp.Text);
PropObj.ela_applied_loan_amt = Handle.ToDouble(txt_ela_applied_loan_amt.Text);
PropObj.ela_no_of_installment = Handle.ToDouble(txt_ela_no_of_installment.Text);
PropObj.ela_installment_amt = Handle.ToDouble(txt_ela_installment_amt.Text);
PropObj.ela_reason = txt_ela_reason.Text;
PropObj.ela_last_loan_date = Handle.ToDateTime(txt_ela_last_loan_date.Text);
PropObj.ela_last_loan_amt = Handle.ToDouble(txt_ela_last_loan_amt.Text);
PropObj.ela_loan_period = Handle.ToDouble(txt_ela_loan_period.Text);
PropObj.ela_last_loan_pend_amt = Handle.ToDouble(txt_ela_last_loan_pend_amt.Text);
PropObj.ela_from_date = Handle.ToDateTime(txt_ela_from_date.Text);
PropObj.ela_to_date = Handle.ToDateTime(txt_ela_to_date.Text);
PropObj.ela_total_days = Handle.ToDouble(txt_ela_total_days.Text);
PropObj.ela_working_days = Handle.ToDouble(txt_ela_working_days.Text);
PropObj.ela_absent_days_with_leave = Handle.ToDouble(txt_ela_absent_days_with_leave.Text);
PropObj.ela_absent_days_without_leave = Handle.ToDouble(txt_ela_absent_days_without_leave.Text);
PropObj.ela_sick_leave = Handle.ToDouble(txt_ela_sick_leave.Text);
PropObj.ela_accident_esi_leave = Handle.ToDouble(txt_ela_accident_esi_leave.Text);
PropObj.ela_present_days = Handle.ToDouble(txt_ela_present_days.Text);
PropObj.ela_tot_absent = Handle.ToDouble(txt_ela_tot_absent.Text); PropObj.status= 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;
                
                PROP_db_return ret = db_hrhr_employee_loan_application_entry_mst.Update(PropObj);
                if (ret.id>0)
                {
                    Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage; 
                    Response.Redirect("list_hrhr_employee_loan_application_entry.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=db_hrhr_employee_loan_application_entry_mst.Insert(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_hrhr_employee_loan_application_entry.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }

         btnSave.Enabled = true;
      }
       
    }
     public void editManage_emp_loan_application_entry(int id)
    {
        DataTable dt = db_hrhr_employee_loan_application_entry_mst.Get_hrhr_employee_loan_application_entry_mst_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {
           
txt_ela_loan_req_date.Text = dt.Rows[0]["ela_loan_req_date"].ToString(); 
txt_ela_date_of_confirm.Text = dt.Rows[0]["ela_date_of_confirm"].ToString(); 
txt_ela_emp_id.Text = dt.Rows[0]["ela_emp_id"].ToString(); 
txt_ela_eligibilty_of_emp.Text = dt.Rows[0]["ela_eligibilty_of_emp"].ToString(); 
txt_ela_applied_loan_amt.Text = dt.Rows[0]["ela_applied_loan_amt"].ToString(); 
txt_ela_no_of_installment.Text = dt.Rows[0]["ela_no_of_installment"].ToString(); 
txt_ela_installment_amt.Text = dt.Rows[0]["ela_installment_amt"].ToString(); 
txt_ela_reason.Text = dt.Rows[0]["ela_reason"].ToString(); 
txt_ela_last_loan_date.Text = dt.Rows[0]["ela_last_loan_date"].ToString(); 
txt_ela_last_loan_amt.Text = dt.Rows[0]["ela_last_loan_amt"].ToString(); 
txt_ela_loan_period.Text = dt.Rows[0]["ela_loan_period"].ToString(); 
txt_ela_last_loan_pend_amt.Text = dt.Rows[0]["ela_last_loan_pend_amt"].ToString(); 
txt_ela_from_date.Text = dt.Rows[0]["ela_from_date"].ToString(); 
txt_ela_to_date.Text = dt.Rows[0]["ela_to_date"].ToString(); 
txt_ela_total_days.Text = dt.Rows[0]["ela_total_days"].ToString(); 
txt_ela_working_days.Text = dt.Rows[0]["ela_working_days"].ToString(); 
txt_ela_absent_days_with_leave.Text = dt.Rows[0]["ela_absent_days_with_leave"].ToString(); 
txt_ela_absent_days_without_leave.Text = dt.Rows[0]["ela_absent_days_without_leave"].ToString(); 
txt_ela_sick_leave.Text = dt.Rows[0]["ela_sick_leave"].ToString(); 
txt_ela_accident_esi_leave.Text = dt.Rows[0]["ela_accident_esi_leave"].ToString(); 
txt_ela_present_days.Text = dt.Rows[0]["ela_present_days"].ToString(); 
txt_ela_tot_absent.Text = dt.Rows[0]["ela_tot_absent"].ToString(); 
        }
    }
    
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
