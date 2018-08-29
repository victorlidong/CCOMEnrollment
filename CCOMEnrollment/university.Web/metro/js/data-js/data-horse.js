//*university后台管理页JS函数，Jquery扩展
//*作者：一些事情
//*时间：2012年02月20日

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


function newsFetch(listId, typeId, page, newsid) {
    var submitUrl = "/admin/NewsApi/news_ajax.ashx?action=getNews&type=" + typeId + "&page=" + page + "&newsid=" + newsid;
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
            $(listId).hide();
            $(listId+"LoadLayer").show();
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                var ul = $(listId);
                ul.empty();
                if (resultJson.NewsList.length > 0) {
                    for (var i = 0; i < resultJson.NewsList.length&&i<10; i++) {
                        var sliceIndex = resultJson.NewsList[i].ChnName.indexOf("|");
                        var top = "";
                        if (resultJson.NewsList[i].IsTop == 1) {// typeId != 0
                            top = '<b style="color:red;">【置顶】</b>';
                        }
                        var li = '<li>'              
                            + ' <div class="media">'
                            + '<span class="label pull-left news-bg">'
                            + '<img class="img-circle" src="' + resultJson.NewsList[i].Pic + '" alt="新闻" style="width: 40px;height:40px;" />'
                            //+ '<img class="img-circle" src="' + resultJson.NewsList[i].Pic + '" alt="新闻" style="width: 50px;height:50px;" />'  孙晨光
                            +' </span>'
                            + '<div class="media-body">'
                            + '<p class="text news-title">'
                            + '<a href="' + resultJson.NewsList[i].Link + '" target="_blank">'
                            + top+resultJson.NewsList[i].Title
                            + '</a></p>'
                            + '<span>'
                            +'<a href="/adminmetro/CenterPage/news_list.aspx?id='+resultJson.NewsList[i].ChnName.substring(0,sliceIndex)+'">'+ resultJson.NewsList[i].ChnName.substring(sliceIndex+1)+'</a>'
                            + '&nbsp;&nbsp;发布时间：' + resultJson.NewsList[i].Date
                            + '</span>'
                            + '</div></div>'
                            + '</li>';
                        ul.append(li);
                    }
                }
                //设置页码
                if (resultJson.NewsList.length == 0 ) {
                    ul.append("<li>暂无资讯。</li>");
                }
                $(listId).show();
                $(listId+"LoadLayer").hide();
            }
        },
        error: function (data, status, e) {
            $(listId).show();
            $(listId).prev().hide();
            //alert("信息加载失败：" + e);
        },
        cache: false
    });
}


  

//新闻首页 List Tab控制函数
function newsTypeTabs(listId, typeId, node) {
    //设置点击后的切换样式
    //$("txtKeywords").val("");
    $(node).parent().children("a.btn-success").removeClass("btn-success");
    $(node).addClass("btn-success");
    
    getNewsForList(listId, typeId, -1, 0);
  

}
function lastPagesForList(node, listId,navId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    var subTypeId = $(navId + " a.btn-success").prev().val();
    page = page - 1;
    if (page < 1)
        page = 1;
    getNewsForList(listId, subTypeId, page, newsid);
}
function nextPagesForList(node, listId, navId) {
    var page = $(node).parent().parent().find(".page_text  b").html();
    page = parseInt(page);
    var newsid = 0;
    var subTypeId = $(navId + " a.btn-success").prev().val();
    getNewsForList(listId, subTypeId, page + 1, newsid);
}


