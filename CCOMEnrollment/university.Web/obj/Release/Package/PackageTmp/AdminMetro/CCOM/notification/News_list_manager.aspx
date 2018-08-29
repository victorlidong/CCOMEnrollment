<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News_list_manager.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notification.News_list_manager" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>资讯发布管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <script type="text/javascript"></script>
    <style type="text/css">
        #NewsTypeDiv a
        {
            margin-bottom:10px;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />
        <asp:HiddenField ID="hidNewsType" runat="server" />
        <asp:HiddenField ID="tabIndex" runat="server" />
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">管理已发布资讯
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>

                                <li>
                                    <a href="/AdminMetro/CCOM/notification/News.aspx">资讯</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">管理已发布资讯
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>


                    <div class="row-fluid">
                        <div class="span12">
                            <!--BEGIN TABS-->
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs" id="pageTab1">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">已发资讯管理</a></li>
                                    <%--<li><a href="#tab_1_2" data-toggle="tab">已置顶资讯 </a></li>--%>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="row-fluid" style="margin-bottom:15px;">
                                            <span style="float:left;">
                                                <a class="btn btn-success" href="ReleaseOrEditNews.aspx?fun_id=<%=get_fun_id("CCOM/notification/ReleaseOrEditNews.aspx") %>"><i class="icon-plus icon-white"></i>发布资讯</a>
                                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger"
                                                OnClientClick="return confirm('确认删除所选资讯吗？');" OnClick="btnDelete_Click"><i class="icon-remove icon-white"></i>批量删除</asp:LinkButton>
                                            
                                            </span>
                                            
                                            <div class="pull-right" >
                                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                            </div>
                                            
                                        </div>
                                        
                                        <div class="row-fluid">
                                            <div id="NewsTypeDiv" runat="server">
                                            </div>
                                            
                                        </div>
                                        <div class="space5"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="rptList" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered  table-hover" id="listTable">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 7%;">
                                                                        <input type="checkbox" onclick='checkAllForEnable(this, "#listTable")' id="checkAll" /><label for="checkAll">全选</label></th>
                                                                    <th>资讯标题</th>
                                                                    <th style="width: 9%;">类别</th>
                                                                    <th style="width: 8%;">发布者</th>
                                                                    <th style="width: 14%;">发布时间</th>
                                                                    <th style="width: 8%;">最终修改者</th>
                                                                    <th style="width: 7%;">阅读量</th>
                                                                    <th style="width: 7%;">附件数</th>
                                                                    <th style="width: 20%;">操作</th>
                                                                </tr>
                                                            </thead>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkId" runat="server"
                                                                        Enabled='<%#IsSelfNews(Eval("News_creator_id").ToString())%>' OnClientClick="checkChanged(this)" />
                                                                    <asp:HiddenField ID="hidId"
                                                                        Value='<%#Eval("News_id")%>' runat="server" />
                                                                    <asp:HiddenField ID="hideCreatorId"
                                                                        Value='<%#Eval("News_creator_id")%>' runat="server" />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <a href="ViewNews.aspx?id=<%#DESEncrypt.Encrypt(Eval("News_id").ToString())%>" target="_blank"><%#Eval("News_title")%>
                                                                    </a>
                                                                </td>
                                                                <td><%#GetNewsType(Eval("News_type_id").ToString())%></td>
                                                                <td><%#GetRealName(Eval("News_creator_id").ToString())%></td>
                                                                <td><%#Eval("News_date")%></td>
                                                                <td><%#GetLastEditor(Eval("News_last_editor").ToString())%></td>
                                                                <td><%#Eval("News_readnumber")%></td>
                                                                <td><%#GetNewsAttachNum(Eval("News_id").ToString())%></td>
                                                                <td>
                                                                    <a href="ReleaseOrEditNews.aspx?id=<%#DESEncrypt.Encrypt(Eval("News_id").ToString())%>&action=<%=MyEnums.ActionEnum.Edit.ToString() %>&fun_id=<%= get_fun_id("CCOM/notification/ReleaseOrEditNews.aspx") %>">
                                                                        <i class="icon-pencil">编辑</i>
                                                                    </a>
                                                                    &nbsp;
                                                                   <%--Visible='<%#IsSelfNews(Eval("News_creator_id").ToString())%>'--%>
                                                                   <%-- <%#GetDeleteInfo(Eval("News_creator_id").ToString())%>--%>
                                                                    <asp:LinkButton ID="lbtDelete"
                                                                        OnClientClick='<%#GetMyScript(Eval("News_creator_id").ToString()) %>' OnClick="lbtSingleDelete_Click" runat="server"
                                                                        Enabled='<%#IsSelfNews(Eval("News_creator_id").ToString())%>'
                                                                         ToolTip='<%# DESEncrypt.Encrypt(Eval("News_id").ToString())%>'>
                                                                        <i class="icon-remove"><%#GetDeleteText(Eval("News_creator_id").ToString()) %></i></asp:LinkButton>
                                                                    &nbsp;
                                                                    <asp:LinkButton ID="lbtTop" OnClientClick="return confirm('确定要执行该操作吗?');void(0);" OnClick="lbtTop_Click" runat="server" ToolTip='<%#DESEncrypt.Encrypt(Eval("News_id").ToString())%>'><%#GetTopText(Eval("News_top").ToString())%></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                                                       </table>
                                                    </FooterTemplate>

                                                </asp:Repeater>
                                                <!--列表展示.结束-->
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
                            <!--END TABS-->
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>

    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
    <!--end common script for all pages-->
    <!--script for this page-->
    <%--<script type="text/javascript" src="/metro/js/form-component.js"></script>--%>
    <!--end script for this page-->
    <script type="text/javascript">
        $(function () {
            var tabIndex = $("#tabIndex").val();
            if (tabIndex != "") {
                showTab("#pageTab1", parseInt(tabIndex));
            }
        });
        function showTab(tabId, tabIndex) {
            $(tabId + " li:eq(" + (tabIndex - 1) + ") a").tab('show');
        }
        function checkAllForEnable(chkobj, nodeId) {
            if ($(chkobj).attr("checked") == "checked") {
                $(nodeId + " input[type=checkbox][disabled!='disabled']").attr("checked", true);
            } else {
                $(nodeId + " input[type=checkbox][disabled!='disabled']").attr("checked", false);
            }
        }
        function checkChanged(obj) {

            if (obj.checked) {
                obj.attr("checked", false);
            }
            else {
                obj.attr("checked", true);
            }
        }
    </script>
</body>
</html>
