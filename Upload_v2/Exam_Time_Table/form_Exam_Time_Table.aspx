<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeBehind="form_Exam_Time_Table.aspx.cs" Inherits="form_Exam_Time_Table" %>
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
      <asp:HiddenField runat="server" ID ="hd_" Value ="0" ></asp:HiddenField>
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
                                <div class="form-row">

                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 0</label>
                                                 <asp:TextBox ID="txt_ett_Id" CssClass="form-control"    runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 2</label>
                                                 <asp:TextBox ID="txt_ett_Institute_Id" TextMode='MultiLine' CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 4</label>
                                                 <asp:TextBox ID="txt_ett_Faculty_Id" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ett_Faculty_Id" runat="server" TargetControlID="txt_ett_Faculty_Id"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 6</label>
                                                 <asp:TextBox runat="server" ID="txt_ett_Program_Id" CssClass="form-control _date" onchange="isDateValidate(this)" />
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 8</label>
                                                 
<asp:DropDownList ID="txt_ett_Semester_Id" runat="server"  AppendDataBoundItems="True">
    <asp:ListItem Value="0" > Please Select TextBox 8</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 10</label>
                                                 <asp:DropDownList ID="txt_ett_Exam_Id" runat="server"  AppendDataBoundItems="True">
                        <asp:ListItem Value="0" > Please Select TextBox 10</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 12</label>
                                                 <div class="form-control"><div class="custom-control custom-checkbox" >
                <asp:CheckBox id="chk_ett_Gap_Day" text=" " CssClass="checkbox"    runat="server"/>
        </div></div>

                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 14</label>
                                                 
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 16</label>
                                                 <asp:TextBox ID="txt_ett_Component_Id" CssClass="form-control"    runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 18</label>
                                                 <asp:TextBox ID="txt_ett_Session_Id" TextMode='MultiLine' CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 20</label>
                                                 <asp:TextBox ID="txt_ett_Exam_Date" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ett_Exam_Date" runat="server" TargetControlID="txt_ett_Exam_Date"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 22</label>
                                                 <asp:TextBox runat="server" ID="txt_ett_Exam_Start_Time" CssClass="form-control _date" onchange="isDateValidate(this)" />
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 24</label>
                                                 
<asp:DropDownList ID="txt_ett_Exam_End_Time" runat="server"  AppendDataBoundItems="True">
    <asp:ListItem Value="0" > Please Select TextBox 24</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 26</label>
                                                 <asp:DropDownList ID="txt_ett_Sub_Type_Id" runat="server"  AppendDataBoundItems="True">
                        <asp:ListItem Value="0" > Please Select TextBox 26</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 28</label>
                                                 <div class="form-control"><div class="custom-control custom-checkbox" >
                <asp:CheckBox id="chk_ett_Is_Status" text=" " CssClass="checkbox"    runat="server"/>
        </div></div>

                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 30</label>
                                                 
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 32</label>
                                                 <asp:TextBox ID="txt_ett_Created_By" CssClass="form-control"    runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 34</label>
                                                 <asp:TextBox ID="txt_ett_Created_Date" TextMode='MultiLine' CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 36</label>
                                                 <asp:TextBox ID="txt_ett_Created_Ip" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ett_Created_Ip" runat="server" TargetControlID="txt_ett_Created_Ip"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 38</label>
                                                 <asp:TextBox runat="server" ID="txt_ett_Modify_By" CssClass="form-control _date" onchange="isDateValidate(this)" />
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 40</label>
                                                 
<asp:DropDownList ID="txt_ett_Modify_Date" runat="server"  AppendDataBoundItems="True">
    <asp:ListItem Value="0" > Please Select TextBox 40</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 42</label>
                                                 <asp:DropDownList ID="txt_ett_Modify_Ip" runat="server"  AppendDataBoundItems="True">
                        <asp:ListItem Value="0" > Please Select TextBox 42</asp:ListItem>
</asp:DropDownList>
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 44</label>
                                                 <div class="form-control"><div class="custom-control custom-checkbox" >
                <asp:CheckBox id="chk_ett_Deleted_By" text=" " CssClass="checkbox"    runat="server"/>
        </div></div>

                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 46</label>
                                                 
                                        </div>
                                        <div class="col-xl-4 col-md-6 mb-3">                                       
                                            <label class="form-label" for="simpleinput">TextBox 48</label>
                                                 <asp:TextBox ID="txt_ett_Deleted_Ip" CssClass="form-control"    runat="server"></asp:TextBox>
                                        </div>        
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="text-align: center" class="col-xl-12">
                    <asp:Button Text= "Save" runat ="server" CssClass="btn btn-primary" ID="btn_save" OnClick="btn_save_Click"/>
                </div>
            </div>        
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>