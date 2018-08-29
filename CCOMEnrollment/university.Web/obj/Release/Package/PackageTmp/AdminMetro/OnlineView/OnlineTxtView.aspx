<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineTxtView.aspx.cs" Inherits="university.Web.AdminMetro.OnlineView.OnlineTxtView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .dbtn {
            height: 25px;
            padding: 0 10px;
            font-weight: bold;
            cursor: pointer;
        }
        .dbtn:hover {
            background-color: #F5E2AF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border-bottom: 2px solid #eee; padding: 10px;">
            <div style="float: left; font-size: 28px; font-weight: bold;" runat="server" id="divFileName">
               
            </div>
            <div style="float: right; padding-right: 10px;">
                <asp:Button ID="Button1" CssClass="dbtn"  runat="server" Text="↓下载" OnClick="Button1_OnClick" />
            </div>
            <div style="clear: both;"></div>
        </div>
        <div style="padding: 20px; line-height: 20px;">
            <div runat="server" id="txtContainner"></div>
        </div>
    </form>
</body>
</html>
