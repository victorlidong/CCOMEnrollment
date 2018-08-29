function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步',
        prevLabel: '上一步',
        skipLabel: '不再提示',
        doneLabel: '完成',
        steps: [
          {
              element: '#step1',
              intro: "点击这里  <b>选择</b> 需要推送的用户",
              position: 'right'
          },
          {
              element: '#txtContent',
              intro: "输入推送通知内容，250字内",
              position: 'bottom'
          },
            {
                element: '#step3',
                intro: "通知方式：<br />(1)APP推送，用户登录圈圈APP后查看<br />(2)短信，<b>选择</b>后，同时给用户发送短信",
                position: 'top'
            },
        {
            element: '#step4',
            intro: "选择后，将 <b>提示用户需要回复</b>，并统计回复情况",
            position: 'right'
        },
        {
            element: '#btnSubmit',
            intro: "Ok，点击完成！",
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=notice&module=main_send";
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