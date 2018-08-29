<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportFractionalline.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.CEEManege.ImportFractionalline" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>导入分数线</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->

</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="pannelScrit" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidUserid" runat="server" />
        <asp:HiddenField ID="hidSchoolid" runat="server" />

        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">导入分数线
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    高考成绩管理
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">导入分数线
                                </li>
                            </ul>--%>
                        </div>
                    </div>

                    <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>模板下载</label>
                                <div class="controls">
                                    <asp:LinkButton ID="prodExcel" runat="server" CssClass="btn _step2" OnClick="prodExcel_Click"><i class="icon-paste"></i>　导出Excel模板</asp:LinkButton>
                                    <asp:Label ID="txtAttentionStr" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>上传模板</label>
                                <div class="controls">
                                    <asp:FileUpload ID="txtFraUpload" runat="server" />
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnUpload" runat="server" Text="提　交" CssClass="btn btn-success" OnClick="btnUpload_Click" />
                                &nbsp;
                                <asp:Button ID="btnSubmit"  Visible="False" runat="server" Text="查看分数线" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <asp:Label ID="lblError" runat="server" CssClass="span12"></asp:Label>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="alert alert-block alert-info fade in">
                                <button data-dismiss="alert" class="close" type="button">×</button>
                                <h4 class="alert-heading">说明：</h4>
                                <p>
                                    1.请先下载Excel模板填写相关信息；
                            <br>
                                    2.EXCEL模板中，红色标题是必填字段，黑色标题是选填字段；　
                            <br>
                                    3.省份、（文科）满分、（理科）满分为必填项，省份的值为选择项，不可更改选项的名字；
                            <br>
                                    4.如果该省三本和艺术线均无，请至少填写该省一本或二本的分数；
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
            <!--#include file="/metro/include/footer_common.html"-->
</body>
</html>

