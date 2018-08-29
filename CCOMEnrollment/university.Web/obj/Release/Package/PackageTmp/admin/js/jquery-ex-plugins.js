//jQuery获取url参数扩展方法
(function ($) {
    $.getUrlParam = function(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]);
        return null;
    };
})(jQuery);

/*
* url 目标url(http://www.phpernote.com/)
* arg 需要替换的参数名称
* arg_val 替换后的参数的值
* return url 参数替换后的url
*/
(function ($) {
    $.changeURLArg = function(url, arg, argVal) {
        var pattern = arg + '=([^&]*)';
        var replaceText = arg + '=' + encodeURIComponent(argVal);
        if (url.match(pattern)) {
            var tmp = '/(' + arg + '=)([^&]*)/gi';
            tmp = url.replace(eval(tmp), replaceText);
            return tmp;
        } else {
            if (url.match('[\?]')) {
                return url + '&' + replaceText;
            } else {
                return url + '?' + replaceText;
            }
        }
        return url + '\n' + arg + '\n' + argVal;
    };
})(jQuery);

//url添加参数
(function ($) {
    $.urlAddParams = function (url, name, value) {
        var r = url;
        if (r != null && r != 'undefined' && r != "") {
            value = encodeURIComponent(value);
            var reg = new RegExp("(^|)" + name + "=([^&]*)(|$)");
            var tmp = name + "=" + value;
            if (url.match(reg) != null) {
                r = url.replace(eval(reg), tmp);
            } else {
                if (url.match("[\?]")) {
                    r = url + "&" + tmp;
                } else {
                    r = url + "?" + tmp;
                }
            }
        }
        return r;
    };
})(jQuery);

//tooltip effect
var tooltip = function () {
    var id = 'tt';
    var top = 3;
    var left = 3;
    var maxw = 400;
    var speed = 10;
    var timer = 20;
    var endalpha = 95;
    var alpha = 0;
    var tt, t, c, b, h;
    var ie = document.all ? true : false;
    return {
        show: function (v, w) {
            if (tt == null) {
                tt = document.createElement('div');
                tt.setAttribute('id', id);
                t = document.createElement('div');
                t.setAttribute('id', id + 'top');
                c = document.createElement('div');
                c.setAttribute('id', id + 'cont');
                b = document.createElement('div');
                b.setAttribute('id', id + 'bot');
                tt.appendChild(t);
                tt.appendChild(c);
                tt.appendChild(b);
                document.body.appendChild(tt);
                tt.style.opacity = 0;
                tt.style.filter = 'alpha(opacity=0)';
                document.onmousemove = this.pos;
            }
            tt.style.display = 'block';
            c.innerHTML = v;
            tt.style.width = w ? w + 'px' : 'auto';
            if (!w && ie) {
                t.style.display = 'none';
                b.style.display = 'none';
                tt.style.width = tt.offsetWidth;
                t.style.display = 'block';
                b.style.display = 'block';
            }
            if (tt.offsetWidth > maxw) { tt.style.width = maxw + 'px' }
            //h = parseInt(tt.offsetHeight) + top;
            h = top;
            clearInterval(tt.timer);
            tt.timer = setInterval(function () { tooltip.fade(1) }, timer);
        },
        pos: function (e) {
            var u = ie ? event.clientY + document.documentElement.scrollTop : e.pageY;
            var l = ie ? event.clientX + document.documentElement.scrollLeft : e.pageX;
            tt.style.top = (u + h) + 'px';
            tt.style.left = (l + left + 5) + 'px';
        },
        fade: function (d) {
            var a = alpha;
            if ((a != endalpha && d == 1) || (a != 0 && d == -1)) {
                var i = speed;
                if (endalpha - a < speed && d == 1) {
                    i = endalpha - a;
                } else if (alpha < speed && d == -1) {
                    i = a;
                }
                alpha = a + (i * d);
                tt.style.opacity = alpha * .01;
                tt.style.filter = 'alpha(opacity=' + alpha + ')';
            } else {
                clearInterval(tt.timer);
                if (d == -1) { tt.style.display = 'none' }
            }
        },
        hide: function () {
            clearInterval(tt.timer);
            tt.timer = setInterval(function () { tooltip.fade(-1) }, timer);
        }
    };
}();