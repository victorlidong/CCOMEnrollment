
/*****************metro 首页通知效果****************/
function noticeSetting() {
    //notice-collapse:false
    noticeCollapse(".notice-collapse", false);
    //显示
    $(".notice-toggle").click(function () {
        $(".notice-collapse").stop(false, true);
        $(".notice-toggle").stop(false, true);
        noticeCollapse(".notice-collapse", false);
        noticeCollapse(".notice-toggle", true);
        //隐藏title
        $(this).slideUp();
        //显示body
        $(this).next().fadeIn();

    });
    //收起
    $(".notice-collapse .notice-close").click(function () {
        //隐藏body
        $(this).parent().slideUp();
        //显示title
        $(this).parent().prev().fadeIn();
    });
}
function noticeCollapse(selector,toggle) {
    $(selector).each(function () {
        if (toggle) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}
/*****************end metro 首页通知效果****************/

/**************删除附件Li节点**********************/
function DelAttachLi(obj) {
    artDialogConfirm("确定要删除吗？", "提示信息", function (result) {
        if (result) {
            $(obj).parent().remove(); //删除节点
        }
    });
}
function artDialogConfirm(content, title,callback) {
    var d = dialog({
        title: title,
        content: content,
        okValue: '确定',
        ok: function () {
            callback(true);
        },
        cancelValue: '取消',
        cancel: function() {
            callback(false);
        }
    });
    d.show();
}
/***************可以自动关闭的提示********************/
function jsprint(msgtitle, url, msgcss, callback) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Warning":
            cssname = "alert fixalert";
            break;
        case "Success":
            cssname = "alert alert-success fixalert";
            break;
        case "Error":
            cssname = "alert alert-error fixalert";
            break;
        default:
            cssname = "alert alert-info fixalert";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\"><i class=\"icon-bell-alt\"></i>&nbsp;&nbsp;" + msgtitle + "</div>";
    $("#frameContainer").prepend(str);
    $("#msgprint").show();
    if (url == "back" ) {
        frames[0].history.back(-1);
    } else if (url != "") {
        frames[0].location.href = url;
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
//============全选===========
//全选取消按钮函数
function checkAll(chkobj, nodeId) {
    if ($(chkobj).attr("checked") == "checked") {
        $(nodeId + " input[type=checkbox]").attr("checked", true);
    } else {
        $(nodeId + " input[type=checkbox]").attr("checked", false);
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
//artdialog v6 tips
function artdialogV6Tips(msg,sec) {
    var tipsDia = dialog({
        content: msg
    });
    tipsDia.show();
    setTimeout(function () {
        tipsDia.close().remove();
    }, sec*1000);
}
//提交方法
function submitDupControl(objThis) {
    objThis.disabled = true;        //变灰 
    __doPostBack(objThis.name, "");    //注意是objThis.name 而不能是 objThis.id, 因为页面可能含有母版页
}

//提交等待提示
function artdialogSubmitTips(msg) {
    if (typeof (msg) == "undefined" || msg == null || msg == "")
        msg = "正在处理，请稍等片刻...^_^";
    var d = dialog({
        title: '系统提示',
        content: "<img src='/scripts/artDialog4.1.7/skins/icons/wait.gif' alt='Loading'/>" + msg
    });
    d.showModal();
}
//获取最上层的窗口
function getTopWindow() {
    var obj = window.self;
    while (true) {
        if (obj.document.getElementById("myFlag")) {
            return obj;
        }
        obj = obj.window.parent;
    }
}
//js htmlEncode and htmlDecode
function htmlEncode(html) {
    return document.createElement('a').appendChild(
        document.createTextNode(html)).parentNode.innerHTML;
};

function htmlDecode(html) {
    var a = document.createElement('a'); a.innerHTML = html;
    return a.textContent;
};
//获取各业务系统的消息通知未读数
function getUnReadNoticeCnt(sysCode, callback) {
    var submitUrl = "/admin/noticer/noticer_ajax.ashx?action=getUnReadNoticeCnt&syscode=" + sysCode;
    //开始提交
    $.ajax({
        url: submitUrl,
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
                callback(resultJson.Cnt);
            } else {
                callback(0);
            }
        },
        error: function (data, status, e) {
            callback(0);
        },
        cache: false
    });
}
function updateUnReadNoticeStatus(sysCode) {
    var submitUrl = "/admin/noticer/noticer_ajax.ashx?action=updateUnReadNoticeStatus&syscode=" + sysCode;
    //开始提交
    $.ajax({
        url: submitUrl,
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
            }
            //console.log(data);
        },
        error: function (data, status, e) {
        },
        cache: false
    });
}

//记录metro block点击数
function recordMetroBlockClick(metroName) {
    var submitUrl = "/adminmetro/CenterPage/metro_ajax.ashx?action=metroClick&metro=" + metroName;
    //开始提交
    $.ajax({
        url: submitUrl,
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
            }
            console.log(data);
        },
        error: function (data, status, e) {
        },
        cache: false
    });
}

//排序公共方法
// by cb 1226
//前提：<div id="btn-sort-group"> 
//<a href="javascript:void();" data-value="UserID" class="btn">用户名</a>
///<a href="javascript:void();" data-value="UserID" class="btn">姓名<i class="icon-arrow-up"></i></a>
//<a href="javascript:void();" data-value="UserID" class="btn">时间</a></div>
//后台需读取参数：sort  例如：UserID,asc
$(function () {
    if ($("#btn-sort-group").length > 0) {
        var _objurl = new objURL();
        var currentsort = _objurl.getParam("sort");
        $("#btn-sort-group a.btn").each(function () {
            var data_value = $(this).attr("data-value");
            if (currentsort == null)
                currentsort = "";
            if (currentsort.split(',').length == 2)
                if (currentsort.split(',')[0] == data_value) {
                    $(this).addClass("btn-success");
                    if (currentsort.split(',')[1] == "asc")
                        $(this).append("<i class='icon-arrow-up'></i>");
                    else
                        $(this).append("<i class='icon-arrow-down'></i>");
                }
            if (currentsort == data_value) {
                $(this).addClass("btn-success");
            }
            $(this).click(function () {
                if (data_value == "") {
                    _objurl.setParam("sort", data_value);
                    location.href = _objurl.url();
                } else {
                    _objurl.setParam("sort", data_value + ",asc");
                    if (currentsort != null)
                        if (currentsort.split(',')[0] == data_value && currentsort.split(',')[1] == "asc")
                            _objurl.setParam("sort", data_value + ",desc");
                        else
                            _objurl.setParam("sort", data_value + ",asc");
                    location.href = _objurl.url();
                }
            });
        });

    }
});