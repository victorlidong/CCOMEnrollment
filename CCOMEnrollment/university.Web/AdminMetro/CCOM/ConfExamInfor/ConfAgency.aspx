<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfAgency.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.ConfExamInfor.ConfAgency" %>

<%@ Import Namespace="university.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ystep.html"-->
    <!--#include file="/metro/include/header_ztree.html"-->
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
            $(".ystep").setStep(2);
        });
        var zTreeObj;
        var setting = {
            //edit: {
            //    enable: true,
            //    removeTitle: "删除",
            //    renameTitle: "重命名",
            //    //drag: {
            //    //    autoExpandTrigger: true,
            //    //    prev: dropPrev,
            //    //    inner: dropInner,
            //    //    next: dropNext
            //    //}
            //},
            view: {
                expandSpeed: "",
                addHoverDom: addHoverDom,
                removeHoverDom: removeHoverDom,
                selectedMulti: false,
                showTitle: true
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onClick: onClick,
                beforeEditName: beforeEditName,
                beforeRemove: beforeRemove,
                beforeRename: beforeRename,
                onRename: onRename,
                onDrop: onDrop,
                beforeDrop: beforeDrop
            }
        };
        function beforeEditName(treeId, treeNode) {
            console.log(treeNode.name.indexOf('【') != -1);
            if (treeNode.name.indexOf('【') != -1)
                treeNode.name = treeNode.name.substr(0, treeNode.name.indexOf('【'));
            return true;
        }
        function beforeRemove(treeId, treeNode) {
            //console.log(treeNode);
            $("#ddlSelectUD").val(treeNode["id"]);
            if (confirm('确认删除？此操作将删除全部子部门！'))
                __doPostBack('btnDelete', '');
            return false;
        }
        function beforeRename(treeId, treeNode, newName) {
            if (newName.length == 0) {
                alert("请输入部门名称.");
                return false;
            }
            return true;
        }
        function onRename(treeId, treeNode, newName) {
            showsendbtn();
        }
        function onDrop(event, treeId, treeNodes) {
            showsendbtn();
        };
        function beforeDrop(treeId, treeNodes, targetNode, moveType, isCopy) {
            if (targetNode == null) return false;
            if (targetNode["childOuter"] == false && moveType != "inner") return false;
            //console.log(targetNode);
        }

        function showsendbtn() {
            $(".well").show();
            $("#divtip").hide();
        }

        function sendsyncData() {
            var treeObj = $.fn.zTree.getZTreeObj("tree_list");
            var nodes = treeObj.getNodes();
            layer.load('机构信息修改中...', 10);
            $.ajax({
                type: "POST",
                url: "./UpdateSchoolUser.ashx",
                data: {
                    "fun": "updateorglist",
                    "adminuserid": '<%=DESEncrypt.Encrypt(this.adminuserid.ToString())%>',
                    "jsonlist": encodeURIComponent(JSON.stringify(nodes))
                },
                dataType: "json",
                success: function (data) {
                    layer.closeAll();
                    $(".well").slideUp("slow");
                    location.reload();
                }
            });
        }

        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
            var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
                + "' title='添加' onfocus='this.blur();'></span>";
            sObj.after(addStr);
            //console.log("add   " + "#addBtn_" + treeNode.id);
            var btn = $("#addBtn_" + treeNode.tId);
            if (btn) btn.bind("click", function () {
                AddOrg();
            });
        };
        function removeHoverDom(treeId, treeNode) {
            //console.log("remove   " + "#addBtn_" + treeNode.id);
            $("#addBtn_" + treeNode.tId).unbind().remove();
        };
        function onClick(e, treeId, treeNode) {
            $("#ddlSelectUD").val(treeNode.id);
            //window.open("OgrList.aspx?fun_id=<%=DESEncrypt.Encrypt(this.fun_id.ToString())%>&selectid=" + treeNode.id, '_self');
        }
        var jsonData = JSON.parse('<%=GetNodeData() %>');
        //console.log(jsonData);
        var zNodes = jsonData;
        //console.log(zNodes);
        $(document).ready(function () {
            zTreeObj = $.fn.zTree.init($("#tree_list"), setting, zNodes);
        });

        function AddOrg() {
            var orgid = $("#ddlSelectUD").val();
            location.href = "../OrgManage/OrgAdd.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id") %>&selectid=" + orgid;
        }

        function EditOrg() {
            var orgid = $("#ddlSelectUD").val();
            location.href = "../OrgManage/OrgEdit.aspx?fun_id=<%=MyRequest.GetQueryString("fun_id") %>&selectid=" + orgid;
        }

        function resumeOrg() {
            location.reload();
        }
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
    </script>
    <style>
        .ztree li span.button.add
        {
            margin-left: 2px;
            margin-right: -1px;
            background-position: -144px 0;
            vertical-align: top;
            *vertical-align: middle;
        }

        .ztree li span.button.diy01_ico_open, .ztree li span.button.diy01_ico_close, .ztree li span.button.diy01_ico_docu
        {
            background-position: -110px 0;
        }

        .well
        {
            margin-top: 10px;
            margin-bottom: 10px;
            line-height: 28px;
        }
        /*.ztree li span {
            font-size: 16px;
            line-height: 20px;
        }
        .ztree li a {
            height: 20px;
        }*/
    </style>
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

                        <%--机构信息--%>
                            <div>
                                <div class="widget-body">

                                    <div class="row-fluid">
                                        <div class="span12 _step2">
                                            <a class="btn btn-success" href="javascript:void(0);" onclick="AddOrg();"><i class="icon-plus icon-white"></i>添加部门</a>
                                            <a class="btn btn-success" href="javascript:void(0);" onclick="EditOrg();"><i class="icon-edit  icon-white"></i>选择编辑</a>
                                            <asp:LinkButton ID="btnDelete" runat="server" Visible="false" CssClass="btn btn-danger" OnClientClick="return confirm('确认删除？此操作将删除全部子部门！');" OnClick="btnDelete_Click"><i class="icon-remove icon-white"></i>选择删除</asp:LinkButton>

                                        </div>
                                    </div>
                                    <div class="space5"></div>
                                    <div class="row-fluid">
                                        <div class="span12">
                                            当前选择：
                                            <asp:DropDownList ID="ddlSelectUD" runat="server" AutoPostBack="true" CssClass="select2"></asp:DropDownList>&nbsp;
                                            <asp:Label ID="lblselectUD" runat="server" ForeColor="Red"></asp:Label>
                                            <a onclick="AlertForm('ddlSelectUD');" class="btn">快速选择</a>
                                        </div>
                                    </div>
                    
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <ul class="ztree _step1" id="tree_list"></ul>
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
                </div>
            </div>
        </div>
    </form>
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript" src="/metro/js/data-js/data-horse.js"></script>
</body>
</html>
