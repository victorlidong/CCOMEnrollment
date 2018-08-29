<%@ Page Language="C#" AutoEventWireup="True" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.ExamSignInForm" CodeFile="ExamSignInForm.aspx.cs" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考场签到表</title>
    <script type="text/javascript">
        function myPrint() {
            var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            var docStr = document.getElementById("exportRoom").innerHTML;
            newWindow.document.write(docStr);
            newWindow.document.close();
            newWindow.print();
            newWindow.close();
        }
    </script>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
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
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">考场签到表</h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">
                            <a class="btn btn-success" href="javascript:void(0);" runat="server" onserverclick="exportword_ServerClick">导出签到表</a>
                            <a class="btn btn-success" href="javascript:void(0);" onclick="myPrint();">打印签到表</a>
                            <asp:Panel ID="exportRoom" runat="server">
                                <style type="text/css">
                                    #title {
                                        text-align: center;
                                    }

                                    #b {
                                        font-size: 25px;
                                    }

                                    #p {
                                        font-size: 25px;
                                    }
                                </style>
                                <div id="title">
                                    <b id="b">中央音乐学院<%=periodYear%>年招生考试考场签到表</b>
                                    <p></p>
                                    <p id="p"><%=examInfo %></p>
                                </div>
                                <asp:Table ID="studentTable" runat="server" HorizontalAlign="Center" Width="100%">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="16%"></asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>
