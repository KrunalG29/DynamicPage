<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeFile="form_hrhr_employee_loan_application_entry.aspx.cs" Inherits="form_hrhr_employee_loan_application_entry" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
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
							<div class="jarviswidget " id="wid-id-0" data-widget-sortable="false"  data-widget-deletebutton="false" data-widget-togglebutton="false" data-widget-editbutton="false">							
								<header>
									<span class="widget-icon"> <i class="fa fa-eye"></i> </span>
									<h2>Manage_emp_loan_application_entry</h2>
				
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
                                        <div class="form-group" >
                                            <asp:Label ID="lblMessage" runat="server"  Style="color: red; margin-left: 0px;"></asp:Label>
                                        </div>
                                        <fieldset>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Loan Req Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_loan_req_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_ela_loan_req_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_ela_loan_req_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_ela_loan_req_date" runat="server" TargetControlID="txt_ela_loan_req_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_ela_loan_req_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_ela_loan_req_date" ControlExtender="MaskedEditExtender_ela_loan_req_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Date Of Confirmation</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_date_of_confirm" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_ela_date_of_confirm" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_ela_date_of_confirm">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_ela_date_of_confirm" runat="server" TargetControlID="txt_ela_date_of_confirm"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_ela_date_of_confirm" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_ela_date_of_confirm" ControlExtender="MaskedEditExtender_ela_date_of_confirm"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Employee Name</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_emp_id"  CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender FirstRowSelected="true" ID="AutoCompleteExtender_ela_emp_id" runat="server" ServicePath="~/Web_Services.asmx"
                        ServiceMethod="" TargetControlID="txt_ela_emp_id" MinimumPrefixLength="1"
                        CompletionListCssClass="listMain" EnableCaching="false" CompletionListHighlightedItemCssClass="itemsSelected"
                        CompletionListItemCssClass="itemsMain" UseContextKey="true" ContextKey=" ">
                        </ajaxToolkit:AutoCompleteExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Eligibility of Employee </label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_eligibilty_of_emp" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_eligibilty_of_emp" runat="server" TargetControlID="txt_ela_eligibilty_of_emp"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Applied for loan amount</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_applied_loan_amt" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_applied_loan_amt" runat="server" TargetControlID="txt_ela_applied_loan_amt"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                No of Installment</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_no_of_installment" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_no_of_installment" runat="server" TargetControlID="txt_ela_no_of_installment"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Instalment Amt.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_installment_amt" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_installment_amt" runat="server" TargetControlID="txt_ela_installment_amt"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Reason</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_reason" TextMode='MultiLine' CssClass="form-control"  runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Last Loan Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_last_loan_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_ela_last_loan_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_ela_last_loan_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_ela_last_loan_date" runat="server" TargetControlID="txt_ela_last_loan_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_ela_last_loan_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_ela_last_loan_date" ControlExtender="MaskedEditExtender_ela_last_loan_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Last Loan Amt.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_last_loan_amt" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_last_loan_amt" runat="server" TargetControlID="txt_ela_last_loan_amt"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Loan Period</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_loan_period" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_loan_period" runat="server" TargetControlID="txt_ela_loan_period"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Last Loan Pend. Amt.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_last_loan_pend_amt" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_last_loan_pend_amt" runat="server" TargetControlID="txt_ela_last_loan_pend_amt"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                From Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_from_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_ela_from_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_ela_from_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_ela_from_date" runat="server" TargetControlID="txt_ela_from_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_ela_from_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_ela_from_date" ControlExtender="MaskedEditExtender_ela_from_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                To Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_to_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_ela_to_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_ela_to_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_ela_to_date" runat="server" TargetControlID="txt_ela_to_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_ela_to_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_ela_to_date" ControlExtender="MaskedEditExtender_ela_to_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Total Days</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_total_days" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_total_days" runat="server" TargetControlID="txt_ela_total_days"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Working Days</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_working_days" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_working_days" runat="server" TargetControlID="txt_ela_working_days"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Absent Days (with leave)</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_absent_days_with_leave" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_absent_days_with_leave" runat="server" TargetControlID="txt_ela_absent_days_with_leave"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Absent Days (w/o leave)</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_absent_days_without_leave" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_absent_days_without_leave" runat="server" TargetControlID="txt_ela_absent_days_without_leave"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Sick Leave</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_sick_leave" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_sick_leave" runat="server" TargetControlID="txt_ela_sick_leave"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Accident / ESI Leave</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_accident_esi_leave" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_accident_esi_leave" runat="server" TargetControlID="txt_ela_accident_esi_leave"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Present Days</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_present_days" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_present_days" runat="server" TargetControlID="txt_ela_present_days"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Total Absent</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ela_tot_absent" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_ela_tot_absent" runat="server" TargetControlID="txt_ela_tot_absent"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>                 
                                    </fieldset>
                                    <div class="form-actions">
										<div class="row">
											<div class="col-md-12" style="text-align:center;">
                                                <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-primary" 
                                                    onclick="btnSave_Click" />
                                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" class="btn btn-default" ValidationGroup="cancel"  
                                                OnClientClick="return redirect('list_hrhr_employee_loan_application_entry.aspx');" />
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
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>