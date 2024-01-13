<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="from_to_destination.aspx.cs" Inherits="from_to_destination" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hasta La Vista</title>
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

                                <!-- widget content -->
                                <div class="widget-body">

                                    <div class="form-group">
                                        <asp:Label ID="lblMessage" runat="server" Style="color: red; margin-left: 0px;"></asp:Label>
                                    </div>
                                    <fieldset>
                                        <div runat="server" id="div_main_div">
                                            <div>
                                                <label style="float: left; margin-left: 10px;">Name</label>
                                                <div style="float: left; margin-left: 10px;">
                                                    <asp:TextBox ID="txt_tbl_name" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div>
                                                <label style="float: left; margin-left: 10px;">Connection String</label>
                                                <div style="float: left; margin-left: 10px;">
                                                    <asp:TextBox ID="txt_constring" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <asp:Label ID="lbl_ret" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_ret1" runat="server"></asp:Label>
                                            <asp:TextBox ID="txt_tbl_name2" runat="server" TextMode="MultiLine" Height="500px" Width="500px" Visible="false"></asp:TextBox>
                                            <asp:Button ID="TEST" runat="server" Text="TEST" class="btn btn-primary" OnClick="TEST_Click" />

                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table id="tbl_don" border="1" cellpadding="0" cellspacing="0" style="border-color: Black; width: 50%">
                                                        <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                                                            <td>Check</td>
                                                            <td>ALTER / CREATE</td>
                                                            <td>Module Name</td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chl_value" runat="server" Checked="true"/></td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rdo_type" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="0" Selected="True">Create</asp:ListItem>
                                                                <asp:ListItem Value="1">Alter</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td>
                                                            <asp:Label ID="lbl_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.name")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_err_msg" runat="server" Text=""></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <asp:Button ID="SUBMIT" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="SUBMIT_Click" />
                                        </div>
                                        <div runat="server" id="div_create_new_div" visible="false">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Label Name</label>
                                                <div class="col-md-4" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <asp:TextBox ID="txt_lbl_name" runat="server" Width="500px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Method Name</label>
                                                <div class="col-md-4" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <asp:TextBox ID="txt_method_name" runat="server" Width="500px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Id By Name (TEXTBOXID)</label>
                                                <div class="col-md-4" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <asp:TextBox ID="txt_id_by_name" runat="server" Width="500px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Ids By Name (TEXTBOXID)</label>
                                                <div class="col-md-4" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <asp:TextBox ID="txt_ids_name" runat="server" Width="500px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <asp:Button Id="add_new" runat="server" OnClick="add_new_Click" Text="Submit"/>
                                        </div>
                                    </fieldset>
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
