using AjaxControlToolkit;
using infinity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class form_task_log : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PROP_iERP_task_log PropObj = new PROP_iERP_task_log();
        PropObj.task_id = Handle.ToInt32(txt_task_id.Text);
        PropObj.task_log = txt_task_log.Text;
        PropObj.task_comp = txt_task_comp.Text; PropObj.status = 1;
        PropObj.comp_id = Handle.ToInt32(Session["comp_id"]);
        PropObj.create_by = Handle.ToInt32(Session["user_id"]);
        PropObj.create_ip = Request.UserHostAddress;

        DataTable id = db_iERP_task_log.GetIdByName(Handle.ToInt32(txt_task_id.Text));
        if (id.Rows.Count > 0)
        {
            PropObj.id = Handle.ToInt32(id.Rows[0]["id"].ToString());
            PropObj.modify_by = Handle.ToInt32(Session["user_id"]);
            PropObj.modify_ip = Request.UserHostAddress;

            DataTable ret = db_iERP_task_log.Update(PropObj);
        }
        else
        {
            DataTable ret = db_iERP_task_log.Insert(PropObj);
        }
        txt_task_id_TextChanged(txt_task_id, EventArgs.Empty);
    }

    protected void txt_task_id_TextChanged(object sender, EventArgs e)
    {
        if (txt_task_id.Text.Contains('%'))
        {

        }
        else
        {
            DataTable id = db_iERP_task_log.GetIdByName(Handle.ToInt32(txt_task_id.Text));
            if (id.Rows.Count > 0)
            {
                DataTable dt = db_iERP_task_log.Get_iERP_task_log_ByID(Handle.ToInt32(id.Rows[0]["id"].ToString()), 1);
                if (dt.Rows.Count > 0)
                {
                    txt_task_log.Text = dt.Rows[0]["task_log"].ToString();
                    txt_task_comp.Text = dt.Rows[0]["task_comp"].ToString();
                }
                Utility.SetFocusOnLoad(txt_task_log);
            }
            else
            {
                txt_task_comp.Text = "";
                txt_task_log.Text = "";
                Utility.SetFocusOnLoad(txt_task_comp);
            }
        }
        
    }
}