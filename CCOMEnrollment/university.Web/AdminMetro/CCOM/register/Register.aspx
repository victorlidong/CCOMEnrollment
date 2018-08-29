<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.register.Register" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="renderer" content="webkit" />
     <!--#include file="/metro/include/header_common.html"-->
     <!--#include file="/metro/include/header_datepicker.html"-->
    <link href="/metro/assets/bootstrap/css/bootstrap-index-v3.min.css" rel="stylesheet" />
    <link href="/admin/css/css_index/login-page-v3.css" rel="stylesheet" type="text/css" />
    <title>中央音乐学院招生系统注册</title>
    <script type="text/javascript">
        function checkSmsCode() {
            if (flag == 0)
            {
                document.getElementById('<%=lblTip.ClientID%>').innerHTML = "当前暂未开启注册";
                return false;
            }
            var code = $("#txtSmsCode").val();
            if (/[\d]{6}/.test(code)) {
                return true;
            } else {
                parent.jsprint("请输入6位验证码！", "", "Error");
                return false;
            }
            var phoneNumber = $("#txtPhoneNumber").val();

            if (phoneNumber.length == 0) {

                document.getElementById('<%=lblTip.ClientID%>').innerHTML = "请填写手机号";
                return;
            }
            if (!myreg.test(phoneNumber)) {

                document.getElementById('<%=lblTip.ClientID%>').innerHTML = "手机号无效";
                return;
            }

            if ($("#txtUserPwd").val() != $("#txtUser_pasword_confer").val()) {
                document.getElementById('<%=lblTip.ClientID%>').innerHTML = "密码前后不一致";
                return;
            }
        }
        var flag = 1;
        var myreg = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
        $(document).ready(function () {
            $("#GetCode").click(function () {
               
                var phoneNumber = $("#txtPhoneNumber").val();

                if (phoneNumber.length == 0) {

                    document.getElementById('<%=lblTip.ClientID%>').innerHTML = "请填写手机号";
                    return;
                }
                if (!myreg.test(phoneNumber)) {

                    document.getElementById('<%=lblTip.ClientID%>').innerHTML = "手机号无效";
                    return;
                }

                if ($("#txtUserPwd").val() != $("#txtUser_pasword_confer").val()) {
                    document.getElementById('<%=lblTip.ClientID%>').innerHTML = "密码前后不一致";
                    return;
                }

                $.ajax({
                    type: "POST",
                    url: "/AdminMetro/CCOM/register/CheckOpenTime.ashx",
                    data: { "action": "getOpenTime" },
                    success: function(data)
                    {
                        if(data=="success")
                        {
                            
                            $.ajax({
                                type: "POST",
                                url: "GetCode.ashx",
                                data: { "phoneNumber": $("#txtPhoneNumber").val() },
                                success: function (data) {
                                    if (data == "1") {
                                        document.getElementById('<%=lblTip.ClientID%>').innerHTML = "";
                                        $("#GetCode").toggleClass("orange brown");      //设置按钮样式为灰色
                                        $("#GetCode").attr("disabled", true);   //设置按钮不可用
                                        RemainTime(60);
                                    }
                                    else {

                                        document.getElementById('<%=lblTip.ClientID%>').innerHTML = data;
                                    }

                                },
                                error: function (data) {
                                    alert("请求数据出错");
                                    ///topWin(msgtitle, url, msgcss);
                                }
                            });
                        }
                        else
                        {
                            flag = 0;
                            document.getElementById('<%=lblTip.ClientID%>').innerHTML = data;
                            return;
                        }
                    },
                    error: function(data)
                    {
                        alert("请求出错");
                        return;
                    }
                });



               
            });
        });
 
        var Account;
        function RemainTime(sec) {
            if (sec <= 0) {
                $("#GetCode").toggleClass("orange brown");      //当时间<=0的时候恢复按钮的样式
                $("#GetCode").val("获取验证码");      //当时间<=0的时候改变按钮的文本  
                $("#GetCode").attr("disabled", false);   //如果时间<=0的时候按钮可用  
                clearTimeout(Account);                      //取消设置的timeout  
            }
            else {
                sec = parseInt(sec) - 1;
                Account = setTimeout("RemainTime('" + sec + "')", 1000);
                $("#GetCode").val("(" + sec + "）秒");
            }
        }
    
       
    </script>

    <style type="text/css">
        .body-container {
            width: 100%;
            height:100%;
            min-width:1100px;
            min-height:650px;
            background-image:url(/images/login/wqbackground.png);
            background-repeat: no-repeat; 
            background-size: cover;
        }
        .container
        {
            width:860px;
            height:450px;
            background: rgba(255, 255, 255, 0.7) none repeat scroll 0 0 !important; /*实现FF背景透明，文字不透明*/
            margin:0 auto;
            max-height:500px;
            
        }
        .left
        {
            width:350px;
            height:450px;
            max-height:450px;
            
        }
        .forImage
        {
            width:90%;
            height:360px;
            max-height:380px;
            margin:0 auto;
        }
        .mid
        {
            height:90%;
            width:1px;
            background:url(/images/login/login-mid.png);
            background-repeat: no-repeat; 
            background-size: cover;
            margin-left:360px;
            margin-top:-450px;
        }
        .right
        {
            width:500px;
            height:100%;
            float:right;
            margin-top:-400px;
            margin-right:10px;
        }
       .right_top
       {
           width:100%;
           height:70px;
       }
       .right_top_left
       {
           width:45%;
           height:40px;
           float:left;
           padding-top:20px;
       }
       .right_top_right
       {
           width:45%;
           height:40px;
           float:right;
           padding-top:20px;
       }
       .right_body
       {
           width:100%;
           height:360px;
           
       }
       .divForInput
       {
           width:100%;
           text-align:center;
           height:50px;
           margin-top:10px;
           
       }
       .txt_Input
       {
           width:60%;
           font-size:20px;
       }
       .mybtn
       {
           font-family: 黑体;
            font-size: 22px;
            display: block;
            height: 40px;
            width: 316px;
            line-height: 40px;
            text-align: center;
            letter-spacing: 2px;
            /*background: #ef6c34;*/
            background: #3dc1f3;
            color: white;
            border-radius: 10px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            margin-left:93px;
       }
       .mybtn hover
       {
           color: white;
           background: #3499cd;
           text-decoration: none;
       }
    </style>
