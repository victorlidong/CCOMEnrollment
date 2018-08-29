<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentManage.StudentList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理用户
    </title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
        function AlertForm(id) {
            $.layer({
                type: 2,
                shadeClose: true,
                title: "选择机构",
                closeBtn: [0, true],
                shade: [0.8, '#000'],
                border: [0],
                offset: ['20px', ''],
                area: ['500px', ($(window).height() - 50) + 'px'],
                iframe: { src: '../OrgManage/OrgSelect.aspx?id=' + id + "&refresh=true&fun_id=" + '<%=this.fun_id.ToString()%>' }
            });
        }
    </script>
    <script type="text/javascript">
        var nwin;
        function openwindow(url, sTitle) {
            if (url == '') return false;
            if (nwin && !nwin.closed)
                nwin.close();
            sWidth = 680;
            sHeight = 520;
            var l = (window.screen.availWidth - sWidth) / 2;
            var t = (window.screen.availHeight - sHeight) / 2;
            //console.log(l, t, window.screen.availWidth, window.screen.availHeight);
            nwin = window.open(url, sTitle, 'left=' + l + ',top=' + t + ',innerHeight=' + sHeight + ',innerWidth=' + sWidth + ',width=' + sWidth + ',height=' + sHeight + ',scrollbars=yes,resizable=yes,location=no');
            nwin.focus();
        }
        function SendText() {
            document.getElementById("txtKeywords").value = $("#InputText").val();
        }
    </script>
    <style type="text/css">
        /*.select_box {
            padding-top: 10px;
        }*/
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="hidUoid" runat="server" Value="-1" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">用户管理
                            </h3>
                        </div>
                    </div>
                    <div class="row-fluid _step1">
                        <div class="span8">
                            <span style="float: left;">请选择机构：</span>
                            <asp:DropDownList ID="ddlOrgan" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgan_SelectedIndexChanged"></asp:DropDownList>
                            <%--<a  onclick="AlertForm('ddlOrgan');" class="btn">快速选择</a>--%>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <span>请选择用户角色：</span>
                            <asp:DropDownList ID="ddlprovence" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="ddlProvence_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="span4">
                            <div class="pull-right">
                                <asp:HiddenField ID="txtKeywords" runat="server" />
                                <input id="InputText" type="text" class="txtInput" placeholder="姓名/学号" />
                                <script type="text/javascript">
                                    document.getElementById("InputText").value = document.getElementById("txtKeywords").value;
                                </script>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn btn-success" OnClick="btnSearch_Click" OnClientClick="return SendText()" />
                            </div>
                        </div>

                    </div>
                    <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span6">
                            <%--<span style="float: left; line-height: 30px;">排序方式：</span>--%>
                            <div id="btn-sort-group">
                                <%--<a href="javascript:void(0);" data-value="" class="btn">默认</a>
                                <a href="javascript:void(0);" data-value="User_realname" class="btn">真实姓名</a>
                                <a href="javascript:void(0);" data-value="User_number" class="btn">手机号</a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                <a href="StudentBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>导入用户</a>
                                &nbsp;&nbsp;
                               <%-- <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-warning" OnClick="btnExport_Click"><i class="icon-download"></i>导出用户</asp:LinkButton>
                            --%></div>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                            <tr>
                                                <th width="5%" >序号</th>
                                                 <th style="width: 10%;">姓名</th>
                                                 <th style="width: 10%;">学号</th>
                                                 <th style="width: 12%;">性别</th>
                                                 <th style="width: 12%;">班号</th>
                                                 <th style="width: 16%;">所属角色</th>
                                                 <th style="width: 14%;">操作</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="chkNo" runat="server"><%#st_index++ %></asp:Label>
                                            <asp:HiddenField ID="hidId" Value='<%#Eval("User_id")%>' runat="server" />
                                        </td>
<%--                                        <td style="text-align: center;"><%#Eval("User_realname")%></td>
                                        <td style="text-align: center;"><%#((Boolean) Eval("User_gender"))== false?"男":"女"%></td>
                                        <td style="text-align: center;"><%#GetProvince(Eval("User_id").ToString())%></td>
                                        <td style="text-align: center;"><%#Eval("User_number")%></td>
                                        <td style="text-align: center;"><%#GetPolitics(Eval("User_id").ToString())%></td>
                                        <td style="text-align: center;"><%#Eval("Agency_name")%></td>
                                        <td style="text-align: center;"><%#GetUserActivity((bool) Eval("User_status"))%></td>--%>

                                        <td style="text-align: center;"><%#Eval("User_realname")%></td>
                                        <td style="text-align: center;"><%#Eval("User_number")%></td>
                                        <td style="text-align: center;"><%#((Boolean) Eval("User_gender"))== false?"男":"女"%></td>
                                        <td style="text-align: center;"><%#Eval("Agency_name")%></td>
                                        <td style="text-align: center;"><%#Eval("Role_name")%></td>
                                       <%-- <td style="text-align: center;"><a class="_step2" href="AddStudent2.aspx?action=<%#MyEnums.ActionEnum.Edit %>&fun_id=<%=this.fun_id %>&id=<%#DESEncrypt.Encrypt( Eval("User_id").ToString())%>">修改</a></td>--%>
                                        <td style="text-align: center;"> 
                                            <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该用户吗?');void(0);" OnClick="lbtSingleDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("User_id").ToString())%>' Text="删除"></asp:LinkButton>
                                            &nbsp;
                                           <a href="AddStudent2.aspx?userId=<%#Eval("User_id") %>&action=<%=MyEnums.ActionEnum.Edit.ToString() %>&fun_id=<%=DESEncrypt.Encrypt("15") %>">
                                                  <i class="icon-pencil"></i>修改
                                        </td> 
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
      </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span6">
                            显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                        </div>
                        <div class="span6">
                            <div class="pull-right">
                                <div id="PageContent" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>
