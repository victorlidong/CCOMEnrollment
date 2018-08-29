<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentStatus.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentScore.StudentStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查询考生录取状态</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <style type="text/css">
        #div_msg{
            font-size:14px;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />

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
                            <h3 class="page-title">查询考生录取状态
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="#">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="#">艺考查询</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">查询高考科目成绩
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
              
                                  
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span12">
                            <div class="widget blue">
                                <div class="widget-body">
                                   <div class="control-group">
                                        <div class="span6 controls" runat="server" id="div_msg"></div>
                                    </div>
                                   <div class="control-group">
                                       <div class="span6 controls" runat="server" id="div_major"></div>
                                    </div>       
                                    <div class="control-group">
                                        <div class="span6 controls" runat="server" id="div_AEE"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>


