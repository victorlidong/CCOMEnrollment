


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