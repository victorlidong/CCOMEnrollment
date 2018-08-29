using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM
{
    public partial class center : university.UI.ManagePage
    {
        protected string newsUrl = "";
        protected string noticeUrl = "";
        public center()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //var ml = new BLL.admin.Web_MetroClickInfo().GetModelList("userId=" + GetAdminInfo().UserID);
            //if (ml != null && ml.Count > 0)
            //{
            //    foreach (var m in ml)
            //    {
            //        metroClickCountMap.Add(m.metro_name,m.click_count);
            //    }
            //}

            //foreach (var metro in metroList)
            //{
            //    metro.ClickCount = GetMetroClickCount(metroClickCountMap, metro);
            //}
            //sort
            //metroList.Sort((metroA, metroB)=> metroB.ClickCount-metroA.ClickCount);
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