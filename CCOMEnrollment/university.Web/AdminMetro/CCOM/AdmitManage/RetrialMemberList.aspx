<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrialMemberList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AdmitManage.RetrialMemberList" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>复试名单列表</title>
    <!--#include file="/metro/include/header_common.html"-->
        <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
       <script type="text/javascript">
           var title = '<%= this.ddlClique.SelectedItem.Text +"复试名单汇总" %>';
           function myPrint() {
               var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
               var str = document.getElementById("div1").innerHTML;
               str = str.replaceAll("查看", "");
               var docStr = "<div class='row-fluid' style='text-align:center'><b>" + title + "</b></div><br/><style type='text/css'>#listTable_length{display:none;} #listTable_info{display:none;} #listTable_filter{display:none;} td{text-align-center;}</style>" + str;
               newWindow.document.write(docStr);
               newWindow.document.close();
               newWindow.print();
               newWindow.close();
           }
           String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
               if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
                   return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
               } else {
                   return this.replace(reallyDo, replaceWith);
               }
           }
    </script>
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
                            <h3 class="page-title">复试名单列表
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
                            <a href="#" onclick="myPrint()" class="btn btn-success"><i class="icon-download">打印表格</i></a>
                          <label style="margin-left: 20px;">系名称：</label>
                          <asp:DropDownList ID="ddlClique" CssClass="select2" Style="width: 150px;" runat="server" OnSelectedIndexChanged="ddlClique_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                            <th style="text-align:center;">系名称</th>
                                            <th style="text-align:center;">专业名称</th>
                                            <th style="text-align:center;">复试人数</th>
                                            <th style="text-align:center;">复试人数占参加考试人数百分比</th>
                                            <th style="text-align:center;">操作</th>
                                        </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="<%#DESEncrypt.Encrypt(Eval("Agency_id").ToString())%>">
                                        <td style="text-align:center;">
                                            <%#this.rptList.Items.Count + 1 %>
                                        </td>
                                        
                                        <td style="text-align:center;"><%# this.ddlClique.SelectedItem.Text %></td>
                                        <td style="text-align:center;"><%# Eval("Agency_name").ToString() %></td>
                                        <td style="text-align:center;"><%# getMajorRetrialNum(Eval("Agency_id").ToString()) %></td>
                                        <td><%# getMajorRetrial(Eval("Agency_id").ToString()) %></td>
                                        <td style="text-align:center;">
                                            <a href="RetrailMembers.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>&major_id=<%#DESEncrypt.Encrypt(Eval("Agency_id").ToString())%>">查看</a>
                                          <%--  <a href="#" onclick="">导出名单</a>--%>
                                        </td>
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

