//*university后台管理页JS函数，Jquery扩展
//*作者：一些事情
//*时间：2012年02月20日

//=============================切换验证码======================================
function ToggleCode(obj, codeurl) {
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}

//表格隔行变色
$(function () {
    $(".msgtable tr:nth-child(odd)").addClass("tr_odd_bg"); //隔行变色
    $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
});
//==========================页面加载时JS函数结束===============================

//===========================系统管理JS函数开始================================

//Tab控制函数
function tabs(tabId, tabNum) {
    //设置点击后的切换样式
    $(tabId + " .tab_nav li").removeClass("selected");
    $(tabId + " .tab_nav li").eq(tabNum).addClass("selected");
    //根据参数决定显示内容
    $(tabId + " .tab_con").hide();
    $(tabId + " .tab_con").eq(tabNum).show();
}

//可以自动关闭的提示
function jsprint(msgtitle, url, msgcss, callback) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "pcent success";
            break;
        case "Error":
            cssname = "pcent error";
            break;
        default:
            cssname = "pcent warning";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
    var curriframe = "";
    $(itemiframe).each(function () {
        if ($(this).css("display") != "none") {
            curriframe = $(itemiframe).index($(this));
            return false;
        }
    });
    if (url == "back" && curriframe != "") {
        frames[curriframe].history.back(-1);
    } else if (url != "" && curriframe != "") {
        frames[curriframe].location.href = url;
    }
    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 3000);
    //执行回调函数
    if (typeof (callback) == "function") callback();
}

//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    if ($(chkobj).find("span b").text() == "全选") {
        $(chkobj).find("span b").text("取消");
        $(".checkall input").attr("checked", true);
    } else {
        $(chkobj).find("span b").text("全选");
        $(".checkall input").attr("checked", false);
    }
}

//执行回传函数
function ExePostBack(objId, objmsg) {
    if ($(".checkall input:checked").size() < 1) {
        $.ligerDialog.warn("对不起，请选中您要操作的记录！");
        return false;
    }
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    $.ligerDialog.confirm(msg, "提示信息", function (result) {
        if (result) {
            __doPostBack(objId, '');
        }
    });
    return false;
}

//关闭提示窗口
function CloseTip(objId) {
    $("#" + objId).hide();
}

//打开Dialog窗口
function openDialog(tit, sendUrl, w, h) {
    if (arguments.length == 3) {
        $.ligerDialog.open({ title: tit, url: sendUrl, width: w, isResize: true });
    } else if (arguments.length == 4) {
        $.ligerDialog.open({ title: tit, url: sendUrl, width: w, height: h, isResize: true });
    } else {
        $.ligerDialog.open({ title: tit, url: sendUrl, isResize: true });
    }
}

//只允许输入数字
function checkNumber(e) {
    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {  //FF 
        if (!((e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105) || (e.which == 8) || (e.which == 46)))
            return false;
    } else {
        if (!((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 8) || (event.keyCode == 46)))
            event.returnValue = false;
    }
}
//===========================系统管理JS函数结束================================

