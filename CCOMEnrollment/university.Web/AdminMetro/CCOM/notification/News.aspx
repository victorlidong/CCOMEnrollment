<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notification.News" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>资讯列表</title>
   <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#newsList").empty();
            //gotoNewsPage(1);
            //设定样式
            if ($("#hidNewsType").val() != "") {
                var tid = parseInt($("#hidNewsType").val());
                if (tid < 0 || tid > 2)
                    tid = 1;
                $("#divNewsType").children(".btn-success").removeClass("btn-success");
                $("#divNewsType").children().eq(tid).addClass("btn-success");
            }
        });
        function gotoNewsPage(page) {

            var listId = "#newsList";
            GetNewsForList(listId, 0, page, $("#txtKeywords").val());//0表示所有资讯
        }
        function search() {
            var subTypeId = $("#divNewsType a.btn-success").prev().val();
            //alert(subTypeId);
            if (subTypeId != undefined) {

                GetNewsForList('#newsList', subTypeId, 1, $("#txtKeywords").val());
            }
        }
        function keyLogin() {
            if (event.keyCode == 13) {
                event.returnValue = false;
                search();
                return false;
            }
        }
        $(document).ready(function () {
            var listId = "#newsList";
            GetNewsForList(listId, 0, 1, $("#txtKeywords").val());
        });
    </script>
    <style type="text/css">
        #newsList li {
            line-height:15px;
        }
    </style>
</head>
<body class="mainbody" onkeydown="keyLogin();">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />
        <asp:HiddenField ID="hidNewsType" runat="server" />
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
                            <h3 class="page-title">资讯
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                              
                                <li class="active">资讯首页
                                </li>
                                <li class="pull-right search-wrap">

                                    

                                </li>
                            </ul>--%>
                            <div class="input-append search-input-area" style="float:right"> 
                                <input class="" id="txtKeywords" type="text" />
                                <button class="btn" type="button" onclick="search()"><i class="icon-search"></i></button>
                             </div>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                           
                            <div class="well" runat="server" id="divNewsType" style="margin-top: 10px; line-height: 35px; padding: 10px;">
                            </div>
                        </div>

                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN FORM-->
                            <div class="load_layer pull-left">
                                <img src='/scripts/artDialog4.1.7/skins/icons/wait.gif' alt='Loading' />正在加载...</div>
                            <ul id="newsList" class="item-list  padding" style="overflow: hidden; width: auto;" data-always-visible="1">
                                <%--<li>
                                    <div class="media">
                                        <span class="label pull-left news-bg">
                                            <img class="img-circle" src="/admin/images/water.jpg" alt="资讯" style="width:40px; height:40px;" />
                                        </span>
                                        <div class="media-body">
                                            <p class="text news-title">
                                                <a href="#">资讯标题</a>
                                            </p>
                                            <span>日常事务 2014年7月</span>
                                        </div>
                                    </div>
                                </li>--%>
                            </ul>
                            <div class="space10">
                               
                            </div>

                        </div>
                    </div>
                    <div class="row-fluid" id="divNewsPage">
                        <div class="span6">
                        </div>
                        <div class="span6">
                            <div class="pull-right">
                                <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>

    </form>
    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="NewsListAjax.js"></script>
    <%--<script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>--%>
    <!--end common script for all pages-->
    <!--script for this page-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <!--end metro  script-->
</body>
</html>
