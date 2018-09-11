using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Web.AdminMetro.CCOM.notice;
namespace university.Web.AdminMetro.CCOM
{
    public partial class center : university.UI.ManagePage
    {
        protected Model.CCOM.User_information user_info;
        protected string newsUrl = "";
        protected string noticeUrl = "";
        public center()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            user_info = GetAdminInfo_CCOM(); //用户信息
            if (user_info.Role_id != 3)//用户不为学生时，只显示欢迎界面
            {
                this.someWhat.InnerHtml = "<div style=\"font-family: 仿宋; text-align: center; font-size:20px; margin-top: 50px; \">欢迎您使用毕业设计管理系统！</ div > ";
            }


            
            if(GetStatusText()==1|| GetStatusText()==3)//题目选择
            {
                this.bt1.InnerHtml = "<a href=\" /AdminMetro/CCOM/TopicManage/StudentChoose.aspx?fun_id=F10BCF0BC92D37DB\" class=\"btn\" style=\" margin-left:105px; margin-top: 20px; background-color: #888; \">题目选择</a>"+
                    " <a href=\" /AdminMetro/CCOM/DatumManage/StudentSubmitList.aspx\"  class=\"btn\"   style=\" margin-left:200px; margin-top: 20px;\">开题报告</a>"+
                     "<a href=\" /AdminMetro/CCOM/ScoreManage/MySoftwarePage.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;\">提交答辩</a>"+  
                     "<a href=\" /AdminMetro/CCOM/ScoreManage/MyScore.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;\">查看评分</a> ";
            }

