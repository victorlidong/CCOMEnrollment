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
                    intro: "点此选择管理员所在机构，注意这不是管理员的管辖范围",
                    position: 'bottom'
                },
               {
                   element: '._step2',
                   intro: "点此选择管理员身份",
                   position: 'bottom'
               },
               {
                   element: '._step3',
                   intro: "点此选择管理员管辖机构",
                   position: 'bottom'
               },
                 {
                     element: '._step4',
                     intro: "点此选择管理员的管辖业务类别，点击右侧查看对应的具体功能",
                     position: 'bottom'
                 },
               {
                    element: '._step5',
                    intro: "此处内容会以短信形式发送给您要添加的管理员，您可以修改内容，也可以选择不发送短信",
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=addmanager2";
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