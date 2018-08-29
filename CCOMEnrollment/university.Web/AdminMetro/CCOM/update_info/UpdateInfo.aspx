<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInfo.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.update_info.UpdateInfo" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改信息</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <style type="text/css">
        .firstTab{
            text-align:center;
            width:20%;
        }
        .otherTab{
            text-align:center;
            width:40%;
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
                            <div class="gohistory" style="margin-left:20px;">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">修改信息
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>

                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid" id="teacher_page" runat="server">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="2"--%>
                                    <tr>
                                        <td style="width:10%;">职工号：</td>
                                        <td><label runat="server" id="lblNumber"></label></td>
                                    </tr>
                                    <tr>
                                        <td>姓名：</td>
                                        <td><label runat="server" id="lblName"></label></td>
                                    </tr>
                                    <tr>
                                        <td>性别：</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlGender">
                                                <asp:ListItem Text="男" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="女" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>部门：</td>
                                        <td><label runat="server" id="lblAgency"></label></td>
                                    </tr>
                                    <tr>
                                        <td>职称：</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlTitle"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>学科方向：</td>
                                        <td><input id="txtSubject" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>Email：</td>
                                        <td><input id="txtEmail" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>手机：</td>
                                        <td><input id="txtPhone" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>固定电话：</td>
                                        <td><input id="txtFixedPhone" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>办公地址：</td>
                                        <td><input id="txtPlace" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>自我介绍：</td>
                                        <td>
                                            <textarea id="txtIntroduce" runat="server" style="width:98%;height:100px;"></textarea>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid" id="student_page" runat="server">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="2"--%>
                                    <tr>
                                        <td style="width:10%;">学号：</td>
                                        <td><label runat="server" id="lblOtherNumber"></label></td>
                                    </tr>
                                    <tr>
                                        <td>姓名：</td>
                                        <td><label runat="server" id="lblOtherName"></label></td>
                                    </tr>
                                    <tr>
                                        <td>性别：</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlOtherGender">
                                                <asp:ListItem Text="男" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="女" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>手机：</td>
                                        <td><input id="txtOtherPhone" runat="server"/></td>
                                    </tr>
                                    <tr>
                                        <td>班级：</td>
                                        <td><label runat="server" id="lblClass"></label></td>
                                    </tr>
                                    <tr>
                                        <td>出生日期：</td>
                                        <td><asp:TextBox ID="txtBirthday" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="220px" /></td>
                                    </tr>
                                    <tr>
                                        <td>民族：</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlNationality"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>政治面貌：</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlPolitic"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="span6" id="other_page" runat="server">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <%--真实姓名--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_realname">真实姓名</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_realname" runat="server" CssClass="input-block-level required" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--所在机构--%>
                                    <div id="div_user_agency" class="row-fluid" runat="server">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_Agency">所在机构</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_Agency" runat="server" CssClass="input-block-level required" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--学号--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_User_number">工号/学号</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_number" runat="server" CssClass="input-block-level digits" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--性别--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="rbl_User_gender">性别</label>
                                                <div class="controls">
                                                    <asp:RadioButtonList CssClass="item-margin" ID="rbl_User_gender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                        <asp:ListItem Value="1" Selected="True">男 </asp:ListItem>
                                                        <asp:ListItem Value="0">女 </asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--出生日期--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">出生日期</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_birthday" onfocus="this.blur()" runat="server" CssClass="input-block-level" onClick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--添加日期--%>
                                    <div class="row-fluid" style="visibility:hidden">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">添加日期</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_User_addtime" onfocus="this.blur()" runat="server" CssClass="input-block-level" ReadOnly="true" />

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    <div class="span12" style="text-align: left;">
                        <div>
                            <asp:Button ID="btn_Submit" runat="server" Text="提交保存" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
</body>
</html>