</head>
<body>
    
    <div class="body-container">
        <div style="width:100%;height:100px;">

        </div>
        <div class="container">
            <div class="left">
                <div style="width:100%;height:70px;">
                </div>
                <div class="forImage">
                    <img src="/images/login/logo2.png" />
                </div>
            </div>
            <div class="mid">    
            </div>
            <div class="right">
                <div class="right_top">
                    <div class="right_top_left">
                        <label class="loginLabal" style="color:#3499cd;font-size:30px;">用户注册</label>              
                    </div>
                    <div class="right_top_right">
                        <a href="/AdminMetro/login_page.aspx" style="margin-left:50px;float:right;margin-right:18%;color:#3499cd;font-size:18px;"><img src="/images/login/back4.png"/> 返回登录</a>  
                    </div>
                </div>
                <div class="right_body">
                    <form id="form1" runat="server">
                        <div class="divForInput">
                            <asp:TextBox CssClass="txt_Input" ID="txtPhoneNumber" runat="server" placeholder="手机号" style="height:30px;font-size:20px;"></asp:TextBox>
                        </div>
                        <div class="divForInput">
                            <asp:TextBox ID="txtUserPwd" TextMode="Password" runat="server"  CssClass="txt_Input formIpt"  style="height:30px;font-size:20px;" placeholder="6~16位密码(数字和字母)"></asp:TextBox>
                        </div>
                        <div class="divForInput">
                            <asp:TextBox ID="txtUser_pasword_confer" TextMode="Password" runat="server" CssClass="txt_Input formIpt"  style="height:30px;font-size:20px;" placeholder="确认密码"></asp:TextBox>
                        </div>
                        <div class="divForInput">
                            <asp:TextBox ID="txtSmsCode" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));"  MaxLength="6" runat="server"  placeholder="6位数字" style="height:30px;font-size:20px;width:194px;"></asp:TextBox>
                            <input id="GetCode" type="button" class="btn btn-warning" value="获取验证码" style="margin-left:15px;width:88px;height:40px;margin-top:-9px;"/>
                        </div>
                        <div class="divForInput">
                            <asp:LinkButton ID="btnSubmit"  CssClass="mybtn" OnClick="btnSubmit_Click" runat="server" OnClientClick="return checkSmsCode()" style="text-decoration:none;">注 册</asp:LinkButton>
                        </div>
                        <div class="divForInput">
                            <asp:Label ID="lblTip" runat="server" Text="" ForeColor="red"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    
</body>
</html>
