<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetTime.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.SetTime" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>考场管理</title>
    <!--#include file="/metro/include/header_common.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="tabIndex" runat="server" />
        <script type="text/javascript">
            $(function () {
                var tabIndex = $("#tabIndex").val();
                if (tabIndex != "") {
                    showTab("#pageTab1", parseInt(tabIndex));
                }
            });
            function showTab(tabId, tabIndex) {
                $(tabId + " li:eq(" + (tabIndex - 1) + ") a").tab('show');
            }
        </script>
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <h3 class="page-title">设置报考周期
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs" id="pageTab1">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">周期列表</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <asp:LinkButton ID="lblOpenThisYear" CssClass="btn btn-success" OnClientClick="return confirm('确定要开启本年度报考周期吗?');void(0);" OnClick="lbtOpenThisYear_Click" runat="server" Text="创建本年度报考周期"></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lblOpenLastYear" CssClass="btn btn-success" OnClientClick="return confirm('确定要开启明年报考周期吗?');void(0);" OnClick="lbtOpenLastYear_Click" runat="server" Text="创建明年报考周期"></asp:LinkButton>
                                            </div>

                                            <div class="span6">
                                                <div class="pull-right">
                                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="rptList" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                            <tr>
                                                                <th width="5%">序号</th>
                                                                <th align="left">年份</th>
                                                                <th align="left">注册开启时间</th>
                                                                <th align="left">注册结束时间</th>
                                                                <th align="left">排考开启时间</th>
                                                                <th align="left">排考结束时间</th>
                                                                <th align="left">状态</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# rptList.Items.Count + 1 %>
                                                            </td>
                                                            <td align="left">
                                                                <%#Eval("Period_year")%>
                                                            </td>
                                                            <td align="left"><%#Eval("Period_register_start")%></td>
                                                            <td align="left"><%#Eval("Period_register_end")%></td>
                                                            <td align="left"><%#Eval("Period_arrange_start")%></td>
                                                            <td align="left"><%#Eval("Period_arrange_end")%></td>
                                                            <td align="left"><%#(bool) Eval("Period_state")?"开启":"关闭"%></td>
                                                            <td align="center">
                                                                <asp:LinkButton ID="lbt" OnClientClick="return confirm('确定要关闭该周期吗?');void(0);" OnClick="lbtClose_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Period_id").ToString())%>' Text="关闭"></asp:LinkButton>
                                                                &nbsp;
                                                                <asp:LinkButton ID="lbt1" OnClientClick="return confirm('确定要开启该周期吗?');void(0);" OnClick="lbtOpen_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Period_id").ToString())%>' Text="开启"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>



                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <%--<div class="span6">
                                                显示<asp:TextBox ID="txtPageNum" Visible="false" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                                            </div>--%>
                                            <div class="span6">
                                                <div class="pull-right">
                                                    <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>
