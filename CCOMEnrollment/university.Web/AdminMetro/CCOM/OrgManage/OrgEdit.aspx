<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgEdit.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.OrgManage.OrgEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑部门</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ztree.html"-->
    <script type="text/javascript">
        function AlertForm(id) {
            $.layer({
                type: 2,
                shadeClose: true,
                title: "选择机构",
                closeBtn: [0, true],
                shade: [0.8, '#000'],
                border: [0],
                offset: ['20px', ''],
                area: ['500px', ($(window).height() - 50) + 'px'],
                iframe: { src: './select_ud.aspx?refresh=false&id=' + id + "&fun_id=" + '<%=university.Common.DESEncrypt.Encrypt(this.fun_id.ToString())%>' }
            });
        }
        function Refresh()
        {
            window.open('OrgEdit.aspx?fun_id=<%=university.Common.DESEncrypt.Encrypt(this.fun_id.ToString())%>&selectid=' + $("#ddlEditSelect").val(), '_self');
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <input id="hiduoid" runat="server" type="hidden" value ="-12" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">编辑部门
                            </h3>
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    机构管理
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">编辑部门
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>选择部门</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlEditSelect" CssClass="select2 required" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEditSelect_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<a onclick="AlertForm('ddlEditSelect');" class="btn">快速选择</a>--%>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>部门名称</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtEditName" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>部门类型</label>
                                <div class="controls">
                                    <asp:DropDownList runat="server" ID="ddlType">
                                        <asp:ListItem Text="行政机构" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="部" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="系" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="专业" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>状态</label>
                                <div class="controls">
                                    <asp:RadioButtonList ID="rbEditStatus" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                        <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                                        <asp:ListItem Value="0">停用</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            
                            <div class="form-actions">
                                <asp:Button ID="btnEditSubmit" runat="server" Text="编 辑" CssClass="btn btn-success" OnClick="btnEditSubmit_Click" />
                                &nbsp;<input name="重置" type="reset" class="btn" value="重 置" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>    <!--#include file="/metro/include/footer_common.html"-->

</body>
</html>

