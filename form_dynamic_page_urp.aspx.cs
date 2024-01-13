using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
using System.IO;
using System.Text;
using System.Net;

public partial class form_dynamic_page_urp : COMM_SessionCheck
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {
            // Bind Data
            //BindData();
        }
    }
    #endregion

    #region BindData Function
    /// <summary>
    /// This is BindData function it is use to get all tables
    /// </summary>  
    public void BindData()
    {
        DataTable pdt = db_dynamic_page_urp.GetAllProject();
        if (pdt.Rows.Count > 0)
        {
            ddlProject.DataSource = pdt;
            ddlProject.DataTextField = "prjm_name";
            ddlProject.DataValueField = "constr2";
            ddlProject.DataBind();
        }

    }
    #endregion

    #region btnSave_Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string pathFile = "";
            pathFile = Server.MapPath("~/Upload_v2/") + ddlTable.SelectedItem.Text;

            if (Directory.Exists(pathFile))
            {
                DirectoryInfo directory = new DirectoryInfo(pathFile);
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            Directory.CreateDirectory(pathFile);

            //#region SaveDataToTable

            //PROP_dynamic_form_configuration obj = new PROP_dynamic_form_configuration();
            //obj.dfc_project_id = Handle.ToInt32(ddlProject.SelectedValue.Split('$')[0]);
            //obj.dfc_project_name = ddlProject.SelectedItem.Text;
            //obj.dfc_table_name = ddlTable.SelectedItem.Text;
            //obj.dfc_menu_name = txtMenName.Text;
            //int max_Version = db_dynamic_page_urp.GetMaximumVersion(ddlProject.SelectedItem.Text, ddlTable.SelectedItem.Text);
            //if (max_Version == 0)
            //{
            //    obj.dfc_version = 1;
            //}
            //else
            //{
            //    obj.dfc_version = max_Version + 1;
            //}
            //obj.dfc_order = 0;
            //obj.dfc_action_method = string.Empty;
            //obj.dfc_action_func_name = string.Empty;
            //obj.dfc_action_url = string.Empty;
            //foreach (RepeaterItem ritm in RptField.Items)
            //{
            //    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
            //    obj.dfc_column_name = hfnm.Value;
            //    HiddenField hid_datatype = (HiddenField)ritm.FindControl("hid_datatype"); //Datatype
            //    obj.dfc_column_datatype = hid_datatype.Value;
            //    HiddenField hid_size = (HiddenField)ritm.FindControl("hid_size"); //size
            //    obj.dfc_column_size = Handle.ToInt32(hid_size.Value);
            //    CheckBox chk = (CheckBox)ritm.FindControl("chkRE"); //user entry not req.
            //    obj.dfc_entry_req = Handle.ToInt32(chk.Checked);
            //    CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp"); //is compulsory
            //    obj.dfc_is_compulsory = Handle.ToInt32(chkComp.Checked);
            //    TextBox txtlbl = (TextBox)ritm.FindControl("txtLBL");//label
            //    obj.dfc_column_lable = txtlbl.Text;
            //    DropDownList ddlentry = (DropDownList)ritm.FindControl("ddlControlType");//control name
            //    obj.dfc_column_entry_control = Handle.ToInt32(ddlentry.SelectedValue);
            //    CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN"); //is enum
            //    obj.dfc_column_is_enum = Handle.ToInt32(chkIEN.Checked);
            //    TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal"); //enum value
            //    obj.dfc_enum_Value = txtEnmVal.Text;
            //    CheckBox chkIsExists = (CheckBox)ritm.FindControl("chkIsExists"); //is function exists
            //    obj.dfc_is_function_exist = Handle.ToInt32(chkIsExists.Checked);
            //    TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo"); //Function Info
            //    obj.dfc_function_info = txtFunctionInfo.Text;
            //    TextBox txt = (TextBox)ritm.FindControl("txtLBL"); //label
            //    DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType"); //control generated

            //    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique"); //is unique check
            //    obj.dfc_is_unique_check = Handle.ToInt32(chkUnique.Checked);

            //    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly"); //is insert only
            //    obj.dfc_is_insert_only = Handle.ToInt32(chkInsertOnly.Checked);

            //    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated"); //is auto generated 
            //    obj.dfc_is_auto_generated = Handle.ToInt32(chkAutoGenerated.Checked);

            //    int ret = db_dynamic_page_urp.Insert(obj);
            //    //if (ret > 0)
            //    //{
            //    //    Response.Redirect("form_dynamic_page.aspx");
            //    //}
            //}
            //#endregion

            StringBuilder strLog = new StringBuilder();
            strLog.AppendLine("#############################Log##############################");
            strLog.AppendLine("");
            strLog.AppendLine("Project:" + ddlProject.SelectedItem.Text);
            strLog.AppendLine();
            strLog.AppendLine("Table:" + ddlTable.SelectedItem.Text);
            strLog.AppendLine();
            strLog.AppendLine("Menu Name:" + txtMenName.Text.Trim());
            strLog.AppendLine();
            strLog.AppendLine("Host IP:" + db_my_functions.GetIp());
            strLog.AppendLine();
            strLog.AppendLine();
            ClearChkDecoration();
            //

            string logDbName = "CMS_EXAM_NEW_LOG";
            //try
            //{
            //    logDbName = db_dynamic_page_urp.GetProjectLogDBName(ddlProject.SelectedItem.Text);
            //}
            //catch { logDbName = "infilog_ierp"; }

            //

            #region for create log table
            if (chk_ltbl.Checked == true)
            {

                String str = db_dynamic_page_urp.CreateLogTable(ddlProject.SelectedValue.Split('$')[1], logDbName, ddlTable.SelectedValue);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Log Table: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Database: " + logDbName);
                    strLog.AppendLine("   Table: " + ddlTable.SelectedValue + "_log");

                    chk_ltbl.Attributes.Add("style", "color:green;");
                    chk_ltbl.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Log Table: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_ltbl.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_ltbl.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Log Table: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region for create Synonym of log table
            if (chkSynonym.Checked == true)
            {

                String str = db_dynamic_page_urp.CreateSynonymOfLogTable(ddlProject.SelectedValue.Split('$')[1], logDbName, ddlTable.SelectedValue);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Log Table Synonym: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Synonym: " + ddlTable.SelectedValue + "_log");

                    chkSynonym.Attributes.Add("style", "color:green;");
                    chkSynonym.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Log Table Synonym: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chkSynonym.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chkSynonym.Attributes.Add("title", str);
                }

            }
            else
            {
                strLog.AppendLine("#Create Log Table Synonym: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create trigger
            if (chk_ltgr.Checked == true)
            {
                String str = db_dynamic_page_urp.CreateTrigger(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Trigger: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Trigger: " + ddlTable.SelectedValue.ToString().Replace("i_", "trg_"));

                    chk_ltgr.Attributes.Add("style", "color:green;");
                    chk_ltgr.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Trigger: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_ltgr.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_ltgr.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Trigger: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create insert procedure
            if (chk_spcreate.Checked == true)
            {
                string uniqueCheck = string.Empty;
                string uniqueCheckLabels = string.Empty;
                string InsertOnly = string.Empty;
                string autoGenerated = string.Empty;

                foreach (RepeaterItem ritm in RptField.Items)
                {
                    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
                    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
                    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
                    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
                    TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

                    if (chkUnique.Checked)
                    {
                        uniqueCheck = uniqueCheck + hfnm.Value;
                        if (!string.IsNullOrEmpty(txtLBL.Text))
                        {
                            uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                        }
                    }
                    if (chkInsertOnly.Checked)
                    {
                        InsertOnly = InsertOnly + hfnm.Value + ',';
                    }
                    if (chkAutoGenerated.Checked)
                    {
                        autoGenerated = autoGenerated + hfnm.Value + ',';
                    }



                }

                String str = db_dynamic_page_urp.CreateInsertProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spcreate.Text, uniqueCheck, uniqueCheckLabels, InsertOnly, autoGenerated);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for Insert: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spcreate.Text) ? txt_spcreate.Text : ddlTable.SelectedValue + "_insert"));

                    chk_spcreate.Attributes.Add("style", "color:green;");
                    chk_spcreate.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for Insert: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spcreate.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spcreate.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for Insert: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Delete procedure
            if (chk_spdelete.Checked == true)
            {
                string uniqueCheck = string.Empty;
                string uniqueCheckLabels = string.Empty;
                string InsertOnly = string.Empty;
                string autoGenerated = string.Empty;

                foreach (RepeaterItem ritm in RptField.Items)
                {
                    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
                    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
                    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
                    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
                    TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

                    if (chkUnique.Checked) 
                    {
                        uniqueCheck = uniqueCheck + ',' +  hfnm.Value ;
                        if (!string.IsNullOrEmpty(txtLBL.Text))
                        {
                            uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                        }
                    }
                    if (chkInsertOnly.Checked)
                    {
                        InsertOnly = InsertOnly + ',' +  hfnm.Value;
                    }
                    if (chkAutoGenerated.Checked)
                    {
                        autoGenerated = autoGenerated + ',' +  hfnm.Value;
                    }



                }
                if(uniqueCheck.Length > 0)
                {
                    uniqueCheck = uniqueCheck.Remove(0, 1);
                }
                if (InsertOnly.Length > 0)
                { 
                    InsertOnly = InsertOnly.Remove(0, 1);
                }
                 
                String str = db_dynamic_page_urp.CreateDeleteProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spdelete.Text, InsertOnly, uniqueCheck);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for Delete: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spdelete.Text) ? txt_spdelete.Text : ddlTable.SelectedValue + "_delete"));

                    chk_spdelete.Attributes.Add("style", "color:green;");
                    chk_spdelete.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for Delete: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spdelete.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spdelete.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for Delete: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Select By ID procedure
            if (chk_spselbyid.Checked == true)
            {
                string uniqueCheck = string.Empty;
                string uniqueCheckLabels = string.Empty;
                string InsertOnly = string.Empty;
                string autoGenerated = string.Empty;

                foreach (RepeaterItem ritm in RptField.Items)
                {
                    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
                    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
                    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
                    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
                    TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

                    if (chkUnique.Checked)
                    {
                        uniqueCheck = uniqueCheck + hfnm.Value + ',';
                        if (!string.IsNullOrEmpty(txtLBL.Text))
                        {
                            uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                        }
                    }
                    if (chkInsertOnly.Checked)
                    {
                        InsertOnly = InsertOnly + hfnm.Value + ',';
                    }
                    if (chkAutoGenerated.Checked)
                    {
                        autoGenerated = autoGenerated + hfnm.Value + ',';
                    }



                }

                String str = db_dynamic_page_urp.CreateSelectByIDProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spselbyid.Text, InsertOnly, autoGenerated);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for select by id: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spselbyid.Text) ? txt_spselbyid.Text : ddlTable.SelectedValue + "_selectby_id"));

                    chk_spselbyid.Attributes.Add("style", "color:green;");
                    chk_spselbyid.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for select by id: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spselbyid.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spselbyid.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for select by id: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Select procedure
            if (chk_spsellist.Checked == true)
            {
                String str = db_dynamic_page_urp.CreateSelectProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spsellist.Text);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for select: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spsellist.Text) ? txt_spsellist.Text : ddlTable.SelectedValue + "_select"));

                    chk_spsellist.Attributes.Add("style", "color:green;");
                    chk_spsellist.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for select: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spsellist.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spsellist.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for select: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Log Select procedure
            if (chk_splogsellist.Checked == true)
            {
                string uniqueCheck = string.Empty;
                string uniqueCheckLabels = string.Empty;
                string InsertOnly = string.Empty;
                string autoGenerated = string.Empty;

                foreach (RepeaterItem ritm in RptField.Items)
                {
                    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
                    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
                    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
                    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
                    TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

                    if (chkUnique.Checked)
                    {
                        uniqueCheck = uniqueCheck + ',' + hfnm.Value;
                        if (!string.IsNullOrEmpty(txtLBL.Text))
                        {
                            uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                        }
                    }
                    if (chkInsertOnly.Checked)
                    {
                        InsertOnly = InsertOnly + ',' + hfnm.Value;
                    }
                    if (chkAutoGenerated.Checked)
                    {
                        autoGenerated = autoGenerated + ',' + hfnm.Value;
                    }



                }
                if (uniqueCheck.Length > 0)
                {
                    uniqueCheck = uniqueCheck.Remove(0, 1);
                }
                if (InsertOnly.Length > 0)
                {
                    InsertOnly = InsertOnly.Remove(0, 1);
                }

                String str = db_dynamic_page_urp.CreateLogSelectProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_splogsellist.Text, uniqueCheck);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for log select: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_splogsellist.Text) ? txt_splogsellist.Text : ddlTable.SelectedValue + "_log_select"));

                    chk_splogsellist.Attributes.Add("style", "color:green;");
                    chk_splogsellist.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for log select: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_splogsellist.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_splogsellist.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for log select: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create PROPERTY file for selected table
            if (chk_fileprop.Checked == true)
            {
                String str = CreateCS(ddlTable.SelectedValue, txt_fileprop.Text, ddlTable.SelectedValue);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create PROPERTY File: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   File: " + (!string.IsNullOrEmpty(txt_fileprop.Text) ? txt_fileprop.Text : "PROP_" + ddlTable.SelectedValue.Replace("i_", "")));

                    chk_fileprop.Attributes.Add("style", "color:green;");
                    chk_fileprop.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create PROPERTY File: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_fileprop.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_fileprop.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create PROPERTY File: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create DB file for selected table
            if (chk_filedb.Checked == true)
            {
                String str = CreateDB(ddlTable.SelectedValue, txt_filedb.Text, ddlTable.SelectedValue);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create DB Function File: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   File: " + (!string.IsNullOrEmpty(txt_filedb.Text) ? txt_filedb.Text : "db_" + ddlTable.SelectedValue.Replace("i_", "")));

                    chk_filedb.Attributes.Add("style", "color:green;");
                    chk_filedb.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create DB Function File: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_filedb.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_filedb.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create DB Function File: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Form file for selected table
            if (chkFormPage.Checked == true)
            {
                String str = CreateFormPage(ddlTable.SelectedValue, txt_formPage.Text);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Form Page File: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   File: " + (!string.IsNullOrEmpty(txt_formPage.Text) ? txt_formPage.Text : ddlTable.SelectedValue.Replace("i_", "form_") + ".aspx"));

                    chkFormPage.Attributes.Add("style", "color:green;");
                    chkFormPage.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Form Page File: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chkFormPage.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chkFormPage.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Form Page File : Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create list file for selected table
            if (chkListPage.Checked == true)
            {
                String str = CreateListPage(ddlTable.SelectedValue, txt_ListPage.Text);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Listing Page File: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   File: " + (!string.IsNullOrEmpty(txt_ListPage.Text) ? txt_ListPage.Text : ddlTable.SelectedValue.Replace("i_", "list_") + ".aspx"));

                    chkListPage.Attributes.Add("style", "color:green;");
                    chkListPage.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Listing Page File: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chkListPage.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chkListPage.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Listing Page File : Not Selected.");
            }
            #endregion

            // Not Usable
            strLog.AppendLine();

            #region create WebMethod file for selected table
            if (chk_spwebmethod.Checked == true)
            {
                String str = CreateWebMethod(ddlTable.SelectedValue, txt_spwebmethod.Text);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Web Method Function File: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   File: " + (!string.IsNullOrEmpty(txt_spwebmethod.Text) ? txt_spwebmethod.Text : "db_" + ddlTable.SelectedValue.Replace("i_", "")));

                    chk_spwebmethod.Attributes.Add("style", "color:green;");
                    chk_spwebmethod.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Web Method Function File: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spwebmethod.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spwebmethod.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Web Method Function File: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Update procedure
            if (chk_spupdate.Checked == true)
            {

                string uniqueCheck = string.Empty;
                string uniqueCheckLabels = string.Empty;
                string InsertOnly = string.Empty;
                string autoGenerated = string.Empty;

                foreach (RepeaterItem ritm in RptField.Items)
                {
                    HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
                    CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
                    CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
                    CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
                    TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

                    if (chkUnique.Checked)
                    {
                        uniqueCheck = uniqueCheck + hfnm.Value + ',';
                        if (!string.IsNullOrEmpty(txtLBL.Text))
                        {
                            uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                        }
                    }
                    if (chkInsertOnly.Checked)
                    {
                        InsertOnly = InsertOnly + hfnm.Value + ',';
                    }
                    if (chkAutoGenerated.Checked)
                    {
                        autoGenerated = autoGenerated + hfnm.Value + ',';
                    }



                }


                String str = db_dynamic_page_urp.CreateUpdateProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spupdate.Text, uniqueCheck, uniqueCheckLabels, InsertOnly, autoGenerated);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for Update: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spupdate.Text) ? txt_spupdate.Text : ddlTable.SelectedValue + "_update"));

                    chk_spupdate.Attributes.Add("style", "color:green;");
                    chk_spupdate.Attributes.Add("title", str);
                }
                else
                {

                    strLog.AppendLine("#Create Procedure for Update: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spupdate.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spupdate.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for Update: Not Selected.");
            }
            #endregion

            strLog.AppendLine();

            #region create Deleted Log Select procedure
            if (chk_spdellogsellist.Checked == true)
            {
                String str = db_dynamic_page_urp.CreateDeletedLogSelectProcedure(ddlProject.SelectedValue.Split('$')[1], ddlTable.SelectedValue, txt_spdellogsellist.Text);
                if (str == "Operation Successfully")
                {
                    strLog.AppendLine("#Create Procedure for deleted log select: Operation successfully completed on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Stored Procedure: " + (!string.IsNullOrEmpty(txt_spdellogsellist.Text) ? txt_spdellogsellist.Text : ddlTable.SelectedValue + "_del_log_select"));

                    chk_spdellogsellist.Attributes.Add("style", "color:green;");
                    chk_spdellogsellist.Attributes.Add("title", str);
                }
                else
                {
                    strLog.AppendLine("#Create Procedure for deleted log select: Error on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                    strLog.AppendLine("   Error: " + str);

                    chk_spdellogsellist.Attributes.Add("style", "color:red;text-decoration: blink;");
                    chk_spdellogsellist.Attributes.Add("title", str);
                }
            }
            else
            {
                strLog.AppendLine("#Create Procedure for deleted log select: Not Selected.");
            }
            #endregion
            // Not Usable
            strLog.AppendLine();
            strLog.Append(FieldLog().ToString()); //Append Field Information
            strLog.AppendLine();
            strLog.AppendLine("##############################################################");

            #region Dynamic page use Log File Function
            CreateDynamicPageLogFile(strLog.ToString());
            #endregion

            Clear();
        }

    }
    #endregion

    #region FieldLog
    public StringBuilder FieldLog()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("***********************Field Log*****************************");
        sb.AppendLine();
        foreach (RepeaterItem ritm in RptField.Items)
        {
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
            HiddenField hid_datatype = (HiddenField)ritm.FindControl("hid_datatype"); //Datatype
            HiddenField hid_size = (HiddenField)ritm.FindControl("hid_size"); //size

            CheckBox chk = (CheckBox)ritm.FindControl("chkRE"); //user entry not req.
            CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp"); //is compulsory
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN"); //is enum
            TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal"); //enum value
            TextBox txt = (TextBox)ritm.FindControl("txtLBL"); //label

            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType"); //control generated
            CheckBox chkIsExists = (CheckBox)ritm.FindControl("chkIsExists"); //is function exists
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo"); //Function Info

            sb.AppendLine();
            sb.AppendLine("Field #: " + (ritm.ItemIndex + 1).ToString());
            sb.AppendLine("       Field Name: " + hfnm.Value);
            sb.AppendLine("       Field Data Type: " + hid_datatype.Value + " (" + hid_size.Value + ")");
            sb.AppendLine("       User Entry Not Required?: " + (chk.Checked == true ? "YES" : "NO"));
            sb.AppendLine("       is Compulsory?: " + (chkComp.Checked == true ? "YES" : "NO"));
            sb.AppendLine("       Is Enum?: " + (chkIEN.Checked == true ? "YES (ENUM VALUES: " + txtEnmVal.Text + ")" : "NO"));
            sb.AppendLine("       Label: " + txt.Text);
            sb.AppendLine("       Entry Control: " + ddl.SelectedItem.Text);
            sb.AppendLine("       Is Function Exists?: " + (chkIsExists.Checked == true ? "YES (FUNCTION INFO.: " + txtFunctionInfo.Text + ")" : "NO"));


        }
        sb.AppendLine();
        sb.AppendLine("**************************************************************");
        return sb;
    }
    #endregion

    #region FieldExcelSheetCreate
    public void FieldExcelSheetCreate()
    {

        foreach (RepeaterItem ritm in RptField.Items)
        {
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
            HiddenField hid_datatype = (HiddenField)ritm.FindControl("hid_datatype"); //Datatype
            HiddenField hid_size = (HiddenField)ritm.FindControl("hid_size"); //size

            CheckBox chk = (CheckBox)ritm.FindControl("chkRE"); //user entry not req.
            CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp"); //is compulsory
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN"); //is enum
            TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal"); //enum value
            TextBox txt = (TextBox)ritm.FindControl("txtLBL"); //label

            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType"); //control generated
            CheckBox chkIsExists = (CheckBox)ritm.FindControl("chkIsExists"); //is function exists
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo"); //Function Info



            //sb.AppendLine();
            //sb.AppendLine("Field #: " + (ritm.ItemIndex + 1).ToString());
            //sb.AppendLine("       Field Name: " + hfnm.Value);
            //sb.AppendLine("       Field Data Type: " + hid_datatype.Value + " (" + hid_size.Value + ")");
            //sb.AppendLine("       User Entry Not Required?: " + (chk.Checked == true ? "YES" : "NO"));
            //sb.AppendLine("       is Compulsory?: " + (chkComp.Checked == true ? "YES" : "NO"));
            //sb.AppendLine("       Is Enum?: " + (chkIEN.Checked == true ? "YES (ENUM VALUES: " + txtEnmVal.Text + ")" : "NO"));
            //sb.AppendLine("       Label: " + txt.Text);
            //sb.AppendLine("       Entry Control: " + ddl.SelectedItem.Text);
            //sb.AppendLine("       Is Function Exists?: " + (chkIsExists.Checked == true ? "YES (FUNCTION INFO.: " + txtFunctionInfo.Text + ")" : "NO"));


        }

    }
    #endregion

    #region for uncheck all check boxes
    /// <summary>
    /// clear all selected check boxes
    /// </summary>
    public void Clear()
    {
        chk_ltbl.Checked = false;
        chk_ltgr.Checked = false;
        chkSynonym.Checked = false;
        chk_spcreate.Checked = false;
        chk_spdelete.Checked = false;
        chk_spupdate.Checked = false;
        chk_spselbyid.Checked = false;
        chk_spselall.Checked = false;
        chk_spsellist.Checked = false;
        chk_splogsellist.Checked = false;
        chk_spdellogsellist.Checked = false;
        chk_fileprop.Checked = false;
        chk_filedb.Checked = false;
        chkFormPage.Checked = false;
        chkListPage.Checked = false;

    }
    #endregion

    #region ClearText Function
    /// <summary>
    /// this function is used to clear all textboxes
    /// </summary>
    public void ClearText()
    {
        txt_spcreate.Text = "";
        txt_spwebmethod.Text = "";
        txt_spdelete.Text = "";
        txt_spupdate.Text = "";
        txt_spselbyid.Text = "";
        txt_spselall.Text = "";
        txt_spsellist.Text = "";
        txt_splogsellist.Text = "";
        txt_spdellogsellist.Text = "";
        txt_fileprop.Text = "";
        txt_filedb.Text = "";
        txt_formPage.Text = "";
        txt_ListPage.Text = "";
    }
    #endregion

    #region ClearChkDecoration Function
    /// <summary>
    /// this function is used to clear all check boxes decoration
    /// </summary>
    public void ClearChkDecoration()
    {
        chk_ltbl.Attributes.Remove("style");
        chk_ltbl.Attributes.Remove("title");

        chkSynonym.Attributes.Remove("style");
        chkSynonym.Attributes.Remove("title");

        chk_ltgr.Attributes.Remove("style");
        chk_ltgr.Attributes.Remove("title");

        chk_spcreate.Attributes.Remove("style");
        chk_spcreate.Attributes.Remove("title");

        chk_spdelete.Attributes.Remove("style");
        chk_spdelete.Attributes.Remove("title");

        chk_spupdate.Attributes.Remove("style");
        chk_spupdate.Attributes.Remove("title");

        chk_spselbyid.Attributes.Remove("style");
        chk_spselbyid.Attributes.Remove("title");

        chk_spselall.Attributes.Remove("style");
        chk_spselall.Attributes.Remove("title");

        chk_spsellist.Attributes.Remove("style");
        chk_spsellist.Attributes.Remove("title");

        chk_splogsellist.Attributes.Remove("style");
        chk_splogsellist.Attributes.Remove("title");

        chk_spdellogsellist.Attributes.Remove("style");
        chk_spdellogsellist.Attributes.Remove("title");

        chk_fileprop.Attributes.Remove("style");
        chk_fileprop.Attributes.Remove("title");

        chk_filedb.Attributes.Remove("style");
        chk_filedb.Attributes.Remove("title");

    }
    #endregion

    #region function for create property file
    public String CreateCS(String tbl_name, String obj_name, String fileFolder)
    {
        obj_name = (obj_name == "" ? "PROP_" + tbl_name.Replace("i_", "") : obj_name);
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string filepath = string.Empty;
            //if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "PROP" + "\\"))
            //{
            //    DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "PROP" + "\\");
            //    thisFolder1.Create();
            //}
            //filepath = root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "PROP" + "\\" + obj_name + ".cs";


            //string SaveFilePath = root + "\\SystemGeneratePages"+"\\"+"DAL"+"\\"+"PROP"+"\\"+ obj_name + ".cs";
            if (File.Exists(filepath))
            {
                ret = "File Name " + obj_name + " already exist!";
            }
            else
            {
                StreamWriter sw = null;
                try
                {//write content
                    filepath = Server.MapPath("~/Upload_v2/") + "\\" + fileFolder + "\\" + "\\" + obj_name + ".cs";
                    FileStream fsSave = File.Create(filepath);
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreatePropCsString(tbl_name, obj_name));
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

    #region Create String Property file
    public String CreatePropCsString(String tbl_name, String obj_name)
    {
        String Propfl = String.Format(@"
//This file is programmatically generated
using System;
/// <summary>
/// this {0} Class Contain all the parameters
/// </summary>
public class {0}
{{
    public {0}()
	{{
		//
		// TODO: Add constructor logic here
		//
	}}", obj_name);

        DataTable dt = db_dynamic_page_urp.GetColumnsByTable(tbl_name, ddlProject.SelectedValue.Split('$')[1]);
        foreach (DataRow drw in dt.Rows)
        {
            Propfl += string.Format(@"
    private {0} _{1};
    public {0} {1}
    {{

        get {{ return _{1}; }}
        set {{ _{1} = value; }}
    }}
", drw["datatype"], drw["name"]);
        }
        Propfl += "}";
        return Propfl;
    }
    #endregion

    #region function for create DB file
    public String CreateDB(String tbl_name, String obj_name, String fileFolder)
    {
        obj_name = (obj_name == "" ? "db_" + tbl_name.Replace("i_", "") : obj_name);
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string filepath = string.Empty;
            //if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "DB_Pages" + "\\"))
            //{
            //    DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "DB_Pages" + "\\");
            //    thisFolder1.Create();
            //}
            //filepath = root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + "DAL" + "\\" + "Db_Pages" + "\\" + obj_name + ".cs";


            //string SaveFilePath = root + "\\SystemGeneratePages"+"\\"+"DAL"+"\\"+"DB_Pages"+"\\"+ obj_name + ".cs";
            if (File.Exists(filepath))
            {
                ret = "File Name " + obj_name + " already exist!";
            }
            else
            {
                StreamWriter sw = null;
                try
                {//write content
                    filepath = Server.MapPath("~/Upload_v2/") + "\\" + fileFolder + "\\" + "\\" + obj_name + ".cs";
                    FileStream fsSave = File.Create(filepath);
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreateDBCsString(tbl_name, obj_name));
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

    #region Create String for DB file
    public String CreateDBCsString(String tbl_name, String obj_name)
    {
        String Propfl = @"
//This file is generated programmatically
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
//using System.Configuration;
//using System.Linq;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
//using System.Data.Common;
//using infinity;

/// <summary>
/// Summary description for {0}
/// </summary>
public class {0}
{{

     #region Get{1}_select Function
    /// <summary>
    /// This function use to get all {15} table data.
    /// </summary>
    /// <returns>This function is return all {15} data table</returns>
    public static DataTable Get{1}_select(Int32 institute_id)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = """ + txt_spsellist.Text + @""";
        cmd.Parameters.Add(para.IntInputPara(""@institute_id"", institute_id));
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }}
    #endregion

    #region Get{1}Log Function
    /// <summary>
    /// This function is used to get log of {1} by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable Get{1}Log(Int32 id,Int32 institute_id)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = """ + txt_splogsellist.Text + @""";
        cmd.Parameters.Add(para.IntInputPara(""@institute_id"", institute_id));
        cmd.Parameters.Add(para.IntInputPara(""@id"", id));
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }}
    #endregion
    
    #region Get{1}_ByID Function
    /// <summary>
    /// This function is use to get {15} data by {5}
    /// </summary>
    /// <param name=""{5}"">Pass {5}</param>
    /// <returns>Return datatable in {15} data</returns>
    public static DataTable Get{1}_ByID(Int32 id,Int32 institute_id)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = ""{6}"";
        cmd.Parameters.Add(para.IntInputPara(""@institute_id"", institute_id));
        cmd.Parameters.Add(para.IntInputPara(""@id"", id)); // ""@{5}""
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }}
    #endregion

    #region Insert_{15} Function
    /// <summary>
    /// This function is use to update the {15} data.
    /// </summary>
    /// <param name=""obj"">Pass the instance object of {7}</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert_{1}({7} obj)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = ""{8}"";";
        string uid = "";
        DataTable dt = db_dynamic_page_urp.GetColumnsByTable(tbl_name, ddlProject.SelectedValue.Split('$')[1]);
        if (dt.Rows.Count > 0)
            uid = dt.Rows[0]["name"].ToString();
        foreach (DataRow drw in dt.Rows)
        {
                Propfl += String.Format(@"
        cmd.Parameters.Add(para.{1}(""{0}"", em.""{0}""));", drw["name"], drw["datatype_2"]);
        }
        Propfl += @" 
        cmd.Parameters.Add(para.IntOutputPara(""@OUT_ID""));
        cmd.Parameters.Add(para.IntOutputPara(""@alert_msg""));
        int a = CreateCommand.NonExecuteQuery(cmd);

        PROP_db_return retObj = new PROP_db_return();
        int resultval = gda.ExecuteNonQuery(comm);
        retObj.id = Handle.ToInt32(cmd.Parameters[""@OUT_ID""].Value);
        retObj.alertMessage = Handle.ToInt32(cmd.Parameters[""@alert_msg""].Value);
        return retObj;
    }}

    #endregion

    #region Delete Function
    /// <summary>
    /// This function is used to delete the {15} data by {5}
    /// </summary>
    /// <param name=""id"">Pass integer {5} </param>
    /// <param name=""userId"">Pass integer userId </param>
    /// <param name=""ip"">Pass string ip </param>
    /// <returns>Returns if {15} data is deleted then true otherwise false</returns>
    public static Boolean Delete(Int32 id,Int32 delete_by,String delete_ip)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = ""{10}"";
        cmd.Parameters.Add(para.IntInputPara(""@id"", id));
        cmd.Parameters.Add(para.IntInputPara(""@delete_by"", delete_by));
        cmd.Parameters.Add(para.StringInputPara(""@delete_ip"", delete_ip));
        
  
        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }}
    #endregion

    #region Update_Status_{15} Function
    /// <summary>
    /// This function is used to delete the {15} data by {5}
    /// </summary>
    /// <param name=""id"">Pass integer {5} </param>
    /// <param name=""userId"">Pass integer userId </param>
    /// <param name=""ip"">Pass string ip </param>
    /// <returns>Returns if {15} data is deleted then true otherwise false</returns>
    public static Boolean Update_Status{5}(Int32 id,Int32 status,Int32 modify_by,String modify_ip)
    {{
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = ""{10}"";
        cmd.Parameters.Add(para.IntInputPara(""@id"", id));
        cmd.Parameters.Add(para.IntInputPara(""@status"", status));
        cmd.Parameters.Add(para.IntInputPara(""@modify_by"", modify_by));
        cmd.Parameters.Add(para.StringInputPara(""@modify_ip"", modify_ip));
        
        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }}
    #endregion
}}";
        Propfl = String.Format(Propfl,
              obj_name,
              obj_name.Replace("db_", "_"),
              txt_spselall.Text,
              txt_spsellist.Text,
              "",
              uid,
              txt_spselbyid.Text,
              txt_fileprop.Text,
              txt_spupdate.Text,
              txt_spcreate.Text,
              txt_spdelete.Text,
              txt_spdellogsellist.Text,
              "",
              txt_splogsellist.Text,
              "",
              tbl_name.Replace("i_", ""));

        return Propfl;
    }
    #endregion

    //functions for create form page

    #region function for create FORM ASPX file
    public String CreateFormPage(String tbl_name, String obj_name)
    {
        obj_name = (obj_name == "" ? tbl_name.Replace("i_", "form_") + ".aspx" : obj_name);
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
                    //write content
                    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + tbl_name + "\\" + "\\" + obj_name;
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreateFormAspxString(tbl_name, obj_name));
                    ret = CreateFormCSPage(tbl_name, obj_name);
                    sw.Close();
                    sw.Dispose();
                    if (ret != "Operation Successfully")
                    {
                        if (File.Exists(SaveFilePath))
                        {
                            File.Delete(SaveFilePath);
                        }
                    }
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

    #region function for create FORM CS file
    public String CreateFormCSPage(String tbl_name, String obj_name)
    {
        obj_name = (obj_name == "" ? tbl_name.Replace("i_", "form_") : obj_name);
        obj_name = obj_name + ".cs";
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
                    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + tbl_name + "\\" + "\\" + obj_name;
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreateFormCSString(tbl_name, obj_name));
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

    #region Create String for Form aspx file
    public String CreateFormAspxString(String tbl_name, String obj_name)
    {
        string uniqueCheck = string.Empty;
        string uniqueCheckLabels = string.Empty;
        string InsertOnly = string.Empty;
        string autoGenerated = string.Empty;

        foreach (RepeaterItem ritm in RptField.Items)
        {
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
            CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
            CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
            CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
            TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");

            if (chkUnique.Checked)
            {
                uniqueCheck = uniqueCheck + ',' + hfnm.Value ;
                if (!string.IsNullOrEmpty(txtLBL.Text))
                {
                    uniqueCheckLabels = uniqueCheckLabels + (uniqueCheckLabels != "" ? " or " : "") + txtLBL.Text.Trim();
                }
            }
            if (chkInsertOnly.Checked)
            {
                InsertOnly = InsertOnly + hfnm.Value + ',';
            }
            if (chkAutoGenerated.Checked)
            {
                autoGenerated = autoGenerated + hfnm.Value + ',';
            }

            if (uniqueCheck.Length > 0)
            {
                uniqueCheck = uniqueCheck.Remove(0, 1);
            }

        }
        String FAspx = @"<%@ Page Title="""" Language=""C#"" MasterPageFile=""~/Include/Master/site.master"" AutoEventWireup=""true""
    CodeBehind=""{0}.aspx.cs"" Inherits=""{0}"" %>
    <%@ Import Namespace=""System.IO"" %>
    <%@ Register Assembly=""AjaxControlToolkit"" Namespace =""AjaxControlToolkit"" TagPrefix =""cc1"" %>
    <asp:Content ID=""Content1"" ContentPlaceHolderID=""head"" runat=""Server"">
    <script>
        function isDateValidate(event) {{
            var id = event.id;
            var date = $(id).val();
            if (isDate(date) == false) {{
                messageWarning(""please Enter Date in DD/MM/YYYY Format"");
            }}
        }}
    </script>
    </asp:Content>
    <asp:Content ID=""Content2"" ContentPlaceHolderID=""ContentPlaceHolder1"" runat=""Server"">
    <script src=""https://cdn.jsdelivr.net/npm/melanke-watchjs@1.5.0/src/watch.min.js""></script>
    <asp:HiddenField runat=""server"" ID =""UniqFileId""></asp:HiddenField>
    <asp:UpdatePanel ID=""UpdatePanel"" runat=""server"" UpdateMode=""Conditional"">
    <ContentTemplate>
          <asp:Panel ID=""PnlMain"" runat =""server"">
      <asp:HiddenField runat=""server"" ID =""hd_" + uniqueCheck + @""" Value =""0"" ></asp:HiddenField>
            <div class=""alert alert-danger"" role =""alert"" id =""div_alert"" runat =""server"" visible =""false"" >
                <strong>
                    <label runat=""server"" id =""lbl_alert_msg"" ></label>
                </strong>
            </div>
            <div class=""row"" id =""div_data"" runat =""server"" visible =""true"">
                <div class=""col-xl-12"" runat=""server"">
                    <div id=""panel-8"" class=""panel"">
                        <div class=""panel-hdr"">
                            <h2></h2>
                            <div class=""panel-toolbar"">
                                <button class=""btn btn-panel waves-effect waves-themed"" data-action=""panel-collapse"" data-toggle=""tooltip"" data-offset=""0,10"" data-original-title=""Collapse""></button>
                            </div>
                        </div>
                        <div class=""panel-container collapse show"" style="""">
                            <div class=""panel-content"">
                                    <div class=""form-row"" >
                                        <asp:Label ID=""lblMessage"" Text =""Item Type"" runat =""server"" Style =""color: red; margin-left: 0px; "" ></asp:Label>
                                    </div>
                                <div class=""form-row"">
";
        foreach (RepeaterItem ritm in RptField.Items)
        {
            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txt = (TextBox)ritm.FindControl("txtLBL");
            TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal");
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");
            CheckBox chkIsExists = (CheckBox)ritm.FindControl("chkIsExists");
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo");
            CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");

            if (chk.Checked == false)
            {
                FAspx += @"
                                        <div class=""col-xl-4 col-md-6 mb-3"">                                       
                                            <label class=""form-label"" for=""simpleinput"">" + (chkComp.Checked == true ? @"<span class=""text-danger"" runat =""server""></span>" : @"") +
                                                 txt.Text + @"</label>
                                                 " + CreateControl(Handle.ToInt32(ddl.SelectedValue), chkComp.Checked, hfnm.Value, txt.Text, chkIEN.Checked, txtEnmVal.Text, chkIsExists.Checked, txtFunctionInfo.Text, chkAutoGenerated.Checked) + @"
                                        </div>";
            }
        }
        FAspx += @"        
                                </div>
                                <div style=""text-align: center"" class=""col-xl-12"">
                                    <asp:Button Text= ""Save"" runat =""server"" CssClass=""btn btn-primary"" ID=""btnSave"" OnClick=""btnSave_Click""/>
                                    <asp:Button ID=""btnCancel"" Text =""Cancel"" runat =""server"" class=""btn btn-default"" CausesValidation =""false""
                                                        OnClientClick =""return redirect('{2}');"" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>     
       </asp:Panel>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>";
        FAspx = String.Format(FAspx, txt_formPage.Text.Replace(".aspx", ""), txtMenName.Text, txt_ListPage.Text);
        String ABC = FAspx;
        return FAspx;
    }
    #endregion

    #region Create String for Form CS file
    public String CreateFormCSString(String tbl_name, String obj_name)
    {
        String EditStr = "";
        String FAspx = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class {0} : COMM_SessionCheck
{{

    #region MASTER PAGE
    public void Page_PreInit(Object sender, EventArgs e)
    {{
        if (Session[""MasterPage""] != null)
        {{
            this.MasterPageFile = Handle.ToString(Session[""MasterPage""]);
        }}
    }}
    #endregion MASTER PAGE

    protected void Page_Load(object sender, EventArgs e)
    {{
        if (!IsPostBack)
        {{    ";
        string BindDropDown = "";
        foreach (RepeaterItem ritm in RptField.Items)
        {

            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo");
            if (ddl.SelectedValue == "6" && chk.Checked == false && chkIEN.Checked == false)
            {
                string[] temp = txtFunctionInfo.Text.Split(',');
                if (temp.Length > 3)
                {

                    BindDropDown += "\nBind" + txtLBL.Text + "();";
                }
            }
        }

        FAspx += BindDropDown + @"
            if (Request.QueryString[""id""] != null && !string.IsNullOrEmpty(Request.QueryString[""id""]))
            {{
                //Edit data    
                edit{1}(Convert.ToInt32(Request.QueryString[""id""]));
            }}
        }}
    }}";
        string bindFunctions = "";
        foreach (RepeaterItem ritm in RptField.Items)
        {

            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo");
            if (ddl.SelectedValue == "6" && chk.Checked == false && chkIEN.Checked == false)
            {
                string[] temp = txtFunctionInfo.Text.Split(',');
                if (temp.Length > 3)
                {

                    bindFunctions += @" 
                                    public void Bind" + txtLBL.Text + @"() 
                                    {{
                                       DataTable dt = " + temp[0] + "." + temp[1] + @";
                                      if(dt !=null && dt.Rows.Count>0)
                                      {{ 
                                       ddl_" + hfnm.Value + @".DataSource=dt;
                                       ddl_" + hfnm.Value + @".DataTextField=""" + temp[2] + @""";
                                       ddl_" + hfnm.Value + @".DataValueField=""" + temp[3] + @""";
                                       ddl_" + hfnm.Value + @".DataBind();
                                    }}
                                   }}
                                   ";
                }
            }
        }

        FAspx += bindFunctions + @"protected void btnSave_Click(object sender, EventArgs e)
    {{  
        if(Page.IsValid)
        {{
            btn_save.Enabled = false;
            //Save data to table
            {3} PropObj = new {3}();";

        foreach (RepeaterItem ritm in RptField.Items)
        {
            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txt = (TextBox)ritm.FindControl("txtLBL");
            TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal");
            TextBox TxtConfig = (TextBox)ritm.FindControl("txtFunctionInfo");
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");

            CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
            CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");




            String DbNm = "";
            String[] ConfAutodrp = TxtConfig.Text.Split(',');
            if (ConfAutodrp.Length > 2)
            {
                DbNm = ConfAutodrp[1];
            }
            String ContrEnable = "";
            String ContVal = "";
            String ContValSet = "";
            switch (ddl.SelectedValue)
            {
                case "1": ContrEnable = "txt_" + hfnm.Value + ".Enabled=false;"; ContVal = "txt_" + hfnm.Value + ".Text"; ContValSet = "txt_" + hfnm.Value + ".Text"; break;
                case "2": ContrEnable = "txt_" + hfnm.Value + ".Enabled=false;"; ContVal = "txt_" + hfnm.Value + ".Text"; ContValSet = "txt_" + hfnm.Value + ".Text"; break;
                case "3": ContrEnable = "txt_" + hfnm.Value + ".Enabled=false;"; ContVal = "Handle.ToDouble(txt_" + hfnm.Value + ".Text)"; ContValSet = "txt_" + hfnm.Value + ".Text"; break;
                case "4": ContrEnable = "txt_" + hfnm.Value + ".Enabled=false;"; ContVal = "Handle.ToDateTime(txt_" + hfnm.Value + ".Text)"; ContValSet = "txt_" + hfnm.Value + ".Text"; break;
                case "5": ContrEnable = "txt_" + hfnm.Value + ".Enabled=false;"; ContVal = "" + DbNm + ".GetIdByName(txt_" + hfnm.Value + ".Text)"; ContValSet = "txt_" + hfnm.Value + ".Text"; break;
                case "6": ContrEnable = "ddl_" + hfnm.Value + ".Enabled=false;"; ContVal = "Handle.ToInt32(ddl_" + hfnm.Value + ".SelectedValue)"; ContValSet = "ddl_" + hfnm.Value + ".SelectedValue"; break;
                case "7": ContrEnable = "chk_" + hfnm.Value + ".Enabled=false;"; ContVal = "(chk_" + hfnm.Value + ".Checked==true?1:0)"; ContValSet = "chk_" + hfnm.Value + ".Checked"; break;
                case "8": ContrEnable = "rdo_" + hfnm.Value + ".Enabled=false;"; ContVal = "Handle.ToInt32(rdo_" + hfnm.Value + ".SelectedValue)"; ContValSet = "rdo_" + hfnm.Value + ".SelectedValue"; break;
            }
            if (chk.Checked == false)
            {
                FAspx += "\nPropObj." + hfnm.Value + " = " + ContVal + ";";
                EditStr += "\n" + ContValSet + " = dt.Rows[0][\"" + hfnm.Value + "\"].ToString(); ";
                if (chkInsertOnly.Checked == true && chkAutoGenerated.Checked == false)
                    EditStr += "\n" + ContrEnable;
            }
        }

        FAspx += @" 
            //Request.UserHostAddress;
            
            if (Request.QueryString[""id""] != null && !string.IsNullOrEmpty(Request.QueryString[""id""]))
            {{
                PROP_db_return ret = {4}.Insert_" + txt_tbl_name1.Text + @"(PropObj);
                if (ret.id>0)
                {{
                    Session[""alertmessage""] = Handle.ToString(ret.alertMessage);
                    Response.Redirect(""{2}"");
                }}
                else
                {{
                    lbl_alert_msg.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }}
            }}
            else
            {{
                PROP_db_return ret={4}.Insert_" + txt_tbl_name1.Text + @"(PropObj);
                if (ret.id > 0)
                {{
                    Session[""alertmessage""] = Handle.ToString(ret.alertMessage);
                    Response.Redirect(""{2}"");
                }}
                else
                {{
                    lbl_alert_msg.Text = DAL_Utilities.ErrorMessage(ret.alertMessage);
                }}
            }}

         btn_save.Enabled = true;
      }}
       
    }}
     public void edit{1}(int id)
    {{
        DataTable dt = {4}.Get{5}_ByID(id,Handle.ToInt32(Session[""comp_id""]));
        if (dt.Rows.Count > 0)
        {{
           " + EditStr + @"
        }}
    }}
    
}}


/*

#region Put below functions to appropriate  file ";

        string dbFunctions = "";
        foreach (RepeaterItem ritm in RptField.Items)
        {

            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");
            CheckBox chkIsExists = (CheckBox)ritm.FindControl("chkIsExists");
            TextBox txtFunctionInfo = (TextBox)ritm.FindControl("txtFunctionInfo");
            if (ddl.SelectedValue == "6" && chk.Checked == false && chkIEN.Checked == false && chkIsExists.Checked == false)
            {
                string[] temp = txtFunctionInfo.Text.Split(',');
                if (temp.Length > 4)
                {
                    string spName = "";
                    spName = temp[4].Replace("i_", "i_get_") + "_all_" + temp[2];

                    string spText = @"
CREATE PROCEDURE [dbo].[" + spName + @"]
AS
BEGIN
 select " + temp[3] + @"," + temp[2] + @" from " + temp[4] + @" with(nolock)
END";

                    if (spName != "" && spText != "")
                    {
                        string str = db_dynamic_page_urp.CreateCustomSP(ddlProject.SelectedValue.Split('$')[1], spText);
                        if (str == "Operation Successfully")
                        {
                            dbFunctions += @" 
///put in " + temp[0] + @" file
#region " + temp[1] + @" Function
/// <summary>
/// This function use to get all " + temp[2] + @" from " + temp[4] + @" table .
/// </summary>
public static DataTable " + temp[1] + @" 
{{

    DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
    DbCommand comm = gda.CreateCommand();                                       
    comm.CommandText = """ + spName + @""";
                                       
    // return the result table
    DataTable table = gda.ExecuteSelectCommand(comm);
    return table;
}}
#endregion
                                   
";
                        }
                    }
                }
            }
            else if (ddl.SelectedValue == "5" && chk.Checked == false && chkIsExists.Checked == false)
            {

                string[] temp = txtFunctionInfo.Text.Split(',');
                if (temp.Length > 5)
                {
                    string spName = "";
                    spName = temp[5] + "_Like_" + temp[3];
                    string spText = @"
CREATE PROCEDURE [dbo].[" + spName + @"]
@Search varchar(100)
AS
BEGIN
 select " + temp[3] + @"," + temp[4] + @" 
 from " + temp[5] + @" with(nolock)  
 where " + temp[3] + @" like @Search+'%'
END";
                    if (spName != "" && spText != "")
                    {
                        string str = db_dynamic_page_urp.CreateCustomSP(ddlProject.SelectedValue.Split('$')[1], spText);
                        if (str == "Operation Successfully")
                        {
                            string funName = "";
                            funName = temp[2].Replace(")", " string Search )");
                            dbFunctions += @" 
///put in " + temp[1] + @" file
#region " + temp[2] + @" Function
/// <summary>
/// This function use to get data from " + temp[5] + @" table like " + temp[3] + @".
/// </summary>
public static DataTable " + funName + @" 
{{

    DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
    DbCommand comm = gda.CreateCommand();                                       
    comm.CommandText = """ + spName + @""";

    DbParameter param = comm.CreateParameter();
    param.ParameterName = """ + "@Search" + @""";
    param.Value = Search;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
                                       
    // return the result table
    DataTable table = gda.ExecuteSelectCommand(comm);
    return table;
}}
#endregion

///put in Webservice file
#region function:" + temp[0] + @" 
/// <summary>
/// return all " + temp[5] + @" data whose " + temp[3] + @" starts with the prefix input string 
/// </summary>
[WebMethod]
public string[] " + temp[0] + @"(string prefixText, int count)
{{
   
    List<string> titleArList = new List<string>();
    DataTable dt = new DataTable();
    dt = " + temp[1] + @"." + temp[2] + @"(prefixText);
    if (dt !=null && dt.Rows.Count > 0)
    {{
           int i = 0;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {{
                string strTemp = Handle.ToString(dt.Rows[i][""" + temp[3] + @"""].ToString());
                string strid = dt.Rows[i][""" + temp[4] + @"""].ToString();
                titleArList.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(strTemp, strid));
            }}  
    }}
    return titleArList.ToArray();
    
   
}}
#endregion //endregion-function:" + temp[0] + @" 

                                   
";
                        }
                    }
                }

            }
        }


        FAspx += dbFunctions + @"
#endregion
*/
";

        FAspx = String.Format(FAspx, txt_formPage.Text.Replace(".aspx", ""), txtMenName.Text.Replace(" ", "_"), txt_ListPage.Text, txt_fileprop.Text, txt_filedb.Text, txt_filedb.Text.Replace("db_", "_"));
        return FAspx;
    }
    #endregion

    #region create dynamic controls
    public String CreateControl(Int32 ContType, Boolean iscomp, String FNM, String LbL, Boolean isEnm, String EnmVal, Boolean isFunctionExists, string functionInfo, Boolean isAutoGenerate)
    {
        String str = "";
        string contrEnabled = "";
        if (isAutoGenerate)
        {
            contrEnabled = @"Enabled = ""false""";
        }
        switch (ContType)
        {
            case 1:
                str = @"<asp:TextBox ID=""txt_" + FNM + @""" CssClass=""form-control""  " + contrEnabled + @"  runat=""server""></asp:TextBox>";
                if (iscomp)
                {
                    str += @"<asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                             ControlToValidate=""txt_" + FNM + @""" Display=""dynamic"" ErrorMessage=""Please enter " + LbL.ToLower() + @"""></asp:RequiredFieldValidator>";

                }
                break;
            case 2:
                str = @"<asp:TextBox ID=""txt_" + FNM + @""" TextMode='MultiLine' CssClass=""form-control"" " + contrEnabled + @" runat=""server""></asp:TextBox>";
                if (iscomp)
                {
                    str += @"<asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                              ControlToValidate=""txt_" + FNM + @""" Display=""dynamic"" ErrorMessage=""Please enter " + LbL.ToLower() + @"""></asp:RequiredFieldValidator>";
                }
                break;
            case 3:
                str = @"<asp:TextBox ID=""txt_" + FNM + @""" CssClass=""form-control""  " + contrEnabled + @" runat=""server""></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID=""fte_" + FNM + @""" runat=""server"" TargetControlID=""txt_" + FNM + @"""
                         ValidChars=""0123456789.-"" FilterType=""Custom""></ajaxToolkit:FilteredTextBoxExtender>";
                if (iscomp)
                {
                    str += @"
                             <asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                              ControlToValidate=""txt_" + FNM + @""" Display=""dynamic"" ErrorMessage=""Please enter " + LbL.ToLower() + @""">
                             </asp:RequiredFieldValidator>";
                }
                break;
            case 4:
                str = @"<asp:TextBox runat=""server"" ID=""txt_" + FNM + @""" CssClass=""form-control _date"" onchange=""isDateValidate(this)"" />";
                if (iscomp)
                {
                    str += @"<asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                             ControlToValidate=""txt_" + FNM + @""" Display=""dynamic"" ErrorMessage=""Please enter " + LbL.ToLower() + @"""></asp:RequiredFieldValidator>";
                }
                break;
            case 5:
                string web_service = "SetMethodHere";
                if (isFunctionExists)
                {
                    string[] temp = functionInfo.Split(',');
                    if (temp.Length > 0)
                    {
                        web_service = temp[0].ToString();
                    }
                }
                else
                {
                    try
                    {
                        string[] temp = functionInfo.Split(',');
                        if (temp.Length > 0)
                        {
                            web_service = temp[0].ToString();
                        }
                    }
                    catch { web_service = "SetMethodHere"; }
                }

                str = @"
