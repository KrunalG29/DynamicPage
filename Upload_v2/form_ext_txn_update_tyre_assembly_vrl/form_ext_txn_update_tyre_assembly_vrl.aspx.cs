using infinity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

public partial class form_ext_txn_update_tyre_assembly_vrl : COMM_SessionCheck
{
    public static string rpt_file;
    public static int manage_direct_print = 0;
    public static string user_name = "";
    public static String FileName = "";

    #region Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        manage_direct_print = Handle.ToInt32(DAL_Utilities.Get_Site_Config_KeyValue("Direct Print", Handle.ToInt32(Session["comp_id"])));

        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name("form_ext_txn_update_tyre_assembly_vrl.aspx", 1, Handle.ToInt32(Session["comp_id"]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = "form_ext_txn_update_tyre_assembly_vrl.rpt";
        }
        int exportFormatFlag = DAL_Utilities.allowExportFormats();
        CrystalReportViewer1.AllowedExportFormats = exportFormatFlag;
        CrystalReportSource1.Report.FileName = Session["BASE_DIR"] + "ext/reports/" + rpt_file.Trim();
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
        int tyre_no = 0;
            try { tyre_no = db_ctlg_item_mst.GetIdByCode(txt_tyre_no.Text, Handle.ToInt32(Session["comp_id"])); }
            catch { tyre_no = 0; }
                
        int assembly_no = 0;
            try { assembly_no = db_ctlg_item_mst.GetIdByCode(txt_assembly_no.Text, Handle.ToInt32(Session["comp_id"])); }
            catch { assembly_no = 0; }
                
        DAL_GenericDataAccess dal = new DAL_GenericDataAccess();
        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name("form_ext_txn_update_tyre_assembly_vrl.aspx", 1, Handle.ToInt32(Session["comp_id"]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = "form_ext_txn_update_tyre_assembly_vrl.rpt";
        }
        CrystalReportSource1.Report.FileName = Session["BASE_DIR"] + "ext/reports/gfpl/" + rpt_file;
        dal.SetConnectionInfo(CrystalReportSource1.ReportDocument.Database.Tables);
        CrystalReportSource1.ReportDocument.SetParameterValue("emp_name", Session["user_name"].ToString());
        CrystalReportSource1.ReportDocument.SetParameterValue("com_id", Handle.ToInt32(Session["comp_id"]));
          CrystalReportSource1.ReportDocument.SetParameterValue("tyre_no", tyre_no);
          CrystalReportSource1.ReportDocument.SetParameterValue("assembly_no", assembly_no);

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
