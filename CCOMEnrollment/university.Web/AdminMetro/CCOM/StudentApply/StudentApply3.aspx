<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentApply3.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentApply.StudentApply3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑科目</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
    <style type="text/css">
     .ystep-lg
        {
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ystep").loadStep({
                //ystep的外观大小
                size: "large",
                color: "green",
                steps: [{
                    title: "① 填写个人信息",
                    content: "完善个人基本信息及家庭联系方式等"
                }, {
                    title: "② 填写证件信息",
                    content: "填写证件信息、免冠照片及省艺术联考信息"
                }, {
                    title: "③ 完善考试内容",
                    content: "确认考试信息并填写曲目信息"
                }]
            });
            $(".ystep").setStep(3);
        });
        function setFocus(control) {
            var controlToValidate = document.getElementById(control);
            controlToValidate.focus();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
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
                            <h3 class="page-title">编辑科目
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <div class="control-group">
                        <div class="ystep"></div>
                    </div>
                    <!--BEGIN  PAGE BODY CONTENT-->
                    <asp:ValidationSummary DisplayMode="BulletList" EnableClientScript="true"  runat="server"/>
                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                        <ContentTemplate>
                            <div class="row-fluid" id="contentTab">
                                <div runat="server" id="divControls"></div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-actions">
                        <a href="javascript:history.go(-1);" class="btn btn-success">上一步</a>
                        &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                        <p></p>
                    </div>
                    <!-- END PAGE CONTAINER-->
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