//================上传文件JS函数开始，需和jquery.form.js一起使用===============
//文件上传
function Upload(action, repath, uppath, isimage, iswater, isthumbnail, filepath) {
    //alert('开始上传');
    var sendUrl = "../../tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage;
    //判断是否打水印
    if (arguments.length == 5) {
        sendUrl = "../../tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage + "&IsWater=" + iswater;
    }
    //判断是否生成宿略图
    if (arguments.length == 6) {
        sendUrl = "../../tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //自定义上传路径
    if (arguments.length == 7) {
        sendUrl = filepath + "tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
    }
    //alert('开始提交');
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + repath).nextAll(".files").eq(0).hide();
            //显示LOADING图片
            $("#" + repath).nextAll(".uploading").eq(0).show();
            //alert('ready');
        },
        success: function (data, textStatus) {
            //alert('success!!');
            if (data.msg == 1) {
                $("#" + repath).val(data.msgbox);
                
                    
            } else {
                alert(data.msgbox);
            }
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        url: sendUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

//新闻word导入上传
function WordExtractUpload(uppath, callback) {
    var submitUrl = "/tools/upload_ajax.ashx?action=WordExtract&UpFilePath=" + uppath;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + uppath).parent().hide();
            //显示LOADING图片
            $("#" + uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                callback(decodeURIComponent(data.msgbox));
                //alert(data.mstitle);
            } else {
                alert(decodeURIComponent(data.msgbox));
            }
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，原因：" + e);
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

//附件上传
function AttachUpload(repath, uppath) {
    var submitUrl = "../../tools/upload_ajax.ashx?action=AttachFile&UpFilePath=" + uppath;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + uppath).parent().hide();
            //显示LOADING图片
            $("#" + uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                var listBox = $("#" + repath + " ul");
                var newLi = '<li>'
                + '<input name="hidFileName" type="hidden" value="0|' + data.mstitle + "|" + data.msgbox + '" />'
                + '<b class="close" title="删除" onclick="DelAttachLi(this);"></b>'
                //+ '<span class="right">下载积分：<input name="txtPoint" type="text" class="input2" value="0" onkeydown="return checkNumber(event);" /></span>'
                + '<span class="title">附件：' + data.mstitle + '</span>'
                //+ '<span>人气：0</span>'
                + '<a href="javascript:;" class="upfile"><input type="file" name="FileUpdate" onchange="AttachUpdate(\'hidFileName\',this);" /></a>'
                + '<span class="uploading">正在更新...</span>'
                + '</li>';
                listBox.append(newLi);
                //alert(data.mstitle);
            } else {
                alert(data.msgbox);
            }
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().nextAll(".uploading").eq(0).hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//更新附件上传
function AttachUpdate(repath, uppath) {
    var btnOldName = $(uppath).attr("name");
    var btnNewName = "NewFileUpdate";
    $(uppath).attr("name", btnNewName);
    var submitUrl = "../../tools/upload_ajax.ashx?action=AttachFile&UpFilePath=" + btnNewName;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $(uppath).parent().hide();
            //显示LOADING图片
            $(uppath).parent().nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                var ArrFileName = $(uppath).parent().prevAll("input[name='" + repath + "']").val().split("|");
                $(uppath).parent().prevAll("input[name='" + repath + "']").val(ArrFileName[0] + "|" + data.mstitle + "|" + data.msgbox);
                $(uppath).parent().prevAll(".title").html("附件：" + data.mstitle);
            } else {
                alert(data.msgbox);
            }
            $(uppath).parent().show();
            $(uppath).parent().nextAll(".uploading").eq(0).hide();
            $(uppath).attr("name", btnOldName);
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $(uppath).parent().show();
            $(uppath).parent().nextAll(".uploading").eq(0).hide();
            $(uppath).attr("name", btnOldName);
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//===========================上传文件JS函数结束================================

//添加选项
function AddCustomItem(listId, type, title, content,sortId) {
    var listBox = $("#" + listId + " ul");
    var newLi = '<li>'
        + '<input name="hidItemName" type="hidden" value="' + type + '|' + title + '|' + sortId + '|' + content + '" />'
        + '<b class="close" title="删除" onclick="DelAttachLi(this);"></b>'
        + '<div ><span style="float:left;">(排序:<b style="color:red;">'+sortId+'</b>)' + title+'：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    switch (type) {
        case "radio":
             itemTextList = content.split(";");
            for ( i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "checkbox":
             itemTextList = content.split(";");
            for ( i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "input":
            newLi += '<input id="input'+idRnd+'" type="text" value="'+content+'" />';
            break;
        case "textarea":
            newLi += '<textarea style="width: 400px; height: 50px;" >'+content+'</textarea>';
            break;
        case "time":
            newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "file":
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
            default:
                break;
    }
    newLi += '<div style="clear:left;"></div></div></li>';
    //console.log(newLi);
    listBox.append(newLi);
    //alert(data.mstitle);
};


////===========================禁用鼠标右键====================================

//document.onkeydown = function () {
//    /*if(event.keyCode==116)  
//    {   
//    event.keyCode=0;   
//    event.returnValue   =   false;   
//    }   */
//    //屏蔽退格删除键,屏蔽   F5   刷新键,Ctrl   +   R   
//    if ((event.keyCode == 116) || (event.ctrlKey && event.keyCode == 82)) {
//        event.keyCode = 0;
//        event.returnValue = false;
//    }
//}
//document.oncontextmenu = function () { event.returnValue = false; }
////=========================禁用鼠标右键 结束====================================

////====================下载app二维码===================
//下载按钮样式
function changeAppQrcode(nodeId, os, tabNum, imgNode) {
    //设置点击后的切换样式
    $(nodeId + " a").removeClass("selected");
    $(nodeId + " a").eq(tabNum).addClass("selected");
    //切换二维码
    var imgSrc = "/admin/images/images_index/qrcode_" + os + ".png";
    $(imgNode).attr("src", imgSrc);
}

////==================news tabs===========
//Center Tab控制函数
function newsTabs(tabId, tabNum,node) {
    //设置点击后的切换样式
    $(node).parent().parent().find("li").removeClass("selected");
    $(node).parent().addClass("selected");
    //$(".tab_nav li").removeClass("selected");
    //$(".tab_nav li").eq(tabNum).addClass("selected");
    //根据参数决定显示内容
    $(tabId + " .tab_con").hide();
    $(tabId + " .tab_con").eq(tabNum).show();
    //判断是否需要加载数据
    var newsCnt = $(tabId + " .tab_con").eq(tabNum).find(".news_list").children().length;
    if (newsCnt == 0) {
        getNews(tabId, tabNum, 1,0);
    }
}
function lastPages(node, tabNum, tabId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    getNews(tabId, tabNum, page - 1, newsid);
}
function nextPages(node, tabNum,tabId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    getNews(tabId, tabNum, page + 1, newsid);
    //$(node).parent().parent().find(".page_text  b").html(page+1);
}
function getNews(tabId, tabNum, page,newsid) {
    var submitUrl = "../../admin/NewsApi/news_ajax.ashx?action=getNews&type=" + tabNum + "&page=" + page + "&newsid="+newsid;
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
             $(tabId + " .tab_con").eq(tabNum).hide();
             $(tabId + " .load_layer").eq(0).show();
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                var ul = $(tabId + " .tab_con").eq(tabNum).find(".news_list");
                ul.empty();
                if (resultJson.NewsList.length > 0) {
                    for (var i = 0; i < resultJson.NewsList.length; i++) {
                        var sliceIndex = resultJson.NewsList[i].ChnName.indexOf("|");
                        var top = "";
                        if (tabNum!=0&&resultJson.NewsList[i].IsTop == 1) {
                            top = '<b style="color:red;">【置顶】</b>';
                        }
                        var li = '<li>'              
                            + ' <div class="left">'
                            + ' <img class="news_icon" src="' + resultJson.NewsList[i].Pic + '" />'
                            + '</div>'
                            + '<div class="left news_list_con">'
                            + '<p class="news_title">'
                            + '<a href="' + resultJson.NewsList[i].Link + '" target="_blank">'
                            + top+resultJson.NewsList[i].Title
                            + '</a></p>'
                            + '<p class="news_des">'
                            +'<a href="/admin/CenterPage/news_list.aspx?id='+resultJson.NewsList[i].ChnName.substring(0,sliceIndex)+'">'+ resultJson.NewsList[i].ChnName.substring(sliceIndex+1)+'</a>'
                            + '&nbsp;&nbsp;发布时间：'+resultJson.NewsList[i].Date
                            + '</p>'
                            + '</div><div class="clear"></div>'
                            + '</li>';
                        ul.append(li);
                    }
                }
                //设置页码
                $(tabId + " .tab_con").eq(tabNum).find(".page_text  b").html(page);
                $(tabId + " .tab_con").eq(tabNum).find(".last").show();
                $(tabId + " .tab_con").eq(tabNum).find(".next").show();
                if (page == 1) {
                    $(tabId + " .tab_con").eq(tabNum).find(".last").hide();
                }
                if (resultJson.NewsList.length == 0 ) {
                    ul.append("<li>无信息资讯，您可以登录圈圈校园APP订阅资讯！</li>");
                }
                if (ul.children().length < 10) {
                    $(tabId + " .tab_con").eq(tabNum).find(".next").hide();
                }
                //全部不显示页码
                if (tabNum == 0) {
                    $(tabId + " .tab_con").eq(tabNum).find(".last").hide();
                    $(tabId + " .tab_con").eq(tabNum).find(".next").hide();
                    $(tabId + " .tab_con").eq(tabNum).find(".page_text").hide();
                }
                $(tabId + " .tab_con").eq(tabNum).show();
                $(tabId + " .load_layer").eq(0).hide();
            }
        },
        error: function (data, status, e) {
            $(tabId + " .tab_con").eq(tabNum).show();
            $(tabId + " .load_layer").eq(0).hide();
            //alert("信息加载失败：" + e);
        },
        cache: false
    });
}

