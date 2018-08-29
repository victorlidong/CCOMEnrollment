using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class RoomList : university.UI.ManagePage
    {
        protected string keywordTab0 = string.Empty;
        protected string keywordTab1 = string.Empty;
        public RoomList()
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
                this.keywordTab0 = keywords;
                RptBind(CombSqlTxt(keywords), " Er_id desc ");
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

            var bll = new BLL.CCOM.Examination_room();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
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
                strTemp.Append(" Er_building like '%" + _keywords + "%' ");
                strTemp.Append(" or Er_floor like '%" + _keywords + "%' ");
                strTemp.Append(" or Er_room like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("RoomList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
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
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}&keywords={1}&page={2}",
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

        protected String GetEditLink(String enc_Id)
        {
            String link = "<a href=\"RoomAdd.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&action="+MyEnums.ActionEnum.Edit.ToString() +"&id=" +
                          enc_Id + "\">编辑</a>";
            return link;
        }
       
    }
}