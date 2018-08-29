function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步',
        prevLabel: '上一步',
        skipLabel: '不再提示',
        doneLabel: '完成',
        steps: [
          {
              element: '._step1 a',
              intro: "这里是当前<b>您所管辖范围</b>的所有机构，您可以拖动改变机构顺序，点击编辑名称。",
              position: 'right'
          },
            {
                element: '._step2',
                intro: "您可以选择一个机构，并点击按钮进行编辑和删除",
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=schoolmanager&module=orglist";
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