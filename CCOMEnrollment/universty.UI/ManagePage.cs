using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using university.Common;
using System.Data;
using System.Xml;
using System.Configuration;
using Newtonsoft.Json;

namespace university.UI
{
    public class ManagePage : System.Web.UI.Page
    {
        //protected internal Model.siteconfig siteConfig;

        public bool checkFunID = false;
        public bool adminfuncition = false;
        public bool checkSchoolUser = false;
        public bool checkUserStaus = true;
        public bool checkLogin = true;
        public bool checkCombineUser = true;
        //public bool checkSchoolLevelAdminUser = true;
        public bool checkSchoolLevelAdminUser = false;
        public string fun_id = "";
        //public ILog LOGGER = LogManager.GetLogger("quanquan");
        //public string PostUrl = ConfigurationManager.AppSettings["PostUrl"].ToString();
        public string webUrl = ConfigurationManager.AppSettings["domain"].ToString();
        public string webPath = ConfigurationManager.AppSettings["webpath"].ToString();
        public string webManagepath = ConfigurationManager.AppSettings["webmanagepath"].ToString();
        //public string PostUrl = ConfigurationManager.AppSettings["PostUrl"].ToString();
        public string PostUrl = "";

        public ILog LOGGER = LogManager.GetLogger("quanquan");
   

        public bool isFirstLogin = false; //是否首次登陆

        protected string Intro_Sys = "";
        protected string Intro_Module = "";

        protected Model.CCOM.User_information user_info;

        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            //siteConfig = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath("Configpath"));
            //siteConfig.weburl = ConfigurationManager.AppSettings["domain"].ToString();
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //return;

            //判断后台是否登录
            if (checkLogin && !IsAdminLogin())
            {
                Redirect(MyEnums.RediirectErrorEnum.SessionNull);
                return;
            }

            if (checkLogin && checkUserStaus && (Session[MyKeys.SESSION_ADMIN_INFO]==null || Session[MyKeys.SESSION_USER_STATUSID] == null))
            {
                //Response.Write("<script type=\"text/javascript\" src=\"/metro/js/ex-common-scripts.js\"></script><script>if(window.parent != window) getTopWindow().location.href='/adminmetro/index.aspx';"
                //   + " else window.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/Login.aspx';</script>");
                Response.Write("<script type=\"text/javascript\" src=\"/metro/js/ex-common-scripts.js\"></script><script>if(window.parent != window) getTopWindow().location.href='/AdminMetro/index.aspx';"
                   + " else window.location.href='/AdminMetro/login_page.aspx';</script>");
                Response.End();
                return;
            }

