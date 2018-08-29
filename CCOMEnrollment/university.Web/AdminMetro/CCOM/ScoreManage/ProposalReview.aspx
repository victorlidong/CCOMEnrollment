<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProposalReview.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.ProposalReview" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>开题评审表</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
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
                            <h3 class="page-title">开题评审表
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="6"--%>
                                    <tr>
                                        <td style="width:10%;text-align:center;">学生姓名</td>
                                        <td style="width:10%;text-align:center;"><label runat="server" id="lblName"></label></td>
                                        <td style="width:10%;text-align:center;">学号</td>
                                        <td style="width:10%;text-align:center;"><label runat="server" id="lblNumber"></label></td>
                                        <td style="width:10%;text-align:center;">导师姓名</td>
                                        <td style="width:10%;text-align:center;"><label runat="server" id="lblTeacher"></label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">论文题目</td>
                                        <td colspan="5" style="text-align:center;"><label runat="server" id="lblTitle"></label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">题目性质</td>
                                        <td colspan="2" style="text-align:center;"><label runat="server" id="lblNature"></label></td>
                                        <td style="text-align:center;">题目来源</td>
                                        <td colspan="2" style="text-align:center;"><label runat="server" id="lblSource"></label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">评审组成员名单</td>
                                        <td style="text-align:center;">姓名</td>
                                        <td style="text-align:center;">职     称</td>
                                        <td colspan="3" style="text-align:center;">工作单位及职务</td>
                                    </tr>
                                    <%=reviewTr %>
                                    <tr>
                                        <td style="text-align:center;">评审意见</td>
                                        <td colspan="5">
                                            <textarea style="width:98%;height:100px;" runat="server" id="txtOpinion"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">评审结果</td>
                                        <td colspan="5">
                                            <asp:DropDownList runat="server" ID="ddlresult">
                                                <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="通过"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="不通过"></asp:ListItem>
                                            </asp:DropDownList>
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