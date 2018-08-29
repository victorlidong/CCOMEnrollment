<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News_type_manage.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notification.News_type_manage" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资讯类别管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField runat="server" ID="current_type_id" Value="" />
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
                            <h3 class="page-title">管理资讯类别
                            </h3>

                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid"  style="margin-bottom:4px;">

                        <div class="span6">
                            <a class="btn btn-success" onclick="addPushType()" href="javascript:void(0);"><i class="icon-plus icon-white"></i>添加类别</a>
                            &nbsp;
                            <a class="btn btn-warning" href="ReleaseOrEditNews.aspx?fun_id=<%=get_fun_id("CCOM/notification/ReleaseOrEditNews.aspx") %>"><i class="icon-plus icon-white"></i>发布资讯</a>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('确定要删除所选资讯类别吗?若删除该类别则该类别下的所有资讯也将被删除!!!？');" OnClick="btnDelete_Click"  style="margin-left:7px;"><i class="icon-remove icon-white"></i>批量删除</asp:LinkButton>
                        </div>
                        <div class="span6">
                            <div class="pull-right">
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <tr>
                                            <th style="width: 7%;text-align:center">
                                                <input type="checkbox" onclick='checkAllForEnable(this, "#listTable")' id="checkAll" />
                                                <label for="checkAll">全选</label>
                                            </th>
                                            <th  style="text-align:center;width:5%;">序号</th>
                                            <th  style="text-align:center;width:20%">资讯类别名称</th>

                                            <th  style="text-align:center;width:15%;">创建者</th>
                                            <th style="text-align:center;width:15%;">创建时间</th>
                                            <th width:15%; style="text-align:center;width:15%;">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align:center">
                                            <asp:CheckBox ID="chkId" runat="server"
                                                Enabled='<%#IsSelfNews(Eval("News_type_creator_id").ToString())%>' OnClientClick="checkChanged(this)" />
                                            <asp:HiddenField ID="hidId" Value='<%#Eval("News_type_id")%>' runat="server" />
                                            <asp:HiddenField ID="hideCreatorId"  Value='<%#Eval("News_type_creator_id")%>' runat="server" />
                                        </td>
                                        <td style="text-align: center;">
                                            <%#(this.rptList.Items.Count + 1).ToString()%>
                                        </td>
                                        <td  style="text-align:center">
                                            <%#Eval("News_type_name") %>
                                        </td>
                                        <td  style="text-align:center">
                                            <%#GetCreatorName(long.Parse(Eval("News_type_creator_id").ToString()))%>
                                        </td>
                                        <td  style="text-align:center">
                                            <%#Eval("News_type_date") %>
                                        </td>
                                        <td style="text-align:center">
                                            <a onclick="<%#GetEditOnclick(Eval("News_type_creator_id").ToString()) %>" href="javascript:void(0);" title='<%#DESEncrypt.Encrypt(Eval("News_type_id").ToString())%>'>
                                                <input type="hidden" value='<%#Eval("News_type_name") %>' id="hidName" runat="server"/>
                                                <i class="icon-pencil"><%#GetEditText(Eval("News_type_creator_id").ToString())%></i>
                                            </a>
                                            
                                             &nbsp;&nbsp;
                                                                   
                                            <asp:LinkButton ID="lbtDelete"
                                                OnClientClick='<%#GetMyScript(Eval("News_type_creator_id").ToString()) %>' OnClick="lbtSingleDelete_Click" runat="server"
                                                Enabled='<%#IsSelfNews(Eval("News_type_creator_id").ToString())%>'
                                                    ToolTip='<%# DESEncrypt.Encrypt(Eval("News_type_id").ToString())%>'>
                                                <i class="icon-remove"><%#GetDeleteText(Eval("News_type_creator_id").ToString()) %></i></asp:LinkButton>
                                        </td>
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
                    <div class="space20"></div>

                </div>
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
        //添加资讯类别
        function addPushType() {
            var d = dialog({
                title: '添加资讯类别',
                width: 400,
                content: '<span>请输入资讯类别名称：</span>&nbsp;<input id="property-returnValue-demo" style="width:15em; padding:4px" value="" /><span style="color:red;" id="spResult"></span>',
                okValue: '确定',
                ok: function () {
                    var value = $('#property-returnValue-demo').val();
                    if (value == "") {
                        parent.jsprint("类别名称不能为空", "", "Warning");
                        return;
                    }
                    $.ajax({
                        url: 'News_handler.ashx?action=addPushType&t=' + encodeURIComponent(value),
                        success: function (data) {
                            //alert(data);
                            var resultJson = eval("(" + data + ")");
                            if (resultJson.Result == 200) {
                                window.location.reload();
                                parent.jsprint("添加成功！", "", "Success");
                                
                            } else {
                                parent.jsprint(resultJson.Msg, "", "Error");
                            }
                        },
                        error: function () {
                            parent.jsprint("添加失败！", "", "Error");
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

        //编辑资讯类别
        function editNewsType(obj) {
            //var name = obj.title;
            var name = $(obj).children("input");
            
            var d = dialog({
                title: '编辑资讯类别',
                width: 400,
                content: '<span>资讯类别名称：</span>&nbsp;<input id="property-returnValue-demo" style="width:15em; padding:4px" value="' + name.val() + '" /><span style="color:red;" id="spResult"></span>',
                okValue: '确定',
                ok: function () {
                    var value = $('#property-returnValue-demo').val();
                    if (value == "") {
                        parent.jsprint("类别名称不能为空", "", "Warning");
                        return;
                    }
                    $.ajax({
                        url: 'News_handler.ashx?action=editNewsType&t=' + encodeURIComponent(value)+'&news_type_id='+encodeURIComponent(obj.title),
                        success: function (data) {
                            //alert(data);
                            var resultJson = eval("(" + data + ")");
                            if (resultJson.Result == 200) {
                                window.location.reload();
                                parent.jsprint("修改成功！", "", "Success");

                            } else {
                                parent.jsprint(resultJson.Msg, "", "Error");
                            }
                        },
                        error: function () {
                            parent.jsprint("修改失败！", "", "Error");
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

        function confer_delete()
        {
            var d = dialog({
                title: '确定要删除该资讯类别吗?若删除该类别则该类别下的所有资讯也将被删除!!!',
                width: 400,
                content: '<span>请输入资讯类别名称：</span>&nbsp;<input id="property-returnValue-demo" style="width:15em; padding:4px" value="" /><span style="color:red;" id="spResult"></span>',
                okValue: '确定',
                ok: function () {
                    this.close();
                },
                cancelValue: '取消',
                cancel: function () { }
            });
            d.show();
        }
    </script>
</body>
</html>
