<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNotice.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.ViewNotice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/metro/js/objURL.js"></script>
    <script type="text/javascript">
        $(function () {
            //userid,token,QQUser_id,QQToken
            var userid = null, token = null;
            try {
                if (typeof QQUser_id !== 'undefined') {
                    userid = QQUser_id;
                } else if (typeof window.jinterface !== 'undefined' && typeof window.jinterface.getUserID !== 'undefined') {
                    userid = window.jinterface.getUserID();
                }

                if (typeof QQToken !== 'undefined') {
                    token = QQToken;
                } else if (typeof window.jinterface !== 'undefined' && typeof window.jinterface.getToken !== 'undefined') {
                    token = window.jinterface.getToken();
                } 

                if (token != null) {
                    $("#hidToken").val(token);
                }

                //点击前台按钮，调用后台处理函数
                $("#btnRedirect").click();
            } catch (e) {
                location.href = "/home/push/template/push_error.html";
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hidToken" runat="server" />
        <asp:Button ID="btnRedirect" runat="server" OnClick="PushRedirect" style="visibility: hidden;" />
    </div>
    </form>
</body>
</html>