function getNewsForList(listId, typeId, page, newsid) {
    //alert(listId + typeId + 'xcd');
    var keyWord = "";
    if ($("#txtKeywords").length>0)
        var keyWord = $("#txtKeywords").val().replace(/\"|\'|\||\<|\>/g, "");
    var submitUrl = "/admin/NewsApi/news_ajax.ashx?action=getTypeNews&type=" + typeId + "&page=" + page + "&newsid=" + newsid+"&k="+encodeURIComponent(keyWord);
    //alert(listId + typeId+'xcd');
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
            $(listId).hide();
            $(listId).prev().show();
           // $("#divNewsPage").hide();
        },
        success: function (data) {
            //alert(data);
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                var ul = $(listId);
                ul.empty();
                if (resultJson.NewsList.length > 0) {
                    for (var i = 0; i < resultJson.NewsList.length; i++) {
                        var sliceIndex = resultJson.NewsList[i].ChnName.indexOf("|");
                        var top = "",linkColor="";
                        if (resultJson.NewsList[i].IsTop == 1) {
                            top = '<b style="color:red;">【置顶】</b>';
                        }
                        if (resultJson.NewsList[i].IsRead == 1)
                        {
                            if(resultJson.NewsList[i].IsTop != 1)
                                linkColor = "#bbbbbb";
                            //置顶且已读
                            else
                                linkColor = "#bbbbbb";
                        }
                        //if (resultJson.NewsList[i].IsRead ==1)
                            
                        
                 

                        var li = '<li>'
                          + ' <div class="media">'
                          + '<span class="label pull-left news-bg">'
                          + '<img class="img-circle" src="' + resultJson.NewsList[i].Pic + '" alt="新闻" style="width: 40px;height:40px;" />'
                          + ' </span>'
                          + '<div class="media-body">'
                          + '<p class="text news-title">'
                          + '<a style="color:'+linkColor+'" href="' + resultJson.NewsList[i].Link + '" target="_blank">'
                          + top + resultJson.NewsList[i].Title
                          + '</a></p>'
                          + '<span>'
                          //+ '<a href="/adminmetro/CenterPage/news_list.aspx?id=' + resultJson.NewsList[i].ChnName.substring(0, sliceIndex) + '">' + resultJson.NewsList[i].ChnName.substring(sliceIndex + 1) + '</a>'
                          +  resultJson.NewsList[i].ChnName.substring(sliceIndex + 1) 
                          + '&nbsp;&nbsp;发布时间：' + resultJson.NewsList[i].Date
                          + '</span>'
                          + '</div></div>'
                          + '</li>';
                        ul.append(li);
                    }
                }
                //设置页码
                //$("#divNewsPage").find(".page_text  b").html(page);
                //$("#divNewsPage").find(".last").show();
                //$("#divNewsPage").find(".next").show();
                //if (page == 1) {
                //    $("#divNewsPage").find(".last").hide();
                //}
                var hasPage = true;
                if (resultJson.NewsList.length == 0) {
                    var hint = "<p style='padding:5px 5px;'>无资讯记录！<p>";
                    if (keyWord != "")
                        hint = "<p style='padding:5px 5px;'>无搜索到相关记录！<p>";
                    ul.append("<li>" + hint + "</li>");
                    hasPage = false;
                }
                //if (ul.children().length < 10) {
                //    $("#divNewsPage").find(".next").hide();
                //}
               //显示
                $(listId).show();
                $(listId).prev().hide();
                if(hasPage)
                    showNewsPage(typeId, page, newsid, keyWord);
                //$("#divNewsPage").show();
            }
        },
        error: function (data, status, e) {
            $(listId).show();
            $(listId).prev().hide();
            alert("资讯加载失败！");
        },
        cache: false
    });
}
function showNewsPage(typeId, page, newsid, keyWord) {
    var submitUrl = "/admin/NewsApi/news_ajax.ashx?action=getTypeNewsPage&type=" + typeId + "&page=" + page + "&newsid=" + newsid + "&k=" + encodeURIComponent(keyWord);
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
    
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                var pageStr = resultJson.PageStr;
                if (pageStr != "") {
                    pageStr = decodeURIComponent(pageStr);
                    pageStr = pageStr.replace(/\+/g, " ");
                    $("#PageContent").html(pageStr);
                    $("#divNewsPage").show();
                    $("body").scrollTop(0);
                }
            }
        },
        cache: false
    });
}
//==================end for news tabs===========

