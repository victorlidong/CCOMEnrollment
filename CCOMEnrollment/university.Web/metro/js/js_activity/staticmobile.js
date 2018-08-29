//获取评论列表
function getComment(_aaid) {
    var ajaxUrl = "action=getcomment&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityStatic.ashx?" + ajaxUrl,
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
        url: "/AdminMetro/activitynew/AjaxActivityStatic.ashx?" + ajaxUrl,
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

//获取粉丝列表
function getFans(_aaid) {
    var ajaxUrl = "action=fans&aaid=" + _aaid;
    //console.log(ajaxUrl);
    $.ajax({
        url: "/AdminMetro/activitynew/AjaxActivityStatic.ashx?" + ajaxUrl,
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