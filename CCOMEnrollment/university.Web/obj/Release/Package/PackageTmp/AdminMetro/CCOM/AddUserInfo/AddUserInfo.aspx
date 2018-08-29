<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserInfo.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AddUserInfo.AddUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function txt_User_ID_numberClear() {
            if (document.getElementById("txt_User_ID_number").value == "请填写证件号码") {
                document.getElementById("txt_User_ID_number").value = "";
                document.getElementById("txt_User_ID_number").style.color = "#000000";
            }
        }

        function txt_User_ID_numberSet() {
            if (document.getElementById("txt_User_ID_number").value == "") {
                document.getElementById("txt_User_ID_number").value = "请填写证件号码";
                document.getElementById("txt_User_ID_number").style.color = "#cccccc";
            }
        }
    </script>


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />

    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->

</head>


<body class="mainbody">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;" defaultfocus="txt_User_realname" defaultbutton="btn_Submit">
        <input id="hidadminuserid" value="0" runat="server" type="hidden" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">完善考生信息
                            </h3>
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">个人中心
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">完善考生信息
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="space5"></div>
                    <div class="row-fluid">

                        <%--基本信息1--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <%--国籍--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="ddl_UP_nation">国籍</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_UP_nation" runat="server" CssClass="select2" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--民族--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="ddl_UP_nationality">民族</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_UP_nationality" runat="server" CssClass="select2" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--政治面貌--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="ddl_UP_politics">政治面貌</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_UP_politics" runat="server" CssClass="select2" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--文化程度--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="ddl_UP_degree">文化程度</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_UP_degree" runat="server" CssClass="select2" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--高中毕业院校--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_high_school">高中毕业院校</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_high_school" runat="server" CssClass="input-block-level required"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--高考报名号--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_CEE_number">高考报名号</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_CEE_number" runat="server" CssClass="input-block-level email required" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--省艺术联考考生号--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_AEE_number">省艺术联考考生号</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_AEE_number" runat="server" CssClass="input-block-level digits" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--专业考试期间移动电话--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_PE_Iphone">专业考试期间移动电话</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_PE_Iphone" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--常规移动电话--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_PE_Aphone">常规移动电话</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_PE_Aphone" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--高考所在地--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="ddl_UP_province">高考所在地</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_UP_province" runat="server" CssClass="select2"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--录取通知书地址--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_address">录取通知书地址</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_address" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--收件人--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_receiver">收件人</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_receiver" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--收件人电话--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_receiver_phone">收件人电话</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_receiver_phone" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--邮编--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_postal_code">邮编</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_UP_postal_code" runat="server" CssClass="input-block-level" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <%--基本信息2--%>
                        <div class="span6">
                            <div class="widget blue">
                                <div class="widget-body">

                                    <%--上传证件复印件图片--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_ID_picture">证件复印图片</label>
                                                <div class="controls">
                                                    <div class=" filesupload ">

                                                        <asp:TextBox ID="txt_UP_ID_picture" runat="server" onfocus="this.blur()" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>

                                                        <span class="btn btn-file">
                                                            <span class="fileupload-new">选择图片</span>
                                                            <input type="file" id="FileUpload_UP_ID_picture" class="default" name="FileUpload_UP_ID_picture" onchange="Upload('SingleFile', 'txt_UP_ID_picture', 'FileUpload_UP_ID_picture','1');" />
                                                        </span>
                                                        <span id="Span1" class="uploading">正在上传，请稍候...</span>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--显示证件复印件图片--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label"></label>
                                                <div class="controls">
                                                    <img id="img_UP_ID_picture" runat="server" alt="证件复印图片" style="height: 100px; width: 100px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--上传近期免冠照片--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_picture">近期免冠照片</label>
                                                <div class="controls">
                                                    <div class=" filesupload ">

                                                        <asp:TextBox ID="txt_UP_picture" runat="server" onfocus="this.blur()" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>

                                                        <span class="btn btn-file">
                                                            <span class="fileupload-new">选择图片</span>
                                                            <input type="file" id="FileUpload_UP_picture" class="default" name="FileUpload_UP_picture" onchange="Upload('SingleFile', 'txt_UP_picture', 'FileUpload_UP_picture','1');" />
                                                        </span>
                                                        <span id="Span2" class="uploading">正在上传，请稍候...</span>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--显示近期免冠照片--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label"></label>
                                                <div class="controls">
                                                    <img id="img_UP_picture" runat="server" alt="近期1寸蓝底免冠照片" style="height: 100px; width: 100px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--上传省联考合格证--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label" for="txt_UP_AEE_picture">省联考合格证</label>
                                                <div class="controls">
                                                    <div class=" filesupload ">

                                                        <asp:TextBox ID="txt_UP_AEE_picture" runat="server" onfocus="this.blur()" CssClass="upload-text input-medium" MaxLength="250"></asp:TextBox>

                                                        <span class="btn btn-file">
                                                            <span class="fileupload-new">选择图片</span>
                                                            <input type="file" id="FileUpload_UP_AEE_picture" class="default" name="FileUpload_UP_AEE_picture" onchange="Upload('SingleFile', 'txt_UP_AEE_picture', 'FileUpload_UP_AEE_picture','1');" />
                                                        </span>
                                                        <span id="Span3" class="uploading">正在上传，请稍候...</span>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--显示近期免冠照片--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label"></label>
                                                <div class="controls">
                                                    <img id="img_UP_AEE_picture" runat="server" alt="省联考合格证照片" style="height: 100px; width: 100px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--所属周期--%>
                                    <div class="row-fluid">
                                        <div class="span10">
                                            <div class="control-group">
                                                <label class="control-label">所属周期</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_Period_id" onfocus="this.blur()" runat="server" CssClass="input-block-level" Enabled="false" />

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="span12" style="text-align: right;">
                        <div class="form-actions">
                            <asp:Button ID="btn_Submit" runat="server" Text="提交保存" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
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
