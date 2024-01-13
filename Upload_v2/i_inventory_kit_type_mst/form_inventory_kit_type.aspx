<%@ Page Title="" Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeFile="form_inventory_kit_type.aspx.cs" Inherits="form_inventory_kit_type" %>
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
									<h2>Manage_Kit_Type_Master</h2>
				
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
                                                </label>
						                        <div class="col-md-4">
                                                 <asp:TextBox ID="txt_ktm_kit_type_name" CssClass="form-control"    runat="server"></asp:TextBox>
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
                                                OnClientClick="return redirect('list_inventory_kit_type.aspx');" />
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