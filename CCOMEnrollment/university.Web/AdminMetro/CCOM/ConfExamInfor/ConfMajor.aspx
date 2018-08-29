<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfMajor.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfMajor" %>

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
            $(".ystep").setStep(3);
        });
        var Index;
        $(function () {
            var tabIndex = $("#tabIndex").val();
            if (tabIndex != "") {
                showTab("#pageTab1", parseInt(tabIndex));
            }
        });
        function showTab(tabId, tabIndex) {
            $(tabId + " li:eq(" + (tabIndex - 1) + ") a").tab('show');
        }
        function EditForm(id, AgencyID, name, Academic, Require, Reference, Remark) {
            $("#" + id).show();
            $("#txtID").val(AgencyID);
            $("#lblTip").text("编辑专业方向--" + name);
            $("#txtacademic").val(Academic);
            $("#txtrequire").val(Require);
            $("#txtreference").val(Reference);
            $("#txtremark").val(Remark);
            var _width = $("#" + id).width();
            $.layer({
                type: 1,
                shade: [0.8, '#000'],
                area: [_width + 'px', 'auto'],
                title: false,
                border: [0],
                shadeClose: true,
                page: { dom: '#' + id },
                closeBtn: [0, true],
                close: function (index) {
                    $("#" + id).hide();
                }
            });
        }
        function SubmitMajor() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'UpdateMajor',
                    Agency: $("#txtID").val(),
                    Academic: $("#txtacademic").val(),
                    Require: $("#txtrequire").val(),
                    Reference: $("#txtreference").val(),
                    Remark: $("#txtremark").val(),
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
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
                            <div class="span6"></div>
                            <div class="span6">
                                <div class="pull-right">
                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" placeholder="专业名称" />
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="space10"></div>
                                <div class="tabbable custom-tab">
                                    <ul class="nav nav-tabs" id="pageTab1">
                                        <li class="active"><a href="#tab_1_1" data-toggle="tab">专业方向列表</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="tab_1_1">
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <!--列表展示.开始-->
                                                    <asp:Repeater ID="rptList" runat="server">
                                                        <HeaderTemplate>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                                <tr>
                                                                    <th width="3%" style="text-align: center;">序号</th>
                                                                    <th width="8%" style="text-align: center;">专业方向</th>
                                                                    <th width="5%" style="text-align: center;">学制</th>
                                                                    <th width="12%" style="text-align: center;">报考要求</th>
                                                                    <th width="12%" style="text-align: center;">参考书目</th>
                                                                    <th width="12%" style="text-align: center;">备注</th>
                                                                    <th width="5%" style="text-align: center;">操作</th>
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                    <%# rptList.Items.Count + 1 %>
                                                                </td>
                                                                <td align="left"><%#Eval("Agency_name")%></td>
                                                                <td style="text-align: center;"><%#GetAcademic(int.Parse(Eval("Agency_id").ToString()))%></td>
                                                                <td align="left"><%#GetRequire(int.Parse(Eval("Agency_id").ToString()))%></td>
                                                                <td align="left"><%#GetReference(int.Parse(Eval("Agency_id").ToString()))%></td>
                                                                <td align="left"><%#GetRemark(int.Parse(Eval("Agency_id").ToString()))%></td>
                                                                <td style="text-align: center;">
                                                                    <a href="javascript:EditForm('edit_resource', <%#Eval("Agency_id")%>, '<%#Eval("Agency_name")%>', '<%#GetAcademic(int.Parse(Eval("Agency_id").ToString()))%>', '<%#GetRequire(int.Parse(Eval("Agency_id").ToString()))%>', '<%#GetReference(int.Parse(Eval("Agency_id").ToString()))%>', '<%#GetRemark(int.Parse(Eval("Agency_id").ToString()))%>')" >编辑</a>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>



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
                                    </div>
                                </div>

                            </div>
                        </div>


                    </div>

                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                            <input type="button" class="btn btn-success" value="上一步" onclick="javascript: history.go(-1);" />
                            &nbsp;
                            <input name="重置" type="reset" class="btn" value="重 置" />
                            &nbsp;
                            <asp:Button ID="btnUpload" Visible="False" runat="server" Text="提　交" CssClass="btn btn-success" />
                            &nbsp;
                            <asp:Button ID="btnSubmit" runat="server" Text="下一步" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_resource" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <asp:Label runat="server" Style="color: white; font-size: 15px; margin-left:10px;" ID="lblTip"></asp:Label>
                                </div>
                                <asp:TextBox ID="txtID" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>学制</td>
                                                    <td>
                                                        <asp:TextBox ID="txtacademic" runat="server" MaxLength="100" Width="550px" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>报考要求</td>
                                                    <td>
                                                        <asp:TextBox ID="txtrequire" runat="server" TextMode="MultiLine" MaxLength="300" Width="550px" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>参考书目</td>
                                                    <td>
                                                        <asp:TextBox ID="txtreference" runat="server" TextMode="MultiLine" MaxLength="300" Width="550px" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>备注</td>
                                                    <td>
                                                        <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" MaxLength="300" Width="550px" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button1" value="确认修改" class="btn btn-success" onclick="SubmitMajor()" />
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
