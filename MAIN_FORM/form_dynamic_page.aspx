<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_dynamic_page.aspx.cs" Inherits="form_dynamic_page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html>
<head>
    <link runat="server" rel="shortcut icon" href="logo_infinityinfoway.com.png" type="image/x-icon" />
    <link runat="server" rel="icon" href="logo_infinityinfoway.com.png" type="image/ico" />
    <title>Create Dynamic Page</title>
    <script>

        function SetContextKey(source, e) {
            debugger;
            var dropdown = document.getElementById('ddlProject').value;
            var Select_project = document.getElementById('Select_project').value;
            if (dropdown.split('$').length >= 1) {
                source.set_contextKey(dropdown);
                document.getElementById('Select_project').value = '1';
            }
            else {
                document.getElementById('Select_project').value = '0';
            }
        }
    </script>
    <style>
        .listMain {
            border: solid 1px #66afe9;
            background-color: #ecf7ff;
            padding: 0;
            list-style: none;
            margin: 0;
            height: 300px;
            overflow: auto;
            width: 500px !important;
            min-width: 500px !important;
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #333;
            font-size: 13px;
            font-weight: 400;
            z-index: 100;
            text-align: left
        }

        .listMainMS {
            border: solid 1px #6ba2de;
            padding: 0;
            list-style: none;
            margin: 0;
            height: 300px;
            overflow: auto;
            width: 300px !important;
            font-family: Calibri;
            color: #000;
            font-weight: 700;
            background: #fff;
            z-index: 100;
            text-align: left
        }

        .itemsMain {
            background-color: #ecf7ff;
            padding: 5px;
            list-style: none;
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #333;
            font-size: 13px;
            font-weight: 400;
            cursor: pointer;
            z-index: 100
        }

        .itemsSelected {
            background: #1083ea;
            border: solid 1px #66afe9;
            padding: 5px;
            list-style: none;
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #fff;
            font-size: 13px;
            font-weight: 700;
            cursor: pointer
        }
    </style>
