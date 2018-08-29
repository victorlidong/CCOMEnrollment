<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfManager.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfManager" %>

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
            $(".ystep").setStep(4);
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

                        <div class="tab-pane active" id="tab_1_1">
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <a href="../ManagerManage/AddManager.aspx?action=<%=MyEnums.ActionEnum.Add.ToString() %>&fun_id=<%=DESEncrypt.Encrypt("15") %>" class="btn btn-success"><i class="icon-plus icon-white"></i>添加管理员</a>
                                            </div>

                                            <div class="span6">
                                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
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
                                                                        <th style="width: 14%;">操作</th>
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
                                                                    <td>
                                                                        <a href="../ManagerManage/AddManager.aspx?userId=<%#Eval("User_id") %>&action=<%=MyEnums.ActionEnum.Edit.ToString() %>&fun_id=<%=DESEncrypt.Encrypt("15") %>">
                                                                            <i class="icon-pencil"></i>编辑
                                                                        </a>
                                                                        &nbsp;
                                                                        <a href="../RoleManage/PermissionManage.aspx?id=<%#Eval("User_id") %>&type=1&fun_id=<%=DESEncrypt.Encrypt("41") %>">
                                                                            <i class="icon-pencil"></i>编辑权限
                                                                        </a>
                                                                        &nbsp;
                                                                <asp:LinkButton ID="lbtAble" runat="server" OnClick="lbtAble_Click" ToolTip='<%# DESEncrypt.Encrypt(Eval("User_id").ToString())%>'>
                                                                        <%#GetStatusText((Boolean)Eval("User_status"))%>
                                                                </asp:LinkButton>
                                                                    </td>
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
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
