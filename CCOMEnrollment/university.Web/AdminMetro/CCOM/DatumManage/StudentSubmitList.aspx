<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSubmitList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.DatumManage.StudentSubmitList" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交材料列表</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script>
        function DeleteWeekly(id) {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'DeleteWeek',
                    ID: id,
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        parent.jsprint(data["msg"], "", "Success", "");
                        location.reload();
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .mainTab{
            float:left;
            background-color:white;
            list-style:none;
            width:80%;
        }
        .fileTab{
            float:left;
            background-color:white;
            list-style:none;
            width:80%;
            margin-bottom:10px;
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
                            <h3 class="page-title">提交材料列表
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">
                            <ul class="weeks" id="week_list" runat="server">
                            </ul>
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <hr style="height:1px;border:none;border-top:1px solid #B0C4DE; width:90%; margin-left:25px;"/>
                        <div class="span12 tab_con first-tab" style="height:200px;">
                        
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>