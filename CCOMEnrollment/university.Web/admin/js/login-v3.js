/*********tabs***************/
function loginTabs(tabsId, tabIdx) {
    //tabs nav切换样式
    $(tabsId + "-nav li a").removeClass("selected");
    $(tabsId + "-nav li a").eq(tabIdx).addClass("selected");
    //显示tab content
    $(tabsId + "-content .tab-con").hide();
    $(tabsId + "-content .tab-con").eq(tabIdx).show();
    //if (tabIdx == 2) {
    //    $(".login-trigger-wrap").hide();
    //    $(".password-wrap").hide();
    //} else {
    //    $(".login-trigger-wrap").show();
    //    $(".password-wrap").show();
    //}
    $("#showLoginTab").val(tabIdx);
}
//nav切换样式
function changeNav(navId, navIdx) {
    $(navId).removeClass("selected");
    $(navId).eq(navIdx).addClass("selected");
}

function showvCodeDiv() {
    if ($("#showVCode").val() == "1") {
        $(".vcode-container").show();
    } else {
        $(".vcode-container").hide();
    }
}
//切换验证码
function ToggleCode(obj, codeurl) {
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}
//=========normal tabs toggle=================
function toggleTabs(tabsId, tabIdx) {
    //tabs nav切换样式
    $(tabsId + "-nav li a").removeClass("selected");
    $(tabsId + "-nav li a").eq(tabIdx).addClass("selected");
    //显示tab content
    $(tabsId + "-content .tab-con").hide();
    $(tabsId + "-content .tab-con").eq(tabIdx).show();
}