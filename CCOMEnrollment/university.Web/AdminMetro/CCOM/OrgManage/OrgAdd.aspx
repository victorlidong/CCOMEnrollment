<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgAdd.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.OrgManage.OrgAdd" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>用户</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript">
        function showRight() {
            $("#rightForm").show();
            $("#showA").hide();
            $("#hideA").show();
        }
        function hideRight() {
            $("#rightForm").hide();
            $("#showA").show();
            $("#hideA").hide();
        }
    </script>
    <style type="text/css">
        .splitForm{
            float:left;
        }
        #rightForm{
            display:none
        }
        #hideA{
            display:none;
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
                            <h3 class="page-title"><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>用户
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">
                            <div class="splitForm" id="leftForm">
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>真实姓名</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtRealname" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>学号/工号</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" autocomplete="off" />
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>密码</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPass1" TextMode="Password" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" autocomplete="off" />
                                        <span class="help-inline"><%=(action == MyEnums.ActionEnum.Edit.ToString())?"(不修改密码可不填)":""%></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>确认密码</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPass2" TextMode="Password" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" autocomplete="off" />
                                        <span class="help-inline"><%=(action == MyEnums.ActionEnum.Edit.ToString())?"(不修改密码可不填)":""%></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>所属机构</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlAgency" runat="server" CssClass="select2" />
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>所属角色</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="select2" />
                                    </div>
                                </div>
                                <a href="#" id="showA" onclick="showRight()">显示选填表单</a>
                                <a href="#" id="hideA" onclick="hideRight()">隐藏选填表单</a>
                                <div class="form-actions">
                                    <input name="重置" type="reset" class="btn" value="重 置" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                            <div class="splitForm" id="rightForm">
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle">证件类型</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlIdType" runat="server" CssClass="select2" />
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle">证件号</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtIdNumber" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30"/>
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle">性别</label>
                                    <div class="controls">
                                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="item-margin">
                                            <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                            <asp:ListItem Value="0">女</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">生日</label>
                                    <div class="controls">
                                        <input type="text" id="txtBirthday" runat="server" class="txtInput normal dateISO" readonly="true" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"/>
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