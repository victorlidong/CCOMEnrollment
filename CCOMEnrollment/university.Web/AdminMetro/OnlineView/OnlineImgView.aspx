<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineImgView.aspx.cs" Inherits="university.Web.AdminMetro.OnlineView.OnlineImgView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>圈圈校园-图片预览</title>
    <style type="text/css">
        .divImg {
            text-align: center;
            vertical-align: middle;
            margin-top: 5%;
        }
        .dbtn {
          height: 25px;
            padding: 0 10px;
            font-weight: bold;
            cursor: pointer;
        }
        .dbtn:hover {
            background-color: #F5E2AF;
        }
        .img-view {
            width: 98%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
                <div style="border-bottom: 2px solid #eee; padding: 10px;">
            <div style="float: left; font-size: 28px; font-weight: bold;" runat="server" id="divFileName">
               
            </div>
            <div style="float: right; padding-right: 10px;">
                <asp:Button ID="Button1" CssClass="dbtn" runat="server" Text="↓下载" OnClick="Button1_OnClick" />
            </div>
            <div style="clear: both;"></div>
        </div>
        <div class="divImg">
            <asp:Image ID="imgViewer" CssClass="img-view" runat="server" AlternateText="图片在线预览失败" />
        </div>

    </form>
</body>
</html>
