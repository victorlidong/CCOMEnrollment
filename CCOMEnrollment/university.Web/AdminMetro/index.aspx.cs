using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Text;
using System.Xml;
using LitJson;

namespace university.Web.AdminMetro
{
    public partial class index : university.UI.ManagePage
    {
        public index()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        //    protected Model.admin.Universities_UserInfo admin_info;
        protected Model.CCOM.User_information user_info;
        protected string userDptName = "";
        //     protected string PosterUrl = ConfigurationManager.AppSettings["PosterUrl"].ToString();
        protected string PosterUrl = "";
        protected long userid = 0;
        protected JsonData Level2Functions;
        public string funid_news = "";
        public string funid_notice = "";
        public string funid_activity = "";
        public string funid_vote = "";
        //活动列表
        //protected string lilist = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                user_info = GetAdminInfo_CCOM(); //用户信息

                //    string facePath = user_info.UI_Face.Trim();
                //string facePath = "";
                //if (facePath == "")
                //{
                //    facePath = "/admin/images/default_user_avatar.gif";
                //}
                //else if (facePath != "" && !facePath.StartsWith("http"))
                //{
                //    facePath = PosterUrl + facePath;
                //}
                //this.userImg.Src = facePath;

                //绑定右上角用户信息和session
                bindusInfo();

                bindleftInfo();

                //触发检查合并登录填数据
                //new BLL.admin.CombineUser().InitSimilarData(admin_info.UserID);

                BindUserDpt();

            }

            ////跳转去青春榜样投票  by zc  不要删除
            //string fromurl = Utils.GetCookie("FromUrl");
            //Utils.WriteCookie("FromUrl", "", -1);  //清除这个cookie
            //if (fromurl != "")
            //{
            //    JscriptReponse("window.parent.location='" + fromurl + "'");
            //    return;
            //}

