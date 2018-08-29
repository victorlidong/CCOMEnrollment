<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.center" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>北京理工大学软件学院本科毕业设计系统</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="Mosaddek" name="author" />
    <link href="/metro/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/metro/assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="/metro/assets/bootstrap/css/bootstrap-fileupload.css" rel="stylesheet" />
    <link href="/metro/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/metro/css/style.css" rel="stylesheet" />
    <link href="/metro/css/ex-style.css" rel="stylesheet" />
    <link href="/metro/css/style-responsive.css" rel="stylesheet" />
    <link href="/metro/css/style-default.css" rel="stylesheet" id="style_color" />
    <link href="/metro/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css" rel="stylesheet" />
    <script src="/metro/js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        .row-fluid .page-title {
            font-size:20px;
            font-weight:bold;
            font-weight:bold !important;
            margin:0;
            color:#888;
        }
        .metro-nav .metro-nav-block {
            width:100px;
            height:100px;
        }
        .metro-fix-view .metro-nav-block {
            width:100px !important;
            margin:0 10px 10px 0;
        }
        .metro-fix-view .metro-nav-block.double {
            width:210px;
            width:210px !important;
        }
        #newsList li {
            line-height:15px;
        }
        .widget-body {
            padding:10px 10px;
        }
        .scroller {
            padding-right:0;
        }
        #main-content {
            min-height:0;
        }
        .metro-nav {
            margin-top:10px;
        }
        /*#notice_list li .label {
            padding:12px !important;
        }*/
        .notice_circle {
            position:absolute;right:-6px;top:-6px;z-index:10000;/*border:2px solid #fff;*/
        }
          span.tools a.default{
            color: #FFF; 
            font-size: 14px;
            cursor:pointer;
              padding: 1px;
        }
        span.tools a.selected {
            background-color: #EEE;
			color: #666;
			padding: 1px 5px;
			border-radius: 2px !important;
			-webkit-border-radius: 2px !important;
        }
      #notice_list li
      {
          line-height:15px;
      }
        
    </style>
</head>
<!-- END HEAD -->

