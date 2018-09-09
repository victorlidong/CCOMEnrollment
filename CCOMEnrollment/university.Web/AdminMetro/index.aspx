<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="university.Web.AdminMetro.index" %>

<%@ Import Namespace="university.Common" %>

<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>北京理工大学计算机学院本科毕业设计管理系统</title>
    
    <%--<meta content="width=device-width, initial-scale=1.0" name="viewport" />--%>
 
    <meta content="" name="description" />
    <meta name="renderer" content="webkit" />
    <meta content="Mosaddek" name="author" />
    <link href="/metro/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/metro/assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="/metro/assets/bootstrap/css/bootstrap-fileupload.css" rel="stylesheet" />
    <link href="/metro/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/metro/css/style.css" rel="stylesheet" />
    <link href="/metro/css/ex-style.css" rel="stylesheet" />
    <link href="/metro/css/style-responsive.css" rel="stylesheet" />
    <link href="/metro/css/style-default.css" rel="stylesheet" id="style_color" />
    <link rel="stylesheet" href="/metro/js/artDialog-v6/css/ui-dialog.css" />
    <script type="text/javascript" src="/metro/js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        #divUserDpt
        {
            color: white;
            width: 500px;
            position: absolute;
            top: 20px;
            font-size: 28px;
            font-family: 隶书;
            z-index: 20;
        }

        .header-search
        {
            position: absolute;
            left: 400px;
            top: 10px;
        }

        #sidebar > ul > li > a, #sidebar > ul > li > a > span
        {
            height: 30px;
            line-height: 30px;
            font-size: 20px;
            font-family: 仿宋;
            display: inline-block;
            text-align:center;
        }
        
     
        .navbar-inner
        {
            border: 0;
            background-color: #333f50; /* fallback color, place your own */
            /* Gradients for modern browsers, replace as you see fit */
            background-image: -moz-linear-gradient(top, #333f50);
            background-image: -ms-linear-gradient(top, #333f50);
            background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#333f50), to(#333f50));
            background-image: -webkit-linear-gradient(top, #333f50);
            background-image: -o-linear-gradient(top, #333f50);
            background-image: linear-gradient(top, #333f50, );
            background-repeat: repeat-x;
            /* IE8-9 gradient filter */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#333f50', endColorstr='#333f50', GradientType=0);
        }

        /*.navbar .nav > li > a
        {
            border-right: 1px solid #434343;
            border-width: thin;
            color: #a0a0a0;
            padding-right: 15px;
            padding-left: 15px;
        }*/

        #userName, #userCurrentUser
        {
            color: #fff;
        }

        /*.navbar .nav > li > a:hover
        {
            border-right: 1px solid #434343;
            border-width: thin;
            color: #999;
        }*/

        #rightbar > ul > li a, #rightbar > ul > li > a > span
        {
            height: 34px;
            line-height: 34px;

        }

        .navbar .nav > .active > a, .navbar .nav > .active > a:hover, .navbar .nav > .active > a:focus
        {
            background-color: #4a8bc2;
            color: #fff;
        }

        .navbar .nav
        {
            margin-right: 0px;
        }

        .navbar-inner
        {
            padding-left: 0px;
            padding-right: 0px;
        }

        li .label
        {
            margin: 0 10px 5px 0;
        }

        ul.dropdown-menu li .affix
        {
            top: 80px;

        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#hide_sidebar").click(function () {
                var display = $('.sidebar-scroll').css('display');
                if (display == "none") {
                    $('.sidebar-scroll').css("display", "block");
                }
                else {
                    $('.sidebar-scroll').css("display", "none");
                }
                //console.log($('.sidebar-scroll').css('display'));
            });
        });

        function hideStuatus() {
            $(".dropdown").removeClass("open");
        }

        function ChangeStatus(value) {
            $("#DropDownListUS").val(value);
            setTimeout('__doPostBack(\'DropDownListUS\',\'\')', 0);
        }
        function SetTopContent(id) {
            var jsondata = JSON.parse($("#hidLevel2FunctionTree").val());
            var showfunjson = "";
            $.each(jsondata, function (n, data) {
                if (data["id"] == id && data["type"] == "S") {
                    showfunjson = data;
                }
                if (data["functions"] != undefined) {
                    $.each(data["functions"], function (i_n, i_data) {
                        if (i_data["id"] == id) {
                            showfunjson = data;
                        }
                    });
                }
            });
            var level3html = "";
            if (showfunjson["functions"] != undefined) {
                level3html = "<div class=\"navbar-inner\"><ul role=\"navigation\" class=\"nav\">";
                level3html += "<li style=\"cursor:pointer;\"><a onclick=\"TopMenuCollapse(1);\" style=\"padding-left:8px;padding-right:8px;\"><i class=\"icon-chevron-sign-right\"></i>收起</a></li>";
                $.each(showfunjson["functions"], function (n, data) {
                    level3html += "<li data-id=\"" + data["id"] + "\">";
                    level3html += "<a class=\"\" href=\"" + data["address"] + "\" target=\"sysMain\" onclick=\"ClickTopContent('" + data["id"] + "')\">";
                    level3html += data["name"];
                    level3html += "</a>";
                    level3html += "</li>";
                });
            }
            level3html += "</ul></div>";
            var navobj = $("#navbar_top");
            var toslidedown = true;
            if (navobj.html() != "") toslidedown = false;
            navobj.html(level3html);
            ClickTopContent(id);
            $("#sidebar li").not(".sub-menu").removeClass("active");
            $("#sidebar li").not(".sub-menu").each(function () {
                if ($(this).attr("data-id") == showfunjson["id"]) {
                    $(this).addClass("active");
                    if (!$(this).parents(".sub-menu").hasClass("open"))
                        $(this).parent().prev().click();
                }
            });
            //console.log(id, showfunjson);
            //$("#sidebar li:contains('" + showfunjson["id"] + "')").addClass("active");
            //_html = (decodeURIComponent(_html));
            //_html = _html.replace(/\+/g, " ");
            if (level3html == "") {
                navobj.hide();
            }
            else {
                navobj.hide();
                if (toslidedown)
                    navobj.slideDown("slow");
                else
                    navobj.show();
                //$("iframe#sysMain").height($("#container").height() - navobj.height() - 60);
                //console.log($("iframe#sysMain").height());
                TopMenuCollapse(0);
            }
        }

        function ClickTopContent(id) {
            $("#navbar_top li").removeClass("active");
            $("#navbar_top li").each(function () {
                //console.log($(this).attr("data-id"), id, $(this).attr("data-id") == id);
                if ($(this).attr("data-id") == id) {
                    $(this).addClass("active");
                }
            });
        }

        function TopMenuCollapse(ToChange) {
            if (ToChange == 1) //改变状态
                TopIsCollapse = 1 - TopIsCollapse;
            if (TopIsCollapse == 0) { //收起状态
                $("#navbar_top li:gt(0)").hide();
                $("#navbar_top a:eq(0)").html("<i class=\"icon-chevron-sign-left\"></i>展开");
                if ($("#navbar_top").width() > 60) {
                    $("#navbar_top").css("position", "fixed");
                    $("#navbar_top").css("width", $("#sysMain").width() + "px");
                    $("#navbar_top").css("right", 0);
                    $("#navbar_top").animate({ width: "60px" }, 800);
                }
            } else {//展开
                $("#navbar_top a:eq(0)").html("<i class=\"icon-chevron-sign-right\"></i>收起");
                $("#navbar_top li:gt(0)").show();
                $("#navbar_top").css("position", "relative");
                if ($("#navbar_top").width() <= 60) {
                    $("#navbar_top").css("width", "100%");
                    $("#navbar_top").hide();
                    $("#navbar_top").slideDown("slow");
                }
            }
        }

        var RightIsCollapse = 0, TopIsCollapse = 1;
        function RightMenuCollapse(ToChange) {
            if (ToChange == 1)
                RightIsCollapse = 1 - RightIsCollapse;
            if (RightIsCollapse == 0) {  //折叠
                if (ToChange == 0)
                    $("#rightbar .sub-menu:gt(0)").fadeOut("1000");
                else
                    $("#rightbar .sub-menu:gt(0)").hide();
                $("#right-content").animate({ width: '50px' });
                RightIsCollapse = 1;
            } else {
                $("#right-content").animate({ width: '150px' });
                $("#rightbar .sub-menu:gt(0)").fadeIn("2000");
                RightIsCollapse = 0;
            }
        }

        function BaseFunction(type) {
            /*
            var id = "";

            SetTopContent(id);
            */
        }

    </script>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="fixed-top" onresize="resizeContainer()" style="height: 100%; overflow: hidden;">
    <div id='myFlag'></div>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidLevel2FunctionTree" />
        <!-- BEGIN HEADER -->
        <div id="header" class="navbar navbar-inverse navbar-fixed-top">
            <!-- BEGIN TOP NAVIGATION BAR -->
            <div class="navbar-inner">
                <div class="container-fluid" style="padding-bottom: 0;height:60px;">
                   
            
                    <!--BEGIN SIDEBAR TOGGLE-->
                   
                    <!--END SIDEBAR TOGGLE-->
                    <!-- BEGIN LOGO -->
                    <a class="brand" href="/adminmetro/CCOM/center.aspx" target="sysMain" data-placement="right"  style="padding-left:5px;width:60px;height:40px;">
                        <img src="/images/login/lg1.png" alt="计算机学院毕业设计管理系统" style="width:48px;height:50px;margin-top:-5px;font-family:隶书;"/> 
                        
                    </a>
                    <!-- END LOGO -->
                    <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                    <a class="btn btn-navbar collapsed" id="main_menu_trigger" data-toggle="collapse" data-target=".nav-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="arrow"></span>
                    </a>
                    <!-- END RESPONSIVE MENU TOGGLER -->

                    <div id="top_menu" class="nav notify-row">

                        <!-- BEGIN NOTIFICATION -->
                        <!--user dept-->
                        <div runat="server" id="divUserDpt">欢迎您</div>


                    </div>



                     



                        
                        <div class="header-search" style="display: none;">
                            <div class="input-append search-input-area">
                                <input class="" id="appendedInputButton" type="text" style="height: 35px; margin-top: 1px; border-left: 10px solid #fff !important">
                                <button class="btn" type="button"><i class="icon-search"></i></button>
                            </div>
                        </div>
                        <!-- END  NOTIFICATION -->
                    

              
                      

                    <div class="top-nav">
                        

                        <ul class="nav pull-right top-menu">
                            <!-- BEGIN USER LOGIN DROPDOWN -->
                            <li id="itemStatus" class="dropdown">
                                <a href="#" id="lnkStatus" class="dropdown-toggle" data-toggle="dropdown" style="border: none;">
                                    <%--<img id="userImg" class="img-circle" src="/admin/images/default_user_avatar.gif" alt="头像" style="width: 29px;" runat="server" />--%>
                                    <span id="userName" runat="server">姓名</span>
                                    <span id="uoName" runat="server">计算机学院</span>
                                    <b class="caret"></b>
                                </a>
                                <ul id="status_list" class="dropdown-menu logout">
                                    <%--<li class="nav-header" style="height: 30px; padding-top: 10px; color: #08c; font-size: 15px;"><i class="icon-hand-down"></i>身份切换：</li>
                                    <asp:Literal runat="server" ID="ltrUserDept"></asp:Literal>--%>
                                    <%--  <li>
                                        <a href="#">计算机学院管理员</a>
                                    </li>
                                    <li>
                                        <a href="#">学院教师</a>
                                    </li>--%>
                                    <%--<li class="divider"></li>--%>
                                    <li>
                                        <a href="/AdminMetro/CCOM/update_info/update_info.aspx" target="sysMain"><i class="icon-user"></i>个人信息</a>
                                    </li>
                                    <li>
                                        <a href="/Adminmetro/CCOM/update_info/ChangePWD.aspx" target="sysMain"><i class="icon-cog"></i>修改密码</a>
                                    </li>
                                    <li>
                                        <a href="javascript:__doPostBack('lbtnExit','')"><i class="icon-key"></i>退出登录</a>
                                    </li>
                                </ul>
                            </li>
                            <!-- END USER LOGIN DROPDOWN -->
                        </ul>

                        <%--<div id="top_menu" class="nav pull-right notify-row">
                            <ul class="nav top-menu">

                                <!-- BEGIN NOTIFICATION DROPDOWN -->
                                <li class="dropdown" id="header_notification_bar">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">

                                        <i class="icon-bell"></i>
                                        <span class="badge badge-warning">7</span>
                                    </a>
                                    <ul class="dropdown-menu extended notification">
                                        <li>
                                            <p>你有7条提示信息</p>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="label label-important"><i class="icon-bolt"></i></span>
                                                Server #3 overloaded.
                                       <span class="small italic">34 mins</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="label label-warning"><i class="icon-bell"></i></span>
                                                Server #10 not respoding.
                                       <span class="small italic">1 Hours</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="label label-important"><i class="icon-bolt"></i></span>
                                                Database overloaded 24%.
                                       <span class="small italic">4 hrs</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="label label-success"><i class="icon-plus"></i></span>
                                                New user registered.
                                       <span class="small italic">Just now</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="label label-info"><i class="icon-bullhorn"></i></span>
                                                Application error.
                                       <span class="small italic">10 mins</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">See all notifications</a>
                                        </li>
                                    </ul>
                                </li>
                                <!-- END NOTIFICATION DROPDOWN -->


                                <!-- BEGIN INBOX DROPDOWN -->
                                <li class="dropdown" id="header_inbox_bar">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="icon-comments-alt"></i>
                                        <span class="badge badge-important">5</span>
                                    </a>
                                    <ul class="dropdown-menu extended inbox">
                                        <li>
                                            <p>你有5条消息</p>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="./img/avatar-mini.png" alt="avatar"></span>
                                                <span class="subject">
                                                    <span class="from">Jonathan Smith</span>
                                                    <span class="time">Just now</span>
                                                </span>
                                                <span class="message">Hello, 这是个消息列子.
                                                </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="./img/avatar-mini.png" alt="avatar"></span>
                                                <span class="subject">
                                                    <span class="from">Jhon Doe</span>
                                                    <span class="time">10 mins</span>
                                                </span>
                                                <span class="message">Hi, 最近咋样?
                                                </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="./img/avatar-mini.png" alt="avatar"></span>
                                                <span class="subject">
                                                    <span class="from">Jason Stathum</span>
                                                    <span class="time">3 hrs</span>
                                                </span>
                                                <span class="message">This is awesome dashboard.
                                                </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <span class="photo">
                                                    <img src="./img/avatar-mini.png" alt="avatar"></span>
                                                <span class="subject">
                                                    <span class="from">Jondi Rose</span>
                                                    <span class="time">Just now</span>
                                                </span>
                                                <span class="message">Hello, this is metrolab
                                                </span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">See all messages</a>
                                        </li>
                                    </ul>
                                </li>
                                <!-- END INBOX DROPDOWN -->

                                <!-- BEGIN SETTINGS -->
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="icon-tasks"></i>
                                        <span class="badge badge-important">6</span>
                                    </a>
                                    <ul class="dropdown-menu extended tasks-bar">
                                        <li>
                                            <p>你有6条任务</p>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="task-info">
                                                    <div class="desc">控制台</div>
                                                    <div class="percent">44%</div>
                                                </div>
                                                <div class="progress progress-striped active no-margin-bot">
                                                    <div class="bar" style="width: 44%;"></div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="task-info">
                                                    <div class="desc">数据库更新</div>
                                                    <div class="percent">65%</div>
                                                </div>
                                                <div class="progress progress-striped progress-success active no-margin-bot">
                                                    <div class="bar" style="width: 65%;"></div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="task-info">
                                                    <div class="desc">手机开发进度</div>
                                                    <div class="percent">87%</div>
                                                </div>
                                                <div class="progress progress-striped progress-info active no-margin-bot">
                                                    <div class="bar" style="width: 87%;"></div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="task-info">
                                                    <div class="desc">手机App进度</div>
                                                    <div class="percent">33%</div>
                                                </div>
                                                <div class="progress progress-striped progress-warning active no-margin-bot">
                                                    <div class="bar" style="width: 33%;"></div>
                                                </div>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <div class="task-info">
                                                    <div class="desc">控制台</div>
                                                    <div class="percent">90%</div>
                                                </div>
                                                <div class="progress progress-striped progress-danger active no-margin-bot">
                                                    <div class="bar" style="width: 90%;"></div>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="external">
                                            <a href="#">查看所有任务</a>
                                        </li>
                                    </ul>
                                </li>
                                <!-- END SETTINGS -->

                            </ul>
                        </div>--%>
                        <!-- END TOP NAVIGATION MENU -->
                    </div>

                    <%--
                    <div id="top_notifcation" class="nav notify-row pull-right">
                        <!-- BEGIN NOTIFICATION -->
                        <ul class="nav top-menu">
                            <!-- BEGIN NOTIFICATION DROPDOWN -->
                            <li id="itemPush" class="dropdown">
                                <a href="#" id="lnkPush" class="dropdown-toggle" data-toggle="dropdown" style="border: none;">
                                    <i class="icon-bell-alt" style="font-size: 25px; color: #fff;"></i>
                                    <span id="pushCount" class="badge badge-important" style="top: 2px; right: 6px;" runat="server"></span>
                                    <asp:HiddenField ID="hidPushIdList" runat="server" />
                                </a>
                                <ul id="pushList" class="dropdown-menu extended notification" runat="server" style="overflow-y: scroll;">
                                    <li>
                                        <p>你有7条提示信息</p>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">
                                            <span class="label label-important"><i class="icon-bolt"></i></span>
                                            Server #3 overloaded.
                                            <span class="small italic">34 mins</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">
                                            <span class="label label-warning"><i class="icon-bell"></i></span>
                                            Server #10 not respoding.
                                            <span class="small italic">1 Hours</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">
                                            <span class="label label-important"><i class="icon-bolt"></i></span>
                                            Database overloaded 24%.
                                            <span class="small italic">4 hrs</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">
                                            <span class="label label-success"><i class="icon-plus"></i></span>
                                            New user registered.
                                            <span class="small italic">Just now</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">
                                            <span class="label label-info"><i class="icon-bullhorn"></i></span>
                                            Application error.
                                            <span class="small italic">10 mins</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">See all notifications</a>
                                    </li>
                                </ul>
                            </li>
                            <!-- END PUSH NOTIFICATION DROPDOWN -->

                        </ul>
                        <!-- END  NOTIFICATION -->
                    </div>--%>
                </div>
            </div>
            <!-- END TOP NAVIGATION BAR -->
        </div>
        <!-- END HEADER -->

        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="position: fixed; top: 60px; margin-top: 0;">
            <!-- BEGIN SIDEBAR -->
            <div class="sidebar-scroll">
                <div id="sidebar" class="nav-collapse collapse">

                    <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
                    <div class="navbar-inverse">
                    </div>
                    <!-- END RESPONSIVE QUICK SEARCH FORM -->
                    <!-- BEGIN SIDEBAR MENU -->
                    <ul class="sidebar-menu" id="sidebar_menu" runat="server">
                    </ul>
                    <!-- END SIDEBAR MENU -->
                </div>
            </div>
            <!-- END SIDEBAR -->

            <!-- BEGIN PAGE -->
            <div id="frameContainer">
                <div id="main-content" style="height: 100%; min-height: 0px;">
                    <!-- BEGIN THIRD NAVIGATION HENGBAN-->
                    <div class="navbar" id="navbar_top" style="display: block; margin-bottom: 0px; width: 100%;">
                        <%--                        <div class="navbar-inner">
                            <div style="width: auto;" class="container">
                                <ul role="navigation" class="nav ">
                                    <li>
                                        <a href="#">学生数据检索</a>
                                    </li>
                                    <li class="active">
                                        <a href="#">学生数据检索</a>
                                    </li>
                                    <li>
                                        <a href="#">学生数据检索</a>
                                    </li>
                                    <li>
                                        <a href="#">学生数据检索</a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <!-- END THIRD NAVIGATION HENGBAN-->
                    <div style="height:100%;-webkit-overflow-scrolling:touch;overflow:auto;">
                        <iframe frameborder="0" width="100%" height="100%" name="sysMain" id="sysMain" src="CCOM/center.aspx"></iframe>
                    </div>

                </div>
            </div>

            <!-- END PAGE -->
        </div>
        <!-- END CONTAINER -->
        <div style="display: none;">
            <asp:LinkButton runat="server" ID="lbtnExit" OnClick="lbtnExit_Click"></asp:LinkButton>
        </div>

        <!-- BEGIN JAVASCRIPTS -->
        <!-- Load javascripts at bottom, this will reduce page load time -->
        
        <script type="text/javascript" src="/metro/js/json2.js"></script>
        <script src="/metro/js/jquery.nicescroll.js" type="text/javascript"></script>
        <script type="text/javascript" src="/metro/assets/jquery-slimscroll/jquery-ui-1.9.2.custom.min.js"></script>
        <script type="text/javascript" src="/metro/assets/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script type="text/javascript" src="/metro/assets/fullcalendar/fullcalendar/fullcalendar.min.js"></script>
        <script type="text/javascript" src="/metro/assets/bootstrap/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="/metro/js/artDialog-v6/dist/dialog-min.js"></script>
        <script type="text/javascript" src="/metro/js/jquery.scrollTo.min.js"></script>
        <!--common script for all pages-->
        <script type="text/javascript" src="/metro/js/common-scripts.js"></script>
        <script type="text/javascript" src="/metro/js/ex-common-scripts.js"></script>

        <!--jquery plugin for the dropdown asset in bootstrap-->
        <script type="text/javascript" src="/metro/js/dropdown-hover.js"></script>

        <script type="text/javascript">
            /*
            $(function () {
                resizeContainer();
            });

            function resizeContainer() {
                var height = document.body.clientHeight;
                var headerHeight = 60;
                //var footerHeight = $("#footer").height();   /*孙晨光*/
            //     var footerHeight = 0;   /*孙晨光*/
            //     $("body").height($("#container").height());
            //     $("#container").height(height - headerHeight - footerHeight);

            //设置通知提醒下拉框最大高度
            //adaptPushHeight();
            //}

            /*
            //提示Dialog并关闭Tab
            function f_errorTab(tit, msg) {
                var d = dialog({
                    title: tit,
                    content: msg,
                    okValue: '确定',
                    cancelValue: '返回',
                    ok: function () {
                        frames[0].location.href = 'center.aspx';
                    },
                    cancel: function () {
                        frames[0].location.href = 'center.aspx';
                    }
                });
                d.showModal();
            }

            $("body").bind("keydown", function (event) {
                if (event.keyCode == 116) {
                    var iframeName = "sysMain";
                    if (typeof (iframeName) != 'undefined') {
                        frames[iframeName].window.location.reload();
                        return false;
                    }
                }
            })
            */
            /*
            //更新通知的阅读状态,all:1为更新所有，0为更新所选
            function updatePushReadStatus(all) {
                var idList = pushIdArray.toString();
                if (all == 1) {
                    idList = "-1";
                }
                //console.log(idList);
                var submitUrl = "/AdminMetro/NewsPush/AjaxPushHandler.ashx?action=updatePushReadStatus&idList=" + idList;

                //开始提交
                $.ajax({
                    url: submitUrl,
                    success: function (data) {
                        try {
                            var resultJson = eval("(" + data + ")");
                            //console.log(data);
                            if (resultJson.ErrCode == 200) {
                                //更新完阅读状态后，将保存的通知id列表清空
                                pushIdArray = [];
                            }
                        } catch (e) {
                        }
                    },
                    error: function (data, status, e) {
                    },
                    cache: false
                });
            }

            //将所有通知全部标为已读
            function updateAllPushReadStatus() {
                //调用接口将所有通知阅读状态改为已读
                updatePushReadStatus(1);

                //重新加载通知列表
                reloadUnreadPushList();

                return false;
            }

            //ul内容的高度
            var ul_height = 0;

            //加载未读通知列表
            function loadUnreadPushList(id) {
                var submitUrl = "/AdminMetro/NewsPush/AjaxPushHandler.ashx?action=getUnreadPushList&id=" + id;

                //开始提交
                $.ajax({
                    url: submitUrl,
                    success: function (data) {
                        try {
                            var resultJson = eval("(" + data + ")");
                            if (resultJson.Result == 200) {
                                //如果id等于0，表示重新加载，更新显示的通知数
                                if (id == 0) {
                                    if (resultJson.Count == 0) {
                                        $("#pushCount").text("");
                                    } else if (resultJson.Count > 0) {
                                        $("#pushCount").text(resultJson.Count);

                                        //加上“全部标为已读”按钮
                                        var btnAllRead = "<input type=\"button\" style=\"background-color: #eee !important; color: #DE577B; ";
                                        btnAllRead += "font-size: 13px; font-weight: bold; border: 0px; float:right; margin-top: -31px;\" ";
                                        btnAllRead += "value=\"全部标为已读\" onclick=\"updateAllPushReadStatus()\"/>";
                                        $(btnAllRead).appendTo("#pushList li:eq(0)");
                                    }

                                    if (resultJson.Count > 9) {
                                        $("#pushCount").css("right", "0px");
                                    } else {
                                        $("#pushCount").css("right", "6px");
                                    }
                                }

                                //加载获取的通知列表
                                $("#pushList").append(resultJson.Msg);

                                //设置第一条通知的样式
                                $("#pushList li:eq(1)").css("margin-top", "40px");

                                //更新ul内容的高度
                                ul_height = $("#pushList li:eq(-1)")[0].getBoundingClientRect().bottom;
                            }
                        } catch (e) {
                        }
                    },
                    error: function (data, status, e) {
                    },
                    cache: false
                });
            }

            //重新加载未读通知列表
            function reloadUnreadPushList() {
                var firstLi = "<li style=\"position: fixed; width: 315px;\">";
                firstLi += "<a href=\"/AdminMetro/CenterPage/notice_list.aspx\" style=\"color: #08c; font-size: 16px; font-weight: bold; ";
                firstLi += "background-color: #eee !important;\" target=\"sysMain\">查看历史通知</a>";
                firstLi += "</li>";
                $("#pushList").html(firstLi);

                //加载未读通知列表
                loadUnreadPushList(0);
            }

            //遍历通知列表，出现1秒后的通知需更新阅读状态
            function checkStatusTimeout() {
                if (timeout) {
                    clearTimeout(timeout);
                }

                //延迟执行，停留一秒后才能更新阅读状态
                timeout = setTimeout(function () {
                    var b_top = $("#pushList li:eq(0)")[0].getBoundingClientRect().bottom;
                    var b_bottom = $("#pushList")[0].getBoundingClientRect().bottom;

                    $("#pushList li").each(function () {
                        if (typeof $(this).attr("id") !== 'undefined' && b_top > 0 && b_bottom > b_top &&
                            this.getBoundingClientRect().top > b_top - 10 && this.getBoundingClientRect().bottom < b_bottom + 10) {
                            if (($(this).children("a").css("color").toLowerCase() != "rgb(192, 192, 192)" && $(this).children("a").css("color").toLowerCase() != "#c0c0c0") &&
                                $.inArray($(this).attr("id"), pushIdArray) < 0) {
                                //将需要更新状态的通知id加入到数组中，改变显示的颜色，并将未读通知数减一
                                pushIdArray.push($(this).attr("id"));
                                
                                $(this).children("a").css("cssText", "background-color: #f3f3f3 !important; color: #C0C0C0;");

                                var remainCount = $("#pushCount").text() - 1;
                                $("#pushCount").text(remainCount > 0 ? remainCount : "");
                            }
                        }
                    });
                }, 1000);
            }

            //首次进入时，加载通知列表
            $(function () {
                reloadUnreadPushList();
            });

            //通知列表隐藏时更新通知状态
            $("#lnkPush").bind("hover click", function () {
                //选出需要更新状态的通知
                checkStatusTimeout();

                //调用接口更新通知状态
                updatePushReadStatus(0);

                //重新加载通知列表
                reloadUnreadPushList();
            });

            var pushIdArray = new Array();
            var timeout = false;
            $("#pushList").bind("scroll", function () {
                //选出需要更新状态的通知
                checkStatusTimeout();

                //reload
                if (ul_height != 0 && (this.scrollTop + this.clientHeight) / ul_height > 0.9) {
                    var id = $("#pushList li:eq(-1)").attr("id");
                    loadUnreadPushList(id);
                }
            });

            //设置通知提醒下拉框最大高度
            function adaptPushHeight() {
                var height = 0;
                if (typeof (window.innerHeight) == 'number') {
                    height = window.innerHeight;
                } else if (document.documentElement && (document.documentElement.clientHeight)) {
                    height = document.documentElement.clientHeight;
                } else if (document.body && (document.body.clientHeight)) {
                    height = document.body.clientHeight;
                }

                if ($("ul.nav.pull-right.top-menu").width() < 250) {
                    $("#top_notifcation").css({ "position": "absolute", "left": "auto", "right": "280px" });
                }
                $("#pushList").css("cssText", "max-width:330px !important; width:330px !important; overflow-y: scroll; max-height:" + (height - 100));
            }
            */
        </script>
    </form>
    <!-- END JAVASCRIPTS -->
    <!--
    <script type="text/javascript">
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?9a103a0d184ea7d73dccd3718e1b990d";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>-->
</body>
<!-- END BODY -->
</html>
