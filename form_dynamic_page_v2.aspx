<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_dynamic_page_v2.aspx.cs" Inherits="form_dynamic_page_v2" %>

<%@ Register Src="~/WebHeader.ascx" TagPrefix="uc1" TagName="WebHeader" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Other Functionally</title>
    <link runat="server" rel="shortcut icon" href="logo_infinityinfoway.com.png" type="image/x-icon" />
    <link runat="server" rel="icon" href="logo_infinityinfoway.com.png" type="image/ico" />
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
        <!-- MAIN CONTENT -->
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
                                <%--<h2>Dynamic Page Jitendran 21032017</h2>--%>
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

                                <uc1:WebHeader runat="server" ID="WebHeader" />

                                <h2>Other Functionally</h2>
                                <asp:Label ID="ErrorMsg" runat="server" Style="color: red"></asp:Label>
                                <!-- widget content -->
                                <div class="widget-body">
                                    Select Project <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlProject" runat="server"
                                        AppendDataBoundItems="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select Project</asp:ListItem>
                                        <asp:ListItem Value="infilog_ierp$Data Source=192.168.30.70;Initial Catalog=infiprod_ierp;User ID=proj_ierp;Password=9HyBsnFV47Q542x9tr;Application Name=iERP">infiprod_ierp</asp:ListItem>
                                        <asp:ListItem Value="CMS_EXAM_NEW_LOG$Data Source=192.168.30.167;Initial Catalog=CMS_EXAM_NEW;Integrated Security=False; User Id=krunalg; Password=krunalg;Max Pool Size = 1000">NEP - ERP</asp:ListItem>
                                    </asp:DropDownList><hr>
                                    Select Functionally<asp:DropDownList ID="grid" runat="server" AutoPostBack="true" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select One....</asp:ListItem>
                                        <asp:ListItem Value="1">Print Page</asp:ListItem>
                                        <asp:ListItem Value="2">Function Page - ERP</asp:ListItem>
                                        <asp:ListItem Value="4">Function Page - URP</asp:ListItem>
                                        <asp:ListItem Value="3">Excel Export</asp:ListItem>
                                        <asp:ListItem Value="5">For New Param Sp String</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="form-group">
                                        <asp:Label ID="lblMessage" runat="server" Style="color: red; margin-left: 0px;"></asp:Label>
                                        <asp:HiddenField ID="hid_id_by_name" runat="server" />
                                        <asp:HiddenField ID="hid_ids_by_name" runat="server" />
                                        <asp:HiddenField ID="hid_method_name" runat="server" />
                                        <asp:HiddenField ID="hid_lbl_name" runat="server" />
                                        <asp:HiddenField ID="hid_lbl_id" runat="server" />
                                        <asp:HiddenField ID="hid_create_click" runat="server" Value="0" />
                                    </div>
                                    <div id="div_print_page" runat="server" visible="false">
                                        <fieldset style="margin-bottom: 50px">
                                            <legend>&nbsp;&nbsp;Create Print Page:&nbsp;&nbsp;</legend>
                                            <div runat="server">

                                                <div runat="server" style="margin-bottom: 20px">
                                                    <label style="float: left; margin-left: 10px;">Page Name : </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox runat="server" ID="txt_file_name"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:HyperLink ID="HyperLink1" runat="server">SSS</asp:HyperLink>
                                                <div runat="server" style="margin-bottom: 20px">
                                                    <label style="float: left; margin-left: 10px;">Label Type : </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddl_lbl_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_lbl_type_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Selected="True">Select Type</asp:ListItem>
                                                            <asp:ListItem Value="4">Date</asp:ListItem>
                                                            <asp:ListItem Value="1">Auto Suggest</asp:ListItem>
                                                            <asp:ListItem Value="2">MultiSelection</asp:ListItem>
                                                            <asp:ListItem Value="3">DropDown</asp:ListItem>
                                                            <asp:ListItem Value="5">Radio Button</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="list_item" runat="server" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div runat="server" id="div_method" visible="false">
                                                    <label style="float: left; margin-left: 10px;">Method Name</label>
                                                    <div style="float: left; margin-left: 10px;">
                                                        <asp:DropDownList ID="ddl_method_name" runat="server" OnSelectedIndexChanged="method_name_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:Button ID="add_new_method_name" Visible="false" runat="server" Text="Add New Method Name" OnClientClick="open_new_tab()" />
                                                    </div>
                                                </div>
                                                <label style="float: left; margin-left: 10px;">Label Name : </label>
                                                <asp:TextBox runat="server" ID="txt_lbl_name"></asp:TextBox>
                                                <div class="form-actions">
                                                    <div class="row">
                                                        <div class="col-md-12" style="text-align: center;">
                                                            <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-primary" OnClick="btnAdd_Click" />
                                                            <%--    <asp:Button ID="btnFile" runat="server" Text="Send File" class="btn btn-primary"
                                                     ValidationGroup="nothing" />--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Repeater ID="RptField" runat="server" OnItemCommand="RptField_ItemCommand">
                                                    <HeaderTemplate>
                                                        <table id="tbl_don" border="1" cellpadding="0" cellspacing="0" style="border-color: Black; width: 50%">
                                                            <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                                                                <td>Label Name</td>
                                                                <td>Label Type</td>
                                                                <td>Method Name</td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.Label_Name")%></td>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.Label_Type")%></td>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.Method_Name")%></td>
                                                            <asp:HiddenField ID="hid_IdByName" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.IdByName")%>' />
                                                            <asp:HiddenField ID="hid_IdsByName" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.IdsByName")%>' />
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <div class="form-actions">
                                                    <div class="row">
                                                        <div class="col-md-12" style="text-align: center;">
                                                            <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-primary" OnClick="Create_Click" />
                                                            <%--    <asp:Button ID="btnFile" runat="server" Text="Send File" class="btn btn-primary"
                                                     ValidationGroup="nothing" />--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>

                                    </div>
                                    <div id="div_function" runat="server" visible="false">
                                        <fieldset>
                                            <legend>&nbsp;&nbsp;Create Function:&nbsp;&nbsp;</legend>
                                            Function Type <asp:DropDownList ID="ddl_func_type" runat="server">
                                                <asp:ListItem Value="0" Selected="True">Select Type</asp:ListItem>
                                                <asp:ListItem Value="1">Return Object</asp:ListItem>
                                                <asp:ListItem Value="2">DataTable</asp:ListItem>
                                                <asp:ListItem Value="3">DataSet</asp:ListItem>
                                                <asp:ListItem Value="4">String</asp:ListItem>
                                                <asp:ListItem Value="5">Boolean</asp:ListItem>
                                                <asp:ListItem Value="6">Int</asp:ListItem>
                                                <asp:ListItem Value="7">DateTime</asp:ListItem>
                                                <asp:ListItem Value="7">None(Void)</asp:ListItem>
                                            </asp:DropDownList><hr />
                                            SP Name<asp:TextBox ID="txt_ierp_sp_name" Width="30%" Height="20px" runat="server" AutoPostBack="true" OnTextChanged="txt_ierp_sp_name_TextChanged"></asp:TextBox>
                                            <hr />
                                            Function Name<asp:TextBox ID="txt_func_name" Width="30%" Height="20px" runat="server"></asp:TextBox>
                                            <span style="color: red"></span>
                                            <asp:Button ID="btn_redirect" Visible="false" Text="Show Example" runat="server" OnClientClick="RedirectURL()" /><hr />
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="550px" Width="500px" PlaceHolder="ALTER PROCEDURE [dbo].[i_stor_purchase_challan_grn_register_report_with_batch_details]
@from_date datetime,
@to_date datetime,
@item_ids varchar(150),
@ven_ids varchar(150),
@com_id bigint"></asp:TextBox>
                                            <asp:Button ID="Create_Func" runat="server" Text="Create" OnClick="Create_Func_Click1" />
                                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="550px" Width="500px"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div id="div_function_urp" runat="server" visible="false">
                                        <fieldset>
                                            <legend>&nbsp;&nbsp;Create Function:&nbsp;&nbsp;</legend>
                                            Function Type <asp:DropDownList ID="ddl_func_type_urp" runat="server">
                                                <asp:ListItem Value="0" Selected="True">Select Type</asp:ListItem>
                                                <asp:ListItem Value="1">Return Object</asp:ListItem>
                                                <asp:ListItem Value="2">DataTable</asp:ListItem>
                                                <asp:ListItem Value="3">DataSet</asp:ListItem>
                                                <asp:ListItem Value="4">String</asp:ListItem>
                                                <asp:ListItem Value="5">Boolean</asp:ListItem>
                                                <asp:ListItem Value="6">Int</asp:ListItem>
                                            </asp:DropDownList><hr />
                                            SP Name<asp:TextBox ID="txt_urp_sp_name" Width="30%" Height="20px" runat="server" AutoPostBack="true" OnTextChanged="txt_urp_sp_name_TextChanged"></asp:TextBox><hr />
                                            Function Name<asp:TextBox ID="txt_func_name_urp" Width="30%" Height="20px" runat="server"></asp:TextBox>
                                            <span style="color: red"></span>
                                            <asp:Button ID="Button1" Visible="false" Text="Show Example" runat="server" OnClientClick="RedirectURL()" /><hr />
                                            <asp:TextBox ID="TextBox2_urp" runat="server" TextMode="MultiLine" Height="550px" Width="500px" PlaceHolder="ALTER PROCEDURE [dbo].[i_stor_purchase_challan_grn_register_report_with_batch_details]
