<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplySms.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.ApplySms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>验证用户安全密码</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
		<!--
    function applySuccess(msg, isFirst, number) {
        parent.applyCallBack(msg, isFirst, number);
        var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
        parent.layer.close(index); //执行关闭
    }
    function cancelApply() {
        //art.dialog.close();//关闭弹出框
        var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
        parent.layer.close(index); //执行关闭
    }
    function gotoApplyRecord(url) {
        parent.showApplyRecord(url);
        cancelApply();
    }
    //-->
    </script>
</head>
<body style="background-color: white;">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important; min-height: 100%;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div runat="server" id="divFirstApply" style="text-align: center;">
                                <p>
                                    <img alt="欢迎您使用通知推送系统，福利来啦，首次使用免费领取1000条！" src="/images/news/logo/first_apply.jpg" />
                                </p>
                                <p>
                                    <asp:Button ID="btnFirstApply" CssClass="btn btn-success" runat="server" Text="点击领取" OnClick="btnFirstApply_Click" />
                                    <asp:Label ID="lblFirstApply" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </p>
                            </div>
                            <div runat="server" id="divNormalApply">
                                <div style="padding-left: 10px; padding-top: 10px;">
                                    <p>
                                        <b style="color: red;">*</b>短信条数：
                    <asp:TextBox ID="txtNumber" CssClass="input-mini" minlength="1" MaxLength="4" runat="server" required></asp:TextBox>
                                        <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                                    </p>
                                    <p style="vertical-align: top; width: 400px">
                                        <span><b style="color: red;">*</b>申请理由：</span>
                                        <asp:TextBox ID="txtReason" runat="server" minlength="1" MaxLength="500" TextMode="MultiLine" Height="80" Width="380" required></asp:TextBox>
                                    </p>
                                    <p style="text-align: right; width: 400px;">
                                        <input id="Button2" type="button" value="取消" class="btn" onclick="cancelApply()" />
                                        &nbsp;&nbsp;<asp:Button ID="btnApply" CssClass="btn btn-success" runat="server" Text="申请" OnClick="btnApply_Click" />
                                        <asp:Label ID="lblApply" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>
