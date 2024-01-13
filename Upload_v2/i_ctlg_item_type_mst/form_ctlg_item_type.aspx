<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeBehind="form_ctlg_item_type.aspx.cs" Inherits="form_ctlg_item_type" %>
    <%@ Import Namespace="System.IO" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function isDateValidate(event) {
            var id = event.id;
            var date = $(id).val();
            if (isDate(date) == false) {
                messageWarning("please Enter Date in DD/MM/YYYY Format");
            }
        }
    </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://cdn.jsdelivr.net/npm/melanke-watchjs@1.5.0/src/watch.min.js"></script>
    <asp:HiddenField runat="server" ID ="UniqFileId"></asp:HiddenField>
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
          <asp:Panel ID="PnlMain" runat ="server">
      <asp:HiddenField runat="server" ID ="hd_parent_type" Value ="0" ></asp:HiddenField>
            <div class="alert alert-danger" role ="alert" id ="div_alert" runat ="server" visible ="false" >
                <strong>
                    <label runat="server" id ="lbl_alert_msg" ></label>
                </strong>
            </div>
            <div class="row" id ="div_data" runat ="server" visible ="true">
                <div class="col-xl-12" runat="server">
                    <div id="panel-8" class="panel">
                        <div class="panel-hdr">
                            <h2></h2>
                            <div class="panel-toolbar">
                                <button class="btn btn-panel waves-effect waves-themed" data-action="panel-collapse" data-toggle="tooltip" data-offset="0,10" data-original-title="Collapse"></button>
                            </div>
                        </div>
                        <div class="panel-container collapse show" style="">
                            <div class="panel-content">
                                    <div class="form-row" >
                                        <asp:Label ID="lblMessage" Text ="Item Type" runat ="server" Style ="color: red; margin-left: 0px; " ></asp:Label>
                                    </div>
                                <div class="form-row">

                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 0</label>
                                                 <asp:TextBox ID="txt_itm_parent_type" CssClass="form-control"    runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 2</label>
                                                 <asp:TextBox ID="txt_itm_name" TextMode='MultiLine' CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 4</label>
                                                 <asp:TextBox ID="txt_itm_code" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_itm_code" runat="server" TargetControlID="txt_itm_code"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 6</label>
                                                 <asp:TextBox runat="server" ID="txt_itm_is_system" CssClass="form-control _date" onchange="isDateValidate(this)" />
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 8</label>
                                                 
<asp:DropDownList ID="txt_itm_key" runat="server"  AppendDataBoundItems="True">
    <asp:ListItem Value="0" > Please Select TextBox 8</asp:ListItem>
</asp:DropDownList>
                                        </div>        
                                </div>
                                <div style="text-align: center" class="col-xl-12">
                                    <asp:Button Text= "Save" runat ="server" CssClass="btn btn-primary" ID="btnSave" OnClick="btnSave_Click"/>
                                    <asp:Button ID="btnCancel" Text ="Cancel" runat ="server" class="btn btn-default" CausesValidation ="false"
                                                        OnClientClick ="return redirect('list_ctlg_item_type.aspx');" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>     
       </asp:Panel>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>