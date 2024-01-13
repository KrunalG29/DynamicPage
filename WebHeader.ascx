<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebHeader.ascx.cs" Inherits="iipl.erph.WebHeader" %>

<div class="form-actions" style="margin-bottom: 30px">
    <div class="row">
        <div class="col-md-12" style="text-align: center;">
            <asp:Button ID="btnCreateDynamicPage" runat="server" Text="Generate Dynamic Page iERP Theme" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnCreateDynamicPage_Click" />
            <asp:Button ID="btnCreateFunction" runat="server" Text="Generate Function Other Functionally" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnCreateFunction_Click" />
            <asp:Button ID="btnCreateDynamicPageURP" runat="server" Text="Generate Dynamic Page NEP Theme" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnCreateDynamicPageURP_Click" />
            <asp:Button ID="btnT10_LinQ" runat="server" Text="LinQ Examples" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnT10_LinQ_Click" />
            <asp:Button ID="btnFileSend" runat="server" Text="Send Dynamic Page Files" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnFileSend_Click" />
            <asp:Button ID="btnCallHistory" runat="server" Text="Sp Call History" class="btn btn-primary"
                ValidationGroup="NOTAPPLY" OnClick="btnCallHistory_Click" />
        </div>
    </div>
</div>
