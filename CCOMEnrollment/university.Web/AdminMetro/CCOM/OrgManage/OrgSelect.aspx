<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgSelect.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.OrgManage.OrgSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>选择部门</title>
    <!--#include file="/metro/include/header_common.html"-->
    <!--#include file="/metro/include/header_ztree.html"-->
    <script type="text/javascript">
        var zTreeObj;
        var setting = {
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onClick: onClick,
                onDblClick: zTreeOnDblClick
            }
        };
        var selNode = null;
        function onClick(e, treeId, treeNode) {
            selNode = treeNode;
        }
        function zTreeOnDblClick(event, treeId, treeNode) {
            selNode = treeNode;
            sure();
        };
        var jsonData = JSON.parse('<%=GetNodeData() %>');
        var zNodes = jsonData;
        $(document).ready(function () {
            zTreeObj = $.fn.zTree.init($("#tree_list"), setting, zNodes);
        });
        function sure() {
            if (selNode == null) return;
            parent.$("#<%=university.Common.MyRequest.GetString("id").ToString()%>").val(selNode.id);
            <% if (university.Common.MyRequest.GetString("refresh").ToString() == "true")
               {%>
            parent.__doPostBack("<%=university.Common.MyRequest.GetString("id").ToString()%>", selNode.id);
            <%}%>
            if ($.isFunction(parent.CreateSmsText)) {
                parent.CreateSmsText();
            }
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭

        }
    </script>
</head>
<body class="mainbody" style="background-color: white;">
    <form id="form1" runat="server" class="form-horizontal" style="margin: 0px;">
        <input id="hiduoid" runat="server" type="hidden" value="-12" />
        <div id="container" class="row-fluid" style="margin-top: 0px;">
            <div id="main-content" style="margin-left: 0px; margin-bottom: 0 !important;min-height: 100%;">
                <div class="container-fluid">
                    <div class="span12">
                        <a href="javascript:sure();" class="btn btn-success"><i class="icon-success"></i>确认</a>
                    </div>
                    <div class="span12">
                        <ul class="ztree" id="tree_list"></ul>             
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