            //end      
            //首次登陆初始化
            //if (Session[MyKeys.SESSION_FIRST_LOGIN] != null && Session[MyKeys.SESSION_FIRST_LOGIN].ToString() == "1")
            //{
            //    FirstLogin.FirstLogin.Do(GetAdminInfo_CCOM().UserID, GetRoleUserId(), GetUserUO_ID(), GetUserRoleType());
            //}
        }

        //绑定用户机构信息
        protected void BindUserDpt()
        {
            try
            {
                /*
                int uoId = GetUserUO_ID();
                int p2uoId = new BLL.admin.Universities_Organization().GetLevel2UO_ID(uoId);
                int p1uoId = new BLL.admin.Universities_Organization().GetLevel1UO_ID(uoId);
                var p2name = new BLL.admin.Universities_Organization().GetModel(p2uoId).UO_Name;
                var p1name = new BLL.admin.Universities_Organization().GetModel(p1uoId).UO_Name;
                String showName = p2name;
                if (p1name != p2name)
                {
                    showName += "(" + p1name + ")";
                }
                userDptName = showName;
                //this.divUserDpt.InnerHtml = "|" + showName;
                 */
                this.divUserDpt.InnerHtml = "计算机学院毕业设计管理系统";
            }
            catch (Exception ex)
            {
                this.divUserDpt.InnerHtml = "";
            }

        }

        #region 绑定功能树===================================
        protected void bindleftInfo()
        {
            user_info = GetAdminInfo_CCOM();
            string left = "";

            //left += "<div title=\"管理菜单\" iconcss=\"menu-icon-model\" >";
            //left += "<ul id=\"global_channel_tree\" style=\"margin-top: 3px;\">";
            Level2Functions = new JsonData();
            Level2Functions.SetJsonType(JsonType.Array);
            //JSON格式 [{"id":"","type":"F","functions":[]}]

            string sql = " Ff_fatherID = " + university.Common.DataDic.Father_Function + " order by Ff_sort";

            BLL.CCOM.Father_function BFF = new BLL.CCOM.Father_function();
            //  Model.CCOM.Father_function Ff = BFF.GetModelList(sql);
            var Ff_list = BFF.GetModelList(sql);

            foreach (Model.CCOM.Father_function Ff in Ff_list)
            {
                left += createleftinneritem(Ff, Level2Functions);
            }

            this.hidLevel2FunctionTree.Value = Level2Functions.ToJson();
            //left += "</ul>";
            //left += "</div>";
            this.sidebar_menu.InnerHtml = left;
        }

        protected string createleftinneritem(Model.CCOM.Father_function Ff, JsonData listData)
        {
            string str = "";
            str += "<li class=\"sub-menu\">";
            str += "<a href=\"javascript:;\" class=\"\">";
            //   string icon = xn.Attributes["icon"].Value == "" ? "icon-file-alt" : xn.Attributes["icon"].Value;
            

            //string level1name = xn.Attributes["cff_name"].Value;
            string level1name = Ff.Ff_name;
            /*
            if ((MyEnums.UserStatus)Session[MyKeys.SESSION_USER_TABLE] ==
                MyEnums.UserStatus.App_Universities_SchoolUser)
            {
                if (xn.Attributes["stuview_name"].Value != "")
                    level1name = xn.Attributes["stuview_name"].Value;
            }
             */

            str += "<span>" + level1name + "</span>";
            str += "</a>";
            str += " <ul class=\"sub\">";

            string sql_Ff = " Ff_fatherID = " + Ff.Ff_id + " order by Ff_sort";

            BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
            var Ff_listSon = Bff.GetModelList(sql_Ff);

            bool hasSon = false;
            
            foreach (var Ff_son in Ff_listSon)
            {
                try
                {
                    string sql_son = " Ff_ID =" + Ff_son.Ff_id;
                    BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
                    BLL.CCOM.Role_permission apbll = new BLL.CCOM.Role_permission();
                    var aplist = apbll.GetModelList("Sf_id in (select Sf_id from Son_function where Ff_ID = " + Ff_son.Ff_id + ") and Role_id=" + user_info.Role_id);
                    if (aplist.Count > 0)
                    {
                        JsonData data = new JsonData();
                        data["id"] = DESEncrypt.Encrypt(Ff_son.Ff_id.ToString());
                        data["type"] = "F";
                        data["address"] = "";
                        data["name"] = Ff_son.Ff_name;
                        data["functions"] = createlevel3json(Ff_son.Ff_id.ToString());
                        listData.Add(data);
                        hasSon = true;
                        Model.CCOM.Son_function Sf1 = Bsf.GetModel(aplist[0].Sf_id);
                        string cff_name = Ff_son.Ff_name;
                        str += "<li data-id=\"" + DESEncrypt.Encrypt(Ff_son.Ff_id.ToString()) + "\"><a onclick=\"SetTopContent('" + DESEncrypt.Encrypt(Sf1.Sf_id.ToString()) + "')\" target=\"sysMain\" class=\"\" href=\"/AdminMetro/" + Sf1.Sf_url +
                               "?fun_id=" +
                               DESEncrypt.Encrypt(Sf1.Sf_id.ToString()) + "\">" +
                         cff_name +
                               "</a></li>";
                    }
                }
                catch (Exception ex)
                {
                    JscriptMsg("读取页面失败", "login_page.aspx", ex.Message);
                }
            }
            str += " </ul></li>";
            if (hasSon)
            {
                return str;
            }
            else
            {
                return "";
            }
        }

        protected JsonData createlevel3json(string Ff_sonID)
        {
            JsonData list3Data = new JsonData();
            list3Data.SetJsonType(JsonType.Array);

            string sql_son = " Ff_ID =" + Ff_sonID + " order by Sf_sort";
            BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
            var Sf_list = Bsf.GetModelList(sql_son);

            foreach (Model.CCOM.Son_function Sf in Sf_list)
            {
                BLL.CCOM.Role_permission apbll = new BLL.CCOM.Role_permission();
                var aplist = apbll.GetModelList("Sf_id =" + Sf.Sf_id + " and Role_id=" + user_info.Role_id);
                if (aplist.Count > 0)
                {
                    try
                    {
                        JsonData data = new JsonData();
                        data["id"] = DESEncrypt.Encrypt(Sf.Sf_id.ToString());
                        data["type"] = "S";
                        data["address"] = "/AdminMetro/" + Sf.Sf_url + "?fun_id=" + DESEncrypt.Encrypt(Sf.Sf_id.ToString()) + "";
                        data["name"] = Sf.Sf_name;
                        list3Data.Add(data);
                        if (data["name"].ToString() == "查阅新闻")
                            this.funid_news = DESEncrypt.Encrypt(Sf.Sf_id.ToString());
                        if (data["name"].ToString() == "最新通知")
                            this.funid_notice = DESEncrypt.Encrypt(Sf.Sf_id.ToString());
                        if (data["name"].ToString() == "活动大厅")
                            this.funid_activity = DESEncrypt.Encrypt(Sf.Sf_id.ToString());
                        if (data["name"].ToString() == "投票")
                            this.funid_vote = DESEncrypt.Encrypt(Sf.Sf_id.ToString());
                    }
                    catch (Exception ex)
                    {
                        JscriptMsg("读取页面失败", "login_page.aspx", ex.Message);
                    }
                }
            }
            return list3Data;
        }

        #endregion

        #region 绑定切换身份的下拉菜单=========================
        /// <summary>
        /// DropDownListUS.SelectedValue=枚举类型+","+XXXUserID
        /// </summary>
        protected void bindusInfo()
        {
            user_info = GetAdminInfo_CCOM();

            //var model = new BLL.admin.View_AdminUser().GetModel("UserID=" + admin_info.UserID);

            //this.userName.InnerText = model.UI_RealName;
            //this.uoName.InnerText = model.UO_Name;
            if (user_info != null)
            {
                if (user_info.User_realname == "请填写姓名")
                {
                    this.userName.InnerText = user_info.User_number;
                }
                else
                {
                    this.userName.InnerText = user_info.User_realname;
                }
            }
            else {
                Response.Redirect("login_page.aspx");
            }
            
            
            this.uoName.InnerText = "计算机学院";

            /*
            Session[MyKeys.SESSION_USER_TABLE] = MyEnums.UserStatus.App_Universities_AdminUser;
            Session[MyKeys.SESSION_USER_STATUSID] = model.AdminUserID.ToString();
            Session[MyKeys.SESSION_USER_SCHOOL] = model.UI_ID.ToString();
            */
            return;


            /*
            this.DropDownListUS.Items.Clear();
            admin_info = GetAdminInfo_CCOM();
            string bindstr = "";


            String sql = "select UI_ID,UO_Name,AdminUser_Role as roleName,2 as roleType,AdminUserID as roleId from App_View_AdminUser where AdminUser_AccountRelation > 0 and AdminUser_Activtiy = 1 and UserID = " + admin_info.UserID;
            sql += " union";
            sql += " select UI_ID,UO_Name,US_Name as roleName,0 as roleType,SchoolUserID as roleId from App_View_SchoolUser where SchoolUser_AccountRelation > 0 and SchoolUser_Activity = 1 and UserID = " + admin_info.UserID;
            sql += " union";
            sql += " select UI_ID,UO_Name,US_Name as roleName,1 as roleType,SocialUserID as roleId from App_View_SocialUser where SocialUser_AccountRelation > 0 and SocialUser_Activity = 1 and UserID = " + admin_info.UserID;
            sql += " order by roleType desc,roleId desc";

            var ds = Database.DBSQL.Query(sql);

            if (ds.Tables[0].DefaultView.Count <= 0)
            {
                Session.Clear();
                Response.Redirect("/AdminMetro/login_page.aspx");
            }

            for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
            {
                ListItem lt = new ListItem(ds.Tables[0].Rows[i]["UO_Name"].ToString() + ds.Tables[0].Rows[i]["roleName"].ToString(), DESEncrypt.Encrypt(ds.Tables[0].Rows[i]["roleType"].ToString() + "," + ds.Tables[0].Rows[i]["roleId"].ToString()));
                bindstr +=
                    AddUSstr(
                        DESEncrypt.Encrypt(ds.Tables[0].Rows[i]["roleType"].ToString() + "," + ds.Tables[0].Rows[i]["roleId"].ToString()),
                        ds.Tables[0].Rows[i]["UO_Name"].ToString() + ds.Tables[0].Rows[i]["roleName"].ToString());
                this.DropDownListUS.Items.Add(lt);
            }

            string param = this.DropDownListUS.SelectedValue;
            this.uoName.InnerHtml = this.DropDownListUS.SelectedItem.Text;
            Utils.WriteCookie(MyKeys.COOKIE_SELECTSTATUS, DESEncrypt.Encrypt(param), 45);
            if (ds.Tables[0].Rows[0]["roleType"].ToString() == "0")
                Session[MyKeys.SESSION_USER_TABLE] = MyEnums.UserStatus.App_Universities_SchoolUser;
            else if (ds.Tables[0].Rows[0]["roleType"].ToString() == "1")
                Session[MyKeys.SESSION_USER_TABLE] = MyEnums.UserStatus.App_Universities_SocialUser;
            else if (ds.Tables[0].Rows[0]["roleType"].ToString() == "2")
                Session[MyKeys.SESSION_USER_TABLE] = MyEnums.UserStatus.App_Universities_AdminUser;
            Session[MyKeys.SESSION_USER_STATUSID] = ds.Tables[0].Rows[0]["roleId"].ToString();
            Session[MyKeys.SESSION_USER_SCHOOL] = ds.Tables[0].Rows[0]["UI_ID"].ToString();
            */
            //this.ltrUserDept.Text = bindstr;
        }

        protected string AddUSstr(string id, string name)
        {
            string str = "<li>";
            str += "<a href=\"javascript:ChangeStatus('" + id + "');\">" + name + "</a>";
            str += "</li>";
            return str;
        }

        #endregion=====================================

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[MyKeys.SESSION_ADMIN_INFO] = null;
            Session.Clear();
            Utils.WriteCookie("UniversityLoginInfo", "", -14400);
            Response.Redirect("login_page.aspx");
        }
    }
}