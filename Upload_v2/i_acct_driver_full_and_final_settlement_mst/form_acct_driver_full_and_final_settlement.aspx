<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeFile="form_acct_driver_full_and_final_settlement.aspx.cs" Inherits="form_acct_driver_full_and_final_settlement" %>
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
                                                Date</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_dfs_date" CssClass="form-control"  runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender_dfs_date" runat="server" Format="dd/MM/yyyy"
                         TargetControlID="txt_dfs_date">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender_dfs_date" runat="server" TargetControlID="txt_dfs_date"
                         Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                         ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator_dfs_date" IsValidEmpty="true" runat="server"
                         CssClass="error_messe" ControlToValidate="txt_dfs_date" ControlExtender="MaskedEditExtender_dfs_date"
                         InvalidValueMessage="Date not valid" >
                        </ajaxToolkit:MaskedEditValidator>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                Full Name</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_dfs_driver_full_name" CssClass="form-control"    runat="server"></asp:TextBox>
                                                </div>
                                        </section>
                                        </div>
                                        <div class="form-group">                                            
                                        <section class="col col-6">                                                
						                        <label class="col-md-2 control-label" >
                                                ID</label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_dfs_driver_id" CssClass="form-control"   runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_dfs_driver_id" runat="server" TargetControlID="txt_dfs_driver_id"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                        </section>
                                        </div>                 
                                    </fieldset>               <fieldset>    
                                    <div runat="server" style ="margin -left: 10%;">
                                        <asp:Repeater ID="rept_item" runat="server" OnItemCommand="rept_item_ItemCommand">
                                            <HeaderTemplate>
                                                <table border="1" width="95%" cellpadding="50" style="">
                                                    <tr style="background-color: #3a3633; color: White; height: 25px;" id="tbl">
                                        <td>
                                            Type Name
                                        </td>
                                        <td>
                                            Account Name 1
                                        </td>
                                        <td>
                                            Account Name 2
                                        </td>
                                        <td>
                                            Amount
                                        </td>                                         <th style="width: 30%; text-align: center;">
                                                                            <b>Action</b>
                                                                        </th>
                                                                    </tr>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr><asp:HiddenField id="hid_dfsd_dfs_id" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_dfs_id")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_ledger_type" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_ledger_type")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_driver_account_id" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_driver_account_id")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_driver_account_type" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_driver_account_type")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_opposiote_account_id" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_opposiote_account_id")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_opposiote_account_type" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_opposiote_account_type")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_jv_mst_id" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_jv_mst_id")%>' runat="server"/>
                                              <asp:HiddenField id="hid_dfsd_jv_detail_id" Value='<%#DataBinder.Eval(Container,"DataItem.dfsd_jv_detail_id")%>' runat="server"/>
                                              
                                        <td>
                                                 <asp:TextBox ID="txt_dfsd_ledger_name" CssClass="form-control"    runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.dfsd_ledger_name")%>'></asp:TextBox>
                                              </td>
                                        <td>
                                                 <asp:TextBox ID="txt_dfsd_driver_account_name" CssClass="form-control"    runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.dfsd_driver_account_name")%>'></asp:TextBox>
                                              </td>
                                        <td>
                                                 <asp:TextBox ID="txt_dfsd_opposiote_account_name" CssClass="form-control"    runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.dfsd_opposiote_account_name")%>'></asp:TextBox>
                                              </td>
                                        <td>
                                                 <asp:TextBox ID="txt_dfsd_amount" CssClass="form-control"   runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.dfsd_amount")%>'></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte_dfsd_amount" runat="server" TargetControlID="txt_dfsd_amount"
                         ValidChars="0123456789.-" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                              </td>                                                                     <td>
                                                                        <asp:ImageButton ID="add_rept_item_btn" CausesValidation="true" runat="server" ToolTip="ADD"
                                                                            CommandName="Add" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.id")%>'
                                                                            ImageUrl="~/Include/img/Add.ico" Visible="false" Height="20" />
                
                                                                        <asp:ImageButton ID="delete_rept_item_btn" CausesValidation="false" runat="server" ToolTip="REMOVE"
                                                                            CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.id")%>'
                                                                            ImageUrl="~/Include/img/Delete.ico" Height="20" />
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                    </fieldset> 
                                    <div class="form-actions">
										<div class="row">
											<div class="col-md-12" style="text-align:center;">
                                                <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-primary" 
                                                    onclick="btnSave_Click" />
                                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" class="btn btn-default" ValidationGroup="cancel"  
                                                OnClientClick="return redirect('list_acct_driver_full_and_final_settlement.aspx');" />
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