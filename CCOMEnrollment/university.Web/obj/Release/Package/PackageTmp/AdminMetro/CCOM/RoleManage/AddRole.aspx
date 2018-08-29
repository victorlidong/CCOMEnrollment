<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.RoleManage.AddRole" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>角色</title>
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
                            <h3 class="page-title"><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>角色
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">
                            <div class="control-group">
                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>角色名</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                    <span class="help-inline"></span>
                                </div>
                            </div>
                            <div class="form-actions">
                                <input name="重置" type="reset" class="btn" value="重 置" />
                                <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
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
