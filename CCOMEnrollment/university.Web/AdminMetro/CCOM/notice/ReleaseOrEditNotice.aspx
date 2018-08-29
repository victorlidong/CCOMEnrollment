<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseOrEditNotice.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.ReleaseOrEditNotice" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>通知推送系统-推送通知</title>
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
        var artDialogWait;
        var layerUser;
        var layerName;
        var gUsersMap = new Map();
        var isVerified = false;
        var flag = 0;
        var total_user = 0;
        function checkPushContent() {
            $("#hidEditorCnt").val(UE.getEditor('editor').getContent());

            if ($("#hidIsImagePush").val() == "0" && ($("#txtContent").val().trim().length == 0 || $("#txtContent").val().length > 250)) {
                parent.jsprint("文字通知内容必须在1~250个字符之间！", "", "Warning");
                return false;
            }
            if ($("#hidIsImagePush").val() == "1" && $("#txtTitle").val().trim().length <= 0) {
                parent.jsprint("图文通知标题不能为空！", "", "Warning");
                return false;
            }
            if ($("#hidIsImagePush").val() == "1" && $("#hidEditorCnt").val().trim().length <= 0) {
                parent.jsprint("图文通知内容不能为空！", "", "Warning");
                return false;
            }
            if ($('#hidUserList').val() == "" && $("#hidDeptList").val().trim() == "" && $("#hidGroupList").val().trim() == "") {
                parent.jsprint("请您选择推送用户！", "", "Warning");
                return false;
            }
           
            var d = dialog({
                title: '发送提示',
                content: "<img src='/scripts/artDialog4.1.7/skins/icons/wait.gif' alt='Loading'/>正在发送，请您耐心等等...^_^"
            });
            d.showModal();
            return true;
        }

        function checkSaveContent() {
            $("#hidEditorCnt").val(UE.getEditor('editor').getContent());

            if ($("#hidIsImagePush").val() == "0" && ($("#txtContent").val().trim().length == 0 || $("#txtContent").val().length > 250)) {
                parent.jsprint("文字通知内容必须在1~250个字符之间！", "", "Warning");
                return false;
            }
            if ($("#hidIsImagePush").val() == "1" && $("#txtTitle").val().trim().length <= 0) {
                parent.jsprint("图文通知标题不能为空！", "", "Warning");
                return false;
            }
            if ($("#hidIsImagePush").val() == "1" && $("#hidEditorCnt").val().trim().length <= 0) {
                parent.jsprint("图文通知内容不能为空！", "", "Warning");
                return false;
            }

            return true;
        }

        //选择推送用户
        function addPushUser() {
           
            var deptList = $("#hidDeptList").val();
            var groupList = $("#hidGroupList").val();
            var userList = $("#hidUserList").val();
            var nodeNameList = $("#hidNodeName").val();
            var url = 'SelectUserDept.aspx?deptList=' + encodeURIComponent(deptList) +
                '&groupList=' + encodeURIComponent(groupList) +
                '&nodeNameList=' + encodeURIComponent(nodeNameList)+
                '&userList=' + encodeURIComponent(userList) + '&fun_id=<%=DESEncrypt.Encrypt(this.fun_id.ToString())%>' ;
                $.layer({
                    type: 2,
                    title: ['选择推送用户'],
                    shadeClose: true,
                    closeBtn: [0, true],
                    shade: [0.3, '#000'],
                    border: [0],
                    area: ['650px', '80%'],
                    iframe: { src: url }
                });
            }

            //选择推送用户的回调函数
            function selectUserDeptCallBack(deptIdList, groupIdList, userIdList, nodeNameList, totalUserCount) {
                
                resetTextExt();
                
                //对3个list赋值
                $("#hidDeptList").val(deptIdList);
                $("#hidGroupList").val(groupIdList);
                $("#hidUserList").val(userIdList);
                $("#hidNodeName").val(nodeNameList);
                //alert(userIdList);
                $("#spanTotalUserCount").html(totalUserCount);
                $("#hidTotalUserCount").val(totalUserCount);
                var idList=new Array();
                var userData = eval("(" + nodeNameList + ")");
                var userMap = new Map();
                for (var key in userData) {
                    if (key.split('|')[0]==3)
                    {
                        idList.push(key.split('|')[1]);  
                    }
                    userMap.put(userData[key], key);
                }
                $("#hidUserList").val(idList);
                updateSelectUsers(userMap);
                
            }

            function clearSelectUsers() {
                if (confirm('您确定要清空已选用户吗?')) {
                    resetTextExt();
                }
            }

            function resetTextExt() {
                 //清空3个list
                $("#hidDeptList").val("");
                $("#hidGroupList").val("");
                $("#hidUserList").val("");
                $("#hidNodeName").val("");
                $("#spanTotalUserCount").html("0");
                $("#hidTotalUserCount").val("0");

                var keySet = gUsersMap.keySet();
               
               
                for (var i = 0; i < keySet.length; i++) {
                    $('#iptUserTags').removeTag(keySet[i]);
                    gUsersMap.remove(keySet[i]);
                }
                //$('#iptUserTags').empty();
                //设置输入框和清空按钮不可见
                $('div.tagsinput').css("display", "none");
                $('#lnkClearUsers').css("visibility", "hidden");
            }

            function updateSelectUsers(tUsersMap) {

                
                gUsersMap = tUsersMap;
                var keySet = gUsersMap.keySet();
                if (keySet.length > 0) {
                    $('div.tagsinput').css("display", "block");
                    $('#lnkClearUsers').css("visibility", "visible");
                } else {
                    $('div.tagsinput').css("display", "none");
                    $('#lnkClearUsers').css("visibility", "hidden");
                }
                
                for (var i = 0; i < keySet.length; i++) {
                    $('#iptUserTags').addTag(keySet[i]);
                }

                //更新选中的推送用户数
                getSelectedUserCount();
            }

           

            //申请短信
         <%--   function applySms() 
            {
                var url = 'ApplySms.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>';
                $.layer({
                    type: 2,
                    title: ['申请短信发送条数'],
                    shadeClose: true,
                    closeBtn: [0, true],
                    shade: [0.3, '#000'],
                    border: [0],
                    area: ['450px', '280px'],
                    iframe: { src: url }
                });
            }

            //申请短信回调函数
            function applyCallBack(msg, isFirst, number) {
                var d = dialog({
                    content: msg
                });
                d.show();
                setTimeout(function () {
                    d.close().remove();
                }, 2000);
                if (isFirst == 1) {
                    $("#smsCnt").html(number);
                }
            }

            function showApplyRecord(url) {
                location.replace(url);
            }--%>

            /* 
            * Add by: dwb
            * Modify Time: 2014-10-27
            * 调用验证页面
            */
            <%--function verifySmsCode() {
           <% if (this.verifySecurityPwd)
              { %>
            $.getScript("/metro/js/verify/verify-pwd.js").done(function (script, textStatus) {
                showPwdVerify(function (data) {
                    $("#verifyToken").val(data);
                    verifyCallBack("身份验证成功！");
                    $("#btnSubmit").click();
                });
            });
         <% } %>
        }--%>

        //验证回调函数
        <%--function verifyCallBack(msg) {
            isVerified = true;
            var d = dialog({
                content: msg
            });
            d.show();
            setTimeout(function () {
                d.close();
            }, 2000);
        }

        //判断短信剩余量是否充足
        function checkSmsCount(chkobj) {

            if ($(chkobj).attr("checked") == "checked")
            {
                
                var total_user = $("#hidTotalUserCount").val();
                var total_SMS_left = "<%=GetSMSNumber()%>";
                if (total_user > total_SMS_left) {
                    alert("你的短信余额不足，请先申请短信");
                    $(chkobj).attr("checked",false);
                }
                
            }
        }--%>

        ////添加通知类别
        //function addPushType() {
        //    var d = dialog({
        //        title: '添加通知类别',
        //        width: 400,
        //        content: '<span>请输入通知类别名称：</span>&nbsp;<input id="property-returnValue-demo" style="width:15em; padding:4px" value="" /><span style="color:red;" id="spResult"></span>',
        //        okValue: '确定',
        //        ok: function () {
        //            var value = $('#property-returnValue-demo').val();
        //            if (value == "") {
        //                parent.jsprint("类别名称不能为空", "", "Warning");
        //                return;
        //            }
        //            $.ajax({
        //                url: 'NoticeHandler.ashx?action=addPushType&t=' + encodeURIComponent(value),
        //                success: function (data) {
        //                    var resultJson = eval("(" + data + ")");
        //                    if (resultJson.Result == 200) {
        //                        parent.jsprint("添加成功！", "", "Success");

        //                        //将新添加的类别加上
        //                        var newType = "<a href=\"javascript:;\" class='btn' onclick='selectPushType(this,\"" + resultJson.id + "\")'>" + resultJson.name + "</a>\"&nbsp;&nbsp;\"";
        //                        $(newType).insertBefore($('#divPushType').children("a:eq(-2)"));
        //                    } else {
        //                        parent.jsprint(resultJson.Msg, "", "Error");
        //                        //$("#spResult").html(resultJson.Msg);
        //                    }
        //                },
        //                error: function () {
        //                    parent.jsprint("添加失败！", "", "Error");
        //                },
        //                cache: false
        //            });
        //            this.close();
        //        },
        //        cancelValue: '取消',
        //        cancel: function () { }
        //    });
        //    d.show();
        //}

        

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

        //导入word文档
        function checkNewsContent() {
            if (UE.getEditor('editor').getPlainTxt().trim() == "") {
                parent.jsprint("信息内容不能为空！", "", "Warning");
                return false;
            }

            document.getElementById("hidEditorCnt").value = UE.getEditor('editor').getContent();
            artdialogSubmitTips();
            return true;
        }

        function setWordContent(wordCnt) {
            UE.getEditor('editor').setContent(wordCnt);
            parent.jsprint("^_^导入成功！请您检查并修改不兼容的格式！", "", "Success");
        }

        //选中推送类别
        function selectPushType(node, value) {
            $(node).parent().children(".btn-success").removeClass("btn-success");
            $(node).addClass("btn-success");
            $("#hidPushType").val(value);
        }

        //选择通知类型
        function selectImagePush() {
            $(".well a:eq(1)").click();
        }

        //切换文字通知与图文通知
        function toggleWordPush(value) {

            if(value=="0")
            {
                $("#step2").css("display", "");
                //$("#step2").style.display = "";
            }
            else
            {
                
                $("#step2").css("display", "none");
                //$("#step2").style.display = 'none';
            }
            $("#hidIsImagePush").val(value);
        }

        //获取选中的推送用户数
        function getSelectedUserCount() {
            //var deptList = $("#hidDeptList").val();
            //var groupList = $("#hidGroupList").val();
            //var userList = $("#hidUserList").val();
            //var nodeName = $("#hidNodeName").val();
            ////alert("deptList=" + deptList +  "groupList=" + groupList +  "userList=" + userList +  "nodeName=" + nodeName);
            //var submitUrl = 'NoticeHandler.ashx?action=getSelectedUserCount&deptList=' + encodeURIComponent(deptList) +
            //    '&groupList=' + encodeURIComponent(groupList) + '&userList=' + encodeURIComponent(userList)
            //+ '&nodeName=' + encodeURIComponent(nodeName);

            ////开始提交
            //$.ajax({
            //    url: submitUrl,
            //    success: function (data) {
                    
            //        try {
            //            var resultJson = eval("(" + data + ")");
            //            //alert(data);
            //            if (resultJson.Result == 200) {
            //                //更改选中的推送用户后，重新获取用户总数并更新
            //                $("#spanTotalUserCount").html(resultJson.Msg);
            //                $("#hidTotalUserCount").val(resultJson.Msg);
                            
            //            }
            //        } catch (e) {
            //        }
            //    },
            //    error: function (data, status, e) {
            //    },
            //    cache: false
            //});
            $("#spanTotalUserCount").html(gUsersMap.keySet().length);
            $("#hidTotalUserCount").val(gUsersMap.keySet().length);
            
        }

        //附件上传
        function AttachUpload(repath, uppath)
        {
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
            }); isSendCounsellor
        };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            <% if (this.editType==0)
           {   %>
                $("#tab_img a").remove();
                var a = document.createElement("a");
                a.innerText = "图 文 通 知";
                a.className = "noChange";
                var li = document.getElementById("tab_img");
                li.appendChild(a);
                
                <% } %>

            <% if(this.editType==1) 
            {   %>
                $("#tab_word a").remove();
                var a = document.createElement("a");
                a.innerText = "文 字 通 知";
                a.className = "noChange";
                var li = document.getElementById("tab_word");
                li.appendChild(a);
                
                <% } %>

            
            });
    </script>
    <style type="text/css">
        .text-core .text-wrap
        {
            background: #fff;
        }

        /*覆盖原样式*/
        .well
        {
            padding: 0;
            width: 800px;
        }

        .nav li
        {
            width: 50%;
            font-size: 18px;
            text-align: center;
            border: #C8C8C8;
        }

        li a
        {
            color: #999999;
        }

        .nav-tabs .active a, .nav-tabs .active a:hover, .nav-tabs .active a:focus
        {
            background-color: #25B6ED; /*#0079FF;*/
            color: #FFF;
            border-bottom-color: #DDD;
        }

        div .tagsinput
        {
            height: auto !important;
            max-height: 120px;
            display: none;
        }

        #divPushType a
        {
            margin-right: 8px;
            margin-bottom: 8px;
        }

        #div_intro b
        {
            color: #FF0013;
        }
        .noChange
        {
            cursor:pointer;
        }
    </style>
        
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="hidEditorCnt" runat="server" />
        <asp:HiddenField ID="hidPushType" Value="0" runat="server" />
        <asp:HiddenField ID="hidIsImagePush" Value="0" runat="server" />
        <asp:HiddenField ID="attachChange" runat="server" Value="0"/>
        <asp:HiddenField ID="SMS_left" runat="server" Value="0"/>
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
                            <h3 id="tit" class="page-title">推送通知
                            </h3>
                            <%--<ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">推送通知系统</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active" id="self">推送通知
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <!--左边-->
                    <div class="row-fluid">
                            <div class="control-group" id="step3">
                                <label class="control-label">通知类型</label>
                                <div class="controls">
                                    <div id="tabbable custom-tab">
                                        <ul class="nav nav-tabs well" style="margin-bottom: 0;">
                                            <li id="tab_word" class="active" onclick="toggleWordPush('0')"><a href="#tab_1_1" data-toggle="tab">文 字 通 知</a></li>
                                            <li id="tab_img"  onclick="toggleWordPush('1')"><a href="#tab_1_2" data-toggle="tab">图 文 通 知</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
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

                                <div class="tab-pane" id="tab_1_2">
                                    <%--<div class="control-group">
                                        <label class="control-label">选择类别</label>
                                        <div class="controls">
                                            <div runat="server" id="divPushType" style="line-height: 35px;">
                                                <a href="javascript:;" class="btn ">未分类</a>
                                                <a href="javascript:;" class="btn ">日常事务</a>
                                                <a href="javascript:;" class="btn btn-success">评奖评优</a>
                                            </div>
                                        </div>
                                        
                                    </div>--%>

                                    <div class="control-group">
                                        <label class="control-label" for="txtTitle"><b style="color: red;">*</b>标题</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="span6" minlength="2" MaxLength="100" />
                                            <span class="help-inline">最多100汉字</span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b style="color: red;">*</b>内容</label>
                                        <div class="controls" id="intro_news">
                                            <p class="filesupload">
                                                <span class="btn btn-file">
                                                    <span class="fileupload-new"><i class="icon-file-text"></i>从word文档中导入</span>
                                                    <input type="file" id="FileUpload" class="default" name="FileUpload" onchange="WordExtractUpload('FileUpload', setWordContent);" />
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
                                        <label class="control-label">上传附件</label>
                                        <div class="controls" id="intro_attach">
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
                                                                <input name="hidFileName" type="hidden" value="<%#Eval("Notice_attach_id")%>|<%#Eval("Notice_attach_name")%>|<%#Eval("Notice_attach_address")%>" />
                                                                <span class="title">附件：<%#Eval("Notice_attach_name")%></span>&nbsp;&nbsp;<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove"></a>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                             <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">
                                        推送用户<br />
                                        <span id="allNum">（人数：<span id="spanTotalUserCount" style="color: red;">0</span>）</span>
                                    </label>
                                    <div class="controls">
                                        <div>
                                            
                                            <input id="iptUserTags" type="text" class="tags" value="" />
                                            <asp:HiddenField ID="hidTotalUserCount" runat="server" Value="0" />
                                            <asp:HiddenField ID="hidDeptList" runat="server" />
                                            <asp:HiddenField ID="hidGroupList" runat="server" />
                                            <asp:HiddenField ID="hidUserList" runat="server" />
                                            <asp:HiddenField ID="hidNodeName" runat="server" />
                                            <p>
                                                <span style="display: inline-block; margin-top: 5px;" id="step1">
                                                    <a class="btn btn-success" href="javascript:void(0);" onclick="addPushUser()"><i class="icon-plus icon-white">&nbsp;</i>添加用户</a>
                                                    <a class="btn btn-danger" id="lnkClearUsers" style="visibility: hidden;" href="javascript:void(0);" onclick="clearSelectUsers()"><i class="icon-remove icon-white">&nbsp;</i>清空</a>
                                                </span>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
           
                                    <div class="controls"  id="step2">
                                        <span>
                                            <asp:CheckBox ID="chbSmsSend" runat="server" Text="附加短信通知" onclick="checkSmsCount(this)" />
                                            <asp:Label ID="lblSms" runat="server" Text=""></asp:Label>
                                            <%--(<span style="color:red;">您当前剩余短信数:<%=GetSMSNumber()%></span>
                                            <a href="javascript:void(0);" onclick="applySms()">申请短信</a>)--%>
                                        </span>
                                    </div>
                                </div>
                                <div class="form-actions" style="margin-bottom:30px;">
                                    <asp:HiddenField ID="verifyToken" runat="server" />
                                    <div id="divSave" visible="false" runat="server">
                                        <%--<asp:CheckBox ID="cbxEditNotice" runat="server" Text="推送编辑提醒:" />
                                        &nbsp;&nbsp;--%>
                                        <asp:Label ID="lblEditNotice" ForeColor="Red" runat="server"></asp:Label>
                                        <br />
                                        <asp:Button ID="btnSave" runat="server" Text="保  存" Style="margin-top: 10px;" CssClass="btn btn-success" OnClick="btnSubmit_Click" OnClientClick="return checkSaveContent()" />
                                    </div>
                                    <asp:Button ID="btnSubmit" runat="server" Text="确定推送" CssClass="btn btn-success" OnClick="btnSubmit_Click" OnClientClick="return checkPushContent()" />
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
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
    <script type="text/javascript">
        //加载标签输入框
        $(function () {
            var elt = $('#iptUserTags');
            elt.tagsInput({
                width: "800px",
                height: "100px",
                interactive: false,
                unique: true,
                onRemoveTag: function (d) {
                    removeTag(d);
                }
            });
        });

        //页面加载完后显示选择的推送用户
        $(function () {
            if (gUsersMap.keySet().length > 0) {
                $('div.tagsinput').css("display", "block");
                $('#lnkClearUsers').css("visibility", "visible");
            } else {
                $('div.tagsinput').css("display", "none");
                $('#lnkClearUsers').css("visibility", "hidden");
            }
        });

        function removeTag(key) {
            //alert("key="+key);
            var value = gUsersMap.get(key);
            
            var type = value.split("|")[0];
            //alert("type=" + type);
            var id = value.split("|")[1];
            //alert("id=" + id);
            switch (type) {
                case '1':
                    removeId("#hidDeptList", id, value);
                    break;
                case '2':
                    {
                        //removeId("#hidGroupList", id, value);
                        id = id.substr(1, id.length - 1);
                        var groupIdList = $("#hidGroupList").val().split(',');
                        //alert(groupIdList);
                        if ($.inArray(id, groupIdList) >= 0)
                        {
                            groupIdList.splice($.inArray(id, groupIdList), 1);
                        }
                        $("#hidGroupList").val(groupIdList.join(','));
                        break;
                    }
                   
                case '3':
                    removeId("#hidUserList", id, value);
                    break;
                default:
                    break;
            }

            gUsersMap.remove(key);

            //更新选中的推送用户数
            getSelectedUserCount();

            //如果是最后一个标签，则清空选择框
            if (gUsersMap.keySet().length == 0) {
                resetTextExt();
            }
        }

        /*
            keySet[i]:值
            keySet：键
        */
        function removeId(hidId, id,value) {
            var idList = $(hidId).val().split(',');
            var keySet = gUsersMap.keySet();
            if ($.inArray(id, idList) >= 0) {
                idList.splice($.inArray(id, idList), 1);
                for (var i = 0; i < keySet.length; i++) {
                    if (gUsersMap.get(keySet[i]).split('|')[1] == id)
                    {
                        //alert("keySet[i]=" + keySet[i]);
                        gUsersMap.remove(keySet[i]);
                    }
                }
            }
            $(hidId).val(idList.join(','));
            var keySet1 = gUsersMap.keySet();
            var sb = "{";
            for (var i = 0; i < keySet1.length; i++)
            {
                sb += '"' + gUsersMap.get(keySet1[i]) + '":' + '"' + keySet1[i] + '"' + ",";
            }
            if (sb.length > 2)
            {
                sb=sb.substr(0,sb.length-1);//去除最后一个‘，’;
                sb += "}";
                
            }
            //alert("sb="+sb);
            $("#hidNodeName").val(sb);
            
            //alert($("#hidNodeName").val());
        }

        

        
    </script>
</body>
</html>
