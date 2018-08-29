<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage_SMS_apply.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.Manage_SMS_apply" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>通知推送系统-短信申请记录管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
        
        function agree(obj)
        {
            $("#hidId").val(obj);
            //alert(obj);
            var d = dialog({
                title: '短信申请审批',
                width: 400,
                content: '<span>批准条数：</span>&nbsp;<input id="check_number" style="width:15em; padding:4px" /><br/><br/><span>审批说明（可不填）：</span><br/><textarea rows="4" cols="50" id=\"agree_reason\" style=\"font-size:13px;width:370px;height:150px;margin-top:15px;\"/>&nbsp;<span style="color:red;" id="spResult"></span>',
                okValue: '确定',
                ok: function () {
                    var number = $("#check_number").val();
                    if (isNaN(number))
                    {
                        $("#spResult").val("批准条数必须为数字");
                        return;
                    }
                    else
                    {
                        $("#spResult").val("");
                    }
                    $.ajax({
                        type: "POST",
                        url: "NoticeHandler.ashx",
                        data: { "action": "checkSmsApply", "SMS_apply_id": obj, "reason": $("#agree_reason").val(), "agree_number": $("#check_number").val() },
                        success: function (data) {
                            if (data == "True") {
                                alert("审批成功!")
                            }
                        },
                        error: function (data) {
                            alert("请求出错");
                        },
                        cache: false
                    });
                    this.close();
                },
                cancelValue: '取消',
                cancel: function () { }
            });
            d.show();
        }
        function deny(obj)
        {
            $("#hidId").val(obj);
            //alert(obj);
            var d = dialog({
                title: '短信申请审批',
                width: 400,
                content: '<span> 审批说明（可不填）:</span><br/><br/>&nbsp;<textarea rows="4" cols="50" id=\"deny_reason\" style=\"font-size:13px;width:370px;height:150px;\">',
                okValue: '确定',
                ok: function () {
                    $.ajax({
                        type: "POST",
                        url: "NoticeHandler.ashx",
                        data: { "action": "denySmsApply", "SMS_apply_id": obj, "reason": $("#deny_reason").val() },
                        success: function (data) {
                            if(data=="True")
                            {
                                alert("审批成功!")
                            }
                        },
                        error: function (data) {
                            alert("请求出错");
                        },
                        cache: false
                    });
                    this.close();
                },
                cancelValue: '取消',
                cancel: function () { }
            });
            d.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:HiddenField ID="hidId" Value="0" runat="server" />
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

                     <div class="row-fluid" style="margin-top:15px;">
                         <div style="float:left;width:200px;margin-left:50px;" id="CheckType" runat="server">
                             <%--<div class="span6" style="width:90px;">
                                <a href="/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=<%#DESEncrypt.Encrypt("0")%>&fun_id=<%#this.fun_id %>" id="noChecked" class="btn btn-success" runat="server">未审批</a>
                            </div>
                            <div class="span6"  style="width:90px;">
                                <a href="/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=<%#DESEncrypt.Encrypt("1")%>&fun_id=<%#this.fun_id %>" id="checked" class="btn"  runat="server">已审批</a>
                            </div>--%>
                         </div>
                        <div class="span6" style="float:right;margin-right:50px;">
                            <div class="pull-right">
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput" Visible="true"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" onclick="btnSearch_Click" Visible="true" style="margin-top:-10px;"/>
                            </div>
                        </div>
                    </div>

                     <div class="row-fluid">
                        <div class="span12">
                           
                        </div>
                    </div>

                     <div class="row-fluid" id="none_check" style="display:block;"  runat="server">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <tr>
                                            <th style="text-align: center;width:12%;">申请人</th>
                                            <th style="text-align: center;width:12%;">申请类型</th>
                                            <th style="text-align: center;width:12%;">申请条数</th>
                                            <th style="text-align: center;width:40%;">申请理由</th>
                                            <th style="text-align: center;width:12%;">申请时间</th>
                                            <th style="text-align: center;width:12%;">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;"><%#GetRealname(Eval("User_id").ToString())%></td>
                                       <td  style="text-align: center;"><%#university.Web.AdminMetro.CCOM.notice.SmsConfig.GetApplyTypeStr(int.Parse(Eval("SMS_apply_type").ToString()))%></td>
                                        <td style="text-align: center;"><%#Eval("SMS_apply_number")%></td>
                                        <td style="text-align: center;"><%#GetWrapReason(int.Parse(Eval("SMS_apply_type").ToString()),Eval("SMS_apply_reason").ToString())%></td>
                                        <td style="text-align: center;"><%#Eval("SMS_apply_time")%></td>
                                        <td style="text-align: center;">
                                            <a href="javascript:void(0);" onclick="agree(<%#Eval("SMS_apply_id")%>)">同意申请</a>
                                            <a href="javascript:void(0);" onclick="deny(<%#Eval("SMS_apply_id")%>)">拒绝申请</a>
                                           
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td style=\"text-align: center;\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="row-fluid" id="had_check" style="display:none;" runat="server">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <tr>
                                            <th style="text-align: center;width:12%;">申请人</th>
                                            <th style="text-align: center;width:5%;">申请类型</th>
                                            <th style="text-align: center;width:5%;">申请条数</th>
                                            <th style="text-align: center;width:25%;">申请理由</th>
                                            <th style="text-align: center;width:10%;">申请时间</th>
                                            <th style="text-align: center;width:5%;">审批状态</th>
                                            <th style="text-align: center;width:25%;">审批说明</th>
                                            <th style="text-align: center;width:5%;">批准条数</th>
                                            <th style="text-align: center;width:8%;">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;"><%#GetRealname(Eval("User_id").ToString())%></td>
                                       <td style="text-align: center;"><%#university.Web.AdminMetro.CCOM.notice.SmsConfig.GetApplyTypeStr(int.Parse(Eval("SMS_apply_type").ToString()))%></td>
                                        <td style="text-align: center;"><%#Eval("SMS_apply_number")%></td>
                                        <td style="text-align: center;"><%#GetWrapReason(int.Parse(Eval("SMS_apply_type").ToString()),Eval("SMS_apply_reason").ToString())%></td>
                                        <td style="text-align: center;"><%#Eval("SMS_apply_time")%></td>
                                        <td style="text-align: center;"><%#university.Web.AdminMetro.CCOM.notice.SmsConfig.GetApplyStatusStr(int.Parse(Eval("SMS_apply_status").ToString()))%></td>
                                        <td style="text-align: center;"><%#Eval("SMS_check_reason").ToString()==""?"--":Eval("SMS_check_reason").ToString()%></td>
                                        <td style="text-align: center;"><%#GetGiveNumber(int.Parse(Eval("SMS_apply_status").ToString()),Eval("SMS_give_number").ToString())%></td>
                                        <td style="text-align: center;">
                                            <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该通知吗?');void(0);" OnClick="lbtSingleDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("SMS_apply_id").ToString())%>'>
                                                <i class="icon-remove"></i>删除记录
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#Repeater1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
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
