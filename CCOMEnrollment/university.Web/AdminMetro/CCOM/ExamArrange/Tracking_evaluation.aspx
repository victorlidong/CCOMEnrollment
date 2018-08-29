<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tracking_evaluation.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.Tracking_evaluation" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>质量追踪表</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 36px;
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
                  <div id="print_div" class="row-fluid" runat="server">
                        <div class="span12">
                            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                           <%-- <div class="btn" onclick="myPrint();" style="float: left;">
                                 <span>打印</span>
                             </div>--%>
                            <div class="gohistory">
                                <a href="javascript:history.go(-1);" class="btn">返回上一页</a>
                            </div>
                            <h3 class="page-title">质量追踪评价表
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                      <div class="row-fluid">
                            <h5 >注：指导教师对学生以上各项做出评价，采取四级评分制，评定等级为“非常满意、满意、不满意、非常不满意”，分别对应分数为4、3、2、1，请填写分数。
                            </h5>
                    </div>
                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">  
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="3"--%>
                                    <tr>
                                        <td width="50%">毕业设计过程及论文质量监控点</td>
                                        <td width="5%">分值</td>
                                        <td width="5%">评价</td>
                                    </tr>
                                      <tr>
                                        <td width="50%">完成了任务书的各项要求，软件运行正常或算法达到预期效果</td>
                                         <td width="5%">25</td>
                                          <td>
                                              <asp:DropDownList ID="ddlteacher1" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                          <%--<td><input id="teacher1" runat="server"  type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="50%">论文结构合理，内容充实、结论可信</td>
                                         <td width="5%">20</td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher2" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                        <%--<td><input id="teacher2"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="50%">能够掌握一门外语，外文翻译准确流畅，具有跨文化交流和沟通能力</td>
                                         <td width="10%">15</td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher3" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                        <%--<td><input id="teacher3"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="50%" class="auto-style1">充分应用了软件工程相关理论和技术，并能够用形式化模型和文档等形式呈现软件系统解决方案和成果</td>
                                         <td width="5%" class="auto-style1">10</td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher4" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <%--<td><input id="teacher4"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="50%">学生积极接受指导老师指导，至少2周进行一次直接指导，表现出主动学习和不断探索的习惯，能够自我评价</td>
                                         <td width="5%">20</td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher5" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                        <%--<td><input id="teacher5"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="50%">论文结果有创新性结果或新颖之处，表现出进行深入研究的能力</td>
                                         <td width="5%">10</td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher6" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                          <%--<td><input id="teacher6"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="span12 tab_con first-tab" style="height:200px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="btn btn-success" OnClick="btnSubmit_Click" />

                        </div>
                        </div>
                    </div>
                </div>
                <!-- END PAGE CONTAINER-->
            </div>
        </div>
    </form>
      <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
    <script type="text/javascript">
        function myPrint() {
            var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            var str = document.getElementById("print_div").innerHTML;
            var docStr = str;
            newWindow.document.write(docStr);
            newWindow.document.close();
            newWindow.print();
            newWindow.close();
        }
    </script>
</body>
</html>