            //int homeworkId = MyRequest.GetQueryInt("homeworkId");
            //Model.CCOM.Week_log log_model = new BLL.CCOM.Week_log().GetModel(" Homework_id=" + homeworkId);
            var user_model = HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] as Model.CCOM.User_information;//获得userid
            Model.CCOM.View_Datum model_1 = new BLL.CCOM.View_Datum().GetModel("User_id=" + user_model.User_id.ToString());
            if (model_1 != null)
            {
                this.bt1.InnerHtml = "<a href=\" /AdminMetro/CCOM/TopicManage/StudentChoose.aspx?fun_id=F10BCF0BC92D37DB\" class=\"btn\" style=\" margin-left:105px; margin-top: 20px; background-color: #888; \">题目选择</a>" +
                    " <a href=\" /AdminMetro/CCOM/DatumManage/StudentSubmitList.aspx\"  class=\"btn\"   style=\" margin-left:200px; margin-top: 20px;background-color: #888; \">开题报告</a>" +
                     "<a href=\" /AdminMetro/CCOM/ScoreManage/MySoftwarePage.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;\">提交答辩</a>" +
                     "<a href=\" /AdminMetro/CCOM/ScoreManage/MyScore.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;\">查看评分</a> ";
            }

            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id);
            if (relation_model != null)
            {
                var software_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                if (software_model != null)
                {
                    if (software_model.Data_list != "")
                    {
                        this.bt1.InnerHtml = "<a href=\" /AdminMetro/CCOM/TopicManage/StudentChoose.aspx?fun_id=F10BCF0BC92D37DB\" class=\"btn\" style=\" margin-left:105px; margin-top: 20px;background-color: #888;  \">题目选择</a>" +
                            " <a href=\" /AdminMetro/CCOM/DatumManage/StudentSubmitList.aspx\"  class=\"btn\"   style=\" margin-left:200px; margin-top: 20px;background-color: #888; \">开题报告</a>" +
                             "<a href=\" /AdminMetro/CCOM/ScoreManage/MySoftwarePage.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;background-color: #888;\">提交答辩</a>" +
                             "<a href=\" /AdminMetro/CCOM/ScoreManage/MyScore.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;\">查看评分</a> ";
                    }
                }
            }

            if(ShowInfo()==1)
            {
                this.bt1.InnerHtml = "<a href=\" /AdminMetro/CCOM/TopicManage/StudentChoose.aspx?fun_id=F10BCF0BC92D37DB\" class=\"btn\" style=\" margin-left:105px; margin-top: 20px;background-color: #888;  \">题目选择</a>" +
                            " <a href=\" /AdminMetro/CCOM/DatumManage/StudentSubmitList.aspx\"  class=\"btn\"   style=\" margin-left:200px; margin-top: 20px;background-color: #888; \">开题报告</a>" +
                             "<a href=\" /AdminMetro/CCOM/ScoreManage/MySoftwarePage.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;background-color: #888;\">提交答辩</a>" +
                             "<a href=\" /AdminMetro/CCOM/ScoreManage/MyScore.aspx\"  class=\"btn\"   style=\" margin-left:210px; margin-top: 20px;background-color: #888;\">查看评分</a> ";
            }


            //跳转去申报  by zc  20150915 不要删除
            string fromurl = Utils.GetCookie("FromUrl");
            Utils.WriteCookie("FromUrl", "", -1);  //清除这个cookie
            if (fromurl != "")
            {
                JscriptReponse("window.location='" + fromurl + "'");
                return;
            }

            BindDeskTop();
         //   BindChannel();
        }

        protected int ShowInfo()
        {
            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            long _id = model.User_id;
            int score_t = -1, score_c = -1, score_s = -1;
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(_id);

            if (user_model == null)
            {
                InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
            }

           
            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + _id);
            if (relation_model == null) return -1;

            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            try
            {
                score_t = (int)comment_model.Teacher_score;
            }
            catch
            {
                score_t = -1;
            }
            try
            {
                score_c = (int)comment_model.Reply_score;
                
            }
            catch
            {
                score_c = -1;
            }
            try
            {
                var soft_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                score_s = (int)soft_model.Conclusion;
               
            }
            catch
            {
                score_s = -1;
            }
            if (score_c >= 0 && score_s >= 0 && score_t >= 0)
            {
                return 1;
            }
            else return 0;
        }

        protected int GetStatusText()
        {
            int state;
            Model.CCOM.Topic_relation model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id);
            if (model == null) state = 2;               //未选
            else if (model.Accept_state == 0) state = 3;//已选，可换
            else if (model.Accept_state == 1) state = 1;//已选，不可换
            else if (model.Accept_state == 2) state = 3;
            else state = 1;
            return state;
        }


        protected void BindDeskTop()
        {
            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            long uiid = model.User_id;
            try
            {
                var metroList = new List<MetroBlock>();

                string sql = "User_id = " + uiid + " order by Ufd_sort";

                BLL.CCOM.View_Desktop Bvd = new BLL.CCOM.View_Desktop();
                var vdList = Bvd.GetModelList(sql);

                foreach (Model.CCOM.View_Desktop ufd in vdList)
                {
                    string _url = ufd.Sf_url +"?fun_id="+ DESEncrypt.Encrypt(ufd.Sf_id.ToString());
                    _url = _url.Replace("CCOM/", "");

                    //affairs += createnavcube(jdaf);
                    //遍历获取活动大厅的fun_id;
                    if (ufd.Ufd_name.ToString().Trim() == "查看通知")
                        noticeUrl = _url;
                    if (ufd.Ufd_name.ToString().Trim() == "查看资讯")
                        newsUrl = _url;

                    if (ufd.Sf_status == true)
                        metroList.Add(new MetroBlock()
                        {
                            Id = DESEncrypt.Encrypt(ufd.Sf_id.ToString()),
                            Address = _url,
                            ClickCount = 10,
                            Color = ufd.Ufd_color.ToString(),
                            Icon = ufd.Ufd_icon.ToString(),
                            Name = ufd.Ufd_showname.ToString(),
                            Remark = ufd.Ufd_remark.ToString(),
                            Width = ufd.Ufd_width.ToString()
                        });
                }
                this.div_affairs.InnerHtml = GetMetroBlockString(metroList);
            }
            catch (Exception ex)
            {
                this.div_affairs.InnerHtml = ex.ToString();
            }
        }

        protected String GetMetroBlockString(List<MetroBlock> metroList)
        {
            var metroClickCountMap = new Dictionary<String, Int32>();
          
            var index = 0;
            var metroSb = new StringBuilder();
            foreach (var metro in metroList)
            {
                metroSb.Append(GetSingleMetroString(metro, index));
                index++;
            }
            return metroSb.ToString();
        }
        protected string GetSingleMetroString(MetroBlock metro, int index)
        {
            string str = "";
            try
            {
                //<span class="badge badge-important">5</span>
                //var sysCode = metro.Remark.Split('|')[0];  //remarks format: syscode|weight|times
                var sysCode = metro.Remark;
                //var metroClickJs = "recordMetroBlockClick('"+metro.Name+"');";
                var metroClickJs = "";
                String jsUpdateNoticeStatus = "", hidSysCode = "", metroStyle = "";
                if (!String.IsNullOrEmpty(sysCode) && sysCode != "xxx")
                {
                    hidSysCode = "<input name=\"noticeSysCode\" type=\"hidden\" value=\"" + sysCode + "\" />";
                    jsUpdateNoticeStatus = "updateNoticeStatus('" + sysCode + "');";
                    metroStyle = "style=\"overflow:visible;\"";
                }

                var metroClass = "metro-nav-block ";
                var aClass = "";
                //if (index == 0)
                //{
                //    metro.Width = "";
                //    metro.Color = "nav-block-green";
                //    aClass = " class=\"text-center\" ";
                //}else if (index > 0 && index < 3)
                //{
                //    metro.Width = "double";
                //}
                //else
                //{
                //    metro.Width = "";
                //}
                metroClass += metro.Color + " " + metro.Width;
                //if (index == 0)
                //{
                //    metroClass += " long";
                //}

                str += "<div class=\"" + metroClass + "\" " + metroStyle + ">";


                str += hidSysCode;
                str += "<a data-original-title=\"" + metro.Name + "\"" + aClass + " href=\"" + metro.Address + "\" onclick=\"parent.SetTopContent('" + metro.Id + "');" + jsUpdateNoticeStatus + metroClickJs + "\">";
                if (index == 0)
                {
                    str += " <span class=\"value\">";
                }
                str += "<i class=\"" + metro.Icon + "\"></i>";

                if (index == 0)
                {
                    str += " </span>";
                }
                str += "<div class=\"status\">" + metro.Name + "</div>"; //data["remarks"].ToString()

                str += "</a></div>";
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected int GetMetroClickCount(Dictionary<String, Int32> metroClickCountMap, MetroBlock metroBlock)
        {
            var count = 0;
            //if (metroClickCountMap.ContainsKey(metroBlock.Name))
            //{
            //    count = metroClickCountMap[metroBlock.Name];
            //}
            //base count
            count += GetMetroBaseCount(metroBlock.Remark);
            return count;
        }

        protected int GetMetroBaseCount(String remark)
        {
            var count = 0;
            try
            {
                var elements = remark.Split('|');
                if (elements.Length > 2)
                {
                    count = int.Parse(elements[1]) * int.Parse(elements[2]);
                }
            }
            catch (Exception ex)
            {
            }
            return count;
        }
    }
    public class MetroBlock
    {
        public String Id { get; set; }
        public String Color { get; set; }
        public String Width { get; set; }
        public String Address { get; set; }
        public String Name { get; set; }
        public String Icon { get; set; }
        public String Remark { get; set; }
        public int ClickCount { get; set; }
    }
}