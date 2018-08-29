
var type_id = new Array();
var type_name = new Array();
//$(document).ready(function () {
//    $.ajax({
//        type: "POST",
//        url: "/AdminMetro/CCOM/notification/News_handler.ashx",
//        data: { "action": "get_news_type" },
//        success: function (data) {
//            //alert(data);
//            if (data != null) {
//                var result = eval(data);
//                for (var i = 0; i < result.length; i++) {
//                    type_id[i] = result[i].News_type_id;
                    
//                    type_name[i] = result[i].News_type_name;
//                }
//            }

//        },
//        error: function (data) {
//            alert("请求数据出错");
//        }
//    });
//});
function GetNewsForList(listId, typeId, page, keyWord)
{
    $(listId).empty();
    var ul = $(listId);
    
    

    $.ajax({
        type: "POST",
        url: "/AdminMetro/CCOM/notification/GetNewsByPage.ashx",
        data: { "typeId": typeId, "page": page, "action": "getAllNewsList","keyWord": keyWord},
        success: function (data) {
            if (data != null)
            {
                var result = eval(data);
                //alert("data_length:" + data.length);
                //alert("result_length:" + result.length);
                //alert("result_0_url:" + result[0].News_URL);
                var class_media = "media";
                var class_span = "label pull-left news-bg";
                var class_img_circle = "img-circle";
                var img_src = "/images/news/logo/news_icon.png";
                var class_media_body = "media-body";
                var p_title = "text news-title";
                var img_style = "width:40px; height:40px;";
                linkColor = "#bbbbbb";
                var type = "";
                //alert(data);
                if (result != null && result.length > 0)
                {
                    for (var i = 0; i < result.length; i++) {
                        //alert(result[i].News_type_name);
                        if (result[i].News_top == "True") {
                            var li = '<li>'
                              + ' <div class="media">'
                              + '<span class="label pull-left news-bg">'
                              + '<img class="img-circle" src="' + img_src + '" alt="新闻" style="width: 40px;height:40px;" />'
                              + ' </span>'
                              + '<div class="media-body">'
                              + '<p class="text news-title">'
                              + '<a href="' + result[i].News_URL + '" target="_blank">'
                              + result[i].News_title
                              + '【置顶】'
                              + '</a></p>'
                              + '<span>'
                              + result[i].News_type_name
                              + '&nbsp;&nbsp;发布时间：' + result[i].News_date
                              + '</span>'
                              + '</div></div>'
                              + '</li>';
                        }
                        else {
                            var li = '<li>'
                              + ' <div class="media">'
                              + '<span class="label pull-left news-bg">'
                              + '<img class="img-circle" src="' + img_src + '" alt="新闻" style="width: 40px;height:40px;" />'
                              + ' </span>'
                              + '<div class="media-body">'
                              + '<p class="text news-title">'
                              + '<a href="' + result[i].News_URL + '" target="_blank">'
                              + result[i].News_title
                              + '</a></p>'
                              + '<span>'
                              + result[i].News_type_name
                              + '&nbsp;&nbsp;发布时间：' + result[i].News_date
                              + '</span>'
                              + '</div></div>'
                              + '</li>';
                        }

                        //alert(li);
                        ul.append(li);
                        var hasPage = true;
                    }
                }
                else
                {
                    var li = '<div class="media notice_content"  style="text-align:center;height:50px;">'
                                + '<p style="text-align:center;font-size:20px;margin-top:15px;">暂无该类资讯</p>'
                                + '</div>';
                    //var hint = "<p style='padding:5px 5px;'>无资讯记录！<p>";
                    if (keyWord != "")
                        hint = '<div class="media notice_content"  style="text-align:center;height:50px;">'
                                + '<p style="text-align:center;font-size:20px;margin-top:15px;">未搜索到资讯</p>'
                                + '</div>';
                    ul.append("<li>" + hint + "</li>");
                    hasPage = false;
                }
                
                
                //显示
                $(listId).show();
                $(listId).prev().hide();
                if (hasPage)
                {
                    $("#PageContent").empty();
                    showNewsPage(typeId, page);
                }
                    
            } 
        },
        error: function (data) {
            alert("请求数据出错");
        }
    });
}
function getTypeName(type_id)
{
    
}
function showNewsPage(typeId,page)
{

    $.ajax({
        type: "POST",
        url: "/AdminMetro/CCOM/notification/GetNewsByPage.ashx",
        data: { "typeId": typeId, "page": page, "action": "getNewsPage", "keyWord": "" },
        success: function(data)
        {
            //alert(data);
            if(data!=null&&data.length>0)
            {
                $("#PageContent").append(data);
                $("#divNewsPage").show();
                $("body").scrollTop(0);

            }
           
        },
        error: function(data)
        {
            alert("请求页码数据出错");
        }
    });
}

function newsTypeTabs(listId, typeId, node) {
    //设置点击后的切换样式
    //$("txtKeywords").val("");
    $(node).parent().children("a.btn-success").removeClass("btn-success");
    $(node).addClass("btn-success");
    
    //alert(node.value);
    GetNewsForList(listId, typeId, 1, $("#txtKeywords").val());
}

//function lastPagesForList(node, listId, navId) {
//    var page = $(node).parent().parent().find(".page_text  b").html();
//    page = parseInt(page);
//    var newsid = 0;
//    var subTypeId = $(navId + " a.btn-success").prev().val();
//    page = page - 1;
//    if (page < 1)
//        page = 1;
//    GetNewsForList(listId, subTypeId, page);
//}
//function nextPagesForList(node, listId, navId) {
//    var page = $(node).parent().parent().find(".page_text  b").html();
//    page = parseInt(page);
//    var newsid = 0;
//    var subTypeId = $(navId + " a.btn-success").prev().val();
//    GetNewsForList(listId, subTypeId, page + 1);
//}