////==================通知================
function showUserNotice() {
    var submitUrl = "/AdminMetro/OA_NoticePush/AjaxPushHandler.ashx?action=getUserNotice";
    //开始提交
    $.ajax({
        url: submitUrl,
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            console.log(data);
           
            var resultJson = eval("(" + data + ")");
            
            var selectedUl = $("#notice_list");
            selectedUl.empty();
            if (resultJson.Result == 200) {
                var i = 0, li = '';
                var notice, content = '',linkColor='';
                for (i = 0; i < resultJson.NoticeList.length && i < 10; i++) {
                    notice = resultJson.NoticeList[i];
                    
                    if (notice.IsRead=="true")
                        linkColor = "#bbbbbb";
                    //alert(notice.IsRead);

                    if (notice.Type == 1) {
                        content = "<a style=\"color:"+linkColor+"\" href=\"/home/push/push.aspx?id=" + notice.Id + "\" target=\"_blank\">";
                        content += notice.Title + "</a>";
                        
                        content += "<br />";
                        content += notice.Content;
                    } else
                    {
                        content = "<a style=\"color:" + linkColor + "\" href=\"/home/push/push.aspx?id=" + notice.Id + "\" target=\"_blank\">";
                        content += notice.Content;
                        content += "</a>";
                    }
                    

                    if (notice.Type == 1)
                        abbrContent = notice.Title;
                    else
                        abbrContent = notice.Content;

                    if (abbrContent.length > 30) {
                        abbrContent = abbrContent.substring(0, 30) + "...";
                    }

                    li = '<li>'
                    + '<div class="media">'
                    + '<span class="label pull-left label-success"><i class="icon-bell" style="font-size:26px;"></i></span>'
                    + '<div class="media-body">'
                    + '<div class="notice-toggle notice_title"  style="display:block; padding:0px 10px 0px 5px; font-size:14px; font-weight:normal;">'
                    + '<p class="text" style="margin:2px 0 5px;">'
                    + "<a  style=\"color:" + linkColor + "\" href=\"/home/push/push.aspx?id=" + notice.Id + "\" target=\"_blank\">" + abbrContent + '</a></p>'
                    + '<span>' + notice.From + '&nbsp;&nbsp; ' + notice.Date + '</span>'
                    + '</div>'
                    + '<div class="notice-collapse" style="display: none; padding: 5px;">'
                    + '<p class="notice-close pull-right"><i class="icon-double-angle-up"></i>收起</p>'
                    + '<div class="text" style="font-size:14px;">'
                    + '<p style="padding-right:40px;">' + content + '</p>'
                    + '<span class="attribution" >' + notice.From + '&nbsp;&nbsp; ' + notice.Date + '</span>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</li>';
                    selectedUl.append(li);
                }
                if (resultJson.NoticeList.length == 0) {
                    selectedUl.append("<li>暂无通知消息！</li>");
                }
                noticeSetting();
            }
        },
        error: function (data, status, e) {
            //alert("通知消息加载失败：" + e);
        },
        cache: false
    });
}
/*
function showUserNotice() {
    var submitUrl = "/admin/NewsPush/AjaxPushHandler.ashx?action=getUserNotice";
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
                for (i = 0; i < resultJson.NoticeList.length&&i<11; i++) {
                    var abbrContent = resultJson.NoticeList[i].Content;
                    if (abbrContent.length > 20) {
                        abbrContent = abbrContent.substring(0, 20) + "...";
                    }
                    li = '<li>'
                    + '<div class="media">'
                    + '<span class="label pull-left label-success"><i class="icon-bell"></i></span>'
                    + '<div class="media-body">'
                    + '<div class="notice-toggle notice_title"  style="display: block; ">'
                    + '<span>'+abbrContent+'</span>'
                    + '<span class="pull-right small italic ">'+resultJson.NoticeList[i].Date+'</span>'
                    + '</div>'
                    + '<div class="notice-collapse" style="display: none; padding: 5px;">'
                    + '<p class="notice-close pull-right"><i class="icon-double-angle-up"></i>收起</p>'
                    + '<div class="text msg-in">'
                    + '  <p style="padding-right:40px;font-weight:bold;">'+resultJson.NoticeList[i].Content+'</p>'
                    + ' <p class="attribution" >' + resultJson.NoticeList[i].From + '&nbsp;&nbsp; ' + resultJson.NoticeList[i].Date + '</p>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</li>';
                    selectedUl.append(li);
                }
                if (resultJson.NoticeList.length == 0) {
                    selectedUl.append("<li>暂无通知消息！</li>");
                }
                noticeSetting();
            }
        },
        error: function (data, status, e) {
            //alert("通知消息加载失败：" + e);
        },
        cache: false
    });
}
*/
////==================end for 通知===========

////==================校园活动================
function showActivity() {
    var submitUrl = "/AdminMetro/activitynew/AjaxActivity.ashx?action=aalist";
    //开始提交
    $.ajax({
        url: submitUrl,
        type:'get',
        beforeSend: function () {
            // Handle the beforeSend event
        },
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            //console.log(resultJson);
            var selectedUl = $("#activity_list");
            selectedUl.empty();
            if (resultJson != null && resultJson.list_activity != null) {
                var i = 0, li = '', dis='';
                //{
                //    "list_activity": [
                //        {
                //            "aaid": "",
                //            "aaname": "",
                //            "aaorganizer": "",
                //            "aaaddress": "",
                //            "aasignupendtime": "",
                //            "aabegintime": ""
                //        }
                //    ]
                //}
                for (i = 0; i < resultJson.list_activity.length && i < 6; i++) {
                    if (i == 0) {
                        dis = 'block';
                    }
                    else {
                        dis = 'none';
                    }
                    var aaname = resultJson.list_activity[i].aaname;
                    if (aaname.length > 30) {
                        aaname = aaname.substring(0, 30) + "...";
                    }


                    li = '<li id="activity_' + resultJson.list_activity[i].aaid + '">'
                    + '<div class="media">'
                    + '<div class="media-body">'
                    + '<div class="notice-toggle notice_title"  style="display: block;">'
                    + '<span style="font-weight:normal;color:#4a8bc2;font-size:14px;"><a style="font-weight:normal;font-size:14px;" href="/AdminMetro/activitynew/Ac_ActivityDetail.aspx?aaid=' + resultJson.list_activity[i].aaid + '" target="_blank">' + aaname + '</a></span>'
                    + '</div>'
                    + '<div class="notice-collapse" style="display: ' + dis + '; padding: 0px 5px 5px 5px;">'
                    + '<span><i class="icon-user"></i> ' + resultJson.list_activity[i].aaorganizer + '</span><span style="width:40px;display:inline-block;"></span>'
                    + '<span><i class="icon-map-marker"></i> ' + resultJson.list_activity[i].aaaddress + '，' + resultJson.list_activity[i].aabegintime + '</span><span style="width:40px;display:inline-block;"></span>'
                    + '<span><i class="icon-calendar"></i> ' + resultJson.list_activity[i].aasignupendtime + ' 报名截止</span>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</li>';
                    selectedUl.append(li);
                }
                if (resultJson.list_activity.length == 0) {
                    selectedUl.append("<li>暂无校园活动！</li>");
                }
            }
        },
        error: function (data, status, e) {
            //alert("通知消息加载失败：" + e);
        },
        cache: false
    });
}
////==================end for 校园活动===========

