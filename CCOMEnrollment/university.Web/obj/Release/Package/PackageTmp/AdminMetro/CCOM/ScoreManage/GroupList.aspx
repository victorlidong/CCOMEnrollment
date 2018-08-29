<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.GroupList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>答辩组列表
    </title>
    <!--#include file="/metro/include/header_common.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="hidUoid" runat="server" Value="-1" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid" id="print_div" runat="server">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">答辩组列表
                            </h3>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                            <tr>
                                                <th width="4%" >序号</th>
                                                <th width="7%" style="text-align: center;">答辩组名称</th>
                                                <th width="7%" style="text-align: center;">答辩类型</th>
                                                <th width="7%" style="text-align: center;">组长</th>
                                                <th width="9%" style="text-align: center;">时间</th>
                                                <th width="7%" style="text-align: center;">地点</th>
                                                <th width="7%" style="text-align: center;">学生人数</th>
                                                <th width="7%" style="text-align: center;">操作</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="chkNo" runat="server"><%#st_index++ %></asp:Label>
                                        </td>
                                        <td style="text-align: center;"><%#Eval("Group_name")%></td>
                                        <td style="text-align: center;"><%#GetGroupType(Eval("Group_type").ToString())%></td>
                                          <td style="text-align: center;"><%#GetTeacherName(long.Parse(Eval("User_id").ToString()))%></td>
                                        <td style="text-align: center;"><%#Eval("Reply_time")%></td>
                                        <td style="text-align: center;"><%#Eval("Reply_room")%></td>
                                        <td style="text-align: center;"><%#GetStudentNumber(long.Parse(Eval("Group_id").ToString()))%></td>
                                        <td style="text-align: center;">
                                            <a href="./GroupStudentList.aspx?groupid=<%#DESEncrypt.Encrypt( Eval("Group_id").ToString())%>">打分</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                    <div class="row-fluid" style="display:none" >
                        <div class="span6">
                            显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                        </div>
                        <div class="span6">
                            <div class="pull-right">
                                <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                            </div>
                        </div>
                    </div>
                    <div class="span12" style="display:none">
                        <div class="form-actions">
                            <div class="form-actions" style="text-align: center;">
                                    <asp:LinkButton ID="ExpertOralTable" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出答辩评分表"></asp:LinkButton>
                                      <asp:LinkButton ID="ExpertSoftTable" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出软件验收表"></asp:LinkButton>
                                             
                            </div>
                        </div>
                           <div class="row-fluid" id="contentTab" style="margin-left:100px">
                                <div style="margin-left:120px;">
                                       <asp:LinkButton ID="LinkButton1" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="评分表"></asp:LinkButton>
                                     
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
