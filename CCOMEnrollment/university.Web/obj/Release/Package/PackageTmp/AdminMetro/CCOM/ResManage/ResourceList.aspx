<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ResManage.ResourceList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>资源管理</title>
    <!--#include file="/metro/include/header_common.html"-->
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:HiddenField ID="tabIndex" runat="server" />
        <script type="text/javascript">
            var Index;
            $(function () {
                var tabIndex = $("#tabIndex").val();
                if (tabIndex != "") {
                    showTab("#pageTab1", parseInt(tabIndex));
                }
            });
            function showTab(tabId, tabIndex) {
                $(tabId + " li:eq(" + (tabIndex - 1) + ") a").tab('show');
            }
            function EditForm(id, type, name) {   
                $("#" + id).show();
                $("#nameText").val(name);
                var _width = $("#" + id).width();
                Index = type;
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
            function SubmitResource() {
                $.ajax({
                    type: "GET",
                    url: "../StudentApply/UpdateUserInfor.ashx",
                    data: {
                        fun: 'UpdateResource',
                        TYPE: Index,
                        resourseType: $("#ddlResourceType").val(),
                        name: $("#nameText").val(),
                    },
                    success: function (data) {
                        console.log(Index);
                        if (data['code'] == 0) {
                            parent.jsprint(data["msg"], "", "Error", "");
                        } else {
                            layer.closeAll();
                            location.reload();
                        }
                    }
                });
            }
        </script>
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                            <h3 class="page-title">资源管理
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid" style="margin-left:-40px">
                        <label class="control-label">资源类型</label>
                        <div class="controls"> 
                            <asp:DropDownList runat="server" ID="ddlResourceType" AutoPostBack="true" OnSelectedIndexChanged="DDMo_click">
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
                    <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs" id="pageTab1">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">资源列表</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <a href="javascript:EditForm('edit_resource', '0', '')" class="btn btn-success"><i class="icon-plus icon-white"></i>添加资源</a>
                                                &nbsp;
                                                <a href="ResourceBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>&selectid=<%=this.ddlResourceType.SelectedValue %>>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量添加</a>
                                            </div>
                                            <div class="span6">
                                                <div class="pull-right">
                                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="rptList" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                            <tr>
                                                                <th width="5%">序号</th>
                                                                <th align="left">名称</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# rptList.Items.Count + 1 %>
                                                            </td>
                                                            <td align="left"><%#GetName(int.Parse(Eval(this.selectIndex).ToString()))%></td>
                                                            <td align="center">
                                                                <a href="javascript:EditForm('edit_resource', <%#GetItemID(int.Parse(Eval(this.selectIndex).ToString()))%>, '<%#GetName(int.Parse(Eval(this.selectIndex).ToString())) %>')" >编辑</a>
                               
                                &nbsp;
                                 <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该资源吗?');void(0);" OnClick="lbtSingleDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval(this.selectIndex).ToString())%>' Text="删除"></asp:LinkButton>
                                                                &nbsp;
                                
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

                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_resource" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>编辑资源</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid" id="contentTab">
                                        <div class="span12 tab_con first-tab">

                                            <div class="control-group">
                                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>资源类别</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddltype">
                                                        <asp:ListItem Text="生源地" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="政治面貌" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="民族" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="国籍" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="乐器" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="教育程度" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="证件类型" Value="7"></asp:ListItem>                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label" for="txtTitle"><b style="color: red;">*</b>名称</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="nameText" runat="server" CssClass="span6 " minlength="1" MaxLength="250" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="btnSubmt" value="确认" class="btn btn-success" onclick="SubmitResource()" />
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

    <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>
