<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceAdd.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ResManage.ResourceAdd" ValidateRequest="false" %>
<%@ Import Namespace="university.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加资源</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ueditor.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <style type="text/css">
    
        .first-tab {
            display: block;
            min-height: 300px;
            /*margin-bottom: 10px;*/
        }

        .normal-tab {
            /*display: none;*/
            min-height: 200px;
            /*margin-bottom: 10px;*/
        }
        span.li-title {
            
        }
    </style>
    <script type="text/javascript">

        var v6dialog;

        function isNumber(str) {
            var r = /^[0-9]{0,4}[0-9]$/;
            return r.test(str);
        }
        function addUserDeptCallBack(deptIdList, deptNameList) {
            $("#hidUserDept").val(deptIdList);
            $("#txtUserDept").val(deptNameList);
        }
        function clearUserDept() {
            $("#hidUserDept").val("");
            $("#txtUserDept").val("");
        }
        $(document).ready(function () {
         
        });
    </script>
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
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <h3 class="page-title">编辑资源信息
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
              
                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">

                            <div class="control-group">
                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>资源类别</label>
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
                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>名称</label>
                                <div class="controls">
                                    <asp:TextBox ID="nameText" runat="server" CssClass="span6 " minlength="1" MaxLength="250" required />
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
    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
    <!--end common script for all pages-->
    <!--script for this page-->
 <%--     <script type="text/javascript" src="/metro/js/form-component.js"></script>--%>
    <!--end script for this page-->
</body>
</html>
