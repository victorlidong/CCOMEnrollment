<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentScore.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.CommentScore" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>答辩评语表</title>
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
            width:10%;
        }
        .otherTab{
            text-align:center;
            width:30%;
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
                            <h3 class="page-title">答辩评语表
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="4"--%>
                                    <tr>
                                        <td colspan="4">指导教师对毕业设计（论文）的评语：</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <textarea runat="server" id="txtTeacherComment" style="width:98%;height:150px"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>指导教师评分：</td>
                                        <td colspan="3">
                                            <input type="text" id="txtTeacherScore" runat="server" class="txtInput normal dateISO" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"/>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">答辩委员会（小组）成员：</td>
                                    </tr>
                                    <tr>
                                        <td class="firstTab">姓名</td>
                                        <td class="otherTab">职称</td>
                                        <td class="otherTab">主要分工</td>
                                        <td class="otherTab">评分</td>
                                    </tr>
                                    <%=reviewTr %>
                                    <tr>
                                        <td colspan="4">答辩中提出的主要问题及回答的简要情况：</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <textarea runat="server" id="txtProblem" style="width:98%;height:150px"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">答辩委员会（小组）的评语：</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <textarea runat="server" id="txtReviewComment" style="width:98%;height:150px"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">给定的成绩：</td>
                                        <td colspan="2">
                                            <input type="text" id="txtScore" runat="server" class="txtInput normal dateISO" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"/>

                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="span12 tab_con first-tab" style="height:200px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="btn btn-success" OnClick="btnSubmit_Click" />

                        </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>