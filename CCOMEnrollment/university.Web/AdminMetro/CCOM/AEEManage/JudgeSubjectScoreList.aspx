<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JudgeSubjectScoreList.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.AEEManage.JudgeSubjectScoreList" %>

<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>艺考科目分数</title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript" src="../../metro/js/data-js/data-horse.js"></script>
        <script type="text/javascript">
            var title = '<%= getSubjectName(this.esn_id) +"打分： " + this.ddlJudge.SelectedItem.Text %>';
            function myPrint() {
                var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
                var str = document.getElementById("div1").innerHTML;
                str = str.replaceAll("修改", "");
                var docStr = "<div class='row-fluid' style='text-align:center'><b>" + title + "</b></div><br/><style type='text/css'>#listTable_length{display:none;} #listTable_info{display:none;} #listTable_filter{display:none;}</style>" + str;
                newWindow.document.write(docStr);
                newWindow.document.close();
                newWindow.print();
                newWindow.close();
            }
            String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
                if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
                    return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
                } else {
                    return this.replace(reallyDo, replaceWith);
                }
            }
    </script>
    <link rel="stylesheet" href="DT_bootstrap.css" />
    <style type="text/css">
        #listTable_length{
            display:none;
        }
        #listTable_info{
            display:none;
        }
        #listTable_filter{
            display:none;
        }
    </style>

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
                            <h3 class="page-title">录入科目成绩
                            </h3>
                            <%-- 
                            <ul class="breadcrumb">
                                <li>
                                    <a href="/adminmetro/CCOM/center.aspx">首页</a>
                                    <span class="divider">/</span>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">艺考成绩管理</a>
                                    <span class="divider">/</span>
                                </li>
                                <li class="active">艺考科目分数
                                </li>
                            </ul>--%>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span10">
                            <a href="ImportSubjectScore.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>&id1=<%=DESEncrypt.Encrypt(this.esn_id)%>&id2=<%=DESEncrypt.Encrypt(this.judge_id)%>&id3=<%=DESEncrypt.Encrypt(this.ea_id)%>" class="btn btn-warning"><i class="icon-download">批量导入</i></a>
                            <asp:LinkButton ID="Excel" runat="server" CssClass="btn btn-warning" OnClick="Excel_Click"><i class="icon-external-link icon-white">&nbsp;</i>下载批量导入艺考科目成绩模板</asp:LinkButton>
                            <a href="#" onclick="myPrint()" class="btn btn-success"><i class="icon-download">打印表格</i></a>
                            <asp:LinkButton ID="ExportExcel" runat="server" CssClass="btn btn-success" OnClick="exportexcel_ServerClick"><i class="icon-external-link icon-white">&nbsp;</i>导出艺考科目评委成绩</asp:LinkButton>
                             <label style="margin-left: 20px;">评委：</label>
                                <asp:DropDownList ID="ddlJudge" CssClass="select2" Style="width: 150px;" runat="server" OnSelectedIndexChanged="ddlJudge_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="span2">
                            <div class="pull-right input-append">
                                <asp:TextBox ID="txtKeywords" placeholder="姓名/考生号" runat="server"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                                <br />
                                <asp:Label ID="txtSearchResult" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="space5"></div>

                      <div class="row-fluid" id="div1">
                        <div class="span12">
                            <!--列表展示.开始-->
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="table table-striped table-bordered table-hover" id="listTable">
                                        <thead>
                                        <tr>
                                            <th align="center" width="10%">序号</th>
                                            <th align="center" width="15%">考生号</th>
                                          <%--   <th align="center">年份</th>--%>
                                           <th align="center" width="15%">考生姓名</th>
                                          <%--  <th align="center">考生类型：文/理</th>
                                            <th align="center">语文</th>
                                            <th align="center">数学</th>
                                            <th align="center">英语</th>  --%> 
                                            <th align="center" width="15%">评委名称</th>
                                            <th align="center" width="15%">科目名称</th>
                                            <th align="center" width="15%">科目成绩</th>
                                            <th align="center" width="10%">科目序</th>
                               <%--             <th align="center">理科满分</th>--%>    
                                            <th align="center" style="width:5%;">操作</th>
                                        </tr>
                                       </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>">
                                        <td style="text-align:center;">
                                            <%#this.rptList.Items.Count + 1 %>
                                        </td>
                                       <%-- <td align="center"><%# GetProvinceName(int.Parse(Eval("Fl_Province").ToString()))%></td>
                                        <td align="center"><%# Eval("NianFen").ToString() %></td>--%>
                                      <%--  <td align="center"><%# Eval("UP_CCOM_number").ToString() %></td>
                                        <td align="center"><%# Eval("User_realname").ToString() %></td>
                                        <td align="center"><%# GetWenOrLi(Eval("CEE_type").ToString()) %></td>
                                        <td align="center"><%# Eval("CEE_Chinese_score", "{0:#.##}").ToString() %></td>--%>
                                        <td align="center"><%# Eval("UP_CCOM_number").ToString() %></td>
                                        <td align="center"><%# Eval("User_realname").ToString() %></td>
                                        <td align="center"><%# this.ddlJudge.SelectedItem.Text %></td>
                                        <td align="center"><%# getSubjectName(Eval("Subject_id").ToString()) %></td>
                                        <td align="center"><%# getSubjectScore(Eval("User_id").ToString(),Eval("Subject_id").ToString(),this.judge_id) %></td>
                                        <td align="center"><%# getSubjectXu(Eval("User_id").ToString(),Eval("Subject_id").ToString(),this.judge_id) %></td>
                                      <%--     <td align="center"><%# Eval("LiKeZongFen").ToString() %></td>
                                        <td align="left">--%>
                                        <td>
                                            <a href="#" id="txtChange<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>" onclick="change('<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>')">修改</a>
                                            <a href="#" style="display:none;" id="txtSub<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>" onclick="upload('<%#DESEncrypt.Encrypt(Eval("User_id").ToString())%>')">提交</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript">

        function checkNum(obj) {
            //检查是否是非数字值  
            if (isNaN(obj.value)) {
                obj.value = "";
            }
            if (obj != null) {
                //检查小数点后是否对于两位http://blog.csdn.net/shanzhizi  
                if (obj.value.toString().split(".").length > 1 && obj.value.toString().split(".")[1].length > 2) {
                    topWin.jsprint("小数点后多于两位！", "", "Warning");
                    obj.value = "";
                }
            }
        }

        function change(id) {
            checkChange(id);
            var tr1 = document.getElementById(id);
            //alert(tr1.cells[1].innerText);

            var val5 = tr1.cells[5].innerText;

            tr1.cells[5].innerHTML = "<input value='" + val5 + "' type='text' id='txtScore" + id + "' onkeyup='checkNum(this)' MaxLength='10' />";
        }

        function checkChange(id) {
            var str = $("#txtScore" + id).val();

            if (str != null && str != undefined && str != "") {
                $("#txtChange" + id).css('display', 'block');
                $("#txtSub" + id).css('display', 'none');
            } else {
                $("#txtChange" + id).css('display', 'none');
                $("#txtSub" + id).css('display', 'block');
            }
        }

        function upload(id)
        {
            var tr1 = document.getElementById(id);

            var txtScore = $("#txtScore" + id).val();

            if (txtScore == "") {
                topWin.jsprint("请填写科目成绩，没有请填写“0”", "", "Warning");
                return;
            }
            var id1 = "<%=DESEncrypt.Encrypt(this.esn_id)%>";
            var id2 = "<%=DESEncrypt.Encrypt(this.judge_id)%>";
            //alert(id1+"#"+id2);
            $.ajax({
                type: "POST",
                url: "/AdminMetro/CCOM/AEEManage/SetAEESubjectScorePort.ashx",
                data: { "id": id, "txtScore": txtScore, "id1": id1, "id2": id2 },
                success: function (data) {
                    topWin.jsprint(data, "", "Success");
                    if (data == "添加成功") {
                        checkChange(id);
                        tr1.cells[5].innerHTML = txtScore;
                    }
                },
                error: function (data) {
                    topWin.jsprint("请求数据出错", "", "Warning");
                }
            });
        }

    </script>

       <!-- BEGIN JAVASCRIPTS -->

   <script type="text/javascript" src="jquery.dataTables.js"></script>
   <script type="text/javascript" src="DT_bootstrap.js"></script>

   <!--script for this page only-->
   <script src="editable-table.js"></script>

   <!-- END JAVASCRIPTS -->
   <script>
       jQuery(document).ready(function () {
           EditableTable.init();
       });
   </script>
</body>
</html>


