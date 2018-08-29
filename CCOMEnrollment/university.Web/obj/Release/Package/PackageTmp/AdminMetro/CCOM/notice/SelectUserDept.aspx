<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectUserDept.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.notice.SelectUserDept" %>
<%@ Import Namespace="university.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <script type="text/javascript">
        function selectDeptSuccess(deptIdList, groupIdList, userIdList, nodeNameList, totalUserCount)
        {
            
            parent.selectUserDeptCallBack(deptIdList, groupIdList, userIdList, nodeNameList, totalUserCount);

            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭
        }

        function confirm_click()
        {
            //var checkboxs = document.getElementsByTagName("checkbox");
            
            //var checkValue = document.getElementById("hidId");
            //var list = new Array();
            //for(var i=0;i<checkboxs.length;i++) 
            //{
            //    if(checkboxs[i].type=="checkbox" && checkboxs[i].checked==true)
            //    {
            //        list.push(checkValue[i].val());
            //    }
            //}
            //alert(checkValue.length);
        }
        
        //treeview checkEvent
        function public_GetParentByTagName(element, tagName) {
            var parent = element.parentNode;
            var upperTagName = tagName.toUpperCase();

            while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
                parent = parent.parentNode ? parent.parentNode : parent.parentElement;
            }
            return parent;
        }

        function setParentChecked(objNode) {
            var objParentDiv = public_GetParentByTagName(objNode, "div");
            if (objParentDiv == null || objParentDiv == "undefined") {
                return;
            }
            var objID = objParentDiv.getAttribute("ID");
            objID = objID.substring(0, objID.indexOf("Nodes"));
            objID = objID + "CheckBox";
            var objParentCheckBox = document.getElementById(objID);
            if (objParentCheckBox == null || objParentCheckBox == "undefined") {
                return;
            }
            if (objParentCheckBox.tagName != "INPUT" && objParentCheckBox.type == "checkbox")
                return;
            //objParentCheckBox.checked = true;
            setParentChecked(objParentCheckBox);
        }

        function setChildUnChecked(divID) {
            var objchild = divID.children;
            var count = objchild.length;
            for (var i = 0; i < objchild.length; i++) {
                var tempObj = objchild[i];
                if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                    tempObj.checked = false;
                }
                setChildUnChecked(tempObj);
            }
        }

        function setChildChecked(divID) {
            var objchild = divID.children;
            var count = objchild.length;
            for (var i = 0; i < objchild.length; i++) {
                var tempObj = objchild[i];
                if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                    tempObj.checked = true;
                }
                setChildChecked(tempObj);
            }
        }

        //触发事件
        function CheckEvent() {
            var objNode = event.srcElement;

            if (objNode.tagName != "INPUT" || objNode.type != "checkbox")
                return;

            if (objNode.checked == true) {
                setParentChecked(objNode);
                var objID = objNode.getAttribute("ID");
                var objID = objID.substring(0, objID.indexOf("CheckBox"));
                var objParentDiv = document.getElementById(objID + "Nodes");
                if (objParentDiv == null || objParentDiv == "undefined") {
                    return;
                }
                setChildChecked(objParentDiv);
            }
            else {
                var objID = objNode.getAttribute("ID");
                var objID = objID.substring(0, objID.indexOf("CheckBox"));
                var objParentDiv = document.getElementById(objID + "Nodes");
                if (objParentDiv == null || objParentDiv == "undefined") {
                    return;
                }
                setChildUnChecked(objParentDiv);
            }
        }

        <%--function jumpGroupAdmin() {
            parent.location.href = "/AdminMetro/NewsPush/UserGroupAdmin.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id")%>";
        }--%>

        function usersearch() {
            var name = $("#search_text").val();
            if (name != "") {
                $("#userlist tr").hide();
                $("#userlist tr:contains('姓名')").show();
                $("#userlist tr:contains(" + name + ")").show();
            }
            else {
                $("#userlist tr").show();
            }
        }

        function onblurSearch() {
            var name = $("#search_text").val();
            if (name != "") {
                $("#userlist tr").hide();
                $("#userlist tr:contains('姓名')").show();
                $("#userlist tr:contains(" + name + ")").show();
                if ($("#userlist tr:hidden").length <= 1 && $("#DropDownList0").val() == "0") {
                    setTimeout(function () {
                        $("#search_btn").click();
                    }, 0);
                }
            } else {
                $("#userlist tr").show();
            }
        }

        $(function () {
            //使选择模板的iframe自适应高度
            //parent.layer.iframeAuto(parent.layer.getFrameIndex(window.name));
        });
    </script>
