<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application_form.aspx.cs" Inherits="university.Web.AdminMetro.CCOM.Certificate.Application_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印报名表</title>
    <style>
        .main_body {
            margin: 0;
            padding: 0;
        }

        .for_btn {
            width: 85%;
            height: 50px;
            margin: 0 auto;
            margin-top: 30px;
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
                <div class="main_container">
                    <style type="text/css">
                        .back {
                            background-color: lightgrey;
                            text-align: center;
                        }

                        .title1 {
                            font-size: 25px;
                            height: 35px;
                            line-height: 35px;
                        }

                        .main_container {
                            overflow: hidden;
                            width: 21cm;
                            height: 29.7cm;
                            padding: 0.6cm;
                            margin: 0.6cm auto;
                            border: 1px #D3D3D3 solid;
                            border-radius: 5px;
                            font-size: 18px;
                        }

                        .content {
                            width: 97%;
                            margin: 0 auto;
                        }

                        .title {
                            width: 100%;
                            height: 45px;
                            margin: 0 auto;
                            font-size: 36px;
                            text-align: center;
                            letter-spacing: 1px;
                            word-spacing: 3px;
                        }

                        .fundamental_info {
                            width: 84%;
                            height: 100%;
                            float: left;
                        }
                        .info_line
                        {
                            width:100%;
                            height:30px;
                            margin-top:4px;
                            margin-bottom:4px;
                        }
                        .name
                        {
                           width:45%;
                           line-height:30px;
                           height:100%;
                           float:left;
                        }
                        .name_lable
                        {
                            height:100%;
                            width:35%;
                            float:left;
                            text-align:center;
                        }
                        #name
                        {
                           margin-left:10px;
                        }
                       .id_number
                       {
                           width:60%;
                           height:100%;
                           line-height:30px;
                           margin-left:40%;
                       }
                       .id_number_label
                       {
                            height:100%;
                            width:40%;
                            float:left;
                            text-align:center;
                       }
                       #id_number
                       {
                           margin-left:10px;
                       }
                       .gender
                       {
                           width:15%;
                           height:100%;
                           float:left
                       }
                       .gender_tit
                       {
                           width:65%;
                           height:100%;
                           line-height:30px;
                           text-align:center;
                           background-color:lightgrey;
                           float:left;
                       }
                       #gender
                       {
                           margin-left:10px;
                           line-height:30px;
                       }
                       .birthday
                       {
                           width:30%;
                           height:100%;
                           margin-left:17%;
                       }
                       .birthday_tit
                       {
                           width:50%;
                           height:100%;
                           float:left;
                           line-height:30px;
                           text-align:center;
                           background-color:lightgrey;
                       }
                       #birthday
                       {
                           line-height:30px;
                           margin-left:10px;
                       }
                       .nation
                       {
                           width:20%;
                           height:100%;
                           margin-left:48%;
                           margin-top:-30px;
                       }
                       .nation_tit 
                       {
                           background-color:lightgrey;
                           width:55%;
                           height:100%;
                           float:left;
                           text-align:center;
                           line-height:30px;
                       }
                       #nation
                       {
                           margin-left:10px;
                           line-height:30px;
                       }
                       .birth_place
                       {
                           width:30%;
                           margin-left:70%;
                           margin-top:-30px;
                       }
                       
                       .birth_place_tit
                       {
                           width:55%;
                           background-color:lightgrey;
                           height:100%;
                           float:left;
                           text-align:center;
                           line-height:30px;
                       }

                       #birth_place
                       {
                           margin-left:10px;
                           line-height:30px;
                       }
                        .head_pic {
                        width: 14%;
                        height: 100%;
                        margin-left: 86%;
                        }

                        .head_pic img {
                            width: 100%;
                            height: 100%;
                        }

                        .major {
                            width: 60%;
                            height: 100%;
                            float: left;
                        }

                        .entrance_exam_number {
                            width: 39%;
                            height: 100%;
                            margin-left: 61%;
                        }

                        .major_title .stu_title .course .course_title {
                            
                            width: 100%;
                        }

                        .col_title {
                            width: 100%;
                            margin-top: 6px;
                            margin-bottom: 6px;
                        }

                        .line {
                            width: 100%;
                        }

                        .course_name {
                            width: 34%;
                            line-height: 29px;
                        }

                        .exam_form {
                            width: 20%;
                            margin-left: 35%;
                            margin-top: -30px;
                            line-height: 29px;
                        }

                        .exam_song {
                            width: 44%;
                            margin-top: -30px;
                            margin-left: 56%;
                            line-height: 29px;
                        }

                        .line_decration {
                            width: 100%;
                            border: 1px dashed grey;
                        }

                        .contect {
                            width: 100%;
                            margin-top: 10px;
                            margin-bottom: 5px;
                        }
                        .contect_line
                        {
                            width:100%;
                            height:35px;
                            line-height:30px;
                            margin-bottom:3px;
                            margin-top:3px;
                            
                        }
                        .footer
                        {
                            width:100%;
                            height:100px;
                           
                            margin-top:50px;
                        }
                        .address
                        {
                            width:20%;
                            height:100%;
                            
                            float:left;
                            text-align:center;
                            font-size:35px;
                            line-height:100px;
                        }
                        .exam_stu_info
                        {
                            margin-left:30%;
                            width:70%;
                            height:100%;
                           
                        }
                       
                    </style>
                    <div class="content">
                        <div class="title">
                            <asp:Label runat="server" ID="title"></asp:Label>
                        </div>
                        <div style="width: 100%; height: 130px;margin-top:10px;">
                            <div class="fundamental_info">
                                <div class="info_title  back title1">
                                    <span>个人信息</span>
                                </div>
                                <div class="info_line">
                                    <div class="name">
                                        <div class="name_lable back">
                                            <span>姓 名</span>
                                        </div>
                                        <asp:Label ID="name" runat="server"></asp:Label>
                                    </div>
                                    <div class="id_number">
                                        <div class="id_number_label back">
                                            <span>证件号码</span>
                                        </div>
                                        <asp:Label ID="id_number" runat="server">1120142028</asp:Label>
                                    </div>
                                </div>

                                 <div class="info_line">
                                     <div class="gender">
                                         <div class="gender_tit">
                                             <span>性别</span>
                                         </div>
                                         <asp:Label ID="gender" runat="server"></asp:Label>
                                     </div>
                                     <div class="birthday">
                                         <div class="birthday_tit">
                                             <span>出生日期</span>
                                         </div>
                                         <asp:Label ID="birthday" runat="server"></asp:Label>
                                     </div>
                                     <div class="nation">
                                         <div class="nation_tit">
                                             <span>民族</span>
                                         </div>
                                         <asp:Label ID="nation" runat="server"></asp:Label>
                                     </div>
                                     <div class="birth_place">
                                         <div class="birth_place_tit">
                                             <span>生源地</span>
                                         </div>
                                         <asp:Label ID="birth_place" runat="server"></asp:Label>
                                     </div>
                                </div>

                                <div class="info_line">
                                    <div class="name">
                                        <div class="name_lable back">
                                            <span>档案所在地</span>
                                        </div>
                                        <asp:Label ID="file_address" runat="server" style="margin-left:10px;"></asp:Label>
                                    </div>
                                    <div class="id_number">
                                        <div class="id_number_label back">
                                            <span>政治面貌</span>
                                        </div>
                                        <asp:Label ID="politics" runat="server" style="margin-left:10px;"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="head_pic">
                                <img src="#" id="head_pic" runat="server"/>
                            </div>
                        </div>
                        <div style="width: 100%; height: 75px; margin-top: 10px;">
                            <div class="major">
                                <div class="major_title back title1">
                                    <span>报考专业信息</span>
                                </div>
                                <div style="background-color:lightgrey;height:30px;text-align:center;width:30%;float:left;margin-top:6px;">
                                    <span style="line-height: 30px; margin-left: 10px;">报考专业 </span>
                                </div>
                                
                                <asp:Label runat="server" ID="major" Style="line-height: 38px;margin-left:10px;"></asp:Label>
                            </div>
                            <div class="entrance_exam_number">
                                <div class="stu_title back title1">
                                    <span>高考考生信息</span>
                                </div>
                                <div style="background-color:lightgrey;height:30px;text-align:center;width:45%;float:left;margin-top:6px;">
                                    <span style="line-height: 30px; margin-left: 10px;" class="back">高考报名号 </span>
                                </div>
                                <asp:Label runat="server" ID="entrance_exam_number" Style="line-height: 38px;margin-left:10px;"></asp:Label>
                            </div>
                        </div>
                        <div class="course">
                            <div class="course_title back title1">
                                <span>考试科目及曲目</span>
                            </div>
                            <div class="col_title">
                                <div class="back" style="width: 34%; float: left;">
                                    <span>考试科目</span>
                                </div>
                                <div class="back" style="width: 20%; margin-left: 35%;">
                                    <span>考试形式</span>
                                </div>
                                <div class="back" style="width: 44%; float: right; margin-top: -23px;">
                                    <span>考试曲目</span>
                                </div>
                            </div>
                            <div id="examination_course" runat="server" style="min-height:370px;">
                                
                            </div>
                        </div>
                        <div class="contect">
                            <div class="course_title back title1">
                                <span>联系方式</span>
                            </div>
                            <div class="contect_line">
                                <div class="exam_phone" style="width:45%;height:100%;float:left;">
                                    <div style="background-color:lightgrey;width:45%;height:80%;line-height:30px;text-align:center;float:left;">
                                        <span>考试期间联系电话</span>
                                    </div>
                                    <asp:Label ID="exam_phone" runat="server"></asp:Label>
                                </div>
                                <div style="margin-left:47%;width:50%;height:100%;">
                                    <div style="float:left;width:48%;background-color:lightgrey;text-align:center;line-height:30px;height:80%;">
                                        <span>录取通知书邮寄地址</span>
                                    </div>
                                    <asp:Label ID="admit_address" runat="server"></asp:Label>
                                </div>
                            </div>
                           <%-- <div class="contect_line">
                                <div style="float:left;width:25%;background-color:lightgrey;text-align:center;line-height:30px;height:80%;">
                                    <span>录取通知书邮寄地址</span>
                                </div>
                                <asp:Label ID="admit_address" runat="server">广东省韶关市南雄</asp:Label>
                            </div>--%>
                            <div class="contect_line">
                                <div style="width:25%;height:100%;float:left;">
                                    <div style="width:50%;height:80%;background-color:lightgrey;float:left;text-align:center;">
                                        <span>邮寄编码</span>
                                    </div>
                                    <asp:Label ID="city_id" runat="server"></asp:Label>
                                </div>
                                <div style="width:25%;margin-left:26%;height:100%;">
                                    <div style="width:50%;height:80%;text-align:center;float:left;background-color:lightgrey;">
                                        <span>收件人</span>
                                    </div>
                                    <asp:Label ID="reciever" runat="server"></asp:Label>
                                </div>
                                <div style="width:35%;height:100%;margin-left:63%;margin-top:-35px;">
                                    <div style="width:50%;height:80%;background-color:lightgrey;text-align:center;float:left;">
                                        <span>收件人电话</span>
                                    </div>
                                    <asp:Label ID="reciever_phone" runat="server"></asp:Label>
                                </div>
                            </div>
                            <%--<div class="contect_line">
                                <div style="width:55%;height:100%;float:left;">
                                    <div style="width:32%;height:80%;background-color:lightgrey;text-align:center;float:left;">
                                        <span>家庭通讯地址</span>
                                    </div>
                                    <asp:Label ID="family_address" runat="server">广东省韶关市南雄</asp:Label>
                                </div>
                                <div style="width:20%;height:100%;margin-left:55%;">
                                    <div style="width:55%;height:80%;background-color:lightgrey;text-align:center;float:left;">
                                        <span>家庭邮编</span>
                                    </div>
                                    <asp:Label ID="family_city_id" runat="server">512400</asp:Label>
                                </div>
                                <div style="background-color:lightgrey;margin-left:74%;margin-top:-35px;text-align:center;float:left;">
                                    <span>家庭收件人</span>
                                </div>
                                <asp:Label ID="family_reciever" runat="server" style="float:right;margin-top:-35px;margin-right:50px;">郑泉斌</asp:Label>
                            </div>--%>
                        </div>
                        <div class="confer">
                             <div class="course_title back title1">
                                <span>信息确认</span>
                            </div>
                            <div class="describ" style="margin-top:-10px;">
                                <p>&nbsp&nbsp
                                本人确认以上信息均为本人填写，真实有效。如有虚假内容，因此产生的一切后果由本人自行承担。受托代表人可完全代表本人意愿。</p>
                                <div>
                                    <span style="margin-left:260px;">考生(或受托代表人)签名：</span><hr style="width:250px;margin-left:500px;margin-top:-5px;"/>
                                </div>
                                
                            </div>
                        </div>
                        <div class="footer">
                            <div class="address" style="text-align:center;font-size:35px;line-height:100px;">
                                <asp:Label ID="stu_province" runat="server"></asp:Label>
                            </div>
                            <div class="exam_stu_info">
                                <div class="stu_name" style="width:28%;height:100%;float:left;text-align:center;font-size:35px;line-height:100px;">
                                    <asp:Label ID="stu_name" runat="server"></asp:Label>
                                </div>
                                <div class="bar_code" style="width:35%;height:100%;margin-left:29%;">
                                    <img src="#" runat="server" id="stu_bar_code" style="width:100%;height:100%;"/>
                                </div>
                                <div class="entrance_number" style="width:35%;height:100%;margin-left:65%;margin-top:-100px;text-align:center;font-size:35px;line-height:100px;">
                                    <asp:Label ID="stu_entrance_number" runat="server"></asp:Label>
                                </div>
                            </div>
                            
                        </div>
                    </div>

                </div>
            </div>
        </form>
        <div class="for_btn" style="margin-bottom:150px;">
            <div class="btn_print">
                <div class="btn" onclick="print();">
                    <span>打印</span>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="jquery-2.0.0.min.js"></script>
    <script type="text/javascript">
        function print() {
            var oldstr = document.body.innerHTML;
            //document.getElementById('suggest').style.display = "none";
            var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            var docStr = document.getElementById("print_div").innerHTML;

            newWindow.document.write(docStr);
            //newWindow.document.close();
            newWindow.print();
            //newWindow.close();
            document.body.innerHTML = oldstr;

        }
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: "/AdminMetro/CCOM/Certificate/BarCode.ashx?data=<%=university.Common.DESEncrypt.Encrypt(new university.BLL.CCOM.User_property().GetModel(" User_id="+GetAdminInfo_CCOM().User_id).UP_CCOM_number)%> ",
                success: function (data) {
                    //alert(data);
                    document.getElementById("stu_bar_code").src = data;
                },
                error: function (data) {
                    alert(data);
                }
            });
        });
    </script>
</body>
</html>
