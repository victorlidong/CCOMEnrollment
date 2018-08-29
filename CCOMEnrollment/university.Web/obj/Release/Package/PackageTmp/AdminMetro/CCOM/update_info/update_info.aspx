<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_info.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.update_info.update_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->

</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txt_User_realname" defaultbutton="btn_Submit">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">编辑用户信息
                            </h3>
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
                                                <label class="control-label" for="txt_User_realname">真实姓名</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_realname" runat="server" CssClass="input-block-level required" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--所在机构--%>
                                    <div id="div_user_agency" class="row-fluid" runat="server">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_Agency">所在机构</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_Agency" runat="server" CssClass="input-block-level required" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--学号--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">工号/学号</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_number" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--性别--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="rbl_User_gender">性别</label>
                                                <div class="controls">
                                                    <asp:RadioButtonList CssClass="item-margin" ID="rbl_User_gender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                        <asp:ListItem Value="1" Selected="True">男 </asp:ListItem>
                                                        <asp:ListItem Value="0">女 </asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--出生日期--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">出生日期</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_birthday" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--添加日期--%>
                                    <div class="row-fluid" style="visibility:hidden">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">添加日期</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_addtime" onfocus="this.blur()" runat="server" CssClass="input-block-level" ReadOnly="true" />

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
                            <asp:Button ID="btn_Submit" runat="server" Text="提交保存" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
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
