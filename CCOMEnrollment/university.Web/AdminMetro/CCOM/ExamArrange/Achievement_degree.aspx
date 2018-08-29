<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Achievement_degree.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ExamArrange.Achievement_degree" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交材料</title>
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
                            <h3 class="page-title">毕业要求达成度
                            </h3>
                            <!-- END PAGE TITLE & BREADCRUMB-->
                        </div>
                    </div>
                      <div class="row-fluid">
                            <h5 >注：学生自评和教师评价采取四级评分制，评定等级为“非常满意、满意、不满意、非常不满意”，分别对应分数为4、3、2、1，请填写分数。
                            </h5>
                    </div>
                    <!--BEGIN  PAGE BODY CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered dataTable">
                                <tbody><%--colspan="3"--%>
                                    <tr>
                                        <td width="20%">毕业要求</td>
                                        <td width="80%">毕业要求指标点</td>
                                         <td width="5%">分值</td>
                                       <td width="5%">学生自评</td>
                                        <td width="5%">指导教师评价</td>
                                    </tr>
                                      <tr>
                                        <td width="20%">毕业要求6．工程与社会</td>
                                        <td width="50%">6.1 能够了解应用领域背景知识，完成复杂软件系统的需求分析，说明其合理性</td>
                                         <td width="5%">15</td>
                                          <td>
                                              <asp:DropDownList ID="ddlstudent1" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                          <td>
                                              <asp:DropDownList ID="ddlteacher1" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                          <%--<td> <input  id="student1" runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher1" runat="server"  type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="20%">毕业要求6．工程与社会</td>
                                        <td width="50%">6.4 能够采用适当的方法评价工程实践对社会、健康、安全、法律以及文化的影响，并理解应承担的责任</td>
                                         <td width="5%">20</td>
                                         <td>
                                              <asp:DropDownList ID="ddlstudent2" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher2" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                        <%--<td><input id="student2"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher2"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="20%">毕业要求7．环境和可持续发展</td>
                                        <td width="50%">7.2 能够了解国内外行业标准、规范和技术发展趋势</td>
                                         <td width="10%">10</td>
                                         <td>
                                              <asp:DropDownList ID="ddlstudent3" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher3" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                       <%--<td><input id="student3"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher3"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="20%" class="auto-style1">毕业要求7．环境和可持续发展</td>
                                        <td width="50%" class="auto-style1">7.3 能够理解复杂软件工程问题的专业实践和对环境以及社会可持续发展的影响</td>
                                         <td width="5%" class="auto-style1">20</td>
                                         <td>
                                              <asp:DropDownList ID="ddlstudent4" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher4" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                        <%--<td><input id="student4"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher4"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="20%">毕业要求10．沟通</td>
                                        <td width="50%">10.2 能够具备一定的国际视野，能够了解和跟踪软件工程专业的最新发展趋势</td>
                                         <td width="5%">25</td>
                                         <td>
                                              <asp:DropDownList ID="ddlstudent5" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher5" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <%--<td><input id="student5"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher5"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
                                    </tr>
                                     <tr>
                                        <td width="20%">毕业要求12．终身学习</td>
                                        <td width="50%">12.3 能够运用科学的学习方法，管理知识和处理信息，做到学以致用</td>
                                         <td width="5%">10</td>
                                         <td>
                                              <asp:DropDownList ID="ddlstudent6" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                         <td>
                                              <asp:DropDownList ID="ddlteacher6" runat="server">
                                                  <asp:ListItem Value="0" Selected="True">未评分</asp:ListItem>
                                                  <asp:ListItem Value="1">非常不满意</asp:ListItem>
                                                  <asp:ListItem Value="2">不满意</asp:ListItem>
                                                  <asp:ListItem Value="3">满意</asp:ListItem>
                                                  <asp:ListItem Value="4">非常满意</asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                          <%--<td><input id="student6"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>
                                          <td><input id="teacher6"  runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /> </td>--%>
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