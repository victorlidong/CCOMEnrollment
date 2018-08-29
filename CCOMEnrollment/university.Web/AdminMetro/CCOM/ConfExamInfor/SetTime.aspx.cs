using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ConfExamInfor
{
    public partial class SetTime : university.UI.ManagePage
    {
        protected string keywordTab0 = string.Empty;
        protected string keywordTab1 = string.Empty;
        public SetTime()
        {
            //this.checkFunID = true;

            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String keywords = MyRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                string year = DateTime.Now.Year.ToString();
                Model.CCOM.Period model = new BLL.CCOM.Period().GetModel(" Period_year=" + year);
                if (model == null)
                {
                    this.lblOpenThisYear.Visible = true;
                }
                else {
                    this.lblOpenThisYear.Visible = false;
                }
                year = (DateTime.Now.Year + 1).ToString();
                model = new BLL.CCOM.Period().GetModel(" Period_year=" + year);
                if (model == null)
                {
                    this.lblOpenLastYear.Visible = true;
                }
                else
                {
                    this.lblOpenLastYear.Visible = false;
                }
                this.keywordTab0 = keywords;
                RptBind(CombSqlTxt(keywords), " Period_id desc ");
            }
        }

        //tab1===================
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            //string keywords = MyRequest.GetQueryString("keywords");
            string keywords = this.keywordTab0;
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Period();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, totalCount);
            this.rptList.DataBind();

            //绑定页码
            //txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Period_year like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Period_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        ////设置分页数量
        //protected void txtPageNum_TextChanged(object sender, EventArgs e)
        //{
        //    int _pagesize;
        //    if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        //    {
        //        if (_pagesize > 0)
        //        {
        //            Utils.WriteCookie("Period_page_size", _pagesize.ToString(), 43200);
        //        }
        //    }
        //    Response.Redirect(Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        //}

        protected String GetEditLink(String enc_Id)
        {
            BLL.CCOM.Period bll = new BLL.CCOM.Period();
            Model.CCOM.Period model = bll.GetModel(" Period_id=" + DESEncrypt.Decrypt(enc_Id));
            String link = "";
            if(model.Period_state)
                link = "<asp:LinkButton ID=\"lbt\" OnClientClick=\"return confirm('确定要关闭该周期吗?');void(0);\" OnClick=\"lbtClose_Click\" runat=\"server\" ToolTip='<%# DESEncrypt.Encrypt(Eval(\"Period_id\").ToString())%>' Text=\"关闭\"></asp:LinkButton>";
            else link = "<asp:LinkButton ID=\"lbt1\" OnClientClick=\"return confirm('确定要开启该周期吗?');void(0);\" OnClick=\"lbtOpen_Click\" runat=\"server\" ToolTip='<%# DESEncrypt.Encrypt(Eval(\"Period_id\").ToString())%>' Text=\"开启\"></asp:LinkButton>";
            return link;
        }

        //开启
        protected void lbtOpen_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Period bll = new BLL.CCOM.Period();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                Model.CCOM.Period model = bll.GetModel(id);
                var models = bll.GetModelList("");
                int number = 0;
                foreach (Model.CCOM.Period m in models)
                {
                    if (m.Period_state) number++;
                }
                if (number != 0)
                {
                    JscriptMsg("请先关闭已开启的周期，再开启本周期！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Error");
                }
                else {
                    model.Period_state = true;
                    if (bll.Update(model))
                    {
                        JscriptMsg("开启成功！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                            DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Success");
                    }
                    else
                        JscriptMsg("开启失败！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                            DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Error");   
                }
            }
        }

        //关闭
        protected void lbtClose_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Period bll = new BLL.CCOM.Period();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                Model.CCOM.Period model = bll.GetModel(id);
                model.Period_state = false;
                if (bll.Update(model))
                {
                    JscriptMsg("关闭成功！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Success");
                }
                else
                    JscriptMsg("关闭失败！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Error");
            }
        }

        //开启本年度
        protected void lbtOpenThisYear_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Period bll = new BLL.CCOM.Period();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                Model.CCOM.Period model = new Model.CCOM.Period();
                model.Period_year = DateTime.Now.Year.ToString();
                model.Period_state = false;
                if (bll.Add(model) > 0)
                {
                    JscriptMsg("创建成功！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Success");
                }
                else
                    JscriptMsg("创建失败！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Error");
            }
        }

        //开启本年度
        protected void lbtOpenLastYear_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Period bll = new BLL.CCOM.Period();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                Model.CCOM.Period model = new Model.CCOM.Period();
                model.Period_year = (DateTime.Now.Year + 1).ToString();
                model.Period_state = false;
                if (bll.Add(model) > 0)
                {
                    JscriptMsg("创建成功！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Success");
                }
                else
                    JscriptMsg("创建失败！", Utils.CombUrlTxt("SetTime.aspx", "fun_id={0}&keywords={1}",
                        DESEncrypt.Encrypt(this.fun_id), keywordTab0), "Error");
            }
        }

    }
}