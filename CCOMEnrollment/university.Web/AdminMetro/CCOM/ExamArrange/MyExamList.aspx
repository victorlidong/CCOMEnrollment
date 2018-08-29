<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyExamList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.MyExamList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>答辩组列表
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
        function EditForm(id, groupid) {
            $("#" + id).show();
            var _width = $("#" + id).width();
            $("#txtExamID").val(groupid);
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
                            <h3 class="page-title">答辩组列表
                            </h3>
                        </div>
                    </div>
                      <div class="row-fluid _step1">
                           <div class="span8">
                                <asp:LinkButton ID="OralTable" CommandArgument='1' CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出答辩评分表"></asp:LinkButton>
                                <asp:LinkButton ID="SoftTable" CommandArgument='2' CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出软件验收表"></asp:LinkButton>
                            </div>
                    </div>
                    <div class="space10"></div>
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered  table-hover" id="listTable">
                                        <thead>
                                            <tr>
                                                <th width="4%" >序号</th>
                                                <th width="7%" style="text-align: center;">答辩组名称</th>
                                                <th width="7%" style="text-align: center;">答辩类型</th>
                                                <th width="7%" style="text-align: center;">组长</th>
                                                <th width="9%" style="text-align: center;">时间</th>
                                                <th width="7%" style="text-align: center;">地点</th>
                                                <th width="7%" style="text-align: center;">学生人数</th>
                                                <th width="7%" style="text-align: center;">操作</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="chkNo" runat="server"><%#st_index++ %></asp:Label>
                                        </td>
                                        <td style="text-align: center;"><%#Eval("Group_name")%></td>
                                        <td style="text-align: center;"><%#GetGroupType(Eval("Group_type").ToString())%></td>
                                          <td style="text-align: center;"><%#GetTeacherName(long.Parse(Eval("User_id").ToString()))%></td>
                                        <td style="text-align: center;"><%#Eval("Reply_time")%></td>
                                        <td style="text-align: center;"><%#Eval("Reply_room")%></td>
                                        <td style="text-align: center;"><%#GetStudentNumber(long.Parse(Eval("Group_id").ToString()))%></td>
                                        <td style="text-align: center;">
                                            <a href="./PrintExamInfor.aspx?groupid=<%#DESEncrypt.Encrypt( Eval("Group_id").ToString())%>">详情</a>
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
                     <div class="span12" style="display:none">
                        <div class="form-actions">
                            <div class="form-actions" style="text-align: center;">
                                    <asp:LinkButton ID="ExpertOralTable" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出答辩评分表"></asp:LinkButton>
                                      <asp:LinkButton ID="ExpertSoftTable" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="导出软件验收表"></asp:LinkButton>
                                             
                            </div>
                        </div>
                           <div class="row-fluid" id="contentTab" style="margin-left:100px">
                                <div style="margin-left:120px;">
                                       <asp:LinkButton ID="LinkButton1" CssClass="btn  btn-success" OnClick="lbtExportStudent_Click" runat="server" Text="评分表"></asp:LinkButton>
                                     
                                        </div>

                             </div>
                     </div>
               <%--     <div class="row-fluid">
                        <div id="ExportType" style="display:normal; width: 360px; height: auto; overflow: auto;">
                            <div class="widget blue">
                                <div class="widget-title">
                                    <h4>选择导出类型</h4>
                                </div>
                                <asp:TextBox ID="txtExamID" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="30" Style="display: none;" />
                                <div class="widget-body">
                                    <div class="row-fluid" id="contentTab" style="margin-left:100px">
                                        <div style="margin-left:120px;">
                                          </div></div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                  
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
