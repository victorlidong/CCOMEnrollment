<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFractionalline.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.CEEManege.AddFractionalline" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>分数线管理</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <script type="text/javascript">
        function checkNum(obj) {
            //检查是否是非数字值  
            if (isNaN(obj.value)) {
                obj.value = "";
            }
            if (obj != null) {
                //检查小数点后是否对于两位http://blog.csdn.net/shanzhizi  
                if (obj.value.toString().split(".").length > 1 && obj.value.toString().split(".")[1].length > 2) {
                    topWin.jsprint("小数点后多于两位！", "", "Warning");
                    obj.value = "";
                }
            }
        }
    </script>
    <style type="text/css">
        label{
            text-align:center;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidEditorCnt" runat="server" />

        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">分数线管理
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="#">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="#">高考成绩管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">分数线管理
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                            
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span12">
                            <div class="widget blue">
                                <div class="widget-body">
                            <div class="control-group">
                                <label class="span2 control-label" for="txtPro"><b style="color: red;">*</b>省份&nbsp;&nbsp;</label>
                                
                                <div class="controls">
                                     <asp:DropDownList ID="ddlPro_ID" runat="server" CssClass="select2" />
                                </div>
                            </div>       
                            <div class="control-group">
                                <label class="span2 control-label" for="txtTitle">(文科)一本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtYiBenWen" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10"/>
                                </div>
                            </div>          
                            <div class="control-group">
                                <label class="span2 control-label" for="txtSort">（理科）一本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtYiBenLi" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="span2 control-label" for="txtTitle">(文科)二本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtErBenWen" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10"/>
                                </div>
                            </div>          
                            <div class="control-group">
                                <label class="span2 control-label" for="txtSort">（理科）二本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtErBenLi" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="span2 control-label" for="txtTitle">(文科)三本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtSanBenWen" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>          
                            <div class="control-group">
                                <label class="span2 control-label" for="txtSort">（理科）三本录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtSanBenLi" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="span2 control-label" for="txtTitle">(文科)艺术类最低录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtYiShuWen" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>          
                            <div class="control-group">
                                <label class="span2 control-label" for="txtSort">（理科）艺术类最低录取分数线&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtYiShuLi" placeholder="没有该分数线请留空" onkeyup="checkNum(this)" runat="server" CssClass="span2" MaxLength="10" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="span2 control-label" for="txtTitle"><b style="color: red;">*</b>(文科)满分&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtManWen" onkeyup="checkNum(this)" runat="server" CssClass="span2" minlength="2" MaxLength="10" />
                                </div>
                            </div>          
                            <div class="control-group">
                                <label class="span2 control-label" for="txtSort"><b style="color: red;">*</b>（理科）满分&nbsp;&nbsp;</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtManLi" onkeyup="checkNum(this)" runat="server" CssClass="span2" minlength="2" MaxLength="10" />
                                </div>
                            </div>                                         
                             <div class="form-actions" style="border-top: none;margin-bottom: 50px;">
                               <span class="span1">&nbsp;</span>
                              <asp:Button ID="btnSubmit" runat="server" Text="确认添加" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                                        <asp:Label ID="lblSubmit" runat="server" Text=""></asp:Label>
                            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>
