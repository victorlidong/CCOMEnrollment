//获取评论列表
function getComment(_aaid) {
    var ajaxUrl = "action=getcomment&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#comment_list").html(json.Msg);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//获取成员列表
function getMember(_aaid) {
    var ajaxUrl = "action=member&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#member_list").html(json.Msg);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//获取待审核成员列表
function getWillCheck(_aaid) {
    var ajaxUrl = "action=willcheck&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#check_list").html(json.Msg);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//获取粉丝列表
function getFans(_aaid) {
    var ajaxUrl = "action=fans&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#fans_list").html(json.Msg);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//更新底测按钮状态
function updateBtn(aaid) {
    var ajaxUrl = "action=btn&aaid=" + aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#event_btn").html(json.Msg);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//发表评论
function setComment() {
    var _objurl = new objURL();
    var _aaid = _objurl.getParam("aaid");
    //var _token = _objurl.getParam("token");
    var _content = $("#comment_text_box").val();
    //console.log(_aaid + "___" + _token + "_____" + _content);
    if (_content == "") {
        alert("请输入评论内容");
    }
    else if (_content.length > 140) {
        alert("评论请不要超过140字");
    }
    else {
        _content = _content.replace(/\?/g, "？");

        var ajaxUrl = "action=setcomment&aaid=" + _aaid + "&content=" + _content;
        //console.log(ajaxUrl);
        $.ajax({
            url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
            dataType: 'json',
            type: "GET",
            success: function (json) {
                //console.log(json);

                if (json.Result == 200) {
                    getComment(_aaid);
                    document.getElementById("comment_text_box").value = "";
                    document.getElementById("comment_text_box").className = "iniheight";
                    $("#CommentSmt").hide();
                }
                else {
                    alert(json.Msg);
                }
            },
            error: function (xhr) {
                alert("请求出错，请连接网络!");
            }
        });
    }
};

//移除成员/粉丝
function deleteMember(_aaid, _apid) {
    if (confirm('您确定要移除吗?')) {
        var ajaxUrl = "action=delete&aaid=" + _aaid + "&apid=" + _apid;
        //console.log(ajaxUrl);
        $.ajax({
            url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
            dataType: 'json',
            type: "GET",
            success: function (json) {
                //console.log(json);

                if (json.Result == 200) {
                    getMember(_aaid);
                    getFans(_aaid);
                    updateBtn(_aaid);
                }
                else {
                    alert(json.Msg);
                }
            },
            error: function (xhr) {
                alert("请求出错，请连接网络!");
            }
        });
    }
}

//审核成员
function CheckApply(_aaid, _apid, _state) {
    var ajaxUrl = "action=check&aaid=" + _aaid + "&apid=" + _apid + "&state=" + _state;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                getMember(_aaid);
                getWillCheck(_aaid);
                updateBtn(_aaid);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//关注
function follow(aaid) {
    var ajaxUrl = "action=follow&aaid=" + aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#follow").html(json.Msg);
                getFans(aaid);
                updateBtn(aaid);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            alert("请求出错，请连接网络!");
        }
    });
}

//报名参加
function participate(aaid) {
    var ajaxUrl = "action=participate&aaid=" + aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityWeb.ashx?" + ajaxUrl,
        dataType: 'json',
        type: "GET",
        success: function (json) {
            //console.log(json);

            if (json.Result == 200) {
                $("#participate").html(json.Msg);
                getMember(aaid);
                getWillCheck(aaid);
                updateBtn(aaid);
            }
            else {
                alert(json.Msg);
            }
        },
        error: function (xhr) {
            console.log(xhr);
            alert("请求出错，请连接网络!");
        }
    });
}