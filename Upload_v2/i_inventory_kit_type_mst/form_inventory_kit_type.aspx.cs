using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_inventory_kit_type : COMM_SessionCheck
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Edit data    
                editManage_Kit_Type_Master(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            btnSave.Enabled = false;
            //Save data to table
            PROP_inventory_kit_type_mst PropObj = new PROP_inventory_kit_type_mst();
            PropObj.ktm_kit_type_name = txt_ktm_kit_type_name.Text; PropObj.status = 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;

            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;

                PROP_db_return ret = db_inventory_kit_type_mst.Update(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_inventory_kit_type.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret = db_inventory_kit_type_mst.Insert(PropObj);
                if (ret.id > 0)
                {
                    Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_inventory_kit_type.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }

            btnSave.Enabled = true;
        }

    }
    public void editManage_Kit_Type_Master(int id)
    {
        DataTable dt = db_inventory_kit_type_mst.Get_inventory_kit_type_mst_ByID(id, Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {

            txt_ktm_kit_type_name.Text = dt.Rows[0]["ktm_kit_type_name"].ToString();
        }
    }

}


/*

#region Put below functions to appropriate  file 
#endregion
*/
