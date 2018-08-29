document.write("<script type=\"text/javascript\" src=\"/metro/js/layer/layer.min.js\"></script>");
//获取最上层的窗口
function getTopWindow() {
    var obj = window.self;
    while (true) {
        if (obj.document.getElementById("myFlag")) {
            return obj;
        }
        obj = obj.window.parent;
    }
}