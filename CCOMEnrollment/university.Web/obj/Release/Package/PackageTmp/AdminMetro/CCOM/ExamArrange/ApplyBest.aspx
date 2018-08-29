<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyBest.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.ApplyBest" %>

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
                            <h3 class="page-title">申请优秀毕业论文
                            </h3>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">申请条件</label>
                                                <div class="controls" style="width:250px">
                                                    <label class="control-label" style="width:250px;text-align:left">形式审查表一通过指导教师审核并合格</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="div_user_agency" class="row-fluid" runat="server">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">表一审核结果</label>
                                                <div class="controls">
                                                    <label class="control-label" style="width:250px;text-align:left" runat="server" id="lblResult"></label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                            <a runat="server" id="lblSubmit" class="btn btn-success">申请评优</a>
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
