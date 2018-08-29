// JavaScript Document
Array.prototype.some||(Array.prototype.some=function(a){"use strict";if(void 0===this||null===this)throw new TypeError;var b=Object(this),c=b.length>>>0;if("function"!=typeof a)throw new TypeError;for(var d=arguments.length>=2?arguments[1]:void 0,e=0;c>e;e++)if(e in b&&a.call(d,b[e],e,b))return!0;return!1}),Array.prototype.forEach||(Array.prototype.forEach=function(a){"use strict";if(void 0===this||null===this)throw new TypeError;var b=Object(this),c=b.length>>>0;if("function"!=typeof a)throw new TypeError;for(var d=arguments.length>=2?arguments[1]:void 0,e=0;c>e;e++)e in b&&a.call(d,b[e],e,b)}),function(a,b,c){function d(a){return a.match(/\D+$/)}function e(a,b,c,d){if("d"!=c&&m(a)){var e=s.exec(b),f="auto"===a.css(c)?0:a.css(c),g="string"==typeof f?l(f):f,h=("string"==typeof b?l(b):b,d===!0?0:g),i=a.is(":hidden"),j=a.translation();if("left"==c&&(h=parseInt(g,10)+j.x),"right"==c&&(h=parseInt(g,10)+j.x),"top"==c&&(h=parseInt(g,10)+j.y),"bottom"==c&&(h=parseInt(g,10)+j.y),e||"show"!=b?e||"hide"!=b||(h=0):(h=1,i&&a.css({display:k(a.context.tagName),opacity:0})),e){var n=parseFloat(e[2]);return e[1]&&(n=("-="===e[1]?-1:1)*n+parseInt(h,10)),"%"==e[3]&&(n+="%"),n}return h}}function f(a,b,c){return c===!0||G===!0&&c!==!1&&F?"translate3d("+a+"px, "+b+"px, 0)":"translate("+a+"px,"+b+"px)"}function g(b,c,d,e,f,g,i,k){var m=b.data(w),n=m&&!j(m)?m:a.extend(!0,{},u),o=f,q=a.inArray(c,p)>-1;if(q){var r=n.meta,s=l(b.css(c))||0,t=c+"_o";o=f-s,r[c]=o,r[t]="auto"==b.css(c)?0+o:s+o||0,n.meta=r,i&&0===o&&(o=0-r[t],r[c]=o,r[t]=0)}return b.data(w,h(b,n,c,d,e,o,g,i,k))}function h(a,b,c,d,e,g,h,i,j){var k=!1,l=h===!0&&i===!0;b=b||{},b.original||(b.original={},k=!0),b.properties=b.properties||{},b.secondary=b.secondary||{};for(var m=b.meta,n=b.original,o=b.properties,p=b.secondary,r=q.length-1;r>=0;r--){var s=q[r]+"transition-property",t=q[r]+"transition-duration",u=q[r]+"transition-timing-function";c=l?q[r]+"transform":c,k&&(n[s]=a.css(s)||"",n[t]=a.css(t)||"",n[u]=a.css(u)||""),p[c]=l?f(m.left,m.top,j):g,o[s]=(o[s]?o[s]+",":"")+c,o[t]=(o[t]?o[t]+",":"")+d+"ms",o[u]=(o[u]?o[u]+",":"")+e}return b}function i(a){for(var b in a)if(!("width"!=b&&"height"!=b||"show"!=a[b]&&"hide"!=a[b]&&"toggle"!=a[b]))return!0;return!1}function j(a){for(var b in a)return!1;return!0}function k(a){a=a.toUpperCase();var b={LI:"list-item",TR:"table-row",TD:"table-cell",TH:"table-cell",CAPTION:"table-caption",COL:"table-column",COLGROUP:"table-column-group",TFOOT:"table-footer-group",THEAD:"table-header-group",TBODY:"table-row-group"};return"string"==typeof b[a]?b[a]:"block"}function l(a){return parseFloat(a.replace(d(a),""))}function m(a){var b=!0;return a.each(function(a,c){return b=b&&c.ownerDocument}),b}function n(b,c,d){if(!m(d))return!1;var e=a.inArray(b,o)>-1;return"width"!=b&&"height"!=b&&"opacity"!=b||parseFloat(c)!==parseFloat(d.css(b))||(e=!1),e}var o=["top","right","bottom","left","opacity","height","width"],p=["top","right","bottom","left"],q=["-webkit-","-moz-","-o-",""],r=["avoidTransforms","useTranslate3d","leaveTransforms"],s=/^([+-]=)?([\d+-.]+)(.*)$/,t=/([A-Z])/g,u={secondary:{},meta:{top:0,right:0,bottom:0,left:0}},v="px",w="jQe",x="cubic-bezier(",y=")",z=null,A=!1,B=document.body||document.documentElement,C=B.style,D="webkitTransitionEnd oTransitionEnd transitionend",E=void 0!==C.WebkitTransition||void 0!==C.MozTransition||void 0!==C.OTransition||void 0!==C.transition,F="WebKitCSSMatrix"in window&&"m11"in new WebKitCSSMatrix,G=F;a.expr&&a.expr.filters&&(z=a.expr.filters.animated,a.expr.filters.animated=function(b){return a(b).data("events")&&a(b).data("events")[D]?!0:z.call(this,b)}),a.extend({toggle3DByDefault:function(){return G=!G},toggleDisabledByDefault:function(){return A=!A},setDisabledByDefault:function(a){return A=a}}),a.fn.translation=function(){if(!this[0])return null;var a=this[0],b=window.getComputedStyle(a,null),c={x:0,y:0};if(b)for(var d=q.length-1;d>=0;d--){var e=b.getPropertyValue(q[d]+"transform");if(e&&/matrix/i.test(e)){var f=e.replace(/^matrix\(/i,"").split(/, |\)$/g);c={x:parseInt(f[4],10),y:parseInt(f[5],10)};break}}return c},a.fn.animate=function(c,d,f,h){c=c||{};var k=!("undefined"!=typeof c.bottom||"undefined"!=typeof c.right),l=a.speed(d,f,h),m=0,o=function(){m--,0===m&&"function"==typeof l.complete&&l.complete.apply(this,arguments)},s="undefined"!=typeof c.avoidCSSTransitions?c.avoidCSSTransitions:A;return s===!0||!E||j(c)||i(c)||l.duration<=0||l.step?b.apply(this,arguments):this[l.queue===!0?"queue":"each"](function(){var d=a(this),f=a.extend({},l),h=function(b){var e=d.data(w)||{original:{}},f={};if(2==b.eventPhase){if(c.leaveTransforms!==!0){for(var g=q.length-1;g>=0;g--)f[q[g]+"transform"]="";if(k&&"undefined"!=typeof e.meta)for(var h,i=0;h=p[i];++i)f[h]=e.meta[h+"_o"]+v,a(this).css(h,f[h])}d.unbind(D).css(e.original).css(f).data(w,null),"hide"===c.opacity&&d.css({display:"none",opacity:""}),o.call(this)}},i={bounce:x+"0.0, 0.35, .5, 1.3"+y,linear:"linear",swing:"ease-in-out",easeInQuad:x+"0.550, 0.085, 0.680, 0.530"+y,easeInCubic:x+"0.550, 0.055, 0.675, 0.190"+y,easeInQuart:x+"0.895, 0.030, 0.685, 0.220"+y,easeInQuint:x+"0.755, 0.050, 0.855, 0.060"+y,easeInSine:x+"0.470, 0.000, 0.745, 0.715"+y,easeInExpo:x+"0.950, 0.050, 0.795, 0.035"+y,easeInCirc:x+"0.600, 0.040, 0.980, 0.335"+y,easeInBack:x+"0.600, -0.280, 0.735, 0.045"+y,easeOutQuad:x+"0.250, 0.460, 0.450, 0.940"+y,easeOutCubic:x+"0.215, 0.610, 0.355, 1.000"+y,easeOutQuart:x+"0.165, 0.840, 0.440, 1.000"+y,easeOutQuint:x+"0.230, 1.000, 0.320, 1.000"+y,easeOutSine:x+"0.390, 0.575, 0.565, 1.000"+y,easeOutExpo:x+"0.190, 1.000, 0.220, 1.000"+y,easeOutCirc:x+"0.075, 0.820, 0.165, 1.000"+y,easeOutBack:x+"0.175, 0.885, 0.320, 1.275"+y,easeInOutQuad:x+"0.455, 0.030, 0.515, 0.955"+y,easeInOutCubic:x+"0.645, 0.045, 0.355, 1.000"+y,easeInOutQuart:x+"0.770, 0.000, 0.175, 1.000"+y,easeInOutQuint:x+"0.860, 0.000, 0.070, 1.000"+y,easeInOutSine:x+"0.445, 0.050, 0.550, 0.950"+y,easeInOutExpo:x+"1.000, 0.000, 0.000, 1.000"+y,easeInOutCirc:x+"0.785, 0.135, 0.150, 0.860"+y,easeInOutBack:x+"0.680, -0.550, 0.265, 1.550"+y},s={},t=i[f.easing||"swing"]?i[f.easing||"swing"]:f.easing||"swing";for(var u in c)if(-1===a.inArray(u,r)){var z=a.inArray(u,p)>-1,A=e(d,c[u],u,z&&c.avoidTransforms!==!0);n(u,A,d)?g(d,u,f.duration,t,A,z&&c.avoidTransforms!==!0,k,c.useTranslate3d):s[u]=c[u]}d.unbind(D);var B=d.data(w);if(!B||j(B)||j(B.secondary))f.queue=!1;else{m++,d.css(B.properties);var C=B.secondary;setTimeout(function(){d.bind(D,h).css(C)})}return j(s)||(m++,b.apply(d,[s,{duration:f.duration,easing:a.easing[f.easing]?f.easing:a.easing.swing?"swing":"linear",complete:o,queue:f.queue}])),!0})},a.fn.animate.defaults={},a.fn.stop=function(b,d,e){return E?(b&&this.queue([]),this.each(function(){var f=a(this),g=f.data(w);if(g&&!j(g)){var h,i={};if(d){if(i=g.secondary,!e&&void 0!==typeof g.meta.left_o||void 0!==typeof g.meta.top_o)for(i.left=void 0!==typeof g.meta.left_o?g.meta.left_o:"auto",i.top=void 0!==typeof g.meta.top_o?g.meta.top_o:"auto",h=q.length-1;h>=0;h--)i[q[h]+"transform"]=""}else if(!j(g.secondary)){var k=window.getComputedStyle(f[0],null);if(k)for(var l in g.secondary)if(g.secondary.hasOwnProperty(l)&&(l=l.replace(t,"-$1").toLowerCase(),i[l]=k.getPropertyValue(l),!e&&/matrix/i.test(i[l]))){var m=i[l].replace(/^matrix\(/i,"").split(/, |\)$/g);for(i.left=parseFloat(m[4])+parseFloat(f.css("left"))+v||"auto",i.top=parseFloat(m[5])+parseFloat(f.css("top"))+v||"auto",h=q.length-1;h>=0;h--)i[q[h]+"transform"]=""}}f.unbind(D),f.css(g.original).css(i).data(w,null)}else c.apply(f,[b,d])}),this):c.apply(this,[b,d])}}(jQuery,jQuery.fn.animate,jQuery.fn.stop),function(){function a(){b&&(e(a),jQuery.fx.tick())}for(var b,c=0,d=["webkit","moz"],e=window.requestAnimationFrame,f=window.cancelAnimationFrame;c<d.length&&!e;c++)e=window[d[c]+"RequestAnimationFrame"],f=f||window[d[c]+"CancelAnimationFrame"]||window[d[c]+"CancelRequestAnimationFrame"];e?(window.requestAnimationFrame=e,window.cancelAnimationFrame=f,jQuery.fx.timer=function(c){c()&&jQuery.timers.push(c)&&!b&&(b=!0,a())},jQuery.fx.stop=function(){b=!1}):(window.requestAnimationFrame=function(a){var b=(new Date).getTime(),d=Math.max(0,16-(b-c)),e=window.setTimeout(function(){a(b+d)},d);return c=b+d,e},window.cancelAnimationFrame=function(a){clearTimeout(a)})}(jQuery),+function(a){"use strict";function b(){var a=document.createElement("bootstrap"),b={WebkitTransition:"webkitTransitionEnd",MozTransition:"transitionend",OTransition:"oTransitionEnd otransitionend",transition:"transitionend"};for(var c in b)if(void 0!==a.style[c])return{end:b[c]};return!1}a.fn.emulateTransitionEnd=function(b){var c=!1,d=this;a(this).one(a.support.transition.end,function(){c=!0});var e=function(){c||a(d).trigger(a.support.transition.end)};return setTimeout(e,b),this},a(function(){a.support.transition=b()})}(jQuery),+function(a){"use strict";var b='[data-dismiss="alert"]',c=function(){};c.prototype.close=function(b){function c(){f.trigger("closed.bs.alert").remove()}var d=a(this),e=d.attr("data-target");e||(e=d.attr("href"),e=e&&e.replace(/.*(?=#[^\s]*$)/,""));var f=a(e);b&&b.preventDefault(),f.length||(f=d.data("dismiss")?d.parent():d),f.trigger(b=a.Event("close.bs.alert")),b.isDefaultPrevented()||(f.removeClass("in"),a.support.transition&&f.hasClass("fade")?f.one(a.support.transition.end,c).emulateTransitionEnd(150):c())};var d=a.fn.alert;a.fn.alert=function(b){return this.each(function(){var d=a(this),e=d.data("bs.alert");e||d.data("bs.alert",e=new c(this)),"string"==typeof b&&e[b].call(d)})},a.fn.alert.Constructor=c,a.fn.alert.noConflict=function(){return a.fn.alert=d,this},a(document).on("click.bs.alert.data-api",b,c.prototype.close)}(jQuery),+function(a){"use strict";function b(){a(d).remove(),a(e).each(function(b){var d=c(a(this));d.hasClass("open")&&(d.trigger(b=a.Event("hide.bs.dropdown2")),b.isDefaultPrevented()||d.removeClass("open").trigger("hidden.bs.dropdown2"))})}function c(b){var c=b.attr("data-target");c||(c=b.attr("href"),c=c&&/#/.test(c)&&c.replace(/.*(?=#[^\s]*$)/,""));var d=c&&a(c);return d&&d.length?d:b.parent()}var d=".dropdown2-backdrop",e="[data-toggle=dropdown2]",f=function(b){a(b).on("click.bs.dropdown2",this.toggle)};f.prototype.dropdown2=function(d){var e=a(this);if(!e.is(".disabled, :disabled")){var f=c(e);if(f.on("mouseleave.bs.dropdown2.data-api",b),f.trigger(d=a.Event("show.bs.dropdown2")),!d.isDefaultPrevented())return f.addClass("open").trigger("shown.bs.dropdown2"),!1}},f.prototype.keydown=function(b){if(/(38|40|27)/.test(b.keyCode)){var d=a(this);if(b.preventDefault(),b.stopPropagation(),!d.is(".disabled, :disabled")){var f=c(d),g=f.hasClass("open");if(!g||g&&27==b.keyCode)return 27==b.which&&f.find(e).focus(),d.click();var h=a("[role=menu] li:not(.divider):visible a",f);if(h.length){var i=h.index(h.filter(":focus"));38==b.keyCode&&i>0&&i--,40==b.keyCode&&i<h.length-1&&i++,~i||(i=0),h.eq(i).focus()}}}};var g=a.fn.dropdown2;a.fn.dropdown2=function(b){return this.each(function(){var c=a(this),d=c.data("dropdown2");d||c.data("dropdown2",d=new f(this)),"string"==typeof b&&d[b].call(c)})},a.fn.dropdown2.Constructor=f,a.fn.dropdown2.noConflict=function(){return a.fn.dropdown2=g,this},a(document).on("click.bs.dropdown2.data-api",".dropdown2 form",function(a){a.stopPropagation()}).on("keydown.bs.dropdown2.data-api",e+", [role=menu]",f.prototype.keydown),a(function(){a(e).on("mouseenter.bs.dropdown2.data-api",f.prototype.dropdown2)})}(window.jQuery),+function(a){"use strict";var b=function(b,c){this.options=c,this.$element=a(b),this.$backdrop=this.isShown=null,this.options.remote&&this.$element.load(this.options.remote)};b.DEFAULTS={backdrop:!0,keyboard:!0,show:!0},b.prototype.toggle=function(a){return this[this.isShown?"hide":"show"](a)},b.prototype.show=function(b){var c=this,d=a.Event("show.bs.modal",{relatedTarget:b});this.$element.trigger(d),this.isShown||d.isDefaultPrevented()||(this.isShown=!0,this.escape(),this.$element.on("click.dismiss.modal",'[data-dismiss="modal"]',a.proxy(this.hide,this)),this.backdrop(function(){var d=a.support.transition&&c.$element.hasClass("fade");c.$element.parent().length||c.$element.appendTo(document.body),c.$element.show(),d&&c.$element[0].offsetWidth,c.$element.addClass("in").attr("aria-hidden",!1),c.enforceFocus();var e=a.Event("shown.bs.modal",{relatedTarget:b});d?c.$element.find(".modal-dialog").one(a.support.transition.end,function(){c.$element.focus().trigger(e)}).emulateTransitionEnd(300):c.$element.focus().trigger(e)}))},b.prototype.hide=function(b){b&&b.preventDefault(),b=a.Event("hide.bs.modal"),this.$element.trigger(b),this.isShown&&!b.isDefaultPrevented()&&(this.isShown=!1,this.escape(),a(document).off("focusin.bs.modal"),this.$element.removeClass("in").attr("aria-hidden",!0).off("click.dismiss.modal"),a.support.transition&&this.$element.hasClass("fade")?this.$element.one(a.support.transition.end,a.proxy(this.hideModal,this)).emulateTransitionEnd(300):this.hideModal())},b.prototype.enforceFocus=function(){a(document).off("focusin.bs.modal").on("focusin.bs.modal",a.proxy(function(a){this.$element[0]===a.target||this.$element.has(a.target).length||this.$element.focus()},this))},b.prototype.escape=function(){this.isShown&&this.options.keyboard?this.$element.on("keyup.dismiss.bs.modal",a.proxy(function(a){27==a.which&&this.hide()},this)):this.isShown||this.$element.off("keyup.dismiss.bs.modal")},b.prototype.hideModal=function(){var a=this;this.$element.hide(),this.backdrop(function(){a.removeBackdrop(),a.$element.trigger("hidden.bs.modal")})},b.prototype.removeBackdrop=function(){this.$backdrop&&this.$backdrop.remove(),this.$backdrop=null},b.prototype.backdrop=function(b){var c=this.$element.hasClass("fade")?"fade":"";if(this.isShown&&this.options.backdrop){var d=a.support.transition&&c;if(this.$backdrop=a('<div class="modal-backdrop '+c+'" />').appendTo(document.body),this.$element.on("click.dismiss.modal",a.proxy(function(a){a.target===a.currentTarget&&("static"==this.options.backdrop?this.$element[0].focus.call(this.$element[0]):this.hide.call(this))},this)),d&&this.$backdrop[0].offsetWidth,this.$backdrop.addClass("in"),!b)return;d?this.$backdrop.one(a.support.transition.end,b).emulateTransitionEnd(150):b()}else!this.isShown&&this.$backdrop?(this.$backdrop.removeClass("in"),a.support.transition&&this.$element.hasClass("fade")?this.$backdrop.one(a.support.transition.end,b).emulateTransitionEnd(150):b()):b&&b()};var c=a.fn.modal;a.fn.modal=function(c,d){return this.each(function(){var e=a(this),f=e.data("bs.modal"),g=a.extend({},b.DEFAULTS,e.data(),"object"==typeof c&&c);f||e.data("bs.modal",f=new b(this,g)),"string"==typeof c?f[c](d):g.show&&f.show(d)})},a.fn.modal.Constructor=b,a.fn.modal.noConflict=function(){return a.fn.modal=c,this},a(document).on("click.bs.modal.data-api",'[data-toggle="modal"]',function(b){var c=a(this),d=c.attr("href"),e=a(c.attr("data-target")||d&&d.replace(/.*(?=#[^\s]+$)/,"")),f=e.data("modal")?"toggle":a.extend({remote:!/#/.test(d)&&d},e.data(),c.data());b.preventDefault(),e.modal(f,this).one("hide",function(){c.is(":visible")&&c.focus()})}),a(document).on("show.bs.modal",".modal",function(){a(document.body).addClass("modal-open")}).on("hidden.bs.modal",".modal:not(#jquery_ajax_loading)",function(){a(document.body).removeClass("modal-open")})}(window.jQuery),+function(a){"use strict";var b=function(a,b){this.type=this.options=this.enabled=this.timeout=this.hoverState=this.$element=null,this.init("tooltip",a,b)};b.DEFAULTS={animation:!0,placement:"top",selector:!1,template:'<div class="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',trigger:"hover focus",title:"",delay:0,html:!1,container:!1},b.prototype.init=function(b,c,d){this.enabled=!0,this.type=b,this.$element=a(c),this.options=this.getOptions(d);for(var e=this.options.trigger.split(" "),f=e.length;f--;){var g=e[f];if("click"==g)this.$element.on("click."+this.type,this.options.selector,a.proxy(this.toggle,this));else if("manual"!=g){var h="hover"==g?"mouseenter":"focusin",i="hover"==g?"mouseleave":"focusout";this.$element.on(h+"."+this.type,this.options.selector,a.proxy(this.enter,this)),this.$element.on(i+"."+this.type,this.options.selector,a.proxy(this.leave,this))}}this.options.selector?this._options=a.extend({},this.options,{trigger:"manual",selector:""}):this.fixTitle()},b.prototype.getDefaults=function(){return b.DEFAULTS},b.prototype.getOptions=function(b){return b=a.extend({},this.getDefaults(),this.$element.data(),b),b.delay&&"number"==typeof b.delay&&(b.delay={show:b.delay,hide:b.delay}),b},b.prototype.getDelegateOptions=function(){var b={},c=this.getDefaults();return this._options&&a.each(this._options,function(a,d){c[a]!=d&&(b[a]=d)}),b},b.prototype.enter=function(b){var c=b instanceof this.constructor?b:a(b.currentTarget)[this.type](this.getDelegateOptions()).data("bs."+this.type);return clearTimeout(c.timeout),c.hoverState="in",c.options.delay&&c.options.delay.show?void(c.timeout=setTimeout(function(){"in"==c.hoverState&&c.show()},c.options.delay.show)):c.show()},b.prototype.leave=function(b){var c=b instanceof this.constructor?b:a(b.currentTarget)[this.type](this.getDelegateOptions()).data("bs."+this.type);return clearTimeout(c.timeout),c.hoverState="out",c.options.delay&&c.options.delay.hide?void(c.timeout=setTimeout(function(){"out"==c.hoverState&&c.hide()},c.options.delay.hide)):c.hide()},b.prototype.show=function(){var b=a.Event("show.bs."+this.type);if(this.hasContent()&&this.enabled){if(this.$element.trigger(b),b.isDefaultPrevented())return;var c=this.tip();this.setContent(),this.options.animation&&c.addClass("fade");var d="function"==typeof this.options.placement?this.options.placement.call(this,c[0],this.$element[0]):this.options.placement,e=/\s?auto?\s?/i,f=e.test(d);f&&(d=d.replace(e,"")||"top"),c.detach().css({top:0,left:0,display:"block"}).addClass(d),this.options.container?c.appendTo(this.options.container):c.insertAfter(this.$element);var g=this.getPosition(),h=c[0].offsetWidth,i=c[0].offsetHeight;if(f){var j=this.$element.parent(),k=d,l=document.documentElement.scrollTop||document.body.scrollTop,m="body"==this.options.container?window.innerWidth:j.outerWidth(),n="body"==this.options.container?window.innerHeight:j.outerHeight(),o="body"==this.options.container?0:j.offset().left;d="bottom"==d&&g.top+g.height+i-l>n?"top":"top"==d&&g.top-l-i<0?"bottom":"right"==d&&g.right+h>m?"left":"left"==d&&g.left-h<o?"right":d,c.removeClass(k).addClass(d)}var p=this.getCalculatedOffset(d,g,h,i);this.applyPlacement(p,d),this.hoverState=null,this.$element.trigger("shown.bs."+this.type)}},b.prototype.applyPlacement=function(b,c){var d,e=this.tip(),f=e[0].offsetWidth,g=e[0].offsetHeight,h=parseInt(e.css("margin-top"),10),i=parseInt(e.css("margin-left"),10);isNaN(h)&&(h=0),isNaN(i)&&(i=0),b.top=b.top+h,b.left=b.left+i,jQuery.offset.setOffset(e[0],a.extend({using:function(a){e.css({top:Math.round(a.top),left:Math.round(a.left)})}},b),0),e.addClass("in");var j=e[0].offsetWidth,k=e[0].offsetHeight;if("top"==c&&k!=g&&(d=!0,b.top=b.top+g-k),/bottom|top/.test(c)){var l=0;b.left<0&&(l=-2*b.left,b.left=0,e.offset(b),j=e[0].offsetWidth,k=e[0].offsetHeight),this.replaceArrow(l-f+j,j,"left")}else this.replaceArrow(k-g,k,"top");d&&e.offset(b)},b.prototype.replaceArrow=function(a,b,c){this.arrow().css(c,a?50*(1-a/b)+"%":"")},b.prototype.setContent=function(){var a=this.tip(),b=this.getTitle();a.find(".tooltip-inner")[this.options.html?"html":"text"](b),a.removeClass("fade in top bottom left right")},b.prototype.hide=function(){function b(){"in"!=c.hoverState&&d.detach()}var c=this,d=this.tip(),e=a.Event("hide.bs."+this.type);return this.$element.trigger(e),e.isDefaultPrevented()?void 0:(d.removeClass("in"),a.support.transition&&this.$tip.hasClass("fade")?d.one(a.support.transition.end,b).emulateTransitionEnd(150):b(),this.hoverState=null,this.$element.trigger("hidden.bs."+this.type),this)},b.prototype.fixTitle=function(){var a=this.$element;(a.attr("title")||"string"!=typeof a.attr("data-original-title"))&&a.attr("data-original-title",a.attr("title")||"").attr("title","")},b.prototype.hasContent=function(){return this.getTitle()},b.prototype.getPosition=function(){var b=this.$element[0];return a.extend({},"function"==typeof b.getBoundingClientRect?b.getBoundingClientRect():{width:b.offsetWidth,height:b.offsetHeight},this.$element.offset())},b.prototype.getCalculatedOffset=function(a,b,c,d){return"bottom"==a?{top:b.top+b.height,left:b.left+b.width/2-c/2}:"top"==a?{top:b.top-d,left:b.left+b.width/2-c/2}:"left"==a?{top:b.top+b.height/2-d/2,left:b.left-c}:{top:b.top+b.height/2-d/2,left:b.left+b.width}},b.prototype.getTitle=function(){var a,b=this.$element,c=this.options;return a=b.attr("data-original-title")||("function"==typeof c.title?c.title.call(b[0]):c.title)},b.prototype.tip=function(){return this.$tip=this.$tip||a(this.options.template)},b.prototype.arrow=function(){return this.$arrow=this.$arrow||this.tip().find(".tooltip-arrow")},b.prototype.validate=function(){this.$element[0].parentNode||(this.hide(),this.$element=null,this.options=null)},b.prototype.enable=function(){this.enabled=!0},b.prototype.disable=function(){this.enabled=!1},b.prototype.toggleEnabled=function(){this.enabled=!this.enabled},b.prototype.toggle=function(b){var c=b?a(b.currentTarget)[this.type](this.getDelegateOptions()).data("bs."+this.type):this;c.tip().hasClass("in")?c.leave(c):c.enter(c)},b.prototype.destroy=function(){this.hide().$element.off("."+this.type).removeData("bs."+this.type)};var c=a.fn.tooltip;a.fn.tooltip=function(c){return this.each(function(){var d=a(this),e=d.data("bs.tooltip"),f="object"==typeof c&&c;e||d.data("bs.tooltip",e=new b(this,f)),"string"==typeof c&&e[c]()})},a.fn.tooltip.Constructor=b,a.fn.tooltip.noConflict=function(){return a.fn.tooltip=c,this}}(jQuery),+function(a){"use strict";var b=function(a,b){this.init("popover",a,b)};if(!a.fn.tooltip)throw new Error("Popover requires tooltip.js");b.DEFAULTS=a.extend({},a.fn.tooltip.Constructor.DEFAULTS,{placement:"right",trigger:"click",content:"",template:'<div class="popover"><div class="arrow"></div><h3 class="popover-title"></h3><div class="popover-content"></div></div>'}),b.prototype=a.extend({},a.fn.tooltip.Constructor.prototype),b.prototype.constructor=b,b.prototype.getDefaults=function(){return b.DEFAULTS},b.prototype.setContent=function(){var a=this.tip(),b=this.getTitle(),c=this.getContent();a.find(".popover-title")[this.options.html?"html":"text"](b),a.find(".popover-content")[this.options.html?"html":"text"](c),a.removeClass("fade top bottom left right in"),a.find(".popover-title").html()||a.find(".popover-title").hide()},b.prototype.hasContent=function(){return this.getTitle()||this.getContent()},b.prototype.getContent=function(){var a=this.$element,b=this.options;return a.attr("data-content")||("function"==typeof b.content?b.content.call(a[0]):b.content)},b.prototype.arrow=function(){return this.$arrow=this.$arrow||this.tip().find(".arrow")},b.prototype.tip=function(){return this.$tip||(this.$tip=a(this.options.template)),this.$tip};var c=a.fn.popover;a.fn.popover=function(c){return this.each(function(){var d=a(this),e=d.data("bs.popover"),f="object"==typeof c&&c;e||d.data("bs.popover",e=new b(this,f)),"string"==typeof c&&e[c]()})},a.fn.popover.Constructor=b,a.fn.popover.noConflict=function(){return a.fn.popover=c,this}}(jQuery),+function(a){"use strict";function b(c,d){var e,f=a.proxy(this.process,this);this.$element=a(a(c).is("body")?window:c),this.$body=a("body"),this.$scrollElement=this.$element.on("scroll.bs.scroll-spy.data-api",f),this.options=a.extend({},b.DEFAULTS,d),this.selector=(this.options.target||(e=a(c).attr("href"))&&e.replace(/.*(?=#[^\s]+$)/,"")||"")+" .nav li > a",this.offsets=a([]),this.targets=a([]),this.activeTarget=null,this.refresh(),this.process()}b.DEFAULTS={offset:10},b.prototype.refresh=function(){var b=this.$element[0]==window?"offset":"position";this.offsets=a([]),this.targets=a([]);{var c=this;this.$body.find(this.selector).map(function(){var d=a(this),e=d.data("target")||d.attr("href"),f=/^#./.test(e)&&a(e);return f&&f.length&&[[f[b]().top+(!a.isWindow(c.$scrollElement.get(0))&&c.$scrollElement.scrollTop()),e]]||null}).sort(function(a,b){return a[0]-b[0]}).each(function(){c.offsets.push(this[0]),c.targets.push(this[1])})}},b.prototype.process=function(){var a,b=this.$scrollElement.scrollTop()+this.options.offset,c=this.$scrollElement[0].scrollHeight||this.$body[0].scrollHeight,d=c-this.$scrollElement.height(),e=this.offsets,f=this.targets,g=this.activeTarget;if(b>=d)return g!=(a=f.last()[0])&&this.activate(a);for(a=e.length;a--;)g!=f[a]&&b>=e[a]&&(!e[a+1]||b<=e[a+1])&&this.activate(f[a])},b.prototype.activate=function(b){this.activeTarget=b,a(this.selector).parents(".active").removeClass("active");var c=this.selector+'[data-target="'+b+'"],'+this.selector+'[href="'+b+'"]',d=a(c).parents("li").addClass("active");d.parent(".dropdown-menu").length&&(d=d.closest("li.dropdown").addClass("active")),d.trigger("activate.bs.scrollspy")};var c=a.fn.scrollspy;a.fn.scrollspy=function(c){return this.each(function(){var d=a(this),e=d.data("bs.scrollspy"),f="object"==typeof c&&c;e||d.data("bs.scrollspy",e=new b(this,f)),"string"==typeof c&&e[c]()})},a.fn.scrollspy.Constructor=b,a.fn.scrollspy.noConflict=function(){return a.fn.scrollspy=c,this},a(window).on("load",function(){a('[data-spy="scroll"]').each(function(){var b=a(this);b.scrollspy(b.data())})})}(jQuery),+function(a){"use strict";var b=function(b){this.element=a(b)};b.prototype.show=function(){var b=this.element,c=b.closest("ul:not(.dropdown-menu)"),d=b.data("target");if(d||(d=b.attr("href"),d=d&&d.replace(/.*(?=#[^\s]*$)/,"")),!b.parent("li").hasClass("active")){var e=c.find(".active:last a")[0],f=a.Event("show.bs.tab",{relatedTarget:e});if(b.trigger(f),!f.isDefaultPrevented()){var g=a(d);this.activate(b.parent("li"),c),this.activate(g,g.parent(),function(){b.trigger({type:"shown.bs.tab",relatedTarget:e})})}}},b.prototype.activate=function(b,c,d){function e(){f.removeClass("active").find("> .dropdown-menu > .active").removeClass("active"),b.addClass("active"),g?(b[0].offsetWidth,b.addClass("in")):b.removeClass("fade"),b.parent(".dropdown-menu")&&b.closest("li.dropdown").addClass("active"),d&&d()}var f=c.find("> .active"),g=d&&a.support.transition&&f.hasClass("fade");g?f.one(a.support.transition.end,e).emulateTransitionEnd(150):e(),f.removeClass("in")};var c=a.fn.tab;a.fn.tab=function(c){return this.each(function(){var d=a(this),e=d.data("bs.tab");e||d.data("bs.tab",e=new b(this)),"string"==typeof c&&e[c]()})},a.fn.tab.Constructor=b,a.fn.tab.noConflict=function(){return a.fn.tab=c,this},a(document).on("click.bs.tab.data-api",'[data-toggle="tab"], [data-toggle="pill"]',function(b){b.preventDefault(),a(this).tab("show")})}(jQuery),+function(a){var b,c=function(a){function b(b){var c={},d=/^jQuery\d+$/;return a.each(b.attributes,function(a,b){b.specified&&!d.test(b.name)&&(c[b.name]=b.value)}),c}function c(b,c){var d=this,e=a(d);if((d.value==e.attr("placeholder")||""==d.value)&&e.hasClass("placeholder"))if(e.data("placeholder-password")){if(e=e.hide().next().show().attr("id",e.removeAttr("id").data("placeholder-id")),b===!0)return e[0].value=c;e.focus()}else d.value="",e.removeClass("placeholder"),d==document.activeElement&&d.select()}function d(){var d,e=this,f=a(e),g=this.id;if(""==a(e).val()){if("password"==e.type){if(!f.data("placeholder-textinput")){try{d=f.clone().attr({type:"text"})}catch(h){d=a("<input>").attr(a.extend(b(this),{type:"text"}))}d.removeAttr("name").data({"placeholder-password":!0,"placeholder-id":g}).bind("focus.placeholder",c),f.data({"placeholder-textinput":d,"placeholder-id":g}).before(d)}f=f.removeAttr("id").hide().prev().attr("id",g).show()}f.addClass("placeholder"),f[0].value=f.attr("placeholder")}else f.removeClass("placeholder")}var e,f,g="placeholder"in document.createElement("input"),h="placeholder"in document.createElement("textarea"),i={},j=a.valHooks;if(g&&h)f=i.placeholder=function(){return this},f.input=f.textarea=!0;else{if(f=i.placeholder=function(){var a=this;return a.filter((g?"textarea":":input")+"[placeholder]").unbind({"focus.placeholder":c,"blur.placeholder":d}).bind({"focus.placeholder":c,"blur.placeholder":d}).data("placeholder-enabled",!0).trigger("blur.placeholder"),a},f.input=g,f.textarea=h,e={get:function(b){var c=a(b);return c.data("placeholder-enabled")&&c.hasClass("placeholder")?"":b.value},set:function(b,e){var f=a(b);return f.data("placeholder-enabled")?(""==e?(b.value=e,b!=document.activeElement&&d.call(b)):f.hasClass("placeholder")?c.call(b,!0,e)||(b.value=e):b.value=e,f):b.value=e}},!g){var k=j.input;j.input=k?{get:function(){return k.get&&k.get.apply(this,arguments),e.get.apply(this,arguments)},set:function(){return k.set&&k.set.apply(this,arguments),e.set.apply(this,arguments)}}:e}if(!h){var k=j.textarea;j.textarea=k?{get:function(){return k.get&&k.get.apply(this,arguments),e.get.apply(this,arguments)},set:function(){return k.set&&k.set.apply(this,arguments),e.set.apply(this,arguments)}}:e}a(function(){a(document).delegate("form","submit.placeholder",function(){var b=a(".placeholder",this).each(c);setTimeout(function(){b.each(d)},10)})}),a(window).bind("beforeunload.placeholder",function(){a(".placeholder").each(function(){this.value=""})})}return f}(a);b=c.input&&c.textarea?function(){}:function(b){b||(b=a("input, textarea")),b&&c.call(a(b))},b(),b.clear=function(b){function c(b){b.each(function(b,c){c=a(c),c[0].value===c.attr("placeholder")&&c.hasClass("placeholder")&&(c[0].value="")})}b=a(b),c("FORM"===b[0].tagName?b.find("input.placeholder, textarea.placeholder"):b)},window.placeholder=b}(window.jQuery),+function(a){"use strict";var b=function(c,d){this.options=a.extend({},b.DEFAULTS,d),this.$window=a(window).on("scroll.bs.affix.data-api",a.proxy(this.checkPosition,this)).on("click.bs.affix.data-api",a.proxy(this.checkPositionWithEventLoop,this)),this.$element=a(c),this.affixed=this.unpin=this.pinnedOffset=null,this.checkPosition()};b.RESET="affix affix-top affix-bottom",b.DEFAULTS={offset:0},b.prototype.getPinnedOffset=function(){if(this.pinnedOffset)return this.pinnedOffset;this.$element.removeClass(b.RESET).addClass("affix");var a=this.$window.scrollTop(),c=this.$element.offset();return this.pinnedOffset=c.top-a},b.prototype.checkPositionWithEventLoop=function(){setTimeout(a.proxy(this.checkPosition,this),1)},b.prototype.checkPosition=function(){if(this.$element.is(":visible")){var c=a(document).height(),d=this.$window.scrollTop(),e=this.$element.offset(),f=this.options.offset,g=f.top,h=f.bottom;"top"==this.affixed&&(e.top+=d),"object"!=typeof f&&(h=g=f),"function"==typeof g&&(g=f.top(this.$element)),"function"==typeof h&&(h=f.bottom(this.$element));var i=null!=this.unpin&&d+this.unpin<=e.top?!1:null!=h&&e.top+this.$element.height()>=c-h?"bottom":null!=g&&g>=d?"top":!1;if(this.affixed!==i){this.unpin&&this.$element.css("top","");var j="affix"+(i?"-"+i:""),k=a.Event(j+".bs.affix");this.$element.trigger(k),k.isDefaultPrevented()||(this.affixed=i,this.unpin="bottom"==i?this.getPinnedOffset():null,this.$element.removeClass(b.RESET).addClass(j).trigger(a.Event(j.replace("affix","affixed"))),"bottom"==i&&this.$element.offset({top:c-h-this.$element.height()}))}}};var c=a.fn.affix;a.fn.affix=function(c){return this.each(function(){var d=a(this),e=d.data("bs.affix"),f="object"==typeof c&&c;e||d.data("bs.affix",e=new b(this,f)),"string"==typeof c&&e[c]()})},a.fn.affix.Constructor=b,a.fn.affix.noConflict=function(){return a.fn.affix=c,this},a(window).on("load",function(){a('[data-spy="affix"]').each(function(){var b=a(this),c=b.data();c.offset=c.offset||{},c.offsetBottom&&(c.offset.bottom=c.offsetBottom),c.offsetTop&&(c.offset.top=c.offsetTop),b.affix(c)})})}(jQuery);