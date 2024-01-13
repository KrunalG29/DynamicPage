<%@ Page Title=" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup ="true" CodeBehind ="form_acct_account_bill_to_bill_adjustment.aspx.cs" Inherits ="form_acct_account_bill_to_bill_adjustment" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace = "CrystalDecisions.Web" TagPrefix= "CR" %>
<%@ Register Src="~/Include/usercontrol/MultiSelectionTextBox.ascx" TagName ="MultiSelectionTextBox"
    TagPrefix ="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID ="cphHead" runat ="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >
    <asp:UpdatePanel ID= "UpdatePanel" runat= "server" UpdateMode ="Conditional" >
        <Triggers>
            <asp:PostBackTrigger ControlID="btnLoad" />
        </Triggers>
        <ContentTemplate>
            <!-- MAIN CONTENT -->
            <div id="content" >
                <div class="row">
                </div>
                <!-- widget grid -->
                <section id="widget-grid" class="" >
                    <!-- row -->
                    <div class="row" >
                        <!-- NEW WIDGET START -->
                        <!-- Widget ID (each widget will need unique ID)-->
                        <div class="jarviswidget" id ="wid-id-0" data-widget-sortable="false" data-widget-deletebutton="false" data-widget-togglebutton="false" data-widget-editbutton="false" >
                            <header>
                                <span class="widget-icon"><i class="fa fa-eye"></i></span>
                                <h2></h2>

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
                                        <asp:Label ID = "lblMessage" runat ="server" Style ="color: red; margin-left: 0px;"></asp:Label>
                                    </div>
                                    <fieldset>
                                        
                                        <div class="form-group">                           <section class="col col-6">                                                
                              <label class="col-md-2 control-label" >
                                                From Date</label>
                              <div class="col-md-4">
                                                 <asp:TextBox ID="txt_from_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_from_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_from_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_from_date" runat="server" TargetControlID="txt_from_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_from_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_from_date" ControlExtender="MaskedEditExtender_from_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>                           <section class="col col-6">                                                
                              <label class="col-md-2 control-label" >
                                                To Date</label>
                              <div class="col-md-4">
                                                 <asp:TextBox ID="txt_to_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_to_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_to_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_to_date" runat="server" TargetControlID="txt_to_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_to_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_to_date" ControlExtender="MaskedEditExtender_to_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>                            </div>                 
                                    <div class="form-group" >
                                        <section class="col col-6" >
                                            <label class="col-md-2 control-label">
                                            </label>
                                            <div class="col-md-4" style ="margin-top: 8px;" >
                                                <asp:Button ID="btnLoad" Width="80" runat="server" Text="Load" class="btn btn-primary"
                                                    OnClick ="btnLoad_Click" />
                                            </div>
                                        </section>
                                    </div>
                                    </fieldset>
                                    <fieldset>
                                        <div class="form-group" >
                                            <CR:CrystalReportViewer ID="CrystalReportViewer1" PrintMode="ActiveX" ReportSourceID="CrystalReportSource1"
                                                runat="server" AutoDataBind ="true" HasToggleGroupTreeButton ="false" HasToggleParameterPanelButton ="false"
                                                ToolPanelView="None" HasCrystalLogo="False" EnableDrillDown="false"/>
                                            <CR:CrystalReportSource ID="CrystalReportSource1" runat ="server" >
                                            </CR:CrystalReportSource>
                                        </div>
                                    </fieldset>
                                        <fieldset>
                                         <div class="form-group" style ="padding-left:1%; padding-right:1%; height:1200px;" runat ="server" id ="DivPrint" >
                                        </div>
                                 </fieldset>
                                </div>
                                <!-- end widget content -->
                            </div>
                            <!-- end widget div -->
                        </div>
                        <!-- end widget -->
                        <!-- WIDGET END -->
                    </div>
                    <!-- end row -->
                </section>
                <!-- end widget grid -->
            </div>
            <!-- END MAIN CONTENT -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>