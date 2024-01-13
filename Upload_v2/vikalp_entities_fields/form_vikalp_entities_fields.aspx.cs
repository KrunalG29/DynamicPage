using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_vikalp_entities_fields : COMM_SessionCheck
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
            PROP_vikalp_entities_fields PropObj = new PROP_vikalp_entities_fields();
PropObj.entities_id = ;
PropObj.forms_tabs_id = ;
PropObj.comments_forms_tabs_id = ;
PropObj.forms_rows_position = ;
PropObj.type = ;
PropObj.name = ;
PropObj.short_name = ;
PropObj.is_heading = ;
PropObj.tooltip = ;
PropObj.tooltip_display_as = ;
PropObj.tooltip_in_item_page = ;
PropObj.tooltip_item_page = ;
PropObj.notes = ;
PropObj.is_required = ;
PropObj.required_message = ;
PropObj.configuration = ;
PropObj.sort_order = ;
PropObj.listing_status = ;
PropObj.listing_sort_order = ;
PropObj.comments_status = ;
PropObj.comments_sort_order = ;
PropObj.is_reserved_fields = ; PropObj.status= 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;
                
                PROP_db_return ret = db_vikalp_entities_fields.Update(PropObj);
                if (ret.id>0)
                {
                    Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage; 
                    Response.Redirect("list_vikalp_entities_fields.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=db_vikalp_entities_fields.Insert(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_vikalp_entities_fields.aspx");
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
        DataTable dt = db_vikalp_entities_fields.Get_vikalp_entities_fields_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {
           
 = dt.Rows[0]["entities_id"].ToString(); 
 = dt.Rows[0]["forms_tabs_id"].ToString(); 
 = dt.Rows[0]["comments_forms_tabs_id"].ToString(); 
 = dt.Rows[0]["forms_rows_position"].ToString(); 
 = dt.Rows[0]["type"].ToString(); 
 = dt.Rows[0]["name"].ToString(); 
 = dt.Rows[0]["short_name"].ToString(); 
 = dt.Rows[0]["is_heading"].ToString(); 
 = dt.Rows[0]["tooltip"].ToString(); 
 = dt.Rows[0]["tooltip_display_as"].ToString(); 
 = dt.Rows[0]["tooltip_in_item_page"].ToString(); 
 = dt.Rows[0]["tooltip_item_page"].ToString(); 
 = dt.Rows[0]["notes"].ToString(); 
 = dt.Rows[0]["is_required"].ToString(); 
 = dt.Rows[0]["required_message"].ToString(); 
 = dt.Rows[0]["configuration"].ToString(); 
 = dt.Rows[0]["sort_order"].ToString(); 
 = dt.Rows[0]["listing_status"].ToString(); 
 = dt.Rows[0]["listing_sort_order"].ToString(); 
 = dt.Rows[0]["comments_status"].ToString(); 
 = dt.Rows[0]["comments_sort_order"].ToString(); 
 = dt.Rows[0]["is_reserved_fields"].ToString(); 
        }
    }
    
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
