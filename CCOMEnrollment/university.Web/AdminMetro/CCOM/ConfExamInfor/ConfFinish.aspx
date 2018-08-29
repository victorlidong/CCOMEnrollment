<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfFinish.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfFinish" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
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
            $(".ystep").setStep(7);
        });
        function SendSms() {
            $("#div_sms").show();
            ShowExample();
            $.layer({
                type: 1,
                shade: [0.8, '#000'],
                shadeClose: true,
                title: "确认导入学生信息",
                area: ['660px', '400px'],
                border: [0],
                page: { dom: '#div_sms' },
                closeBtn: false,
            });
            //var d = dialog({
            //    title: '确认',
            //    content: '确认信息无误，用户导入不可恢复！',
            //    okValue: '确定',
            //    ok: function () {
            //        var that = this;
            //        $("#btnSubmit").click();
            //        that.close().remove();
            //        //__doPostBack("btnSubmit", "");
            //        $("#btn-wrong").hide();
            //        return true;
            //    }
            //});
            //d.showModal();
            SmsDiv();
            return false;
        }
        function SmsDiv() {
            var ischecked = $("#cbSendSms").prop("checked");
            if (ischecked) {
                $(".suresms").show();
                $(".xubox_main").height("400px");
            }
            else {
                $(".xubox_main").height("200px");
                $(".suresms").hide();
            }
        }
        function ShowExample() {
            var str = $("#txtMessageText").val();
            str = str.replace(/{登录名}/, '<font color="red">' + $("#hidTemplateUserLoginName").val() + '</font>');
            str = str.replace(/{姓名}/, '<font color="red">' + $("#hidTemplateUserRealName").val() + '</font>');
            $("#lblSmsPreview").html(str);
        }
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
                        <div class="row-fluid">
                        <input type="button" id="Button1" value="再次确认管理员信息：" class="btn" />
                    </div>
                                    <div class="space5"></div>
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <asp:ScriptManager ID="ScriptManager2" runat="server"/> 
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
                                                <ContentTemplate>
                                                    <!--列表展示.开始-->
                                                    <asp:Repeater ID="rptList" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered  table-hover" id="listTable">
                                                                <thead>
                                                                    <tr>
                                                                        <!--<th style="width: 5%;">
                                                                        <input type="checkbox" onclick='checkAllForEnable(this, "#listTable")' />
                                                                    </th>-->
                                                                        <!--总计71-->
                                                                        <th style="width: 10%;">姓名</th>
                                                                        <th style="width: 10%;">手机号</th>
                                                                        <th style="width: 12%;">所属机构</th>
                                                                        <th style="width: 12%;">所属角色</th>
                                                                        <th style="width: 16%;">添加时间</th>
                                                                        <th style="width: 8%;">启用状态</th>
                                                                    </tr>
                                                                </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tbody>
                                                                <tr>
                                                                    <!--<td>
                                                                    <asp:CheckBox ID="chkId" runat="server"/>
                                                                </td>-->
                                                                    <td>
                                                                        <asp:HiddenField ID="hidId" Value='<%#Eval("User_id")%>' runat="server" />
                                                                        <%#Eval("User_realname")%>
                                                                    </td>
                                                                    <td><%#Eval("User_mobile")%></td>
                                                                    <td><%#Eval("Agency_name")%></td>
                                                                    <td><%#Eval("Role_name")%></td>
                                                                    <td><%#Eval("User_addtime")%></td>
                                                                    <td>已<%#(Boolean)Eval("User_status")==true?"启用":"禁用"%></td>
                                                                </tr>
                                                            </tbody>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                                                        </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <!--列表展示.结束-->
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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
                    </div>
                    <div class="row-fluid">
                        <%--                        <asp:CheckBox ID="CheckSend" CssClass="checkall" AutoPostBack="true" OnCheckedChanged="CheckSend_CheckedChanged" Text="发短信提醒？" runat="server" />--%>
                        <asp:Panel ID="panelSendMessage" runat="server" Visible="false" Style="float: left">
                            <asp:TextBox ID="txtSendMessage" runat="server" CssClass="txtInput normal " TextMode="MultiLine" Height="70" Width="700" />
                        </asp:Panel>
                    </div>
                    <div class="space10"></div>
                    <div class="row-fluid">
                        <input type="button" id="btn-wrong" value="信息有误，重新输入" class="btn" onclick="javascript: history.go(-1);" />
                        <input type="button" value="确认信息无误，完成" class="btn btn-success" onclick="SendSms()" />
                    </div>
                    <div class="row-fluid">
                        <div class="span12" id="div_sms" style="display: none; width: 660px;">
                            <div class="space15"></div>
                            <div class="control-group">
                                <label class="control-label">短信通知：</label>
                                <div class="controls">
                                    <asp:CheckBox runat="server" ID="cbSendSms" CssClass="item-margin" Text="发送短信息通知其他管理员" Checked="True"  onchange="SmsDiv()" />
                                </div>
                            </div>
                            <div class="control-group suresms">
                                <label class="control-label">短信模板：</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtMessageText" TextMode="MultiLine" Width="490px" Height="110px" onkeyup="ShowExample()">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group suresms">
                                <label class="control-label">短信预览：</label>
                                <div class="controls">
                                    <asp:Label runat="server" ID="lblSmsPreview" Style="max-height: 110px; width: 500px; overflow: auto; display: block;"></asp:Label>
                                </div>
                            </div>
                            <div class="form-actions">
                                &nbsp;
                        <asp:Button runat="server" ID="btnSubmit" OnClick="btn_Submit_Click" Text="确认" CssClass="btn btn-success" />
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
