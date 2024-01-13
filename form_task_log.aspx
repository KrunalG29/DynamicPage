<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form_task_log.aspx.cs" Inherits="form_task_log" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New/Edit Task Log</title>
     <link runat="server" rel="shortcut icon" href="logo_infinityinfoway.com.png" type="image/x-icon" />
    <link runat="server" rel="icon" href="logo_infinityinfoway.com.png" type="image/ico" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.4.1/jquery.min.js" integrity="sha512-nMfwEl3895BA1+quPaSgiwpjk+lfpu7s+mK0H8WmSLSREzaGqt37evTRnBw6eFXmXfAmUbyN1rTOPE8gMgSSkg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.4.1/jquery.js" integrity="sha512-wlXxbt7zNAa2rEsfOVGtwZzyWcQGX3mLKfcdGg6liuv0EdrQxU5VFCOTYQCfFznpHGjDm4CiW2eH7zYdn4HCXg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="ckeditor/ckeditor.js"></script>
    <script>
<%--     $(function () {
            CKEDITOR.replace('<%=txt_task_log.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
        });--%>
    </script>
    <style> 
        .form-control {
            display: block;
            width: 100%;
            height: 30px;
            font-size: 13px;
            line-height: 1.42857143;
            color: #555555;
            background-color: #ffffff;
            background-image: none;
            border: 1px solid #cccccc;
            border-radius: 0px;
            -webkit-box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s
        }

            .form-control:focus {
                border-color: #66afe9;
                background-color: #ecf7ff;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(102, 175, 233, 0.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(102, 175, 233, 0.6);
            }
    </style>
     <style>
        .listMain {
            border: solid 1px #66afe9;
            background-color: #ecf7ff;
            padding: 0;
            list-style: none;
            margin: 0;
            height: 150px;
            overflow: auto;
               
            
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #333;
            font-size: 13px;
            font-weight: 400;
            z-index: 100;
            text-align: left
        }

        .listMainMS {
            border: solid 1px #6ba2de;
            padding: 0;
            list-style: none;
            margin: 0;
            height: 300px;
            overflow: auto;
            
            font-family: Calibri;
            color: #000;
            font-weight: 700;
            background: #fff;
            z-index: 100;
            text-align: left
        }

        .itemsMain {
            background-color: #ecf7ff;
            padding: 5px;
            list-style: none;
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #333;
            font-size: 13px;
            font-weight: 400;
            cursor: pointer;
            z-index: 100
        }

        .itemsSelected {
            background: #1083ea;
            border: solid 1px #66afe9;
            padding: 5px;
            list-style: none;
            font-family: "Open Sans",Arial,Helvetica,Sans-Serif;
            color: #fff;
            font-size: 13px;
            font-weight: 700;
            cursor: pointer
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <section class="col col-6" style="margin-left: 20px; margin-bottom: 20px; width: 30%; display: flex;">
                Task Id
                 <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="10000" EnablePageMethods="true"></asp:ScriptManager>
                <asp:TextBox ID="txt_task_id" Style="margin-left: 20px; margin-right: 20px;" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txt_task_id_TextChanged"></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender FirstRowSelected="true" ID="AutoCompleteExtender1" runat="server" ServicePath="~/Web_Service.asmx"
                    ServiceMethod="get_all_task" TargetControlID="txt_task_id" MinimumPrefixLength="1" ClientIDMode="AutoID"
                    CompletionListCssClass="listMain" EnableCaching="false" CompletionListHighlightedItemCssClass="itemsSelected"
                    CompletionListItemCssClass="itemsMain" UseContextKey="true" ContextKey="0">
                </ajaxToolkit:AutoCompleteExtender>
                Comp
                <asp:TextBox ID="txt_task_comp" Style="margin-left: 20px;" CssClass="form-control" runat="server"></asp:TextBox>
                  <ajaxToolkit:AutoCompleteExtender FirstRowSelected="true" ID="AutoCompleteExtender2" runat="server" ServicePath="~/Web_Service.asmx"
                    ServiceMethod="get_comp" TargetControlID="txt_task_comp" MinimumPrefixLength="1" ClientIDMode="AutoID"
                    CompletionListCssClass="listMain" EnableCaching="false" CompletionListHighlightedItemCssClass="itemsSelected"
                    CompletionListItemCssClass="itemsMain" UseContextKey="true" ContextKey="0">
                </ajaxToolkit:AutoCompleteExtender>
                <asp:Button ID="btnSave" Style="margin-left: 50px;" runat="server" Text="Save" class="btn btn-primary"
                        OnClick="btnSave_Click" />
            </section>
            <section class="col col-6">
                <CKEditor:CKEditorControl ID="txt_task_log"  Height="650px" BasePath="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>
            </section>
        </div>
        <div class="form-actions">
            <div class="row">
                <div class="col-md-12" style="text-align: center;">
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
