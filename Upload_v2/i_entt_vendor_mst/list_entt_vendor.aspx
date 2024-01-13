<%@ Page Language="C#" MasterPageFile="~/Include/Master/site.master" AutoEventWireup="true"
    CodeFile="list_entt_vendor.aspx.cs" Inherits="list_entt_vendor" %>
<asp:Content ID="Content2" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="Server">
   <!-- widget grid -->
    <section id="widget-grid" class="panel">
        <!-- row -->
        <div class="row">
            <!-- NEW WIDGET START -->
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <!-- Widget ID (each widget will need unique ID)-->
                <div class="jarviswidget jarviswidget-color-blueDark" id ="wid-id-3" data-widget-sortable="false" data-widget-deletebutton="false" data-widget-togglebutton="false" data-widget-editbutton="false">
                    <div class="panel-hdr">
                        <h2></h2>
                    </div>
                    <!-- widget div-->
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="panel-container collapse show" style="">
                                    <div class="panel-content">
                                        <div class="form-row">
                                            <%--<fieldset class="custom_fs">                                                
                                                <legend>
                                                    Filter Criteria
                                                </legend>											    
                                            </fieldset>
                                            <br />--%>
                                            <div class="col-md-4">
                                                <a href="javascript:void(0);" onclick="GetDataAJAX();" class="btn btn-primary btn-sm">Load</a>
                                                <a href="javascript:void(0);" onclick="ShowDefInput();" class="btn btn-primary btn-sm">Save Definition</a>
                                            </div>
                                            <input type="hidden" id="hid_default_def" />
                                            <div class="col-md-4" id="defSave" style="visibility: hidden;">
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
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="widget-body no-padding" style="clear: left; margin-top: 10px;">
                            <div id='jqxWidget'>
                                <div id="jqxgrid">
                                </div>
                            </div>
                            <div id='jqxWidgetViewLog'>
                                <div id="jqxgridViewLog">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </div>
    </section>
                <!-- PAGE RELATED PLUGIN(S) -->
                <link rel="stylesheet" href ="<%=Session["base_url"]%>jqwidgets/styles/jqx.base.css" type ="text/css" />
                <script type="text/javascript" src ="<%=Session["base_url"]%>jqwidgets/jqx-all.js"></script>
                function ShowDefInput()
        {
            document.getElementById("defSave").style.visibility="visible";
        }
        function HideDef()
        {
            document.getElementById("defSave").style.visibility="hidden";
            $("#jqxNotification").jqxNotification("open");
        }
        function DelDef() {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            ConfirmBox("Are You Sure?", "Do you want to delete " + item.label + " definition?").done(function() {
                $.ajax({
                type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: "del_def_id=" + item.value,
                    success: function(data) {
                    if (data.toString() == '1')
                    {
                        alert('Definition deleted successfully.');
                            $("#DDLDef").jqxDropDownList('clearSelection');
                            $("#DDLDef").jqxDropDownList('removeItem', item.value);
                        document.getElementById("delDef").style.visibility = "hidden";
                        document.getElementById("updateDef").style.visibility = "hidden";
                        document.getElementById("setDefault").style.visibility = "hidden";
                    }
                    else
                    {
                        alert('Some error is occurred while deleting.');
                    }
                },
                    error: function() { //On Error
                    alert('Some error is occurred while deleting.');
                }
            });
        });
    }

    function Defchange(item) {
            if (item.value != '-1') {
                document.getElementById("delDef").style.visibility = "visible";
                document.getElementById("updateDef").style.visibility = "visible";
                document.getElementById("setDefault").style.visibility = "visible";
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: "GridDef_id=" + item.value,
                    success: function (data) {
                        if (data.toString() != '') {
                            var Definition = $.parseJSON(data);
                            if (Definition[0].uwgs_is_default == "1")
                                document.getElementById("setDefault").style.visibility = "hidden";
                            var sstate = $.parseJSON(Definition[0].uwgs_grid_state);
                            try {
                                if (sstate) {
                                    $("#jqxgrid").jqxGrid("cleargroups");
                                    $("#jqxgrid").jqxGrid('loadstate', sstate);
                                }
                            }
                            catch (ex) { alert("Oops! Some error is occurred"); }
                        }
                    }
                })
            }
            else {
                document.getElementById("delDef").style.visibility = "hidden";
                document.getElementById("updateDef").style.visibility = "hidden";
                document.getElementById("setDefault").style.visibility = "hidden";

                var sstate = $.parseJSON($("#hid_default_def").val());
                try {
                    if (sstate) {
                        $("#jqxgrid").jqxGrid("cleargroups");
                        $("#jqxgrid").jqxGrid('loadstate', sstate);
                    }
                }
                catch (ex) { alert("Oops! Some error is occurred"); }
            }
        }
         
        function UpdateDef() {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            var ustat = $("#jqxgrid").jqxGrid('savestate');
            ConfirmBox("Are You Sure?", "Do you want to update " + item.label + " definition?").done(function () {
                var DatStr = { 'update_def_id': item.value, 'uwgs_grid_state': JSON.stringify(ustat) }
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: DatStr,
                    success: function (data) {
                        if (data.toString() == '1') {
                            alert('Definition updated successfully.');
                        }
                        else {
                            alert('Some error is occurred while updating.');
                        }
                    },
                    error: function () { //On Error
                        alert('Some error is occurred while updating.');
                    }
                });
            });
        }
        
        function SetDefaultDef() {
            var item = $("#DDLDef").jqxDropDownList('getSelectedItem');
            ConfirmBox("Are You Sure?", "Do you want to set this definition as default ?").done(function () {
                $.ajax({
                    type: "POST",
                    url: "<%=Session["base_url"]%>ajax_comm.aspx",
                    async: true,
                    data: "SD_def_id=" + item.value,
                    success: function (data) {
                        if (data.toString() == '1') {
                            alert('Default Definition set successfully.');
                            document.getElementById("setDefault").style.visibility = "hidden";
                        }
                        else {
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
                var DatStr={'uwgs_set_name':$("#txtDefName").val(),'uwgs_grid_name':'vendor','uwgs_grid_state':JSON.stringify(stat)}
                
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
            $("#jqxgridViewLog").show();

            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            if(dataRecord.id !="")
            {
                $.ajax({
                    type: "POST",
                    url: "ajax_entt.aspx",
                    async: true,
                    data: "slv_ven_id="+dataRecord.id+"&sign=vendor",
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

        var Editclick = function (event) {
            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            $.ajax({
                type: "POST",
                url: "list_entt_vendor.aspx/Edit_vendor",
                data: '{ven_id : "' + dataRecord.id + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    $('[id*=UpdateProgress]').css('display', '');
                },
                success: function (response) {
                    if (response.d != "[]") {
                        window.open(response.d, "_blank");
                    }
                },
                error: function () { //On Error
                    alert('Some error is occurred while Edit data.');
                },
                complete: function () {
                    $('[id*=UpdateProgress]').css('display', 'none');
                },

            });
            
        }
        var Viewclick = function (event) {
            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            $.ajax({
                type: "POST",
                url: "list_entt_vendor.aspx/View_vendor",
                data: '{ven_id: "' + dataRecord.id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    $('[id*=UpdateProgress]').css('display', '');
                },
                success: function (response) {
                    if (response.d != "[]") {
                        window.open(response.d, "_blank");
                    }
                },
                error: function () { //On Error
                    alert('Some error is occurred while Data View.');
                },
                complete: function () {
                    $('[id*=UpdateProgress]').css('display', 'none');
                },
            });  
        }

        var Deleteclick = function (event) {
            var id = event.target.id;
            var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
            if (confirm("Are you sure delete?")) {
                var id = event.target.id;
                var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', id);
                $.ajax({
                    type: "POST",
                    url: "ajax_entt.aspx",
                    async: true,
                    data: "del_ven_id=" + dataRecord.id + "&sign=vendor",
                    success: function (data) {
                        if (data.toString() == '1') {
                            alert('vendor deleted successfully.');
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
            }
        }
                    
        var datafields = [];
            var source =
            {
                datatype: "json",
                datafields: [{ name: 'id', type: 'number', colName: '' },
{ name: 'ven_code', type: 'string', colName: 'TextBox 0' },
{ name: 'ven_name', type: 'string', colName: 'TextBox 2' },
{ name: 'ven_org_type', type: 'number', colName: 'TextBox 4' },
{ name: 'ven_group', type: 'date', colName: 'TextBox 6' },
{ name: 'ven_type', type: 'string', colName: 'TextBox 8' },
{ name: 'ven_parent_id', type: 'string', colName: 'TextBox 10' },
{ name: 'ven_contact_person', type: 'string', colName: 'TextBox 12' },
{ name: 'ven_com_name', type: 'string', colName: 'TextBox 14' },
{ name: 'ven_add1', type: 'string', colName: 'TextBox 16' },
{ name: 'ven_add2', type: 'string', colName: 'TextBox 18' },
{ name: 'ven_add3', type: 'number', colName: 'TextBox 20' },
{ name: 'ven_phone_no', type: 'date', colName: 'TextBox 22' },
{ name: 'ven_mobile_no', type: 'string', colName: 'TextBox 24' },
{ name: 'ven_email_add', type: 'string', colName: 'TextBox 26' },
{ name: 'ven_cit_id', type: 'string', colName: 'TextBox 28' },
{ name: 'ven_sta_id', type: 'string', colName: 'TextBox 30' },
{ name: 'ven_pincode', type: 'string', colName: 'TextBox 32' },
{ name: 'ven_country_id', type: 'string', colName: 'TextBox 34' },
{ name: 'ven_excise_range', type: 'number', colName: 'TextBox 36' },
{ name: 'ven_excise_division', type: 'date', colName: 'TextBox 38' },
{ name: 'ven_service_tax_range', type: 'string', colName: 'TextBox 40' },
{ name: 'ven_service_tax_division', type: 'string', colName: 'TextBox 42' },
{ name: 'ven_is_tds_exemption', type: 'string', colName: 'TextBox 44' },
{ name: 'ven_brm_id', type: 'string', colName: 'TextBox 46' },
{ name: 'ven_is_VAT_payment_allowed', type: 'string', colName: 'TextBox 48' },
{ name: 'ven_legal_status_proof', type: 'string', colName: 'TextBox 50' },
{ name: 'ven_original_legal_status_proof', type: 'number', colName: 'TextBox 52' },
{ name: 'ven_address_proof', type: 'date', colName: 'TextBox 54' },
{ name: 'ven_original_address_proof', type: 'string', colName: 'TextBox 56' },
{ name: 'ven_not_provide_doc', type: 'string', colName: 'TextBox 58' },
{ name: 'ven_gstin_info_flag', type: 'string', colName: 'TextBox 60' },
{ name: 'ven_gstn_no', type: 'string', colName: 'TextBox 62' },
{ name: 'ven_gstn_date', type: 'string', colName: 'TextBox 64' },
{ name: 'ven_arn_no', type: 'string', colName: 'TextBox 66' },
{ name: 'ven_gstin_status', type: 'number', colName: 'TextBox 68' },
{ name: 'ven_gstin_reg_email', type: 'date', colName: 'TextBox 70' },
{ name: 'ven_gstin_reg_mobile', type: 'string', colName: 'TextBox 72' },
{ name: 'ven_gstin_contact_person', type: 'string', colName: 'TextBox 74' },
{ name: 'ven_gstin_slab', type: 'string', colName: 'TextBox 76' },
{ name: 'ven_gstin_file', type: 'string', colName: 'TextBox 78' },
{ name: 'ven_gstn_original_file', type: 'string', colName: 'TextBox 80' },
{ name: 'ven_composition_scheme_flag', type: 'string', colName: 'TextBox 82' },
{ name: 'ven_is_unregister', type: 'number', colName: 'TextBox 84' },
{ name: 'ven_itc_noc_file', type: 'date', colName: 'TextBox 86' },
{ name: 'ven_itc_noc_original_file', type: 'string', colName: 'TextBox 88' },
{ name: 'ven_payment_days', type: 'string', colName: 'TextBox 90' },
{ name: 'ven_allowed_credit', type: 'string', colName: 'TextBox 92' },
{ name: 'ven_pt_max_amt', type: 'string', colName: 'TextBox 94' },
{ name: 'ven_credit_start', type: 'string', colName: 'TextBox 96' },
{ name: 'ven_overdue_interest_per', type: 'string', colName: 'TextBox 98' },
{ name: 'ven_import_Info', type: 'number', colName: 'TextBox 100' },
{ name: 'ven_weekly_off', type: 'date', colName: 'TextBox 102' },
{ name: 'ven_shift_id', type: 'string', colName: 'TextBox 104' },
{ name: 'ven_process_ids', type: 'string', colName: 'TextBox 106' },
{ name: 'ven_key', type: 'string', colName: 'TextBox 108' },
{ name: 'ven_evm_id', type: 'string', colName: 'TextBox 110' },
{ name: 'ven_div_id', type: 'string', colName: 'TextBox 112' },
{ name: 'ven_div_ids', type: 'string', colName: 'TextBox 114' },
{ name: 'ven_filing_status', type: 'number', colName: 'TextBox 116' },
{ name: 'ven_approval_status', type: 'date', colName: 'TextBox 118' },
{ name: 'ven_approve_dt', type: 'string', colName: 'TextBox 120' },
{ name: 'ven_approve_by', type: 'string', colName: 'TextBox 122' },
{ name: 'ven_hold_reject_reason', type: 'string', colName: 'TextBox 124' },
{ name: 'ven_base_currency', type: 'string', colName: 'TextBox 126' },
{ name: 'ven_tcs_applicable', type: 'string', colName: 'TextBox 128' },
{ name: 'ven_tcs_ref_type', type: 'string', colName: 'TextBox 130' },
{ name: 'ven_deduction', type: 'number', colName: 'TextBox 132' },
{ name: 'ven_dlvr_charge', type: 'date', colName: 'TextBox 134' },
{ name: 'ven_dispatch_mode', type: 'string', colName: 'TextBox 136' },
{ name: 'ven_frieght', type: 'string', colName: 'TextBox 138' },
{ name: 'ven_pack_chrg_incld', type: 'string', colName: 'TextBox 140' },
{ name: 'ven_insurance', type: 'string', colName: 'TextBox 142' },
{ name: 'ven_packing', type: 'string', colName: 'TextBox 144' },
{ name: 'ven_payroll', type: 'string', colName: 'TextBox 146' },
{ name: 'ven_purchase_planing', type: 'number', colName: 'TextBox 148' },
{ name: 'ven_is_auto_mail_send', type: 'date', colName: 'TextBox 150' },
{ name: 'ven_payment_term', type: 'string', colName: 'TextBox 152' },
{ name: 'ven_tax', type: 'string', colName: 'TextBox 154' },
{ name: 'ven_milk_cal_method_type', type: 'string', colName: 'TextBox 156' },
{ name: 'ven_tds_applicable_continuously', type: 'string', colName: 'TextBox 158' },
{ name: 'ven_distance', type: 'string', colName: 'TextBox 160' },
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
{ name: 'ven_code', type: 'string', colName: 'TextBox 0' },
{ name: 'ven_name', type: 'string', colName: 'TextBox 2' },
{ name: 'ven_org_type', type: 'number', colName: 'TextBox 4' },
{ name: 'ven_group', type: 'date', colName: 'TextBox 6' },
{ name: 'ven_type', type: 'string', colName: 'TextBox 8' },
{ name: 'ven_parent_id', type: 'string', colName: 'TextBox 10' },
{ name: 'ven_contact_person', type: 'string', colName: 'TextBox 12' },
{ name: 'ven_com_name', type: 'string', colName: 'TextBox 14' },
{ name: 'ven_add1', type: 'string', colName: 'TextBox 16' },
{ name: 'ven_add2', type: 'string', colName: 'TextBox 18' },
{ name: 'ven_add3', type: 'number', colName: 'TextBox 20' },
{ name: 'ven_phone_no', type: 'date', colName: 'TextBox 22' },
{ name: 'ven_mobile_no', type: 'string', colName: 'TextBox 24' },
{ name: 'ven_email_add', type: 'string', colName: 'TextBox 26' },
{ name: 'ven_cit_id', type: 'string', colName: 'TextBox 28' },
{ name: 'ven_sta_id', type: 'string', colName: 'TextBox 30' },
{ name: 'ven_pincode', type: 'string', colName: 'TextBox 32' },
{ name: 'ven_country_id', type: 'string', colName: 'TextBox 34' },
{ name: 'ven_excise_range', type: 'number', colName: 'TextBox 36' },
{ name: 'ven_excise_division', type: 'date', colName: 'TextBox 38' },
{ name: 'ven_service_tax_range', type: 'string', colName: 'TextBox 40' },
{ name: 'ven_service_tax_division', type: 'string', colName: 'TextBox 42' },
{ name: 'ven_is_tds_exemption', type: 'string', colName: 'TextBox 44' },
{ name: 'ven_brm_id', type: 'string', colName: 'TextBox 46' },
{ name: 'ven_is_VAT_payment_allowed', type: 'string', colName: 'TextBox 48' },
{ name: 'ven_legal_status_proof', type: 'string', colName: 'TextBox 50' },
{ name: 'ven_original_legal_status_proof', type: 'number', colName: 'TextBox 52' },
{ name: 'ven_address_proof', type: 'date', colName: 'TextBox 54' },
{ name: 'ven_original_address_proof', type: 'string', colName: 'TextBox 56' },
{ name: 'ven_not_provide_doc', type: 'string', colName: 'TextBox 58' },
{ name: 'ven_gstin_info_flag', type: 'string', colName: 'TextBox 60' },
{ name: 'ven_gstn_no', type: 'string', colName: 'TextBox 62' },
{ name: 'ven_gstn_date', type: 'string', colName: 'TextBox 64' },
{ name: 'ven_arn_no', type: 'string', colName: 'TextBox 66' },
{ name: 'ven_gstin_status', type: 'number', colName: 'TextBox 68' },
{ name: 'ven_gstin_reg_email', type: 'date', colName: 'TextBox 70' },
{ name: 'ven_gstin_reg_mobile', type: 'string', colName: 'TextBox 72' },
{ name: 'ven_gstin_contact_person', type: 'string', colName: 'TextBox 74' },
{ name: 'ven_gstin_slab', type: 'string', colName: 'TextBox 76' },
{ name: 'ven_gstin_file', type: 'string', colName: 'TextBox 78' },
{ name: 'ven_gstn_original_file', type: 'string', colName: 'TextBox 80' },
{ name: 'ven_composition_scheme_flag', type: 'string', colName: 'TextBox 82' },
{ name: 'ven_is_unregister', type: 'number', colName: 'TextBox 84' },
{ name: 'ven_itc_noc_file', type: 'date', colName: 'TextBox 86' },
{ name: 'ven_itc_noc_original_file', type: 'string', colName: 'TextBox 88' },
{ name: 'ven_payment_days', type: 'string', colName: 'TextBox 90' },
{ name: 'ven_allowed_credit', type: 'string', colName: 'TextBox 92' },
{ name: 'ven_pt_max_amt', type: 'string', colName: 'TextBox 94' },
{ name: 'ven_credit_start', type: 'string', colName: 'TextBox 96' },
{ name: 'ven_overdue_interest_per', type: 'string', colName: 'TextBox 98' },
{ name: 'ven_import_Info', type: 'number', colName: 'TextBox 100' },
{ name: 'ven_weekly_off', type: 'date', colName: 'TextBox 102' },
{ name: 'ven_shift_id', type: 'string', colName: 'TextBox 104' },
{ name: 'ven_process_ids', type: 'string', colName: 'TextBox 106' },
{ name: 'ven_key', type: 'string', colName: 'TextBox 108' },
{ name: 'ven_evm_id', type: 'string', colName: 'TextBox 110' },
{ name: 'ven_div_id', type: 'string', colName: 'TextBox 112' },
{ name: 'ven_div_ids', type: 'string', colName: 'TextBox 114' },
{ name: 'ven_filing_status', type: 'number', colName: 'TextBox 116' },
{ name: 'ven_approval_status', type: 'date', colName: 'TextBox 118' },
{ name: 'ven_approve_dt', type: 'string', colName: 'TextBox 120' },
{ name: 'ven_approve_by', type: 'string', colName: 'TextBox 122' },
{ name: 'ven_hold_reject_reason', type: 'string', colName: 'TextBox 124' },
{ name: 'ven_base_currency', type: 'string', colName: 'TextBox 126' },
{ name: 'ven_tcs_applicable', type: 'string', colName: 'TextBox 128' },
{ name: 'ven_tcs_ref_type', type: 'string', colName: 'TextBox 130' },
{ name: 'ven_deduction', type: 'number', colName: 'TextBox 132' },
{ name: 'ven_dlvr_charge', type: 'date', colName: 'TextBox 134' },
{ name: 'ven_dispatch_mode', type: 'string', colName: 'TextBox 136' },
{ name: 'ven_frieght', type: 'string', colName: 'TextBox 138' },
{ name: 'ven_pack_chrg_incld', type: 'string', colName: 'TextBox 140' },
{ name: 'ven_insurance', type: 'string', colName: 'TextBox 142' },
{ name: 'ven_packing', type: 'string', colName: 'TextBox 144' },
{ name: 'ven_payroll', type: 'string', colName: 'TextBox 146' },
{ name: 'ven_purchase_planing', type: 'number', colName: 'TextBox 148' },
{ name: 'ven_is_auto_mail_send', type: 'date', colName: 'TextBox 150' },
{ name: 'ven_payment_term', type: 'string', colName: 'TextBox 152' },
{ name: 'ven_tax', type: 'string', colName: 'TextBox 154' },
{ name: 'ven_milk_cal_method_type', type: 'string', colName: 'TextBox 156' },
{ name: 'ven_tds_applicable_continuously', type: 'string', colName: 'TextBox 158' },
{ name: 'ven_distance', type: 'string', colName: 'TextBox 160' }],
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
                url: "ajax_entt.aspx",
                async: true,
                data: "gven_user_id=<%=Session["user_id"]%>&sign=vendor",
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
                data: "GridDef_user_id=<%=Session["user_id"]%>&Grid_name=vendor",
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
                return ((editflag>0) ? '<i title="Edit" style="cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px" onClick="Editclick(event)" id="' + id + '" class="fal fa-edit" ></i>':'') 
                       + '<i title="View" style="cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px" onClick="Viewclick(event)" id="' + id + '" class="fal fa-eye" ></i>'
                       + ((deleteflag>0) ? '<i title="Delete" style="cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px" onClick="Deleteclick(event)" id="' + id + '" class="fal fa-trash-alt" ></i>' :'')
                       + ((viewLogflag>0 && dataRecord.modify_dnt != null ) ?'<i title="View Log" style="cursor:pointer;font-size:18px;padding-left:8px;padding-top: 5px" onClick="viewLog(event)" id="' + id + '" class="fal fa-database" ></i>':'')
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
                        window.location.href = "form_entt_vendor.aspx";
                    });
                    // Export In Excel
                    ExportBtn.click(function (event) 
                    {
                        $("#jqxgrid").jqxGrid('exportdata', 'xls', 'vendor_Detail');
                    });
                    //Deleted Log
                    deletedLogButton.click(function (event) {

                        $("#jqxgridViewLog").show();
                        $.ajax({
                            type: "POST",
                            url: "ajax_entt.aspx",
                            async: true,
                            data: "dlv_ven_user_id=<%=Session["user_id"]%>&sign=vendor",
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
{ text: 'TextBox 0', datafield: 'ven_code',filtertype: 'input' },
{ text: 'TextBox 2', datafield: 'ven_name',filtertype: 'input' },
{ text: 'TextBox 4', datafield: 'ven_org_type',filtertype: 'number' },
{ text: 'TextBox 6', datafield: 'ven_group',filtertype: 'range' },
{ text: 'TextBox 8', datafield: 'ven_type',filtertype: 'input' },
{ text: 'TextBox 10', datafield: 'ven_parent_id',filtertype: 'input' },
{ text: 'TextBox 12', datafield: 'ven_contact_person',filtertype: 'input' },
{ text: 'TextBox 14', datafield: 'ven_com_name',filtertype: 'input' },
{ text: 'TextBox 16', datafield: 'ven_add1',filtertype: 'input' },
{ text: 'TextBox 18', datafield: 'ven_add2',filtertype: 'input' },
{ text: 'TextBox 20', datafield: 'ven_add3',filtertype: 'number' },
{ text: 'TextBox 22', datafield: 'ven_phone_no',filtertype: 'range' },
{ text: 'TextBox 24', datafield: 'ven_mobile_no',filtertype: 'input' },
{ text: 'TextBox 26', datafield: 'ven_email_add',filtertype: 'input' },
{ text: 'TextBox 28', datafield: 'ven_cit_id',filtertype: 'input' },
{ text: 'TextBox 30', datafield: 'ven_sta_id',filtertype: 'input' },
{ text: 'TextBox 32', datafield: 'ven_pincode',filtertype: 'input' },
{ text: 'TextBox 34', datafield: 'ven_country_id',filtertype: 'input' },
{ text: 'TextBox 36', datafield: 'ven_excise_range',filtertype: 'number' },
{ text: 'TextBox 38', datafield: 'ven_excise_division',filtertype: 'range' },
{ text: 'TextBox 40', datafield: 'ven_service_tax_range',filtertype: 'input' },
{ text: 'TextBox 42', datafield: 'ven_service_tax_division',filtertype: 'input' },
{ text: 'TextBox 44', datafield: 'ven_is_tds_exemption',filtertype: 'input' },
{ text: 'TextBox 46', datafield: 'ven_brm_id',filtertype: 'input' },
{ text: 'TextBox 48', datafield: 'ven_is_VAT_payment_allowed',filtertype: 'input' },
{ text: 'TextBox 50', datafield: 'ven_legal_status_proof',filtertype: 'input' },
{ text: 'TextBox 52', datafield: 'ven_original_legal_status_proof',filtertype: 'number' },
{ text: 'TextBox 54', datafield: 'ven_address_proof',filtertype: 'range' },
{ text: 'TextBox 56', datafield: 'ven_original_address_proof',filtertype: 'input' },
{ text: 'TextBox 58', datafield: 'ven_not_provide_doc',filtertype: 'input' },
{ text: 'TextBox 60', datafield: 'ven_gstin_info_flag',filtertype: 'input' },
{ text: 'TextBox 62', datafield: 'ven_gstn_no',filtertype: 'input' },
{ text: 'TextBox 64', datafield: 'ven_gstn_date',filtertype: 'input' },
{ text: 'TextBox 66', datafield: 'ven_arn_no',filtertype: 'input' },
{ text: 'TextBox 68', datafield: 'ven_gstin_status',filtertype: 'number' },
{ text: 'TextBox 70', datafield: 'ven_gstin_reg_email',filtertype: 'range' },
{ text: 'TextBox 72', datafield: 'ven_gstin_reg_mobile',filtertype: 'input' },
{ text: 'TextBox 74', datafield: 'ven_gstin_contact_person',filtertype: 'input' },
{ text: 'TextBox 76', datafield: 'ven_gstin_slab',filtertype: 'input' },
{ text: 'TextBox 78', datafield: 'ven_gstin_file',filtertype: 'input' },
{ text: 'TextBox 80', datafield: 'ven_gstn_original_file',filtertype: 'input' },
{ text: 'TextBox 82', datafield: 'ven_composition_scheme_flag',filtertype: 'input' },
{ text: 'TextBox 84', datafield: 'ven_is_unregister',filtertype: 'number' },
{ text: 'TextBox 86', datafield: 'ven_itc_noc_file',filtertype: 'range' },
{ text: 'TextBox 88', datafield: 'ven_itc_noc_original_file',filtertype: 'input' },
{ text: 'TextBox 90', datafield: 'ven_payment_days',filtertype: 'input' },
{ text: 'TextBox 92', datafield: 'ven_allowed_credit',filtertype: 'input' },
{ text: 'TextBox 94', datafield: 'ven_pt_max_amt',filtertype: 'input' },
{ text: 'TextBox 96', datafield: 'ven_credit_start',filtertype: 'input' },
{ text: 'TextBox 98', datafield: 'ven_overdue_interest_per',filtertype: 'input' },
{ text: 'TextBox 100', datafield: 'ven_import_Info',filtertype: 'number' },
{ text: 'TextBox 102', datafield: 'ven_weekly_off',filtertype: 'range' },
{ text: 'TextBox 104', datafield: 'ven_shift_id',filtertype: 'input' },
{ text: 'TextBox 106', datafield: 'ven_process_ids',filtertype: 'input' },
{ text: 'TextBox 108', datafield: 'ven_key',filtertype: 'input' },
{ text: 'TextBox 110', datafield: 'ven_evm_id',filtertype: 'input' },
{ text: 'TextBox 112', datafield: 'ven_div_id',filtertype: 'input' },
{ text: 'TextBox 114', datafield: 'ven_div_ids',filtertype: 'input' },
{ text: 'TextBox 116', datafield: 'ven_filing_status',filtertype: 'number' },
{ text: 'TextBox 118', datafield: 'ven_approval_status',filtertype: 'range' },
{ text: 'TextBox 120', datafield: 'ven_approve_dt',filtertype: 'input' },
{ text: 'TextBox 122', datafield: 'ven_approve_by',filtertype: 'input' },
{ text: 'TextBox 124', datafield: 'ven_hold_reject_reason',filtertype: 'input' },
{ text: 'TextBox 126', datafield: 'ven_base_currency',filtertype: 'input' },
{ text: 'TextBox 128', datafield: 'ven_tcs_applicable',filtertype: 'input' },
{ text: 'TextBox 130', datafield: 'ven_tcs_ref_type',filtertype: 'input' },
{ text: 'TextBox 132', datafield: 'ven_deduction',filtertype: 'number' },
{ text: 'TextBox 134', datafield: 'ven_dlvr_charge',filtertype: 'range' },
{ text: 'TextBox 136', datafield: 'ven_dispatch_mode',filtertype: 'input' },
{ text: 'TextBox 138', datafield: 'ven_frieght',filtertype: 'input' },
{ text: 'TextBox 140', datafield: 'ven_pack_chrg_incld',filtertype: 'input' },
{ text: 'TextBox 142', datafield: 'ven_insurance',filtertype: 'input' },
{ text: 'TextBox 144', datafield: 'ven_packing',filtertype: 'input' },
{ text: 'TextBox 146', datafield: 'ven_payroll',filtertype: 'input' },
{ text: 'TextBox 148', datafield: 'ven_purchase_planing',filtertype: 'number' },
{ text: 'TextBox 150', datafield: 'ven_is_auto_mail_send',filtertype: 'range' },
{ text: 'TextBox 152', datafield: 'ven_payment_term',filtertype: 'input' },
{ text: 'TextBox 154', datafield: 'ven_tax',filtertype: 'input' },
{ text: 'TextBox 156', datafield: 'ven_milk_cal_method_type',filtertype: 'input' },
{ text: 'TextBox 158', datafield: 'ven_tds_applicable_continuously',filtertype: 'input' },
{ text: 'TextBox 160', datafield: 'ven_distance',filtertype: 'input' },
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
{ text: 'TextBox 0', datafield: 'ven_code',filtertype: 'input' },
{ text: 'TextBox 2', datafield: 'ven_name',filtertype: 'input' },
{ text: 'TextBox 4', datafield: 'ven_org_type',filtertype: 'number' },
{ text: 'TextBox 6', datafield: 'ven_group',filtertype: 'range' },
{ text: 'TextBox 8', datafield: 'ven_type',filtertype: 'input' },
{ text: 'TextBox 10', datafield: 'ven_parent_id',filtertype: 'input' },
{ text: 'TextBox 12', datafield: 'ven_contact_person',filtertype: 'input' },
{ text: 'TextBox 14', datafield: 'ven_com_name',filtertype: 'input' },
{ text: 'TextBox 16', datafield: 'ven_add1',filtertype: 'input' },
{ text: 'TextBox 18', datafield: 'ven_add2',filtertype: 'input' },
{ text: 'TextBox 20', datafield: 'ven_add3',filtertype: 'number' },
{ text: 'TextBox 22', datafield: 'ven_phone_no',filtertype: 'range' },
{ text: 'TextBox 24', datafield: 'ven_mobile_no',filtertype: 'input' },
{ text: 'TextBox 26', datafield: 'ven_email_add',filtertype: 'input' },
{ text: 'TextBox 28', datafield: 'ven_cit_id',filtertype: 'input' },
{ text: 'TextBox 30', datafield: 'ven_sta_id',filtertype: 'input' },
{ text: 'TextBox 32', datafield: 'ven_pincode',filtertype: 'input' },
{ text: 'TextBox 34', datafield: 'ven_country_id',filtertype: 'input' },
{ text: 'TextBox 36', datafield: 'ven_excise_range',filtertype: 'number' },
{ text: 'TextBox 38', datafield: 'ven_excise_division',filtertype: 'range' },
{ text: 'TextBox 40', datafield: 'ven_service_tax_range',filtertype: 'input' },
{ text: 'TextBox 42', datafield: 'ven_service_tax_division',filtertype: 'input' },
{ text: 'TextBox 44', datafield: 'ven_is_tds_exemption',filtertype: 'input' },
{ text: 'TextBox 46', datafield: 'ven_brm_id',filtertype: 'input' },
{ text: 'TextBox 48', datafield: 'ven_is_VAT_payment_allowed',filtertype: 'input' },
{ text: 'TextBox 50', datafield: 'ven_legal_status_proof',filtertype: 'input' },
{ text: 'TextBox 52', datafield: 'ven_original_legal_status_proof',filtertype: 'number' },
{ text: 'TextBox 54', datafield: 'ven_address_proof',filtertype: 'range' },
{ text: 'TextBox 56', datafield: 'ven_original_address_proof',filtertype: 'input' },
{ text: 'TextBox 58', datafield: 'ven_not_provide_doc',filtertype: 'input' },
{ text: 'TextBox 60', datafield: 'ven_gstin_info_flag',filtertype: 'input' },
{ text: 'TextBox 62', datafield: 'ven_gstn_no',filtertype: 'input' },
{ text: 'TextBox 64', datafield: 'ven_gstn_date',filtertype: 'input' },
{ text: 'TextBox 66', datafield: 'ven_arn_no',filtertype: 'input' },
{ text: 'TextBox 68', datafield: 'ven_gstin_status',filtertype: 'number' },
{ text: 'TextBox 70', datafield: 'ven_gstin_reg_email',filtertype: 'range' },
{ text: 'TextBox 72', datafield: 'ven_gstin_reg_mobile',filtertype: 'input' },
{ text: 'TextBox 74', datafield: 'ven_gstin_contact_person',filtertype: 'input' },
{ text: 'TextBox 76', datafield: 'ven_gstin_slab',filtertype: 'input' },
{ text: 'TextBox 78', datafield: 'ven_gstin_file',filtertype: 'input' },
{ text: 'TextBox 80', datafield: 'ven_gstn_original_file',filtertype: 'input' },
{ text: 'TextBox 82', datafield: 'ven_composition_scheme_flag',filtertype: 'input' },
{ text: 'TextBox 84', datafield: 'ven_is_unregister',filtertype: 'number' },
{ text: 'TextBox 86', datafield: 'ven_itc_noc_file',filtertype: 'range' },
{ text: 'TextBox 88', datafield: 'ven_itc_noc_original_file',filtertype: 'input' },
{ text: 'TextBox 90', datafield: 'ven_payment_days',filtertype: 'input' },
{ text: 'TextBox 92', datafield: 'ven_allowed_credit',filtertype: 'input' },
{ text: 'TextBox 94', datafield: 'ven_pt_max_amt',filtertype: 'input' },
{ text: 'TextBox 96', datafield: 'ven_credit_start',filtertype: 'input' },
{ text: 'TextBox 98', datafield: 'ven_overdue_interest_per',filtertype: 'input' },
{ text: 'TextBox 100', datafield: 'ven_import_Info',filtertype: 'number' },
{ text: 'TextBox 102', datafield: 'ven_weekly_off',filtertype: 'range' },
{ text: 'TextBox 104', datafield: 'ven_shift_id',filtertype: 'input' },
{ text: 'TextBox 106', datafield: 'ven_process_ids',filtertype: 'input' },
{ text: 'TextBox 108', datafield: 'ven_key',filtertype: 'input' },
{ text: 'TextBox 110', datafield: 'ven_evm_id',filtertype: 'input' },
{ text: 'TextBox 112', datafield: 'ven_div_id',filtertype: 'input' },
{ text: 'TextBox 114', datafield: 'ven_div_ids',filtertype: 'input' },
{ text: 'TextBox 116', datafield: 'ven_filing_status',filtertype: 'number' },
{ text: 'TextBox 118', datafield: 'ven_approval_status',filtertype: 'range' },
{ text: 'TextBox 120', datafield: 'ven_approve_dt',filtertype: 'input' },
{ text: 'TextBox 122', datafield: 'ven_approve_by',filtertype: 'input' },
{ text: 'TextBox 124', datafield: 'ven_hold_reject_reason',filtertype: 'input' },
{ text: 'TextBox 126', datafield: 'ven_base_currency',filtertype: 'input' },
{ text: 'TextBox 128', datafield: 'ven_tcs_applicable',filtertype: 'input' },
{ text: 'TextBox 130', datafield: 'ven_tcs_ref_type',filtertype: 'input' },
{ text: 'TextBox 132', datafield: 'ven_deduction',filtertype: 'number' },
{ text: 'TextBox 134', datafield: 'ven_dlvr_charge',filtertype: 'range' },
{ text: 'TextBox 136', datafield: 'ven_dispatch_mode',filtertype: 'input' },
{ text: 'TextBox 138', datafield: 'ven_frieght',filtertype: 'input' },
{ text: 'TextBox 140', datafield: 'ven_pack_chrg_incld',filtertype: 'input' },
{ text: 'TextBox 142', datafield: 'ven_insurance',filtertype: 'input' },
{ text: 'TextBox 144', datafield: 'ven_packing',filtertype: 'input' },
{ text: 'TextBox 146', datafield: 'ven_payroll',filtertype: 'input' },
{ text: 'TextBox 148', datafield: 'ven_purchase_planing',filtertype: 'number' },
{ text: 'TextBox 150', datafield: 'ven_is_auto_mail_send',filtertype: 'range' },
{ text: 'TextBox 152', datafield: 'ven_payment_term',filtertype: 'input' },
{ text: 'TextBox 154', datafield: 'ven_tax',filtertype: 'input' },
{ text: 'TextBox 156', datafield: 'ven_milk_cal_method_type',filtertype: 'input' },
{ text: 'TextBox 158', datafield: 'ven_tds_applicable_continuously',filtertype: 'input' },
{ text: 'TextBox 160', datafield: 'ven_distance',filtertype: 'input' }]
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