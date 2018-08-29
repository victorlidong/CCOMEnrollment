// JavaScript Document
//调用jquery ui的datepicker日历插件
$.editable.addInputType('datepicker', {
    element : function(settings, original) {
        var input = $('<input class="input" />');
		input.attr("readonly","readonly");
        $(this).append(input);
        return(input);
    },
    plugin : function(settings, original) {
		var form = this;
		$("input",this).datepicker();
    }
});

//验证E-mail
$.editable.addInputType('email', {
    element : function(settings, original) {
        var input = $('<input class="input" />');
        $(this).append(input);
        return(input);
    },
    submit: function (settings, original) {
		var value = $("input").val();
		if(value==""){
			$(this).append("<br/>不能为空！").css("color","red");
			return false;
		}
        var preg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
        if (!preg.test(value)) {
			$(this).append("<br/>请输入正确的email地址！").css("color","red");
            return false;
        }
    }
});

//验证手机号码
$.editable.addInputType('mobile', {
    element : function(settings, original) {
        var input = $('<input class="input" />');
        $(this).append(input);
        return(input);
    },
    submit: function (settings, original) {
		var value = $("input").val();
		if(value==""){
			$(this).append("<br/>不能为空！").css("color","red");
			return false;
		}
        var preg = /^(((13[0-9]{1})|(15[0-9]{1}))+\d{8})$/;
        if (!preg.test(value)) {
			$(this).append("<br/>请输入正确的手机号码！").css("color","red");
            return false;
        }
    }
});
//url
$.editable.addInputType('url', {
    element : function(settings, original) {
        var input = $('<input class="input" />');
        $(this).append(input);
        return(input);
    },
    submit: function (settings, original) {
		var value = $("input").val();
		if(value==""){
			$(this).append("<br/>不能为空！").css("color","red");
			return false;
		}
        var preg = /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
        if (!preg.test(value)) {
			$(this).append("<br/>请输入正确的URL地址！").css("color","red");
            return false;
        }
    }
});