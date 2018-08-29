<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPage.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.TopicManage.TeacherPage" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息</title>
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
                            <h3 class="page-title">教师信息
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="2"--%>
                                    <tr>
                                        <td style="width:10%;">职工号：</td>
                                        <td><label runat="server" id="lblNumber"></label></td>
                                    </tr>
                                    <tr>
                                        <td>姓名：</td>
                                        <td><label runat="server" id="lblName"></label></td>
                                    </tr>
                                    <tr>
                                        <td>性别：</td>
                                        <td><label runat="server" id="lblGender"></label></td>
                                    </tr>
                                    <tr>
                                        <td>部门：</td>
                                        <td><label runat="server" id="lblAgency"></label></td>
                                    </tr>
                                    <tr>
                                        <td>职称：</td>
                                        <td><label runat="server" id="lblTitle"></label></td>
                                    </tr>
                                    <tr>
                                        <td>学科方向：</td>
                                        <td><label runat="server" id="lblSubject"></label></td>
                                    </tr>
                                    <tr>
                                        <td>Email：</td>
                                        <td><label runat="server" id="lblEmail"></label></td>
                                    </tr>
                                    <tr>
                                        <td>手机：</td>
                                        <td><label runat="server" id="lblPhone"></label></td>
                                    </tr>
                                    <tr>
                                        <td>固定电话：</td>
                                        <td><label runat="server" id="lblFixedPhone"></label></td>
                                    </tr>
                                    <tr>
                                        <td>办公地址：</td>
                                        <td><label runat="server" id="lblLocation"></label></td>
                                    </tr>
                                    <tr>
                                        <td>自我介绍：</td>
                                        <td><label runat="server" id="lblIntroduce"></label></td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="span12 tab_con first-tab" style="height:200px;">
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