document.write("<script type=\"text/javascript\" src=\"/metro/js/js_declaration/DataDic.js\"></script>");

//添加奖学金模板是自主添加字段，简化版的添加字段，值包含字段名称
//默认文本类型，非必填
function AddSimpleDataItem(hid) {
    var d = dialog({
        title: '添加自定义字段',
        width: 400,
        okValue: '确定',
        cancel: true,
        cancelValue: '取消',
        content: "名称：<input type='text' id='titleIndependentAdd' />",
        ok: function () {
            var input = document.getElementById('titleIndependentAdd');
            if (input.value != "") {
                var obj = new Object;
                obj.value = "0_" + FieldSource_IndependentAdd + "_-1";
                obj.text = input.value;
                Insert(obj, hid);
                return true;
            }
            else {
                parent.jsprint("名称不能为空", "", "Warning");
            }
            return false;
        }
    });
    d.show();
    document.getElementById('titleIndependentAdd').focus();
}

//插入属性占位符
function Insert(obj, hid) {
    var src = obj.value.split('_')[1];
    if (src == FieldSource_ErrorProperty) {
        alert('不能选择此字段，请您重新选择!');
        return;
    }
    var id = obj.value.split('_')[2];
    var ue = UE.getEditor('editor', {
        autoHeight: false
    });
    var date = new Date();
    var key = date.getTime();
    var text = obj.text;
    if (text.indexOf('>>')>0) text = text.substring(text.indexOf('>>') + 2);
    var hiditem = document.getElementById(hid).value;

    //判断模板申请项是否重复
    //if (hiditem != "") {
    //    var hidArr = hiditem.split('|');
    //    var sameNum = 1;
    //    for (var i = 0; i < hidArr.length; ++i) {
    //        var reg = new RegExp(text, "g");
    //        var bo = reg.test(hidArr[i]);
    //        if (bo == true) {
    //            sameNum++;
    //        }
    //    }
    //    if (sameNum > 1)
    //        text += sameNum.toString();
    //}    


    //key + title + src + id(key，名称，来源，ID)
    if (hiditem == "") hiditem += key + "," + text + "," + src + "," + id;
    else hiditem += "|" + key + "," + text + "," + src + "," + id;
    document.getElementById(hid).value = hiditem;

    //var str = "<declaration key=\"" + key + "\">";
    //str += "{" + text + "}"
    //str += "</declaration>";
    var str = "{"+text+"<label style=\"display:none;\">"+ key + "</label>}";
    ue.execCommand("inserthtml", str);

}


//添加选项
function AddApplyItem(listId, src, type, title, content, sortId, required, id) {
    var listBox = $("#" + listId + " ul");

    //判断是否重复添加申报项
    //var cnt = $("#" + listId + " ul li").length;    //li标签的个数，即已经添加的选项个数
    //var items = listBox[0].getElementsByTagName("li");
    //var sameNum = 1;    //添加的选项重复个数加1

    //if (cnt > 0) {
    //    var hiddenInputs = document.getElementsByName("hidItemName");   //取出所有name为hidItemName的标签
    //}
    ////正则匹配value中title的个数
    //for (var i = 0; i < cnt; ++i) {
    //    var inputValue = hiddenInputs[i].value;
    //    var reg = new RegExp(title, "g");
    //    var bo = reg.test(inputValue);
    //    if (bo == true) {
    //        sameNum++;
    //    }
    //}
    //if (sameNum > 1)
    //    title += sameNum.toString();

    

    var newLi = '<li style="margin:5px 0;"><span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title;
    if (required == "1") newLi += '<b style="color: red;">*</b>';
    newLi += '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case ItemType_Radio.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Checkbox.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Select.toString():
            itemTextList = content.split(";");
            newLi += '<select class="item-margin" style="width:213px;" name="select' + idRnd + '" id="select' + idRnd + '_' + i + '">';
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<option value="' + itemTextList[i] + '">' + itemTextList[i] + '</option>';
            }
            newLi += "</select>";
            break;
        case ItemType_Input.toString():
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_Textarea.toString():
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case ItemType_Time.toString():
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_File.toString():
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }
    newLi += '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="editSubjectItem(\'AttachList\',this);" class="icon-edit">编辑</a>&nbsp;&nbsp;'
          + '<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove">删除</a>'
          + '<input name="hidItemName" type="hidden" value="'+ src+ '|' + type + '|' + title + '|' + content + '|' + sortId + '|' + required + '|' + id + '|' + 1 + '" />'
          + '</li>';
    //console.log(newLi);
    listBox.append(newLi);
};

//编辑选项,类型，名称，内容，排序，是否必填，ID
function EditApplyItem(obj,src, type, title, content, sortId, required, id, applyItemType) {
    var newLi = '<span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title;
    if (required == "1") newLi += '<b style="color: red;">*</b>';
    newLi += '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case ItemType_Radio.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Checkbox.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Select.toString():
            itemTextList = content.split(";");
            newLi += '<select class="item-margin" style="width:213px;" name="select' + idRnd + '" id="select' + idRnd + '_' + i + '">';
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<option value="' + itemTextList[i] + '">' + itemTextList[i] + '</option>';
            }
            newLi += "</select>";
            break;
        case ItemType_Input.toString():
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_Textarea.toString():
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case ItemType_Time.toString():
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_File.toString():
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }
    newLi += '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="editSubjectItem(\'AttachList\',this);" class="icon-edit">编辑</a>&nbsp;&nbsp;'
          + '<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove">删除</a>'
          + '<input name="hidItemName" type="hidden" value="' + src + '|' + type + '|' + title + '|' + content + '|' + sortId + '|' + required + '|' + id + '|' + applyItemType +'" />';
    $(obj).parent().html(newLi);
};

//编辑选项,类型，名称，内容，排序，是否必填，ID，ApplyType_Scholarship类型时调用
function EditApplyItem2(obj, src, type, title, content, sortId, required, id, applyItemType) {
    var newLi = '<span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title;
    if (required == "1") newLi += '<b style="color: red;">*</b>';
    newLi += '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case ItemType_Radio.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Checkbox.toString():
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case ItemType_Select.toString():
            itemTextList = content.split(";");
            newLi += '<select class="item-margin" style="width:213px;" name="select' + idRnd + '" id="select' + idRnd + '_' + i + '">';
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<option value="' + itemTextList[i] + '">' + itemTextList[i] + '</option>';
            }
            newLi += "</select>";
            break;
        case ItemType_Input.toString():
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_Textarea.toString():
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case ItemType_Time.toString():
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case ItemType_File.toString():
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }
    newLi += '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="editSubjectItem(\'AttachList\',this);" class="icon-edit">编辑</a>&nbsp;&nbsp;' + '<a></a>' + '<input name="hidItemName" type="hidden" value="' + src + '|' + type + '|' + title + '|' + content + '|' + sortId + '|' + required + '|' + id + '|' + applyItemType + '" />';
    $(obj).parent().html(newLi);
};


//删除申报项目列表
function DelAttachLi(obj) {
    $.ligerDialog.confirm("确定要删除吗？", "提示信息", function (result) {
        if (result) {
            $(obj).parent().remove(); //删除节点
        }
    });
}

//判断是否为数字
function isNumber(str) {
    var r = /^[0-9]{0,4}[0-9]$/;
    return r.test(str);
}