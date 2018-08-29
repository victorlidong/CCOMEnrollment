var __verifyPwdCallback;
function showPwdVerify(callback) {
    __verifyPwdCallback = callback;
    var url = "/adminmetro/manager/VerifySecurityPwd.aspx";
    $.layer({
        type: 2,
        title: ['安全密码验证'],
        shadeClose: false,
        closeBtn: [0, true],
        shade: [0.3, '#000'],
        border: [0],
        area: ['450px', '250px'],
        iframe: { src: url }
    });
}
function verifyPwdCallback(data) {
    if (typeof (__verifyPwdCallback) =="function" ) {
        __verifyPwdCallback(data);
    }
}
