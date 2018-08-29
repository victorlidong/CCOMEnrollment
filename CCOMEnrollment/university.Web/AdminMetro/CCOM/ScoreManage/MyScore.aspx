<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyScore.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.MyScore" %>

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
                            <h3 class="page-title">我的成绩
                            </h3>
                       </div>
                        <div class="row-fluid">
                            <label runat="server" id="lblScroeInfor"></label>
                            <%--<h5>成绩说明：指导教师评分满分为30分；口头答辩成绩、软件验收成绩满分为100分；最终成绩=指导教师评分+较小值（口头答辩成绩，软件验收成绩）*0.7
                            </h5>--%>
                        </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <%--真实姓名--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_realname">姓名</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_realname" runat="server" CssClass="input-block-level required" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                    <asp:TextBox ID="txtID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--学号--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">学号</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_number" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     <%--指导教师打分--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">指导教师评分</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtTeacherScore" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--口头答辩成绩--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">口头答辩成绩</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtCommentScore" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--软件验收成绩--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">软件验收成绩</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtScoftwareScore" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     <%--最终成绩--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">最终成绩</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtScore" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--口头答辩表--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">答辩评语表</label>
                                                <div class="controls">
                                                    <a runat="server" id="lblComment">答辩评语表</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--软件验收表--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">软件验收表</label>
                                                <div class="controls">
                                                    <a runat="server" id="lblSoft">软件验收表</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
