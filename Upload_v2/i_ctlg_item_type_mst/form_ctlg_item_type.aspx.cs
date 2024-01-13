using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class form_ctlg_item_type : COMM_SessionCheck
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
            btn_save.Enabled = false;
            //Save data to table
            PROP_ctlg_item_type_mst PropObj = new PROP_ctlg_item_type_mst();
PropObj.itm_parent_type = txt_itm_parent_type.Text;
PropObj.itm_name = txt_itm_name.Text;
PropObj.itm_code = Handle.ToDouble(txt_itm_code.Text);
PropObj.itm_is_system = Handle.ToDateTime(txt_itm_is_system.Text);
PropObj.itm_key = .GetIdByName(txt_itm_key.Text); 
            //Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PROP_db_return ret = BAL_ctlg_item_type_mst.Insert_i_ctlg_item_type_mst(PropObj);
                if (ret.id>0)
                {
                    Session["alertmessage"] = Handle.ToString(ret.alertMessage);
                    Response.Redirect("list_ctlg_item_type.aspx");
                }
                else
                {
                    lbl_alert_msg.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=BAL_ctlg_item_type_mst.Insert_i_ctlg_item_type_mst(PropObj);
                if (ret.id > 0)
                {
                    Session["alertmessage"] = Handle.ToString(ret.alertMessage);
                    Response.Redirect("list_ctlg_item_type.aspx");
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
        DataTable dt = BAL_ctlg_item_type_mst.GetBAL_ctlg_item_type_mst_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        {
           
txt_itm_parent_type.Text = dt.Rows[0]["itm_parent_type"].ToString(); 
txt_itm_parent_type.Enabled=false;
txt_itm_name.Text = dt.Rows[0]["itm_name"].ToString(); 
txt_itm_code.Text = dt.Rows[0]["itm_code"].ToString(); 
txt_itm_is_system.Text = dt.Rows[0]["itm_is_system"].ToString(); 
txt_itm_key.Text = dt.Rows[0]["itm_key"].ToString(); 
        }
    }
    
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
