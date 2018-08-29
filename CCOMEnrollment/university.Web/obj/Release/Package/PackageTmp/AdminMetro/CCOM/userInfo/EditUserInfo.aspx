<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserInfo.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.userInfo.EditUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑个人信息</title>
    <!--#include file="/metro/include/header_common.html"-->
     <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript">
        function showimg() {
            var facePath = document.getElementById("txtAvatar").value;
            if (facePath != "") {
                if (!facePath.startWith('http'))
                    facePath = "http://static.quanquan6.com" + facePath;
                document.getElementById("face").src = facePath
            }
        }
         //表单验证
        $(function () {
            $("#form1").validate({
                errorPlacement: function (lable, element) {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                },
                success: function (lable) {
                    lable.ligerHideTip();
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" style="margin:0 auto;">
        <input id="hiduserid" runat="server" type="hidden" />
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <div class="row-fluid" style="width:60%;">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">编辑个人信息</h3>
                            <ul class="breadcrumb" style="width:60%;">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="#">个人中心</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">个人资料
                                </li>
                            </ul>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div id="row-fluid">
                        <div class="span12" ><%--style="padding:0 35%;margin-top:50px;"--%>
                           
                            <div class="control-group">
                                <label class="control-label">电话：</label>
                                <div class="controls">
                                    <%--<asp:TextBox ID="txt_phone_number" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="50"></asp:TextBox>
                                    <asp:Label ID="mobileAttention" runat="server" style="color:#F00"></asp:Label>--%>
                                    <asp:Label ID="lbl_phone_number" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">证件类型：</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddl_identity_type" runat="server" CssClass="select2">
                                    </asp:DropDownList>
                                </div>
                            </div>
                           <div class="control-group">
                                <label class="control-label">证件号：</label>
                                <div class="controls">
                                    <asp:TextBox ID="txt_identity_number" runat="server" CssClass="txtInput normal  required" minlength="2" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">真实姓名：</label>
                                <div class="controls">
                                    <%--<asp:Label ID="lblUI_RealName" runat="server"></asp:Label>--%>
                                    <asp:TextBox ID="txt_realname" runat="server" CssClass="txtInput normal  required" minlength="2" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">性别：</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddl_Sex" runat="server" CssClass="select2">
                                        <asp:ListItem Value="1">男</asp:ListItem>
                                        <asp:ListItem Value="0">女</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">用户类别：</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddl_user_type" runat="server" CssClass="select2">
                                    <asp:ListItem Value="1">大陆考生</asp:ListItem>
                                    <asp:ListItem Value="2">港澳台考生</asp:ListItem>
                                    <asp:ListItem Value="3">华侨</asp:ListItem>
                                    <asp:ListItem Value="4">协作计划</asp:ListItem>
                                    <asp:ListItem Value="5">定向计划</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">生日：</label>
                                <div class="controls">
                                    <input type="text" id="txtBirthday" runat="server" class="txtInput normal dateISO" readonly="true" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">注册时间：</label>
                                <div class="controls">
                                    <asp:Label ID="lbl_register_time" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
