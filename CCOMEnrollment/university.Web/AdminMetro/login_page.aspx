<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_page.aspx.cs" Inherits="university.Web.AdminMetro.login_page" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html lang="en">
<head id="Head1" runat="server">
    <title>北京理工大学计算机学院本科毕业设计管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <link href="/metro/assets/bootstrap/css/bootstrap-index-v3.min.css" rel="stylesheet" />
    <%-- <link href="/admin/css/css_index/login-page-v3.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript">
        var cur_page = 1;
        var page_num;
        $(document).ready(function () {
            page_num = $("#page_num").val();
            //alert(page_num);
            if (cur_page == 1) {
                $("#before_page").hide();
            }
            else {
                $("#before_page").show();
            }
            if (page_num <= 1) {
                $("#next_page").hide();
            }
            else {
                $("#next_page").show();
            }
            $("#before_page").click(function () {
                cur_page -= 1;
                $.ajax({
                    type: "POST",
                    url: "CCOM/notification/GetNewsByPage.ashx",
                    data: { "action": "getAllNewsList", "page": cur_page, "keyWord": "", "typeId": 0 },
                    success: function (data) {
                        if (data != null) {
                            $("#news_list").empty();
                            var result = eval(data);
                            for (var i = 0; i < result.length; i++) {
                                var time = "";
                                if (result[i].News_date != null) {
                                    time = result[i].News_date.substr(0, 8);
                                }
                                if (result[i].News_top == "True") {
                                    var li = "<li class=\"notice-li\">" + "<a href=\"" + result[i].News_URL + "\" target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\"  class=\"img_logo\"/>" + "<span style=\"color:red;\">[置顶] </span>" + result[i].News_title + "</a>" + "<span class=\"date\">" + time + "</span>" + "</li>";
                                    $("#news_list").append(li);
                                }
                                else {
                                    var li = "<li class=\"notice-li\">" + "<a href=\"" + result[i].News_URL + "\"  target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\"  class=\"img_logo\"/>" + result[i].News_title + "</a>" + "<span class=\"date\">" + time + "</span>" + "</li>";
                                    $("#news_list").append(li);
                                }
                            }
                        }
                        if (cur_page == 1) {

                            $("#before_page").hide();
                        }
                        else {
                            $("#before_page").show();

                        }
                        if (cur_page < page_num) {
                            $("#next_page").show();
                        }
                    },
                    error: function (data) {
                        alert("请求数据出错");
                    }
                });
            });
            if (cur_page == page_num) {
                $("#next_page").hide();
            }
            $("#next_page").click(function () {
                cur_page += 1;
                $.ajax({
                    type: "POST",
                    url: "CCOM/notification/GetNewsByPage.ashx",
                    data: { "action": "getAllNewsList", "page": cur_page, "keyWord": "", "typeId": 0 },
                    success: function (data) {
                        if (data != null) {
                            $("#news_list").empty();
                            var result = eval(data);
                            for (var i = 0; i < result.length; i++) {
                                var time = "";
                                if (result[i].News_date != null) {
                                    time = result[i].News_date.substr(0, 8);
                                }
                                if (result[i].News_top == "True") {
                                    var li = "<li class=\"notice-li\">" + "<a href=\"" + result[i].News_URL + "\"  target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\"  class=\"img_logo\"/>" + "<span style=\"color:red;\">[置顶] </span>" + result[i].News_title + "</a>" + "<span class=\"date\">" + time + "</span>" + "</li>";
                                    $("#news_list").append(li);
                                }
                                else {
                                    var li = "<li class=\"notice-li\">" + "<a href=\"" + result[i].News_URL + "\"  target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\"  class=\"img_logo\"/>" + result[i].News_title + "</a>" + "<span class=\"date\">" + time + "</span>" + "</li>";
                                    $("#news_list").append(li);
                                }
                            }
                        }
                        if (cur_page == page_num) {
                            $("#next_page").hide();
                        }
                        else {
                            $("#next_page").show();
                        }
                        if (cur_page > 1) {
                            $("#before_page").show();
                        }
                    },
                    error: function (data) {
                        alert("请求数据出错");
                    }
                });
            });
        });


    </script>
    <style type="text/css">
        .main-container {
            width: 100%;
            
        }

        .nav {
            width: 1280px;
            height: 80px;
            margin: 0 auto;
            padding-top: 5px;
        }

        .title-txt {
            padding-top: 180px;
            text-align:center;
        }

        .body-container {
            width: 1280px;
            height: 543px;
            margin: 0 auto;
            text-align: center;
        }

        .body-content {
            width: 1000px;
            height: 360px;
            margin: 0 auto;
        }

        .news-container {
            float: left;
            width: 550px;
            text-align: left;
            /*background:#bebebe;*/
            line-height: 28px;
            font-size: 12px;
            font-family: Arial, Helvetica, sans-serif;
           
            height: 100%;
            margin-top: 60px;
            border-radius: 15px;
        }

        .con {
            text-align: left;
            width: 550px;
            margin: 0px auto;
           
            filter: Alpha(opacity=80);
           
            border-radius: 4px 4px 4px 4px;
            padding-top: 5px;
            padding-bottom: 10px;
        }

        .login-info-container {
          
           margin:0px auto;
           margin-left:auto; 
           margin-right:auto;        
           width: 400px;
           height: 370px;
            /*border: 1px solid #CCC;*/
           border-radius: 15px;
        }

        .news-title {
            width: 100%;
            height: 300px;
        }

        .news-content {
            width: 100%;
            height: 300px;
        }

        .news-page {
            width: 100%;
            height: 20px;
        }

        .login-title {
            width: 100%;
            height: 50px;
            margin-bottom: 30px;
        }

        .input-txt-div {
      
            width: 100%;
            line-height: 90px;
            margin-top: -180px;
           
        }

        .remember-username {
            width: 100%;
            color: white;
            height: 50px;
            padding-top:20px;
            margin-top:8px;
        }

        .btn-container {
            width: 100%;
            height: 60px;
            margin: 0 auto;
            text-align: center;
        }

        .login-button1 {
            color: white;
            font-family: 隶书;
            font-size: 20px;
            display: block;
            width: 130px;
            line-height: 45px;
            text-align: center;
            letter-spacing: 2px;
            background: #2e75b6;
            /*background: #3dc1f3;*/
            color: white;
            border-radius: 10px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            text-decoration:none;
        }

            .login-button1:hover {
                color: white;
                background: #0a5898;
                text-decoration: none;
            }

        .notice-li {
            margin: 0 5px -12px 0;
            font-size: 14px;
            overflow: hidden;
            text-overflow: ellipsis;
            width: 100%;
            display: inline-block;
        }

            .notice-li a {
                max-width: 330px;
                text-overflow: ellipsis;
                float: left;
                margin-left: 10px;
                white-space: nowrap;
                display: block;
                overflow: hidden;
                color: black;
            }

        .date {
            width: 100px;
            float: right;
            text-overflow: ellipsis;
            white-space: nowrap;
            margin-right: 10px;
            display: block;
            overflow: hidden;
            color: black;
        }
        .img_logo
        {
            width:14px;
            height:14px;
            margin-top:2px;
            margin-right:2px;
            float:left;
        }
        .img_page
        {
            width:18px;
            height:18px;
            margin-top:-3px;
        }
    </style>