</head>
<body style="background-color: white;">
   
    <form id="form2" runat="server" class="form-horizontal" style="margin: 0px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="tabIndex" runat="server" />
        <script type="text/javascript">
            $(function () {
                var tabIndex = $("#tabIndex").val();
                if (tabIndex != "") {
                    showTab("#pageTab1", parseInt(tabIndex));
                }
            });
            function showTab(tabId, tabIndex) {
                $(tabId + " li:eq(" + (tabIndex - 1) + ") a").tab('show');
            }
        </script>
        <!-- BEGIN CONTAINER -->
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <!-- BEGIN PAGE -->
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important; min-height: 100%;">
                <!-- BEGIN PAGE CONTAINER-->
                <div class="container-fluid">
                   
                    <div class="space5"></div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="tabbable custom-tab">
                                <ul class="nav nav-tabs" id="pageTab1">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">按机构</a></li>
                                    <%--<li><a href="#tab_1_2" data-toggle="tab">按通信组</a></li>--%>
                                    <li><a href="#tab_1_3" data-toggle="tab">按学校通讯录</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div>
                                            <asp:TreeView ID="trDepartmentList" Width="100%" runat="server" ImageSet="Simple" ShowCheckBoxes="All">
                                            </asp:TreeView>
                                        </div>
                                    </div>
                                    <%--<div class="tab-pane" id="tab_1_2">
                                        <a href="javascript:void(0);" onclick="jumpGroupAdmin();">没有合适的？点击添加通信组</a>

                                        <asp:TreeView ID="trUserGroup" Width="100%" runat="server" ImageSet="Simple" ShowCheckBoxes="All">
                                        </asp:TreeView>
                                    </div>--%>
                                    <div class="tab-pane" id="tab_1_3">
                                        <asp:UpdatePanel ID="updatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="row-fluid">
                                                    <div class="span12" style="text-align:center;">
                                                        <asp:DropDownList ID="DropDownList0" runat="server" Width="150" OnSelectedIndexChanged="DropDownList0_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="150" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="150" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="space10"></div>
                                                <div class="row-fluid">
                                                    <div class="span12">
                                                        <div class="pull-right">
                                                            <input type="text" placeholder="输入姓名或手机号搜索" id="search_text" onkeyup="usersearch()" onblur="onblurSearch()" style="width: 150px;" runat="server" />
                                                            <input type="button" runat="server" id="search_btn" value="搜索" class="btn" onserverclick="btnSearch_Click" />
                                                        </div>
                                                    </div>
                                                     <div class="space5"></div>
                                                    <div class="span12">
                                                        <asp:HiddenField ID="hidUser" runat="server" Value="," />
                                                        <asp:Repeater ID="rptList" runat="server">
                                                            <HeaderTemplate>
                                                                <table width="100%" border="0" id="userlist" cellspacing="0" cellpadding="0" class="table table-striped table-bordered  table-hover">
                                                                    <tr>
                                                                        <th style="text-align: center;">选择</th>
                                                                        <th>姓名</th>
                                                                        <th>联系方式</th>
                                                                        <th>所在机构</th>
                                                                    </tr>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="text-align: center;">
                                                                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Checked='<%#IsContain(Eval("User_id").ToString())%>'/>
                                                                        <asp:HiddenField ID="hidId" Value='<%#Eval("User_id") + "_" + Eval("User_type")%> ' runat="server" />
                                                                        <asp:HiddenField ID="hidName" Value='<%#Eval("User_realname")%>' runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("User_realname")%>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("User_number")%>
                                                                    </td>
                                                                     <td>
                                                                        <%#GetAgency(Convert.ToInt32(Eval("User_id").ToString()))%>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END PAGE TITLE & BREADCRUMB-->
                    </div>
                </div>
                <div class="space10"></div>
                <div class="row-fluid">
                    <div class="span12" style="text-align: center;">
                        <asp:Button ID="btnConfirm" CssClass="btn btn-success" runat="server" Text="确认选中" OnClick="btnConfirm_Click" OnClientClick="confirm_click()"/>
                    </div>
                </div>
                <!--BEGIN  PAGE BODY CONTENT-->
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
    </form>
     <!--common script for all pages-->
    <!--#include file="/metro/include/footer_common.html"-->
    <!--end common script for all pages-->
    <!--script for this page-->
    <!--end script for this page-->
</body>
</html>
