function objURL(url) {
    var obj= new Object();
    obj.ourl = url || window.location.href;
    obj.href = "";//?前面部分
    obj.params = {};//url参数对象
    obj.jing = "";//#及后面部分
    var init = function () {
        var str = obj.ourl;
        var index = str.indexOf("#");
        if (index > 0) {
            obj.jing = str.substr(index + 1);
            str = str.substring(0, index);
        }
        else
            obj.jing = "";
        index = str.indexOf("?");
        if (index > 0) {
            obj.href = str.substring(0, index);
            str = str.substr(index + 1);
            var parts = str.split("&");
            for (var i = 0; i < parts.length; i++) {
                var kv = parts[i].split("=");
                obj.params[kv[0]] = kv[1];
            }
        } else {
            obj.href = str;
            obj.params = {};
        }
    };
    obj.setParam = function (key, val) {
        key = encodeURI(key);
        obj.params[key] = encodeURIComponent(val);
    };
    obj.removeParam = function (key) {
        if (key in params) obj.params[key] = undefined;
    };
    obj.getParam = function (key) {
        key = encodeURIComponent(key);
        var rtn = decodeURIComponent(obj.params[key]);
        if (rtn == "undefined")
            return null;
        else
            return rtn;
    };
    obj.setFragment = new function (value) {
        obj.jing = value;
    };
    obj.getFragment = new function () {
        return obj.jing;
    };
    obj.url = function () {
        var strurl = this.href;
        var objps = [];
        for (var k in this.params) {
            if (this.params[k]) {
                objps.push(k + "=" + this.params[k]);
            }
        }
        if (objps.length > 0) {
            strurl += "?" + objps.join("&");
        }
        //if (this.jing.length > 0) {
        //    strurl += this.jing;
        //}
        return strurl;
    };
    this.debug = function () {
        // 以下调试代码自由设置
        var objps = [];
        for (var k in params) {
            objps.push(k + "=" + params[k]);
        }
        alert(objps);//输出params的所有值
    };
    init();
    return obj;
}