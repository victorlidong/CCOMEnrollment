function startIntro(chapter) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步 &rarr;',
        prevLabel: '&larr; 上一步',
        skipLabel: '不再提示',
        doneLabel: '完成',
        steps: [
          {
              intro: "您好，欢迎您使用圈圈校园开证明系统！这个是申请开证明页面。",
          },
          {
              element: '#step2',
              intro: "首先，选择可以给您开证明的辅导员（一般是您的辅导员）。",
              position: 'bottom'
          },
          {
              element: '#step3',
              intro: "其次，选择您开证明对应的模板，可以输入关键词进行搜索。如果您希望开证明的类型不在模板列表里，可以先选择其他，在申请理由里进行说明，然后找辅导员添加该证明模板。",
              position: 'bottom'
          },
          {
              element: '#step4',
              intro: "在模板预览里，您可以看到所选择的模板内容，如果不是您所需要的模板，可以重新选择证明模板",
              position: 'bottom'
          },
          {
              element: '#step5',
              intro: "然后，填上申请理由，向辅导员说明您为什么要开这个证明，方便辅导员审批",
              position: 'bottom'
          },
          {
              element: '#step6',
              intro: "最后，点击提交申请按钮，证明申请就完成了。",
              position: 'bottom'
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
    var submitUrl = "/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=certf&module=student_certf";
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
}