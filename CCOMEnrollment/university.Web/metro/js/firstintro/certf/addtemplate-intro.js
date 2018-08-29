function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步 &rarr;',
        prevLabel: '&larr; 上一步',
        skipLabel: '不再提示',
        doneLabel: '完成'
    });
    intro.onexit(function() {
        //完成不再提示
        completeIntro();
    });
    intro.oncomplete(function() {
        //完成
        completeIntro();
    });
    intro.start();
}

function completeIntro() {
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=certf&module=add_template";
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