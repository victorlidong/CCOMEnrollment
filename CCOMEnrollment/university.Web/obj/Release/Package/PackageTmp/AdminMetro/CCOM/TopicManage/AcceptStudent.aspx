<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptStudent.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.TopicManage.AcceptStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript" src="../../metro/js/data-js/data-horse.js"></script>
</head>
<body class="mainbody" style="background-color: white;">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important; min-height: 100%;">
                <div class="container-fluid">
                    <div class="space10"></div>
                    <div class="row-fluid" style="text-align: center;">
                        <div class="span12">
                            <table>
                                <%--<tr>
                                    <td style="text-align: right; width: 30%;">
                                        <label>审核意见：</label>
                                    </td>
                                    <td style="text-align: left; width: 70%;">
                                        <textarea id="reviewText" name="DIVCSS5" style="width:300px;" cols="40" rows="4"> </textarea>  
                                        &nbsp;</td>
                                </tr>--%>
                                
                                <tr>
                                    <td></td>
                                    <td style="text-align: center; width:100% ">
    
                                          <asp:Button ID="Button1" runat="server" Text="接收" CssClass="btn btn-success" OnClick="btnSubmit_Success" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button2" runat="server" Text="拒绝" CssClass="btn btn-error" OnClick="btnSubmit_Error" />
                                    </td>

                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="space5"></div>

    </form>
     <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>