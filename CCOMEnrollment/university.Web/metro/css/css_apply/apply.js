//添加选项
function AddApplyItem(listId, type, title, content, sortId, required, itemvalue) {
    var listBox = $("#" + listId + " ul");
    var newLi = '<li style="margin:5px 0;"><span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title;
    if(required == "1") newLi += '<b style="color: red;">*</b>';
    newLi += '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case "radio":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "checkbox":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "select":
            itemTextList = content.split(";");
            newLi += '<select class="item-margin" style="width:213px;" name="select' + idRnd + '" id="select' + idRnd + '_' + i + '">';
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<option value="' + itemTextList[i] + '">' + itemTextList[i] + '</option>';
            }
            newLi += "</select>";
            break;
        case "input":
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "textarea":
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case "time":
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "file":
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }
    newLi += '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="editSubjectItem(\'AttachList\',this);" class="icon-edit">编辑</a>&nbsp;&nbsp;'
          + '<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove">删除</a>'
          + '<input name="hidItemName" type="hidden" value="' + type + '|' + title + '|' + sortId + '|' + content + '|' + required + '|' + itemvalue + '" />'
          + '</li>';
    //console.log(newLi);
    listBox.append(newLi);
    //alert(data.mstitle);
};

//编辑选项
function EditApplyItem(obj, type, title, content, sortId, required, itemvalue) {
    var newLi = '<span class="li-title" >(排序:<b style="color:red;">' + sortId + '</b>)' + title;
    if (required == "1") newLi += '<b style="color: red;">*</b>';
    newLi += '：</span>';
    var itemTextList, i;
    var idRnd = Math.floor(Math.random() * 100 + 1);
    content = htmlEncode(content);
    switch (type) {
        case "radio":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="radio' + idRnd + '_' + i + '" type="radio" name="radio' + idRnd + '"/>';
                newLi += '<label for="radio' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "checkbox":
            itemTextList = content.split(";");
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<input id="checkbox' + idRnd + '_' + i + '" type="checkbox" name="checkbox' + idRnd + '"/>';
                newLi += '<label for="checkbox' + idRnd + '_' + i + '">' + itemTextList[i] + '</label>&nbsp;&nbsp;';
            }
            break;
        case "select":
            itemTextList = content.split(";");
            newLi += '<select class="item-margin" style="width:213px;" name="select' + idRnd + '" id="select' + idRnd + '_' + i + '">';
            for (i = 0; i < itemTextList.length; i++) {
                newLi += '<option value="' + itemTextList[i] + '">' + itemTextList[i] + '</option>';
            }
            newLi += "</select>";
            break;
        case "input":
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "textarea":
            newLi += '<textarea placeholder="' + content + '" style="width: 400px; height: 50px;" >' + content + '</textarea>';
            break;
        case "time":
            //newLi += '<input onClick="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})" id="input' + idRnd + '" type="text" value="' + content + '" />';
            newLi += '<input placeholder="' + content + '" id="input' + idRnd + '" type="text" value="' + content + '" />';
            break;
        case "file":
            newLi += '<input id="txtFilePath' + idRnd + '" type="text" class="txtInput normal left" ><a href="javascript:;" class="files">';
            newLi += '<input type="file" id="FileUpload' + idRnd + '" name="FileUpload' + idRnd + '"  onchange = "Upload(\'SingleFile\', \'txtFilePath' + idRnd + '\', \'FileUpload' + idRnd + '\');" /></a>';
            newLi += '<span class="uploading">正在上传，请稍候...</span>';
            break;
        default:
            break;
    }
    newLi += '&nbsp;&nbsp;<a href="javascript:void(0);" onclick="editSubjectItem(\'AttachList\',this);" class="icon-edit">编辑</a>&nbsp;&nbsp;'
          + '<a href="javascript:void(0);" onclick="DelAttachLi(this);" class="icon-remove">删除</a>'
          + '<input name="hidItemName" type="hidden" value="' + type + '|' + title + '|' + sortId + '|' + content + '|' + required + '|' + itemvalue + '" />';
    $(obj).parent().html(newLi);
};