<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_default_notice.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.Edit_default_notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑默认通知</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <link rel="stylesheet" type="text/css" href="/metro/assets/jquery-tags-input/jquery.tagsinput.css" />
    <link rel="stylesheet" href="/metro/js/textext/css/textext.core.css" type="text/css" />
    <link rel="stylesheet" href="/metro/js/textext/css/textext.plugin.tags.css" type="text/css" />
    <link rel="stylesheet" href="/metro/js/textext/css/textext.plugin.focus.css" type="text/css" />
    <script src="/metro/js/textext/js/textext.core.js" type="text/javascript" charset="utf-8"></script>
    <script src="/metro/js/textext/js/textext.plugin.tags.js" type="text/javascript" charset="utf-8"></script>
    <script src="/metro/js/textext/js/textext.plugin.focus.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="/metro/assets/jquery-tags-input/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="/metro/js/JsMap.js"></script>
    <script type="text/javascript" src="/scripts/artDialog4.1.7/artDialog.js?skin=blue"></script>
    <script type="text/javascript" src="/scripts/artDialog4.1.7/plugins/iframeTools.js"></script>
    <script type="text/javascript">
        //计算当前输入多少字符
        function countWord() {
            var len = $("#txtContent").val().length;
            if (len <= 250) {
                $("#lblWord").css("color", "");
                $("#lblWord").css("font-weight", "lighter");
                $("#lblWord").text("当前已输入" + len + "个字符，您还可以输入" + (250 - len) + "个字符");
            } else {
                $("#lblWord").css("color", "red");
                $("#lblWord").css("font-weight", "bold");
                $("#lblWord").text("字数超出最大允许值");
            }
        }

        function checkSaveContent() {
           

            if ( ($("#txtContent").val().trim().length == 0 || $("#txtContent").val().length > 250)) {
                parent.jsprint("文字通知内容必须在1~250个字符之间！", "", "Warning");
                return false;
            }
            

            return true;
        }
    </script>
    <style type="text/css">
        .text-core .text-wrap {
            background: #fff;
        }

        /*覆盖原样式*/
        .well {
            padding: 0;
            width: 800px;
        }

        .nav li {
            width: 50%;
            font-size: 18px;
            text-align: center;
            border: #C8C8C8;
        }

        li a {
            color: #999999;
        }

        .nav-tabs .active a, .nav-tabs .active a:hover, .nav-tabs .active a:focus {
            background-color: #25B6ED; /*#0079FF;*/
            color: #FFF;
            border-bottom-color: #DDD;
        }

        div .tagsinput {
            height: auto !important;
            max-height: 120px;
            display: none;
        }

        #divPushType a {
            margin-right: 8px;
            margin-bottom: 8px;
        }

        #div_intro b {
            color: #FF0013;
        }

        .noChange {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="hidEditorCnt" runat="server" />
        <asp:HiddenField ID="hidPushType" Value="0" runat="server" />
        <asp:HiddenField ID="hidIsImagePush" Value="0" runat="server" />
        <asp:HiddenField ID="attachChange" runat="server" Value="0" />
        <asp:HiddenField ID="SMS_left" runat="server" Value="0" />
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 id="tit" class="page-title">设置默认通知
                            </h3>
                        </div>
                    </div>
                    <!--左边-->
                    <div class="row-fluid" style="margin-top:20px;">
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1_1">
                                <div class="control-group">
                                    <label class="control-label" for="txtContent">
                                        推送内容<br />
                                        (250字以内)</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="788" Height="100" onKeyUp="countWord()" onblur="countWord()"></asp:TextBox>
                                        <label id="lblWord" style="width: 800px; text-align: right; font-size: 12px; font-weight: lighter; display: block;">
                                            当前已输入0个字符，您还可以输入250个字符
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="span12">
                                <div class="form-actions" style="margin-bottom: 30px;">
                                    <asp:HiddenField ID="verifyToken" runat="server" />
                                    <div id="divSave" runat="server">
                                        <asp:Label ID="lblEditNotice" ForeColor="Red" runat="server"></asp:Label>
                                        <br />
                                        <asp:Button ID="btnSave" runat="server" Text="保  存" Style="margin-top: 10px;" CssClass="btn btn-success" OnClick="btnSubmit_Click" OnClientClick="return checkSaveContent()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
            <!-- END PAGE -->
        </div>
        <!-- END CONTAINER -->
    </form>
</body>
</html>
