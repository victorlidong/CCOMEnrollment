<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckSubjectScore.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AEEManage.CheckSubjectScore" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>科目成绩查漏列表</title>
    <!--#include file="/metro/include/header_common.html"-->
        <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
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
                            <h3 class="page-title">科目成绩查漏列表
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">艺考成绩管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">艺考科目分数
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                             <div class="pull-left">
                                     <label class="control-label" for="txtExam">系名称：</label>
                                     <asp:DropDownList Style="width: 150px;" ID="ddlClique" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlClique_SelectedIndexChanged"/>
                                </div>
                              <div class="pull-left">
                                  <label class="control-label" for="txtMajor">专业名称：</label>
                                  <asp:DropDownList ID="ddlMajor" Style="width: 150px;" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged"/>
                              </div>
                        </div>
                    </div>
                    <div class="space5"></div>

                      <div class="row-fluid" id="div1">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <thead>
                                        <tr>
                                            <th style="text-align:center;">序号</th>
                                            <th style="text-align:center;">科目名称</th>
                                            <th style="text-align:center;">专业名称</th>
                                            <th style="text-align:center;">已有成绩人数</th>
                                            <th style="text-align:center;">进入复试人数</th>
                                            <th style="text-align:center;">专业方向总人数</th>
                                            <%--<th style="text-align:center;">操作</th>--%>
                                        </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="<%#DESEncrypt.Encrypt(Eval("Major_Agency_id").ToString())%>">
                                        <td style="text-align:center;">
                                            <%#this.rptList.Items.Count + 1 %>
                                        </td>
                                        <td style="text-align:center;"><%# Eval("Subject_title").ToString() %></td>
                                        <td style="text-align:center;"><%# getMajorName(Eval("Major_Agency_id").ToString()) %></td>
                                        <td style="text-align:center;"><%# getMajorScoreNum(Eval("Major_Agency_id").ToString(),Eval("Subject_id").ToString()) %></td>
                                        <td style="text-align:center;"><%# getMajorRetrialNum(Eval("Major_Agency_id").ToString()) %></td>
                                        <td style="text-align:center;"><%# getMajorNum(Eval("Major_Agency_id").ToString()) %></td>
                                        <%--<td style="text-align:center;">
                                            <a href="RetrailMembers.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>&major_id=<%#DESEncrypt.Encrypt(Eval("Major_Agency_id").ToString())%>">录入成绩</a>
                                            <a href="#" onclick="">导出名单</a>
                                        </td>--%>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

