<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FractionallineList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.CEEManege.FractionallineList" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考分数线</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript" src="../../metro/js/data-js/data-horse.js"></script>
           <script type="text/javascript">
               var title = "高考分数线";
               function myPrint() {
                   var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
                   var str = document.getElementById("div1").innerHTML;
                   var docStr = "<div class='row-fluid' style='text-align:center'><b>" + title + "</b></div><br/><style type='text/css'>#listTable_length{display:none;} #listTable_info{display:none;} #listTable_filter{display:none;}</style>" + str;
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
                            <h3 class="page-title">高考分数线
                            </h3>
                            <br />
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">高考成绩管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">高考分数线
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <a href="AddFractionalline.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>&action=<%=MyEnums.ActionEnum.Add%>" class="btn btn-warning"><i class="icon-plus icon-white"></i>单个添加</a>
                            <a href="ImportFractionalline.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>" class="btn btn-warning"><i class="icon-download">批量导入</i></a>
                              <a href="#" onclick="myPrint()" class="btn btn-success"><i class="icon-download">打印表格</i></a>
                            <asp:LinkButton ID="ExportExcel" runat="server" CssClass="btn btn-success" OnClick="exportexcel_ServerClick"><i class="icon-external-link icon-white">&nbsp;</i>导出高考分数线</asp:LinkButton>
                        </div>
                    </div>
                    <div class="space10"></div>
                      <div class="row-fluid" id="div1">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered table-hover" id="listTable">
                                        <thead>
                                        <tr>
                                            <th style="text-align:center;">序号</th>
                                            <th align="center">省份</th>
                                           <th align="center">文科一本线</th>
                                            <th align="center">理科一本线</th>
                                            <th align="center">文科二本线</th>
                                            <th align="center">理科二本线</th>
                                            <th align="center">文科三本线</th>
                                            <th align="center">理科三本线</th>
                                            <th align="center">艺术类最低控制线（文科）</th>
                                            <th align="center">艺术类最低控制线（理科）</th>
                                            <th align="center">文科满分</th>
                                            <th align="center">理科满分</th>
                                            <th align="center">操作</th>
                                        </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align:center;">
                                            <%#this.rptList.Items.Count + 1 %>
                                        </td>
                                        <td align="center"><%# GetProvinceName(int.Parse(Eval("Fl_Province").ToString()))%></td>
                                        <%--<td align="center"><%# Eval("NianFen").ToString() %></td>--%>
                                        <td align="center"><%# Eval("WenKeYiBen",  "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("LiKeYiBen", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("WenKeErBen", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("LiKeErBen", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("WenKeSanBen", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("LiKeSanBen", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("WenKeYiShuXian", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("LiKeYiShuXian", "{0:#.##}").ToString() %></td>
                                        <td align="center"><%# Eval("WenKeZongFen").ToString() %></td>
                                        <td align="center"><%# Eval("LiKeZongFen").ToString() %></td>
                                        <td align="center"><a href="AddFractionalline.aspx?fun_id=<%= MyRequest.GetQueryString("fun_id") %>&action=<%=MyEnums.ActionEnum.Edit %>&id=<%#DESEncrypt.Encrypt(Eval("Fl_id").ToString())%>">修改</a>
                                            <asp:LinkButton ID="btnDeleteFenShuXian" runat="server" OnClick="btnDeleteFenShuXian" ToolTip='<%#DESEncrypt.Encrypt(Eval("Fl_id").ToString())%>'>删除</asp:LinkButton></td>
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
    <!--#include file="/metro/include/footer_common.html"-->
</body>
</html>
