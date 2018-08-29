<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupStudentList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.GroupStudentList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>学生</title>
    <!--#include file="/metro/include/header_common.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title"><%=PageTitle %>
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div style="font-size: 16px; font-weight: bold; padding: 10px; border: 1px solid #eee; border-bottom: none;">
                               答辩组名称：<asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></div>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <tr>
                                            <th style="text-align:center;">序号</th>
                                             <th style="text-align:center;">姓名</th>
                                             <th style="text-align:center;">性别</th>
                                             <th style="text-align:center;">学号</th>
                                             <th style="text-align:center;">班号</th>
                                            <th style="text-align:center;">状态</th>
                                            <th style="text-align:center;">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align:center;">
                                            <%#rptList.Items.Count+1%>
                                        </td>
                                         <th style="text-align:center;"><%#GetStudentName(long.Parse(Eval("User_id").ToString()))%> </td>
                                        <td style="text-align: center;"><%#GetStudentGender(long.Parse(Eval("User_id").ToString()))%></td>
                                         <th style="text-align:center;"><%#GetStudentNumber(long.Parse(Eval("User_id").ToString()))%></td>
                                         <th style="text-align:center;"><%#GetStudentBan(long.Parse(Eval("User_id").ToString()))%></td>
                                         <th style="text-align:center;"><%#GetStudentStatus(long.Parse(Eval("User_id").ToString()), this.apply_id)%></td>
                                        <td style="text-align:center;">
                                              <a href="./<%=GetHref() %>.aspx?userid=<%#DESEncrypt.Encrypt( Eval("User_id").ToString())%>&groupid=<%#DESEncrypt.Encrypt(this.apply_id.ToString())%>">打分</a>
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
                            <div class="pull-right">
                                <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--common script for all pages-->
        <!--#include file="/metro/include/footer_common.html"-->
        <!--end common script for all pages-->
        <!--script for this page-->
        <!--end script for this page-->
    </form>
</body>
</html>
