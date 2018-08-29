<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseOrEditNews.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notification.ReleaseOrEditNews" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>编辑发布资讯</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    
    <script type="text/javascript" src="ReleaseOrEdit.js"></script>

    <script type="text/javascript">

        

        function checkNewsContent() {

            if (UE.getEditor('editor').getPlainTxt().trim() == "") {
                parent.jsprint("信息内容不能为空！", "", "Warning");
                return false;
            }
            document.getElementById("hidEditorCnt").value = UE.getEditor('editor').getContent();
            artdialogSubmitTips();
            return true;
        }
        function SetWordContent(wordCnt) {
            UE.getEditor('editor').setContent(wordCnt);
            parent.jsprint("^_^导入成功！请您检查并修改不兼容的格式！", "", "Success");
        }

        function showTopTime() {
            if ($("#optTop").attr("checked")) {
                $("#trTop").show();
            } else {
                $("#trTop").hide();
            }
        }
        function newsTypeTabs(typeId, node) {
            //设置点击后的切换样式
            //$("txtKeywords").val("");
            $(node).parent().children("a.btn-success").removeClass("btn-success");
            $(node).addClass("btn-success");
            //alert(typeId);
            document.getElementById('<%=hidNewsType.ClientID%>').value = typeId;

        }
        $(function () {
            showTopTime();
        });

        function showUpNewsSet(self) {
            var iNode = $(self).find("i");
            if (iNode.attr('class') == "icon-double-angle-down") {
                $(".news-set").slideDown();
                iNode.attr('class', 'icon-double-angle-up');
                iNode.html("收起设定");
            } else {
                $(".news-set").slideUp();
                iNode.attr('class', 'icon-double-angle-down');
                iNode.html("展开设定");
            }
        }





        //新闻word导入上传
        function WordExtractUpload(uppath, callback) {
            var submitUrl = "/tools/upload_ajax.ashx?action=WordExtract&UpFilePath=" + uppath;
            //开始提交
            $("#form1").ajaxSubmit({
                beforeSubmit: function (formData, jqForm, options) {
                    //隐藏上传按钮
                    $("#" + uppath).parent().next().show();
                    //显示LOADING图片
                    $("#" + uppath).parent().hide();
                },
                success: function (data, textStatus) {
                    if (data.msg == 1) {
                        callback(decodeURIComponent(data.msgbox));
                        //alert(data.mstitle);
                    } else {
                        alert(decodeURIComponent(data.msgbox));
                    }
                    $("#" + uppath).parent().show();
                    $("#" + uppath).parent().next().hide();

                },
                error: function (data, status, e) {
                    alert("网络异常，上传失败，您可以再次尝试或更换浏览器试一下。");
                    $("#" + uppath).parent().show();
                    $("#" + uppath).parent().next().hide();
                },
                url: submitUrl,
                type: "post",
                dataType: "json",
                timeout: 600000
            });
        };

        //附件上传
        function AttachUpload(repath, uppath) {
            document.getElementById('<%=attachChange.ClientID%>').value = 1;
            var submitUrl = "/tools/upload_ajax.ashx?action=AttachFile&UpFilePath=" + uppath;
            //开始提交
            $("#form1").ajaxSubmit({
                beforeSubmit: function (formData, jqForm, options) {
                    //隐藏上传按钮
                    $("#" + uppath).parent().hide();
                    //显示LOADING图片
                    $("#" + uppath).parent().next().show();
                },
                success: function (data, textStatus) {
                    if (data.msg == 1) {

                        var listBox = $("#" + repath + " ul");
                        var newLi = '<li>'
                        + '<input name="hidFileName" type="hidden" value="0|' + data.mstitle + "|" + data.msgbox + '" />'
                        + '<span class="title">附件：' + data.mstitle + '</span>'
                        + '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove"></a>'
                        + '</li>';
                        listBox.append(newLi);
                    } else {
                        alert(data.msgbox);
                    }
                    $("#" + uppath).parent().show();
                    $("#" + uppath).parent().next().hide();

                },
                error: function (data, status, e) {
                    alert("网络异常，上传失败，您可以再次尝试或更换浏览器试一下。");
                    $("#" + uppath).parent().show();
                    $("#" + uppath).parent().next().hide();
                },
                url: submitUrl,
                type: "post",
                dataType: "json",
                timeout: 60000
            });
        };

        function lostFocus()
        {
            var time = $("#txtTopTime").val();
            //alert(time.length);
            for(i=0;i<time.length;i++)
            {
                if(time[i]<'0'||time[i]>'9')
                {
                    document.getElementById('<%=txtTopTime.ClientID%>').value = "";
                    alert("时间只能为数字");
                    return;
                }
            }
            if(time.length>=5)
            {
                document.getElementById('<%=txtTopTime.ClientID%>').value = "";
                alert("置顶时间过长");
                return;
            }
        }


        //添加资讯类别
        function addPushType() {
            var d = dialog({
                title: '添加资讯类别',
                width: 400,
                content: '<span>请输入资讯类别名称：</span>&nbsp;<input id="property-returnValue-demo" style="width:15em; padding:4px" value="" /><span style="color:red;" id="spResult"></span>',
                okValue: '确定',
                ok: function () {
                    var value = $('#property-returnValue-demo').val();
                    if (value == "") {
                        parent.jsprint("类别名称不能为空", "", "Warning");
                        return;
                    }
                    $.ajax({
                        url: 'News_handler.ashx?action=addPushType&t=' + encodeURIComponent(value),
                        success: function (data) {
                            //alert(data);
                            var resultJson = eval("(" + data + ")");
                            if (resultJson.Result == 200) {
                                //alert(data);
                                parent.jsprint("添加成功！", "", "Success");
                                //alert(data);
                                //将新添加的类别加上
                                var newType = "<a href='javascript:;' class='btn'" + " onclick='newsTypeTabs(\"" + resultJson.id + "\",this)'>" + resultJson.name + "</a>&nbsp;&nbsp;";
                                $(newType).insertBefore($('#NewsTypeDiv').children("a:eq(-1)"));
                            } else {
                                parent.jsprint(resultJson.Msg, "", "Error");
                                //$("#spResult").html(resultJson.Msg);
                            }
                        },
                        error: function () {
                            parent.jsprint("添加失败！", "", "Error");
                        },
                        cache: false
                    });
                    this.close();
                },
                cancelValue: '取消',
                cancel: function () { }
            });
            d.show();
        }

        //选中推送类别
        function selectPushType(node, value) {
            $(node).parent().children(".btn-success").removeClass("btn-success");
            $(node).addClass("btn-success");
            $("#hidNewsType").val(value);
        }
    </script>
    <style type="text/css">
        #NewsTypeDiv a
        {
            margin-left:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />
        <asp:HiddenField ID="hidNewsType" runat="server"/>
        <asp:HiddenField ID="hidOptOnlyAdmin" runat="server" />
        <asp:HiddenField ID="attachChange" runat="server" Value="0"/>
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">发布资讯
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="/AdminMetro/CenterPage/news_list.aspx">资讯</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">发布资讯
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <div class="alert alert-success" style="display: none;">
                        <button data-dismiss="alert" class="close">×</button>
                        <strong>更新提醒：</strong>
                        <p>1. 资讯发布系统增加手机快速发布频道啦，请登陆APP查看详情。</p>
                        <p>2. 更新了系统发布系统的后台架构，发布更流畅！</p>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                          
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <!-- BEGIN FORM-->
                                        <div class="control-group">
                                            <label class="control-label" style="float:left;margin-top:5px;"><b style="color: red;">*</b>选择类别</label>
                                            <div class="controls" style="padding-left:80px;">
                                                <div runat="server" id="NewsTypeDiv" style="line-height: 35px;">
                                                    <a href="javascript:;" class="btn ">未分类</a>
                                                    <a href="javascript:;" class="btn ">日常事务</a>
                                                    <a href="javascript:;" class="btn btn-success">评奖评优</a>
                                                </div> 
                                            </div>
                                        </div>
                              
                                        <div class="control-group">
                                            <label class="control-label" for="txtTitle" style="float:left;margin-top:5px;"><b style="color: red;">*</b>资讯标题</label>
                                            <div class="controls" style="padding-left:80px;">
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="span6" minlength="2" MaxLength="100" />

                                                <span class="help-inline">最多100汉字</span>
                                            </div>
                                        </div>
                                   
                                        <div class="control-group">
                                            <label class="control-label" style="float:left;margin-top:5px;"><b style="color: red;">*</b>资讯内容</label>
                                            <div class="controls" id="intro_news" style="padding-left:80px;">

                                                <p class="filesupload">
                                                    <span class="btn btn-file">
                                                        <span class="fileupload-new"><i class="icon-file-text"></i>从word文档中导入</span>
                                                        <input type="file" id="FileUpload" class="default" name="FileUpload" onchange="WordExtractUpload('FileUpload', SetWordContent);" />
                                                    </span>
                                                    <span id="Span1" class="uploading">正在上传，请稍候...</span>
                                                </p>
                                                <script id="editor" type="text/plain" style="width: 95%; height: 250px;">
                                                </script>
                                                <script type="text/javascript">
                                                    //实例化编辑器
                                                    var ue = UE.getEditor('editor', {
                                                        autoHeight: false
                                                    });
                                                    ue.ready(function () {
                                                        //设置编辑器的内容
                                                        ue.setContent(document.getElementById("hidEditorCnt").value);
                                                        
                                                    });
                                                    if (!ue.isServerConfigLoaded()) {
                                                        ue.loadServerConfig();
                                                    }
                                                </script>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label" style="float:left;margin-top:5px;">上传附件</label>
                                            <div class="controls" id="intro_attach" style="padding-left:80px;">
                                                <p class="filesupload">
                                                    <span class="btn btn-file">
                                                        <span class="fileupload-new"><i class="icon-plus"></i>选择附件</span>
                                                        <input type="file" id="File2" class="default" name="FileUpload2" onchange="AttachUpload('AttachList','FileUpload2');" />
                                                    </span>
                                                    <span class="uploading">正在上传，请稍候...</span>
                                                </p>
                                                <div id="AttachList" class="attach_list">
                                                    <ul>
                                                        <asp:Repeater ID="rptAttach" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <input name="hidFileName" type="hidden" value="<%#Eval("News_attach_id")%>|<%#Eval("News_attach_name")%>|<%#Eval("News_attach_address")%>" />
                                                                    <span class="title">附件：<%#Eval("News_attach_name")%></span>
                                                                    &nbsp;&nbsp;<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove"></a>
                                                                 
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="control-group ">
                                            <label class="control-label"  style="float:left;margin-top:5px;">发布时间</label>
                                            <div class="controls" style="padding-left:80px;">
                                                <asp:TextBox ID="txtReleaseTime" runat="server" onClick="WdatePicker({dateFmt:'yyyy年MM月dd日 HH:mm'})" CssClass="input-medium" />

                                            </div>
                                        </div>   
                                        <div class="control-group ">
                                            <label class="control-label"  style="float:left;margin-top:5px;">置顶设定</label>
                                            <div class="controls" style="padding-left:80px;">
                                                <asp:CheckBox ID="optTop" onclick="showTopTime();" runat="server" Text="资讯置顶" />
                                                <asp:Label ID="lblTop" ForeColor="red" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group" id="trTop" runat="server">
                                            <label class="control-label" style="float:left;">置顶时长</label>
                                            <div class="controls" style="padding-left:80px;">
                                                <asp:TextBox ID="txtTopTime" onBlur="lostFocus();" runat="server" CssClass="input-medium"/>
                                                （默认置顶3天）
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions" style="border-top: none;margin-bottom: 50px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="display: inline;">
                                    <ContentTemplate>
                                        <asp:Button ID="btnPreView" runat="server" Text="预览" CssClass="btn" OnClick="btnPreView_Click" OnClientClick="return checkNewsContent()" Style="width: 100px;" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Button ID="btnSubmit" runat="server" Text="发布" CssClass="btn btn-success" OnClick="btnSubmit_Click" OnClientClick="return checkNewsContent()" Style="width: 100px;" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    
    <!--end common script for all pages-->
</body>
</html>
