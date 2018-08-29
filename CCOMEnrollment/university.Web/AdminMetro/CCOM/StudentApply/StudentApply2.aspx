<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentApply2.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.StudentApply.StudentApply2" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>确认报名信息</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
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
        .ystep-lg
        {
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tab3 .icon-chevron-down:gt(4)").click();
        });
        $(document).ready(function () {
            $(".ystep").loadStep({
                //ystep的外观大小
                size: "large",
                color: "green",
                steps: [{
                    title: "① 填写个人信息",
                    content: "完善个人基本信息及家庭联系方式等"
                }, {
                    title: "② 填写证件信息",
                    content: "填写证件信息、免冠照片及省艺术联考信息"
                }, {
                    title: "③ 完善考试内容",
                    content: "确认考试信息并填写曲目信息"
                }]
            });
            $(".ystep").setStep(2);
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
        function SubmitID() {
            $.ajax({
                type: "GET",
                url: "./UpdateUserInfor.ashx",
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
                url: "./UpdateUserInfor.ashx",
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
                url: "./UpdateUserInfor.ashx",
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
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span8">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">确认报名信息
                            </h3>
                        </div>
                    </div>
                    <div class="space12"></div>
                    <div class="control-group">
                        <div class="ystep"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab1">
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
                                                                        <a target="_blank" href="../StudentManage/CertificateReference.html">上传须知</a>
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
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="row-fluid">
                                    <div class="form-actions">
                                        <input type="button" id="btnSubmit" value="确认修改" class="btn btn-success" onclick="SubmitID()" />
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
                                                            <span id="Span2" class="uploading">正在上传，请稍候...</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="btnSubmt" value="确认修改" class="btn btn-success" onclick="SubmitPicture()" />
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
                                                            <span id="Span3" class="uploading">正在上传，请稍候...</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="form-actions">
                                            <input type="button" id="Button2" value="确认修改" class="btn btn-success" onclick="SubmitAee()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="row-fluid" style="margin-bottom:50px;">
                        <div class="form-actions">
                            <a href="javascript:history.go(-1);" class="btn btn-success">上一步</a>
                            &nbsp;
                            <asp:Button ID="Button3" OnClick="OnClickNextStep" runat="server" Text="下一步" CssClass="btn btn-success" />
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