<asp:DropDownList ID=""txt_" + FNM + @""" runat=""server"" " + contrEnabled + @" AppendDataBoundItems=""True"">
    <asp:ListItem Value=""0"" > Please Select " + LbL + @"</asp:ListItem>
</asp:DropDownList>";
                if (iscomp)
                {
                    str += @"<asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                              ControlToValidate=""txt_" + FNM + @""" Display=""dynamic"" ErrorMessage=""Please enter " + LbL.ToLower() + @"""></asp:RequiredFieldValidator>";
                }
                break;
            case 6:
                str = @"<asp:DropDownList ID=""txt_" + FNM + @""" runat=""server"" " + contrEnabled + @" AppendDataBoundItems=""True"">
                        <asp:ListItem Value=""0"" > Please Select " + LbL + @"</asp:ListItem>
";
                if (isEnm)
                {
                    String[] Enm = EnmVal.Split(',');
                    for (Int32 lp = 0; lp < Enm.Length; lp += 2)
                    {
                        str += @"<asp:ListItem Text=""" + Enm[lp + 1].ToString() + @""" Value=""" + Enm[lp].ToString() + @"""></asp:ListItem>";
                    }
                }
                str += @"</asp:DropDownList>";
                if (iscomp)
                {
                    str += @"<asp:RequiredFieldValidator CssClass=""text-danger drpClass"" ID=""Req_" + FNM + @""" runat=""server""
                              ControlToValidate=""ddl_" + FNM + @""" InitialValue=""0"" Display=""dynamic"" ErrorMessage=""Please select " + LbL.ToLower() + @""">
                             </asp:RequiredFieldValidator>";
                }
                break;
            case 7:
                str = @"<div class=""form-control""><div class=""custom-control custom-checkbox"" >
                <asp:CheckBox id=""chk_" + FNM + @""" text="" "" CssClass=""checkbox""  " + contrEnabled + @"  runat=""server""/>
        </div></div>
