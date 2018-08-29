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
    public partial class ConfResource : university.UI.ManagePage
    {
        protected BLL.CCOM.Province bll_province;
        protected BLL.CCOM.Politics bll_politics;
        protected BLL.CCOM.Nationality bll_nationality;
        protected BLL.CCOM.Nation bll_nation;
        protected BLL.CCOM.Musical_instrument bll_musical_instrument;
        protected BLL.CCOM.Degree bll_degree;
        protected BLL.CCOM.Certificate_type bll_certivicate_type;
        protected string selectid = "";
        public string selectIndex = "";
        public string addOrEditIndex = "";
        protected string keywordTab0 = string.Empty;
        protected string keywordTab1 = string.Empty;
        protected string keywordTab2 = string.Empty;
        private static long _id = 0;
        public ConfResource()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_infomation model = GetAdminInfo_CCOM();
            _id = model.User_id;
            String keywords = MyRequest.GetQueryString("keywords");

            if (!Page.IsPostBack)
            {
                this.keywordTab0 = keywords;
                RoomBind(RoomCombSqlTxt(keywords), " Er_id desc ");
                this.keywordTab1 = keywords;
                JudgeBind(JudgeCombSqlTxt(keywords), " Judge_id desc ");

                this.selectid = MyRequest.GetString("selectid");
                if (this.selectid.Equals("")) this.selectid = "1";
                this.ddlResourceType.SelectedValue = selectid;
                this.ddltype.SelectedValue = selectid;
                this.ddltype.Enabled = false;
                this.nameText.Text = "";
                switch (this.selectid)
                {
                    case "1":
                        selectIndex = "Province_id";
                        break;
                    case "2":
                        selectIndex = "Politics_id";
                        break;
                    case "3":
                        selectIndex = "Nationality_id";
                        break;
                    case "4":
                        selectIndex = "Nation_id";
                        break;
                    case "5":
                        selectIndex = "Mi_id";
                        break;
                    case "6":
                        selectIndex = "Degree_id";
                        break;
                    case "7":
                        selectIndex = "Ct_id";
                        break;
                    default:
                        break;
                }
                RptBind(CombSqlTxt(keywords), " " + selectIndex + " desc ");
            }
        }

        #region 更新操作=================================

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConfSubject.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id.ToString()));
        }
        #endregion

        #region tab1=====================================
        //tab1===================
        #region 数据绑定=================================
        private void RoomBind(string _strWhere, string _order)
        {
            int pageSize = RoomGetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            //string keywords = MyRequest.GetQueryString("keywords");
            string keywords = this.keywordTab0;
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Examination_room();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.roomList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.roomList.DataBind();

            //绑定页码
            txtRoomPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string RoomCombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Er_building like '%" + _keywords + "%' ");
                strTemp.Append(" or Er_floor like '%" + _keywords + "%' ");
                strTemp.Append(" or Er_room like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int RoomGetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("RoomList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnRoomSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtRoomPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtRoomPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("RoomList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //删除
        protected void lbtRoomDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Examination_room bll = new BLL.CCOM.Examination_room();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result = bll.Delete(id);
                }
                catch
                {
                    result = false;
                }
                string keywords = this.keywordTab0;
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
            }
        }

        //获取考场楼名
        protected String GetRoomBuildingName(int id)
        {
            return new BLL.CCOM.Examination_room().GetModel(" Er_id=" + id).Er_building;
        }

        //获取考场楼层
        protected int GetRoomFloor(int id)
        {
            return new BLL.CCOM.Examination_room().GetModel(" Er_id=" + id).Er_floor;
        }

        //获取考场房间号
        protected String GetRoomName(int id)
        {
            return new BLL.CCOM.Examination_room().GetModel(" Er_id=" + id).Er_room;
        }

        //获取考场容量
        protected int GetRoomCapacity(int id)
        {
            return new BLL.CCOM.Examination_room().GetModel(" Er_id=" + id).Er_capacity;
        }

        //获取考场备注
        protected String GetRoomRemark(int id)
        {
            return new BLL.CCOM.Examination_room().GetModel(" Er_id=" + id).Er_remark;
        }

        protected String GetRoomEditLink(String enc_Id)
        {
            String link = "<a href=\"../ResManage/RoomAdd.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&action=" + MyEnums.ActionEnum.Edit.ToString() + "&id=" +
                          enc_Id + "\">编辑</a>";
            return link;
        }
        #endregion

        #region tab2====================================

        //tab2===================
        #region 数据绑定=================================
        private void JudgeBind(string _strWhere, string _order)
        {
            int pageSize = JudgeGetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            //string keywords = MyRequest.GetQueryString("keywords");
            string keywords = this.keywordTab0;
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Judge();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.Repeater1.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.Repeater1.DataBind();

            //绑定页码
            txtJudgePageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
            this.Div2.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string JudgeCombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Judge_name like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_staff_number like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_department like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_title like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int JudgeGetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("JudgeList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void JudgebtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtJudgePageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtJudgePageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("JudgeList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //删除
        protected void lbtJudgeDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Judge bll = new BLL.CCOM.Judge();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result = bll.Delete(id);
                }
                catch
                {
                    result = false;
                }
                string keywords = this.keywordTab0;
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
            }
        }

        //获取评委姓名
        protected String GetJudgeName(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_name;
        }

        //获取评委教工号
        protected String GetJudgeStaffNumber(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_staff_number;
        }

        //获取评委部门
        protected String GetJudgeDepartment(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_department;
        }

        //获取评委职称
        protected String GetJudgeTitle(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_title;
        }

        protected String GetJudgeEditLink(String enc_Id)
        {
            String link = "<a href=\"../ResManage/JudgeAdd.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&action=" + MyEnums.ActionEnum.Edit.ToString() + "&id=" +
                          enc_Id + "\">编辑</a>";
            return link;
        }

        #endregion

        #region tab3====================================

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

            int totalCount = 0;
            switch (this.ddlResourceType.SelectedValue)
            {
                case "1":
                    bll_province = new BLL.CCOM.Province();
                    totalCount = bll_province.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_province.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "2":
                    bll_politics = new BLL.CCOM.Politics();
                    totalCount = bll_politics.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_politics.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "3":
                    bll_nationality = new BLL.CCOM.Nationality();
                    totalCount = bll_nationality.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_nationality.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "4":
                    bll_nation = new BLL.CCOM.Nation();
                    totalCount = bll_nation.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_nation.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "5":
                    bll_musical_instrument = new BLL.CCOM.Musical_instrument();
                    totalCount = bll_musical_instrument.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_musical_instrument.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "6":
                    bll_degree = new BLL.CCOM.Degree();
                    totalCount = bll_degree.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_degree.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                case "7":
                    bll_certivicate_type = new BLL.CCOM.Certificate_type();
                    totalCount = bll_certivicate_type.GetRecordCount(_strWhere);
                    this.Repeater2.DataSource = bll_certivicate_type.GetListByPage(_strWhere, _order, start_index, end_index);
                    break;
                default:
                    break;
            }
            this.Repeater2.DataBind();
            //绑定页码
            txtResoursePageNumber.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
            this.Div3.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                switch (this.selectid)
                {
                    case "1":
                        strTemp.Append(" Province_name like '%" + _keywords + "%' ");
                        break;
                    case "2":
                        strTemp.Append(" Politics_name like '%" + _keywords + "%' ");
                        break;
                    case "3":
                        strTemp.Append(" Nationality_name like '%" + _keywords + "%' ");
                        break;
                    case "4":
                        strTemp.Append(" Nation_name like '%" + _keywords + "%' ");
                        break;
                    case "5":
                        strTemp.Append(" Mi_name like '%" + _keywords + "%' ");
                        break;
                    case "6":
                        strTemp.Append(" Degree_name like '%" + _keywords + "%' ");
                        break;
                    case "7":
                        strTemp.Append(" Ct_name like '%" + _keywords + "%' ");
                        break;
                    default:
                        break;
                }
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("ResourceList_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&selectid={2}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text, this.ddlResourceType.SelectedValue));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtResoursePageNumber.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("ResourceList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    switch (this.ddlResourceType.SelectedValue)
                    {
                        case "1":
                            bll_province = new BLL.CCOM.Province();
                            result = bll_province.Delete(id);
                            break;
                        case "2":
                            bll_politics = new BLL.CCOM.Politics();
                            result = bll_politics.Delete(id);
                            break;
                        case "3":
                            bll_nationality = new BLL.CCOM.Nationality();
                            result = bll_nationality.Delete(id);
                            break;
                        case "4":
                            bll_nation = new BLL.CCOM.Nation();
                            result = bll_nation.Delete(id);
                            break;
                        case "5":
                            bll_musical_instrument = new BLL.CCOM.Musical_instrument();
                            result = bll_musical_instrument.Delete(id);
                            break;
                        case "6":
                            bll_degree = new BLL.CCOM.Degree();
                            result = bll_degree.Delete(id);
                            break;
                        case "7":
                            bll_certivicate_type = new BLL.CCOM.Certificate_type();
                            result = bll_certivicate_type.Delete(id);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    result = false;
                }
                string keywords = this.keywordTab0;
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}&selectid={3}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString(), this.ddlResourceType.SelectedValue), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("ConfResource.aspx", "fun_id={0}&keywords={1}&page={2}&selectid={3}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString(), this.ddlResourceType.SelectedValue), "Error");
            }
        }

        protected String GetName(int id)
        {
            switch (this.selectid)
            {
                case "1":
                    bll_province = new BLL.CCOM.Province();
                    return bll_province.GetModel(" " + selectIndex + "=" + id).Province_name;
                case "2":
                    bll_politics = new BLL.CCOM.Politics();
                    return bll_politics.GetModel(" " + selectIndex + "=" + id).Politics_name;
                case "3":
                    bll_nationality = new BLL.CCOM.Nationality();
                    return bll_nationality.GetModel(" " + selectIndex + "=" + id).Nationality_name;
                case "4":
                    bll_nation = new BLL.CCOM.Nation();
                    return bll_nation.GetModel(" " + selectIndex + "=" + id).Nation_name;
                case "5":
                    bll_musical_instrument = new BLL.CCOM.Musical_instrument();
                    return bll_musical_instrument.GetModel(" " + selectIndex + "=" + id).Mi_name;
                case "6":
                    bll_degree = new BLL.CCOM.Degree();
                    return bll_degree.GetModel(" " + selectIndex + "=" + id).Degree_name;
                case "7":
                    bll_certivicate_type = new BLL.CCOM.Certificate_type();
                    return bll_certivicate_type.GetModel(" " + selectIndex + "=" + id).Ct_name;
                default:
                    return "";
            }
        }

        public String GetResourseName(String signId)
        {
            switch (this.ddlResourceType.SelectedValue)
            {
                case "1":
                    Model.CCOM.Province model_province = new BLL.CCOM.Province().GetModel(" Province_id=" + signId);
                    if (model_province != null) return model_province.Province_name;
                    return "";
                case "2":
                    Model.CCOM.Politics model_politics = new BLL.CCOM.Politics().GetModel(" Politics_id=" + signId);
                    if (model_politics != null) return model_politics.Politics_name;
                    return "";
                case "3":
                    Model.CCOM.Nationality model_nationality = new BLL.CCOM.Nationality().GetModel(" Nationality_id=" + signId);
                    if (model_nationality != null) return model_nationality.Nationality_name;
                    return "";
                case "4":
                    Model.CCOM.Nation model_nation = new BLL.CCOM.Nation().GetModel(" Nation_id=" + signId);
                    if (model_nation != null) return model_nation.Nation_name;
                    return "";
                case "5":
                    Model.CCOM.Musical_instrument model_musical_instrument = new BLL.CCOM.Musical_instrument().GetModel(" Mi_id=" + signId);
                    if (model_musical_instrument != null) return model_musical_instrument.Mi_name;
                    return "";
                case "6":
                    Model.CCOM.Degree model_degree = new BLL.CCOM.Degree().GetModel(" Degree_id=" + signId);
                    if (model_degree != null) return model_degree.Degree_name;
                    return "";
                case "7":
                    Model.CCOM.Certificate_type model_certificate_type = new BLL.CCOM.Certificate_type().GetModel(" Ct_id=" + signId);
                    if (model_certificate_type != null) return model_certificate_type.Ct_name;
                    return "";
                default:
                    return "";
            }
        }

        public string GetItemID(int id)
        {
            this.addOrEditIndex = id.ToString(); ;
            return this.addOrEditIndex;
        }

        protected void DDMo_click(object sender, EventArgs e)
        {
            this.selectid = this.ddlResourceType.SelectedValue.ToString();
            this.ddltype.SelectedValue = this.ddlResourceType.SelectedValue;
            Response.Redirect("ConfResource.aspx?fun_id=" + DESEncrypt.Encrypt(fun_id) + "&selectid=" + this.ddlResourceType.SelectedValue.ToString());
        }

        #endregion
    }
}