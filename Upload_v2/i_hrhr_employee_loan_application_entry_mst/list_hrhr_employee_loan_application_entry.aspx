<%@ Page Language="C#" MasterPageFile="~/Include/Master/list.master" AutoEventWireup="true"
    CodeFile="list_hrhr_employee_loan_application_entry.aspx.cs" Inherits="list_hrhr_employee_loan_application_entry" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- widget grid -->
            <section id="widget-grid" class="">				
					<!-- row -->
					<div class="row">				
						<!-- NEW WIDGET START -->
						<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-blueDark" id="wid-id-3" data-widget-sortable="false"  data-widget-deletebutton="false" data-widget-togglebutton="false" data-widget-editbutton="false">								
								<header>
									<span class="widget-icon"> <i class="fa fa-table"></i> </span>
									<h2>Manage_emp_loan_application_entry</h2>				
								</header>				
								    <!-- widget div-->                                    
                                    <div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group"> 
											<fieldset class="custom_fs">                                                
                                                <legend>
                                                    Filter Criteria
                                                </legend>											    
                                            </fieldset>
                                            <br />
                                            <div class="col-md-3">
                                            <a href="javascript:void(0);" onclick="GetDataAJAX();" class="btn btn-primary btn-sm"><i class="fa fa-check"></i>Load</a>                                        
                                            <a href="javascript:void(0);" onclick="ShowDefInput();" class="btn btn-primary btn-sm"><i class="fa fa-save"></i>Save Definition</a>
                                            </div>
                                            <div class="col-md-4" id="defSave" style="visibility:hidden;">
                                            <div class="input-group">
												<input type="text" id="txtDefName" class="form-control">
												<div class="input-group-btn">
													<button type="button" onclick="SaveDef();" class="btn btn-default">
														Save
													</button>
													<button type="button" onclick="HideDef();" class="btn btn-default">
														Cancel
													</button>
												</div>
											</div>
                                            </div>
                                        </div>									
                                     </ContentTemplate>
                                    </asp:UpdatePanel>                                    							
									<div class="widget-body no-padding" style="clear:left;margin-top:10px;">
                                    <div id='jqxWidget'>
                                        <div id="jqxgrid">
                                        </div>                                    
                                    </div>
                                    <div id='jqxWidgetViewLog' style="visibility:hidden;">
                                        <div id="jqxgridViewLog">
                                        </div>                                    
                                    </div>
								</div>	
                                </div>
                                </div>
						</article>
				</div>							
				</section>
            </asp:Content>
            <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
                <!-- PAGE RELATED PLUGIN(S) -->
                <link rel="stylesheet" href="<%=Session["base_url"]%>jqwidgets/styles/jqx.base.css"
                    type="text/css" />
                <script type="text/javascript" src="<%=Session["base_url"]%>jqwidgets/jqx-all.js"></script>
                <script type="text/javascript">
                function ShowDefInput()
        {
            document.getElementById("defSave").style.visibility="visible";
        }
        function HideDef()
        {
            document.getElementById("defSave").style.visibility="hidden";
            $("#jqxNotification").jqxNotification("open");
        }
        function DelDef()
        {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            ConfirmBox("Are You Sure?","Do you want to delete "+item.label+" definition?").done(function(){
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: "del_def_id=" + item.value,
                    success: function (data) 
                    {
                        if (data.toString() == '1') 
                        {
                            alert('Definition deleted successfully.'); 
                            $("#DDLDef").jqxDropDownList('clearSelection'); 
                            $("#DDLDef").jqxDropDownList('removeItem',item.value);
                            document.getElementById("delDef").style.visibility="hidden";
                            document.getElementById("updateDef").style.visibility="hidden";
                            document.getElementById("setDefault").style.visibility="hidden";
                        }
                        else 
                        {
                            alert('Some error is occurred while deleting.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred while deleting.');
                    }
                });
            });
        }

        function Defchange (item) 
        {                        
            
            document.getElementById("delDef").style.visibility="visible";
            document.getElementById("updateDef").style.visibility="visible";                            
            document.getElementById("setDefault").style.visibility="visible";
                $.ajax({
                type: "POST",
                url: "<%=Session["base_url"]%>ajax_comm.aspx",
                async: true,
                data: "GridDef_id="+item.value,
                success: function (data) {
                    if (data.toString() != '') 
                    {                                    
                        var Definition = $.parseJSON(data);
                        if(Definition[0].uwgs_is_default=="1")
                        document.getElementById("setDefault").style.visibility="hidden";
                        var sstate=$.parseJSON(Definition[0].uwgs_grid_state);
                        try
                        {
                            if (sstate) 
                            {
                                $("#jqxgrid").jqxGrid("cleargroups");
                                $("#jqxgrid").jqxGrid('loadstate', sstate);
                            }
                        }
                        catch(ex){alert("Oops! Some error is occurred");}
                    }
                }
            })       
            
        }
         
        function UpdateDef()
        {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            var ustat=$("#jqxgrid").jqxGrid('savestate');
            ConfirmBox("Are You Sure?","Do you want to update "+item.label+" definition?").done(function() {
            var DatStr={'update_def_id':item.value,'uwgs_grid_state':JSON.stringify(ustat)}
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: DatStr,
                    success: function (data) 
                    {
                        if (data.toString() == '1') 
                        {
                            alert('Definition updated successfully.');                             
                        }
                        else 
                        {
                            alert('Some error is occurred while updating.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred while updating.');
                    }
                });
            });
        }
        
        function SetDefaultDef()
        {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            ConfirmBox("Are You Sure?","Do you want to set this definition as default ?").done(function() {
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: "SD_def_id=" + item.value,
                    success: function (data) 
                    {
                        if (data.toString() == '1') 
                        {
                            alert('Default Definition set successfully.');                                                         
                            document.getElementById("setDefault").style.visibility="hidden";
                        }
                        else 
                        {
                            alert('Some error is occurred.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred.');
                    }
                });
            });
        } 

        function SaveDef()
        {
            var flg=0;
            var items = $("#DDLDef").jqxDropDownList('getItems');
            for (var i = 0; i < items.length; i++) 
            {
                if(items[i].label==$("#txtDefName").val())
                {
                    alert("Definition already exists with name "+$("#txtDefName").val());
                    flg=1;
                }
            }
            if($.trim($("#txtDefName").val())=="")
            {
                alert("Please enter definition name");
                $("#txtDefName").focus();
                flg=1;
            }
            if(flg==0)
            {
                var url='<%=Session["base_url"]%>ajax_comm.aspx';
                var stat=$("#jqxgrid").jqxGrid('savestate');                                
                var DatStr={'uwgs_set_name':$("#txtDefName").val(),'uwgs_grid_name':'Manage_emp_loan_application_entry','uwgs_grid_state':JSON.stringify(stat)}
                
                $.ajax({
                    type: "POST",
                    url: url,                                
                    async: true,                                
                    data:  DatStr,                                
                    success: function (data) 
                    {                                    
                        if (data.toString() == '1') 
                        {
                            alert('inserted');  
                            document.getElementById("defSave").style.visibility="hidden";
                            GetDefData();
                        }
                        else
                        {
                            alert('Some error is occurred.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred.');
                    }
                });
            }
        }
        /* LOG FUNCTION */
        var viewLog = function (event) {
            document.getElementById("jqxWidgetViewLog").style.visibility="visible";

            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            if(dataRecord.id !="")
            {
                $.ajax({
                    type: "POST",
                    url: "ajax_hrhr.aspx",
                    async: true,
                    data: "slv_ela_id="+dataRecord.id+"&sign=Manage_emp_loan_application_entry",
                    success: function (data) {
                        if (data.toString() != '') 
                        {                                    
                            datafieldsViewLog = data;                                    
                            sourceViewLog.localdata = datafieldsViewLog                                   
                            dataAdapterViewLog.dataBind();
                        }
                    }
                })                           
            }
            document.getElementById("jqxgridViewLog").scrollIntoView()
        }
        /* END LOG FUNCTION */

        var Editclick = function (event)
        {
            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            window.location.href = "form_hrhr_employee_loan_application_entry.aspx?id=" + dataRecord.id;
        }
        var Deleteclick = function (event) {
            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            ConfirmBox("Are You Sure?","Do you want to delete this record?").done(function(){
                $.ajax({
                    type: "POST",
                    url: "ajax_hrhr.aspx",
                    async: true,
                    data: "del_ela_id=" + dataRecord.id+"&sign=Manage_emp_loan_application_entry",
                    success: function (data) {
                        if (data.toString() == '1') {
                            alert('Manage_emp_loan_application_entry deleted successfully.');
                            $("#jqxgrid").jqxGrid('deleterow', id);
                        }
                        else {
                            alert('Some error is occurred while deleting.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred while deleting.');
                    }
                });
            });
        }
                    
        var datafields = [];
            var source =
            {
                datatype: "json",
                datafields: [{ name: 'id', type: 'number', colName: '' },
{ name: 'ela_loan_req_date', type: 'date', colName: 'Loan Req Date' },
{ name: 'ela_date_of_confirm', type: 'date', colName: 'Date Of Confirmation' },
{ name: 'ela_emp_id', type: 'string', colName: 'Employee Name' },
{ name: 'ela_eligibilty_of_emp', type: 'number', colName: 'Eligibility of Employee ' },
{ name: 'ela_applied_loan_amt', type: 'number', colName: 'Applied for loan amount' },
{ name: 'ela_no_of_installment', type: 'number', colName: 'No of Installment' },
{ name: 'ela_installment_amt', type: 'number', colName: 'Instalment Amt.' },
{ name: 'ela_reason', type: 'string', colName: 'Reason' },
{ name: 'ela_last_loan_date', type: 'date', colName: 'Last Loan Date' },
{ name: 'ela_last_loan_amt', type: 'number', colName: 'Last Loan Amt.' },
{ name: 'ela_loan_period', type: 'number', colName: 'Loan Period' },
{ name: 'ela_last_loan_pend_amt', type: 'number', colName: 'Last Loan Pend. Amt.' },
{ name: 'ela_from_date', type: 'date', colName: 'From Date' },
{ name: 'ela_to_date', type: 'date', colName: 'To Date' },
{ name: 'ela_total_days', type: 'number', colName: 'Total Days' },
{ name: 'ela_working_days', type: 'number', colName: 'Working Days' },
{ name: 'ela_absent_days_with_leave', type: 'number', colName: 'Absent Days (with leave)' },
{ name: 'ela_absent_days_without_leave', type: 'number', colName: 'Absent Days (w/o leave)' },
{ name: 'ela_sick_leave', type: 'number', colName: 'Sick Leave' },
{ name: 'ela_accident_esi_leave', type: 'number', colName: 'Accident / ESI Leave' },
{ name: 'ela_present_days', type: 'number', colName: 'Present Days' },
{ name: 'ela_tot_absent', type: 'number', colName: 'Total Absent' },
{ name: 'create_by_user', type: 'string', colName: 'Enter By' },
                    { name: 'create_dnt', type: 'date', colName: 'Enter Date' },
                    { name: 'modify_by_user', type: 'string', colName: 'Modify By' },
                    { name: 'modify_dnt', type: 'date', colName: 'Modify Date' }],
                pager: function (pagenum, pagesize, oldpagenum) {
                    // callback called when a page or page size is changed.
                },                            
                localdata: datafields

            };
        var dataAdapter = new $.jqx.dataAdapter(source);

        /* LOG VARIABLES */
        ///View Log Section
        var datafieldsViewLog = [];
            var sourceViewLog =
            {
                datatype: "json",
                datafields: [{ name: 'operation_type', type: 'string', colName: 'Operation Type' },
                    { name: 'operation_dnt', type: 'date', colName: 'Operation Date' },
                    { name: 'create_by_user', type: 'string', colName: 'Enter By' },
                    { name: 'create_dnt', type: 'date', colName: 'Enter Date' },
                    { name: 'modify_by_user', type: 'string', colName: 'Modify By' },
                    { name: 'modify_dnt', type: 'date', colName: 'Modify Date' },
{ name: 'ela_loan_req_date', type: 'date', colName: 'Loan Req Date' },
{ name: 'ela_date_of_confirm', type: 'date', colName: 'Date Of Confirmation' },
{ name: 'ela_emp_id', type: 'string', colName: 'Employee Name' },
{ name: 'ela_eligibilty_of_emp', type: 'number', colName: 'Eligibility of Employee ' },
{ name: 'ela_applied_loan_amt', type: 'number', colName: 'Applied for loan amount' },
{ name: 'ela_no_of_installment', type: 'number', colName: 'No of Installment' },
{ name: 'ela_installment_amt', type: 'number', colName: 'Instalment Amt.' },
{ name: 'ela_reason', type: 'string', colName: 'Reason' },
{ name: 'ela_last_loan_date', type: 'date', colName: 'Last Loan Date' },
{ name: 'ela_last_loan_amt', type: 'number', colName: 'Last Loan Amt.' },
{ name: 'ela_loan_period', type: 'number', colName: 'Loan Period' },
{ name: 'ela_last_loan_pend_amt', type: 'number', colName: 'Last Loan Pend. Amt.' },
{ name: 'ela_from_date', type: 'date', colName: 'From Date' },
{ name: 'ela_to_date', type: 'date', colName: 'To Date' },
{ name: 'ela_total_days', type: 'number', colName: 'Total Days' },
{ name: 'ela_working_days', type: 'number', colName: 'Working Days' },
{ name: 'ela_absent_days_with_leave', type: 'number', colName: 'Absent Days (with leave)' },
{ name: 'ela_absent_days_without_leave', type: 'number', colName: 'Absent Days (w/o leave)' },
{ name: 'ela_sick_leave', type: 'number', colName: 'Sick Leave' },
{ name: 'ela_accident_esi_leave', type: 'number', colName: 'Accident / ESI Leave' },
{ name: 'ela_present_days', type: 'number', colName: 'Present Days' },
{ name: 'ela_tot_absent', type: 'number', colName: 'Total Absent' }],
                pager: function (pagenum, pagesize, oldpagenum) {
                    // callback called when a page or page size is changed.
                },                            
                localdata: datafieldsViewLog
            };
            var dataAdapterViewLog = new $.jqx.dataAdapter(sourceViewLog);
        //End View Log Section
        /* LOG VARIABLES */
                   
        function GetDataAJAX()
        {
            $.ajax({
                type: "POST",
                url: "ajax_hrhr.aspx",
                async: true,
                data: "gela_user_id=<%=Session["user_id"]%>&sign=Manage_emp_loan_application_entry",
                success: function (data) {
                    if (data.toString() != '') 
                    {                                    
                        datafields = data;                                    
                        source.localdata = datafields                                   
                        dataAdapter.dataBind();
                    }
                }
            })
        }
                                                                              
        var DdlDefSource=
        {
            datatype: "json",
            datafields: [
                { name: 'uwgs_set_name', type: 'String' },
                { name: 'Def', type: 'String' }
            ],
            pager: function (pagenum, pagesize, oldpagenum) {
                // callback called when a page or page size is changed.
            }
        };
        var dataAdapterDDLDef = new $.jqx.dataAdapter(DdlDefSource);
        var defailtDef=0;
        function GetDefData()
        {
            var DefData="";
            $.ajax({
                type: "POST",
                url: "<%=Session["base_url"]%>ajax_comm.aspx",
                async: false,
                data: "GridDef_user_id=<%=Session["user_id"]%>&Grid_name=Manage_emp_loan_application_entry",
                success: function (data) {
                    if (data.toString() != '') 
                    {                                    
                        var Response=data.split('^');
                        defailtDef=Response[0];
                        DefData =$.parseJSON(Response[1]);
                        DdlDefSource.localdata=DefData;
                        dataAdapterDDLDef.dataBind();

                    }
                }
            })  
        }
        GetDefData();

        $(document).ready(function () {
            var renderer = function (id) 
            {
                var editflag="<%=edit_flag%>";
                var deleteflag="<%=delete_flag%>";
                var viewLogflag="<%=viewLog_flag%>";

                var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
                return ((editflag>0) ? '<i title="Edit" style="cursor:pointer;font-size:20px;padding-left:8px;" onClick="Editclick(event)" id="' + id + '" class="fa fa-edit" ></i>':'') + ((deleteflag>0) ? '<i title="Delete" style="cursor:pointer;font-size:20px;padding-left:8px;" onClick="Deleteclick(event)" id="' + id + '" class="fa fa-trash-o" ></i>' :'')+ ((viewLogflag>0 && dataRecord.modify_dnt != null ) ?'<i title="View Log" style="cursor:pointer;font-size:20px;padding-left:8px;" onClick="viewLog(event)" id="' + id + '" class="fa fa-database" ></i>':'')
            };                        
            $("#jqxgrid").jqxGrid(
            {
                width: '100%',
                autoheight:true,
                source: dataAdapter,
                columnsresize: true,
                groupable: true,
                sortable: true,
                pageable: true,
                showfilterrow: true,
                filterable: true,
                showtoolbar: true,                            
                columnsreorder: true,
                rendertoolbar: function (toolbar) {
                    var me = this;
                    var container = $("<div style='margin: 5px;'></div>");
                    toolbar.append(container);
                    var addButton = $("<div style='float: left; margin-left: 5px;'><i class='fa fa-plus' style='color:green;font-size:18px;' ></i><span style='margin-left: 4px; position: relative;top:-3px;'>Add</span></div>");
                                
                    var insertflag="<%=insert_flag%>";
                    if(insertflag==1)
                        container.append(addButton);
                    addButton.jqxButton({ width: 60, height: 18 });

                    var ddlDiv = $("<div style='float:left;margin-left: 5px;' id='jqxWidgetDDL'></div>");
                    var ddlDivDef = $("<div id='DDLDef' style='float:left;margin-left: 5px;'></div>");
                    var ExportBtn = $("<div style='float: left; margin-left: 5px;'><i class='fa fa-file-excel-o' style='color:green;font-size:18px;margin-top:-2px;' ></i><span style='margin-left: 4px; position: relative;top:-1px;'>Export</span></div>");
                    
                    var delBtn=$("<i class='fa fa-trash-o fa-lg' id='delDef' onclick='DelDef();' style='font-size:15px;color:red;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='delete definition'></i>");
                    var UpdateBtn=$("<i class='fa fa-pencil-square-o fa-lg' id='updateDef' onclick='UpdateDef();' style='font-size:15px;color:red;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='Update Selected definition'></i>");
                    var SetDefaultBtn=$("<i class='fa fa-check-square-o fa-lg' id='setDefault' onclick='SetDefaultDef();' style='font-size:15px;color:green;margin-top:5px;margin-left:3px;visibility: hidden;cursor:pointer;' title='Set it as Default Definition'></i>");                    
                                
                    var exportflag="<%=export_flag%>";
                    if(exportflag==1)
                        container.append(ExportBtn);

                    var deletedLogButton = $("<div style='float: left; margin-left: 5px;'><span style='margin-left: 4px; position: relative;top:2px;'>Deleted Log</span></div>");
                               
                    var deletedViewLogflag="<%=deletedViewLog_flag%>";
                    if(deletedViewLogflag==1)
                        container.append(deletedLogButton);
                    deletedLogButton.jqxButton({ width: 100, height: 18 });

                    container.append(ddlDiv);
                    container.append(ddlDivDef);
                    container.append(delBtn);
                    container.append(UpdateBtn);
                    container.append(SetDefaultBtn);
                    // prepare the data
                    var sourceData = source.datafields;
                    var Cldata='[';
                    for(i=0;i<sourceData.length;i++)
                    {
                        if(sourceData[i].colName !="")
                        {
                        if(i==sourceData.length-1)
                        Cldata+='{"cnm":"'+sourceData[i].colName+'","cvl":"'+sourceData[i].name+'"}';
                        else
                        Cldata+='{"cnm":"'+sourceData[i].colName+'","cvl":"'+sourceData[i].name+'"},';
                        } 
                    }
                    Cldata+=']';                                
                    var sourceDDL =
                    {
                        datatype: "json",
                        datafields: [
                            { name: 'cnm', type: 'String' },
                            { name: 'cvl', type: 'string' }
                        ],
                        pager: function (pagenum, pagesize, oldpagenum) {
                            // callback called when a page or page size is changed.
                        },
                        localdata: Cldata
                    };
                    var dataAdapterDDL = new $.jqx.dataAdapter(sourceDDL);
                    // Create a jqxDropDownList
                    ddlDiv.jqxDropDownList({ checkboxes: true, selectionRenderer: function () {return "<div class='DDLLabel'>Select Column</div>";}, source: dataAdapterDDL, displayMember: "cnm", valueMember: "cvl", width: '25%', height: 25,placeHolder:"Select Column" });
                    ddlDiv.jqxDropDownList('checkAll');
                    ddlDiv.on('checkChange', function (event) 
                    {
                        if (event.args) {
                            var item = event.args.item;
                            $("#jqxgrid").jqxGrid('beginupdate');
                            if (item.checked) {
                                $("#jqxgrid").jqxGrid('showcolumn', item.value);
                            }
                            else {
                                $("#jqxgrid").jqxGrid('hidecolumn', item.value);
                                
                            }
                            $("#jqxgrid").jqxGrid('endupdate');
                        }
                    });                                                            
                   
                    ddlDivDef.on('change',function (event) {var item = event.args.item;Defchange(item);});
                    ddlDivDef.on('bindingComplete', function (event) 
                    {                        
                        var item = ddlDivDef.jqxDropDownList('getItemByValue', defailtDef.toString());                        
                        if(item)
                        {   
                            ddlDivDef.jqxDropDownList('selectItem',item);
                            Defchange(item);
                        }
                    });                   
                    ddlDivDef.jqxDropDownList({source: dataAdapterDDLDef , displayMember: "uwgs_set_name", valueMember: "Def", width: '25%', height: 25,placeHolder:"Select Definition" });                                                            

                    ExportBtn.jqxButton({ width: 80, height: 18 });
                    // Add new row.
                    addButton.click(function (event) {
                        window.location.href = "form_hrhr_employee_loan_application_entry.aspx";
                    });
                    // Export In Excel
                    ExportBtn.click(function (event) 
                    {
                        $("#jqxgrid").jqxGrid('exportdata', 'xls', 'Manage_emp_loan_application_entry_Detail');
                    });
                    //Deleted Log
                    deletedLogButton.click(function (event) {

                        document.getElementById("jqxWidgetViewLog").style.visibility="visible";
                        

                        $.ajax({
                            type: "POST",
                            url: "ajax_hrhr.aspx",
                            async: true,
                            data: "dlv_ela_user_id=<%=Session["user_id"]%>&sign=Manage_emp_loan_application_entry",
                            success: function (data) {
                                if (data.toString() != '') 
                                {                                    
                                    datafieldsViewLog = data;                                    
                                    sourceViewLog.localdata = datafieldsViewLog                                   
                                    dataAdapterViewLog.dataBind();
                                }
                            }
                        })
                        document.getElementById("jqxgridViewLog").scrollIntoView()                                    
                    });
                },                            
                columns: [{ text: 'Action', datafield: 'id', groupable: false, sortable: false, exportable: false, filterable: false, cellsrenderer: renderer,pinned: true, width:85 },
{ text: 'Loan Req Date', datafield: 'ela_loan_req_date',filtertype: 'range' },
{ text: 'Date Of Confirmation', datafield: 'ela_date_of_confirm',filtertype: 'range' },
{ text: 'Employee Name', datafield: 'ela_emp_id',filtertype: 'input' },
{ text: 'Eligibility of Employee ', datafield: 'ela_eligibilty_of_emp',filtertype: 'number' },
{ text: 'Applied for loan amount', datafield: 'ela_applied_loan_amt',filtertype: 'number' },
{ text: 'No of Installment', datafield: 'ela_no_of_installment',filtertype: 'number' },
{ text: 'Instalment Amt.', datafield: 'ela_installment_amt',filtertype: 'number' },
{ text: 'Reason', datafield: 'ela_reason',filtertype: 'input' },
{ text: 'Last Loan Date', datafield: 'ela_last_loan_date',filtertype: 'range' },
{ text: 'Last Loan Amt.', datafield: 'ela_last_loan_amt',filtertype: 'number' },
{ text: 'Loan Period', datafield: 'ela_loan_period',filtertype: 'number' },
{ text: 'Last Loan Pend. Amt.', datafield: 'ela_last_loan_pend_amt',filtertype: 'number' },
{ text: 'From Date', datafield: 'ela_from_date',filtertype: 'range' },
{ text: 'To Date', datafield: 'ela_to_date',filtertype: 'range' },
{ text: 'Total Days', datafield: 'ela_total_days',filtertype: 'number' },
{ text: 'Working Days', datafield: 'ela_working_days',filtertype: 'number' },
{ text: 'Absent Days (with leave)', datafield: 'ela_absent_days_with_leave',filtertype: 'number' },
{ text: 'Absent Days (w/o leave)', datafield: 'ela_absent_days_without_leave',filtertype: 'number' },
{ text: 'Sick Leave', datafield: 'ela_sick_leave',filtertype: 'number' },
{ text: 'Accident / ESI Leave', datafield: 'ela_accident_esi_leave',filtertype: 'number' },
{ text: 'Present Days', datafield: 'ela_present_days',filtertype: 'number' },
{ text: 'Total Absent', datafield: 'ela_tot_absent',filtertype: 'number' },
{ text: 'Enter By', datafield: 'create_by_user',filtertype: 'input',width:80 },
                    { text: 'Enter Date', datafield: 'create_dnt', cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 },
                    { text: 'Modify By', datafield: 'modify_by_user',filtertype: 'input',width:80 },
                    { text: 'Modify Date', datafield: 'modify_dnt', cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 }]
            });                   
            /*Log View Grid */
            $("#jqxgridViewLog").jqxGrid(
            {
                width: '100%',
                autoheight:true,
                source: dataAdapterViewLog,
                columnsresize: true,
                groupable: false,
                sortable: false,
                pageable: true,
                showfilterrow: true,
                filterable: true,
                showtoolbar: true,                            
                columnsreorder: true,
                rendertoolbar: function (toolbar) {
                    var me = this;
                    var container = $("<div style='margin: 5px;'></div>");
                    toolbar.append(container);

                    var closeButton = $("<div style='float: left; margin-left: 5px;'><span style='margin-left: 4px; position: relative;top:2px;'>Close</span></div>");
                    container.append(closeButton);
                    closeButton.jqxButton({ width: 60, height: 18 });
                    closeButton.click(function (event) {
                                   
                            $("#jqxgridViewLog").jqxGrid('clear');
                            document.getElementById("jqxWidgetViewLog").style.visibility="hidden";
                            window.scroll(0, 0);
                    });

                    var ddlDiv = $("<div style='float:left;margin-left: 5px;' id='jqxWidgetViewLogDDL'></div>");
                    container.append(ddlDiv);
                                
                    var sourceData = sourceViewLog.datafields;
                    var Cldata='[';
                    for(i=0;i<sourceData.length;i++)
                    {
                        if(sourceData[i].colName !="")
                        {
                            if(i==sourceData.length-1)
                            Cldata+='{"cnm":"'+sourceData[i].colName+'","cvl":"'+sourceData[i].name+'"}';
                            else
                            Cldata+='{"cnm":"'+sourceData[i].colName+'","cvl":"'+sourceData[i].name+'"},';
                        }
                    }
                    Cldata+=']';                                
                    var sourceDDL =
                    {
                        datatype: "json",
                        datafields: [
                            { name: 'cnm', type: 'String' },
                            { name: 'cvl', type: 'string' }
                        ],
                        pager: function (pagenum, pagesize, oldpagenum) {
                            // callback called when a page or page size is changed.
                        },
                        localdata: Cldata
                    };
                    var dataAdapterDDL = new $.jqx.dataAdapter(sourceDDL);
                                                               
                    // Create a jqxDropDownList
                                
                    ddlDiv.jqxDropDownList({ checkboxes: true,selectionRenderer: function () {return "<div class='DDLLabel'>Select Column</div>";}, source: dataAdapterDDL, displayMember: "cnm", valueMember: "cvl", width: '25%', height: 25,placeHolder:"Select Column" });
                    ddlDiv.jqxDropDownList('checkAll');
                    ddlDiv.on('checkChange', function (event) 
                    {
                        if (event.args) {
                            var item = event.args.item;
                            $("#jqxgridViewLog").jqxGrid('beginupdate');
                            if (item.checked) {
                               $("#jqxgridViewLog").jqxGrid('showcolumn', item.value);
                            }
                            else {
                                 $("#jqxgridViewLog").jqxGrid('hidecolumn', item.value);
                                
                            }
                            $("#jqxgridViewLog").jqxGrid('endupdate');
                        }
                    });                                                            
                },
                columns: [{ text: 'Operation Type', datafield: 'operation_type',filtertype: 'input',width:80},
                    { text: 'Operation Date', datafield: 'operation_dnt',cellsformat: 'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 },
                    { text: 'Enter By', datafield: 'create_by_user',filtertype: 'input',width:80 },
                    { text: 'Enter Date', datafield: 'create_dnt', cellsformat:'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 },
                    { text: 'Modify By', datafield: 'modify_by_user',filtertype: 'input' ,width:80 },
                    { text: 'Modify Date', datafield: 'modify_dnt', cellsformat:'dd/MM/yyyy hh:mm tt',filtertype: 'range',width:150 },
{ text: 'Loan Req Date', datafield: 'ela_loan_req_date',filtertype: 'range' },
{ text: 'Date Of Confirmation', datafield: 'ela_date_of_confirm',filtertype: 'range' },
{ text: 'Employee Name', datafield: 'ela_emp_id',filtertype: 'input' },
{ text: 'Eligibility of Employee ', datafield: 'ela_eligibilty_of_emp',filtertype: 'number' },
{ text: 'Applied for loan amount', datafield: 'ela_applied_loan_amt',filtertype: 'number' },
{ text: 'No of Installment', datafield: 'ela_no_of_installment',filtertype: 'number' },
{ text: 'Instalment Amt.', datafield: 'ela_installment_amt',filtertype: 'number' },
{ text: 'Reason', datafield: 'ela_reason',filtertype: 'input' },
{ text: 'Last Loan Date', datafield: 'ela_last_loan_date',filtertype: 'range' },
{ text: 'Last Loan Amt.', datafield: 'ela_last_loan_amt',filtertype: 'number' },
{ text: 'Loan Period', datafield: 'ela_loan_period',filtertype: 'number' },
{ text: 'Last Loan Pend. Amt.', datafield: 'ela_last_loan_pend_amt',filtertype: 'number' },
{ text: 'From Date', datafield: 'ela_from_date',filtertype: 'range' },
{ text: 'To Date', datafield: 'ela_to_date',filtertype: 'range' },
{ text: 'Total Days', datafield: 'ela_total_days',filtertype: 'number' },
{ text: 'Working Days', datafield: 'ela_working_days',filtertype: 'number' },
{ text: 'Absent Days (with leave)', datafield: 'ela_absent_days_with_leave',filtertype: 'number' },
{ text: 'Absent Days (w/o leave)', datafield: 'ela_absent_days_without_leave',filtertype: 'number' },
{ text: 'Sick Leave', datafield: 'ela_sick_leave',filtertype: 'number' },
{ text: 'Accident / ESI Leave', datafield: 'ela_accident_esi_leave',filtertype: 'number' },
{ text: 'Present Days', datafield: 'ela_present_days',filtertype: 'number' },
{ text: 'Total Absent', datafield: 'ela_tot_absent',filtertype: 'number' }]
            });
            //End Log view grid
            /*END Log View Grid */                             
            $("#excelExport").click(function () 
            {
                $("#jqxgrid").jqxGrid('exportdata', 'xls', 'jqxGrid');
            });
        });
    </script>        
</asp:Content>