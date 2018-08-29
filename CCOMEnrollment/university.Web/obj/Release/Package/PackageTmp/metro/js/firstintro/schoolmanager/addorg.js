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
              intro: "您当前为该机构添加子级机构",
              position: 'bottom'
          },
            {
                element: '._step2',
                intro: "在此处输入部门名称，请参照右侧图示",
                position: 'right'
            },
            {
                element: '._step3',
                intro: "您可以点此添加输入框，一次增添多个部门",
                position: 'bottom'
            }]
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=addorg";
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