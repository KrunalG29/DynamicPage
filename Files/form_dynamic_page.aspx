<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_dynamic_page.aspx.cs" Inherits="form_dynamic_page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WebHeader.ascx" TagPrefix="uc1" TagName="WebHeader" %>


<!DOCTYPE html>

<html>
<head>
    <link runat="server" rel="shortcut icon" href="logo_infinityinfoway.com.png" type="image/x-icon" />
    <link runat="server" rel="icon" href="logo_infinityinfoway.com.png" type="image/ico" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <title>Generate Dynamic Page iERP Theme</title>
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
        $(document).ready(function () {
            show_loader();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(show_loader);
        });
        function show_loader() {
            $(document).ajaxSend(function () {
                $('[id*=UpdateProgress]').show();
            });
            $(document).ajaxComplete(function () {
                $('[id*=UpdateProgress]').hide();
            });
        }
        document.onreadystatechange = function () {
            if (document.readyState !== "complete") {
                $('#preloader').show();
                $('#UpdateProgress').show();
            }
            else if (document.readyState === "complete") {

                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_initializeRequest(initializeRequest);
                prm.add_endRequest(endRequest);

                var _postBackElement;

                function initializeRequest(sender, e) {
                    _postBackElement = e.get_postBackElement();
                }

                function endRequest(sender, e) {
                    if (_postBackElement) {

                    }
                }
                $('#UpdateProgress').hide();
            }
        };
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

        /*Page Loader Css*/
        #preloader {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            /*display: none;*/
            z-index: 9999 !important;
        }

        #loader {
            display: block;
            position: relative;
            left: 50%;
            top: 50%;
            width: 150px;
            height: 150px;
            margin: -75px 0 0 -75px;
            border-radius: 50%;
            border: 3px solid transparent;
            border-top-color: #9370DB;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
            z-index: 9999 !important;
        }

            #loader:before {
                content: "";
                position: absolute;
                top: 5px;
                left: 5px;
                right: 5px;
                bottom: 5px;
                border-radius: 50%;
                border: 3px solid transparent;
                border-top-color: #BA55D3;
                -webkit-animation: spin 3s linear infinite;
                animation: spin 3s linear infinite;
                z-index: 9999 !important;
            }

            #loader:after {
                content: "";
                position: absolute;
                top: 15px;
                left: 15px;
                right: 15px;
                bottom: 15px;
                border-radius: 50%;
                border: 3px solid transparent;
                border-top-color: #FF00FF;
                -webkit-animation: spin 1.5s linear infinite;
                animation: spin 1.5s linear infinite;
                z-index: 9999 !important;
            }

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
                -ms-transform: rotate(0deg);
                transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
                -ms-transform: rotate(360deg);
                transform: rotate(360deg);
            }
        }

        @keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
                -ms-transform: rotate(0deg);
                transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
                -ms-transform: rotate(360deg);
                transform: rotate(360deg);
            }
        }
        /*Page Loader Css Over*/
    </style>
</head>
<body>
    <form runat="server">
        <asp:UpdateProgress ID="UpdateProgress" runat="server">
            <ProgressTemplate>
                <div id="preloader">
                    <div id="loader"></div>
                </div>
                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.35;">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
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
                                    <uc1:WebHeader runat="server" ID="WebHeader" />
                                    <h2>Generate Dynamic Page iERP Theme</h2>

                                    <fieldset>
                                        <div>
                                            <label style="float: left;">Project Name</label>
                                            <div style="float: left; margin-left: 10px;">
                                                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlProject" runat="server"
                                                    AppendDataBoundItems="true"
                                                    OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select Project</asp:ListItem>
                                                    <asp:ListItem Value="infilog_ierp$Data Source=192.168.30.70;Initial Catalog=infiprod_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP">infiprod_ierp</asp:ListItem>
                                                    <%--<asp:ListItem Value="studymaterial_vikalp$Data Source=4.240.123.71;Initial Catalog=infiprod_vrl;User ID=sa;Password=GpIC4yVNAwZjFFv;Application Name=iERP">Local</asp:ListItem>--%>
                                                    <%--<asp:ListItem Value="infilog_ierp$Data Source=192.168.30.70;Initial Catalog=infilog_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP">infilog_ierp</asp:ListItem>--%>
                                                    <asp:ListItem Value="CMS_EXAM_NEW_LOG$Data Source=192.168.30.167;Initial Catalog=CMS_EXAM_NEW;Integrated Security=False; User Id=krunalg; Password=krunalg;Max Pool Size = 1000">NEP - ERP</asp:ListItem>
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