</head>
<body>
    <form runat="server">
        <style>
            .msgclass {
            }

                .msgclass input[type="text"] {
                    font-weight: bold;
                    color: mediumvioletred;
                }
        </style>
        <!-- MAIN CONTENT -->
        <div id="content">
            <div class="row">
            </div>
            <!-- widget grid -->
            <section id="widget-grid" class="">
                <!-- row -->
                <div class="row">

                    <!-- NEW WIDGET START -->
                    <article class="col-sm-12 col-md-12 col-lg-12">

                        <!-- Widget ID (each widget will need unique ID)-->
                        <div class="jarviswidget " id="wid-id-0" data-widget-sortable="false" data-widget-deletebutton="false" data-widget-togglebutton="false" data-widget-editbutton="false">
                            <header>
                                <span class="widget-icon"><i class="fa fa-eye"></i></span>
                                <h2>Dynamic Page Jitendran 21032017</h2>
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="10000" EnablePageMethods="true"></asp:ScriptManager>
                                <asp:HiddenField ID="Select_project" runat="server" Value="0" />
                            </header>
                            <!-- widget div-->
                            <div>

                                <!-- widget edit box -->
                                <div class="jarviswidget-editbox">
                                    <!-- This area used as dropdown edit box -->

                                </div>
                                <!-- end widget edit box -->

                                <!-- widget content -->
                                <div class="widget-body">

                                    <div class="form-group">
                                        <asp:Label ID="lblMessage" runat="server" Style="color: red; margin-left: 0px;"></asp:Label>
                                    </div>

                                    <fieldset>
                                        <div>
                                            <label style="float: left;">Project Name</label>
                                            <div style="float: left; margin-left: 10px;">
                                                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlProject" runat="server"
                                                    AppendDataBoundItems="true"
                                                    OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select Project</asp:ListItem>
                                                    <asp:ListItem Value="infiprod_ierp$Data Source=192.168.30.70;Initial Catalog=infiprod_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP">infiprod_ierp</asp:ListItem>
                                                    <asp:ListItem Value="infilog_ierp$Data Source=192.168.30.70;Initial Catalog=infilog_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP">infilog_ierp</asp:ListItem>
                                                    <asp:ListItem Value="conERPProd$Data Source=DESKTOP-9OIC7LF;Initial Catalog=State;Integrated Security=True">DEMO</asp:ListItem>
                                                    <asp:ListItem Value="CMS_EXAM_NEW$Data Source=192.168.30.3;Initial Catalog=CMS_EXAM_NEW;Integrated Security=False; User Id=kevalv; Password=Welcome_IIPL;Max Pool Size = 1000">URP</asp:ListItem>

                                                </asp:DropDownList>
                                                <span class="red_star">*</span>
                                                <asp:RequiredFieldValidator CssClass="error_messe" ID="RequiredFieldValidator1" Display="dynamic"
                                                    runat="server" ErrorMessage="Please select project" InitialValue="0" ControlToValidate="ddlProject"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div runat="server" id="auto_tbl_name1" visible="true">
                                            <label style="float: left; margin-left: 10px;">Table Name</label>
                                            <div style="float: left; margin-left: 10px;">
                                                <asp:TextBox ID="txt_tbl_name1" Width="350" runat="server" CssClass="form-control" ClientIDMode="AutoID" Placeholder="Type and select" AutoPostBack="true" OnTextChanged="txt_tbl_name1_TextChanged">
                                                </asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender FirstRowSelected="true" ID="AutoCompleteExtender1" runat="server" ServicePath="~/Web_Service.asmx"
                                                    ServiceMethod="get_tbl_name1" TargetControlID="txt_tbl_name1" MinimumPrefixLength="1" ClientIDMode="AutoID"
                                                    CompletionListCssClass="listMain" EnableCaching="false" CompletionListHighlightedItemCssClass="itemsSelected"
                                                    CompletionListItemCssClass="itemsMain" UseContextKey="true" ContextKey="0" OnClientPopulating="SetContextKey">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </div>
                                        </div>
                                        <div>
                                            <label style="float: left; margin-left: 10px;">Table Name</label>
                                            <div style="float: left; margin-left: 10px;">
                                                <asp:DropDownList Width="350" CssClass="form-control" AutoPostBack="true" ID="ddlTable" runat="server"
                                                    AppendDataBoundItems="true"
                                                    OnSelectedIndexChanged="ddlTable_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select Table</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="red_star">*</span>
                                                <asp:RequiredFieldValidator CssClass="error_messe" ID="rbranch" Display="dynamic"
                                                    runat="server" ErrorMessage="Please select table" InitialValue="0" ControlToValidate="ddlTable"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div>
                                            <label style="float: left; margin-left: 10px;">Menu Name</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtMenName" Style="float: left; margin-left: 10px;" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div style="clear: both; float: none; width: auto;"></div>
                                        <div>
                                            <asp:Repeater ID="RptField" runat="server">
                                                <HeaderTemplate>
                                                    <table border="1" cellpadding="0" cellspacing="0" style="border-color: Black;">
                                                        <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                                                            <td colspan="16">Field Info of selected table </td>
                                                        </tr>
                                                        <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                                                            <td>Name</td>
                                                            <td>Data Type</td>
                                                            <td>Size</td>
                                                            <td>User Input Not Req?</td>
                                                            <td>Is Mandatory?</td>
                                                            <td>Is Enum?</td>
                                                            <td>Label</td>
                                                            <td>Entry Control</td>
                                                            <td>Is Function Exists?</td>
                                                            <td>Function Info</td>
                                                            <td>Allow Null?</td>
                                                            <td>Default Value</td>
                                                            <td>Function Help</td>
                                                            <td>Check Unique ?</td>
                                                            <td>Insert Only ?</td>
                                                            <td>Auto Generated ?</td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#DataBinder.Eval(Container,"DataItem.Name")%></td>
                                                        <asp:HiddenField ID="hid_fnm" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.Name")%>' />
                                                        <td><%#DataBinder.Eval(Container,"DataItem.datatype")%></td>
                                                        <asp:HiddenField ID="hid_datatype" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.datatype")%>' />
                                                        <td><%#DataBinder.Eval(Container,"DataItem.size")%></td>
                                                        <asp:HiddenField ID="hid_size" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.size")%>' />
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkRE" /></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ChkIsComp" /></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkIEN" AutoPostBack="true" OnCheckedChanged="CheckIsENM" />
                                                            <asp:TextBox ID="txtENMVal" runat="server" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtLBL"></asp:TextBox></td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlControlType" AutoPostBack="true" OnSelectedIndexChanged="ddlControlType_SelectedIndexChanged" AppendDataBoundItems="true">
                                                                <asp:ListItem Text="Select Control Type" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="TextBox(String)" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="TextBox(Multiline)" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="TextBox(Numeric)" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="TextBox(DateTime)" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="TextBox(AutoSuggest)" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="DropDown" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="CheckBox" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="Radio" Value="8"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkIsExists" Visible="false" /></td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtFunctionInfo" Visible="false" TextMode="MultiLine"></asp:TextBox></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkPropNullable" Checked="true" /></td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtDefault" TextMode="SingleLine"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtFunctionHelp" Visible="false" TextMode="MultiLine"></asp:TextBox></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkUnique" /></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkInsertOnly" /></td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkAutoGenerated" /></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div id="msg" runat="server" class="msgclass">
                                            <table style="text-align: left;">
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chk_ltbl" runat="server"
                                                            Text="Create Log Table" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkSynonym" runat="server"
                                                            Text="Create Log Table Synonym" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_ltgr" Text="Create Trigger" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            <asp:CheckBox runat="server" ID="chk_spcreate"
                                                                Text="Create Procedure for Insert with name" AutoPostBack="true"
                                                                OnCheckedChanged="chk_spcreate_CheckedChanged" />
                                                            </lable>
                                                            <asp:TextBox ID="txt_spcreate" runat="server" BorderStyle="None" Width="400"></asp:TextBox>

                                                            <label id="lblwebmethod" runat="server" visible="false">
                                                                <asp:CheckBox runat="server" ID="chk_spwebmethod"
                                                                    Text="Create Procedure for Insert Web method" AutoPostBack="true" /></label>
                                                            <asp:TextBox ID="txt_spwebmethod" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>


                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spdelete"
                                                            Text="Create Procedure for Delete with name" />
                                                        <asp:TextBox ID="txt_spdelete" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spupdate"
                                                            Text="Create Procedure for Update with name" />
                                                        <asp:TextBox ID="txt_spupdate" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spselbyid"
                                                            Text="Create Procedure for select by id with name" />
                                                        <asp:TextBox ID="txt_spselbyid" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spselall"
                                                            Text="Create Procedure for Select all with name" />
                                                        <asp:TextBox ID="txt_spselall" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spsellist"
                                                            Text="Create Procedure for select with name" />
                                                        <asp:TextBox ID="txt_spsellist" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_splogsellist"
                                                            Text="Create Procedure for log select with name" />
                                                        <asp:TextBox ID="txt_splogsellist" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_spdellogsellist"
                                                            Text="Create Procedure for deleted log select with name" />
                                                        <asp:TextBox ID="txt_spdellogsellist" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_fileprop" Text="Create PROPERTY File with name" />
                                                        <asp:TextBox ID="txt_fileprop" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chk_filedb"
                                                            Text="Create DB Function File with name" />
                                                        <asp:TextBox ID="txt_filedb" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkListPage"
                                                            Text="Create Listing Page File with name" />
                                                        <asp:TextBox ID="txt_ListPage" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkFormPage"
                                                            Text="Create Form Page File with name" />
                                                        <asp:TextBox ID="txt_formPage" runat="server" BorderStyle="None" Width="400"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </fieldset>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-12" style="text-align: center;">
                                                <asp:Button ID="btnSave" runat="server" Text="Create" class="btn btn-primary"
                                                    OnClick="btnSave_Click" />
                                                <asp:Button ID="btnFile" runat="server" Text="Send File" class="btn btn-primary"
                                                    OnClick="btnFile_Click" ValidationGroup="nothing" />
                                            </div>
                                        </div>
                                    </div>


                                </div>
                                <!-- end widget content -->

                            </div>
                            <!-- end widget div -->

                        </div>
                        <!-- end widget -->




                    </article>
                    <!-- WIDGET END -->


                </div>
                <!-- end row -->
            </section>
            <!-- end widget grid -->
        </div>
        <!-- END MAIN CONTENT -->
    </form>
</body>
</html>