";
                break;
            case 8:
                if (isEnm)
                {
                    String[] Enm = EnmVal.Split(',');
                    if (Enm.Length > 0)
                    {
                        str = @"<asp:RadioButtonList CssClass=""radio"" RepeatDirection=""Horizontal"" Width =""100% "" " + contrEnabled + @"  runat=""server"" ID=""rdo_" + FNM + @""" AppendDataBoundItems=""true"">";
                        for (Int32 lp = 0; lp < Enm.Length; lp += 2)
                        {
                            str += Environment.NewLine + @"<asp:ListItem Text=""" + Enm[lp + 1].ToString() + @""" Value=""" + Enm[lp].ToString() + @"""></asp:ListItem>";
                        }
                        str += @"</asp:RadioButtonList>";
                    }
                }
                break;
        }
        return str;

    }
    #endregion

    ////////////////    

    //functions for create list page

    #region function for create LIST ASPX file
    public String CreateListPage(String tbl_name, String obj_name)
    {
        obj_name = (obj_name == "" ? "db_" + tbl_name.Replace("i_", "") : obj_name);
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
                    //write content
                    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + tbl_name + "\\" + "\\" + obj_name;
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreateListAspxString(tbl_name, obj_name));
                    ret = CreateListCSPage(tbl_name, obj_name);
                    sw.Close();
                    sw.Dispose();
                    if (ret != "Operation Successfully")
                    {
                        SaveFilePath = root + "\\SystemGeneratePages\\" + ddlProject.SelectedItem + "\\" + obj_name;
                        if (File.Exists(SaveFilePath))
                        {
                            File.Delete(SaveFilePath);
                        }
                    }
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

    #region function for create LIST CS file
    public String CreateListCSPage(String tbl_name, String obj_name)
    {
        obj_name = (obj_name == "" ? "db_" + tbl_name.Replace("i_", "") : obj_name);
        obj_name = obj_name + ".cs";
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
                    SaveFilePath = Server.MapPath("~/Upload_v2/") + "\\" + tbl_name + "\\" + "\\" + obj_name;
                    FileStream fsSave = File.Create(SaveFilePath);
                    //write content
                    sw = new StreamWriter(fsSave);
                    sw.Write(CreateListCSString(tbl_name, obj_name));
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

    #region Create String for List aspx file
    public String CreateListAspxString(String tbl_name, String obj_name)
    {
        String MainGrdDataSource = "";
        String MainGrdColSet = "";
        String LogGrdDataSource = "";
        String LogGrdColSet = "";
        String ColumnPreFix = "";
        String TablePreFix = ddlTable.SelectedValue.Split('_')[1];

        MainGrdDataSource += "{{ name: 'id', type: 'number', colName: '' }},";
        LogGrdDataSource += @"{{ name: 'operation_type', type: 'string', colName: 'Operation Type' }},
                    {{ name: 'operation_dnt', type: 'date', colName: 'Operation Date' }},
                    {{ name: 'create_by_user', type: 'string', colName: 'Enter By' }},
                    {{ name: 'create_dnt', type: 'date', colName: 'Enter Date' }},
                    {{ name: 'modify_by_user', type: 'string', colName: 'Modify By' }},
                    {{ name: 'modify_dnt', type: 'date', colName: 'Modify Date' }},";

        MainGrdColSet += "{{ text: 'Action', datafield: 'id', groupable: false, sortable: false, exportable: false, filterable: false, cellsrenderer: renderer,pinned: true, width:85 }},";
        LogGrdColSet += @"{{ text: 'Operation Type', datafield: 'operation_type',filtertype: 'input',width:80}},
                    {{ text: 'Operation Date', datafield: 'operation_dnt',cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }},
                    {{ text: 'Enter By', datafield: 'create_by_user',filtertype: 'input',width:80 }},
                    {{ text: 'Enter Date', datafield: 'create_dnt', cellsformat:'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }},
                    {{ text: 'Modify By', datafield: 'modify_by_user',filtertype: 'input' ,width:80 }},
                    {{ text: 'Modify Date', datafield: 'modify_dnt', cellsformat:'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }},";

        foreach (RepeaterItem ritm in RptField.Items)
        {
            CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
            CheckBox chkIEN = (CheckBox)ritm.FindControl("chkIEN");
            TextBox txt = (TextBox)ritm.FindControl("txtLBL");
            TextBox txtEnmVal = (TextBox)ritm.FindControl("txtENMVal");
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            CheckBox chkComp = (CheckBox)ritm.FindControl("ChkIsComp");
            DropDownList ddl = (DropDownList)ritm.FindControl("ddlControlType");
            ColumnPreFix = hfnm.Value.Split('_')[0];
            String DataType = "";
            String FilterType = "";
            switch (ddl.SelectedValue)
            {
                case "1": DataType = "string"; FilterType = "input"; break;
                case "2": DataType = "string"; FilterType = "input"; break;
                case "3": DataType = "number"; FilterType = "number"; break;
                case "4": DataType = "date"; FilterType = "range"; break;
                case "5": DataType = "string"; FilterType = "input"; break;
                case "6": DataType = "string"; FilterType = "input"; break;
                case "7": DataType = "string"; FilterType = "input"; break;
                case "8": DataType = "string"; FilterType = "input"; break;
            }
            if (chk.Checked == false)
            {
                MainGrdDataSource += Environment.NewLine + "{{ name: '" + hfnm.Value + "', type: '" + DataType + "', colName: '" + txt.Text + "' }},";
                LogGrdDataSource += Environment.NewLine + "{{ name: '" + hfnm.Value + "', type: '" + DataType + "', colName: '" + txt.Text + "' }},";
                MainGrdColSet += Environment.NewLine + "{{ text: '" + txt.Text + "', datafield: '" + hfnm.Value + "',filtertype: '" + FilterType + "' }},";
                LogGrdColSet += Environment.NewLine + "{{ text: '" + txt.Text + "', datafield: '" + hfnm.Value + "',filtertype: '" + FilterType + "' }},";
            }
        }
        MainGrdDataSource += Environment.NewLine + @"{{ name: 'create_by_user', type: 'string', colName: 'Enter By' }},
                    {{ name: 'create_dnt', type: 'date', colName: 'Enter Date' }},
                    {{ name: 'modify_by_user', type: 'string', colName: 'Modify By' }},
                    {{ name: 'modify_dnt', type: 'date', colName: 'Modify Date' }}";
        LogGrdDataSource = LogGrdDataSource.Remove(LogGrdDataSource.Length - 1, 1);
        LogGrdColSet = LogGrdColSet.Remove(LogGrdColSet.Length - 1, 1);
        MainGrdColSet += Environment.NewLine + @"{{ text: 'Enter By', datafield: 'create_by_user',filtertype: 'input',width:80 }},
                    {{ text: 'Enter Date', datafield: 'create_dnt', cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }},
                    {{ text: 'Modify By', datafield: 'modify_by_user',filtertype: 'input',width:80 }},
                    {{ text: 'Modify Date', datafield: 'modify_dnt', cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }}";

        String FAspx = @"<%@ Page Language=""C#"" MasterPageFile=""~/Include/Master/site.master"" AutoEventWireup=""true""
    CodeFile=""{0}.cs"" Inherits=""{1}"" %>
<asp:Content ID=""Content2"" ContentPlaceHolderID =""ContentPlaceHolder1"" runat =""Server"">
   <!-- widget grid -->
    <section id=""widget-grid"" class=""panel"">
        <!-- row -->
        <div class=""row"">
            <!-- NEW WIDGET START -->
            <article class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <!-- Widget ID (each widget will need unique ID)-->
                <div class=""jarviswidget jarviswidget-color-blueDark"" id =""wid-id-3"" data-widget-sortable=""false"" data-widget-deletebutton=""false"" data-widget-togglebutton=""false"" data-widget-editbutton=""false"">
                    <div class=""panel-hdr"">
                        <h2></h2>
                    </div>
                    <!-- widget div-->
                    <div>
                        <asp:UpdatePanel ID=""UpdatePanel2"" runat=""server"" UpdateMode=""Conditional"">
                            <ContentTemplate>
                                <div class=""panel-container collapse show"" style="""">
                                    <div class=""panel-content"">
                                        <div class=""form-row"">
                                            <%--<fieldset class=""custom_fs"">                                                
                                                <legend>
                                                    Filter Criteria
                                                </legend>											    
                                            </fieldset>
                                            <br />--%>
                                            <div class=""col-md-4"">
                                                <a href=""javascript:void(0);"" onclick=""GetDataAJAX();"" class=""btn btn-primary btn-sm"">Load</a>
                                                <a href=""javascript:void(0);"" onclick=""ShowDefInput();"" class=""btn btn-primary btn-sm"">Save Definition</a>
                                            </div>
                                            <input type=""hidden"" id=""hid_default_def"" />
                                            <div class=""col-md-4"" id=""defSave"" style=""visibility: hidden;"">
                                                <div class=""input-group"">
                                                    <input type=""text"" id=""txtDefName"" class=""form-control"">
                                                    <div class=""input-group-btn"">
                                                        <button type=""button"" onclick=""SaveDef();"" class=""btn btn-default"">
                                                            Save
                                                        </button>
                                                        <button type=""button"" onclick=""HideDef();"" class=""btn btn-default"">
                                                            Cancel
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class=""widget-body no-padding"" style=""clear: left; margin-top: 10px;"">
                            <div id='jqxWidget'>
                                <div id=""jqxgrid"">
                                </div>
                            </div>
                            <div id='jqxWidgetViewLog'>
                                <div id=""jqxgridViewLog"">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </div>
    </section>
                <!-- PAGE RELATED PLUGIN(S) -->
                <link rel=""stylesheet"" href =""<%=Session[""base_url""]%>jqwidgets/styles/jqx.base.css"" type =""text/css"" />
                <script type=""text/javascript"" src =""<%=Session[""base_url""]%>jqwidgets/jqx-all.js""></script>
                function ShowDefInput()
        {{
            document.getElementById(""defSave"").style.visibility=""visible"";
        }}
        function HideDef()
        {{
            document.getElementById(""defSave"").style.visibility=""hidden"";
            $(""#jqxNotification"").jqxNotification(""open"");
        }}
        function DelDef() {{
            var item = $(""#DDLDef"").jqxDropDownList('getSelectedItem');
            ConfirmBox(""Are You Sure?"", ""Do you want to delete "" + item.label + "" definition?"").done(function() {{
                $.ajax({{
                type: ""POST"",
                    url: ""<%=Session[""base_url""]%>ajax_comm.aspx"",
                    async: true,
                    data: ""del_def_id="" + item.value,
                    success: function(data) {{
                    if (data.toString() == '1')
                    {{
                        alert('Definition deleted successfully.');
                            $(""#DDLDef"").jqxDropDownList('clearSelection');
                            $(""#DDLDef"").jqxDropDownList('removeItem', item.value);
                        document.getElementById(""delDef"").style.visibility = ""hidden"";
                        document.getElementById(""updateDef"").style.visibility = ""hidden"";
                        document.getElementById(""setDefault"").style.visibility = ""hidden"";
                    }}
                    else
                    {{
                        alert('Some error is occurred while deleting.');
                    }}
                }},
                    error: function() {{ //On Error
                    alert('Some error is occurred while deleting.');
                }}
            }});
        }});
    }}

    function Defchange(item) {{
            if (item.value != '-1') {{
                document.getElementById(""delDef"").style.visibility = ""visible"";
                document.getElementById(""updateDef"").style.visibility = ""visible"";
                document.getElementById(""setDefault"").style.visibility = ""visible"";
                $.ajax({{
                    type: ""POST"",
                    url: ""<%=Session[""base_url""]%>ajax_comm.aspx"",
                    async: true,
                    data: ""GridDef_id="" + item.value,
                    success: function (data) {{
                        if (data.toString() != '') {{
                            var Definition = $.parseJSON(data);
                            if (Definition[0].uwgs_is_default == ""1"")
                                document.getElementById(""setDefault"").style.visibility = ""hidden"";
                            var sstate = $.parseJSON(Definition[0].uwgs_grid_state);
                            try {{
                                if (sstate) {{
                                    $(""#jqxgrid"").jqxGrid(""cleargroups"");
                                    $(""#jqxgrid"").jqxGrid('loadstate', sstate);
                                }}
                            }}
                            catch (ex) {{ alert(""Oops! Some error is occurred""); }}
                        }}
                    }}
                }})
            }}
            else {{
                document.getElementById(""delDef"").style.visibility = ""hidden"";
                document.getElementById(""updateDef"").style.visibility = ""hidden"";
                document.getElementById(""setDefault"").style.visibility = ""hidden"";

                var sstate = $.parseJSON($(""#hid_default_def"").val());
                try {{
                    if (sstate) {{
                        $(""#jqxgrid"").jqxGrid(""cleargroups"");
                        $(""#jqxgrid"").jqxGrid('loadstate', sstate);
                    }}
                }}
                catch (ex) {{ alert(""Oops! Some error is occurred""); }}
            }}
        }}
         
        function UpdateDef() {{
            var item = $(""#DDLDef"").jqxDropDownList('getSelectedItem');
            var ustat = $(""#jqxgrid"").jqxGrid('savestate');
            ConfirmBox(""Are You Sure?"", ""Do you want to update "" + item.label + "" definition?"").done(function () {{
                var DatStr = {{ 'update_def_id': item.value, 'uwgs_grid_state': JSON.stringify(ustat) }}
                $.ajax({{
                    type: ""POST"",
                    url: ""<%=Session[""base_url""]%>ajax_comm.aspx"",
                    async: true,
                    data: DatStr,
                    success: function (data) {{
                        if (data.toString() == '1') {{
                            alert('Definition updated successfully.');
                        }}
                        else {{
                            alert('Some error is occurred while updating.');
                        }}
                    }},
                    error: function () {{ //On Error
                        alert('Some error is occurred while updating.');
                    }}
                }});
            }});
        }}
        
        function SetDefaultDef() {{
            var item = $(""#DDLDef"").jqxDropDownList('getSelectedItem');
            ConfirmBox(""Are You Sure?"", ""Do you want to set this definition as default ?"").done(function () {{
                $.ajax({{
                    type: ""POST"",
                    url: ""<%=Session[""base_url""]%>ajax_comm.aspx"",
                    async: true,
                    data: ""SD_def_id="" + item.value,
                    success: function (data) {{
                        if (data.toString() == '1') {{
                            alert('Default Definition set successfully.');
                            document.getElementById(""setDefault"").style.visibility = ""hidden"";
                        }}
                        else {{
                            alert('Some error is occurred.');
                        }}
                    }},
                    error: function () {{ //On Error
                        alert('Some error is occurred.');
                    }}
                }});
            }});
        }}

        function SaveDef()
        {{
            var flg=0;
            var items = $(""#DDLDef"").jqxDropDownList('getItems');
            for (var i = 0; i < items.length; i++) 
            {{
                if(items[i].label==$(""#txtDefName"").val())
                {{
                    alert(""Definition already exists with name ""+$(""#txtDefName"").val());
                    flg=1;
                }}
            }}
            if($.trim($(""#txtDefName"").val())=="""")
            {{
                alert(""Please enter definition name"");
                $(""#txtDefName"").focus();
                flg=1;
            }}
            if(flg==0)
            {{
                var url='<%=Session[""base_url""]%>ajax_comm.aspx';
                var stat=$(""#jqxgrid"").jqxGrid('savestate');                                
                var DatStr={{'uwgs_set_name':$(""#txtDefName"").val(),'uwgs_grid_name':'{3}','uwgs_grid_state':JSON.stringify(stat)}}
                
                $.ajax({{
                    type: ""POST"",
                    url: url,                                
                    async: true,                                
                    data:  DatStr,                                
                    success: function (data) 
                    {{                                    
                        if (data.toString() == '1') 
                        {{
                            alert('inserted');  
                            document.getElementById(""defSave"").style.visibility=""hidden"";
                            GetDefData();
                        }}
                        else
                        {{
                            alert('Some error is occurred.');
                        }}
                    }},
                    error: function () {{ //On Error
                        alert('Some error is occurred.');
                    }}
                }});
            }}
        }}
        /* LOG FUNCTION */
        var viewLog = function (event) {{
            $(""#jqxgridViewLog"").show();

            var id = event.target.id;
            var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
            if(dataRecord.id !="""")
            {{
                $.ajax({{
                    type: ""POST"",
                    url: ""ajax_{6}.aspx"",
                    async: true,
                    data: ""slv_{5}_id=""+dataRecord.id+""&sign={3}"",
                    success: function (data) {{
                        if (data.toString() != '') 
                        {{                                    
                            datafieldsViewLog = data;                                    
                            sourceViewLog.localdata = datafieldsViewLog                                   
                            dataAdapterViewLog.dataBind();
                        }}
                    }}
                }})                           
            }}
            document.getElementById(""jqxgridViewLog"").scrollIntoView()
        }}
        /* END LOG FUNCTION */

        var Editclick = function (event) {{
            var id = event.target.id;
            var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
            $.ajax({{
                type: ""POST"",
                url: ""{1}.aspx/Edit_{3}"",
                data: '{{{5}_id : ""' + dataRecord.id + '"" }}',
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                beforeSend: function () {{
                    $('[id*=UpdateProgress]').css('display', '');
                }},
                success: function (response) {{
                    if (response.d != ""[]"") {{
                        window.open(response.d, ""_blank"");
                    }}
                }},
                error: function () {{ //On Error
                    alert('Some error is occurred while Edit data.');
                }},
                complete: function () {{
                    $('[id*=UpdateProgress]').css('display', 'none');
                }},

            }});
            
        }}
        var Viewclick = function (event) {{
            var id = event.target.id;
            var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
            $.ajax({{
                type: ""POST"",
                url: ""{1}.aspx/View_{3}"",
                data: '{{{5}_id: ""' + dataRecord.id + '""}}',
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                beforeSend: function () {{
                    $('[id*=UpdateProgress]').css('display', '');
                }},
                success: function (response) {{
                    if (response.d != ""[]"") {{
                        window.open(response.d, ""_blank"");
                    }}
                }},
                error: function () {{ //On Error
                    alert('Some error is occurred while Data View.');
                }},
                complete: function () {{
                    $('[id*=UpdateProgress]').css('display', 'none');
                }},
            }});  
        }}

        var Deleteclick = function (event) {{
            var id = event.target.id;
            var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
            if (confirm(""Are you sure delete?"")) {{
                var id = event.target.id;
                var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
                $.ajax({{
                    type: ""POST"",
                    url: ""ajax_{6}.aspx"",
                    async: true,
                    data: ""del_{5}_id="" + dataRecord.id + ""&sign={3}"",
                    success: function (data) {{
                        if (data.toString() == '1') {{
                            alert('{3} deleted successfully.');
                            $(""#jqxgrid"").jqxGrid('deleterow', id);
                        }}
                        else {{
                            alert('Some error is occurred while deleting.');
                        }}
                    }},
                    error: function () {{ //On Error
                        alert('Some error is occurred while deleting.');
                    }}
                }});
            }}
        }}
                    
        var datafields = [];
            var source =
            {{
                datatype: ""json"",
                datafields: [" + MainGrdDataSource + @"],
                pager: function (pagenum, pagesize, oldpagenum) {{
                    // callback called when a page or page size is changed.
                }},                            
                localdata: datafields

            }};
        var dataAdapter = new $.jqx.dataAdapter(source);

        /* LOG VARIABLES */
        ///View Log Section
        var datafieldsViewLog = [];
            var sourceViewLog =
            {{
                datatype: ""json"",
                datafields: [" + LogGrdDataSource + @"],
                pager: function (pagenum, pagesize, oldpagenum) {{
                    // callback called when a page or page size is changed.
                }},                            
                localdata: datafieldsViewLog
            }};
            var dataAdapterViewLog = new $.jqx.dataAdapter(sourceViewLog);
        //End View Log Section
        /* LOG VARIABLES */
                   
        function GetDataAJAX()
        {{
            $.ajax({{
                type: ""POST"",
                url: ""ajax_{6}.aspx"",
                async: true,
                data: ""g{5}_user_id=<%=Session[""user_id""]%>&sign={3}"",
                success: function (data) {{
                    if (data.toString() != '') 
                    {{                                    
                        datafields = data;                                    
                        source.localdata = datafields                                   
                        dataAdapter.dataBind();
                    }}
                }}
            }})
        }}
                                                                              
        var DdlDefSource=
        {{
            datatype: ""json"",
            datafields: [
                {{ name: 'uwgs_set_name', type: 'String' }},
                {{ name: 'Def', type: 'String' }}
            ],
            pager: function (pagenum, pagesize, oldpagenum) {{
                // callback called when a page or page size is changed.
            }}
        }};
        var dataAdapterDDLDef = new $.jqx.dataAdapter(DdlDefSource);
        var defailtDef=0;
        function GetDefData()
        {{
            var DefData="""";
            $.ajax({{
                type: ""POST"",
                url: ""<%=Session[""base_url""]%>ajax_comm.aspx"",
                async: false,
                data: ""GridDef_user_id=<%=Session[""user_id""]%>&Grid_name={3}"",
                success: function (data) {{
                    if (data.toString() != '') 
                    {{                                    
                        var Response=data.split('^');
                        defailtDef=Response[0];
                        DefData =$.parseJSON(Response[1]);
                        DdlDefSource.localdata=DefData;
                        dataAdapterDDLDef.dataBind();

                    }}
                }}
            }})  
        }}
        GetDefData();

        $(document).ready(function () {{
            var renderer = function (id) 
            {{
                var editflag=""<%=edit_flag%>"";
                var deleteflag=""<%=delete_flag%>"";
                var viewLogflag=""<%=viewLog_flag%>"";

                var dataRecord = $(""#jqxgrid"").jqxGrid('getrowdata', id);
                return ((editflag>0) ? '<i title=""Edit"" style=""cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px"" onClick=""Editclick(event)"" id=""' + id + '"" class=""fal fa-edit"" ></i>':'') 
                       + '<i title=""View"" style=""cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px"" onClick=""Viewclick(event)"" id=""' + id + '"" class=""fal fa-eye"" ></i>'
                       + ((deleteflag>0) ? '<i title=""Delete"" style=""cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px"" onClick=""Deleteclick(event)"" id=""' + id + '"" class=""fal fa-trash-alt"" ></i>' :'')
                       + ((viewLogflag>0 && dataRecord.modify_dnt != null ) ?'<i title=""View Log"" style=""cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px"" onClick=""viewLog(event)"" id=""' + id + '"" class=""fal fa-database"" ></i>':'')
            }};                        
            $(""#jqxgrid"").jqxGrid(
            {{
                width: '100%',
                autoheight:true,
                source: dataAdapter,
                columnsresize: true,
                groupable: true,
                sortable: true,
                pageable: true,
                showfilterrow: true,
                filterable: true,
                showtoolbar: true,                            
                columnsreorder: true,
                rendertoolbar: function (toolbar) {{
                    var me = this;
                    var container = $(""<div style='margin: 5px;'></div>"");
                    toolbar.append(container);
                    var addButton = $(""<div style='float: left; margin-left: 5px;'><i class='fa fa-plus' style='color:green;font-size:18px;' ></i><span style='margin-left: 4px; position: relative;top:-3px;'>Add</span></div>"");
                                
                    var insertflag=""<%=insert_flag%>"";
                    if(insertflag==1)
                        container.append(addButton);
                    addButton.jqxButton({{ width: 60, height: 18 }});

                    var ddlDiv = $(""<div style='float:left;margin-left: 5px;' id='jqxWidgetDDL'></div>"");
                    var ddlDivDef = $(""<div id='DDLDef' style='float:left;margin-left: 5px;'></div>"");
                    var ExportBtn = $(""<div style='float: left; margin-left: 5px;'><i class='fa fa-file-excel-o' style='color:green;font-size:18px;margin-top:-2px;' ></i><span style='margin-left: 4px; position: relative;top:-1px;'>Export</span></div>"");
                    
                    var delBtn=$(""<i class='fa fa-trash-o fa-lg' id='delDef' onclick='DelDef();' style='font-size:15px;color:red;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='delete definition'></i>"");
                    var UpdateBtn=$(""<i class='fa fa-pencil-square-o fa-lg' id='updateDef' onclick='UpdateDef();' style='font-size:15px;color:red;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='Update Selected definition'></i>"");
                    var SetDefaultBtn=$(""<i class='fa fa-check-square-o fa-lg' id='setDefault' onclick='SetDefaultDef();' style='font-size:15px;color:green;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='Set it as Default Definition'></i>"");                    
                                
                    var exportflag=""<%=export_flag%>"";
                    if(exportflag==1)
                        container.append(ExportBtn);

                    var deletedLogButton = $(""<div style='float: left; margin-left: 5px;'><span style='margin-left: 4px; position: relative;top:2px;'>Deleted Log</span></div>"");
                               
                    var deletedViewLogflag=""<%=deletedViewLog_flag%>"";
                    if(deletedViewLogflag==1)
                        container.append(deletedLogButton);
                    deletedLogButton.jqxButton({{ width: 100, height: 18 }});

                    container.append(ddlDiv);
                    container.append(ddlDivDef);
                    container.append(delBtn);
                    container.append(UpdateBtn);
                    container.append(SetDefaultBtn);
                    // prepare the data
                    var sourceData = source.datafields;
                    var Cldata='[';
                    for(i=0;i<sourceData.length;i++)
                    {{
                        if(sourceData[i].colName !="""")
                        {{
                        if(i==sourceData.length-1)
                        Cldata+='{{""cnm"":""'+sourceData[i].colName+'"",""cvl"":""'+sourceData[i].name+'""}}';
                        else
                        Cldata+='{{""cnm"":""'+sourceData[i].colName+'"",""cvl"":""'+sourceData[i].name+'""}},';
                        }} 
                    }}
                    Cldata+=']';                                
                    var sourceDDL =
                    {{
                        datatype: ""json"",
                        datafields: [
                            {{ name: 'cnm', type: 'String' }},
                            {{ name: 'cvl', type: 'string' }}
                        ],
                        pager: function (pagenum, pagesize, oldpagenum) {{
                            // callback called when a page or page size is changed.
                        }},
                        localdata: Cldata
                    }};
                    var dataAdapterDDL = new $.jqx.dataAdapter(sourceDDL);
                    // Create a jqxDropDownList
                    ddlDiv.jqxDropDownList({{ checkboxes: true, selectionRenderer: function () {{return ""<div class='DDLLabel'>Select Column</div>"";}}, source: dataAdapterDDL, displayMember: ""cnm"", valueMember: ""cvl"", width: '25%', height: 25,placeHolder:""Select Column"" }});
                    ddlDiv.jqxDropDownList('checkAll');
                    ddlDiv.on('checkChange', function (event) 
                    {{
                        if (event.args) {{
                            var item = event.args.item;
                            $(""#jqxgrid"").jqxGrid('beginupdate');
                            if (item.checked) {{
                                $(""#jqxgrid"").jqxGrid('showcolumn', item.value);
                            }}
                            else {{
                                $(""#jqxgrid"").jqxGrid('hidecolumn', item.value);
                                
                            }}
                            $(""#jqxgrid"").jqxGrid('endupdate');
                        }}
                    }});                                                            
                   
                    ddlDivDef.on('change',function (event) {{var item = event.args.item;Defchange(item);}});
                    ddlDivDef.on('bindingComplete', function (event) 
                    {{                        
                        var item = ddlDivDef.jqxDropDownList('getItemByValue', defailtDef.toString());                        
                        if(item)
                        {{   
                            ddlDivDef.jqxDropDownList('selectItem',item);
                            Defchange(item);
                        }}
                    }});                   
                    ddlDivDef.jqxDropDownList({{source: dataAdapterDDLDef , displayMember: ""uwgs_set_name"", valueMember: ""Def"", width: '25%', height: 25,placeHolder:""Select Definition"" }});                                                            

                    ExportBtn.jqxButton({{ width: 80, height: 18 }});
                    // Add new row.
                    addButton.click(function (event) {{
                        window.location.href = ""{4}"";
                    }});
                    // Export In Excel
                    ExportBtn.click(function (event) 
                    {{
                        $(""#jqxgrid"").jqxGrid('exportdata', 'xls', '{3}_Detail');
                    }});
                    //Deleted Log
                    deletedLogButton.click(function (event) {{

                        $(""#jqxgridViewLog"").show();
                        $.ajax({{
                            type: ""POST"",
                            url: ""ajax_{6}.aspx"",
                            async: true,
                            data: ""dlv_{5}_user_id=<%=Session[""user_id""]%>&sign={3}"",
                            success: function (data) {{
                                if (data.toString() != '') 
                                {{                                    
                                    datafieldsViewLog = data;                                    
                                    sourceViewLog.localdata = datafieldsViewLog                                   
                                    dataAdapterViewLog.dataBind();
                                }}
                            }}
                        }})
                        document.getElementById(""jqxgridViewLog"").scrollIntoView()                                    
                    }});
                }},                            
                columns: [" + MainGrdColSet + @"]
            }});                   
            /*Log View Grid */
            $(""#jqxgridViewLog"").jqxGrid(
            {{
                width: '100%',
                autoheight:true,
                source: dataAdapterViewLog,
                columnsresize: true,
                groupable: false,
                sortable: false,
                pageable: true,
                showfilterrow: true,
                filterable: true,
                showtoolbar: true,                            
                columnsreorder: true,
                rendertoolbar: function (toolbar) {{
                    var me = this;
                    var container = $(""<div style='margin: 5px;'></div>"");
                    toolbar.append(container);

                    var closeButton = $(""<div style='float: left; margin-left: 5px;'><span style='margin-left: 4px; position: relative;top:2px;'>Close</span></div>"");
                    container.append(closeButton);
                    closeButton.jqxButton({{ width: 60, height: 18 }});
                    closeButton.click(function (event) {{
                                   
                            $(""#jqxgridViewLog"").jqxGrid('clear');
                            document.getElementById(""jqxWidgetViewLog"").style.visibility=""hidden"";
                            window.scroll(0, 0);
                    }});

                    var ddlDiv = $(""<div style='float:left;margin-left: 5px;' id='jqxWidgetViewLogDDL'></div>"");
                    container.append(ddlDiv);
                                
                    var sourceData = sourceViewLog.datafields;
                    var Cldata='[';
                    for(i=0;i<sourceData.length;i++)
                    {{
                        if(sourceData[i].colName !="""")
                        {{
                            if(i==sourceData.length-1)
                            Cldata+='{{""cnm"":""'+sourceData[i].colName+'"",""cvl"":""'+sourceData[i].name+'""}}';
                            else
                            Cldata+='{{""cnm"":""'+sourceData[i].colName+'"",""cvl"":""'+sourceData[i].name+'""}},';
                        }}
                    }}
                    Cldata+=']';                                
                    var sourceDDL =
                    {{
                        datatype: ""json"",
                        datafields: [
                            {{ name: 'cnm', type: 'String' }},
                            {{ name: 'cvl', type: 'string' }}
                        ],
                        pager: function (pagenum, pagesize, oldpagenum) {{
                            // callback called when a page or page size is changed.
                        }},
                        localdata: Cldata
                    }};
                    var dataAdapterDDL = new $.jqx.dataAdapter(sourceDDL);
                                                               
                    // Create a jqxDropDownList
                                
                    ddlDiv.jqxDropDownList({{ checkboxes: true,selectionRenderer: function () {{return ""<div class='DDLLabel'>Select Column</div>"";}}, source: dataAdapterDDL, displayMember: ""cnm"", valueMember: ""cvl"", width: '25%', height: 25,placeHolder:""Select Column"" }});
                    ddlDiv.jqxDropDownList('checkAll');
                    ddlDiv.on('checkChange', function (event) 
                    {{
                        if (event.args) {{
                            var item = event.args.item;
                            $(""#jqxgridViewLog"").jqxGrid('beginupdate');
                            if (item.checked) {{
                               $(""#jqxgridViewLog"").jqxGrid('showcolumn', item.value);
                            }}
                            else {{
                                 $(""#jqxgridViewLog"").jqxGrid('hidecolumn', item.value);
                                
                            }}
                            $(""#jqxgridViewLog"").jqxGrid('endupdate');
                        }}
                    }});                                                            
                }},
                columns: [" + LogGrdColSet + @"]
            }});
            //End Log view grid
            /*END Log View Grid */                             
            $(""#excelExport"").click(function () 
            {{
                $(""#jqxgrid"").jqxGrid('exportdata', 'xls', 'jqxGrid');
            }});
        }});
    </script>        
</asp:Content>";

        FAspx = String.Format(FAspx, txt_ListPage.Text, txt_ListPage.Text.Replace(".aspx", ""), txtMenName.Text, txtMenName.Text.Replace(" ", "_"), txt_formPage.Text, ColumnPreFix, TablePreFix);
        return FAspx;
    }
    #endregion

    #region Create String for List CS file
    public String CreateListCSString(String tbl_name, String obj_name)
    {
        String ColumnPreFix = "";
        if (RptField.Items.Count > 0)
        {
            RepeaterItem ritm = RptField.Items[0];
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");
            ColumnPreFix = hfnm.Value.Split('_')[0];
        }
        String FAspx = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using infinity;
using System.Web.Services;
using Newtonsoft.Json;
using AjaxControlToolkit;

public partial class {0} : COMM_SessionCheck
{{
    #region MASTER PAGE
    public void Page_PreInit(Object sender, EventArgs e)
    {{
        if (Session[""MasterPage""] != null)
        {{
            this.MasterPageFile = Handle.ToString(Session[""MasterPage""]);
        }}
    }}
    #endregion MASTER PAGE

    #region Global Declaration
    public int insert_flag = 0;
    public int edit_flag = 0;
    public int delete_flag = 0;
    public int export_flag = 0;
    public int viewLog_flag = 0;
    public int deletedViewLog_flag = 0;
    public int copy_flag = 0;
    public int status_flag = 0;
    public int view_flag = 0;
    #endregion
    
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {{
        if (!IsPostBack)
        {{
            if (Session[""alertmessage""] != null && !string.IsNullOrEmpty(Handle.ToString(Session[""alertmessage""])))
            {{
                Page.ClientScript.RegisterStartupScript(this.GetType(), ""script"", ""messageSuccess('"" + Session[""alertmessage""] + ""');hide(); "", true);
                Session[""alertmessage""] = null;
            }}
            GetRightsData();
        }}
    }}
    #endregion

    #region GetRightsData
    public void GetRightsData()
    {{
        DataTable dtPermission = db_Menu.GetAllPermissions(DAL_Utilities.getpagenamefolder(), Handle.ToInt32(Session[""user_id""]));
        if (dtPermission != null && dtPermission.Rows.Count > 0)
        {{
            if (dtPermission.Rows[0][""MenuID""].ToString() != ""0"")
            {{
                DataRow[] drInsert = dtPermission.Select(""uwp_per_id=1"");
                insert_flag = (drInsert.Length > 0 ? 1 : 0);
                DataRow[] drEdit = dtPermission.Select(""uwp_per_id=2"");
                edit_flag = (drEdit.Length > 0 ? 1 : 0);
                DataRow[] drDelete = dtPermission.Select(""uwp_per_id=3"");
                delete_flag = (drDelete.Length > 0 ? 1 : 0);
                DataRow[] drStatus = dtPermission.Select(""uwp_per_id=4"");
                status_flag = (drStatus.Length > 0 ? 1 : 0);
                DataRow[] drView = dtPermission.Select(""uwp_per_id=5"");
                view_flag = (drView.Length > 0 ? 1 : 0);
                DataRow[] drExport = dtPermission.Select(""uwp_per_id=6"");
                export_flag = (drExport.Length > 0 ? 1 : 0);
                DataRow[] drViewLog = dtPermission.Select(""uwp_per_id=7"");
                viewLog_flag = (drViewLog.Length > 0 ? 1 : 0);
                DataRow[] drDeletedLogView = dtPermission.Select(""uwp_per_id=8"");
                deletedViewLog_flag = (drDeletedLogView.Length > 0 ? 1 : 0);
            }}
        }}
    }}
    #endregion

    #region Encrypt_Decrypt
    [System.Web.Services.WebMethod]
    public static string Edit_Item_Type(int itm_id)
    {{
        string JSONString = string.Empty;
        string Decrypt = Incrypt_Decrypt.Encrypt_Decrypt.Encrypt(Handle.ToString(itm_id));
        string url = Handle.ToString("""+ txt_ListPage.Text.Replace(".aspx", "").Replace("list","from") + @".aspx?id="" + Decrypt + """");
        JSONString = url;
        return JSONString;
    }}

    [System.Web.Services.WebMethod]
    public static string View_data_view(int itm_id)
    {{
        string JSONString = string.Empty;
        string Decrypt = Incrypt_Decrypt.Encrypt_Decrypt.Encrypt(Handle.ToString(itm_id));
        string url = Handle.ToString(""" + txt_ListPage.Text.Replace(".aspx", "").Replace("list", "from") + @".aspx?vid="" + Decrypt + "");
        JSONString = url;
        return JSONString;
    }}
    #endregion
}}

/*

 case ""{1}"":
                Manage{1}();
                break;

#region {1}

    public void Manage{1}()
    {{
        if (Request.Form[""del_{2}_id""] != null && !string.IsNullOrEmpty(Request.Form[""del_{2}_id""]))
        {{
            Delete{1}(Handle.ToInt32(Request.Form[""del_{2}_id""].ToString()));
        }}
        else if (Request.Form[""g{2}_user_id""] != null && !string.IsNullOrEmpty(Request.Form[""g{2}_user_id""] ))
        {{
            Get{1}();
        }}
        else if (Request.Form[""dlv_{2}_user_id""] != null && !string.IsNullOrEmpty(Request.Form[""dlv_{2}_user_id""]))
        {{
            Get{1}DeletedLog();
        }}
        else if (Request.Form[""slv_{2}_id""] != null && !string.IsNullOrEmpty(Request.Form[""slv_{2}_id""] ))
        {{
            Get{1}Log();
        }}
    }}

    #region Delete{1}
    /// <summary>
    /// use to delete {1} by passing {1} id
    /// </summary>    
    public void Delete{1}(int {2}_id)
    {{
        if ({3}.Delete({2}_id, Handle.ToInt32(Session[""user_id""]), Request.UserHostAddress,Handle.ToInt32(Session[""comp_id""])))
            Response.Write(""1"");
        else
            Response.Write(""0"");
    }}
    #endregion

    #region Get{1}
    /// <summary>
    /// use to get all {1}
    /// </summary>
    public void Get{1}()
    {{
        if (Request.Form[""g{2}_user_id""] != null && !string.IsNullOrEmpty(Request.Form[""g{2}_user_id""]))
        {{
            DataTable dt = {3}.Get{4}_select(Handle.ToInt32(Session[""user_id""]),Handle.ToInt32(Session[""comp_id""]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }}
    }}
    #endregion

    #region Get{1}Log
   /// <summary>
   /// This function is used to get single log view of record
   /// </summary>
    public void Get{1}Log()
    {{
        if (Request.Form[""slv_{2}_id""] != null && !string.IsNullOrEmpty(Request.Form[""slv_{2}_id""]))
        {{
            DataTable dt = {3}.Get{4}Log(Handle.ToInt32(Request.Form[""slv_{2}_id""]),Handle.ToInt32(Session[""comp_id""]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }}
    }}
    #endregion

    #region Get{1}DeletedLog
    /// <summary>
    /// use to get all {1}
    /// </summary>
    public void Get{1}DeletedLog()
    {{
        if (Request.Form[""dlv_{2}_user_id""] != null && !string.IsNullOrEmpty(Request.Form[""dlv_{2}_user_id""]) )
        {{
            DataTable dt = {3}.Get{4}DeletedLog(Handle.ToInt32(Session[""user_id""]),Handle.ToInt32(Session[""comp_id""]));
            String AjaxStr = DAL_Utilities.JSON(dt);
            Response.Write(AjaxStr);
            Response.End();
        }}
    }}
    #endregion

    #endregion
*/
";

        FAspx = String.Format(FAspx, txt_ListPage.Text.Replace(".aspx", ""), txtMenName.Text.Replace(" ", "_"), ColumnPreFix, txt_filedb.Text, txt_filedb.Text.Replace("db_", "_"));
        return FAspx;
    }
    #endregion

    #region CreateDynamicPageLogFile Function
    public String CreateDynamicPageLogFile(String text)
    {
        string obj_name = ddlProject.SelectedItem.Text + "_" + ddlTable.SelectedItem.Text + "_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + "_Log";
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

    ////////////////    

    #region ddlTable_SelectedIndexChanged Event
    /// <summary>
    /// this event used to set names of all new items as per selection
    /// </summary>    
    protected void ddlTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTable.SelectedValue != "0")
        {
            ManageFields();
            string tblnm = ddlTable.SelectedValue;
            txt_spcreate.Text =  "Insert_" + tblnm;
            if (chk_spcreate.Checked == true)
                txt_spwebmethod.Text = "Insert";
            else
                txt_spwebmethod.Text = "";
            txt_spdelete.Text = "Delete_" + tblnm ;
            txt_spupdate.Text = tblnm + "_update";
            txt_spselbyid.Text = tblnm + "_selectby_id";
            txt_spselall.Text = tblnm + "_select_all";
            txt_spsellist.Text = tblnm + "_select";
            txt_splogsellist.Text = tblnm + "_log_select";
            txt_spdellogsellist.Text = tblnm + "_del_log_select";
            txt_fileprop.Text = "PROP_" + tblnm.Replace("i_", "");
            txt_filedb.Text = "BAL_" + tblnm.Replace("i_", "");
            txt_ListPage.Text = "list_" + (((tblnm.Replace("i_", "")).Replace("_mst", "")).Replace("_details", "")).Replace("_detail", "") + ".aspx";
            txt_formPage.Text = "form_" + (((tblnm.Replace("i_", "")).Replace("_mst", "")).Replace("_details", "")).Replace("_detail", "") + ".aspx";
        }
        else
        {
            ClearText();
        }
    }
    #endregion

    #region ddlProject_SelectedIndexChanged Event
    /// <summary>
    /// this event used to set names of all new items as per selection
    /// </summary>    
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTable.Items.Clear();
        ListItem li = new ListItem("Select Table", "0");
        ddlTable.Items.Add(li);
        DataTable dt = new DataTable();
        lblMessage.Text = "";
        try
        {
            dt = db_dynamic_page_urp.GetAllTables(ddlProject.SelectedValue.Split('$')[1]);
        }
        catch
        {
            lblMessage.Text = "Oops, Issue to Connect Database of selected project";
        }
        if (dt.Rows.Count > 0)
        {
            ddlTable.DataSource = dt;
            ddlTable.DataTextField = "name";
            ddlTable.DataValueField = "name";
            ddlTable.DataBind();
        }
    }
    #endregion

    #region ManageFields
    public void ManageFields()
    {
        DataTable dt = db_dynamic_page_urp.GetColumnsByTable(ddlTable.SelectedValue, ddlProject.SelectedValue.Split('$')[1]);
        DataRow[] dr = dt.Select("name not in ('id','comp_id','status','create_by','create_ip','create_dnt','modify_by','modify_ip','modify_dnt')");
        if (dr.Length > 0)
            dt = dr.CopyToDataTable();
        DataView dataview = dt.DefaultView;
        dataview.Sort = "colorder";
        dt = dataview.ToTable();
        RptField.DataSource = dt;
        RptField.DataBind();
        int count = 0;
        int count1 = 1;
        foreach (RepeaterItem ritm in RptField.Items)
        {
            HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm"); //FieldName
            CheckBox chkUnique = (CheckBox)ritm.FindControl("chkUnique");
            CheckBox chkInsertOnly = (CheckBox)ritm.FindControl("chkInsertOnly");
            CheckBox chkAutoGenerated = (CheckBox)ritm.FindControl("chkAutoGenerated");
            TextBox txtLBL = (TextBox)ritm.FindControl("txtLBL");
            DropDownList ddlControlType = (DropDownList)ritm.FindControl("ddlControlType");

            if (count == 0)
            {
                chkUnique.Checked = true;
                chkInsertOnly.Checked = true;
            }
            if (hfnm.Value.ToLower().Contains(("Modify_By").ToLower()) || hfnm.Value.ToLower().Contains(("Modify_ip").ToLower()) || hfnm.Value.ToLower().Contains(("is_delete").ToLower()) || hfnm.Value.ToLower().Contains(("Modify_Date").ToLower()))
            {
                chkInsertOnly.Checked = true;
            }
            txtLBL.Text = "TextBox " + count++.ToString();
            if (count1 > 8)
            {
                count1 = 1;
            }
            ddlControlType.SelectedValue = count1.ToString();
            count1++;
            count++;
        }
    }
    #endregion

    #region CheckIsENM
    protected void CheckIsENM(object sender, EventArgs e)
    {
        RepeaterItem rpt = (RepeaterItem)((CheckBox)sender).Parent;
        rpt.FindControl("txtENMVal").Visible = ((CheckBox)sender).Checked;
    }
    #endregion

    #region ddlControlType_SelectedIndexChanged Event
    protected void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlControlType = (DropDownList)sender;
        CheckBox chkIsExists = (CheckBox)ddlControlType.Parent.FindControl("chkIsExists");
        TextBox txtFunctionInfo = (TextBox)ddlControlType.Parent.FindControl("txtFunctionInfo");
        if (ddlControlType.SelectedValue == "5" || ddlControlType.SelectedValue == "6")
        {
            chkIsExists.Visible = true;
            txtFunctionInfo.Visible = true;
        }
        else
        {
            chkIsExists.Checked = false;
            txtFunctionInfo.Text = "";
            chkIsExists.Visible = false;
            txtFunctionInfo.Visible = false;
        }

    }
    #endregion

    #region chk_spcreate_CheckedChanged
    protected void chk_spcreate_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_spcreate.Checked == true)
        {
            lblwebmethod.Visible = true;
            txt_spwebmethod.Text = "Insert";
        }
        else
        {
            lblwebmethod.Visible = false;
            txt_spwebmethod.Text = "";
        }
    }
    #endregion

    #region function for create Web Method file
    public String CreateWebMethod(String tbl_name, String obj_name)
    {
        obj_name = (obj_name == "" ? "WebMethod_" + tbl_name.Replace("i_", "") : obj_name);
        String ret = "Operation Successfully";
        try
        {
            string root = Server.MapPath("~");
            string filepath = string.Empty;
            if (!Directory.Exists(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\"))
            {
                DirectoryInfo thisFolder1 = new DirectoryInfo(root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\");
                thisFolder1.Create();
            }
            filepath = root + "\\SystemGeneratePages" + "\\" + ddlProject.SelectedItem + "\\" + obj_name + ".txt";


            //string SaveFilePath = root + "\\SystemGeneratePages"+"\\"+"DAL"+"\\"+"DB_Pages"+"\\"+ obj_name + ".cs";
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
                    String WebMethosStr;
                    DataTable dt = db_dynamic_page_urp.GetColumnsByTable(tbl_name, ddlProject.SelectedValue.Split('$')[1]);

                    String WTxt = "Int32 app_version, String android_id, Int32 device_id, Int32 user_id, ";

                    //WTxt= @"{3} PropObj = new {3}();";
                    foreach (RepeaterItem ritm in RptField.Items)
                    {
                        CheckBox chk = (CheckBox)ritm.FindControl("chkRE");
                        HiddenField hfnm = (HiddenField)ritm.FindControl("hid_fnm");

                        if (chk.Checked == false)
                        {
                            WTxt += dt.Rows[0]["datatype"].ToString() + " " + hfnm.Value + ",";
                        }
                    }
                    WTxt = WTxt.Remove(WTxt.Count() - 1, 1);
                    String Para = "Int32 app_version, String android_id, Int32 device_id, Int32 user_id,";
                    foreach (DataRow drw in dt.Rows)
                    {

                        Para += drw["datatype"].ToString() + " " + drw["name"].ToString() + ",";
                        Para += drw["datatype"].ToString() + " " + drw["name"].ToString() + ",";
                    }

                    Para = Para.Remove(Para.Count() - 1, 1);

                    WebMethosStr = @"#region function:Insert
/// <summary>
/// Dynamic Insert Web Method for table " + tbl_name + @"
/// </summary>
[WebMethod]
public Int32 " + obj_name + @"(" + WTxt + @")
{                                        
    Int32 Ret = " + txt_filedb.Text + @".Insert(" + WTxt + @")        
    return Ret;
}
#endregion //endregion-function:" + tbl_name + "";
                    sw.Write(WebMethosStr);
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

    protected void btnFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("form_download_file.aspx");
    }
    protected void txt_tbl_name1_TextChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (Handle.ToInt32(Select_project.Value) == 1)
        {
            //ddlTable.Items.Clear();
            ddlTable.Items.Insert(0, new ListItem(txt_tbl_name1.Text.ToString(), txt_tbl_name1.Text.ToString()));
            ddlTable.SelectedValue = txt_tbl_name1.Text.ToString();
            ddlTable_SelectedIndexChanged(ddlTable, EventArgs.Empty);
        }
        else
        {
            lblMessage.Text = "Oops, Issue to Connect Database of selected project";
        }
    }


}
