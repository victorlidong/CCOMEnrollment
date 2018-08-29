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
              intro: "点此修改学生的密码",
              position: 'bottom'
          },
          {
              element: '._step2',
              intro: "点此切换查看信息类别",
              position: 'bottom'
          },
            {
                element: '._step3',
                intro: "点此修改学生个人基础信息",
                position: 'left'
            },
            {
                element: '._step4',
                intro: "在此修改学生账户信息",
                position: 'left'
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=stu_edit";
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