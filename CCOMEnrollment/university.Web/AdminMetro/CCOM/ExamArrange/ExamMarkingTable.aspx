<%@ Page Language="C#" AutoEventWireup="true" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.ExamMarkingTable" CodeFile="ExamMarkingTable.aspx.cs" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打分表</title>
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
                            <h3 class="page-title">打分表</h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <a class="btn btn-success" href="javascript:void(0);" onclick="myPrint();">打印打分表</a>
                        <p></p>
                        <asp:ScriptManager ID="ScriptManager2" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                            <ContentTemplate>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle">科目名</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="select2" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                                            <asp:ListItem Value="#">--请选择科目--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
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
                                        <b id="b">中央音乐学院<%=periodYear%>年本科招生考试打分表</b>
                                        <p></p>
                                        <p id="p"><%=examInfo %></p>
                                    </div>
                                    <asp:Table ID="studentTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="100%">
                                    </asp:Table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>
