using infinity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

public partial class print_purc_vendor_wise_min_max_report : COMM_SessionCheck
{
    public static string rpt_file;
    public static int manage_direct_print = 0;
    public static string user_name = "";
    public static String FileName = "";

    #region Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        manage_direct_print = Handle.ToInt32(DAL_Utilities.Get_Site_Config_KeyValue("Direct Print", Handle.ToInt32(Session["comp_id"])));

        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name("print_purc_vendor_wise_min_max_report.aspx", 1, Handle.ToInt32(Session["comp_id"]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = "print_purc_vendor_wise_min_max_report.rpt";
        }
        int exportFormatFlag = DAL_Utilities.allowExportFormats();
        CrystalReportViewer1.AllowedExportFormats = exportFormatFlag;
        CrystalReportSource1.Report.FileName = Session["BASE_DIR"] + "purc/reports/" + rpt_file.Trim();
        FileName = "";
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            user_name = Session["user_name"].ToString();
            CrystalReportViewer1.Visible = false;
            txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
    }
    #endregion

    #region btnLoad_Click"
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (manage_direct_print == 1)
            {
                DivPrint.Visible = true;
            }
            else
            {
                CrystalReportViewer1.Visible = true;
            }
            bind_data();
        }
    }
    #endregion

    #region bind_data()
    public void bind_data()
    {
        
        int vendor_name = 0;
            try { vendor_name = db_entt_vendor.GetIdByName(txt_vendor_name.Text, Handle.ToInt32(Session["comp_id"])).ToString(); }
            catch { vendor_name = 0; }
                
        int location = 0;
            try { location = db_stor_location.GetIdByName(txt_location.Text.Trim(), Handle.ToInt32(Session["comp_id"])); }
            catch { location = 0; }
                
        DAL_GenericDataAccess dal = new DAL_GenericDataAccess();
        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name("print_purc_vendor_wise_min_max_report.aspx", 1, Handle.ToInt32(Session["comp_id"]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = "print_purc_vendor_wise_min_max_report.rpt";
        }
        CrystalReportSource1.Report.FileName = Session["BASE_DIR"] + "purc/reports/gfpl/" + rpt_file;
        dal.SetConnectionInfo(CrystalReportSource1.ReportDocument.Database.Tables);
        CrystalReportSource1.ReportDocument.SetParameterValue("emp_name", Session["user_name"].ToString());
        CrystalReportSource1.ReportDocument.SetParameterValue("com_id", Handle.ToInt32(Session["comp_id"]));
          CrystalReportSource1.ReportDocument.SetParameterValue("date", Handle.ToDateTime(txt_date.Text.ToString()));
          CrystalReportSource1.ReportDocument.SetParameterValue("vendor_name", vendor_name);
          CrystalReportSource1.ReportDocument.SetParameterValue("location", location);

        if (DivPrint.Visible)
        {
            FileName = "";
            CrystalReportViewer1.Visible = false;
            string source_folder = Session["base_dir"].ToString() + "\\Upload\\";
            if (System.IO.Directory.Exists(source_folder))
            {
                string[] files = System.IO.Directory.GetFiles(source_folder);
                foreach (string s in files)
                {

                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    if (fileName == FileName + ".pdf")
                    {
                        System.IO.File.Delete(source_folder + fileName);
                    }
                }
            }
            CrystalReportSource1.ReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, GetIFrameSavePath(FileName));
            DivPrint.InnerHtml = DAL_Utilities.GetIFrameReport(FileName);
        }
    }
    #endregion
}
