<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySoftwarePage.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.MySoftwarePage" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>软件验收表</title>
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
                    <%-- <div id="print_div" class="row-fluid" runat="server">--%>
                     <div id="print_div" class="row-fluid" runat="server">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory" style="margin-left:20px;">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                         <%--   <h3 class="page-title"><%=PageTitle %>
                            </h3>--%>
                            <h3>软件验收表</h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                     <div id="soft" class="row-fluid" runat="server">
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
                                        <td style="text-align:center;">验收组成员名单</td>
                                        <td style="text-align:center;">姓名</td>
                                        <td style="text-align:center;">专业技术职务</td>
                                        <td colspan="3" style="text-align:center;">单位</td>
                                    </tr>
                                    <%=reviewTr %>
                                    <tr>
                                        <td style="text-align:center;">验收时间</td>
                                        <td colspan="5"><label runat="server" id="lblTime"></label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">验收资料清单</td>
                                        <td colspan="5">
                                            <textarea style="width:98%;height:100px;" runat="server" id="txtDataList"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">源语言/开发环境</td>
                                        <td colspan="2">
                                            <textarea style="width:95%;height:100px;" runat="server" id="txtAnguage"></textarea>
                                        </td>
                                        <td style="text-align:center;">运行环境/系统配置</td>
                                        <td colspan="2">
                                            <textarea style="width:95%;height:100px;" runat="server" id="txtEnvironmental"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">总代码行数/字节数（KB）</td>
                                        <td colspan="2">
                                            <textarea style="width:95%;height:100px;" runat="server" id="txtLineCount"></textarea>
                                        </td>
                                        <td style="text-align:center;">手工编写代码行数</td>
                                        <td colspan="2">
                                            <textarea style="width:95%;height:100px;" runat="server" id="txtLineHand"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">软件运行状况</td>
                                        <td colspan="5">
                                            <textarea style="width:98%;height:100px;" runat="server" id="txtRunStatus"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">软件特点及应用情况</td>
                                        <td colspan="5">
                                            <textarea style="width:98%;height:100px;" runat="server" id="txtFeature"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">验收结论（最后须给出定量的百分制结论）</td>
                                        <td colspan="5">
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