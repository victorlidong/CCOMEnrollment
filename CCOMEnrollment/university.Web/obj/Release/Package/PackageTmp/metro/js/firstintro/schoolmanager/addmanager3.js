function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
            nextLabel: '下一步',
            prevLabel: '上一步',
            skipLabel: '不再提示',
            doneLabel: '完成',
            steps: [
                {
                    element: '._step1',
                    intro: "您可以在此完善办公信息，也可以略过填写并直接完成",
                    position: 'top'
                }
            ]
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=addmanager3";
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