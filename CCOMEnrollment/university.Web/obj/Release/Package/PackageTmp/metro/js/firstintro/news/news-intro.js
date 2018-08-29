function startIntro(module) {
    switch (module) {
        case "add_news":
            startIntroAddNews(module);
            break;
        case "add_type":
            break;
        case "read_right":
            break;
        case "admin_news":
            break;
        default:
            break;
    }
}
function startIntroAddNews(module) {
    var intro = introJs();
    intro.setOptions({
        nextLabel: '下一步',
        prevLabel: '上一步',
        skipLabel: '不再提示',
        doneLabel: '完成',
        steps: [
          {
              element: '.breadcrumb',
              intro: "<h>2.0版本的新闻升级为资讯啦！</h><p>在资讯功能中，<b>不再提供推送提醒功能，如需实时推送提醒和阅读统计，可以使用升级后的通知功能！我要发通知</b>",
              position: 'bottom'
          }
        ]
    });
    intro.onexit(function () {
        $("body").scrollTop(0);
        //完成不再提示
        completeIntro(module);
    });
    intro.oncomplete(function () {
        $("body").scrollTop(0);
        //完成
        completeIntro(module);
    });
    intro.start();
}

function completeIntro(module) {
    var submitUrl = '/adminmetro/firstlogin/intro_ajax.ashx?action=completeIntro&sys=news&module=' + module;
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

//steps: [
//       {
//           element: '.page-title',
//           intro: "点击  <b>选择</b> 新闻类别<br/>如果还没有新闻类别，请点击<b> 添加新闻类别</b>",
//           position: 'right'
//       },
//       {
//           element: '#txtTitle',
//           intro: "新闻标题，<b>必填</b>，100字内",
//           position: 'right'
//       },
//         {
//             element: '#txtAbstract',
//             intro: "新闻摘要，<b>选填</b>，200字内",
//             position: 'right'
//         },
//     {
//         element: '#intro_news',
//         intro: "新闻内容，可以 <b style='color:red;'>从word文档中导入</b>，或直接编辑",
//         position: 'top'
//     },
//     {
//         element: '#intro_attach',
//         intro: "新闻附件，可选<br /><b>支持20个，单个附件不要大于4M</b>！",
//         position: 'top'
//     },
//     {
//         element: '#intro_news_set',
//         intro: "新闻设定，<b style='color:red;'>可选</b>，包括：<br />(1)修改新闻发布时间<br />(2)新闻置顶<br />(3)分享登录查看<br />(4)新闻阅读权限重设",
//         position: 'right'
//     },
//     {
//         element: '#btnPreView',
//         intro: "编辑完成后，可以预览编辑效果！",
//         position: 'top'
//     },
//     {
//         element: '#btnSubmit',
//         intro: "Ok，点击完成！",
//         position: 'top'
//     }
//]