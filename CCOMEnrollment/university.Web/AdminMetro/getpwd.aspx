<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getpwd.aspx.cs" Inherits="university.Web.AdminMetro.getpwd" %>

<!DOCTYPE html>

<html lang="en">
<head id="Head1" runat="server">
    <title>找回密码</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />
    <link href="/admin/css/css_index/loginIndex-v3.css" rel="stylesheet" type="text/css" />
    <link href="/metro/assets/bootstrap/css/bootstrap-index-v3.min.css" rel="stylesheet" />
    <style type="text/css">
        .box-getpwd {
            /*padding-top: 1em;*/
        }

        .text-label {
            width: 90px;
            text-align: right;
            margin-right: 20px;
            vertical-align: middle;
            line-height: 30px;
        }

        .float-left {
            float: left;
        }

        .btn {
            /*padding: 0 8px;*/
            height: 32px;
            /*line-height: 34px;*/
            font-family: "微软雅黑";
            /*font-size: medium;*/
            color: #707070;
            border: 1px solid #D7D7D7;
            background: url(./images/btn_bg.gif) repeat-x;
            cursor: pointer;
            vertical-align: middle;
            overflow: hidden;
            margin-top: 10px;
        }

            .btn:hover {
                background-position: 0 -13px;
                color: black;
                font-weight: bold;
                 background: url(./images/btn_bg.gif) repeat-x;
            }

        .btn-small {
            color: #707070;
            height: 30px;
            border: 1px solid #D7D7D7;
            background: url(./images/btn_bg.gif) repeat-x;
            cursor: pointer;
            /*vertical-align: middle;*/
            overflow: hidden;
            padding: 1px 12px;
        }

            .btn-small:hover {
                background-position: 0 -13px;
                color: black;
                font-weight: bold;
            }

        .btn-small-gray, .btn-small-gray:hover {
            background-color: #999;
        }

        #optMethod {
            margin-bottom: 10px;
        }

            #optMethod label {
                font-size: 16px;
                margin-right: 10px;
            }

        .kclear {
            clear: both;
        }
        .box-submit {
            padding-left: 110px;
        }
        #lblReInfo {
            line-height: 20px;
            vertical-align: bottom;
        }
        .return-hint {
            color: #999; margin-top: 2em;
            font-size: 16px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="mainbody" id="body_top">
            <div class="nav_banner nav_banner-fixed-top nav_banner-scroll" id="top_nav_banner">
                <div class="container noindex-nav">
                    <div class="row-fluid">
                        <div class="span2">
                            <div class="nav-visited">
                                <div runat="server" id="divVisited">
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="line1-gray"></div>
            </div>

            <div class="row-fluid noindex-content">
                <div class="container">
                    <div class="space20"></div>
                    <div class="space20"></div>
                    <div class="row-fluid">
                        <div class="span3">
                        </div>
                        <div class="span6" id="tabs1-content">
                            <div id="Div1" runat="server" class="box-getpwd">
                                <!--content-->
                                <div>
                                    <h3 style="color: #14b8f7;">找回密码</h3>
                                    <asp:HiddenField ID="hidIsTick" runat="server" />
                                    <asp:Panel ID="PanelPhone" runat="server">
                                        <div>
                                            <div class="text-label float-left">用户名：</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="txtUserName1" runat="server" Width="200" placeholder="工号/学号"></asp:TextBox></div>
                                            <div class="kclear"></div>
                                        </div>
                                        <div>
                                            <div class="text-label float-left">手机号：</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="txtPhone" runat="server" Width="200"></asp:TextBox></div>
                                            <div class="float-left">
                                                <asp:Button ID="btnPhoneCode" CssClass="btn-small" style="width:100px;" runat="server" Text="获取验证码" OnClick="btnPhoneCode_Click" /></div>
                                            <div class="kclear"></div>
                                        </div>
                                        <div>
                                            <div class="text-label float-left">手机验证码：</div>
                                            <div class="float-left">
                                                <asp:TextBox ID="txtPhoneCode" runat="server"></asp:TextBox></div>
                                            <div class="kclear"></div>
                                        </div>
                                    </asp:Panel>
                                    <div class="box-submit">
                                        <asp:Button ID="btnGetPwd" CssClass="btn" Width="150" runat="server" Text="确定找回" OnClick="btnGetPwd_Click" />
                                        &nbsp;&nbsp;<asp:Label ID="lblReInfo" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                    <div class="return-hint"><span style="color: #14b8f7;"><a href="/AdminMetro/login_page.aspx">点击返回首页</a></span>，如无法找回密码，请<b style="color: black;"> 联系所在学院管理员</b></div>
                                </div>

                            </div>
                        </div>
                        <div class="span2">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <script type="text/javascript">
        var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
        document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F9a103a0d184ea7d73dccd3718e1b990d' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/admin/js/login-v3.js"></script>
    <script type="text/javascript" src="/metro/assets/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/admin/js/jquery.placeholder.js"></script>
    <script type="text/javascript" src="/admin/js/function.js"></script>
    <script type="text/javascript">
        var id;
        function setting(s) {
            var btn = document.getElementById("btnPhoneCode");
            btn.disabled = true;
            btn.className = "btn-small";
            btn.value = "(" + s + ")获取验证码";
            s = parseInt(s) - 1;
            if (s == 0) {
                window.clearTimeout(id);
                btn.value = "获取验证码";
                btn.className = "btn-small";
                btn.disabled = false;
            }
            else {
                id = setTimeout("setting('" + s + "')", 1000);
            }
        }
        $(document).ready(function () {
            if ($("#hidIsTick").val() == "1") {
                setting(60);
            }
        });
    </script>
</body>
</html>
