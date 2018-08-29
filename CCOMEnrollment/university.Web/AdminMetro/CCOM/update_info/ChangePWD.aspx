<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePWD.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.update_info.ChangePWD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->

</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txtOldPwd" defaultbutton="btn_Submit">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">修改密码
                            </h3>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <%--旧密码--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_realname">旧密码</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtOldPwd" runat="server" CssClass="input-block-level required" minlength="6" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--新密码--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">新密码</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtNewPwd" runat="server" CssClass="input-block-level required"  minlength="6" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--重复新密码--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="rbl_User_gender">确认新密码</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtNewPwd2" runat="server" CssClass="input-block-level required"  minlength="6" autocomplete="off"></asp:TextBox>
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
                            <asp:Button ID="btn_Submit" runat="server" Text="确认修改" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
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
