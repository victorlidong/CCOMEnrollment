function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步 &rarr;',
        prevLabel: '&larr; 上一步',
        skipLabel: '不再提示',
        doneLabel: '继续',
        steps: [
          {
              intro: "您好，欢迎您使用圈圈校园开证明系统！接下来，请跟着我们的引导一步步了解如何使用开证明系统吧^_^",
          },
          {
              element: '#step2',
              intro: "需要给学生开证明时，请点击这里。",
              position: 'right'
          },
          {
              element: '#step3',
              intro: "为了以后开证明的方便，我们需要先添加证明模板。请点击<b style='color:#4a8bc2'>继续</b>按钮，我们将进入添加证明模板页面。",
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
        completeIntro(chapter);
    });
    intro.start();
}

function completeIntro(chapter) {
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=certf&module=admin_certf";
    //开始提交
    $.ajax({
        url: submitUrl,
        success: function (data) {
            var resultJson = eval("(" + data + ")");
            if (resultJson.ErrCode == 200) {
            }
        },
        error: function (data, status, e) {
        },
        cache: false
    });
    window.location.href = '/AdminMetro/Certificate/NewTemplate.aspx?fun_id=' + chapter;
}