<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfResource.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfResource" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
    <style>
        .ystep-lg
        {
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ystep").loadStep({
                //ystep的外观大小
                size: "large",
                color: "green",
                steps: [{
                    title: "① 填写时间节点",
                    content: "确定注册开启、结束时间及排考时间"
                }, {
                    title: "② 确认机构信息",
                    content: "按照学院、部、系、专业编辑机构信息"
                }, {
                    title: "③ 配置专业方向",
                    content: "完善专业方向信息"
                }, {
                    title: "④ 配置管理员信息",
                    content: "确认其他各系部管理员信息"
                }, {
                    title: "⑤ 配置资源信息",
                    content: "确认考场、评委及其他相关资源信息"
                }, {
                    title: "⑥ 添加科目",
                    content: "配置专业方向对应科目信息"
                }, {
                    title: "⑦ 完成",
                    content: "配置年度报考信息完成"
                }]
            });
            $(".ystep").setStep(5);
        });
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
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txtApplyStart" defaultbutton="btnSubmit">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">配置报考信息
                            </h3>
                        </div>
                    </div>
                    <div class="space12"></div>
                    <div class="row-fluid">
                        <div class="space12"></div>
                        <div class="control-group">
                            <div class="ystep"></div>
                        </div>

                        <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs _step2">
                                    <li class="active"><a href="#tab1" data-toggle="tab">考场列表</a></li>
                                    <li class=""><a href="#tab2" data-toggle="tab">评委列表</a></li>
                                    <li class=""><a href="#tab3" data-toggle="tab">其他资源</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab1">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <a href="../ResManage/RoomAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>添加考场</a>
                                                <a href="../ResManage/RoomBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量添加</a>
                                            </div>

                                            <div class="span6">
                                                <div class="pull-right">
                                                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn" OnClick="btnRoomSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="roomList" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                            <tr>
                                                                <th width="5%">序号</th>
                                                                <th align="left">所在楼</th>
                                                                <th align="left">楼层</th>
                                                                <th align="left">房间号</th>
                                                                <th align="left">容量</th>
                                                                <th align="left">备注</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# roomList.Items.Count + 1 %>
                                                            </td>
                                                            <td align="left">
                                                                <%#GetRoomBuildingName(int.Parse(Eval("Er_id").ToString()))%>
                                                            </td>
                                                            <td align="left"><%#GetRoomFloor(int.Parse(Eval("Er_id").ToString()))%></td>
                                                            <td align="left"><%#GetRoomName(int.Parse(Eval("Er_id").ToString()))%></td>
                                                            <td align="left"><%#GetRoomCapacity(int.Parse(Eval("Er_id").ToString()))%></td>
                                                            <td align="left"><%#GetRoomRemark(int.Parse(Eval("Er_id").ToString()))%></td>
                                                            <td align="center">
                                                                <%#GetRoomEditLink(DESEncrypt.Encrypt(Eval("Er_id").ToString()))%>
                               
                                &nbsp;
                                 <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该考场吗?');void(0);" OnClick="lbtRoomDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Er_id").ToString())%>' Text="删除"></asp:LinkButton>
                                                                &nbsp;
                                
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <%#roomList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>



                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                显示<asp:TextBox ID="txtRoomPageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtRoomPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
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
                                    <div class="tab-pane" id="tab2">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="Div1">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <a href="../ResManage/JudgeAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>添加评委</a>
                                                <a href="../ResManage/JudgeBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量添加</a>
                                            </div>
                                            <div class="span6">
                                                <div class="pull-right">
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtInput"></asp:TextBox>
                                                    <asp:Button ID="Button1" runat="server" Text="搜 索" CssClass="btn" OnClick="JudgebtnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                            <tr>
                                                                <th width="5%">序号</th>
                                                                <th align="left">姓名</th>
                                                                <th align="left">教工号</th>
                                                                <th align="left">所属部门</th>
                                                                <th align="left">职称</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# Repeater1.Items.Count + 1 %>
                                                            </td>
                                                            <td align="left"><%#GetJudgeName(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeStaffNumber(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeDepartment(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="left"><%#GetJudgeTitle(int.Parse(Eval("Judge_id").ToString()))%></td>
                                                            <td align="center">
                                                                <%#GetJudgeEditLink(DESEncrypt.Encrypt(Eval("Judge_id").ToString()))%>
                               
                                &nbsp;
                                 <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除该评委吗?');void(0);" OnClick="lbtJudgeDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Judge_id").ToString())%>' Text="删除"></asp:LinkButton>
                                                                &nbsp;
                                
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <%#Repeater1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>



                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                显示<asp:TextBox ID="txtJudgePageNum" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtJudgePageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                                            </div>
                                            <div class="span6">
                                                <div class="pull-right">
                                                    <div id="Div2" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                   <div class="tab-pane" id="tab3">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="Div4">
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <a href="javascript:EditForm('edit_resource', '0', '')" class="btn btn-success"><i class="icon-plus icon-white"></i>添加资源</a>
                                                <a href="../ResManage/ResourceBatchAdd.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id) %>&selectid=<%=this.ddlResourceType.SelectedValue %>>" class="btn btn-success"><i class="icon-plus icon-white"></i>批量添加</a>
                                            </div>
                                            <div class="span4">
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
                                            <div class="span4">
                                                <div class="pull-right">
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txtInput"></asp:TextBox>
                                                    <asp:Button ID="Button2" runat="server" Text="搜 索" CssClass="btn" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <!--列表展示.开始-->
                                                <asp:Repeater ID="Repeater2" runat="server">
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
                                                                <%# Repeater2.Items.Count + 1 %>
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
                                                        <%#Repeater2.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>



                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span6">
                                                显示<asp:TextBox ID="txtResoursePageNumber" runat="server" CssClass="input-mini" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
                                            </div>
                                            <div class="span6">
                                                <div class="pull-right">
                                                    <div id="Div3" runat="server" class="dataTables_paginate paging_bootstrap pagination"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>

                    <div class="span12" style="text-align: left;">
                        <div class="form-actions">
                            <input type="button" class="btn btn-success" value="上一步" onclick="javascript: history.go(-1);" />
                            &nbsp;
                            <input name="重置" type="reset" class="btn" value="重 置" />
                            &nbsp;
                            <asp:Button ID="btnUpload" Visible="False" runat="server" Text="提　交" CssClass="btn btn-success" />
                            &nbsp;
                            <asp:Button ID="btnSubmit" runat="server" Text="下一步" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
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
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
