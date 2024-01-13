<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spcallhistory.aspx.cs" Inherits="iipl.erph.spcallhistory" %>

<%@ Register Src="~/WebHeader.ascx" TagPrefix="uc1" TagName="WebHeader" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Log SP Call History</title>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>
    <script type="text/javascript">
        function copyText(id) {
            document.getElementById(id).innerHTML;
            document.execCommand('copy');
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebHeader runat="server" ID="WebHeader" />
        <div class="container" style="display:flex">
            <div class="col-lg-6">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="500px" Width="500px"> </asp:TextBox><br />
                <asp:CheckBox runat="server" ID="chk" Text="Copy to Clipboard" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="convert" CssClass="btn btn-primary" OnClick="Unnamed1_Click" />
            </div>
            <div class="col-lg-6">
                <%--<div class="panel panel-default">--%>
                <%--   <asp:Label ID="lbloutput" runat="server" Style="white-space: pre-wrap;"></asp:Label>--%>
                <asp:TextBox ID="lbloutput" runat="server" TextMode="MultiLine" Height="500px" Width="500px"> </asp:TextBox>
                <%-- <input type="button" class="btn btn-danger" value="copy" onclick="copyText();" />--%>
                <%--</div>--%>
            </div>
        </div>
    </form>
</body>
</html>
