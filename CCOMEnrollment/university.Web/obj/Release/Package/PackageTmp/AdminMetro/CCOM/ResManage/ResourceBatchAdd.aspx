<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceBatchAdd.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ResManage.ResourceBatchAdd" %>
<%@ Import Namespace="university.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>资源导入</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
    <style>
        .ystep-lg {
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">资源导入
                            </h3>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12" style="margin-top: 20px; margin-bottom: 20px;">
                            <div class="control-group">
                                <div class="ystep"></div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>资源类型</label>
                                <div class="controls"> 
                                    <asp:DropDownList runat="server" ID="ddlResourceType">
                                        <asp:ListItem Text="生源地" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="政治面貌" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="民族" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="国籍" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="乐器" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="教育程度" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="证件类型" Value="7"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>模板下载</label>
                                <div class="controls">
                                    <asp:LinkButton ID="prodExcel" runat="server" CssClass="btn btn-success" OnClick="prodExcel_Click"><i class="icon-paste"></i>导出Excel模板</asp:LinkButton>
                                    <asp:Label ID="txtAttentionStr" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">上传模板：</label>
                                <div class="controls">
                                    <asp:FileUpload ID="txtUserUpload" runat="server" />
                                </div>
                            </div>
                            <div class="space5"></div>

                            <div class="form-actions">
                                <input name="重置" type="reset" class="btn" value="重 置" />
                                <asp:Button ID="btnUpload" runat="server" Text="提　交" CssClass="btn btn-success" OnClick="btnUpload_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <asp:Label ID="lblError" runat="server" CssClass="span12"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
</body>
</html>
