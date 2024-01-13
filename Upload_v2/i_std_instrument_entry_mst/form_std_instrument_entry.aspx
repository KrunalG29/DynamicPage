<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeFile="form_std_instrument_entry.aspx.cs" Inherits="form_std_instrument_entry" %>
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
                                        <div class="form-group" >
                                            <asp:Label ID="lblMessage" runat="server"  Style="color: red; margin-left: 0px;"></asp:Label>
                                        </div>
                                        <fieldset>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Department</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_dept_id"  CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender FirstRowSelected="true" ID="AutoCompleteExtender_siem_dept_id" runat="server" ServicePath="~/Web_Services.asmx"
                        ServiceMethod="" TargetControlID="txt_siem_dept_id" MinimumPrefixLength="1"
                        CompletionListCssClass="listMain" EnableCaching="false" CompletionListHighlightedItemCssClass="itemsSelected"
                        CompletionListItemCssClass="itemsMain" UseContextKey="true" ContextKey=" ">
                        </ajaxToolkit:AutoCompleteExtender>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Instrument Name</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_instr_name" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                GF No.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_gf_no" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Instrument Make</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_instr_make" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Model No.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_model_no" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Inst. Sr no.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_instr_sr_no" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Inst. Pur. Dtae</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_instr_pur_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_siem_instr_pur_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_siem_instr_pur_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_siem_instr_pur_date" runat="server" TargetControlID="txt_siem_instr_pur_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_siem_instr_pur_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_siem_instr_pur_date" ControlExtender="MaskedEditExtender_siem_instr_pur_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Avg. Lifecycle</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_avg_lifecycle" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Calibration Req.</label>
						                        <div class="col-md-4">
                                                 <asp:DropDownList ID="ddl_siem_calib_req" CssClass="form-control"  runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Select Calibration Req." Value="0"></asp:ListItem></asp:DropDownList>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Inst. Cali. Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_instr_calib_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_siem_instr_calib_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_siem_instr_calib_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_siem_instr_calib_date" runat="server" TargetControlID="txt_siem_instr_calib_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_siem_instr_calib_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_siem_instr_calib_date" ControlExtender="MaskedEditExtender_siem_instr_calib_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Cali. Frequency</label>
						                        <div class="col-md-4">
                                                 <asp:DropDownList ID="ddl_siem_calib_frequency" CssClass="form-control"  runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Select Cali. Frequency" Value="0"></asp:ListItem></asp:DropDownList>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Next Calibration </label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_next_calib_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_siem_next_calib_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_siem_next_calib_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_siem_next_calib_date" runat="server" TargetControlID="txt_siem_next_calib_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_siem_next_calib_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_siem_next_calib_date" ControlExtender="MaskedEditExtender_siem_next_calib_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Range</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_range" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                L.C.</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_LC" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Size</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_size" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Class</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_class" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                GO</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_go" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                NO GO</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_siem_no_go" CssClass="form-control"    runat="server"></asp:TextBox>
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
                                                OnClientClick="return redirect('list_std_instrument_entry.aspx');" />
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