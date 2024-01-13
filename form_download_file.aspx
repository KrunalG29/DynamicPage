<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_download_file.aspx.cs" Inherits="form_download_file" %>

<%@ Register Src="~/WebHeader.ascx" TagPrefix="uc1" TagName="WebHeader" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Mail Generated Files</title>
    <link runat="server" rel="shortcut icon" href="logo_infinityinfoway.com.png" type="image/x-icon" />
    <link runat="server" rel="icon" href="logo_infinityinfoway.com.png" type="image/ico" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
</head>
<body>


    <form id="form1" runat="server">
        <uc1:WebHeader runat="server" ID="WebHeader" />
       
        <h2>Send Dynamic Page Files</h2>

        <div>
            <asp:Repeater ID="RptField" runat="server" OnItemCommand="RptField_ItemCommand">
                <HeaderTemplate>
                    <table id="tbl_don" border="1" cellpadding="0" cellspacing="0" style="border-color: Black; width: 50%">
                        <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                            <td colspan="5">Dynamic Create Form Info</td>
                        </tr>
                        <tr style="font-family: cambria; background-color: Gray; font-size: 15px; font-style: italic; font-weight: 700; text-align: center;">
                            <td>Table Name</td>
                            <td>Create By</td>
                            <td>Email Address</td>
                            <%--<td>Download</td>--%>
                            <td>Send Mail</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container,"DataItem.table_name")%></td>
                        <td><%#DataBinder.Eval(Container,"DataItem.create_by")%></td>
                        <td>
                            <asp:TextBox ID="txt_to_mail" runat="server" CssClass="form-control" Text='<%#DataBinder.Eval(Container,"DataItem.to_mail")%>' Style="text-align: right;"></asp:TextBox>
                        </td>
                        <asp:HiddenField ID="hid_fnm" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.folder_name")%>' />
                        <%--<td>
                            <asp:LinkButton runat="server" ID="lnk_download" CommandName="lnk_download"><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton></td>--%>
                        <td>
                            <asp:LinkButton runat="server" ID="lnk_send" CommandName="lnk_send_mail"><i class="fa fa-paper-plane" aria-hidden="true"></i></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
