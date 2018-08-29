<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintExamInfor.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.PrintExamInfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>答辩安排</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <style type="text/css">
        .firstTab{
            text-align:center;
            width:20%;
        }
        .otherTab{
            text-align:center;
            width:40%;
        }
    </style>
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
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            
                            <div class="gohistory" style="margin-left:20px;">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">答辩安排
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid" id="print_div">
                        <div class="span12">
                             <h3 class="page-title" style="text-align:center"><%=page_title %>
                            </h3>
                            <table class="table table-striped table-bordered table-hover">
                                <tbody><%--colspan="4"--%>
                                    <tr>
                                        <td style="width:15%;">答辩组名称</td>
                                        <td style="width:40%;">
                                            <asp:Label ID="lbltitle" runat="server">答辩组一</asp:Label>
                                        </td>
                                        <td style="width:10%;text-align:center">答辩类型</td>
                                        <td style="width:35%;text-align:center">
                                            <asp:Label ID="lbltype" runat="server">3月4日 13:00</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td>答辩时间</td>
                                        <td >
                                            <asp:Label ID="lbltime" runat="server">3月4日 13:00</asp:Label>
                                        </td>
                                        <td style="text-align:center">答辩地点</td>
                                        <td style="text-align:center">
                                            <asp:Label ID="lblplace" runat="server">教学楼611</asp:Label>
                                        </td>
                                    </tr>
                                    </tbody></table>
                                <table border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered table-hover" style="margin-top:40px;width:100%;">
                                    <tbody>
                                    <tr>
                                        <td colspan="3" style="text-align:center">答辩委员会成员</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;width:20%">姓名</td>
                                        <td style="text-align:center;width:20%">职称</td>
                                        <td style="text-align:center;width:60%">主要分工</td>
                                    </tr>
                                    <%=reviewTr1 %>
                                        </tbody></table>
                                <table border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered table-hover" style="margin-top:40px;width:100%;">
                                    <tbody>
                                    <tr>
                                        <td colspan="4" style="text-align:center">答辩组学生</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;width:15%">姓名</td>
                                        <td style="text-align:center;width:15%">学号</td>
                                        <td style="text-align:center;width:15%">指导教师</td>
                                        <td style="text-align:center;width:55%">题目</td>
                                    </tr>
                                    <%=reviewTr2 %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="span12 tab_con first-tab" style="height:20px;"></div>
                    <div class="btn btn-success" onclick="myPrint();" style="float: left;">
                        <span>打印</span>
                    </div>
                    <div class="span12 tab_con first-tab" style="height:20px;"></div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
     <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <script type="text/javascript">
        function myPrint() {
            var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            var str = document.getElementById("print_div").innerHTML;
            var docStr = str;
            newWindow.document.write(docStr);
            newWindow.document.close();
            newWindow.print();
            newWindow.close();
        }
    </script>
</body>
</html>
