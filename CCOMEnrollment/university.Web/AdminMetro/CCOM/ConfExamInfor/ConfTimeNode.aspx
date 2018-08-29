<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfTimeNode.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfTimeNode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
    <style>
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
                    title: "① 填写时间节点",
                    content: "确定注册开启、结束时间及排考时间"
                }, {
                    title: "② 确认机构信息",
                    content: "按照学院、部、系、专业编辑机构信息"
                }, {
                    title: "③ 配置专业方向",
                    content: "完善专业方向信息"
                }, {
                    title: "④ 配置管理员信息",
                    content: "确认其他各系部管理员信息"
                }, {
                    title: "⑤ 配置资源信息",
                    content: "确认考场、评委及其他相关资源信息"
                }, {
                    title: "⑥ 添加科目",
                    content: "配置专业方向对应科目信息"
                }, {
                    title: "⑦ 完成",
                    content: "配置年度报考信息完成"
                }]
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txtApplyStart" defaultbutton="btnSubmit">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">配置报考信息
                            </h3>
                        </div>
                    </div>
                    <div class="space12"></div>
                    <div class="row-fluid">
                        <div class="space12"></div>
                        <div class="control-group">
                            <div class="ystep"></div>
                        </div>

                        <%--时间节点信息--%>
                        <div class="span6">
                            <div>
                                <div class="widget-body">

                                    <%--注册开启--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_realname">注册开启时间</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtApplyStart" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--注册结束--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_mobile">注册结束时间</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtApplyEnd" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--排考开启--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="rbl_User_gender">排考开启时间</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtArrangeStart" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--排考结束--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="rbl_User_gender">排考结束时间</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtArrangeEnd" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
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
                            <input name="重置" type="reset" class="btn" value="重 置" />
                            &nbsp;
                            <asp:Button ID="btnSubmit" runat="server" Text="下一步" CssClass="btn btn-success _step3" OnClick="btn_Submit_Click" />

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
