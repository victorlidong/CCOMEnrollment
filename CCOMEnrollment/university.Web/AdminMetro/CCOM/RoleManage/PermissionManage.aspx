<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionManage.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.RoleManage.PermissionManage" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>权限管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
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
                            <h3 class="page-title">管理角色
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div runat="server" id="divControls">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-actions">
                        <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
</body>
</html>