            if (checkFunID)
            {
                if (MyRequest.GetQueryString("fun_id") != "")
                {
                    fun_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("fun_id"));
                    user_info = GetAdminInfo_CCOM(); //用户信息
                    String url = HttpContext.Current.Request.Url.AbsolutePath;
                    url = url.Replace("/AdminMetro/", "");

                    BLL.CCOM.Son_function sfbll = new BLL.CCOM.Son_function();
                    Model.CCOM.Son_function sfModel = sfbll.GetModel("Sf_id =" + fun_id);
                    if (sfModel.Sf_url != url)
                    {
                        InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
                    }

                    //BLL.CCOM.Admin_permission bll = new BLL.CCOM.Admin_permission();
                    //Model.CCOM.Admin_permission model = bll.GetModel("Sf_id =" + fun_id + "and User_id =" + user_info.User_id);
                    //if (model == null)
                    //{
                    //    InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);
                    //}
                    //else
                    //{
                        BLL.CCOM.Role rolebll = new BLL.CCOM.Role();
                        //Model.CCOM.Role roleModel = rolebll.GetModel("Role_id IN (SELECT Role_id FROM Role_permission WHERE User_id = " + user_info.User_id + ")");
                        Model.CCOM.Role roleModel = rolebll.GetModel("Role_id IN (SELECT Role_id FROM User_information WHERE User_id = " + user_info.User_id + ")");
                       
                        if (!roleModel.Role_status) 
                        {
                            BLL.CCOM.Role_permission rpbll = new BLL.CCOM.Role_permission();
                            List<Model.CCOM.Role_permission> rpmodel = rpbll.GetModelList("Sf_id =" + fun_id + "and Role_id =" + roleModel.Role_id);
                            if (rpmodel.Count > 0)
                            {
                                InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);
                            }
                        }
                    
                }
                else
                {
                    InnerRedirect(MyEnums.RediirectErrorEnum.FunIDNull);
                }
            }


            //标志首次登陆
            if (Session[MyKeys.SESSION_FIRST_LOGIN] != null)
            {
                isFirstLogin = true;
            }

            //只要有操作就重写session
            Session[MyKeys.SESSION_ADMIN_INFO] = GetAdminInfo_CCOM();
            Session.Timeout = 300;
            return;
        }

        public void InnerRedirect(MyEnums.RediirectErrorEnum err)
        {
            string msbox = "if(window.parent != window) getTopWindow().f_errorTab(\"错误提示\", \"您没有管理该页面的权限，请勿尝试非法进入！\"); else window.location.href='" + webPath + webManagepath + "/Login_page.aspx';";
            Response.Write("<script type=\"text/javascript\" src=\"/metro/js/ex-common-scripts.js\"></script><script type=\"text/javascript\">" + msbox + "</script>");
            Response.End();
        }

        protected void Redirect(MyEnums.RediirectErrorEnum err)
        {
            Response.Write("<script type=\"text/javascript\" src=\"/metro/js/ex-common-scripts.js\"></script><script>if(window.parent != window)getTopWindow().location.href='" + webPath + webManagepath + "/Login_page.aspx';"
                + " else window.location.href='" + webPath + webManagepath + "/Login_page.aspx'; </script>");
            //Response.Redirect(siteConfig.webpath + siteConfig.webmanagepath + "/Login.aspx");
            Response.End();
        }

        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session[MyKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                //Cookie存储 时间,ID 加密后的内容 手动计算过期时间
                string CookieID = Utils.GetCookie("UniversityLoginInfo");
                if (CookieID != "")
                {
                    CookieID = DESEncrypt.Decrypt(CookieID);
                    try
                    {
                        DateTime dt = Convert.ToDateTime(CookieID.Split(',')[0]);
                        if (dt.Date.Date == DateTime.Now.Date)
                        {
                            CookieID = CookieID.Split(',')[1];
                            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                            Model.CCOM.User_information model = bll.GetModel(Convert.ToInt64(CookieID));
                            /*
                            Model.admin.View_AdminUser model = new BLL.admin.View_AdminUser().GetModel(Convert.ToInt64(CookieID));
                        */
                            if (model != null)
                            {
                                Session[MyKeys.SESSION_ADMIN_INFO] = model;
                                Session[MyKeys.SESSION_USER_STATUSID] = model.User_id.ToString();
                                return true;
                            }
                             
                            return true;
                        }

                    }
                    catch { }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得用户信息
        /// </summary>
        public Model.CCOM.User_information GetAdminInfo_CCOM()
        {
            if (IsAdminLogin())
            {
                Model.CCOM.User_information model = Session[MyKeys.SESSION_ADMIN_INFO] as Model.CCOM.User_information;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 取得用户口头答辩成绩
        /// 返回-1表示没有该生对应的口头答辩成绩
        /// </summary>
        public float GetUser_CommentScore(long userid)
        {
            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userid + " and Accept_state=1");
            if (relation_model == null) return -1;
            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            if (comment_model == null) return -1;
            if (comment_model.Reply_score == null) return -1;
            int score = (int)comment_model.Reply_score;
            int number = 1;
            var reply_students = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + userid);
            foreach (var reply_student in reply_students)
            {
                long group_id = reply_student.Group_id;
                if (new BLL.CCOM.Reply_group().GetModel(group_id).Group_type == 0)//筛选出口头答辩组
                {
                    var mark_scores = new BLL.CCOM.Mark_table().GetModelList(" Rs_id=" + reply_student.Rs_id);
                    foreach (var mark_score in mark_scores)
                    {
                        if (mark_score.Score != null)
                        {
                            score += (int)mark_score.Score;
                            number++;
                        }
                    }
                }
            }
            return score/number;
        }

        /// <summary>
        /// 传入url，取得跳转页面的fun_id
        /// </summary>
        public string get_fun_id(string url)
        {
            BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
            var sf = Bsf.GetModel("Sf_url='"+url+"'");
            if (sf != null) return DESEncrypt.Encrypt(sf.Sf_id.ToString());
            return "";
        }

        /// <summary>
        /// 获得当前（管理员）用户的管理机构List<org>
        /// </summary>
        /// Activity为TRUE表示不返回禁用的机构部门
        /// <returns></returns>
        public DataSet GetOrgList_DataSet(bool activity) 
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Agency_id", typeof(string))); //加密后的id
            dt.Columns.Add(new DataColumn("Agency_name", typeof(string)));
           // Model.CCOM.Admin_agency model = new BLL.CCOM.Admin_agency().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'");
           // int Agency_id = GetAdminInfo_CCOM().User_agency;
            AddOtherOrg(dt, GetAdminInfo_CCOM().Agency_id, 0, activity);
            ds.Tables.Add(dt);
            return ds;
        }

        private void AddOtherOrg(DataTable dt, int ID, int level, bool activity)
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            Model.CCOM.Agency model = bll.GetModel(" Agency_id=" + ID);
            DataRow dr = dt.NewRow();
            string tag = "";
            for (int i = 0; i < level; i++)
                tag += "　";
            tag += "┠";
            dr["Agency_name"] = tag + model.Agency_name;
            if (!model.Agency_status) dr["Agency_name"] += "（已禁用）";
            dr["Agency_id"] = model.Agency_id;
            //if (!activity)
            //{
            //    if (model.Agency_status)
            //    {
            //        dt.Rows.Add(dr);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else 
            //{
            //    dt.Rows.Add(dr);
            //}
            dt.Rows.Add(dr);
            
            List<Model.CCOM.Agency> listOrganization = bll.GetModelList(" Agency_father=" + ID);
            foreach (Model.CCOM.Agency org in listOrganization)
            {
                AddOtherOrg(dt, org.Agency_id, level + 1, activity);
            }
        }
        
        #region JS提示============================================

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "topWin.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            //JscriptReponse(msbox);
        }

        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
        {
            string msbox = "topWin.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            //JscriptReponse(msbox);
        }
        #endregion

        protected void JscriptWinOpen(string url, string target)
        {
            var res = "window.open('" + url + "','"+target+"');";
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "msg", res, true);
        }

        protected void JscriptTabControll(int tabIndex)
        {
            string js="javascript:tabs('#contentTab',"+tabIndex.ToString()+");";
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "msg", js, true);
            //ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "msg", js, true);
        }

        protected void JscriptReponse(String js)
        {
            string jsStr = "javascript:"+js+";";
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "msg", js, true);
        }

    }
}