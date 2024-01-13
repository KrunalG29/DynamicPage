using infinity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kogs;
using System.Text;
using System.Net;

public partial class form_dynamic_page_v2 : COMM_SessionCheck
{

    #region GLOBAL
    public static string conSTr = "workstation id=infiprodERP.mssql.somee.com;packet size=4096;user id=Nishu2904;pwd=nishu#2904;data source=infiprodERP.mssql.somee.com;persist security info=False;initial catalog=infiprodERP";
    public static string conProd = @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=nothing1plus_SampleDB;User ID=nothing1plus_SampleDB;Password=DBSamplePW;Persist Security Info=True;";
    String Constring = "Data Source=192.168.30.70;Initial Catalog=infiprod_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP";
    public DataTable rptdt = new DataTable(); // for Material Detail
    DataTable rptdt_copy = new DataTable();
    public static String Ret_str = "";
    public static String Ret_str_variable = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //div_excel_export.Visible = false;
            //div_function.Visible = false;
            //div_print_page.Visible = false;
            //BindMethodName();
            ErrorMsg.Text = "";
        }
        HyperLink1.NavigateUrl = "from_to_destination.aspx?new_id=1";
    }
    #endregion

    #region btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Handle.ToInt32(ddl_lbl_type.SelectedValue) == 3 || Handle.ToInt32(ddl_lbl_type.SelectedValue) == 4 || Handle.ToInt32(ddl_lbl_type.SelectedValue) == 5)
        {
            div_method.Visible = false;
            hid_lbl_name.Value = txt_lbl_name.Text.Trim();
            hid_lbl_id.Value = txt_lbl_name.Text.Trim();
        }
        else
        {
            div_method.Visible = true;
            hid_lbl_id.Value = txt_lbl_name.Text.Trim();
        }
        manageviewstate();
    }
    #endregion

    #region manageviewstate
    public void manageviewstate()
    {
        manageTable();
        MakeViewsateForGrid();
        DataTable dt_RptField = ViewState["rptdt"] as DataTable;
        RptField.DataSource = dt_RptField;
        RptField.DataBind();
        ClearAll();
    }
    #endregion

    #region Create_Click
    protected void Create_Click(object sender, EventArgs e)
    {
        GenerateLog();
        hid_create_click.Value = "1";
        manageviewstate();
        CreatePrintPage(txt_file_name.Text.Trim(), ViewState["rptdt"] as DataTable);
        hid_create_click.Value = "0";
    }
    #endregion

    // Print Page Controlers
    #region function for create LIST ASPX file
    public String CreatePrintPage(String obj_name, DataTable rpt_dt)
    {
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string SaveFilePath = string.Empty;

            //if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\"))
            //{
            //    DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\");
            //    thisFolder1.Create();
            //}

            //string SaveFilePath = root + "\\SystemGeneratePages\\" + ddlProject.SelectedItem + "\\" + obj_name;
            if (File.Exists(SaveFilePath))
            {
                ret = "File Name " + obj_name + " already exist!";
            }
            else
            {
                StreamWriter sw = null;
                try
                {
                    string pathFile = Server.MapPath("~/Upload_v2/") + obj_name;
                    DirectoryInfo directory = new DirectoryInfo(pathFile);
                    if (Directory.Exists(pathFile))
                    {
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in directory.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(pathFile);
                    }
                    //write content
                    SaveFilePath = Server.MapPath("~/Upload_v2/" + obj_name + "/") + "\\" + obj_name + ".aspx";
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreatePrintAspxString(obj_name, rptdt));
                    ret = CreatePrintCSPage(obj_name, rptdt);
                    sw.Close();
                    sw.Dispose();
                    //if (ret != "Operation Successfully")
                    //{
                    //    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + obj_name;
                    //    if (File.Exists(SaveFilePath))
                    //    {
                    //        File.Delete(SaveFilePath);
                    //    }
                    //}
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

    #region Create String for Print aspx file
    public String CreatePrintAspxString(String obj_name, DataTable rptdt)
    {
        String FAspx = @"<%@ Page Title="" Language=""C#"" MasterPageFile=""~/Include/Master/site.master"" AutoEventWireup =""true"" CodeBehind =""" + obj_name + @".aspx.cs"" Inherits =""" + obj_name + @""" %>

<%@ Register Assembly=""CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304""
    Namespace = ""CrystalDecisions.Web"" TagPrefix= ""CR"" %>
<%@ Register Src=""~/Include/usercontrol/MultiSelectionTextBox.ascx"" TagName =""MultiSelectionTextBox""
    TagPrefix =""uc2"" %>
<asp:Content ID=""Content1"" ContentPlaceHolderID =""cphHead"" runat =""server"" >
</asp:Content>
<asp:Content ID=""Content2"" ContentPlaceHolderID =""ContentPlaceHolder1"" runat =""server"" >
    <asp:UpdatePanel ID= ""UpdatePanel"" runat= ""server"" UpdateMode =""Conditional"" >
        <Triggers>
            <asp:PostBackTrigger ControlID=""btnLoad"" />
        </Triggers>
        <ContentTemplate>
            <!-- MAIN CONTENT -->
            <div id=""content"" >
                <div class=""row"">
                </div>
                <!-- widget grid -->
                <section id=""widget-grid"" class="""" >
                    <!-- row -->
                    <div class=""row"" >
                        <!-- NEW WIDGET START -->
                        <!-- Widget ID (each widget will need unique ID)-->
                        <div class=""jarviswidget"" id =""wid-id-0"" data-widget-sortable=""false"" data-widget-deletebutton=""false"" data-widget-togglebutton=""false"" data-widget-editbutton=""false"" >
                            <header>
                                <span class=""widget-icon""><i class=""fa fa-eye""></i></span>
                                <h2></h2>

                            </header>
                            <!-- widget div-->
                            <div>
                                <!-- widget edit box -->
                                <div class=""jarviswidget-editbox"">
                                    <!-- This area used as dropdown edit box -->
                                </div>
                                <!-- end widget edit box -->
                                <!-- widget content -->
                                <div class=""widget-body"">
                                    <div class=""form-group"">
                                        <asp:Label ID = ""lblMessage"" runat =""server"" Style =""color: red; margin-left: 0px;""></asp:Label>
                                    </div>
                                    <fieldset>
                                        ";
        Int32 count = 1;
        foreach (DataRow dr in rptdt.Rows)
        {
            int id = Handle.ToInt32(dr["id"]);
            String Label_Name = Handle.ToString(dr["Label_Name"]);
            String Label_Type = Handle.ToString(dr["Label_Type"]);
            String Method_Name = Handle.ToString(dr["Method_Name"]);
            String IdByName = Handle.ToString(dr["IdByName"]);
            String IdsByName = Handle.ToString(dr["IdsByName"]);
            String Label_id = Handle.ToString(dr["Label_id"]);
            String List_str = Handle.ToString(dr["List_str"]);

            if (count % 2 != 0)
            {
                FAspx += @"
                                        <div class=""form-group"">";
            }
            FAspx += @"                           <section class=""col col-6"">                                                
                              <label class=""col-md-2 control-label"" >
                                                " + Label_Name + @"</label>
                              <div class=""col-md-4"">
                                                 " + CreateControlASPX(id, Handle.ToString(Label_Type), Method_Name, IdByName, IdsByName, Label_Name, Label_id, List_str) + @"
                                                </div>
                                        </section>";

            if (count % 2 == 0 || rptdt.Rows.Count == count)
            {
                FAspx += @"                            </div>";
            }

            count++;
        }
        FAspx += @"                 
                                    <div class=""form-group"" >
                                        <section class=""col col-6"" >
                                            <label class=""col-md-2 control-label"">
                                            </label>
                                            <div class=""col-md-4"" style =""margin-top: 8px;"" >
                                                <asp:Button ID=""btnLoad"" Width=""80"" runat=""server"" Text=""Load"" class=""btn btn-primary""
                                                    OnClick =""btnLoad_Click"" />
                                            </div>
                                        </section>
                                    </div>
                                    </fieldset>
                                    <fieldset>
                                        <div class=""form-group"" >
                                            <CR:CrystalReportViewer ID=""CrystalReportViewer1"" PrintMode=""ActiveX"" ReportSourceID=""CrystalReportSource1""
                                                runat=""server"" AutoDataBind =""true"" HasToggleGroupTreeButton =""false"" HasToggleParameterPanelButton =""false""
                                                ToolPanelView=""None"" HasCrystalLogo=""False"" EnableDrillDown=""false""/>
                                            <CR:CrystalReportSource ID=""CrystalReportSource1"" runat =""server"" >
                                            </CR:CrystalReportSource>
                                        </div>
                                    </fieldset>
                                        <fieldset>
                                         <div class=""form-group"" style =""padding-left:1%; padding-right:1%; height:1200px;"" runat =""server"" id =""DivPrint"" >
                                        </div>
                                 </fieldset>
                                </div>
                                <!-- end widget content -->
                            </div>
                            <!-- end widget div -->
                        </div>
                        <!-- end widget -->
                        <!-- WIDGET END -->
                    </div>
                    <!-- end row -->
                </section>
                <!-- end widget grid -->
            </div>
            <!-- END MAIN CONTENT -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>";
        //FAspx = String.Format(FAspx, txt_formPage.Text.Replace(".aspx", ""), txtMenName.Text, txt_ListPage.Text);
        return FAspx;
    }
    #endregion

    #region Create String for Print CS file
    public String CreatePrintCSString(String obj_name, DataTable rpt_dt)
    {
        String FAspx = @"using infinity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

public partial class " + obj_name + @" : COMM_SessionCheck
{
    public static string rpt_file;
    public static int manage_direct_print = 0;
    public static string user_name = """";
    public static String FileName = """";

    #region Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        manage_direct_print = Handle.ToInt32(DAL_Utilities.Get_Site_Config_KeyValue(""Direct Print"", Handle.ToInt32(Session[""comp_id""])));

        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name(""" + obj_name + @".aspx"", 1, Handle.ToInt32(Session[""comp_id""]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = """ + obj_name + @".rpt"";
        }
        int exportFormatFlag = DAL_Utilities.allowExportFormats();
        CrystalReportViewer1.AllowedExportFormats = exportFormatFlag;
        CrystalReportSource1.Report.FileName = Session[""BASE_DIR""] + """ + obj_name.Split('_')[1] + @"/reports/"" + rpt_file.Trim();
        FileName = """";
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            user_name = Session[""user_name""].ToString();
            CrystalReportViewer1.Visible = false;
";


        foreach (DataRow dr in rpt_dt.Rows)
        {
            int id = Handle.ToInt32(dr["id"]);
            String Label_id = Handle.ToString(dr["Label_id"]);

            if (id == 4)
            {
                FAspx += @"            txt_" + Label_id.Replace(' ', '_').ToLower() + @".Text = DateTime.Now.ToString(""dd/MM/yyyy"");
";
            }
        }
        FAspx += @"
        }
    }
    #endregion

    #region btnLoad_Click""
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
";

        foreach (DataRow dr in rpt_dt.Rows)
        {
            int id = Handle.ToInt32(dr["id"]);
            String Label_Name = Handle.ToString(dr["Label_Name"]);
            String Label_Type = Handle.ToString(dr["Label_Type"]);
            String Method_Name = Handle.ToString(dr["Method_Name"]);
            String IdByName = Handle.ToString(dr["IdByName"]);
            String IdsByName = Handle.ToString(dr["IdsByName"]);
            String Label_id = Handle.ToString(dr["Label_id"]);
            String List_str = Handle.ToString(dr["List_str"]);

            FAspx += @"        " + CreateControlCS(id, 1, Handle.ToString(Label_Type), Method_Name, IdByName, IdsByName, Label_Name, Label_id, List_str) + @"
";
        }

        FAspx += @"        DAL_GenericDataAccess dal = new DAL_GenericDataAccess();
        rpt_file = db_conf_report_configuration_mst.Get_rpt_file_name(""" + obj_name + @".aspx"", 1, Handle.ToInt32(Session[""comp_id""]));
        if (String.IsNullOrEmpty(rpt_file))
        {
            rpt_file = """ + obj_name + @".rpt"";
        }
        CrystalReportSource1.Report.FileName = Session[""BASE_DIR""] + """ + obj_name.Split('_')[1] + @"/reports/gfpl/"" + rpt_file;
        dal.SetConnectionInfo(CrystalReportSource1.ReportDocument.Database.Tables);
        CrystalReportSource1.ReportDocument.SetParameterValue(""emp_name"", Session[""user_name""].ToString());
        CrystalReportSource1.ReportDocument.SetParameterValue(""com_id"", Handle.ToInt32(Session[""comp_id""]));
";

        Int32 count = 1;
        foreach (DataRow dr in rpt_dt.Rows)
        {
            int id = Handle.ToInt32(dr["id"]);
            String Label_Name = Handle.ToString(dr["Label_Name"]);
            String Label_Type = Handle.ToString(dr["Label_Type"]);
            String Method_Name = Handle.ToString(dr["Method_Name"]);
            String IdByName = Handle.ToString(dr["IdByName"]);
            String IdsByName = Handle.ToString(dr["IdsByName"]);
            String Label_id = Handle.ToString(dr["Label_id"]);
            String List_str = Handle.ToString(dr["List_str"]);

            FAspx += @"        " + CreateControlCS(id, 2, Handle.ToString(Label_Type), Method_Name, IdByName, IdsByName, Label_Name, Label_id, List_str) + @"
";
            count++;
        }
        FAspx += @"
        if (DivPrint.Visible)
        {
            FileName = """";
            CrystalReportViewer1.Visible = false;
            string source_folder = Session[""base_dir""].ToString() + ""\\Upload\\"";
            if (System.IO.Directory.Exists(source_folder))
            {
                string[] files = System.IO.Directory.GetFiles(source_folder);
                foreach (string s in files)
                {

                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    if (fileName == FileName + "".pdf"")
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
";

        //  FAspx = String.Format(FAspx, txt_ListPage.Text.Replace(".aspx", ""), txtMenName.Text.Replace(" ", "_"), ColumnPreFix, txt_filedb.Text, txt_filedb.Text.Replace("db_", "_"));
        return FAspx;
    }
    #endregion

    #region create dynamic controls
    public String CreateControlASPX(Int32 ContType, String Label_Type, String Method_Name, String IdByName, String IdsByName, String Label_Name, String FNM, String List_str)
    {
        String str = "";
        string contrEnabled = "";
        FNM = FNM.Replace(' ', '_').ToLower();
        switch (ContType)
        {
            case 1:
                str = @"<asp:TextBox ID=""txt_" + FNM + @"""  CssClass=""form-control"" " + contrEnabled + @" runat=""server"" PlaceHolder=""Type And Select """ + Label_Name + @"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender FirstRowSelected=""true"" ID=""AutoCompleteExtender_" + FNM + @""" runat=""server"" ServicePath=""~/Web_Services.asmx""
                        ServiceMethod=""" + Method_Name + @""" TargetControlID=""txt_" + FNM + @""" MinimumPrefixLength=""1""
                        CompletionListCssClass=""listMain"" EnableCaching=""false"" CompletionListHighlightedItemCssClass=""itemsSelected""
                        CompletionListItemCssClass=""itemsMain"" UseContextKey=""true"" ContextKey="" "">
                        </ajaxToolkit:AutoCompleteExtender>";
                break;
            case 2:
                str = @" <uc2:MultiSelectionTextBox ID=""txt" + FNM + @""" runat=""server"" firstrowselected=""true"" ServicePath=""~/Web_Services.asmx""
                            ServiceMethod=""" + Method_Name + @""" UseContextKey =""true"" ContextKey ="""" MinimumPrefixLength=""1""
                           CompletionListCssClass=""listMainMS"" CompletionListHighlightedItemCssClass=""itemsSelected""
                           CompletionListItemCssClass=""itemsMain""></ uc2:MultiSelectionTextBox>";
                break;
            case 3:
                str = @"<asp:DropDownList ID=""ddl_" + FNM.Replace(' ', '_') + @""" CssClass=""form-control"" " + contrEnabled + @" runat=""server"" AppendDataBoundItems=""true"">";
                String[] Enm = List_str.Split(',');
                if (Enm.Length > 0)
                {
                    for (Int32 lp = 0; lp < Enm.Length; lp += 2)
                    {
                        str += @"<asp:ListItem Text=""" + Enm[lp + 1].ToString() + @""" Value=""" + Enm[lp].ToString() + @"""></asp:ListItem>";
                    }
                }
                str += @"</asp:DropDownList>";
                break;
            case 4:
                str = @"<asp:TextBox ID=""txt_" + FNM.Replace(' ', '_') + @""" CssClass=""form-control"" " + contrEnabled + @" runat=""server""></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID=""CalendarExtender_" + FNM.Replace(' ', '_') + @""" runat=""server"" Format=""dd/MM/yyyy""
                         TargetControlID=""txt_" + FNM.Replace(' ', '_') + @""">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID=""MaskedEditExtender_" + FNM.Replace(' ', '_') + @""" runat=""server"" TargetControlID=""txt_" + FNM.Replace(' ', '_') + @"""
                         Mask=""99/99/9999"" MessageValidatorTip=""true"" OnFocusCssClass=""MaskedEditFocus""
                         OnInvalidCssClass=""MaskedEditError"" MaskType=""Date"" DisplayMoney=""Left"" AcceptNegative=""Left""
                         ErrorTooltipEnabled=""True"" />
                        <ajaxToolkit:MaskedEditValidator ID=""MaskedEditValidator_" + FNM.Replace(' ', '_') + @""" IsValidEmpty=""true"" runat=""server""
                         CssClass=""error_messe"" ControlToValidate=""txt_" + FNM.Replace(' ', '_') + @""" ControlExtender=""MaskedEditExtender_" + FNM.Replace(' ', '_') + @"""
                         InvalidValueMessage=""Date not valid"" >
                        </ajaxToolkit:MaskedEditValidator>";
                break;
            case 5:
                str = @"<asp:RadioButtonList CssClass=""ListControl""  " + contrEnabled + @"  runat=""server"" ID=""rdo_" + FNM.Replace(' ', '_') + @""" AppendDataBoundItems=""true"">";
                String[] Enm2 = List_str.Split(',');
                if (Enm2.Length > 0)
                {
                    for (Int32 lp = 0; lp < Enm2.Length; lp += 2)
                    {
                        str += Environment.NewLine + @"<asp:ListItem Text=""" + Enm2[lp + 1].ToString() + @""" Value=""" + Enm2[lp].ToString() + @"""></asp:ListItem>";
                    }
                }
                str += @"</asp:RadioButtonList>";
                break;
        }
        return str;

    }
    #endregion  

    #region create dynamic controls
    public String CreateControlCS(Int32 ContType, Int32 LineType, String Label_Type, String Method_Name, String IdByName, String IdsByName, String Label_Name, String FNM, String List_str)
    {
        String str = "";
        FNM = FNM.Replace(' ', '_').ToLower();
        switch (ContType)
        {
            case 1:
                switch (LineType)
                {
                    case 1:
                        str = @"int " + FNM.Replace("txt_", "") + @" = 0;
            try { " + FNM.Replace("txt_", "") + @" = " + IdByName.Replace("TEXTBOXID", "txt_" + FNM + ".Text") + @" }
            catch { " + FNM.Replace("txt_", "") + @" = 0; }
                ";
                        break;
                    case 2:
                        str = @"  CrystalReportSource1.ReportDocument.SetParameterValue(""" + FNM + @""", " + FNM.Replace("txt_", "") + ");";
                        break;
                }
                break;
            case 2:
                switch (LineType)
                {
                    case 1:
                        str = @"string " + FNM.Replace("txt_", "") + @"s = """";
            try { " + FNM.Replace("txt_", "") + @"s = " + IdsByName.Replace("TEXTBOXID", "txt" + FNM + ".Text") + @" }
            catch { " + FNM.Replace("txt_", "") + @"s = """"; }
                ";
                        break;
                    case 2:
                        str = @"  CrystalReportSource1.ReportDocument.SetParameterValue(""" + FNM + @""", " + FNM.Replace("txt_", "") + "s);";
                        break;
                }
                break;
            case 3:
                switch (LineType)
                {
                    case 1:
                        str = @"";
                        break;
                    case 2:
                        str = @"  CrystalReportSource1.ReportDocument.SetParameterValue(""" + FNM + @""", Handle.ToInt32(ddl_" + FNM + ".SelectedValue));";
                        break;
                }
                break;
            case 4:
                switch (LineType)
                {
                    case 1:
                        str = @"";
                        break;
                    case 2:
                        str = @"  CrystalReportSource1.ReportDocument.SetParameterValue(""" + FNM.Replace(' ', '_') + @""", Handle.ToDateTime(txt_" + FNM.Replace(' ', '_') + @".Text.ToString()));";
                        break;
                }
                break;
            case 5:
                switch (LineType)
                {
                    case 1:
                        str = @"";
                        break;
                    case 2:
                        str = @"  CrystalReportSource1.ReportDocument.SetParameterValue(""" + FNM + @""", Handle.ToInt32(rdo_" + FNM + ".SelectedValue));";
                        break;
                }
                break;
        }
        return str;

    }
    #endregion

    #region function for create LIST CS file
    public String CreatePrintCSPage(String obj_name, DataTable rpt_dt)
    {
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string SaveFilePath = string.Empty;

            //if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\"))
            //{
            //    DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\");
            //    thisFolder1.Create();
            //}

            //string SaveFilePath = root + "\\SystemGeneratePages\\" + ddlProject.SelectedItem + "\\" + obj_name;
            if (File.Exists(SaveFilePath))
            {
                ret = "File Name " + obj_name + " already exist!";
            }
            else
            {
                StreamWriter sw = null;
                try
                {//write content
                    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + obj_name + "\\" + "\\" + obj_name + ".aspx.cs";
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreatePrintCSString(obj_name, rpt_dt));
                    sw.Close();
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

    // Other Page Controlers
    #region BindMethodName
    public void BindMethodName()
    {
        DataTable dt = db_my_functions.GetBindMethodNames(conSTr);
        if (dt != null && dt.Rows.Count > 0)
        {
            ddl_method_name.Items.Clear();
            ddl_method_name.DataSource = dt;
            ddl_method_name.DataTextField = "Label_Name";
            ddl_method_name.DataValueField = "id";
            ddl_method_name.DataBind();
            ddl_method_name.Items.Insert(0, new ListItem("Select Method Name", "0"));
        }
        GetData(dt);
    }
    #endregion

    #region GetData
    public void GetData(DataTable dt)
    {
        rptdt_copy = dt;
        ViewState["rptdt_copy"] = dt;
    }
    #endregion

    #region RptField_ItemCommand
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

        }
    }
    #endregion

    #region manageTable function
    public void manageTable()
    {
        if (ViewState["rptdt"] == null)
        {
            rptdt.Columns.Add("id", typeof(Int32));
            rptdt.Columns.Add("Label_Name", typeof(string));
            rptdt.Columns.Add("Label_Type", typeof(string));
            rptdt.Columns.Add("Method_Name", typeof(string));
            rptdt.Columns.Add("IdByName", typeof(string));
            rptdt.Columns.Add("IdsByName", typeof(string));
            rptdt.Columns.Add("Label_id", typeof(string));
            rptdt.Columns.Add("List_str", typeof(string));
            rptdt.AcceptChanges();
            ViewState["rptdt"] = rptdt;
        }
    }
    #endregion

    #region MakeViewsateForGrid
    public void MakeViewsateForGrid()
    {
        rptdt = ViewState["rptdt"] as DataTable;
        if (CheckDuplicateItem(rptdt) && Handle.ToInt32(hid_create_click.Value) == 0)
        {
            DataRow rd = rptdt.NewRow();
            rd["id"] = Handle.ToInt32(ddl_lbl_type.SelectedItem.Value.Trim());
            rd["Label_Name"] = Handle.ToString(hid_lbl_name.Value.Trim());
            rd["Label_Type"] = Handle.ToString(ddl_lbl_type.SelectedItem.Text.Trim());
            rd["Method_Name"] = Handle.ToString(hid_method_name.Value.Trim());
            rd["IdByName"] = Handle.ToString(hid_id_by_name.Value.Trim());
            rd["IdsByName"] = Handle.ToString(hid_ids_by_name.Value.Trim());
            rd["Label_id"] = Handle.ToString(hid_lbl_id.Value.Trim());
            rd["List_str"] = Handle.ToString(list_item.Text.Trim());
            rptdt.Rows.Add(rd);
            rptdt.AcceptChanges();
            ViewState["rptdt"] = rptdt;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "str", "<script language='javascript'>alert('Item With Same Properties Does Not Allowed');</script>", false);
        }

    }
    #endregion

    #region CheckDuplicateItem
    public Boolean CheckDuplicateItem(DataTable dtitem)
    {
        int flag = 0;

        foreach (DataRow grid in dtitem.Rows)
        {

            String Label_Name = Handle.ToString(grid["Label_Name"]);
            String Method_Name = Handle.ToString(grid["Method_Name"]);
            if (Label_Name == Handle.ToString(txt_lbl_name.Text))
            {
                flag = 1;
                break;
            }

        }
        return (flag == 1 ? false : true);
    }
    #endregion

    #region method_name_SelectedIndexChanged
    protected void method_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int ddl_method = Handle.ToInt32(ddl.SelectedValue);
        DataTable dt = ViewState["rptdt_copy"] as DataTable;
        if (dt.Rows.Count > 0)
        {
            DataRow[] dataRow = dt.Select("id=" + ddl_method.ToString());
            hid_method_name.Value = dataRow[0]["Method_Name"].ToString();
            hid_id_by_name.Value = dataRow[0]["IdByName"].ToString();
            hid_ids_by_name.Value = dataRow[0]["IdsByName"].ToString();
            hid_lbl_name.Value = dataRow[0]["Label_Name"].ToString();
        }
    }
    #endregion

    #region ClearAll
    public void ClearAll()
    {

    }
    #endregion

    #region CreatePrintAspxString DEMO
    public void CreatePrintAspxString()
    {
        String PrintString = "";

        PrintString = @"
<%@ Page Title="" Language=""C#"" MasterPageFile=""~/Include/Master/site.master"" AutoEventWireup =""true"" CodeBehind =""print_store_production_issue_voucher_summary_register_report.aspx.cs"" Inherits =""print_store_production_issue_voucher_summary_register_report"" %>

<%@ Register Assembly=""CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304""
    Namespace = ""CrystalDecisions.Web"" TagPrefix= ""CR"" %>
<%@ Register Src=""~/Include/usercontrol/MultiSelectionTextBox.ascx"" TagName =""MultiSelectionTextBox""
    TagPrefix =""uc1"" %>
<asp:Content ID=""Content1"" ContentPlaceHolderID =""cphHead"" runat =""server"" >
</asp:Content>
<asp:Content ID=""Content2"" ContentPlaceHolderID =""ContentPlaceHolder1"" runat =""server"" >
    <asp:UpdatePanel ID= ""UpdatePanel"" runat= ""server"" UpdateMode =""Conditional"" >
        <Triggers>
            <asp:PostBackTrigger ControlID=""btnLoad"" />
        </Triggers>
        <ContentTemplate>
            <!-- MAIN CONTENT -->
            <div id=""content"" >
                <div class=""row"">
                </div>
                <!-- widget grid -->
                <section id=""widget-grid"" class="""" >
                    <!-- row -->
                    <div class=""row"" >
                        <!-- NEW WIDGET START -->
                        <!-- Widget ID (each widget will need unique ID)-->
                        <div class=""jarviswidget"" id =""wid-id-0"" data-widget-sortable=""false"" data-widget-deletebutton=""false"" data-widget-togglebutton=""false"" data-widget-editbutton=""false"" >
                            <header>""
                                <span class=""widget-icon""><i class=""fa fa-eye""></i></span>
                                <h2></h2>

                            </header>
                            <!-- widget div-->
                            <div>
                                <!-- widget edit box -->
                                <div class=""jarviswidget-editbox"">
                                    <!-- This area used as dropdown edit box -->
                                </div>
                                <!-- end widget edit box -->
                                <!-- widget content -->
                                <div class=""widget-body"">
                                    <div class=""form-group"">
                                        <asp:Label ID = ""lblMessage"" runat =""server"" Style =""color: red; margin-left: 0px;""></asp:Label>
                                    </div>
                                    <fieldset>
                                        <div class=""form-group"">
                                            <section class=""col col-6"" >
                                                <label class=""col-md-2 control-label"" >
                                                    <span class=""red_star""> *</span>From Date</label>
                                                <div class=""col-md-4"" >
                                                    <asp:TextBox ID=""txtFromDate"" CssClass=""form-control"" runat=""server""></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID=""CalendarExtenderFromDate"" runat=""server"" Format=""dd/MM/yyyy""
                                                        TargetControlID =""txtFromDate"">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID=""MaskedEditExtenderFromDate"" runat=""server"" TargetControlID=""txtFromDate""
                                                        Mask =""99/99/9999"" MessageValidatorTip=""true"" OnFocusCssClass=""MaskedEditFocus""
                                                        OnInvalidCssClass=""MaskedEditError"" MaskType=""Date"" DisplayMoney=""Left"" AcceptNegative=""Left""
                                                        ErrorTooltipEnabled=""True""/>
                                                    <ajaxToolkit:MaskedEditValidator ID=""MaskedEditValidatorFromDate"" runat=""server"" ControlExtender =""MaskedEditExtenderFromDate""
                                                        ControlToValidate=""txtFromDate"" IsValidEmpty =""true"" InvalidValueMessage =""Date not valid""
                                                        Display=""Dynamic"" CssClass=""error_messe""></ajaxToolkit:MaskedEditValidator>
                                                    <asp:RequiredFieldValidator CssClass=""error_messe"" ID=""rfvFromDate"" runat=""server""
                                                        ControlToValidate=""txtFromDate"" Display=""dynamic"" ErrorMessage=""Please enter from date""></asp:RequiredFieldValidator>
                                                </div>
                                            </section>
                                            <section class=""col col-6"" >
                                                <label class=""col-md-2 control-label"">
                                                    <span class=""red_star""> *</span>To Date</label>
                                                <div class=""col-md-4"">
                                                    <asp:TextBox ID=""txtToDate"" CssClass=""form-control"" runat=""server""></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID=""CalendarExtenderToDate"" runat=""server"" Format=""dd/MM/yyyy""
                                                        TargetControlID =""txtFromDate"">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID=""MaskedEditExtenderToDate"" runat=""server"" TargetControlID=""txtToDate""
                                                        Mask =""99/99/9999"" MessageValidatorTip=""true"" OnFocusCssClass=""MaskedEditFocus""
                                                        OnInvalidCssClass=""MaskedEditError"" MaskType=""Date"" DisplayMoney=""Left"" AcceptNegative=""Left""
                                                        ErrorTooltipEnabled=""True""/>
                                                    <ajaxToolkit:MaskedEditValidator ID=""MaskedEditValidatorToDate"" runat=""server"" ControlExtender =""MaskedEditExtenderToDate""
                                                        ControlToValidate=""txtToDate"" IsValidEmpty =""true"" InvalidValueMessage =""Date not valid""
                                                        Display=""Dynamic"" CssClass=""error_messe""></ajaxToolkit:MaskedEditValidator>
                                                    <asp:RequiredFieldValidator CssClass=""error_messe"" ID=""rfvFromDate"" runat=""server""
                                                        ControlToValidate=""txtToDate"" Display=""dynamic"" ErrorMessage=""Please enter to date""></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID=""CompareValidator2"" ControlToValidate=""txtToDate"" Display =""Dynamic"" ControlToCompare=""txtFromDate"" runat=""server"" ErrorMessage=""To Date Must be Greater Than OR Equal to From date..""
                                                        Operator=""GreaterThanEqual"" Type=""Date"" CssClass=""error_messe""></asp:CompareValidator>
                                                </div>
                                            </section>
                                        </div>

                                    </fieldset>
                                    <fieldset>
                                        <div class=""form-group"" >

                                            <CR:CrystalReportViewer ID=""CrystalReportViewer1"" PrintMode=""ActiveX"" ReportSourceID=""CrystalReportSource1""
                                                runat=""server"" AutoDataBind =""true"" HasToggleGroupTreeButton =""false"" HasToggleParameterPanelButton =""false""
                                                ToolPanelView=""None"" HasCrystalLogo=""False"" EnableDrillDown=""false""/>
                                            <CR:CrystalReportSource ID=""CrystalReportSource1"" runat =""server"" >
                                            </CR:CrystalReportSource>
                                        </div>
                                    </fieldset>
                                </div>
                                <!-- end widget content -->
                            </div>
                            <!-- end widget div -->
                        </div>
                        <!-- end widget -->
                        <!-- WIDGET END -->
                    </div>
                    <!-- end row -->
                </section>
                <!-- end widget grid -->
            </div>
            <!-- END MAIN CONTENT -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
";
    }

    #endregion

    #region ddl_lbl_type_SelectedIndexChanged
    protected void ddl_lbl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int ddl_method = Handle.ToInt32(ddl.SelectedValue);
        if (ddl_method == 4)
        {
            div_method.Visible = false;
        }
        else if (ddl_method == 5 || ddl_method == 3)
        {
            list_item.Visible = true;
        }
        else
        {
            div_method.Visible = true;
            list_item.Visible = false;
        }
    }
    #endregion

    // Function controller
    #region Create_Func_Click1
    protected void Create_Func_Click1(object sender, EventArgs e)
    {
        ErrorMsg.Text = "";
        GenerateLog();
        String str = TextBox2.Text.Trim();
        String Function = "";
        string[] strArray = str.Split('\n');
        String func_name = txt_func_name.Text.Trim();
        int func_type = Handle.ToInt32(ddl_func_type.SelectedValue);
        if (func_type > 0)
        {
            if (func_name.Length > 0)
            {
                if (str.Length > 0)
                {
                    Function = CreateFunc(func_type, strArray);
                    TextBox1.Text = Function;
                }
                else
                {
                    ErrorMsg.Text = "Please Enter ALTER PARAM SCRIPT";
                }
            }
            else
            {
                ErrorMsg.Text = "Please Enter Function Name";
            }
        }
        else
        {
            ErrorMsg.Text = "Please Select Function Type";
        }
    }
    #endregion

    #region CreateFunc
    public string CreateFunc(Int32 func_type, String[] strArray)
    {
        String setStr = "";
        String strStatic = @"
                            /// get a configured DbCommand object
                            DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
                            DbCommand comm = gda.CreateCommand();

                            /// set the stored procedure name";
        switch (func_type)
        {
            case 1:
                setStr = @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static PROP_db_return " + txt_func_name.Text.Trim() + @"(" + "PROP_FILE_NAME" + @" obj)
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 1) + @"
                           param = comm.CreateParameter();
                           param.ParameterName = ""@out_id"";
                           param.Direction = ParameterDirection.Output;
                           param.DbType = DbType.Int32;
                           comm.Parameters.Add(param);

                           param = comm.CreateParameter();
                           param.ParameterName = ""@alert_msg"";
                           param.Direction = ParameterDirection.Output;
                           param.DbType = DbType.String;
                           param.Size = 300;
                           comm.Parameters.Add(param);

                           PROP_db_return retObj = new PROP_db_return();
                           int resultval = gda.ExecuteNonQuery(comm);
                           retObj.id = Handle.ToInt32(comm.Parameters[""@out_id""].Value);
                           retObj.alertMessage = Handle.ToString(comm.Parameters[""@alert_msg""].Value);
                           return retObj; 
                           }
                           #endregion
";
                break;
            case 2:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static DataTable " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           DataTable table = gda.ExecuteSelectCommand(comm);
                           return table;
                           }
                           #endregion
                ";
                break;
            case 3:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static DataSet " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           DataSet table = gda.ExecuteSelectCommandDataset(comm);
                           return table;
                           }
                           #endregion
                ";
                break;
            case 4:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static string " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           string retStr = gda.ExecuteScalar(comm);
                           return retStr;
                           }
                           #endregion
                ";
                break;
            case 5:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static Boolean " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           int retval = gda.ExecuteNonQuery(comm);

                           if (retval > 0)
                              return true;
                           else
                              return false;
                           }
                           #endregion
                ";
                break;
            case 6:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static int " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           int retInt = Handle.ToInt32(gda.ExecuteScalar(comm));
                           return retInt;
                           }
                           #endregion
                ";
                break;
            case 7:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static DateTime " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           int retDateTime = Handle.DateTime(gda.ExecuteScalar(comm));
                           return retDateTime;
                           }
                           #endregion
                ";
                break;
            case 8:
                setStr += @"                           #region " + txt_func_name.Text.Trim() + @"
                           public static DateTime " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           comm.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           /// create a new parameter
                           DbParameter " + CreateFuncParam(strArray, 0) + @"
                           // return the result table
                           gda.ExecuteNonQuery(comm);
                           }
                           #endregion
                ";
                break;
        }

        return setStr;
    }
    #endregion

    #region CreateFuncParam
    public string CreateFuncParam(String[] strArray, int ObjType)
    {
        String setStr = "";
        int rows = 0;
        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');
                String Param = strParam[1]; // Param
                String ParamType = strParam[2].ToLower(); // ParamType

                // Start
                setStr += @"                    param = comm.CreateParameter();
                    param.ParameterName = ""@" + Param.Trim() + @""";
                    param.Value = " + (ObjType == 1 ? "obj." + Param : Param) + @";";

                // Middle
                if (ParamType.Contains("date"))
                {
                    setStr += @"
                    param.DbType = DbType.DateTime;";
                }
                else if (ParamType.Contains("int"))
                {
                    setStr += @"
                    param.DbType = DbType.Int32;";
                }
                else if (ParamType.Contains("varchar"))
                {
                    setStr += @"
                    param.DbType = DbType.String;";
                }
                else if (ParamType.Contains("decimal"))
                {
                    setStr += @"
                    param.DbType = DbType.Double;";
                }

                // End
                setStr += @"
                    comm.Parameters.Add(param); 

";
            }
            rows++;
        }
        return setStr;
    }
    #endregion

    #region CreateParamByValue
    public string CreateParamByValue(String[] strArray)
    {
        String setStr = "";
        int rows = 0;
        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');
                String Param = strParam[1]; // Param
                String ParamType = strParam[2].ToLower(); // ParamType
                if (ParamType.Contains("date"))
                {
                    setStr += ",DateTime " + Param;
                }
                else if (ParamType.Contains("int"))
                {
                    setStr += ",Int32 " + Param;
                }
                else if (ParamType.Contains("varchar"))
                {
                    setStr += ",String " + Param;
                }
                else if (ParamType.Contains("decimal"))
                {
                    setStr += ",Double " + Param;
                }

            }
            rows++;
        }
        return setStr.Remove(0, 1);
    }
    #endregion

    // Export
    #region btn_get_col_Click
    protected void btn_get_col_Click(object sender, EventArgs e)
    {
        ErrorMsg.Text = "";
        String str = txt_str.Text;
        if (str.Length > 0)
        {
            try
            {
                string[] strArray = str.Split('\n');
                String Sp_Name = strArray[0].Split('[')[2].Replace(']', ' ').Trim();
                DataTable dt_Item = db_my_functions.getColumns_from_table(Constring, Sp_Name, strArray);

                if (dt_Item.Columns.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ebd_name");
                    dt.Columns.Add("ebd_value");
                    foreach (DataColumn col_name in dt_Item.Columns)
                    {
                        dt.Rows.Add(col_name.ColumnName.ToString(), col_name.ColumnName.ToString());
                    }
                    chk_columns.DataSource = dt;
                    chk_columns.DataTextField = "ebd_name";
                    chk_columns.DataValueField = "ebd_value";
                    chk_columns.DataBind();
                }
                div_NEW.Visible = true;
            }
            catch
            {
                ErrorMsg.Text = "INVALID ALTER PARAM SCRIPT";
            }
        }
        else
        {
            ErrorMsg.Text = "Please Enter ALTER PARAM SCRIPT";
        }
    }
    #endregion

    #region btn_Export_Click
    protected void btn_Export_Click(object sender, EventArgs e)
    {
        ErrorMsg.Text = "";
        if (txt_dt_name.Text.Trim().Length > 0)
        {
            GenerateLog();
            string chk_column = "";
            Int32 chk_count = 0;
            foreach (ListItem li in chk_columns.Items)
            {
                if (li.Selected)
                {
                    chk_column += li.Value + "$";
                    chk_count++;
                }
            }
            if (chk_count > 0)
            {
                txt_Export_STr.Text = CreateExportExcelString(chk_column);
            }
            else
            {
                ErrorMsg.Text = "Please Enter At Least One Column";
            }
        }
        else
        {
            ErrorMsg.Text = "Please Enter Function Name";
        }
    }
    #endregion

    #region CreateExportExcelString
    public string CreateExportExcelString(String chk_column)
    {
        String FAspx = "";
        int rows = 0;
        String Param = "";
        String ParamType = "";
        String Fun_Param = "";

        String[] chk_column_arr = chk_column.Split('$');
        String str = txt_str.Text;
        string[] strArray = str.Split('\n');

        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');

                Param += "," + strParam[1]; // Param
            }
            rows++;
        }

        FAspx += @" int TotalColumn = " + (chk_column_arr.Length - 1) + @";
                    string ReportName = ""ReportName"";
        DataTable com = db_Company.Get_company_data_ByComId(Handle.ToInt32(Session[""comp_id""]));
        DataTable dt = new DataTable(); 

        //dt = " + txt_dt_name.Text.Trim() + "(" + Param.Remove(0, 1) + "); ";

        FAspx += @"
    if (dt.Rows.Count > 0)
        {
            var row = 1;
            int column = 1;
            int sr_no = 1;
            using (ExcelPackage pck = new ExcelPackage())
            {

                Response.ClearContent();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(ReportName);
                column = 1;
                ws.OutLineApplyStyle = true;
                ws.Cells[row, column, row, column].Value = Handle.ToString(com.Rows[0][""com_name""]);
                ws.Cells[row, column, row, column].Style.Font.Bold = true;
                ws.Cells[row, column, row, column].Style.Font.Size = 14;
                ws.Cells[row, column, row, TotalColumn].Merge = true;
                ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                row += 1;
        
                ws.Cells[row, column, row, column].Value = Handle.ToString(com.Rows[0][""full_address""]);
                ws.Cells[row, column, row, column].Style.Font.Size = 12;
                ws.Cells[row, column, row, TotalColumn].Merge = true;
                ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                row += 1;


                ws.Cells[row, column, row, column].Value = ReportName;
                ws.Cells[row, column, row, column].Style.Font.Size = 12;
                ws.Cells[row, column, row, TotalColumn].Merge = true;
                ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                row += 1;

                column = 1;
                ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[row, column, row, TotalColumn].Merge = true;
                row++;
";
        int row = chk_column_arr.Length;
        int row_compare = 1;
        foreach (String str_name in chk_column_arr)
        {
            if (row_compare != row)
            {
                FAspx += @"
                ws.Cells[row, column, row, column].Value = """ + str_name.Trim() + "\"; column++;";
            }
            row_compare++;
        }
        FAspx += @"
                row++;
           
                foreach (DataRow dr in dt.Rows)
                {
                    column = 1;";
        row_compare = 1;
        foreach (String str_name in chk_column_arr)
        {
            if (row_compare != row)
            {
                FAspx += @"
                ws.Cells[row, column, row, column].Value = dr[""" + str_name.Trim() + "\"]; column++;";
            }
            row_compare++;
        }
        FAspx += @"
                    row++;
                }";
        FAspx += @"
                    row--;
                ws.Cells[5, 1, row, TotalColumn].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[5, 1, row, TotalColumn].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[5, 1, row, TotalColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[5, 1, row, TotalColumn].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells.AutoFitColumns();
                string file_name = ReportName;
                this.Response.ContentType = ""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"";
                this.Response.AddHeader(""content-disposition"", string.Format(""attachment;  filename={0}"", file_name + "".xlsx""));
                this.Response.BinaryWrite(pck.GetAsByteArray());
                this.Response.Flush();
                this.Response.End();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), ""alert"", ""alert('Record Not Found'); "", true);
        }
        ";
        return FAspx;
    }
    #endregion

    #region chk_columns_SelectedIndexChanged
    protected void chk_columns_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt_grp = new DataTable();
        dt_grp.Columns.Add("col_name");
        dt_grp.Columns.Add("txt_chk_value");

        foreach (ListItem li in chk_columns.Items)
        {
            if (li.Selected)
            {
                dt_grp.Rows.Add(li.Value);
            }
        }
        Repeater1.DataSource = dt_grp;
        Repeater1.DataBind();
        btn_grp_Export.Visible = true;
    }
    #endregion

    #region btn_grp_Export_Click
    protected void btn_grp_Export_Click(object sender, EventArgs e)
    {
        string chk_column = "";
        ErrorMsg.Text = "";
        if (txt_dt_name.Text.Trim().Length > 0)
        {

            foreach (RepeaterItem rept in Repeater1.Items)
                chk_column += "$" + ((Label)rept.FindControl("lbl_col_name")).Text;

            txt_Export_STr.Text = CreateExportExcelStringWithAll(chk_column.Remove(0, 1));
        }
        else
        {
            ErrorMsg.Text = "Please Enter Function Name";
        }

    }
    #endregion

    #region CreateExportExcelString
    public string CreateExportExcelStringWithAll(String chk_column)
    {
        String FAspx = "";
        String[] ret_STR = CreatePrintColumns();
        int rows = 0;
        String Param = "";

        String[] chk_column_arr = chk_column.Split('$');
        String str = txt_str.Text;
        string[] strArray = str.Split('\n');

        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');

                Param += "," + strParam[1]; // Param
            }
            rows++;
        }

        FAspx += @" int TotalColumn = " + (chk_column_arr.Length - 1) + @";
                            string ReportName = ""ReportName"";
                DataTable com = db_Company.Get_company_data_ByComId(Handle.ToInt32(Session[""comp_id""]));
                DataTable dt = new DataTable(); 

                //dt = " + txt_dt_name.Text.Trim() + "(" + Param.Remove(0, 1) + "); ";

        FAspx += @"
            if (dt.Rows.Count > 0)
                {
                    var row = 1;
                    int column = 1;
                    int sr_no = 1;
                    using (ExcelPackage pck = new ExcelPackage())
                    {

                        Response.ClearContent();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(ReportName);
                        column = 1;
                        ws.OutLineApplyStyle = true;
                        ws.Cells[row, column, row, column].Value = Handle.ToString(com.Rows[0][""com_name""]);
                        ws.Cells[row, column, row, column].Style.Font.Bold = true;
                        ws.Cells[row, column, row, column].Style.Font.Size = 14;
                        ws.Cells[row, column, row, TotalColumn].Merge = true;
                        ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row += 1;

                        ws.Cells[row, column, row, column].Value = Handle.ToString(com.Rows[0][""full_address""]);
                        ws.Cells[row, column, row, column].Style.Font.Size = 12;
                        ws.Cells[row, column, row, TotalColumn].Merge = true;
                        ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row += 1;


                        ws.Cells[row, column, row, column].Value = ReportName;
                        ws.Cells[row, column, row, column].Style.Font.Size = 12;
                        ws.Cells[row, column, row, TotalColumn].Merge = true;
                        ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row += 1;

                        column = 1;
                        ws.Cells[row, column, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[row, column, row, TotalColumn].Merge = true;
                        row++;
        ";
        foreach (RepeaterItem rept in Repeater1.Items)
        {
            String col_name = ((Label)rept.FindControl("lbl_col_name")).Text;
            FAspx += @"
                        ws.Cells[row, column, row, column].Value = """ + col_name.Trim() + "\"; column++;";
        }
        FAspx += @"
                        row++;

                        " + Ret_str_variable + @"

                        foreach (DataRow dr in dt.Rows)
                        {
                            column = 1;

                            " + ret_STR[0] + ret_STR[1] + @"

                            row++;
                        }";
        FAspx += @"
                            row--;
                        ws.Cells[5, 1, row, TotalColumn].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        ws.Cells[5, 1, row, TotalColumn].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ws.Cells[5, 1, row, TotalColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        ws.Cells[5, 1, row, TotalColumn].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        ws.Cells.AutoFitColumns();
                        string file_name = ReportName;
                        this.Response.ContentType = ""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"";
                        this.Response.AddHeader(""content-disposition"", string.Format(""attachment;  filename={0}"", file_name + "".xlsx""));
                        this.Response.BinaryWrite(pck.GetAsByteArray());
                        this.Response.Flush();
                        this.Response.End();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), ""alert"", ""alert('Record Not Found'); "", true);
                }
                ";
        return FAspx;
    }
    #endregion

    #region CreatePrintColumns
    public string[] CreatePrintColumns()
    {
        String FAspx = "";
        string[] Array2 = new string[2];
        String txt_chk_value = "";
        foreach (RepeaterItem rept in Repeater1.Items)
        {
            Boolean chk_Group = ((CheckBox)rept.FindControl("chk_Group")).Checked;
            if (chk_Group == true)
            {
                txt_chk_value += "$" + Handle.ToString(((TextBox)rept.FindControl("txt_chk_value")).Text);
            }
        }
        String[] chk_value = txt_chk_value.Remove(0, 1).Split('$').Distinct().ToArray();
        Array.Sort(chk_value);
        int count = 1;
        String Last_Str = "";
        foreach (String array in chk_value)
        {
            if (count == 1)
            {
                FAspx = getGroupString(Handle.ToInt32(array), chk_value);
            }
            count++;
            Last_Str += @"}
";
        }
        Array2[1] = Last_Str;
        Array2[0] = FAspx;
        return Array2;
    }
    #endregion

    #region getGroupString
    public string getGroupString(Int32 Value, String[] chk_value)
    {
        String col_names = "";

        if (chk_value.Contains(Handle.ToString(Value)))
        {
            foreach (RepeaterItem rept in Repeater1.Items)
            {
                String col_name = Handle.ToString(((Label)rept.FindControl("lbl_col_name")).Text);
                if (Handle.ToInt32(((TextBox)rept.FindControl("txt_chk_value")).Text) == Value)
                {
                    col_names += "$" + col_name;
                }
            }
        }
        else
        {
            return Ret_str;
        }
        String[] condition = col_names.Split('$');
        int count = 1;
        if (col_names.Length > 0)
        {
            Ret_str += @"if (";
            foreach (String str in condition)
            {
                if (count != 1)
                {
                    if (count == condition.Length)
                    {
                        Ret_str += @"Handle.ToString(dr[""" + str + @"""]) != " + str.Replace(' ', '_');
                    }
                    else
                    {
                        Ret_str += @"Handle.ToString(dr[""" + str + @"""]) != " + str.Replace(' ', '_') + "&&";
                    }
                    Ret_str_variable += @"String " + str.Replace(' ', '_') + @" = """";
";
                }
                count++;
            }
            Ret_str += @")
{";
            Ret_str += @"       ws.Cells[row, 1, row, TotalColumn].Merge = true;
                                    ws.Cells[row, 1, row, TotalColumn].Value = ""        "" + dr[""" + condition[0] + @"""];
                            row++;";
            foreach (String str in condition)
            {
                Ret_str += @"                " + str.Replace(' ', '_') + @" = Handle.ToString(dr[""" + str + @"""]); 
";
            }
        }
        getGroupString(Value + 1, chk_value);
        return Ret_str;
    }
    #endregion

    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Handle.ToInt32(grid.SelectedValue) == 1)
        {
            div_print_page.Visible = true;
            div_function.Visible = false;
            div_excel_export.Visible = false;
            div_function_urp.Visible = false;
            divFornewParamSP.Visible = false;
        }
        if (Handle.ToInt32(grid.SelectedValue) == 2)
        {

            div_print_page.Visible = false;
            div_function.Visible = true;
            div_excel_export.Visible = false;
            div_function_urp.Visible = false;
            divFornewParamSP.Visible = false;
        }
        if (Handle.ToInt32(grid.SelectedValue) == 3)
        {

            div_print_page.Visible = false;
            div_function.Visible = false;
            div_excel_export.Visible = true;
            div_function_urp.Visible = false;
            divFornewParamSP.Visible = false;
        }
        if (Handle.ToInt32(grid.SelectedValue) == 4)
        {

            div_print_page.Visible = false;
            div_function_urp.Visible = true;
            div_function.Visible = false;
            div_excel_export.Visible = false;
            divFornewParamSP.Visible = false;
        }
        if (Handle.ToInt32(grid.SelectedValue) == 5)
        {

            div_print_page.Visible = false;
            div_function_urp.Visible = false;
            div_function.Visible = false;
            div_excel_export.Visible = false;
            divFornewParamSP.Visible = true;
        }
    }

    protected void Create_Func_URP_Click(object sender, EventArgs e)
    {
        ErrorMsg.Text = "";
        GenerateLog();
        String str = TextBox2_urp.Text.Trim();
        String Function = "";
        string[] strArray = str.Split('\n');
        String func_name = txt_func_name_urp.Text.Trim();
        int func_type = Handle.ToInt32(ddl_func_type_urp.SelectedValue);
        if (func_type > 0)
        {
            if (func_name.Length > 0)
            {
                if (str.Length > 0)
                {
                    Function = CreateFunc_URP(func_type, strArray);
                    TextBox1_urp.Text = Function;
                }
                else
                {
                    ErrorMsg.Text = "Please Enter ALTER PARAM SCRIPT";
                }
            }
            else
            {
                ErrorMsg.Text = "Please Enter Function Name";
            }
        }
        else
        {
            ErrorMsg.Text = "Please Select Function Type";
        }

    }

    #region CreateFunc
    public string CreateFunc_URP(Int32 func_type, String[] strArray)
    {
        String setStr = "";
        String strStatic = @"
                             SqlCommand cmd = new SqlCommand();
                             CreateParameter para = new CreateParameter();";
        switch (func_type)
        {
            case 1:
                setStr = @"                           public static int  " + txt_func_name_urp.Text.Trim() + @"(" + "PROP_FILE_NAME" + @" obj)
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                            " + CreateFuncParam_URP(strArray, 1) + @"
                           cmd.Parameters.Add(para.IntOutputPara(""@out_id""));
                           DataTable dt = CreateCommand.ExecuteQuery(cmd);
                           return Handle.ToInt32(cmd.Parameters[""@out_id""].Value);
                        }
                        ";
                break;
            case 2:
                setStr += @"                           public static DataTable " + txt_func_name_urp.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                            " + CreateFuncParam_URP(strArray, 0) + @"
                           DataTable dt = CreateCommand.ExecuteQuery(cmd);
                           return dt;
                           }
                ";
                break;
            case 3:
                setStr += @"                           public static DataSet " + txt_func_name_urp.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                            " + CreateFuncParam_URP(strArray, 0) + @"
                           return CreateCommand.ExecuteQueryDS(cmd);
                           }
                ";
                break;
            case 4:
                setStr += @"                           public static string " + txt_func_name_urp.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           
                            " + CreateFuncParam_URP(strArray, 0) + @"
                           string retval = CreateCommand.NonExecuteQuery(cmd);
                          return retval;
                           }
                ";
                break;
            case 5:
                setStr += @"                           public static Boolean " + txt_func_name_urp.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           
                            " + CreateFuncParam_URP(strArray, 0) + @"
                           int retval = CreateCommand.NonExecuteQuery(cmd);

                           if (retval > 0)
                                return true;
                           else
                                return false;
                ";
                break;
            case 6:
                setStr += @"                           public static int " + txt_func_name_urp.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                           {
                           " + strStatic + @"
                           cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";
                           
                            " + CreateFuncParam_URP(strArray, 0) + @"
                           // return the result table
                           string retval = CreateCommand.NonExecuteQuery(cmd);
                           return retval;
                           }
                ";
                break;
                //case 7:
                //    setStr += @"                           public static DateTime " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                //               {
                //               " + strStatic + @"
                //               cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";

                //                " + CreateFuncParam_URP(strArray, 0) + @"
                //               // return the result table
                //               int retDateTime = Handle.DateTime(gda.ExecuteScalar(comm));
                //               return retDateTime;
                //               }
                //    ";
                //    break;
                //case 8:
                //    setStr += @"                           public static DateTime " + txt_func_name.Text.Trim() + "(" + CreateParamByValue(strArray) + @")
                //               {
                //               " + strStatic + @"
                //               cmd.CommandText = """ + strArray[0].Split('[')[2].Replace(']', ' ').Trim() + @""";

                //                " + CreateFuncParam_URP(strArray, 0) + @"
                //               // return the result table
                //               gda.ExecuteNonQuery(comm);
                //               }
                //    ";
                //    break;
        }

        return setStr;
    }
    #endregion

    #region CreateFuncParam_URP
    public string CreateFuncParam_URP(String[] strArray, int ObjType)
    {
        String setStr = "";
        int rows = 0;
        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');
                String Param = strParam[1]; // Param
                String ParamType = strParam[2].ToLower(); // ParamType

                // Start
                if (Param != "out_id" && ObjType == 1)
                {
                    if (ParamType.Contains("date"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", obj." + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("int"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.IntInputPara(""@" + Param.Trim() + @"""" + @", obj." + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("varchar"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", obj." + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("decimal"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", obj." + Param.Trim() + @"));";
                    }
                    else
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", obj." + Param.Trim() + @"));";
                    }

                }
                else if (ObjType == 0)
                {
                    // Middle
                    if (ParamType.Contains("date"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", " + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("int"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.IntInputPara(""@" + Param.Trim() + @"""" + @", " + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("varchar"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", " + Param.Trim() + @"));";
                    }
                    else if (ParamType.Contains("decimal"))
                    {
                        setStr += @"
                    cmd.Parameters.Add(para.StringInputPara(""@" + Param.Trim() + @"""" + @", " + Param.Trim() + @"));";
                    }

                }

            }
            rows++;
        }
        return setStr;
    }
    #endregion


    public void GenerateLog()
    {
        StringBuilder strLog = new StringBuilder();
        strLog.AppendLine("#############################Log##############################");
        strLog.AppendLine();
        strLog.AppendLine("Host IP:" + db_my_functions.GetIp());
        strLog.AppendLine("");
        strLog.AppendLine("Type:" + grid.SelectedItem.Text);
        strLog.AppendLine();
        strLog.AppendLine("Page Name:" + txt_file_name.Text);
        strLog.AppendLine();
        strLog.AppendLine("Function Type iERP:" + ddl_func_type.SelectedItem.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("Function Name iERP:" + txt_func_name.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("SP String iERP:" + TextBox2.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("Function Type URP:" + ddl_func_type_urp.SelectedItem.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("Function Name URP:" + txt_func_name_urp.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("SP String URP:" + TextBox2_urp.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("Excel SP String:" + txt_str.Text.Trim());
        strLog.AppendLine();
        strLog.AppendLine("##############################################################");

        #region Dynamic page use Log File Function
        CreateDynamicPageLogFile(strLog.ToString());
        #endregion
    }


    #region CreateDynamicPageLogFile Function
    public String CreateDynamicPageLogFile(String text)
    {
        string obj_name = grid.SelectedItem.Text + "_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + "_Log";
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

    protected void btnCreateStrings_Click(object sender, EventArgs e)
    {
        ErrorMsg.Text = "";
        if (txt_For_New_Field.Text.Trim().Length > 0)
        {
            String paramsNewFields = txt_For_New_Field.Text.Trim();
            String[] paramsarray = paramsNewFields.Split('@');
            if (paramsarray.Length > 0)
            {
                String Final_String = "/* For Insert */";
                String Declare = "";
                String Column = "";
                String Values = "";
                for (int i = 0; i < paramsarray.Length; i++)
                {
                    if (paramsarray[i].Length > 5)
                    {
                        string[] spech = paramsarray[i].ToString().Trim().Split(' ');
                        if (spech.Length > 0)
                        {
                            String ParamName = "";
                            String ParamType = "";

                            Declare += "\n@" + spech[0].ToString() + " " + spech[1].ToString();
                            Column += "\n" + spech[0].ToString() + ",";
                            Values += "\n@" + spech[0].ToString() + ",";
                        }
                    }
                }

                Final_String += Declare + "\n" + Column + "\n" + Values + "\n";
                Declare = ""; Column = ""; Values = "";

                Final_String += "\n /* For Update */ \n";
                for (int i = 0; i < paramsarray.Length; i++)
                {
                    if (paramsarray[i].Length > 5)
                    {
                        string[] spech = paramsarray[i].ToString().Split(' ');
                        if (spech.Length > 0)
                        {
                            String ParamName = "";
                            String ParamType = "";

                            Declare += "@" + spech[0].ToString() + " " + spech[1].ToString();
                            Values += "\n" + spech[0].ToString() + "=@" + spech[0].ToString() + ",";
                        }
                    }
                }

                Final_String += Declare + "\n" + Values + "\n";
                Declare = ""; Column = ""; Values = "";

                Final_String += "\n /* For Select By Id */";
                for (int i = 0; i < paramsarray.Length; i++)
                {
                    if (paramsarray[i].Length > 5)
                    {
                        string[] spech = paramsarray[i].ToString().Split(' ');
                        if (spech.Length > 0)
                        {
                            String ParamName = "";
                            String ParamType = "";

                            Values += "\n" + spech[0].ToString() + ",";
                        }
                    }
                }


                Final_String += Values + "\n";
                Declare = ""; Column = ""; Values = "";

                Final_String += "\n /* IN DB FUNCTION */\n";
                for (int i = 0; i < paramsarray.Length; i++)
                {
                    if (paramsarray[i].Length > 5)
                    {
                        string[] spech = paramsarray[i].ToString().Split(' ');
                        if (spech.Length > 0)
                        {
                            String ParamName = spech[0].Trim();
                            String ParamType = "";
                            if (spech[1].ToLower().Contains("int"))
                            {
                                ParamType = "Int32";
                            }
                            else if (spech[1].ToLower().Contains("varchar"))
                            {
                                ParamType = "String";
                            }
                            else if (spech[1].ToLower().Contains("decimal"))
                            {
                                ParamType = "Double";
                            }
                            else if (spech[1].ToLower().Contains("date"))
                            {
                                ParamType = "DateTime";
                            }
                            Values += @"param = comm.CreateParameter();
param.ParameterName = """ + ParamName + @""";
param.Value = obj." + ParamName + @";
param.DbType = DbType." + ParamType + @";
comm.Parameters.Add(param);

";
                        }
                    }
                }

                Final_String += Values + "\n";
                Declare = ""; Column = ""; Values = "";

                Final_String += "\n /* IN PROP FILE*/\n";
                for (int i = 0; i < paramsarray.Length; i++)
                {
                    if (paramsarray[i].Length > 5)
                    {
                        string[] spech = paramsarray[i].ToString().Split(' ');
                        if (spech.Length > 0)
                        {
                            String ParamName = spech[0].Trim();
                            String ParamType = "";
                            if (spech[1].ToLower().Contains("int"))
                            {
                                ParamType = "Int32";
                            }
                            else if (spech[1].ToLower().Contains("varchar"))
                            {
                                ParamType = "String";
                            }
                            else if (spech[1].ToLower().Contains("decimal"))
                            {
                                ParamType = "Double";
                            }
                            else if (spech[1].ToLower().Contains("date"))
                            {
                                ParamType = "Nullable<DateTime>";
                            }
                            Values += @"private " + ParamType + @" _" + ParamName + @";
public " + ParamType + @" " + ParamName + @"
{

    get { return _" + ParamName + @"; }
    set { _" + ParamName + @" = value; }
}

";
                        }
                    }
                }

                Final_String += Values + "\n";
                Declare = ""; Column = ""; Values = "";
                GeneratedScripts.Text = Final_String;
            }
            else
            {
                ErrorMsg.Text = "Please Add Correct Params";
            }
        }
        else
        {
            ErrorMsg.Text = "Please Add Params";
        }
    }


    #region ddlProject_SelectedIndexChanged Event
    /// <summary>
    /// this event used to set names of all new items as per selection
    /// </summary>    
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        lblMessage.Text = "";
        try
        {
            dt = db_dynamic_page.GetAllTables(ddlProject.SelectedValue.Split('$')[1]);
        }
        catch
        {
            lblMessage.Text = "Oops, Issue to Connect Database of selected project";
        }
    }
    #endregion

    protected void txt_ierp_sp_name_TextChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        String ObjectName = txt_ierp_sp_name.Text.Trim().Replace("[", "").Replace("]", "");
        String ALTER_STR = db_dynamic_page.GetSPALTER_QUERY(ddlProject.SelectedValue.Split('$')[1], ObjectName);
        if (ALTER_STR.ToLower().Contains("alter procedure"))
        {
            TextBox2.Text = ALTER_STR;
            txt_func_name.Text = ObjectName;
        }
        else
        {
            lblMessage.Text = ALTER_STR;
        }
    }

    protected void txt_urp_sp_name_TextChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        String ObjectName = txt_urp_sp_name.Text.Trim().Replace("[", "").Replace("]", "");
        String ALTER_STR = db_dynamic_page.GetSPALTER_QUERY(ddlProject.SelectedValue.Split('$')[1], ObjectName);
        if (ALTER_STR.ToLower().Contains("alter procedure"))
        {
            TextBox2_urp.Text = ALTER_STR;
            txt_func_name_urp.Text = ObjectName;
        }
        else
        {
            lblMessage.Text = ALTER_STR;
        }
    }
}