@from_date datetime,
@to_date datetime,
@item_ids varchar(150),
@ven_ids varchar(150),
@com_id bigint"></asp:TextBox>
                                            <asp:Button ID="Create_Func_URP" runat="server" Text="Create" OnClick="Create_Func_URP_Click" />
                                            <asp:TextBox ID="TextBox1_urp" runat="server" TextMode="MultiLine" Height="550px" Width="500px"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div id="div_excel_export" runat="server" visible="false">
                                        <fieldset>
                                            <legend>&nbsp;&nbsp;Create Special Export:&nbsp;&nbsp;</legend>
                                            <div style="display: flex">
                                                <div>
                                                    <asp:TextBox ID="txt_str" runat="server" TextMode="MultiLine" Height="150px" PlaceHolder="ALTER procedure [dbo].[i_stor_purchase_challan_grn_register_report_with_batch_details]
@from_date datetime,
@to_date datetime,
@item_ids varchar(150),
@ven_ids varchar(150),
@com_id bigint"
                                                        Width="500px"></asp:TextBox><hr />
                                                    <asp:Button ID="btn_get_col" runat="server" Text="Get Columns" OnClick="btn_get_col_Click" />
                                                </div>
                                                <div style="margin-left: 100px">

                                                    <asp:CheckBoxList ID="chk_columns" CssClass="chk" runat="server" OnSelectedIndexChanged="chk_columns_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:CheckBoxList><hr />
                                                    <div runat="server" id="div_NEW" visible="false">
                                                        <asp:TextBox ID="txt_dt_name" PlaceHolder="DB.FunctionName" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox><hr />
                                                        <asp:TextBox ID="txt_Export_STr" runat="server" TextMode="MultiLine" Height="150px" Width="500px"></asp:TextBox><hr />
                                                        <asp:Button ID="btn_Export" runat="server" Text="Export" OnClick="btn_Export_Click" />
                                                    </div>

                                                </div>
                                                <div>
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="tbl_don" border="1" cellpadding="0" cellspacing="0" style="border-color: Black; width: 50%">
                                                                <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                                                                    <td>Column Name</td>
                                                                    <td>Is Group</td>
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl_col_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.col_name")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:CheckBox ID="chk_Group" runat="server" /><asp:TextBox ID="txt_chk_value" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.txt_chk_value")%>'></asp:TextBox></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <asp:Button ID="btn_grp_Export" runat="server" Text="Group Export" OnClick="btn_grp_Export_Click" Visible="true" />
                                                </div>
                                            </div>

                                            <%--<asp:TextBox ID="txt_str_export" runat="server" TextMode="MultiLine" Height="550px" Width="500px"></asp:TextBox>--%>
                                        </fieldset>
                                    </div>
                                    <div id="divFornewParamSP" runat="server" visible="false">
                                        <asp:TextBox ID="txt_For_New_Field" PlaceHolder="@itm_is_non_mrp bigint,
@itm_packing_type_id bigint,
@itm_tariff_head_no varchar(max)
"
                                            Height="500px" Width="500px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Button ID="btnCreateStrings" runat="server" Text="Create" OnClick="btnCreateStrings_Click" Visible="true" />
                                        <asp:TextBox ID="GeneratedScripts" PlaceHolder="/* For Insert */
@itm_is_non_mrp bigint,
@itm_packing_type_id bigint,
@itm_tariff_head_no varchar(max)

itm_is_non_mrp,
itm_packing_type_id,
itm_tariff_head_no,

@itm_is_non_mrp,
@itm_packing_type_id,
@itm_tariff_head_no,

 /* For Update */ 
@itm_is_non_mrp bigint,
@itm_packing_type_id bigint,
@itm_tariff_head_no varchar(max)

itm_is_non_mrp=@itm_is_non_mrp,
itm_packing_type_id=@itm_packing_type_id,
itm_tariff_head_no=@itm_tariff_head_no,

 /* For Select By Id */
itm_is_non_mrp,
itm_packing_type_id,
itm_tariff_head_no,
"
                                            Height="500px" Width="500px" runat="server" TextMode="MultiLine"></asp:TextBox>
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
