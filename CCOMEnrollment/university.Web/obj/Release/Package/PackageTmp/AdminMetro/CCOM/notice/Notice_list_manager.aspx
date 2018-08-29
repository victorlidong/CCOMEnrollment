<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice_list_manager.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.Notice_list_manager" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>通知推送系统-推送通知管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript" src="../../metro/js/layer/layer.min.js"></script>

    <style type="text/css">
        .nowrap
        {
            width: 100%;
            display: inline-block;
            text-overflow: ellipsis;
            white-space: nowrap;
            overflow: hidden;
        }
    </style>

    <script type="text/javascript">
      

        function checkAllForEnable(chkobj, nodeId) {
            if ($(chkobj).attr("checked") == "checked") {
                $(nodeId + " input[type=checkbox][disabled!='disabled']").attr("checked", true);
            } else {
                $(nodeId + " input[type=checkbox][disabled!='disabled']").attr("checked", false);
            }
        }
        function type_change(obj)
        {
            //alert(obj.id);
            if(obj.id=="image_word_notice")
            {
                $("#notice_type").val(1);
            }
            else
            {
                $("#notice_type").val(0);
            }
            //alert($("#notice_type").val());
        }

        
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField runat="server" ID="notice_type" Value="0"/>
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
                            <h3 class="page-title">管理推送通知
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/Adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>

                                <li>
                                    <a href="javascript:void(0);">推送通知系统</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">管理推送通知
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <a class="btn btn-warning" href="ReleaseOrEditNotice.aspx?fun_id=<%=get_fun_id("ReleaseOrEditNotice.aspx") %>"><i class="icon-plus icon-white"> </i>发布通知</a>
                             <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger"
                                                OnClientClick="return confirm('确认删除所选通知吗？');" OnClick="btnDelete_Click"><i class="icon-remove icon-white"> </i>批量删除</asp:LinkButton>
                           <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="btn_type_change" OnClientClick="type_change(this)" ID="word_notice" style="width:75px;height:20px;">文字通知</asp:LinkButton>
                            <asp:LinkButton CssClass="btn" runat="server" OnClick="btn_type_change" ID="image_word_notice"  OnClientClick="type_change(this)" style="width:75px;height:20px;">图文通知</asp:LinkButton> 
                        </div>
                        <%--<div class="row-fluid" style="margin-bottom:10px;">
                            <div style="display:inline-block;float:left;">
                                
                            </div>
                        </div>--%>
                        <div class="span6" style="float:right;margin-top:-25px;">
                                <div class="pull-right">
                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        <div class="space5"></div>
                        
                        <%--<div class="row-fluid">
                            <div class="span6" id="NoticeTypeDiv" runat="server">
                            </div>
                        </div>--%>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="listTable" class="table table-striped table-bordered  table-hover" style="table-layout: fixed;">
                                        <tr>
                                            <th style="text-align: center;" width="5%"><input type="checkbox" onclick='checkAllForEnable(this, "#listTable")' /></th>
                                            <th style="text-align: center;" width="6%">序号</th>
                                            <th style="text-align: center;" width="35%">通知内容</th>
                                            
                                            <th style="text-align: center;" width="12%">时间</th>
                                            <th style="text-align: center;" width="12%">最后编辑人</th>
                                            <th style="text-align: center;" width="15%">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:CheckBox ID="chkId" runat="server" Enabled='<%#IsSelfPush(Eval("Notice_sender_id").ToString()) %>'  />
                                            <asp:HiddenField ID="hidId"  Value='<%#Eval("Notice_id")%>' runat="server" />
                                        </td>
                                        <td style="text-align: center;">
                                            <%#(this.rptList.Items.Count + 1).ToString()%>
                                        </td>
                                        <td>
                                            <span class="nowrap">
                                                <a href="ViewNotice.aspx?id=<%# DESEncrypt.Encrypt(Eval("Notice_id").ToString())%>" target="_blank">
                                                   <%# Eval("Notice_type").ToString() == "True" ? Eval("Notice_title").ToString() + "<br />" : WrapPushContent(Eval("Notice_id").ToString()) %>  
                                                </a>
                                            </span>
                                               
                                            <asp:HiddenField ID="hidContent" Value='<%#Eval("Notice_content")%>' runat="server" />
                                        </td>
                                        
                                        <td style="text-align: center;"><%#DateTime.Parse(Eval("Notice_date").ToString()).ToString("yyyy-MM-dd HH:mm")%></td>
                                       <td style="text-align: center;"><%#GetLastEditorName(Eval("Notice_last_editor").ToString())%></td>
                                        <td style="text-align: center;">
                                            <a href="ReleaseOrEditNotice.aspx?fun_id=<%= get_fun_id("CCOM/notice/ReleaseOrEditNotice.aspx") %>&action=<%= MyEnums.ActionEnum.Edit.ToString() %>&id=<%# DESEncrypt.Encrypt(Eval("Notice_id").ToString())%>"><i class="icon-pencil"></i>编辑</a>
                                            &nbsp;
                                            <asp:LinkButton ID="lbtDelete" OnClientClick='<%#GetMyScript(Eval("Notice_sender_id").ToString()) %>' OnClick="lbtSingleDelete_Click" runat="server" Enabled='<%#IsSelfPush(Eval("Notice_sender_id").ToString())%>' ToolTip='<%# DESEncrypt.Encrypt(Eval("Notice_id").ToString())%>'>
                                                <i class="icon-remove"><%#GetDeleteText(Eval("Notice_sender_id").ToString()) %></i>
                                            </asp:LinkButton>
                                            &nbsp;
                                            
                                            
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <!--列表展示.结束-->
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
        <!--#include file="/metro/include/footer_common.html"-->
    </form>
</body>
</html>
