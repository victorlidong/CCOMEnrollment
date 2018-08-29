<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSubject.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamManage.ShowSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑科目</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField runat="server" ID="hidAgencyFatherTree" />
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
                            <h3 class="page-title">编辑科目
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="row-fluid" id="contentTab">
                                <div class="span12 tab_con first-tab">
                                    <div class="control-group">
                                        <label class="control-label" for="txtTitle">系名</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="txtTitle">专业名</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlMajor" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged">
                                                <asp:ListItem Value="#">--请选择专业--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <asp:Table runat="server" ID="subjectTable" GridLines="Both" CellPadding="5" HorizontalAlign="Center" Width="100%"></asp:Table>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- END PAGE CONTAINER-->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
