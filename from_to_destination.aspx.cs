using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infinity;


public partial class from_to_destination : System.Web.UI.Page
{
    //String Constring = "Data Source=192.168.30.70;Initial Catalog=infiprod_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP";
    String Constring = "Data Source=192.168.30.167;Initial Catalog=CMS_EXAM_NEW;Integrated Security=False; User Id=krunalg; Password=krunalg;Max Pool Size = 1000";
    //String Constring = "Data Source=192.168.30.3;Initial Catalog=CMS_EXAM_NEW;Integrated Security=False; User Id=karank; Password=Welcome_IIPL;Max Pool Size = 1000";
    //String Constring = "Data Source=182.18.181.33,1425;Initial Catalog=gsfc_administrative;User ID=gsfc_administrative;Password=3LN23Ltm0W3@UHs;Application Name=iERP_GSFC";
    public static string conSTr = "workstation id=infiprodERP.mssql.somee.com;packet size=4096;user id=Nishu2904;pwd=nishu#2904;data source=infiprodERP.mssql.somee.com;persist security info=False;initial catalog=infiprodERP";
    public static string txt_constringText = "workstation id=kuldipierp.mssql.somee.com;packet size=4096;user id=KuldipGajjar_SQLLogin_1;pwd=yjh792dcxd;data source=kuldipierp.mssql.somee.com;persist security info=False;initial catalog=kuldipierp";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["new_id"] != null && !string.IsNullOrEmpty(Request.QueryString["new_id"]))
            {
                div_create_new_div.Visible = true;
                div_main_div.Visible = false;
            }
        }
    }

    #region TEST_Click
    protected void TEST_Click(object sender, EventArgs e)
    {
        DataTable dt = db_my_functions.Get_SP_Names(Constring, txt_tbl_name.Text.Trim().ToString());
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        lblMessage.Text = "";
        lbl_ret.Text = "";
        lbl_ret1.Text = "";
        // dada.Text = dt.Rows[1]["name"].ToString();
    }
    #endregion

    #region SUBMIT_Click
    protected void SUBMIT_Click(object sender, EventArgs e)
    {
        String Create_Obj_ids = "";
        String Create_row_ids = "";
        String Alter_Obj_ids = "";
        String Alter_row_ids = "";
        String Exec_Create_String = "";
        String Exec_Alter_String = "";
        String ret_create = "";
        String ret_alter = "";
        Int32 row = 0;
        if (Repeater1.Items.Count > 0)
        {
            foreach (RepeaterItem itm in Repeater1.Items)
            {
                CheckBox chk = itm.FindControl("chl_value") as CheckBox;
                RadioButtonList rdolist = (RadioButtonList)itm.FindControl("rdo_type");
                if (chk.Checked)
                {
                    Label lbl_name = (Label)itm.FindControl("lbl_name");
                    if (Handle.ToInt32(rdolist.SelectedValue) == 1)
                    {
                        Alter_Obj_ids += lbl_name.Text.Trim().ToString() + ",";
                        Alter_row_ids += itm.ItemIndex + ",";
                    }
                    else
                    {
                        Create_Obj_ids += lbl_name.Text.Trim().ToString() + ",";
                        Create_row_ids += itm.ItemIndex + ",";
                    }
                }
            }
            DataTable create_dt_scripts = db_my_functions.GetString(Constring, Create_Obj_ids, 0);
            DataTable alter_dt_scripts = db_my_functions.GetString(Constring, Alter_Obj_ids, 1);
            foreach (DataRow dr in create_dt_scripts.Rows)
            {
                Exec_Create_String += create_dt_scripts.Rows[row]["SCRIPT"].ToString() + "\n";
                row++;
            }
            row = 0;
            foreach (DataRow dr in alter_dt_scripts.Rows)
            {
                Exec_Alter_String += alter_dt_scripts.Rows[row]["SCRIPT"].ToString() + "\n";
                row++;
            }
            if (Exec_Create_String.Trim() != "")
            {
                int count = 0;
                int chk_count = 0;
                String[] sp_script = Exec_Create_String.Replace("'", "''").Split('`');
                String[] row_ids = Create_row_ids.Split(',');
                foreach (String str in sp_script)
                {
                    ret_create = db_my_functions.Exec_Scripts(txt_constring.Text, str);
                    int row_id = Handle.ToInt32(row_ids[count].ToString());
                    ((Label)Repeater1.Items[row_id].FindControl("lbl_err_msg")).Text = ret_create;
                    ret_create = "";
                    count++;
                }
            }
            else if (Exec_Alter_String.Trim() != "")
            {
                int count = 0;
                String[] sp_script = Exec_Alter_String.Replace("'", "''''").Split('`');
                String[] row_ids = Alter_row_ids.Split(',');
                foreach (String str in sp_script)
                {
                    ret_alter = db_my_functions.Exec_Scripts(txt_constring.Text, str);
                    int row_id = Handle.ToInt32(row_ids[count].ToString());
                    ((Label)Repeater1.Items[row_id].FindControl("lbl_err_msg")).Text = ret_alter;
                    count++;
                }
            }
        }
        else
        {
            lblMessage.Text = "Please Select Items";
        }
    }
    #endregion

    protected void add_new_Click(object sender, EventArgs e)
    {
        string lbl_name = txt_lbl_name.Text.Trim();
        string method_name = txt_method_name.Text.Trim();
        string id_by_name = txt_id_by_name.Text.Trim();
        string ids_name = txt_ids_name.Text.Trim();

        db_my_functions.Insert(conSTr, lbl_name, method_name, id_by_name, ids_name);
    }
}
