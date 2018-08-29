<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyRecord.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.ApplyRecord" %>
<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>通知推送系统-短信申请记录</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">

        function applySms() {
            var url = 'ApplySms.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>';
            $.layer({
                type: 2,
                title: ['申请短信发送条数'],
                shadeClose: true,
                closeBtn: [0, true],
                shade: [0.3, '#000'],
                border: [0],
                area: ['450px', '280px'],
                iframe: { src: url }
            });
        }

        //验证回调函数
        function applyCallBack(msg, isFirst, number) {
            //art.dialog.tips(msg, 2);
            var d = dialog({
                content: msg
            });
            d.show();
            setTimeout(function () {
                d.close().remove();
            }, 2000);
            if (isFirst == 1) {
                $("#smsCnt").html(number);
            }
            location.replace(window.location.href);
        }

        function showApplyRecord(url) {
            location.replace(url);
        }
        </script>
</head>
<body class="mainbody">
<form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
    <input id="hiduo_id" type="hidden" runat="server" value="-1" />
     <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                         <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">短信申请记录
                            </h3>
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                               
                                <li>
                                       <a href="javascript:void(0);">推送通知系统</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">短信申请记录
                                </li>
                            </ul>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                        </div>

                     <div class="row-fluid">
                        <div class="span6">
                            <a href="javascript:void(0);" onclick="applySms()" class="btn btn-warning"><i class="icon-plus icon-white"></i>申请短信</a>
                            <p><br /><asp:Label ID="lblSms" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="span6">
                            <div class="pull-right">
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput" Visible="true"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" onclick="btnSearch_Click" Visible="true" />
                            </div>
                        </div>
                    </div>

                     <div class="row-fluid">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <tr>
                                            <th align="left">申请类型</th>
                                            <th align="left">申请条数</th>
                                            <th align="left">申请理由</th>
                                            <th align="left">申请时间</th>
                                            <th align="left">审批状态</th>
                                            <th align="left">审批说明</th>
                                            <th align="left">批准条数</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="left"><%#university.Web.AdminMetro.CCOM.notice.SmsConfig.GetApplyTypeStr(int.Parse(Eval("SMS_apply_type").ToString()))%></td>
                                        <td align="left"><%#Eval("SMS_apply_number")%></td>
                                        <td align="left"><%#GetWrapReason(int.Parse(Eval("SMS_apply_type").ToString()),Eval("SMS_apply_reason").ToString())%></td>
                                        <td align="left"><%#Eval("SMS_apply_time")%></td>
                                        <td align="left"><%#university.Web.AdminMetro.CCOM.notice.SmsConfig.GetApplyStatusStr(int.Parse(Eval("SMS_apply_status").ToString()))%></td>
                                        <td align="left"><%#Eval("SMS_check_reason").ToString()==""?"--":Eval("SMS_check_reason").ToString()%></td>
                                        <td align="left"><%#GetGiveNumber(int.Parse(Eval("SMS_apply_status").ToString()),Eval("SMS_give_number").ToString())%></td>
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
    
</form>
     <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>
