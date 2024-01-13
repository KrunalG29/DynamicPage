using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_purc_weigh_bridge_in : COMM_SessionCheck
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
            PROP_purc_weigh_bridge_in_mst PropObj = new PROP_purc_weigh_bridge_in_mst();
PropObj.wbi_date = ;
PropObj.wbi_no = ;
PropObj.wbi_ven_id = ;
PropObj.wbi_tra_id = ;
PropObj.wbi_ref_id = ;
PropObj.wbi_ref_type = ;
PropObj.wbi_ref_challan_no = ;
PropObj.wbi_itm_id = ;
PropObj.wbi_vehicle_no = ;
PropObj.wbi_gross_qty = ;
PropObj.wbi_tare_qty = ;
PropObj.wbi_net_qty = ;
PropObj.wbi_weigh_bridge_id = ;
PropObj.wbi_truck_weight = ;
PropObj.wbi_driver_name = ;
PropObj.wbi_driver_contact_no = ;
PropObj.wbi_current_status = ; PropObj.status= 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;
                
                PROP_db_return ret = db_purc_weigh_bridge_in_mst.Update(PropObj);
                if (ret.id>0)
                {
                    Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage; 
                    Response.Redirect("list_purc_weigh_bridge_in.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=db_purc_weigh_bridge_in_mst.Insert(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_purc_weigh_bridge_in.aspx");
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
        DataTable dt = db_purc_weigh_bridge_in_mst.Get_purc_weigh_bridge_in_mst_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {
           
 = dt.Rows[0]["wbi_date"].ToString(); 
 = dt.Rows[0]["wbi_no"].ToString(); 
 = dt.Rows[0]["wbi_ven_id"].ToString(); 
 = dt.Rows[0]["wbi_tra_id"].ToString(); 
 = dt.Rows[0]["wbi_ref_id"].ToString(); 
 = dt.Rows[0]["wbi_ref_type"].ToString(); 
 = dt.Rows[0]["wbi_ref_challan_no"].ToString(); 
 = dt.Rows[0]["wbi_itm_id"].ToString(); 
 = dt.Rows[0]["wbi_vehicle_no"].ToString(); 
 = dt.Rows[0]["wbi_gross_qty"].ToString(); 
 = dt.Rows[0]["wbi_tare_qty"].ToString(); 
 = dt.Rows[0]["wbi_net_qty"].ToString(); 
 = dt.Rows[0]["wbi_weigh_bridge_id"].ToString(); 
 = dt.Rows[0]["wbi_truck_weight"].ToString(); 
 = dt.Rows[0]["wbi_driver_name"].ToString(); 
 = dt.Rows[0]["wbi_driver_contact_no"].ToString(); 
 = dt.Rows[0]["wbi_current_status"].ToString(); 
        }
    }
    
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
