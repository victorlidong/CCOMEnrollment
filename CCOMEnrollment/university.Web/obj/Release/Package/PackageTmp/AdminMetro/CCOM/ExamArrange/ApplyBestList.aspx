<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyBestList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.ApplyBestList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>评优列表
    </title>
    <!--#include file="/metro/include/header_common.html"-->
     
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
                            <h3 class="page-title">申优列表
                            </h3>
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
                                                <tr>
                                            <th style="text-align:center;">姓名</th>
                                             <th style="text-align:center;">学号</th>
                                             <th style="text-align:center;">形式审查一</th>
                                             <th style="text-align:center;">形式审查二</th>
                                             <th style="text-align:center;">达成度评价</th>
                                             <th style="text-align:center;">质量追踪</th>
                                             <th style="text-align:center;">答辩评语表</th>
                                             <th style="text-align:center;">软件验收表</th>
                                        </tr>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                         <td style="text-align:center;"><%#Eval("Student_name")%> </td>
                                         <td style="text-align:center;"><%#Eval("User_number")%></td>
                                         <td style="text-align:center;">
                                             <%#GetFormReview1(long.Parse(Eval("Student_id").ToString()))%>
                                         </td>
                                         <td style="text-align:center;">
                                             <%#GetFormReview2(long.Parse(Eval("Student_id").ToString()))%>
                                         </td>
                                         <td style="text-align:center;">
                                            <a href="./Achievement_degree.aspx?studentID=<%#DESEncrypt.Encrypt( Eval("Student_id").ToString())%>">查看</a>
                                         </td>
                                         <td style="text-align:center;">
                                            <a href="./Tracking_evaluation.aspx?studentID=<%#DESEncrypt.Encrypt( Eval("Student_id").ToString())%>">查看</a>
                                         </td>
                                        <td style="text-align:center;">
                                            <a href="../ScoreManage/CommentPage.aspx?userid=<%#DESEncrypt.Encrypt( Eval("Student_id").ToString())%>">查看</a>
                                         </td>
                                        <td style="text-align:center;">
                                            <a href="../ScoreManage/SoftwarePage.aspx?userid=<%#DESEncrypt.Encrypt( Eval("Student_id").ToString())%>">查看</a>
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

