﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherChoose.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.TopicManage.TeacherChoose" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>教师选题
    </title>
    <!--#include file="/metro/include/header_common.html"-->
       <script type="text/javascript">

           function AcceptCheck(id) {

               var value = "";
               $('input[type="checkbox"]:checked').each(function () {
                   var tmp = $(this).parent().next().val();
                   if (tmp != "") value += tmp + ",";
               });
               if (id == -1) {
                   if (value == "") {
                       topWin.jsprint("请选择需要审核的选题", "", "Warning");
                       return;
                   }
                   var url = 'AcceptStudent.aspx?id=' + value;
               } else {
                   var url = 'AcceptStudent.aspx?id=' + id;
               }

               $.layer({
                   type: 2,
                   title: ['接收学生'],
                   shadeClose: false,
                   closeBtn: [0, true],
                   shade: [0.3, '#000'],
                   border: [0],
                   area: ['600px', '250px'],
                   iframe: { src: url }
               });
           }

    </script>
</head>
<body class="mainbody">
      <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="hidUoid" runat="server" Value="-1" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">选题列表
                            </h3>
                        </div>
                    </div>
                    <div class="row-fluid _step1" style="display:none">
                        <div class="span8">
                            <a href="TopicBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量导入</a>
                        </div>
                        <div class="span4">
                            <div class="pull-right">
                                <asp:HiddenField ID="txtKeywords" runat="server" />
                                <input id="InputText" type="text" class="txtInput" placeholder="题目名称" />
                                <script type="text/javascript">
                                    document.getElementById("InputText").value = document.getElementById("txtKeywords").value;
                                </script>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn btn-success" OnClick="btnSearch_Click" OnClientClick="return SendText()" />
                            </div>
                        </div>

                    </div>
                    <div class="space10"></div>
                    <div class="space5"></div>
                    <div class="row-fluid"">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                            <tr>
                                                <th width="5%" >序号</th>
                                                 <th style="width: 14%;">题目名称</th>
                                                 <th style="width: 8%;">指导教师</th>
                                                 <th style="width: 8%;">职称</th>
                                                 <th style="width: 8%;">单位</th>
                                                 <th style="width: 8%;">题目性质</th>
                                                 <th style="width: 8%;">题目来源</th>
                                                 <th style="width: 5%;">可选人数</th>
                                                 <th style="width: 5%;">已选人数</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="chkNo" runat="server"><%#st_index++ %></asp:Label>
                                            <asp:HiddenField ID="hidId" Value='<%#Eval("Topic_id")%>' runat="server" />
                                        </td>

                                       <td style="text-align: center;"><a href="TopicPage.aspx?topicid=<%#DESEncrypt.Encrypt(Eval("Topic_id").ToString())%>"><%#Eval("Topic_name")%></a></td>
                                         <td style="text-align: center;"><a href="TeacherPage.aspx?teacherid=<%#DESEncrypt.Encrypt(Eval("Teacher_id").ToString())%>"><%#GetTeacherName(Eval("Teacher_id").ToString())%></td>
                                        <td style="text-align: center;"><%#GetTitle(Eval("Teacher_id").ToString())%></td>
                                        <td style="text-align: center;"><%#Eval("Company")%></td>
                                        <td style="text-align: center;"><%#Eval("Topic_nature")%></td>
                                        <td style="text-align: center;"><%#Eval("Topic_source")%></td>
                                        <td style="text-align: center;">1</td>
                                        <td style="text-align: center;"><%#(Boolean)Eval("Selected_state")==true?1:0%></td>
                                      
                                      
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
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
                    <div class="row-fluid">
                        <div class="span12">
                            <h6 class="page-title">我的选题
                            </h6>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList2" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                            <tr>
                                                 <th style="width: 14%;">题目名称</th>
                                                 <th style="width: 8%;">选题学生</th>
                                                 <th style="width: 8%;">学号</th>
                                                 <th style="width: 8%;">题目性质</th>
                                                 <th style="width: 8%;">题目来源</th>
                                                 <th style="width: 5%;">选题时间</th>
                                                 <th style="width: 5%;">教师确认</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;"><%#Eval("Topic_name")%></td>
                                        <td style="text-align: center;"><a href="StudentPage.aspx?studentid=<%#DESEncrypt.Encrypt(Eval("Student_id").ToString())%>"><%#Eval("Student_name")%></a></td>
                                        <td style="text-align: center;"><%#Eval("User_number")%></td>
                                        <td style="text-align: center;"><%#Eval("Topic_nature")%></td>
                                        <td style="text-align: center;"><%#Eval("Topic_source")%></td>
                                        <td style="text-align: center;"><%#((DateTime)Eval("Apply_time")).ToString("yyyy年MM月dd日")%></td>
                                        <td style="text-align: center;"><%#GetAcceptState(Eval("Accept_state").ToString(),Eval("Topic_relation_id").ToString())%>
                                   <%--        &nbsp;<a href="javascript:void(0);" onclick='AcceptCheck(<%#Eval("Topic_relation_id")%>)'>
                                                  <i class="icon-pencil"></i>修改--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList2.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                      <div class="row-fluid">
                        <div class="span12">
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
