<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.AddStudent" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加学生</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">

  
        function addStudent(stuid) {
            $.ajax({
                type: "GET",
                url: "./AddInfo.ashx",
                data: {
                    StudentID: stuid,
                    fun: 'AddStudent',
                    GroupID: '<%=this.apply_id.ToString() %>'
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
        }

        function removeStudent(stuid) {
            $.ajax({
                type: "GET",
                url: "./AddInfo.ashx",
                data: {
                    StudentID: stuid,
                    fun: 'RemoveStudent',
                    GroupID: '<%=this.apply_id.ToString() %>'
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
        }

        function batchAdd() {
            var value = "";
            $('input[type="checkbox"]:checked').each(function () {
                var tmp = $(this).parent().next().val();
                if(tmp != "") value += tmp + ",";
            });
            if (value == "") {
                topWin.jsprint("请选择需要添加的考生", "", "Warning");
                return;
            }
            $.ajax({
                type: "GET",
                url: "./AddInfo.ashx",
                data: {
                    StudentID: value,
                    fun: 'BatchAddStudent',
                    GroupID: '<%=this.apply_id.ToString() %>'
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
        }

        function batchRemove() {
            var value = "";
            $('input[type="checkbox"]:checked').each(function () {
                var tmp = $(this).parent().next().val();
                if (tmp != "") value += tmp + ",";
            });
            if (value == "") {
                topWin.jsprint("请选择需要移除的考生", "", "Warning");
                return;
            }
            $.ajax({
                type: "GET",
                url: "./AddInfo.ashx",
                data: {
                    StudentID: value,
                    fun: 'BatchRemoveStudent',
                    GroupID: '<%=this.apply_id.ToString() %>'
                },
                success: function (data) {
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        layer.closeAll();
                        location.reload();
                    }
                }
            });
        }

        function batchCheck(id) {
            var url = 'BatchCheck.aspx?id=' + id;
            $.layer({
                type: 2,
                title: ['批量审核学生'],
                shadeClose: false,
                closeBtn: [0, true],
                shade: [0.3, '#000'],
                border: [0],
                area: ['600px', '50%'],
                iframe: { src: url }
            });
        }

        //列表标题中的全选
        function MycheckAll(chkobj) {
            if (chkobj.checked == true) {
                $(".checkall input").attr("checked", true);
            } else {
                $(".checkall input").attr("checked", false);
            }
        }


    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">添加学生
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div style="font-size: 16px; font-weight: bold; padding: 10px; border: 1px solid #eee; border-bottom: none;">
                               答辩组名称：<a href="" runat="server" id="title" style="text-decoration:none;"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></a></div>
                        </div>
                    </div>
                     <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span8">
                            <%-- <a class="btn btn-warning" onclick="MycheckAll(this);"><i class="icon-ok"></i><span>全选</span></a> --%>
                            <a href="javascript:void(0);" onclick='batchAdd()' class="btn  btn-warning"><i class="icon-ok icon-white"></i>批量添加</a>
                            <a href="javascript:void(0);" onclick='batchRemove()' class="btn  btn-warning"><i class="icon-ok icon-white"></i>批量移除</a>
                            <asp:LinkButton ID="btnExport" Visible="false" runat="server" CssClass="btn btn-warning" OnClick="btnExport_Click"><i class="icon-download"></i>导出名单</asp:LinkButton>
                        </div>
                        <div class="span4">
                            <div class="pull-right">
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                        <tr>
                                            <th style="text-align:center;">全选<input name="selectAll" type="checkbox" value="" onclick="MycheckAll(this);" style="margin-left:2px;margin-bottom:4px;" /></th>
                                            <th style="text-align:center;">序号</th>
                                             <th style="text-align:center;">姓名</th>
                                             <th style="text-align:center;">性别</th>
                                             <th style="text-align:center;">学号</th>
                                             <th style="text-align:center;">班号</th>
                                             <th style="text-align:center;">添加状态</th>
                                            <th style="text-align:center;">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                         <td style="text-align: center;" id="check">
                                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                                            <asp:HiddenField ID="hidId" Value='<%#Eval("User_id")%>' runat="server" />
                                        </td>
                                        <td style="text-align:center;">
                                            <%#rptList.Items.Count+1%>
                                        </td>
                                         <th style="text-align:center;"><%#Eval("User_realname")%> </td>
                                        <td style="text-align: center;"><%#((Boolean) Eval("User_gender"))== false?"男":"女"%></td>
                                         <th style="text-align:center;"><%#Eval("User_number")%></td>
                                         <th style="text-align:center;"><%#Eval("Agency_name")%></td>
                                         <th style="text-align:center;"><%#GetAddStatus(long.Parse(Eval("User_id").ToString()),this.apply_id)%></td>
                                        <td style="text-align:center;">
                                           <%-- <a href="javascript:void(0);" onclick='addStudent("<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>")'>添加</a>--%>
                                               &nbsp;<a href="javascript:void(0);" onclick='addStudent(<%#Eval("User_id")%>)'>添加</a>
                                            &nbsp;&nbsp;
                                            <a href="javascript:void(0);" onclick='removeStudent(<%#Eval("User_id")%>)'>移除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="row-fluid">
                        <%--<div class="span6">
                            显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                        </div>--%>
                        <div class="span6">
                            <div class="pull-right">
                                <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--common script for all pages-->
        <!--#include file="/metro/include/footer_common.html"-->
        <!--end common script for all pages-->
        <!--script for this page-->
        <!--end script for this page-->
    </form>
</body>
</html>
