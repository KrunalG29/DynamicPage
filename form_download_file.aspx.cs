using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infinity;
using System.Net;
using System.Text;

public partial class form_download_file : COMM_SessionCheck
{
    public static DataTable dt_file = new DataTable();
    public static int myChanges;
    public static int BothFileGenerate;
    public static string conSTr = "workstation id=infiprodERP.mssql.somee.com;packet size=4096;user id=Nishu2904;pwd=nishu#2904;data source=infiprodERP.mssql.somee.com;persist security info=False;initial catalog=infiprodERP";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddColumn();
            BindData();
            getpagename();
        }
    }
    public static string getpagename()
    {
        if (HttpContext.Current.Request.QueryString["id"] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["id"]))
        {
            Int32 id = Handle.ToInt32(HttpContext.Current.Request.QueryString["id"]);
        }
        string page = "";
        var uri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
        string basic_url = uri.GetLeftPart(UriPartial.Path);
        string[] pnm = basic_url.Split('/');
        page = pnm[pnm.Length - 1];
        return page;
    }
    public void BindData()
    {
        string getfilepath = Server.MapPath("~/Upload_v2/");
        if (!Directory.Exists(getfilepath))
        {
            Directory.CreateDirectory(getfilepath);
        }
        string[] Filenames = Directory.GetDirectories(getfilepath);
        String create_by = "admin";

        foreach (String flm in Filenames)
        {
            string[] SplitName = flm.Split('\\');
            string filename = SplitName[SplitName.Length - 1];
            string[] tbl_names = filename.Split('_');
            dt_file.Rows.Add(filename, create_by, flm);
            dt_file.AcceptChanges();
            RptField.DataSource = dt_file;
            RptField.DataBind();
        }

    }
    public void AddColumn()
    {
        dt_file.Rows.Clear();
        RptField.DataSource = null;
        RptField.DataBind();
        if (dt_file.Columns.Count == 0)
        {
            dt_file = new DataTable();
            dt_file.Columns.Add("table_name", typeof(string));
            dt_file.Columns.Add("create_by", typeof(string));
            dt_file.Columns.Add("folder_name", typeof(string));
            dt_file.Columns.Add("to_mail", typeof(string));
            dt_file.AcceptChanges();
        }
    }

    protected void RptField_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "lnk_download")
        //{
        //    RepeaterItem gvrow = (RepeaterItem)(((LinkButton)e.CommandSource).NamingContainer);
        //    String filePath = ((HiddenField)gvrow.FindControl("hid_fnm")).Value;
        //    string[] Filenames = Directory.GetFiles(filePath);
        //    //String msg_check = db_dynamic_page_2.SendMail("kingofgreenscreen2@gmail.com", filePath, "");
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    Response.End();
        //}
        if (e.CommandName == "lnk_send_mail")
        {
            RepeaterItem gvrow = (RepeaterItem)(((LinkButton)e.CommandSource).NamingContainer);
            String filePath = ((HiddenField)gvrow.FindControl("hid_fnm")).Value;
            String to_mail = ((TextBox)gvrow.FindControl("txt_to_mail")).Text;
            string[] Filenames = Directory.GetFiles(filePath);

            StringBuilder strLog = new StringBuilder();
            strLog.AppendLine("#############################Log##############################");
            strLog.AppendLine();
            strLog.AppendLine("Host IP:" + db_my_functions.GetIp());
            strLog.AppendLine("");
            strLog.AppendLine("To Mail:" + to_mail);
            strLog.AppendLine("");
            strLog.AppendLine("File Path:" + filePath);
            strLog.AppendLine();
            strLog.AppendLine();
            strLog.AppendLine("##############################################################");

            #region Dynamic page use Log File Function
            CreateDynamicPageLogFile(strLog.ToString());
            #endregion

            String msg = db_my_functions.SendMail(to_mail, Filenames, "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "str", "<script language='javascript'>alert('" + msg + "');</script>", false);
        }
    }


    #region CreateDynamicPageLogFile Function
    public String CreateDynamicPageLogFile(String text)
    {
        string obj_name = "SenMail_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + "_Log";
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string filepath = string.Empty;
            if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + "LogFile" + "\\"))
            {
                DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + "LogFile" + "\\");
                thisFolder1.Create();
            }
            filepath = root + "\\SystemGeneratePages" + "\\" + "LogFile" + "\\" + obj_name + ".txt";



            //          string SaveFilePath = root + "\\SystemGeneratePages\\" + obj_name + ".txt";
            if (File.Exists(filepath))
            {
                ret = "File Name " + obj_name + " already exist!";
            }
            else
            {
                FileStream fsSave = File.Create(filepath);
                StreamWriter sw = null;
                try
                {//write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(text);
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                }
                finally
                {
                    sw.Close();
                }
            }
        }
        catch (Exception ex)
        {
            ret = ex.Message;
        }
        return ret;
    }
    #endregion
}