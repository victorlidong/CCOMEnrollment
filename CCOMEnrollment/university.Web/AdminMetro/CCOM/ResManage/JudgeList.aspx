<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JudgeList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ResManage.JudgeList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>评委管理</title>
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
                            <h3 class="page-title">评委管理
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs" id="pageTab1">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">评委列表</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <a href="JudgeAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>添加评委</a>
                                                 &nbsp;
                                                <a href="JudgeBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量添加</a>
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
                                                                <th align="left">姓名</th>
                                                                <th align="left">教工号</th>
                                                                <th align="left">所属部门</th>
                                                                <th align="left">职称</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# rptList.Items.Count + 1 %>
                                                            </td>
                                                            <td align="left"><%#GetJudgeName(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeStaffNumber(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeDepartment(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeTitle(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="center">
                                                                <%#GetEditLink(DESEncrypt.Encrypt(Eval("Judge_id").ToString()))%>
                               
                                &nbsp;
                                 <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该评委吗?');void(0);" OnClick="lbtSingleDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Judge_id").ToString())%>' Text="删除"></asp:LinkButton>
                                                                &nbsp;
                                
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
