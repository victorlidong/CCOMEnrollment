<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.RoleManage.RoleList" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>角色列表</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
</head>
<body>
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
                    <div class="row-fluid">
                        <div class="span12">
                            <!--BEGIN TABS-->
                            <div class="tabbable custom-tab">

                                <asp:ScriptManager ID="ScriptManager2" runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                                    <ContentTemplate>
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="tab_1_1">
                                                <div class="row-fluid">
                                                    <div class="span6"style="visibility:hidden">
                                                        <a href="AddRole.aspx?action=<%=MyEnums.ActionEnum.Add.ToString() %>&fun_id=<%=DESEncrypt.Encrypt("24") %>" class="btn btn-success"><i class="icon-plus icon-white"></i>添加角色</a>
                                                    </div>
                                                    <div class="span6">
                                                        <div class="pull-right">
                                                            <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                            <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="space5"></div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <!--列表展示.开始-->
                                                    <asp:Repeater ID="rptList" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered  table-hover" id="listTable">
                                                                <thead>
                                                                    <tr>
                                                                        <th style="width: 15%;">角色名</th>
                                                                        <th style="width: 8%;">启用状态</th>
                                                                        <th style="width: 12%;">操作</th>
                                                                    </tr>
                                                                </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:HiddenField ID="hidId" Value='<%#Eval("Role_id")%>' runat="server" />
                                                                        <%#Eval("Role_name")%>
                                                                    </td>
                                                                    <td>已<%#(Boolean)Eval("Role_status")==true?"启用":"禁用"%></td>
                                                                    <td>
                                                                        <a href="AddRole.aspx?roleId=<%#Eval("Role_id") %>&action=<%=MyEnums.ActionEnum.Edit.ToString() %>&fun_id=<%=get_fun_id("CCOM/RoleManage/AddRole.aspx") %>">
                                                                            <i class="icon-pencil"></i>编辑
                                                                        </a>
                                                                        &nbsp;
                                                                        <a href="PermissionManage.aspx?id=<%#Eval("Role_id") %>&type=0&fun_id=<%=get_fun_id("CCOM/RoleManage/PermissionManage.aspx") %>">
                                                                            <i class="icon-pencil"></i>编辑权限
                                                                        </a>
                                                                        &nbsp;
                                                                <asp:LinkButton ID="lbtAble" runat="server" OnClientClick="return confirm('属于该角色的所有用户权限都将受影响，确认操作？');void(0);" OnClick="lbtAble_Click" ToolTip='<%# DESEncrypt.Encrypt(Eval("Role_id").ToString())%>'>
                                                                        <%#GetStatusText((Boolean)Eval("Role_status"))%>
                                                                </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                                                        </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <!--列表展示.结束-->
                                                </div>

                                            </div>
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                                                </div>
                                                <div class="span6">
                                                    <div class="pull-right">
                                                        <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <!--END TABS-->
                    </div>
                </div>
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
    </form>
</body>
</html>
