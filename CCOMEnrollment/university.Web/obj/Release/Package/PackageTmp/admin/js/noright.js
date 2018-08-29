//禁用鼠标右键
document.onkeydown = function () {
    /*if(event.keyCode==116)  
    {   
    event.keyCode=0;   
    event.returnValue   =   false;   
    }   */
    //屏蔽退格删除键,屏蔽   F5   刷新键,Ctrl   +   R   
    if ((event.keyCode == 116) || (event.ctrlKey && event.keyCode == 82)) {
        event.keyCode = 0;
        event.returnValue = false;
    }
}
document.oncontextmenu = function () { event.returnValue = false; }
