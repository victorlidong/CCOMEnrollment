<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentManage.StudentEdit" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理考生</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <style type="text/css">
        .lead {
            margin-bottom: 0;
            font-size: 12px;
        }

        #lblUI_LoginName {
            font-size: 24px;
        }

        #lblIntroInfo {
            font-size: 14px;
        }

        .form-horizontal .form-actions {
            padding-top: 20px;
            padding-bottom: 10px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .widget {
            margin-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tab3 .icon-chevron-down:gt(4)").click();
        });
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
        function SubmitBasic() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    RealName: $("#txtRealName").val(),
                    fun: 'Basic',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    Sex: $("#ddlSex").val(),
                    BirthDate: $("#txtBirthday").val(),
                    Nationality: $("#ddlNationality").val(),
                    Origin: $("#ddlOrigin").val(),
                    Nation: $("#ddlNation").val(),
                    OverSeas:$("#ddlOverSeas").val(),
                    Degree: $("#ddlDegree").val(),
                    Political: $("#ddlPolitical").val(),
                    SeniorSchool: $("#txtSeniorSchool").val(),
                    ExaminationID: $("#txtExaminationID").val(),
                    Direction: $("#ddlMajor").val(),
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
        function SubmitSchool() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'SchoolUser',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    PhoneNumber: $("#txtPhoneNumber").val(),
                    YKPhoneNumber: $("#txtykPhoneNumber").val(),
                    Address: $("#txtAddress").val(),
                    ZipCode: $("#txtZipCode").val(),
                    Addressee: $("#txtAddressee").val(),
                    AddresseeNumber: $("#txtAddresseeNumber").val(),
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
        function AddMember() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'AddMember',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    Name: $("#txtMName").val(),
                    Realition: $("#txtMRelation").val(),
                    Company: $("#txtMCompany").val(),
                    PhoneNumber: $("#txtMPhone").val(),
                    Politics: $("#ddlMPolitics").val(),
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
        function SubmitPass() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'Pass',
                    schooluserid: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    pass: $("#txtPass").val(),
                    passconfirm: $("#txtPassConfirm").val(),
                },
                success: function (data) {
                    console.log("测试:" + data);
                    if (data['code'] == 0) {
                        parent.jsprint(data["msg"], "", "Error", "");
                    } else {
                        parent.jsprint("修改密码成功！", "", "Success", "");
                        layer.closeAll();
                        //location.reload();
                    }
                }
            });
        }
        function SubmitID() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    IDType: $("#ddlIDType").val(),
                    fun: 'StudentID',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    IDNumber: $("#txtIDNumber").val(),
                    IDPicture: $("#txtIDPicture").val(),
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
        function SubmitPicture() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'StudentPicture',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    Picture: $("#txtPicture").val(),
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
        function SubmitAee() {
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: 'StudentAEE',
                    UID: '<%=DESEncrypt.Encrypt(this.id.ToString()) %>',
                    AEENumber: $("#txtAEENumber").val(),
                    AEEPicture: $("#txtAEEPicture").val(),
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
        function Level2Data() {
            var id = $("#ddlDepartment").val();
            $.ajax({
                type: "GET",
                url: "../StudentApply/UpdateUserInfor.ashx",
                data: {
                    fun: "Major",
                    depid: id
                },
                success: function (data) {
                    var obj = $("#ddlMajor");
                    obj.html(data);
                }
            });
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
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title"><%=Page.Title %>
                            </h3>
                        </div>
                    </div>
                    <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span2">
                            <div class="pull-right">
                                <asp:Label ID="lblFace" runat="server" Style="text-align: right;"></asp:Label>
                            </div>
                        </div>
                        <div class="span2">
                            <div class="row-fluid" style="height: 32px; padding-top: 30px;">
                                <asp:Label ID="lblUI_LoginName" runat="server" CssClass="lead text-info"></asp:Label>
                            </div>
                            <div class="row-fluid">
                                <asp:Label ID="lblIntroInfo" Visible="false" runat="server" CssClass="lead"></asp:Label>
                            </div>
                        </div>
                        <div class="span8">
                            <div class="controls" id="deps" runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="space10"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs _step2">
                                    <li class="active"><a href="#tab1" data-toggle="tab">个人信息</a></li>
                                    <li class=""><a href="#tab2" data-toggle="tab">证件信息</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab1">
                                        <div class="row-fluid">
                                            <div class="span7">
                                                <div class="widget purple">
                                                    <div class="widget-title">
                                                        <h4>1、个人信息</h4>
                                                        <span class="tools">
                                                            <a href="javascript:EditForm('edit_basic');" title="编辑" class="icon-edit _step3"></a>
                                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                                            <%--<a href="javascript:;" class="icon-remove"></a>--%>
                                                        </span>
                                                    </div>
                                                    <div class="widget-body" style="display: block;">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    <td>姓名：<asp:Label ID="lblRealName" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>性别：<asp:Label ID="lblSex" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>出生日期：<asp:Label ID="lblBirthday" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>民族：<asp:Label ID="lblNationality" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>高考所在地：<asp:Label ID="lblOrigin" runat="server"></asp:Label>
                                                                    </td>
                                                                    
                                                                    <td>文化程度：<asp:Label ID="lblDegree" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>政治面貌：<asp:Label ID="lblPolitical" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>高中毕业院校：<asp:Label ID="lblSeniorSchool" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>高考报名号：<asp:Label ID="lblExaminationID" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>专业方向：<asp:Label ID="lblDirection" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>是否华侨：<asp:Label ID="lblOverSeas" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>国籍：<asp:Label ID="lblNation" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3"><a href="javascript:EditForm('edit_basic');" class="btn btn-success"><i class="icon-plus icon-white"></i>编辑</a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="span5">
                                                <div class="widget blue">
                                                    <div class="widget-title">
                                                        <h4>2、联系方式</h4>
                                                        <span class="tools">
                                                            <a href="javascript:EditForm('edit_school');" title="编辑" class="icon-edit _step3"></a>
                                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                                        </span>
                                                    </div>
                                                    <div class="widget-body" style="display: block;">
                                                        <table class="table">
                                                            <tbody>
                                                                <tr>
                                                                    
                                                                    <td>常规移动电话：<asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>艺考期间移动电话：<asp:Label ID="lblykPhoneNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">邮编：<asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">录取通知书邮寄地址：<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>收件人：<asp:Label ID="lblAddressee" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2">收件人电话：<asp:Label ID="lblAddresseeNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3"><a href="javascript:EditForm('edit_school');" class="btn btn-success"><i class="icon-plus icon-white"></i>编辑</a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="space10"></div>
                                        <div class="row-fluid">
                                            <div class="widget red">
                                                <div class="widget-title">
                                                    <h4>3、家庭联系信息</h4>
                                                    <span class="tools">
                                                        <a href="javascript:EditForm('addHomeMember');" title="编辑" class="icon-edit _step3"></a>
                                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                                    </span>
                                                </div>
                                                <div class="widget-body" style="display: block;">
                                                    <asp:Repeater ID="rptList" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                            <tr>
                                                                <th align="left">姓名</th>
                                                                <th align="center">亲属关系</th>
                                                                <th align="center">政治面貌</th>
                                                                <th align="center">工作单位</th>
                                                                <th align="center">联系方式</th>
                                                                <th align="center">操作</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="left"><%#GetMName(int.Parse(Eval("Fm_id").ToString()))%></td>
                                                            <td align="left"><%#GetRelation(int.Parse(Eval("Fm_id").ToString()))%></td>
                                                            <td align="left"><%#GetPolitics(int.Parse(Eval("Fm_id").ToString()))%></td>
                                                            <td align="left"><%#GetCompany(int.Parse(Eval("Fm_id").ToString()))%></td>
                                                            <td align="left"><%#GetPhoneNumber(int.Parse(Eval("Fm_id").ToString()))%></td>
                                                            <td align="center">                            
                                &nbsp;
                                 <asp:LinkButton ID="lbtDelete" OnClientClick="return confirm('确定要删除吗?');void(0);" OnClick="lbtSingleDelete_Click" runat="server" ToolTip='<%# DESEncrypt.Encrypt(Eval("Fm_id").ToString())%>' Text="删除"></asp:LinkButton>
                                                                &nbsp;
                                
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                    <a href="javascript:EditForm('addHomeMember');" class="btn btn-success"><i class="icon-plus icon-white"></i>添加</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab2">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="tabbable custom-tab">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="Div1">
                                                            <div class="row-fluid">
                                                                <div class="span12">
                                                                    <div class="widget purple">
                                                                        <div class="widget-title">
                                                                            <h4>4、证件信息</h4>
                                                                            <span class="tools">
                                                                                <a href="javascript:EditForm('edit_id');" title="编辑" class="icon-edit _step3"></a>
                                                                                <a href="javascript:;" class="icon-chevron-down"></a>
                                                                            </span>
                                                                        </div>
                                                                        <div class="widget-body" style="display: block;">
                                                                            <table class="table">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>证件类型：<asp:Label ID="lblIDType" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>证件号：<asp:Label ID="lblIDNumber" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>证件照：<img id="lblIDPicture" runat="server" alt="头像" style="height:100px;width:100px;" />
                                                                                            
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6"><a href="javascript:EditForm('edit_id');" class="btn btn-success"><i class="icon-plus icon-white"></i>编辑</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                     </div>
                                                                </div>
                                                            </div>
                                                            <div class="space10"></div>
                                                            <div class="row-fluid">
                                                                <div class="span12">
                                                                    <div class="widget blue">
                                                                        <div class="widget-title">
                                                                            <h4>5、免冠照片</h4>
                                                                            <span class="tools">
                                                                                <a href="javascript:EditForm('edit_picture');" title="编辑" class="icon-edit _step3"></a>
                                                                                <a href="javascript:;" class="icon-chevron-down"></a>
                                                                            </span>
                                                                        </div>
                                                                        <div class="widget-body" style="display: block;">
                                                                            <table class="table">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>近期免冠照片：<img id="lblPicture" runat="server" alt="头像" style="height:100px;width:100px;" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6"><a href="javascript:EditForm('edit_picture');" class="btn btn-success"><i class="icon-plus icon-white"></i>编辑</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="space10"></div>
                                                            <div class="row-fluid">
                                                                <div class="span12">
                                                                    <div class="widget red">
                                                                        <div class="widget-title">
                                                                            <h4>6、省艺术联考信息</h4>
                                                                            <span class="tools">
                                                                                <a href="javascript:EditForm('edit_aee');" title="编辑" class="icon-edit _step3"></a>
                                                                                <a href="javascript:;" class="icon-chevron-down"></a>
                                                                            </span>
                                                                        </div>
                                                                        <div class="widget-body" style="display: block;">
                                                                            <table class="table">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>省艺术联考考生号：<asp:Label ID="lblAEENumber" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>省艺术联考合格证：<img id="lblAEEPicture" runat="server" alt="头像" style="height:100px;width:100px;" /></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6"><a href="javascript:EditForm('edit_aee');" class="btn btn-success"><i class="icon-plus icon-white"></i>编辑</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="space10"></div>    
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
                    <div class="row-fluid">
                        <div id="edit_basic" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>编辑个人信息</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>姓名</td>
                                                    <td>
                                                        <asp:TextBox ID="txtRealName" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                    <td>性别</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSex">
                                                            <asp:ListItem Text="男" Value="0"></asp:ListItem>
                                                             <asp:ListItem Text="女" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>是否华侨</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlOverSeas" >
                                                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                                             <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="help-inline"></span></td>
                                                    <td>国籍</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlNation" />
                                                        <span class="help-inline"></span></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td>出生日期</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtBirthday" runat="server" onClick="WdatePicker()" minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>民族</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlNationality" /></td>
                                                    <td>政治面貌</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlPolitical" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>高考所在地</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlOrigin" />
                                                    <span class="help-inline"></span></td>
                                                     <td>文化程度</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDegree" runat="server" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>高中毕业院校</td>
                                                    <td>
                                                        <asp:TextBox ID="txtSeniorSchool" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                    <td>高考报名号</td>
                                                    <td>
                                                        <asp:TextBox ID="txtExaminationID" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>专业方向</td>
                                                    <td colspan="3">
                                                        <asp:DropDownList onchange="Level2Data()" runat="server" ID="ddlDepartment" />
                                                        <asp:DropDownList runat="server" ID="ddlMajor" />
                                                    </td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="btnSubmit" value="确认修改" class="btn btn-success" onclick="SubmitBasic()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_school" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>编辑联系方式</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    
                                                    <td>常规移动电话</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPhoneNumber" runat="server"  minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                    <td>艺考期间移动电话</td>
                                                    <td>
                                                        <asp:TextBox ID="txtykPhoneNumber" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>邮编</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtZipCode" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                    </tr>
                                                <tr>
                                                    <td>录取通知书邮寄地址</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtAddress" runat="server"  CssClass="span12 " minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>收件人</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddressee" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                    <td>收件人电话</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtAddresseeNumber" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="btnSubmt" value="确认修改" class="btn btn-success" onclick="SubmitSchool()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_pass" style="display: none; width: 550px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>修改账户密码</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>密码</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPass" TextMode="Password" CssClass="input-medium" runat="server" minlength="2" MaxLength="100" required />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>确认密码</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassConfirm" TextMode="Password" CssClass="input-medium" runat="server" minlength="2" MaxLength="100" required />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button1" value="确认修改" class="btn btn-success" onclick="SubmitPass()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="addHomeMember" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>添加家庭成员</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>姓名</td>
                                                    <td>
                                                        <asp:TextBox ID="txtMName" runat="server"  minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                    <td>亲属关系</td>
                                                    <td>
                                                        <asp:TextBox ID="txtMRelation" runat="server"  minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>工作单位</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtMCompany" runat="server"  CssClass="span12 " minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>联系方式</td>
                                                    <td>
                                                        <asp:TextBox ID="txtMPhone" runat="server" minlength="2" MaxLength="100" autocomplete="off"/>
                                                        <span class="help-inline"></span></td>
                                                    <td>政治面貌</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlMPolitics" />
                                                        <span class="help-inline"></span></td>
                                                    </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button2" value="确认添加" class="btn btn-success" onclick="AddMember()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_id" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>编辑证件信息信息</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>证件类型</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlIDType" runat="server"/>
                                                        <span class="help-inline"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>证件号码</td>
                                                    <td>
                                                        <asp:TextBox ID="txtIDNumber" runat="server" minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>证件照</td>
                                                    <td>
                                                        <div class=" filesupload ">
                                                            <asp:TextBox ID="txtIDPicture" runat="server" onkeydown="return false;" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>
                                                            <span class="btn btn-file">
                                                                <span class="fileupload-new">选择图片</span>
                                                                <input type="file" id="fulIDPicture" class="default" name="fulIDPicture" onchange="Upload('SingleFile', 'txtIDPicture', 'fulIDPicture','1');" />
                                                            </span>
                                                            <span id="Span1" class="uploading">正在上传，请稍候...</span>
                                                            <a href="CertificateReference.html" target="_blank">上传须知</a>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button3" value="确认修改" class="btn btn-success" onclick="SubmitID()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_picture" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>编辑免冠照片</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>近期免冠照片</td>
                                                    <td>
                                                        <div class=" filesupload ">
                                                            <asp:TextBox ID="txtPicture" runat="server" onkeydown="return false;" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>
                                                            <span class="btn btn-file">
                                                                <span class="fileupload-new">选择图片</span>
                                                                <input type="file" id="fulPicture" class="default" name="fulPicture" onchange="Upload('SingleFile', 'txtPicture', 'fulPicture','1');" />
                                                            </span>
                                                            <span id="Span3" class="uploading">正在上传，请稍候...</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button5" value="确认修改" class="btn btn-success" onclick="SubmitPicture()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div id="edit_aee" style="display: none; width: 700px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>修改省艺术联考信息</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <table class="table table-striped table-bordered dataTable">
                                            <tbody>
                                                <tr>
                                                    <td>省艺术联考考生号</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAEENumber" runat="server"  minlength="2" MaxLength="100" autocomplete="off" />
                                                        <span class="help-inline"></span></td>
                                                </tr>
                                                <tr>
                                                    <td>省艺术联考合格证</td>
                                                    <td>
                                                        <div class=" filesupload ">
                                                            <asp:TextBox ID="txtAEEPicture" runat="server" onkeydown="return false;" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>
                                                            <span class="btn btn-file">
                                                                <span class="fileupload-new">选择图片</span>
                                                                <input type="file" id="fulAEEPicture" class="default" name="fulAEEPicture" onchange="Upload('SingleFile', 'txtAEEPicture', 'fulAEEPicture','1');" />
                                                            </span>
                                                            <span id="Span4" class="uploading">正在上传，请稍候...</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button6" value="确认修改" class="btn btn-success" onclick="SubmitAee()" />
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
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
    <!--end common script for all pages-->
</body>
</html>
