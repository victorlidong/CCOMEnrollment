<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormReview.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.FormReview" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>形式审查表</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript">
        function EditForm(id) {
            $("#" + id).show();
            var _width = $("#" + id).width();
            $.layer({
                type: 1,
                shade: [0.8, '#000'],
                area: [_width + 'px', 'auto'],
                title: false,
                border: [0],
                shadeClose: true,
                page: { dom: '#' + id },
                closeBtn: [0, true],
                close: function (index) {
                    $("#" + id).hide();
                }
            });
        }

        function ChangeSelectValue(obj,userID,formID) {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'UpdateFormValue',
                    UserID: userID,
                    FormID: formID,
                    SelectValue: $(obj).val(),
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                    }
                }
            });
        }

        function SutdentSubmit() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'SutdentSubmitForm',
                    type: "1",
                    userid: $("#MyUserID").val(),
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        parent.jsprint("提交成功！", "", "Success", "");
                        location.reload();
                    }
                }
            });
        }

        function TeacherSubmit(result) {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'TeacherSubmitForm',
                    userid: $("#MyUserID").val(),
                    type: "1",
                    result: result,
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        parent.jsprint("审核成功！", "", "Success", "");
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
        }

        function SubmitForm(state) {
            if (state == 1) {
                SutdentSubmit();
            } else{                                //审核
                EditForm("CheckForm");
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />

        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                     <div id="print_div" class="row-fluid" runat="server">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory" style="margin-left:20px;">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">形式审查表（一）
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                            <asp:TextBox ID="MyUserID" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                      <div class="row-fluid" >
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="6"--%>
                                    <%=reviewTr %>
                                </tbody>
                            </table>
                            <div class="span12 tab_con first-tab" style="height:20px;"></div>
                            <div class="span12" style="text-align: left;">
                                <div class="form-actions">
                                    <a runat="server" id="submit_button"></a>
                                </div>
                            </div>
                            <div class="span12 tab_con first-tab" style="height:20px;"></div>
                        </div>
                        </div>
                    <div class="row-fluid">
                        <div id="CheckForm" style="display: none; width: 350px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>审核</h4>
                                </div>
                                <div class="widget-body">
                                    <br />
                                    <div style="text-align:center">
                                        <a href="javascript:TeacherSubmit(1);" class="btn btn-success">及格</a>
                                        &nbsp;&nbsp;&nbsp;
                                        <a href="javascript:TeacherSubmit(2);" class="btn btn-error">不及格</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
    </form>
</body>
</html>