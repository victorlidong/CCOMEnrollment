<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmissionProvinceMembers.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AdmitManage.AdmissionProvinceMembers" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=GetProvinceName(this.pro_id.ToString())%>录取名单</title>
    <!--#include file="/metro/include/header_common.html"-->
               <script type="text/javascript">
                   var title = '<%= GetProvinceName(this.pro_id.ToString()) +"录取名单" %>';
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
                            <h3 class="page-title"><%=GetProvinceName(this.pro_id.ToString())%>录取名单
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
                                <li class="active">勾选进入复试名单
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span10">
                            <a href="#" onclick="myPrint()" class="btn btn-success"><i class="icon-download">打印表格</i></a>
                            <asp:LinkButton ID="ExportExcel" runat="server" CssClass="btn btn-success" OnClick="exportexcel_ServerClick"><i class="icon-external-link icon-white">&nbsp;</i>导出录取名单</asp:LinkButton>
                        </div>
                        <div class="span2">
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
                                            <th style="text-align:center;">序号</th>
                                            <th align="center">考生号</th>
                                            <th align="center">考生姓名</th>
                                            <th align="center">高考报名号</th>
                                            <th align="center">专业方向</th>
                                            <th align="center">省份</th>
                                            <th align="center">毕业院校</th>
                                            <th align="center">专业成绩</th>
                                            <th align="center">专业排名</th>  
                                            <th align="center">高考总分</th>
                                            <th align="center">高考折合分</th>  
                                            <th align="center">最终成绩</th>
                                        </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>">
                                        <td align="center" id="check">
                                            <asp:Label ID="chkNo" runat="server"><%#++this.st_index %></asp:Label>
                                        </td>
                                        <td align="center"><%# Eval("UP_CCOM_number").ToString() %></td>
                                        <td align="center"><%# Eval("User_realname").ToString() %></td>

                                        <%# getUserDetail(Eval("User_id").ToString()) %>

                                        <td align="center"><%# Eval("Transcript_AEE_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_AEE_ranking", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_CEE_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_CEE_convert_score", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("Transcript_score", "{0:#.##}").ToString() %></td>
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
</body>
</html>


