<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputScore.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ScoreManage.ComputScore" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->

</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">总成绩计算方式
                            </h3>
                       </div>
                        <div class="row-fluid">
                            <h5>成绩计算方式示例：最终成绩=指导教师评分*1+较小值（口头答辩成绩，软件验收成绩）*0.7
                            </h5>
                            <label>当前计算方式：</label>
                        </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <div class="span7">
                            <div class="widget blue" style="width:100%">
                                <div class="widget-body">

                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="control-group">
                                                <label>最终成绩=指导教师评分*</label>
                                                <asp:TextBox ID="txtTeacher" runat="server" Width="50px"></asp:TextBox>
                                                <label>+</label>
                                                <asp:DropDownList runat="server" Width="80px" ID="ddlM">
                                                    <asp:ListItem Text="较小值" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="较大值" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                                <label>(口头答辩成绩，软件验收成绩)*</label>
                                                <asp:TextBox ID="txtOther" runat="server" Width="50px"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                            <asp:Button ID="btn_Submit" runat="server" Text="提交保存" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
