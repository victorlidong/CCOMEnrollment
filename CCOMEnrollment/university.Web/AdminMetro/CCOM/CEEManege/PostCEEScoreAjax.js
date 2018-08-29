function change(id) {
    checkChange(id);
    var tr1 = document.getElementById(id);
    //alert(tr1.cells[1].innerText);

    var val5 = getStuType(tr1.cells[5].innerText);
    var val6 = tr1.cells[6].innerText;
    var val7 = tr1.cells[7].innerText;
    var val8 = tr1.cells[8].innerText;
    var val9 = tr1.cells[9].innerText;
    var val10 = tr1.cells[10].innerText;

    tr1.cells[5].innerHTML = "<input class='txt' value='" + val5 + "' type='text' id='txtType" + id + "' onkeyup='checkNum(this)' MaxLength='1' placeholder='1-文科 2-理科'/>";
    tr1.cells[6].innerHTML = "<input class='txt' value='" + val6 + "' type='text' id='txtYuWen" + id + "' onkeyup='checkNum(this)' MaxLength='10' />";
    tr1.cells[7].innerHTML = "<input class='txt' value='" + val7 + "' type='text' id='txtShuXue" + id + "' onkeyup='checkNum(this)' MaxLength='10' />";
    tr1.cells[8].innerHTML = "<input class='txt' value='" + val8 + "' type='text' id='txtYingYu" + id + "' onkeyup='checkNum(this)' MaxLength='10' />";
    tr1.cells[9].innerHTML = "<input class='txt' value='" + val9 + "' type='text' id='txtZongHe" + id + "' onkeyup='checkNum(this)' MaxLength='10' />";
    tr1.cells[10].innerHTML = "<input class='txt' value='" + val10 + "' type='text' id='txtErWai" + id + "'onkeyup='checkNum(this)' MaxLength='10' />";
}

function checkChange(id) {
    var str = $("#txtYuWen" + id).val();

    if (str != null && str != undefined && str != "") {
        $("#txtChange" + id).css('display', 'block');
        $("#txtSub" + id).css('display', 'none');
    } else {
        $("#txtChange" + id).css('display', 'none');
        $("#txtSub" + id).css('display', 'block');
    }
}

function upload(id) {

    var tr1 = document.getElementById(id);
    // alert(tr1.cells[1].innerText);
    var txtType = $("#txtType" + id).val();
    if (txtType == "") {
        topWin.jsprint("请填写考生类型", "", "Warning");
        return;
    } else if (txtType != "1" && txtType != "2" && txtType != "3") { alert("请输入正确考生类型"); return; }
    var txtYuWen = $("#txtYuWen" + id).val();
    var txtShuXue = $("#txtShuXue" + id).val();
    var txtYingYu = $("#txtYingYu" + id).val();
    var txtZongHe = $("#txtZongHe" + id).val();
    var txtErWai = $("#txtErWai" + id).val();

    if (txtYuWen == "" || txtShuXue == "" || txtYingYu == "" || txtZongHe == "" || txtErWai == "") {
        topWin.jsprint("请完整填写各科成绩，没有请填写“0”", "", "Warning");
        return;
    }
    var txtZongFen = Number(txtYuWen) + Number(txtShuXue) + Number(txtYingYu) + Number(txtZongHe) + Number(txtErWai);
    //alert(txtType + ", " + txtYuWen + ", " + txtShuXue + ", " + txtYingYu + ", " + txtZongHe + ", " + txtErWai + ", " + txtZongFen);
    $.ajax({
        type: "POST",
        url: "/AdminMetro/CCOM/CEEManege/SetCEEScorePort.ashx",
        data: { "id": id, "type": txtType, "YuWen": txtYuWen, "ShuXue": txtShuXue, "YingYu": txtYingYu, "ZongHe": txtZongHe, "ErWai": txtErWai, "ZongFen": txtZongFen },
        success: function (data) {
            topWin.jsprint(data, "", "Success");
            if (data == "添加成功") {
                checkChange(id);
                tr1.cells[5].innerHTML = getStuType(txtType);
                tr1.cells[6].innerHTML = txtYuWen;
                tr1.cells[7].innerHTML = txtShuXue;
                tr1.cells[8].innerHTML = txtYingYu;
                tr1.cells[9].innerHTML = txtZongHe;
                tr1.cells[10].innerHTML = txtErWai;
                tr1.cells[11].innerHTML = txtZongFen;
            }
        },
        error: function (data) {
            topWin.jsprint("请求数据出错", "", "Warning");
        }
    });
}