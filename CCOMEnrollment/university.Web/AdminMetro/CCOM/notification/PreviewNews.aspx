<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewNews.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notification.PreviewNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,user-scalable=no" name="viewport" />
    <title runat="server" ID="txtHeadTitle">资讯预览</title>
    <!--    <link rel="stylesheet" href="../css/touch.css"> -->
    <style type="text/css">
        html, body {
            height: 100%;
        }
        body, ul, p {
            margin: 0;
            padding: 0;
        }
        .mainBody { /*background:#EFF0F4;*/
            text-align: left; /*font-family:STHeiti,Arial;*/ /*font-family: "HiraginoSansGB W3";*/
            font-family: "Helvetica";
            /*padding:0  0.8em;*/
            overflow-x: scroll;
            overflow-y: hidden;
            max-width: 1024px;
            margin: 0 auto;
            overflow-x: auto;
            background: #fff;
            min-height: 100%;
            /*footer置底*/
            position: relative; /*重要！保证footer是相对于wapper位置绝对*/
            height: auto; /* 保证页面能撑开浏览器高度时显示正常*/
            min-height: 100%; /* IE6不支持，IE6要单独配置*/
        }

        a, a:visited {
            text-decoration: none;
            color: #000;
        }

        .articleList {
            overflow: hidden;
            color: #000;
            background: #fff;
            display: none;
            padding: 1.2em;
            padding-bottom: 180px; /*重要！给footer预留的空间*/
        }

            .articleList h1 {
                font-size: 1.2em;
                margin: 0;
            }

            .articleList h2 {
                color: #b9b9b9;
                font-size: 0.8em;
                font-weight: normal;
            }

            .articleList .text1 p {
                margin: 0.1em 0;
                text-indent: 2em;
                line-height: 1.45em;
                padding-top: 0.3em;
                font-size: 1.0em;
                font-weight: normal;
                letter-spacing: 0.1em;
                max-width: 100%;
            }

            .articleList .text1 table p {
                margin: 0.1em 0;
                line-height: 1.45em;
                text-indent: 0em;
                padding-top: 0.3em;
                font-size: 1.0em;
                font-weight: normal;
                letter-spacing: 0.1em;
                max-width: 100%;
            }

            .articleList .text1 img {
                max-width: 60%;
                clear: both;
                display: block;
                margin: auto;
                border: 0px;
            }

        .ep-source {
            color: #808080;
            font-size: 0.8em;
            padding-top: 0.2em;
        }

        .attach {
            color: #808080;
            font-size: 0.9em;
            padding-top: 0.2em;
        }

            .attach .attachTitle {
            }

            .attach .attachItem {
                background: url(/admin/images/icon_attach.png) no-repeat 3px 4px;
                padding-left: 20px;
                line-height: 20px;
                vertical-align: middle;
            }

        .text1 {
            /*overflow-x: auto;*/
        }

        /*img
        {
            width: 98%;
            max-width: 600px;
        }*/
        .spanShare {
            float: left;
            padding: 5px 0 0;
        }

        #footer {
            position: absolute;
            bottom: 0; /* 关键 */
            left: 0; /* IE下一定要记得 */
            height: 170px; /* footer的高度一定要是固定值*/
        }
    </style>
    <script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
     
    </script>
</head>
<body style="background-color: #eee;">
    <form id="form1" runat="server">
        <div class="mainBody" runat="server" id="txtBody">
            <div style="border-bottom: 1px solid #666; padding: 17px;">
                <a href="/AdminMetro/login_page.aspx">
                    <img src="/images/news_head.png" style="border: 0px;" alt="中央音乐学院" /></a>
            </div>
            <!-- banner top end -->
            <article class="articleList" style="display: block;min-height:300px;">
                <div class="head clearfix">
                    <h1 class="title" runat="server" id="txtTitle">titlexxx</h1>
                    <h2><span class="time" runat="server" id="txtDes">desxxx</span>
                        &nbsp;&nbsp;<span>阅读量：<b id="readCnt">1</b></span>
                    </h2>
                </div>
                <!-- JiaThis Button BEGIN -->

                <!-- JiaThis Button END -->
                <div class="text clearfix">
                    <div class="text1">
                        <p runat="server" id="txtContent">contentxxx</p>
                    </div>
                    <div class="attach" runat="server" id="txtAttach">attachxxx</div>
                </div>

            </article>
            <div id="footer">
                
            </div>
        </div>
    </form>
</body>
</html>