</head>
<body class="bottom">
    <div class="main-container">
        <div style="background-image: url(/images/login/test1.bmp); background-repeat: no-repeat; background-size: cover; width: 100%; height: 100%; min-width: 1280px; position: fixed; top: 0; bottom: 0; left: 0; right: 0; z-index: -1; filter: blur(3px);">
        </div>
       
            <div class="nav">
                <div class="logo" style="float: left; margin-left: 150px;">
                   
                </div>
                <div class="title-txt">
                    <span style="font-size: 70px; font-family: STZhongsong; color: white;  ">毕业设计管理系统</span>
                </div>
            </div>
        

        <div class="body-container">
            <div class="body-content">
                <div class="news-container">
                    <div class="con">
                        
                        <div class="news-content" style="visibility:hidden">

                            <ul style="overflow: hidden; text-overflow: ellipsis;" runat="server" id="news_list">
                               
                               
                            </ul>
                        </div>
                        <div class="news-page" style="visibility:hidden">
                            <div style="float: right; height: 100%; margin-right: 30px;" id="show_page" runat="server">
                                <span>
                                    <a style="margin-left: 5px; margin-right: 5px; font-size: 15px;" id="before_page">
                                        <label><img src="/images/news/before_page.png"  class="img_page"/>上一页</label></a>
                                    <a style="margin-left: 5px; margin-right: 5px; font-size: 15px;" id="next_page">
                                        <label>下一页<img src="/images/news/next_page.png" class="img_page"/></label></a>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="login-info-container">
                    <%--<div class="login-title">
                        <span style="float: left; margin-left: 30px; font-size: 20px; margin-top: 20px;">用户登录</span>
                    </div>--%>
                    <div class="login-body-concainer">                 
                        <form runat="server" id="form1" DefaultButton="btnSubmit">
                            <asp:HiddenField ID="showVCode" runat="server" Value="0" />
                            <asp:HiddenField ID="showLoginTab" runat="server" Value="0" />
                            <asp:HiddenField ID="hidselectedschool" runat="server" Value="0" />
                            <asp:HiddenField ID="page_num" runat="server" Value="0" />
                            <div class="input-txt-div">
                                <asp:TextBox ID="txtUserName" runat="server" placeholder="用户名" CssClass="txt-input" Style="width: 300px; height: 30px; margin-top: 450px; "></asp:TextBox>
                            </div>
                            <div class="input-txt-div">
                                <asp:TextBox ID="txtUserPwd" TextMode="Password" runat="server" CssClass="txt-input" Style="width: 300px; height: 30px; margin-top: -5px;" placeholder="密码"></asp:TextBox>
                            </div>
                            <div class="input-txt-div" style="line-height:120px;height:30px;display:none;" id="show_code" runat="server">
                                <asp:TextBox ID="txtCode" runat="server" CssClass="vcode-input" placeholder="验证码" Style="width: 150px; height: 30px; float: left; margin-left: 365px;margin-top: 19px;"></asp:TextBox>
                                <img src="/tools/verify_code.ashx" alt="点击切换验证码" title="点击切换验证码" class="vcode-img" onclick="ToggleCode(this, '/tools/verify_code.ashx');return false;" style="float: left; margin-left: 365px;height:40px;"/>
                            </div>
                            <div class="remember-username">
                                <asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户名" Checked="True" Style="float: left; margin-left: 42px; font-size: 15px;" />
                                <%--<asp:Label runat="server" Style="color: red; font-size: 13px;" ID="lblTip"></asp:Label>--%>
                                <a href="/AdminMetro/getpwd.aspx" style="float:right;margin-right:45px;color:#fff">忘记密码</a>
                            </div>
                            <div class="btn-container">
                              <%--  <div class="login-button" style="float: left; margin-left: 42px;">
                                    <a style="color: white; text-decoration: none;" href="CCOM/register/Register.aspx">注册</a>
                                </div>--%>
                                <div style="float: left; margin-left: 42px;">
                                    <asp:LinkButton ID="btnSubmit" CssClass="login-button1" OnClick="btnSubmit_Click" runat="server" style="text-decoration:none;" Width="315px">登录</asp:LinkButton>                                   
                                </div>                                 
                            </div>
                            <asp:Label runat="server" Style="color: red; font-size: 13px;" ID="lblTip"></asp:Label>
                        </form>                         
                    </div>
                </div>
            </div>
        </div>
 </div>
    

    <script type="text/javascript">
        var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
        document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F9a103a0d184ea7d73dccd3718e1b990d' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/admin/js/login-v3.js"></script>
    <script type="text/javascript" src="/scripts/layer/layer.min.js"></script>
    <script type="text/javascript" src="/metro/assets/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/admin/js/jquery.placeholder.js"></script>
    <script type="text/javascript">

        
    </script>
</body>
</html>
