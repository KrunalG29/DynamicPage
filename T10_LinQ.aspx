<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T10_LinQ.aspx.cs" Inherits="Tutorials.Practice.T10_LinQ" %>

<%@ Register Src="~/WebHeader.ascx" TagPrefix="uc1" TagName="WebHeader" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinQ Examples</title>
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">--%>
    <script type="text/javascript">
        function myFunction() {
            /* Get the text field */
            var copyText = document.getElementById("TextBox2");

            /* Select the text field */
            copyText.select();
            copyText.setSelectionRange(0, 99999);/* For mobile devices */

            /* Copy the text inside the text field */
            document.execCommand("copy");
            document.getElementById("btn_copy").classList.remove('btn-outline-success');
            document.getElementById("btn_copy").classList.add('btn-outline-warning');
            alert("Function Code Copied To Clipboard");
            window.open("T10_LinQ.aspx", "_self");
        }
    </script>
</head>
<body>
   
    <form id="form1" runat="server" style="margin: 100px">
       
        <uc1:WebHeader runat="server" ID="WebHeader" />
    <h2>LinQ Examples</h2>
        <div>
            <div runat="server" style="margin-bottom: 20px; float: left">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="1">Get All Data</asp:ListItem>
                    <asp:ListItem Value="2">Get Top 1</asp:ListItem>
                    <asp:ListItem Value="3">Order By</asp:ListItem>
                    <asp:ListItem Value="6">Sum</asp:ListItem>
                    <asp:ListItem Value="4">Group By Single Column <b>(Sum)</b></asp:ListItem>
                    <asp:ListItem Value="5">Group By Multiple Column <b>(Sum)</b></asp:ListItem>
                    <asp:ListItem Value="7">Group By Single Column<b>(Count)</b></asp:ListItem>
                    <asp:ListItem Value="8">Group By Multiple Column <b>(Count)</b></asp:ListItem>
                    <asp:ListItem Value="9">Left Join</asp:ListItem>
                </asp:RadioButtonList>
                <hr />
                <br />
                <asp:Label ID="lbl_que" runat="server" Font-Bold="true" Visible="false"></asp:Label>
            </div>
            <div style="float: right">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lbl_date" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Code">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_code" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_code")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Of Birth">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_dob")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="lbl_date" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_department")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_code" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_salary")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_city")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.emp_state")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView3" runat="server" class="table table-striped" Visible="false" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_date" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_code" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.user_code")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lbl_emp_name" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.user_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.user_pass")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div runat="server" style="margin-bottom: 20px">
            <asp:GridView ID="GridView1" runat="server" class="table table-striped">
            </asp:GridView>
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <div id="div_getcode" runat="server" style="margin-bottom: 20px" visible="false">
            <asp:Button class="btn btn-outline-primary" runat="server" ID="btnGetCode" OnClick="btnGetCode_Click" Text="GetCode" />
            <span class="btn btn-outline-success" runat="server" id="btn_copy" onclick="myFunction();">Copy</span>
        </div>
        <div runat="server" style="margin-bottom: 20px">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="550px" Width="800px" Visible="false"></asp:TextBox>
        </div>

    </form>
</body>
</html>