/////===========upload====================

//================上传文件JS函数开始，需和jquery.form.js一起使用===============
//带回调的文件上传
function CallBackUpload(action, repath, uppath, isimage, callback) {
    //alert('开始上传');
    var sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage;
    //alert('开始提交');
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + repath).nextAll(".btn").eq(0).hide();
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
            $("#" + repath).nextAll(".btn").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
            //console.log($("#" + repath).val());
            callback();
        },
        error: function (data, status, e) {
            alert("网络异常，上传失败，您可以再次尝试或更换浏览器试一下。");
            $("#" + repath).nextAll(".btn").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        url: sendUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

//文件上传
function Upload(action, repath, uppath, isimage, iswater, isthumbnail, filepath) {
    //alert('开始上传');
    var sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage;
    //判断是否打水印
    if (arguments.length == 5) {
        sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage + "&IsWater=" + iswater;
    }
    //判断是否生成宿略图
    if (arguments.length == 6) {
        sendUrl = "/tools/upload_ajax.ashx?action=" + action + "&ReFilePath=" + repath + "&UpFilePath=" + uppath + "&IsImage=" + isimage + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail;
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
            $("#" + repath).nextAll(".btn").eq(0).hide();
            //显示LOADING图片
            $("#" + repath).nextAll(".uploading").eq(0).show();
            //alert('ready');
        },
        success: function (data, textStatus) {
            //alert('success!!');
            if (data.msg == 1) {
                $("#" + repath).val(data.msgbox);
                if($("#face").length>0)
                {
                    $("#face").attr('src', data.msgbox);
                }
            } else {
                alert(data.msgbox);
            }
            $("#" + repath).nextAll(".btn").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("网络异常，上传失败，您可以再次尝试或更换浏览器试一下。");
            $("#" + repath).nextAll(".btn").eq(0).show();
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
                //+ '<b class="close" title="删除" onclick="DelAttachLi(this);"></b>'
                //+ '<span class="right">下载积分：<input name="txtPoint" type="text" class="input2" value="0" onkeydown="return checkNumber(event);" /></span>'
                + '<span class="title">附件：' + data.mstitle + '</span>'
                + '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove"></a>'
                //+ '<span>人气：0</span>'
                //+ '<a href="javascript:;" class="upfile"><input type="file" name="FileUpdate" onchange="AttachUpdate(\'hidFileName\',this);" /></a>'
                //+ '<span class="uploading">正在更新...</span>'
                + '</li>';
                listBox.append(newLi);
            } else {
                alert(data.msgbox);
            }
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().next().hide();
 
        },
        error: function (data, status, e) {
            alert("网络异常，上传失败，您可以再次尝试或更换浏览器试一下。" );
            $("#" + uppath).parent().show();
            $("#" + uppath).parent().next().hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};

/////===========end upload====================

//添加自定义申报选项
function AddCustomItem(listId, type, title, content, sortId) {
    var listBox = $("#" + listId + " ul");
    var newLi = '<li style="margin:5px 0;">'
        + '<input name="hidItemName" type="hidden" value="' + type + '|' + title + '|' + sortId + '|' + content + '" />'
        //+ '<b class="close" title="删除" onclick="DelAttachLi(this);"></b>'
        + '<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove"></a>&nbsp;&nbsp;'
        + '<span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title + '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case "radio":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "checkbox":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "input":
            newLi += '<input placeholder="'+content+'" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "textarea":
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case "time":
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "file":
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }

    newLi += '</li>';
    //console.log(newLi);
    listBox.append(newLi);
    //alert(data.mstitle);
};