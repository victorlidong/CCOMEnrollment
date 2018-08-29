<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeeklyAdd.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.DatumManage.WeeklyAdd" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>提交</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script>
        function AddLine() {
            $("#dep").clone().appendTo($("#deps"));
        }

        function DeleteLine() {
            if ($("#deps select[name='dep']").length > 1) {
                $("#deps select[name='dep']:last").remove();
                $("#deps br:last").remove();
            } else {
                topWin.jsprint("至少需要一个提交类型", "", "Warning");
            }
        }
        function SubmitWeekly() {
            var str = "";
            $("#deps select[name='dep']").each(function () {
                var line = $(this).val()
                if (line != '')
                    str += line + "|";
            });
            $("#txtAddName").val(str);
            document.getElementById("btnSubmit").click();
        }

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
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title"><%=(action == MyEnums.ActionEnum.Edit.ToString())?"编辑":"添加"%>提交
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->

                    <div class="row-fluid" id="contentTab">
                        <div class="span12 tab_con first-tab">
                            <div id="leftForm">
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>开始时间</label>
                                    <div class="controls">
                                        <input type="text" id="txtStarttime" runat="server" class="txtInput normal dateISO"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"/>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>结束时间</label>
                                    <div class="controls">
                                         <input type="text" id="txtEndtime" runat="server" class="txtInput normal dateISO"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"/>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>是否开启</label>
                                    <div class="controls">
                                        <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="item-margin">
                                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                            <asp:ListItem Value="0">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>提交类型</label>
                                    <asp:TextBox ID="txtAddName" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                    <div style="width: 35%;">
                                        <a onclick="javascript:AddLine()" class="_step3" style="margin-left:20px;">
                                            <img style="width: 20px;" src="/images/jia.png" />
                                        </a>
                                        <a onclick="javascript:DeleteLine()">
                                            <img style="width: 20px;" src="/images/jian.png" />
                                        </a>
                                        <div id="deps" style="width: 35%; padding-left:120px;">
                                            <asp:DropDownList ID="dep" name="dep" runat="server" style="width: 220px; margin-top:20px;"/>
                                        
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <input name="重置" type="reset" class="btn" value="重 置" />
                                    <input type="button" id="btnSubmt" value="确 认" class="btn btn-success" onclick="SubmitWeekly()" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click" Style="display: none;" />
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