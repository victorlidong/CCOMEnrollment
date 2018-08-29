<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamEdit.aspx.cs" EnableEventValidation="false" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.ExamEdit" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
 <%--   <script type="text/javascript">
        $(document).ready(function () {
            $("#tab3 .icon-chevron-down:gt(4)").click();
        });
        function Level1Data() {
            var id = $("#ddlBuilding").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Building",
                    depid: id
                },
                success: function (data) {
                    $("#ddlFloor").html(data);
                    $("#ddlRoom").html("");
                    $("#lbNumber").html("");
                }
            });
        }
        function Level2Data() {
            var building = $("#ddlBuilding").val();
            var floor = $("#ddlFloor").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Floor",
                    building: building,
                    floor: floor
                },
                success: function (data) {
                    var obj = $("#ddlRoom");
                    obj.html(data);
                }
            });
        }
        function Level3Data() {
            var building = $("#ddlBuilding").val();
            var floor = $("#ddlFloor").val();
            var room = $("#ddlRoom").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Room",
                    building: building,
                    floor: floor,
                    room: room
                },
                success: function (data) {
                    var obj = $("#lbNumber");
                    obj.html(data);
                }
            });
        }
        function LevelRest1Data() {
            var id = $("#ddlRestBuilding").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Building",
                    depid: id
                },
                success: function (data) {
                    $("#ddlRestFloor").html(data);
                    $("#ddlRestRoom").html("");
                    $("#lbRestNumber").html("");
                }
            });
        }
        function LevelRest2Data() {
            var building = $("#ddlRestBuilding").val();
            var floor = $("#ddlRestFloor").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Floor",
                    building: building,
                    floor: floor
                },
                success: function (data) {
                    var obj = $("#ddlRestRoom");
                    obj.html(data);
                }
            });
        }
        function LevelRest3Data() {
            var building = $("#ddlRestBuilding").val();
            var floor = $("#ddlRestFloor").val();
            var room = $("#ddlRestRoom").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "Room",
                    building: building,
                    floor: floor,
                    room: room
                },
                success: function (data) {
                    var obj = $("#lbRestNumber");
                    obj.html(data);
                }
            });
        }
        function LevelSubjectData() {
            var agency = $("#ddlOragin").val();
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: "GetSubject",
                    Agency: agency,
                    Manager: $("#txtManagerID").val(),
                },
                success: function (data) {
                    var obj = $("#ddlSubject");
                    obj.html(data);
                }
            });
        }
        function EditForm(id) {
            $("#" + id).show();
            var _width = $("#" + id).width();
            $.layer({
                type: 1,
                shade: [0.8, '#000'],
                area: [_width + 'px', 'auto'],
                title: false,
                border: [0],
                shadeClose: true,
                page: { dom: '#' + id },
                closeBtn: [0, true],
                close: function (index) {
                    $("#" + id).hide();
                }
            });
        }
        function DeleteLine() {
            if ($("#deps input[name='dep']").length > 0) {
                $("#deps input[name='dep']:last").remove();
                $("#deps br:last").remove();
            }
        }
        function SubmitResource() {
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: 'UpdateExam',
                    Oragin: $("#ddlOragin").val(),
                    Subject: $("#ddlSubject").val(),
                },
                success: function (data) {
                    
                    if (data == "") {
                        parent.jsprint("请选择正确的专业方向及科目", "", "Error", "");
                    }else{
                        $("#deps").append(data);
                        layer.closeAll();
                    }
                }
            });
        }
        function StrCombine() {
            var str = "";
            $("#deps input[name='dep']").each(function () {
                var line = $(this).attr("data-id");
                if (line != '')
                    str += line + "|";
            });
            $("#txtAddName").val(str);
            $.ajax({
                type: "GET",
                url: "./ExamAddStudent.ashx",
                data: {
                    fun: 'AddExam',
                    Name: $("#txtExamName").val(),
                    ExamID: $("#txtExamID").val(),
                    Buliding: $("#ddlBuilding").val(),
                    Floor: $("#ddlFloor").val(),
                    Room: $("#ddlRoom").val(),
                    RestBuilding: $("#ddlRestBuilding").val(),
                    RestFloor: $("#ddlRestFloor").val(),
                    RestRoom: $("#ddlRestRoom").val(),
                    StartTime: $("#txtStartTime").val(),
                    EndTime: $("#txtEndTime").val(),
                    Subject: $("#txtAddName").val(),
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                        location.reload();
                    } else {
                        parent.jsprint(data["msg"], "", "Success", "");
                        location.reload();
                    }
                }
            });
        }
    </script>--%>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txtExamName">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">编辑答辩组
                            </h3>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <%--基本信息--%>
                        <div class="span6">
                            <div class="widget-body">
                                <asp:TextBox ID="txtExamID" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                <asp:TextBox ID="txtManagerID" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                <%--答辩组名称--%>
                                    <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>答辩组名称</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtGroupName" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                    <%--答辩组类型--%>
                                     <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>答辩组类型</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddltype" runat="server" CssClass="select2" />
                                    </div>
                                    </div>
                                      <%--组长--%>
                                      <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>组长工号</label>
                                     <div class="controls">
                                        <asp:TextBox ID="txtTeaNumber" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                                  <%--答辩时间--%>
                                    <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>时间</label>
                                    <div class="controls">

                                        <%--<asp:TextBox ID="txtReplyTime" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                         --%> 
                                        <input type="text" id="txtReplyTime" runat="server" class="txtInput normal dateISO"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })"/>
                                         <span class="help-inline"></span>
                                    </div>
                                </div>
                                   <%--答辩地点--%>
                                    <div class="control-group">
                                    <label class="control-label" for="txtTitle"><b style="color: red;">*</b>地点</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtReplyRoom" runat="server" CssClass="txtInput normal " minlength="2" MaxLength="30" />
                                        <span class="help-inline"></span>
                                    </div>
                                </div>
                         
                         
                                <%--添加科目--%>
                                <div class="row-fluid" style="display:none">
                                    <div class="span10">
                                        <div class="control-group">
                                            <label class="control-label">添加科目</label>
                                            <asp:TextBox ID="txtAddName" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                            <div class="controls" id="deps" runat="server">
                                                <a href="javascript:EditForm('addSubject')" class="btn btn-success"><i class="icon-plus icon-white"></i>添加科目</a>
                                                <a href="javascript:DeleteLine();" class="btn  btn-warning"><i class="icon-ok icon-white"></i>移除科目</a>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                      
                       
      
                            </div>
                        </div>
                    </div>

                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                          <div class="form-actions">
                                    <input name="重置" type="reset" class="btn" value="重 置" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="完 成" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                </div>
                    </div>
                    <div class="row-fluid">
                        <div id="addSubject" style="display: none; width: 360px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>添加科目</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid" id="contentTab">
                                        <label class="control-label">专业方向</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" onchange="LevelSubjectData()" ID="ddlOragin" Style="width: 133px;" />
                                        </div>
                                        <br />
                                        <label class="control-label">科目</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="ddlSubject" Style="width: 133px;" />
                                        </div>
                                        <br />
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="btnSubmt" value="确认添加" class="btn btn-success" onclick="SubmitResource()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
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
