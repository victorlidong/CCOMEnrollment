<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSubmit.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.DatumManage.StudentSubmit" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交材料</title>
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
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">提交材料
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="3"--%>
                                    <tr>
                                        <td width="10%">提交类型</td>
                                        <td>
                                            <label id="type" runat="server"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">提交状态</td>
                                        <td>
                                            <label id="state" runat="server"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">提交时间</td>
                                        <td>
                                            <label id="time" runat="server"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">导师意见</td>
                                        <td>
                                            <label id="advice" runat="server"></label>
                                        </td>
                                    </tr>
                                    <tr id="fileTR" runat="server" visible="false">
                                        <td width="10%">提交材料</td>
                                        <td>
                                            <asp:LinkButton ID="lbtnDownLoad" runat="server" OnCommand="lbtnDownLoad_Command"></asp:LinkButton>
                                            <asp:FileUpload ID="txtUserUpload" runat="server" />
                                            &nbsp;<asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="btn btn-success" OnClick="btnUpload_Click" />
                                            &nbsp;<a id="massage" runat="server" style="color:red"></a>
                                        </td>
                                    </tr>
                                    <tr id="logTRstarttime" runat="server" >
                                        <td width="10%">开始时间</td>
                                        <td >
                                            <input type="text" id="txtStarttime" runat="server" class="txtInput normal dateISO"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"/>

                                        </td>
                                    </tr>
                                    <tr id="logTRendtime" runat="server" >
                                        <td width="10%">结束时间</td>
                                        <td>
                                            <input type="text" id="txtEndtime" runat="server" class="txtInput normal dateISO"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"/>

                                        </td>
                                    </tr>
                                    <tr id="logTRcontent" runat="server" >
                                        <td width="10%">工作情况</td>
                                        <td>
                                            <label id="lbContent" runat="server"></label>
                                            <textarea id="txtContent" style="width:500px;" rows="6" runat="server"></textarea>
                                        </td>
                                    </tr>
                                    <tr id="logTRproblem" runat="server" >
                                        <td width="10%">存在问题</td>
                                        <td>
                                            <label id="lbProblem" runat="server"></label>
                                            <textarea id="txtProblem" style="width:500px;" rows="6" runat="server"></textarea>
                                        </td>
                                    </tr>
                                    <tr id="logTRplan" runat="server" >
                                        <td width="10%">工作计划</td>
                                        <td>
                                            <label id="lbPlan" runat="server"></label>
                                            <textarea id="txtPlan" style="width:500px;" rows="6" runat="server"></textarea>
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