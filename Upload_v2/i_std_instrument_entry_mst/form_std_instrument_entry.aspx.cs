using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_std_instrument_entry : COMM_SessionCheck
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
    }protected void btnSave_Click(object sender, EventArgs e)
    {  
        if(Page.IsValid)
        {
            btnSave.Enabled = false;
            //Save data to table
            PROP_std_instrument_entry_mst PropObj = new PROP_std_instrument_entry_mst();
PropObj.siem_dept_id = .GetIdByName(txt_siem_dept_id.Text);
PropObj.siem_instr_name = txt_siem_instr_name.Text;
PropObj.siem_gf_no = txt_siem_gf_no.Text;
PropObj.siem_instr_make = txt_siem_instr_make.Text;
PropObj.siem_model_no = txt_siem_model_no.Text;
PropObj.siem_instr_sr_no = txt_siem_instr_sr_no.Text;
PropObj.siem_instr_pur_date = Handle.ToDateTime(txt_siem_instr_pur_date.Text);
PropObj.siem_avg_lifecycle = txt_siem_avg_lifecycle.Text;
PropObj.siem_calib_req = Handle.ToInt32(ddl_siem_calib_req.SelectedValue);
PropObj.siem_instr_calib_date = Handle.ToDateTime(txt_siem_instr_calib_date.Text);
PropObj.siem_calib_frequency = Handle.ToInt32(ddl_siem_calib_frequency.SelectedValue);
PropObj.siem_next_calib_date = Handle.ToDateTime(txt_siem_next_calib_date.Text);
PropObj.siem_range = txt_siem_range.Text;
PropObj.siem_LC = txt_siem_LC.Text;
PropObj.siem_size = txt_siem_size.Text;
PropObj.siem_class = txt_siem_class.Text;
PropObj.siem_go = txt_siem_go.Text;
PropObj.siem_no_go = txt_siem_no_go.Text; PropObj.status= 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;
                
                PROP_db_return ret = db_std_instrument_entry_mst.Update(PropObj);
                if (ret.id>0)
                {
                    Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage; 
                    Response.Redirect("list_std_instrument_entry.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=db_std_instrument_entry_mst.Insert(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_std_instrument_entry.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }

         btnSave.Enabled = true;
      }
       
    }
     public void edit(int id)
    {
        DataTable dt = db_std_instrument_entry_mst.Get_std_instrument_entry_mst_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {
           
txt_siem_dept_id.Text = dt.Rows[0]["siem_dept_id"].ToString(); 
txt_siem_instr_name.Text = dt.Rows[0]["siem_instr_name"].ToString(); 
txt_siem_gf_no.Text = dt.Rows[0]["siem_gf_no"].ToString(); 
txt_siem_instr_make.Text = dt.Rows[0]["siem_instr_make"].ToString(); 
txt_siem_model_no.Text = dt.Rows[0]["siem_model_no"].ToString(); 
txt_siem_instr_sr_no.Text = dt.Rows[0]["siem_instr_sr_no"].ToString(); 
txt_siem_instr_pur_date.Text = dt.Rows[0]["siem_instr_pur_date"].ToString(); 
txt_siem_avg_lifecycle.Text = dt.Rows[0]["siem_avg_lifecycle"].ToString(); 
ddl_siem_calib_req.SelectedValue = dt.Rows[0]["siem_calib_req"].ToString(); 
txt_siem_instr_calib_date.Text = dt.Rows[0]["siem_instr_calib_date"].ToString(); 
ddl_siem_calib_frequency.SelectedValue = dt.Rows[0]["siem_calib_frequency"].ToString(); 
txt_siem_next_calib_date.Text = dt.Rows[0]["siem_next_calib_date"].ToString(); 
txt_siem_range.Text = dt.Rows[0]["siem_range"].ToString(); 
txt_siem_LC.Text = dt.Rows[0]["siem_LC"].ToString(); 
txt_siem_size.Text = dt.Rows[0]["siem_size"].ToString(); 
txt_siem_class.Text = dt.Rows[0]["siem_class"].ToString(); 
txt_siem_go.Text = dt.Rows[0]["siem_go"].ToString(); 
txt_siem_no_go.Text = dt.Rows[0]["siem_no_go"].ToString(); 
        }
    }
    
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
