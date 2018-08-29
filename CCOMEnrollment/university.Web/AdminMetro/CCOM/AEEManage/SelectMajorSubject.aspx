<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectMajorSubject.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AEEManage.SelectMajorSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看考生科目成绩</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
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
                            <h3 class="page-title">查看考生科目成绩
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="#">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="#">艺考成绩管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">查看考生成绩
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">
                           <div class="control-group">
                                <label class="control-label" for="txtExam"><b style="color: red;">*</b>系名称：</label>
                                <div class="controls">
                                     <asp:DropDownList ID="ddlClique" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlClique_SelectedIndexChanged"/>
                                     <asp:Label ID="LabelExamRoom" runat="server" Text="" style="color: red;"></asp:Label>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtMajor"><b style="color: red;">*</b>专业名称：</label>
                                <div class="controls">
                                     <asp:DropDownList ID="ddlMajor" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged"/>
                                     <asp:Label ID="Label1" runat="server" Text="" style="color: red;"></asp:Label>
                                </div>
                            </div>      
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>科目名称：</label>
                                <div class="controls" style="padding-top: 3px;">
                                    <asp:RadioButtonList ID="radioSub" runat="server" AutoPostBack="False" OnSelectedIndexChanged="radioSub_SelectedIndexChanged"/>
                                    
                                    <asp:Label ID="lblNowHasJudge" runat="server" Text="" style="color: red;"></asp:Label>
                                </div>
                            </div>
                                          
                             <div class="form-actions" style="border-top: none;margin-bottom: 50px;">
                                 <span class="span1"></span>
                              <asp:Button ID="btnSubmit" runat="server" Text="前往查看" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                                        <asp:Label ID="lblSubmit" runat="server" Text=""></asp:Label>
                            </div>


                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- 
                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">

                    
                        </div>
                    </div>--%>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>


