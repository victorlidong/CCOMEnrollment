<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admission_ticket.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.Certificate.Admission_ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印准考证</title>
    
    <!--#include file="/metro/include/header_datepicker.html"-->
    <script type="text/javascript" src="jquery-2.0.0.min.js"></script>
    <style type="text/css">
        .main_body {
            width: 100%;
            margin: 0 auto;
        }
        .for_btn
        {
            width:85%;
            height:50px;
            margin: 0 auto;
            margin-top:30px;
        }
        .btn_print {
            width: 85%;
            height: 100%;
            margin: 0 auto;
            text-align: center;
        }

        .btn {
            margin: 0 auto;
            font-family: 黑体;
            font-size: 20px;
            display: block;
            height: 30px;
            width: 100px;
            line-height: 45px;
            text-align: center;
            letter-spacing: 2px;
            background: #6ac275;
            color: white;
            padding-bottom: 12px;
            border-radius: 10px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
        }

            .btn:hover {
                background-color: #73b07a;
                cursor: pointer;
            }
    </style>
</head>
<body>
    <div class="main_body">
        <form id="form1" runat="server">
            <div id="print_div" runat="server">
                <style type="text/css">
                     
                    .body_container
                    {

                        overflow:hidden;
                        width:1200px;
                        min-width:1200px;
                        min-height:600px;
                        border:1px solid grey;
                        margin:0 auto;
                        margin-top:40px;
                    }
                    .left
                    {
                        width:49%;
                        float:left;
                        margin-top:15px;
                    }
                    .title
                    {
                        width:78%;
                        height:100px;
                        text-align:center;
                        margin:0 auto;
                        margin-top:15px;
                        /*margin-left:10px;*/
                    }
                    .for_img
                    {
                        margin:0 auto;
                        width:200px;
                        margin-top:20px;
                        height:200px;
                    }
                    .for_img img
                    {
                         width:200px;
                        height:200px;
                    }
                    .person_info
                    {
                        width:85%;
                        /*height:350px;*/
                        margin:0 auto;
                        margin-top:15px;
                    }
                    .info_line
                    {
                        width:90%;
                        height:30px;
                        margin:0 auto;
                        margin-bottom:8px;
                        padding-top:8px;
                        font-size:22px;
                    }
                    .key
                    {
                        width:45%;
                        height:100%;
                        float:left;
                        text-align:right;
                    }
                    .value
                    {
                         width:54%;
                        height:100%;
            
                        text-align:left;
                        margin-left:46%;
                    }
                    .left_footer
                    {
                        width:85%;
                        height:90px;
                        margin:0 auto;
                        margin-top:20px;
                        margin-bottom:20px;
                    }

                    .left_qrcode
                    {
                        width:110px;
                        height:90px;
                        float:left;
                        margin-left:20px;
                    }
                    .left_qrcode img
                    {
                        width:90px;
                        height:90px;
                    }
                    .extra_info
                    {
                        margin-left:130px;
                        width:72%;
                        height:100%;
                        text-align:center;
                    }
                    .extra_info span
                    {
                        font-size:18px;
                        line-height:30px;
                    }
                    .right
                    {
                        width:49%;
                        /*min-width:660px;*/
                        /*height:900px;*/
                        float:right;
                         margin-top:15px;
                         border-left:1px solid grey;
                        /*margin-top:-900px;*/
                    }
                    .right_title
                    {
                        width:80%;
                        height:40px;
                        margin:0 auto;
                        margin-top:10px;
                        text-align:center;
                    }
                    .right_body
                    {
                        width:85%;
                        /*height:600px;*/
                        margin:0 auto;
            
            
                    }
     
                    .table_title
                    {
                        text-align:center;
                        width:100%;
                        height:25px;
                        font-size:20px;
                        font-weight:600;
                    }

                      .table_title_left
                      {
                          width:35%;
                          height:25px;
                          float:left;
                          background-color:lightgrey;
                      }
                      .table_title_right
                      {
                          width:64%;
                          height:25px;
                          margin-left:36%;
                          background-color:lightgrey;
                      }
                     .table_content
                     {
                        width:100%;
                        min-height:380px;
                        font-size:18px;
                        margin:0 auto;
                        margin-top:8px;
                        margin-bottom:8px;
                     }
                     .exam_line
                     {
                         width:100%;
                         height:48px;
             
                     }
                     .exam_line span
                     {
                         line-height:23px;
                        
                     }
                     .course
                     {
                         width:35%;
                         height:100%;
                         float:left;
             
                     }
                     .arrange
                     {
                         width:64%;
                         height:100%;
                         margin-left:36%;
             
                     }
                    
    
       
                     .right_footer
                     {
                         width:90%;
                         margin:0 auto;
                         height:180px;
                         margin-top:15px;
                         margin-bottom:20px;
            
             
            
                     }
                     .tip
                     {
                         width:100%;
                         height:120px;
                         margin:0 auto;
            
                     }
         
                      .tip p
                      {
                          width:100%;
                          font-size:17.5px;
                          margin:0 auto;
                          line-height:23px;
                      }
                      .focus
                     {
                         width:95%;
                         height:40px;
                         margin:0 auto;
                         text-align:center;
                         margin-top:18px;
                     }
                      .focus span
                      {
                          font-size:30px; 
                      }
                     .suggest
                     {
                         margin:0 auto;
                         text-align:center;
                         width:95%;
                         height:35px;
             
                     }
                     .suggest span
                     {
                         font-size:20px;
                     }
                </style>
                <div class="body_container">
                    <div class="left">
                        <div class="title" >
                            <asp:Label ID="tit" runat="server" style="font-size:40px;"></asp:Label>
                        </div>
                        <div class="for_img">
                            <img src="#" alt="证件照" id="stu_pic" runat="server" style="width: 200px; height: 200px;" />
                        </div>
                        <div class="person_info">

                            <div class="info_line">
                                <div class="key" style="margin-top:6px;">
                                    <span>准考证号:</span>
                                </div>
                                <div class="value">
                                    <asp:Label ID="addmission_number" runat="server" style="font-size:30px;"></asp:Label>
                                </div>
                            </div>

                            <div class="info_line">
                                <div class="key">
                                    <span>姓名:</span>
                                </div>
                                <div class="value">
                                    <asp:Label ID="stu_name" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="info_line" >
                                <div class="key">
                                    <span>性别:</span>
                                </div>
                                <div class="value">
                                    <asp:Label ID="gender" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="info_line">
                                <div class="key">
                                    <span>证件号码:</span>
                                </div>
                                <div class="value">
                                    <asp:Label ID="ID_number" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="info_line">
                                <div class="key">
                                    <span>报考专业:</span>
                                </div>
                                <div class="value" >
                                    <asp:Label ID="major" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="left_footer">
                            <div class="left_qrcode">
                                <img src="#" runat="server" id="qrcode" alt="二维码" />
                            </div>
                            <div class="extra_info">
                                <span>中央音乐学院招生委员会办公室 发</span><br />
                                <span>此证需配合有效身份证件原件方为有效</span><br />
                                <asp:Label ID="print_time" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="right">
                        <div class="right_title">
                            <h2>考试科目及安排</h2>
                        </div>
                        <div class="right_body">

                            <div class="table_title">
                                <div class="table_title_left">
                                    <span style="background-color:lightgrey;">科目</span>
                                </div>
                                <div class="table_title_right">
                                    <span style="background-color:lightgrey;">安排</span>
                                </div>
                            </div>
                            <div class="table_content" id="exam_info" runat="server" style="font-size:15px;">

                               
                                <div class="exam_line">
                                    <div class="course">
                                        <span></span>
                                    </div>
                                    <div class="arrange">
                                        <span></span>
                                        <br />
                                        <span ></span>
                                    </div>
                                </div>

                                <div class="exam_line">
                                    <div class="course">
                                        <span></span>
                                    </div>
                                    <div class="arrange">
                                        <span></span>
                                        <br />
                                        <span ></span>
                                    </div>
                                </div>
                                <div class="exam_line">
                                    <div class="course">
                                        <span></span>
                                    </div>
                                    <div class="arrange">
                                        <span></span>
                                        <br />
                                        <span ></span>
                                    </div>
                                </div>

                                
                            </div>

                        </div>
                        <div class="right_footer">
                            <div class="tip">
                                <p>提示:</p>
                                <p> ①考生打印准考证后，考试安排若有变动，我院将于指定地点公布，恕不另行通知考生，考生亦可随时关注我院招生网站</p>
                                <p> ②笔试科目的实际时长，以试卷上注明为准</p>
                                <p> ③部分表演专业考试单个考场安排了多种乐器的考生，考试次序为包含所有乐器考生的总次序，请考生务必提前候考，以免贻误考试</p>
                            </div>
                            <div class="focus">
                                <span style="font-size: 30px;">请考生自备2B铅笔与黑色签字笔</span>
                            </div>
                            <div class="suggest" id="suggest">
                                <span>请用A4纸横向打印，黑白稿、复印件皆有效</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="for_btn">
                <div class="btn_print">
                    <div class="btn" onclick="print('print_div');">
                        <span>打印</span>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script type="text/javascript" src="/metro/js/ex-jquery-plugins.js"></script>
   
    <!--#include file="/metro/include/footer_common.html"-->
    <script type="text/javascript">
        function print(printpage) {
            var oldstr = document.body.innerHTML;
            document.getElementById('suggest').style.display = "none";
            var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            var docStr = document.getElementById("print_div").innerHTML;
            
            newWindow.document.write(docStr);
            //newWindow.document.close();
            newWindow.print();
            //newWindow.close();
            document.body.innerHTML = oldstr;

            //var headstr = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title></title><link href='/AdminMetro/CCOM/Certificate/Admission_ticket.css' rel='stylesheet' media='all'/></head><body>";
            //var footstr = "</body></html>";
            //var newstr = document.all.item(printpage).innerHTML;
            //var oldstr = document.body.innerHTML;
            //document.body.innerHTML = headstr + newstr + footstr;
            //w = window.open("", "_blank");
            //w.document.write(headstr + newstr + footstr);
            //w.print();
            //w.close();
            //document.body.innerHTML = oldstr;

        }
        
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: "/AdminMetro/CCOM/Certificate/QrCode.ashx?data=<%=university.Common.DESEncrypt.Encrypt(new university.BLL.CCOM.User_property().GetModel(" User_id="+GetAdminInfo_CCOM().User_id).UP_CCOM_number)%> ",
                success: function (data) {
                    //alert(data);
                    document.getElementById("qrcode").src = data;
                },
                error: function (data) {
                    alert(data);
                }
            });
        });
            
            
        
    </script>
</body>
</html>
