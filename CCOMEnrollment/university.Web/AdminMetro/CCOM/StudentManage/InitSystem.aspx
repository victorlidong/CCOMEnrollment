<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitSystem.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentManage.InitSystem" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->

</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">初始化系统
                            </h3>
                       </div>
                    <div class="space5"></div>
                    <%--<div class="row-fluid">

                        <div class="span7">
                            <div class="widget blue" style="width:100%">
                                <div class="widget-body">

                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="control-group">
                                                <label class="btn btn-error">删除所有学生</label>
                                                &nbsp;&nbsp;
                                                <label class="btn btn-error">删除所有选题</label>
                                                &nbsp;&nbsp;
                                                <label class="btn btn-error">删除所有提交材料</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="control-group">
                                                <label class="btn btn-error">删除所有答辩组</label>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                            <asp:Button ID="btn_Submit" OnClientClick="return confirm('本次操作将删除所有用户、所有选题、所有提交的材料、所有答辩组及与其相关的信息，您确定要进行初始化吗?');void(0);" OnClick="btn_Submit_Click" runat="server" Text="一键初始化系统" CssClass="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
