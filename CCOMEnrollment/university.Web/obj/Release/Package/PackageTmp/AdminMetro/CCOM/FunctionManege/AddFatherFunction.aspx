<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFatherFunction.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AddFatherFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加父级功能</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
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
                            <h3 class="page-title">添加一级父功能
                            </h3>
                            <ul class="breadcrumb">
                                <li>
                                    <a href="#">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="#">功能权限管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">添加父功能
                                </li>
                            </ul>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
              
                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">

                            <div class="control-group">
                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>父功能名称</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="span2" minlength="2" MaxLength="40" required />
                                </div>
                            </div>
                            
                            <div class="control-group">
                                <label class="control-label" for="txtSort"><b style="color: red;">*</b>父功能序号</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtSort" placeholer="请填入数字（如：1）" runat="server" CssClass="span2 " minlength="1" MaxLength="50" required />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label"><b style="color: red;">*</b>父功能状态</label>
                                <div class="controls" style="padding-top: 3px;">

                                    <asp:RadioButton ID="optOpen" runat="server" Text="开启" Checked="true" GroupName="optApplyStatus" />
                                    &nbsp;
                            <asp:RadioButton ID="optClose" runat="server" Text="关闭" GroupName="optApplyStatus" />
                                    <asp:Label ID="lblSms" runat="server" Text="（处于开启状态时，可以进行赋权）"></asp:Label>

                                </div>
                            </div>                            
                             <div class="form-actions" style="border-top: none;margin-bottom: 50px;">
                              <asp:Button ID="btnSubmit" runat="server" Text="确认添加" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                                        <asp:Label ID="lblSubmit" runat="server" Text=""></asp:Label>
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
