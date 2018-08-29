﻿function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
            nextLabel: '下一步',
            prevLabel: '上一步',
            skipLabel: '不再提示',
            doneLabel: '完成',
            steps: [
                {
                    element: '._step1',
                    intro: "点此选择要导入用户所在的机构",
                    position: 'bottom'
                },
                  {
                      element: '._step2',
                      intro: "点此下载Excel模板，并严格按照模板要求填写内容",
                      position: 'bottom'
                  },
                {
                    element: '._step3',
                    intro: "进入下一步上传填好的Excel模板",
                    position: 'right'
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=addstu";
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