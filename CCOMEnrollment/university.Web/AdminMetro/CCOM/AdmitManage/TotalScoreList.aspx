﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalScoreList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AdmitManage.TotalScoreList" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考生总成绩</title>
    <!--#include file="/metro/include/header_common.html"-->
        <script type="text/javascript" src="/metro/js/objURL.js"></script>
    <script type="text/javascript" src="/metro/js/json2.js"></script>

           <script type="text/javascript">
               var title = '<%= this.ddlMajor.SelectedItem.Text +"考生最终成绩汇总" %>';
               function myPrint() {
                   var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
                   var str = document.getElementById("div1").innerHTML;
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
    <link rel="stylesheet" href="../AEEManage/DT_bootstrap.css" />
    <style type="text/css">
        #listTable_length{
            display:none;
        }
        #listTable_info{
            display:none;
        }
        #listTable_filter{
            display:none;
        }
    </style>
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
                            <h3 class="page-title">考生总成绩
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">录取名单管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">考生总成绩
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span6">
                            
                         <asp:LinkButton ID="btnCalculation" runat="server" CssClass="btn btn-warning" OnClick="btnGetCEE_Click"><i class="icon-upload">获取高考成绩及计算</i></asp:LinkButton>
                           <a href="#" onclick="myPrint()" class="btn btn-success"><i class="icon-download">打印表格</i></a>
                            <asp:LinkButton ID="ExportExcel" runat="server" CssClass="btn btn-success" OnClick="exportexcel_ServerClick"><i class="icon-external-link icon-white">&nbsp;</i>导出最终分数</asp:LinkButton>
                            <label style="margin-left: 20px;">专业方向：</label>
                                <asp:DropDownList ID="ddlMajor" CssClass="select2" Style="width: 150px;" runat="server" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="span6">
                            <%-- 
                            <label>专业方向：</label>
                            <asp:DropDownList ID="ddlOrgan" CssClass="select2" Style="width: 200px;" runat="server" OnSelectedIndexChanged="ddlOrgan_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <a class="btn" onclick="AlertForm('ddlOrgan');" style="padding: 6px 12px;">快速选择</a>
                            --%>
                            <div class="pull-right input-append">
                                <asp:TextBox ID="txtKeywords" placeholder="姓名/考生号" runat="server"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                                <br />
                                <asp:Label ID="txtSearchResult" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="space5"></div>

                      <div class="row-fluid" id="div1">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                        <tr>
                                             <th align="center" style="width: 8%">
                                                    序号</th>
                                            <th align="center">考生号</th>
                                          <%--   <th align="center">年份</th>--%>
                                           <th align="center">考生姓名</th>
                                        <%--  <th align="center">考生性别</th>--%>
                                            <th align="center">专业成绩</th>
                                            <th align="center">专业平均序</th>
                                            <th align="center">专业排名</th>  
                                            <th align="center">文考结果</th>
                                            <th align="center">高考总分</th>
                                            <th align="center">高考过线</th> 
                                            <th align="center">高考折合分</th>  
                                            <th align="center">最终成绩</th>
                                         <%--   <th align="center">毕业院校</th> --%> 
                                        </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>">
                                        <td style="text-align:center;">
                                            <%#this.rptList.Items.Count + 1 %>
                                        </td>
                                       <%-- <td align="center"><%# GetProvinceName(int.Parse(Eval("Fl_Province").ToString()))%></td>
                                        <td align="center"><%# Eval("NianFen").ToString() %></td>--%>
                                      <%--  <td align="center"><%# Eval("UP_CCOM_number").ToString() %></td>
                                        <td align="center"><%# Eval("User_realname").ToString() %></td>
                                        <td align="center"><%# GetWenOrLi(Eval("CEE_type").ToString()) %></td>
                                        <td align="center"><%# Eval("CEE_Chinese_score", "{0:#.##}").ToString() %></td>--%>
                                        <td align="center"><%# Eval("UP_CCOM_number").ToString() %></td>
                                        <td align="center"><%# Eval("User_realname").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_AEE_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_AEE_sequence", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_AEE_ranking", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_type").ToString() == "1" ? "备取" : (Eval("Transcript_type").ToString() == "2" ? "合格" : "正取") %></td>
                                        <td align="center"><%# Eval("Transcript_CEE_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_passline").ToString() == "False" ? "否":(Eval("Transcript_passline").ToString() == "True" ? "是" : "") %></td>
                                        <td align="center"><%# Eval("Transcript_CEE_convert_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_score", "{0:#.##}").ToString() %></td>
                                     <%--   <td align="center"><%# Eval("Transcript_score", "{0:#.##}").ToString() %></td>--%> 
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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

    </form>
       <!-- BEGIN JAVASCRIPTS -->

   <script type="text/javascript" src="../AEEManage/jquery.dataTables.js"></script>
   <script type="text/javascript" src="../AEEManage/DT_bootstrap.js"></script>

   <!--script for this page only-->
   <script src="../AEEManage/editable-table.js"></script>

   <!-- END JAVASCRIPTS -->
   <script>
       jQuery(document).ready(function () {
           EditableTable.init();
       });
   </script>
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>