<body style="background:#FFF;">
    <form id="form1" runat="server">
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid" style="padding-bottom: 20px;">
                    <!-- BEGIN PAGE CONTENT-->
                     <div class="row-fluid" align="center">
                         您好，欢迎使用软件学院毕业设计管理系统！
                     </div>
                    <div class="row-fluid" style="display:none;">
                        <!--BEGIN METRO STATES-->
                            <div class="metro-nav metro-fix-view" id="div_affairs" runat="server">
                                <div class="metro-nav-block nav-light-purple">
                                    <a data-original-title="" href="javascript:parent.f_errorTab('haha','content');">
                                        <i class="icon-shopping-cart"></i>

                                        <div class="status">奖学金</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-block-blue">
                                    <a href="#" data-original-title="">
                                        <i class="icon-tasks"></i>

                                        <div class="status">请假</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-light-brown double">
                                    <a data-original-title="" href="#">
                                        <i class="icon-remove-sign"></i>

                                        <div class="status">开证明</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-block-grey ">
                                    <a data-original-title="" href="#">
                                        <i class="icon-external-link"></i>
                                        <div class="status">数据申报</div>
                                    </a>
                                </div>
                      
                                <div class="metro-nav-block nav-block-orange">
                                    <a data-original-title="" target="_self" href="/AdminMetro/NewsCampus/OfficeChannelAdmin.aspx?fun_id=80E0E1FCE17E6EE7">
                                        <i class="icon-user"></i>
                                        <div class="info">2</div>
                                        <div class="status">资讯类别</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-olive">
                                    <a data-original-title="" target="_self" href="/AdminMetro/NewsCampus/NewsList.aspx?fun_id=B9D1DD47A2998A63">
                                        <i class="icon-tags"></i>
                                        <div class="info">1</div>
                                        <div class="status">管理资讯</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-block-purple">
                                    <a data-original-title="" target="_self" href="/AdminMetro/NewsCampus/EditNews.aspx?fun_id=EBD37274A4AC45C9">
                                        <i class="icon-addnews"></i>
                                        <div class="info">1</div>
                                        <div class="status">发资讯</div>
                                    </a>
                                </div>

                                <div class="metro-nav-block nav-block-orange" style="width: 30%;">
                                    <a data-original-title="" href="#">
                                        <i class="icon-user"></i>

                                        <div class="status">校园生活</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-olive" style="width: 30%;">
                                    <a data-original-title="" href="#">
                                        <i class="icon-tags"></i>

                                        <div class="status">校园资讯</div>
                                    </a>
                                </div>
                                <div class="metro-nav-block nav-block-yellow" style="width: 30%;">
                                    <a data-original-title="" href="#">
                                        <i class="icon-comments-alt"></i>
                                        <div class="info">5</div>
                                        <div class="status">参加投票</div>
                                    </a>
                                </div>
                                
                            </div>
                        <div class="space10"></div>
                        <!--END METRO STATES-->
                    </div>
                  
                    <div class="row-fluid" style="margin-top: 20px;padding-bottom: 220px;">
                        <div class="span6"  style="display:none">
                            <div class="widget blue" >
                                <div class="widget-title" style="overflow: auto;">
                                    <h4><i class="icon-bell"></i>资讯</h4>
                                    <span class="tools" runat="server" id="divNewsType">
                                       
 <%--                                       <a class="default selected" onclick="toggleSelectedCss(this);newsFetch('#newsList', 0, 1, 0);" >最新</a>
                                        <a class="default"onclick="toggleSelectedCss(this);newsFetch('#newsList', 1, 1, 0);" >办公通知</a>
                                        <a class="default" onclick="toggleSelectedCss(this);newsFetch('#newsList', 2, 1, 0);">校园资讯</a>--%>
                      
                                        <a href="/AdminMetro/CCOM/notification/News.aspx?fun_id=<%=get_fun_id("CCOM/notification/News.aspx") %>" onclick="parent.BaseFunction('news');" style="color: #FFF; font-size: 14px; margin-right: 6px;">更多</a>
                                    </span>
                                </div>
                                <div class="widget-body" >
                                    <div id="newsListLoadLayer" class="load_layer pull-left"><img src='/scripts/artDialog4.1.7/skins/icons/wait.gif' alt='Loading'/>正在加载...</div>
                                    <ul id="newsList" style="height:504px;" class="item-list scroller padding" data-always-visible="1">
                                       <%-- <li>
                                            <div class="media">
                                                <span class="label pull-left news-bg">
                                                    <img class="img-circle" src="/admin/images/water.jpg" alt="资讯" style="width: 50px;" />
                                                </span>
                                                <div class="media-body">
                                                    <p class="text news-title">
                                                        <a href="#">资讯标题</a>
                                                    </p>
                                                    <span>日常事务 2014年7月</span>
                                                </div>
                                            </div>
                                        </li>--%>
                                    </ul>
                                    <div class="space10"></div>
                                    <a href="/AdminMetro/CCOM/notification/News.aspx?fun_id=<%=get_fun_id("CCOM/notification/News.aspx") %>" class="pull-right">查看所有资讯>></a>
                                    <div class="clearfix no-top-space no-bottom-space"></div>
                                </div>
                            </div>
                        </div>
                        <div class="span6"  style="display:none">
                            <div class="widget red">
                                <div class="widget-title">
                                    <h4><i class="icon-comments-alt"></i>我的通知</h4>
                                    <span class="tools">
                                        <a href="/AdminMetro/CCOM/notice/Notice_list.aspx?fun_id=<%=get_fun_id("CCOM/notice/Notice_list.aspx") %>" onclick="parent.BaseFunction('notice');"  style="color:#FFF;font-size:14px;margin-right:6px;">更多</a>
                                    </span>
                                </div>
                                <div class="widget-body">
                                    <div id="noticeListLoadLayer" class="load_layer pull-left"><img src='/scripts/artDialog4.1.7/skins/icons/wait.gif' alt='Loading'/>正在加载...</div>
                                    <ul id="notice_list" class="item-list scroller padding" style="overflow: hidden; width: auto; height: 320px;" data-always-visible="1">
                                        <%--<li>
                                            <div class="media">
                                                <span class="label pull-left label-success"><i class="icon-bell"></i></span>
                                                <div class="media-body">
                                                     <div class="notice-toggle notice_title"  style="display: block; "> 
                                                        <span>温馨提示：明天气温下降，注意穿衣保暖</span>
                                                        <span class="pull-right small italic ">Just now</span>
                                                    </div>
                                                    <div class="notice-collapse" style="display: block; padding: 5px;">
                                                        <p class="notice-close pull-right"><i class="icon-double-angle-up"></i>收起</p>
                                                        <div class="text msg-in">
                                                            <p>温馨提示：明天气温下降，注意穿衣保暖</p>
                                                            <p class="attribution"><a href="#">系统管理员：</a> at 1:55pm, 13th April 2013</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>--%>
                                    </ul>
                                     <div class="space10"></div>
                                    <a href="/AdminMetro/CCOM/notice/Notice_list.aspx?fun_id=<%=get_fun_id("CCOM/notice/Notice_list.aspx") %>" class="pull-right">查看所有通知>></a>
                                    <div class="clearfix no-top-space no-bottom-space"></div>
                                </div>
                            </div>
                        </div>
                        <%--
                        <div class="span6">
                            <div class="widget red">
                                <div class="widget-title">
                                    <h4><i class="icon-comments-alt"></i>校园活动</h4>
                                    <span class="tools">
                                        <a href="<%=this.aaurl%>" onclick="parent.BaseFunction('activity');"  style="color:#FFF;font-size:14px;margin-right:6px;">更多</a>
                                    </span>
                                </div>
                                <div class="widget-body">
                                    <ul id="activity_list" class="item-list scroller padding" data-always-visible="1">
                                        <li id="activity_12">
                                            <div class="media">
                                                <div class="media-body">
                                                    <div class="notice-toggle notice_title"  style="display: block; "> 
                                                        <span>系统管理员为您温馨提示：明天气温下降，注意穿衣保暖</span>
                                                    </div>
                                                    <div class="notice-collapse" style="display:block; padding: 5px;">
                                                        <span><i class="icon-user"></i> 陈杰浩</span><span style="width:40px;display:inline-block;"></span>
                                                        <span><i class="icon-map-marker"></i> 工体，2014/2/7</span><span style="width:40px;display:inline-block;"></span>
                                                        <span><i class="icon-calendar"></i> 2014/2/6 报名截止</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                    <div class="clearfix no-top-space no-bottom-space"></div>
                                </div>
                            </div>

                            <div class="widget purple">
                                <div class="widget-title">
                                    <h4><i class="icon-comments-alt"></i>热门投票</h4>
                                    <span class="tools">
                                        <a href="<%=this.voteurl%>" onclick="parent.BaseFunction('vote');"  style="color:#FFF;font-size:14px;margin-right:6px;">更多</a>
                                    </span>
                                </div>
                                <div class="widget-body">
                                    <ul id="vote_list" class="item-list scroller padding" style="width:auto;" runat="server" data-always-visible="1"></ul>
                                    <div class="clearfix no-top-space no-bottom-space"></div>
                                </div>
                            </div>
                        </div>--%>

                    </div>
                    <!-- END PAGE CONTENT-->
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
            <!-- END PAGE -->
        </div>
        <!-- END CONTAINER -->

        <!-- BEGIN JAVASCRIPTS -->
        <!-- Load javascripts at bottom, this will reduce page load time -->
        <script src="/metro/js/jquery.nicescroll.js" type="text/javascript"></script>
        <script type="text/javascript" src="/metro/assets/jquery-slimscroll/jquery-ui-1.9.2.custom.min.js"></script>
        <script type="text/javascript" src="/metro/assets/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <script src="/metro/assets/bootstrap/js/bootstrap.min.js"></script>

        <!-- ie8 fixes -->
        <!--[if lt IE 9]>
            <script src="js/excanvas.js"></script>
            <script src="js/respond.js"></script>
        <![endif]-->
        <script src="/metro/js/jquery.scrollTo.min.js"></script>

        <!--common script for all pages-->
        <script src="/metro/js/common-scripts.js"></script>
        <script src="/metro/js/data-js/data-horse.js"></script>
        <script src="/metro/js/ex-common-scripts.js"></script>
        <script type="text/javascript" src="notification/NewsListAjax.js"></script>
        <!--script for this page only-->

        <script type="text/javascript">
            $(function () {
                //资讯
                //newsFetch('#newsList', 1, 1, 0);

                //getNewsForList('#newsList', 1, 1, 0);
                //if ($("default selected").length > 0)
                //    $("default selected").click();


                //$("#div_affairs").sortable();
                //$("#div_school").sortable();

                //$("#activity_list").height(290);
                //$("#activity_list").parent().height(290);

                //$("#vote_list").height(220);
                //$("#vote_list").parent().height(220);
                //showActivity();

                //showUnReadNoticeCnt();
                

            });
            $(document).ready(function () {
                //$("#activity_list li").mouseover(function() {
                //    var thisid = $(this).attr('id');
                //    $("#" + thisid + " .notice-collapse").show();
                //    $(this).siblings("li").find(".notice-collapse").hide();
                //});
                //showUnReadNoticeCnt();
                var listId = "#newsList";
                GetNewsForList(listId, 0, 1, "");
                var a = document.getElementById('indexSelectA');
                if (a) {
                    a.click();
                }

                //通知
                showUserNotice();


            });
            function showUserNotice()
            {
                var img_src = "/images/news/logo/notice_icon.png";
                $.ajax({
                    type: "POST",
                    url: "/AdminMetro/CCOM/notice/NoticeHandler.ashx",
                    data: { "action": "getStatisticData" },
                    success: function(data)
                    {
                        
                        if (data != null||data.length>0)
                        {
                            
                            var result = eval(data);
                            //alert("result=" + result);
                            if (result!=null&&result.length > 0)
                            { 
                                for (var i = 0; i < result.length; i++) {
                                    var title = ""
                                    if (result[i].Notice_content.length > 30) {
                                        title = result[i].Notice_content.substr(0, 30) + "...."
                                    }
                                    else {
                                        title = result[i].Notice_content;
                                    }
                                    var li = '<li>'
                                        + ' <div class="media notice_content">'
                                        + '<span class="label pull-left news-bg">'
                                        + '<img class="img-circle" src="' + img_src + '" alt="新闻" style="width: 40px;height:40px;" />'
                                        + ' </span>'
                                        + '<div class="media-body notice_content">'
                                        + '<p class="text news-title">'
                                        + '<a href="/AdminMetro/CCOM/notice/ViewNotice.aspx?id=' + result[i].Notice_id + '" target="_blank">'
                                        + title
                                        + '</a></p>'
                                        + '<span>'
                                        + '发布时间：' + result[i].Notice_date
                                        + '</span>'
                                        + '</div></div>'
                                        + '</li>';
                                    $("#notice_list").append(li);
                                }
                            }
                            else
                            {
                                //alert("data=" + data);
                                var li = '<li>'
                                + '<div class="media notice_content"  style="text-align:center;height:50px;">'
                                + '<p style="text-align:center;font-size:20px;margin-top:15px;">暂无通知</p>'
                                + '</div>'
                                + '</li>';
                                $("#notice_list").append(li);
                            }
                            
                        }
                        else
                        {
                            
                            //alert(data);
                            var li = '<li>'
                            + '<div class="media notice_content">'
                            + '<span style="text-align:center;">暂无通知</span>'
                            + '</div>'
                            + '</li>';
                            $("#notice_list").append(li);
                        }
                        
                    },
                    error: function(data)
                    {
                        alert("请求数据出错");
                    }
                });

            }
            var sysNotices = {};
            function showUnReadNoticeCnt() {
                $("input[name='noticeSysCode']:hidden").each(
                    function () {
                        var sysCode = $(this).val();
                        var node = $(this);
                        getUnReadNoticeCnt(sysCode, function (cnt) {
                            sysNotices[sysCode] = cnt;
                            if (cnt > 0) {
                                var badge = '<span class="badge badge-important notice_circle">' + cnt + "</span>";
                                node.before(badge);
                            }
                        });
                    }
                );
            }
            function updateNoticeStatus(sysCode) {
                if (sysNotices[sysCode] > 0)
                    updateUnReadNoticeStatus(sysCode);
            }
            function toggleSelectedCss(self) {
                $(self).parent().find("a:lt(999)").removeClass("selected");

                $(self).addClass("selected");
            }
        </script>
            <script type="text/javascript">
                //首页清空功能树
                if ($.isFunction(parent.SetTopContent))
                    parent.SetTopContent('');
            </script>
            <script>
                var _hmt = _hmt || [];
                (function () {
                    var hm = document.createElement("script");
                    hm.src = "//hm.baidu.com/hm.js?9a103a0d184ea7d73dccd3718e1b990d";
                    var s = document.getElementsByTagName("script")[0];
                    s.parentNode.insertBefore(hm, s);
                })();
            </script>
    </form>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