//List Tab控制函数
function newsTypeTabs(tabId, typeId, node) {
    //设置点击后的切换样式
    //$("txtKeywords").val("");
    $(node).parent().parent().find("li").removeClass("selected");
    $(node).parent().addClass("selected");
    getNewsForList(tabId, typeId, 1, 0);

}
function lastPagesForList(node, tabId,navId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    var typeId = $(navId + " .tab_nav .selected").find('input[name=typeId]').val();
    getNewsForList(tabId, typeId,page - 1, newsid);
}
function nextPagesForList(node, tabId,navId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    var typeId = $(navId + " .tab_nav .selected").find('input[name=typeId]').val();
    //console.log(typeId);
    getNewsForList(tabId, typeId,page + 1, newsid);
    //$(node).parent().parent().find(".page_text  b").html(page+1);
}
function getNewsForList(tabId, typeId, page, newsid) {
    var keyWord = $("#txtKeywords").val().replace(/\"|\'|\||\<|\>/g, "");
    var submitUrl = "../../admin/NewsApi/news_ajax.ashx?action=getTypeNews&type=" + typeId + "&page=" + page + "&newsid=" + newsid+"&k="+encodeURIComponent(keyWord);
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
            $(tabId + " .tab_con").hide();
            $(tabId + " .load_layer").eq(0).show();
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                var ul = $(tabId + " .tab_con").find(".news_list");
                ul.empty();
                if (resultJson.NewsList.length > 0) {
                    for (var i = 0; i < resultJson.NewsList.length; i++) {
                        var sliceIndex = resultJson.NewsList[i].ChnName.indexOf("|");
                        var top = "";
                        if (resultJson.NewsList[i].IsTop == 1) {
                            top = '<b style="color:red;">【置顶】</b>';
                        }
                        var li = '<li>'
                            + ' <div class="left">'
                            + ' <img class="news_icon" src="' + resultJson.NewsList[i].Pic + '" />'
                            + '</div>'
                            + '<div class="left news_list_con">'
                            + '<p class="news_title">'
                            + '<a href="' + resultJson.NewsList[i].Link + '" target="_blank">'
                            + top+resultJson.NewsList[i].Title
                            + '</a></p>'
                            + '<p class="news_des">'
                            +  resultJson.NewsList[i].ChnName.substring(sliceIndex + 1)
                            + '&nbsp;&nbsp;发布时间：' + resultJson.NewsList[i].Date
                            + '</p>'
                            + '</div>'
                            + '</li>';
                        ul.append(li);
                    }
                }
                //设置页码
                $(tabId + " .tab_con").find(".page_text  b").html(page);
                $(tabId + " .tab_con").find(".last").show();
                $(tabId + " .tab_con").find(".next").show();
                if (page == 1) {
                    $(tabId + " .tab_con").find(".last").hide();
                }
                if (resultJson.NewsList.length == 0) {
                    var hint = "无信息资讯记录，您可以登录圈圈校园APP订阅资讯！";
                    if (keyWord != "")
                        hint = "无搜索到相关记录！";
                    ul.append("<li>"+hint+"</li>");
                }
                if (ul.children().length < 10) {
                    $(tabId + " .tab_con").find(".next").hide();
                }
               //显示
                $(tabId + " .tab_con").show();
                $(tabId + " .load_layer").eq(0).hide();
            }
        },
        error: function (data, status, e) {
            $(tabId + " .tab_con").show();
            $(tabId + " .load_layer").eq(0).hide();
            alert("信息加载失败：" + e);
        },
        cache: false
    });
}
////==================快速入口================
function showShortAccess() {
    var submitUrl = "../../admin/ShortAccess/shortaccess_ajax.ashx?action=getAccess";
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            var selectedUl = $("#selectedList");
            var unSelectedUl = $("#unselectedList");
            selectedUl.empty();
            unSelectedUl.empty();
            if (resultJson.ErrCode == 200) {
                var i = 0, li = '';
                for (i = 0; i < resultJson.UnSelectedList.length; i++) {
                    li='<li>'
                    +'<div class="item_unselected" onclick="selecteItem(this)">'
                    +'<input type="checkbox" style="float:right;" />'
                    +'<p class="item_title">'+resultJson.UnSelectedList[i].Title+'</p>'
                    + '<p class="item_text">目录:' + resultJson.UnSelectedList[i].Path + '</p>'
                    +'<input type="hidden" name="item_id" value="'+resultJson.UnSelectedList[i].Id+'" />'
                    +'</div>'
                    + '</li>';
                    unSelectedUl.append(li);
                }
                for (i = 0; i < resultJson.SelectedList.length; i++) {
                    li='<li>'
                    +'<div class="item_selected">'
                    + '<p class="item_title">' + resultJson.SelectedList[i].Title + '</p>'
                    + '<p class="item_text">目录:' + resultJson.SelectedList[i].Path + '</p>'
                    + '<p class="item_op"><a href="javascript:;" class="prev" onclick="prevItem(this)"></a><a href="javascript:;" class="top" onclick="topItem(this)"></a><a href="javascript:;" class="delete" onclick="deleteItem(this)"></a></p>'
                    +'<div class="clear"></div>'
                    + '<input type="hidden" name="item_id" value="' + resultJson.SelectedList[i].Id + '" />'
                    +'</div>'
                    + '</li>';
                    selectedUl.append(li);
                }
            }
            if (unSelectedUl.children().length == 0) {
                unSelectedUl.append("<li id='unselected_null'>暂无可添加的快速入口！</li>");
            }
            if (selectedUl.children().length == 0) {
                selectedUl.append("<li id='selected_null'>您还未添加快速入口！</li>");
            }
        },
        error: function (data, status, e) {

            //alert("信息加载失败：" + e);
        },
        cache: false
    });
}
function saveShortAccess() {
    var selectedUl = $("#selectedList");
    if ($("#selected_null").length == 0 && selectedUl.children().length > 0) {
        var datas = [];
        selectedUl.children().each(function(i, n) {
            var data = {};
            var id = $(n).find('input[name=item_id]').val();
            data["id"] = id;
            data["sort_id"] = i+1;
            datas.push(data);
        });
        var jsonString = JSON.stringify(datas);
        saveShortAccessAjax(jsonString);
    } else {
        parent.jsprint("请您添加快速入口后再保存！", "", "Warning");
    }
}
function saveShortAccessAjax(jsonData) {
    var submitUrl = "../../admin/ShortAccess/shortaccess_ajax.ashx?action=saveAccess";
    //开始提交
    $.ajax({
        url: submitUrl,
        type: "POST",
        data:"data="+encodeURIComponent(jsonData),
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                parent.jsprint("保存成功！", "", "Success");
            } else {
                parent.jsprint("保存失败！", "", "Success");
            }
        },
        error: function (data, status, e) {

            alert("保存失败：" + e);
        },
        cache: false
    });
}
function prevItem(node) {
    if ($(node).parent().parent().parent().prev()) {
        $(node).parent().parent().parent().insertBefore($(node).parent().parent().parent().prev());
    }
}
function topItem(node) {
    var selectedUl = $("#selectedList");
    selectedUl.prepend($(node).parent().parent().parent());
}
function deleteItem(node) {
    var selectedUl = $("#selectedList");
    var unSelectedUl = $("#unselectedList");
    var title = $(node).parent().parent().find(".item_title").html();
    var text = $(node).parent().parent().find(".item_text").html();
    var id = $(node).parent().parent().find('input[name=item_id]').val();
    $(node).parent().parent().parent().remove();
    var li = '<li>'
                   + '<div class="item_unselected" onclick="selecteItem(this)">'
                   + '<input type="checkbox" style="float:right;" />'
                   + '<p class="item_title">' + title + '</p>'
                   + '<p class="item_text">' + text + '</p>'
                   + '<input type="hidden" name="item_id" value="' + id + '" />'
                   + '</div>'
                   + '</li>';
    unSelectedUl.append(li);
    if ($("#unselected_null").length > 0) {
        $("#unselected_null").remove();
    }
    if (selectedUl.children().length == 0) {
        selectedUl.append("<li id='selected_null'>您还未添加快速入口！</li>");
    }
}
function selecteItem(node) {
    var selectedUl = $("#selectedList");
    var unSelectedUl = $("#unselectedList");
    var title = $(node).find(".item_title").html();
    var text = $(node).find(".item_text").html();
    var id = $(node).find('input[name=item_id]').val();
    $(node).parent().remove();
    var li = '<li>'
                   + '<div class="item_selected">'
                   + '<p class="item_title">' + title + '</p>'
                   + '<p class="item_text">' + text + '</p>'
                   + '<p class="item_op"><a href="javascript:;" class="prev" onclick="prevItem(this)"></a><a href="javascript:;" class="top" onclick="topItem(this)"></a><a href="javascript:;" class="delete" onclick="deleteItem(this)"></a></p>'
                   + '<div class="clear"></div>'
                   + '<input type="hidden" name="item_id" value="' + id + '" />'
                   + '</div>'
                   + '</li>';
    selectedUl.append(li);
    if ($("#selected_null").length>0) {
        $("#selected_null").remove();
    }
    if (unSelectedUl.children().length == 0) {
        unSelectedUl.append("<li id='unselected_null'>暂无可添加的快速入口！</li>");
    }
}
function showUserAccess() {
    var submitUrl = "../../admin/ShortAccess/shortaccess_ajax.ashx?action=getUserAccess";
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            var selectedUl = $("#access_list");
            selectedUl.empty();
            if (resultJson.ErrCode == 200) {
                var i = 0, li = '';
                for (i = 0; i < resultJson.SelectedList.length; i++) {
                    li = '<li>'
                    + '<a href="' + resultJson.SelectedList[i].Url + '">'
                    + resultJson.SelectedList[i].Title 
                    + '</a>'
                    + '</li>';
                    selectedUl.append(li);
                }
                if (resultJson.IsRec == 1 && resultJson.SelectedList.length>0) {
                    $("<p>您可能喜欢：<p>").insertBefore(selectedUl);
                }
                if (resultJson.SelectedList.length == 0) {
                    selectedUl.append("<li>暂无快速入口！</li>");
                }
            }
        },
        error: function (data, status, e) {

            //alert("快速入口加载失败：" + e);
        },
        cache: false
    });
}
function showUserNotice() {
    var submitUrl = "../../admin/NewsPush/AjaxPushHandler.ashx?action=getUserNotice";
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            var selectedUl = $("#notice_list");
            selectedUl.empty();
            if (resultJson.Result == 200) {
                var i = 0, li = '';
                for (i = 0; i < resultJson.NoticeList.length&&i<3; i++) {
                    li = '<li onclick="showNoticeInfo(this)">'
                        +'<div class="notice_title" >'
                        +'<p class="left">'+resultJson.NoticeList[i].From+'：</p>'
                        +'<p class="right notice_time">'+resultJson.NoticeList[i].Date+'</p>'
                        +'</div>'
                        +'<div class="notice_con">'+resultJson.NoticeList[i].Content+'</div>'
                        + '</li>';
                    selectedUl.append(li);
                }
                if (resultJson.NoticeList.length == 0) {
                    selectedUl.append("<li>暂无通知消息！</li>");
                }
            }
        },
        error: function (data, status, e) {

            //alert("通知消息加载失败：" + e);
        },
        cache: false
    });


}