using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
public partial class form_acct_driver_full_and_final_settlement : COMM_SessionCheck
{   
        #region Global Declaration
        DataTable rptdt = new DataTable();
        #endregion
            
#region Page_Load
protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {                    ManageRepeater();
                SaveRepeaterdata_DataTable();
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Edit data    
                edit(Convert.ToInt32(Request.QueryString["id"]));
            }
        }
    }
#endregion

#region btnSave_Click
protected void btnSave_Click(object sender, EventArgs e)
    {  
        if(Page.IsValid)
        {
            btnSave.Enabled = false;
            //Save data to table
            PROP_acct_driver_full_and_final_settlement_mst PropObj = new PROP_acct_driver_full_and_final_settlement_mst();
PropObj.dfs_date = Handle.ToDateTime(txt_dfs_date.Text);
PropObj.dfs_driver_full_name = txt_dfs_driver_full_name.Text;
PropObj.dfs_driver_id = Handle.ToDouble(txt_dfs_driver_id.Text); PropObj.status= 1;
            PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
            PropObj.create_by = Handle.ToInt32(Session["user_id"]);
            PropObj.create_ip = Request.UserHostAddress;
            
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PropObj.id = Handle.ToInt32(Request.QueryString["id"].ToString());
                PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
                PropObj.modify_ip = Request.UserHostAddress;
                
                PROP_db_return ret = db_acct_driver_full_and_final_settlement_mst.Update(PropObj);
                if (ret.id>0)
                {              insertItemDetail(ret.id);          
            Session["AlertTitle"] = "Record Updated";
                    Session["AlertMsg"] = ret.alertMessage; 
                    Response.Redirect("list_acct_driver_full_and_final_settlement.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }
            else
            {
                PROP_db_return ret=db_acct_driver_full_and_final_settlement_mst.Insert(PropObj);
                if (ret.id > 0)
                {              insertItemDetail(ret.id);             
            Session["AlertTitle"] = "Record Inserted";
                    Session["AlertMsg"] = ret.alertMessage;
                    Response.Redirect("list_acct_driver_full_and_final_settlement.aspx");
                }
                else
                {
                    lblMessage.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }
            }

         btnSave.Enabled = true;
      }
       
    }
#endregion
         
           #region insertItemDetail
                   public void insertItemDetail(int id)
                   {
                       db_acct_driver_full_and_final_settlement_detail.Delete(id, Handle.ToInt32(Session["user_id"]), Request.UserHostAddress, Handle.ToInt32(Session["comp_id"]));
                       foreach (RepeaterItem itm in rept_item.Items)
                       {
                           PROP_acct_driver_full_and_final_settlement_detail PropObjDetail = new PROP_acct_driver_full_and_final_settlement_detail(); 
PropObjDetail.dfsd_dfs_id = ((HiddenField)itm.FindControl("hid_dfsd_dfs_id")).Value;
PropObjDetail.dfsd_ledger_type = ((HiddenField)itm.FindControl("hid_dfsd_ledger_type")).Value;
PropObjDetail.dfsd_ledger_name = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_ledger_name")).Text);
PropObjDetail.dfsd_driver_account_id = ((HiddenField)itm.FindControl("hid_dfsd_driver_account_id")).Value;
PropObjDetail.dfsd_driver_account_name = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_driver_account_name")).Text);
PropObjDetail.dfsd_driver_account_type = ((HiddenField)itm.FindControl("hid_dfsd_driver_account_type")).Value;
PropObjDetail.dfsd_opposiote_account_id = ((HiddenField)itm.FindControl("hid_dfsd_opposiote_account_id")).Value;
PropObjDetail.dfsd_opposiote_account_name = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_opposiote_account_name")).Text);
PropObjDetail.dfsd_opposiote_account_type = ((HiddenField)itm.FindControl("hid_dfsd_opposiote_account_type")).Value;
PropObjDetail.dfsd_amount = Handle.ToDouble(((TextBox)itm.FindControl("txt_dfsd_amount")).Text);
PropObjDetail.dfsd_jv_mst_id = ((HiddenField)itm.FindControl("hid_dfsd_jv_mst_id")).Value;
PropObjDetail.dfsd_jv_detail_id = ((HiddenField)itm.FindControl("hid_dfsd_jv_detail_id")).Value;                PropObjDetail.status = 1;
                            PropObjDetail.comp_id = Handle.ToInt32(Session["comp_id"]);
                            PropObjDetail.create_by = Handle.ToInt32(Session["user_id"]);
                            PropObjDetail.create_ip = Request.UserHostAddress;
                            db_acct_driver_full_and_final_settlement_detail.Insert(PropObjDetail);
                        }
                    }
           #endregion

        #region Reapeater Controls
        public void rpt_New_Row()
        {
            rptdt = ViewState["rptdt"] as DataTable;
            DataRow rd = rptdt.NewRow();
            rd["id"] = rptdt.Rows.Count + 1; 
rd["dfsd_dfs_id"] = "0";
rd["dfsd_ledger_type"] = "0";
rd["dfsd_ledger_name"] = "";
rd["dfsd_driver_account_id"] = "0";
rd["dfsd_driver_account_name"] = "";
rd["dfsd_driver_account_type"] = "0";
rd["dfsd_opposiote_account_id"] = "0";
rd["dfsd_opposiote_account_name"] = "";
rd["dfsd_opposiote_account_type"] = "0";
rd["dfsd_amount"] = "";
rd["dfsd_jv_mst_id"] = "0";
rd["dfsd_jv_detail_id"] = "0";
            rptdt.Rows.Add(rd);
            rptdt.AcceptChanges();
            ViewState["rptdt"] = rptdt;
        }

        public void ManageRepeater()
        {
            if (ViewState["rptdt"] == null)
            {
                rptdt.Columns.Add("id", typeof(int)); 
rptdt.Columns.Add("dfsd_dfs_id", typeof(int));
rptdt.Columns.Add("dfsd_ledger_type", typeof(int));
rptdt.Columns.Add("dfsd_ledger_name", typeof(string));
rptdt.Columns.Add("dfsd_driver_account_id", typeof(int));
rptdt.Columns.Add("dfsd_driver_account_name", typeof(string));
rptdt.Columns.Add("dfsd_driver_account_type", typeof(int));
rptdt.Columns.Add("dfsd_opposiote_account_id", typeof(int));
rptdt.Columns.Add("dfsd_opposiote_account_name", typeof(string));
rptdt.Columns.Add("dfsd_opposiote_account_type", typeof(int));
rptdt.Columns.Add("dfsd_amount", typeof(double));
rptdt.Columns.Add("dfsd_jv_mst_id", typeof(int));
rptdt.Columns.Add("dfsd_jv_detail_id", typeof(int));
                rptdt.AcceptChanges();
                ViewState["rptdt"] = rptdt;
                rpt_New_Row();
                rept_item.DataSource = rptdt;
                rept_item.DataBind();
                RepeaterItem itm = rept_item.Items[0] as RepeaterItem;
                ((ImageButton)itm.FindControl("add_rept_item_btn")).Visible = true;
            }
        }

        public void SaveRepeaterdata_DataTable()
        {
           rptdt = ViewState["rptdt"] as DataTable;
           rptdt.Rows.Clear();
           foreach (RepeaterItem itm in rept_item.Items)
           {
               DataRow rd = rptdt.NewRow();
                rd["id"] = rptdt.Rows.Count + 1; 
rd["dfsd_dfs_id"] = ((HiddenField)itm.FindControl("hid_dfsd_dfs_id")).Value;
rd["dfsd_ledger_type"] = ((HiddenField)itm.FindControl("hid_dfsd_ledger_type")).Value;
rd["dfsd_ledger_name"] = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_ledger_name")).Text);
rd["dfsd_driver_account_id"] = ((HiddenField)itm.FindControl("hid_dfsd_driver_account_id")).Value;
rd["dfsd_driver_account_name"] = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_driver_account_name")).Text);
rd["dfsd_driver_account_type"] = ((HiddenField)itm.FindControl("hid_dfsd_driver_account_type")).Value;
rd["dfsd_opposiote_account_id"] = ((HiddenField)itm.FindControl("hid_dfsd_opposiote_account_id")).Value;
rd["dfsd_opposiote_account_name"] = Handle.ToString(((TextBox)itm.FindControl("txt_dfsd_opposiote_account_name")).Text);
rd["dfsd_opposiote_account_type"] = ((HiddenField)itm.FindControl("hid_dfsd_opposiote_account_type")).Value;
rd["dfsd_amount"] = Handle.ToDouble(((TextBox)itm.FindControl("txt_dfsd_amount")).Text);
rd["dfsd_jv_mst_id"] = ((HiddenField)itm.FindControl("hid_dfsd_jv_mst_id")).Value;
rd["dfsd_jv_detail_id"] = ((HiddenField)itm.FindControl("hid_dfsd_jv_detail_id")).Value;
                rptdt.Rows.Add(rd);
                rptdt.AcceptChanges();
           }
            ViewState["rptdt"] = rptdt;
        }

        protected void rept_item_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem itm = e.Item;
            if (e.CommandName == "Add")
            {
                SaveRepeaterdata_DataTable();
                rpt_New_Row();
                rptdt = ViewState["rptdt"] as DataTable;
                rept_item.DataSource = rptdt;
                rept_item.DataBind();
                ((ImageButton)rept_item.Items[rept_item.Items.Count - 1].FindControl("add_rept_item_btn")).Visible = true;
            }
            if (e.CommandName == "Remove")
            {
                if (rept_item.Items.Count > 1)
                {
                    SaveRepeaterdata_DataTable();
                    rptdt = ViewState["rptdt"] as DataTable;
                    rptdt.Rows.RemoveAt(e.Item.ItemIndex);
                    rptdt.Columns["id"].ReadOnly = false;
                    int count = 1;
                    foreach (DataRow rd in rptdt.Rows)
                    {
                        rptdt.Rows[count - 1]["id"] = count;
                        count++;
                        rptdt.AcceptChanges();
                    }
                    rept_item.DataSource = rptdt;
                    rept_item.DataBind();
                    ((ImageButton)rept_item.Items[rept_item.Items.Count - 1].FindControl("add_rept_item_btn")).Visible = true;
                }
                else
                {
                    ViewState["rptdt"] = null;
                }
            }
        }
        #endregion
 
#region edit
    public void edit(int id)
    {
        DataTable dt = db_acct_driver_full_and_final_settlement_mst.Get_acct_driver_full_and_final_settlement_mst_ByID(id,Handle.ToInt32(Session["comp_id"]));
        if (dt.Rows.Count > 0)
        { 
txt_dfs_date.Text = dt.Rows[0]["dfs_date"].ToString(); 
txt_dfs_driver_full_name.Text = dt.Rows[0]["dfs_driver_full_name"].ToString(); 
txt_dfs_driver_id.Text = dt.Rows[0]["dfs_driver_id"].ToString();  
          DataTable dtitem = db_acct_driver_full_and_final_settlement_detail.Get_form_acct_driver_full_and_final_settlement.aspx.csByID(id, Handle.ToInt32(Session["comp_id"]));
          if (dtitem.Rows.Count > 0)
          {
              rept_item.DataSource = dtitem;
              rept_item.DataBind();
              ((ImageButton)rept_item.Items[rept_item.Items.Count - 1].FindControl("add_rept_item_btn")).Visible = true;
          }
}
    }
  #endregion
}


/*

#region Put below functions to appropriate  file 
#endregion
*/
