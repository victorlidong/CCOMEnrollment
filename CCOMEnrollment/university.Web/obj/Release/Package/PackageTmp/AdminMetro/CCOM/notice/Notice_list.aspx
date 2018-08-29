<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice_list.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.Notice_list" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>通知列表</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="Mosaddek" name="author" />
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
        function search() {
            var url;
            if ($.getUrlParam("keywords") == null) {
                url = $.urlAddParams(window.location.href, "keywords", encodeURIComponent($("#txtKeywords").val()));
            } else {
                url = $.changeURLArg(window.location.href, "keywords", encodeURIComponent($("#txtKeywords").val()));
            }
            location.replace(url);
        }
        function keyLogin() {
            if (event.keyCode == 13) {
                event.returnValue = false;
                search();
                return false;
            }
        }
        function status_change(obj)
        {
            $("#" + obj.id).parent().children(".btn-success").removeClass("btn-success");
            $("#" + obj.id).addClass("btn-success");
           
            $.ajax({
                type: "POST",
                url: "/AdminMetro/CCOM/notice/NoticeHandler.ashx",
                data: { "action": "getUserNotice", "notice_type": obj.id ,"page":1},
                success: function(data)
                {
                    
                    if(data!=null)
                    {
                        //alert(data);
                        $("#noticeList").empty();
                        $("#noticeList").append(data);
                    }
                },
                error: function(data)
                {
                    alert("请求数据出错");
                }
            });
        }
    </script>
    <style type="text/css">
        #noticeList li .label
        {
            padding: 12px !important;
        }
    </style>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="fixed-top" onkeydown="keyLogin();">
    <form id="form1" runat="server" style="margin: 0px;">
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
                            <h3 class="page-title">我的通知列表
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">我的通知
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN CHAT PORTLET-->
                           <%-- <div class="pull-right input-append" style="padding: 2px 25px;">
                                        <input type="text" id="txtKeywords" class="input-medium" runat="server" />
                                        <input type="button" id="btnSearch" value="搜索" class="btn " onclick="search()" />
                                    </div>--%>
                            <div class="input-append search-input-area" style="float:right;margin-right:25px;"> 
                                <input class="" id="txtKeywords" type="text"  runat="server"/>
                                <button class="btn" type="button" onclick="search()"><i class="icon-search"></i></button>
                                <%--<asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />--%>
                             </div>
                            
                                <%--<div class="widget-title">
                                    <h4><i class="icon-comments-alt"></i>我的通知</h4>
                                     <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                        <a href="javascript:;" class="icon-remove"></a>
                                    </span>
                                    
                                    
                                </div>--%>
                                <div style="width:280px;float:left;display:inline-block;margin-left:15px;margin-top:15px;">
                                    <div id="no_read" class="btn btn-success" style="width:100px;height:20px;"  runat="server">
                                        <a href="/AdminMetro/CCOM/notice/Notice_list.aspx?type=<%=DESEncrypt.Encrypt("0") %>&fun_id=<%=get_fun_id("CCOM/notice/Notice_list.aspx") %>" style="text-decoration:none;color:white;">未 读</a>
                                    </div>
                                    <div id="read" class="btn" style="width:100px;margin-left:10px;height:20px;"  runat="server">
                                        <a href="/AdminMetro/CCOM/notice/Notice_list.aspx?type=<%=DESEncrypt.Encrypt("1") %>&fun_id=<%=get_fun_id("CCOM/notice/Notice_list.aspx") %>" style="text-decoration:none;color:white;">已 读</a>
                                    </div>
                                </div>
                                <div class="widget-body" style="margin-top:45px;">
                                    <ul id="noticeList" runat="server" class="item-list scroller padding" style="min-height:400px; width: auto;" data-always-visible="1">
                                        <li>
                                            <div class="media">
                                                <span class="label pull-left label-success"><i class="icon-bell"></i></span>
                                                <div class="media-body">
                                                    <div class="notice-collapse" style="display: block; padding: 5px;">
                                                        <div class="text" style="padding: 2px 4px; text-decoration: none;">
                                                            <p>温馨提示：明天气温下降，注意穿衣保暖</p>
                                                            <p class="attribution"><a href="#">系统管理员：</a> at 1:55pm, 13th April 2013</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row-fluid" id="page_size" runat="server">
                                    <div class="span6"> 
                                    </div>
                                    <div class="span6" style="padding-right: 25px;">
                                        <div class="pull-right">
                                            <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                                        </div>
                                    </div>
                                </div>
                           
                            <!-- END CHAT PORTLET-->
                        </div>

                    </div>
                    <!-- END PAGE CONTENT-->
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
            <!-- END PAGE -->
        </div>
        <!-- END CONTAINER -->

        <!--common script for all pages-->
        <!--#include file="/metro/include/footer_common.html"-->
        <script src="/metro/js/data-js/data-horse.js"></script>
        <!--script for this page only-->
        <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
        <script type="text/javascript">
            $(function () {
                //通知
                //noticeSetting();
            });
        </script>
    </form>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
