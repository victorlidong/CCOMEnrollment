using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    public partial class AddFractionalline : university.UI.ManagePage
    {
        protected int period_id = 0;
        private string action;
        public AddFractionalline()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.action = MyEnums.ActionEnum.Add.ToString(); //默认为添加操作类型
            string _action = MyRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MyEnums.ActionEnum.Edit.ToString())//编辑
            {
                this.action = MyEnums.ActionEnum.Edit.ToString();//修改类型
            }

            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }
            if (!Page.IsPostBack)
            {
                RptBind();
            }
            if (this.action == MyEnums.ActionEnum.Edit.ToString())
            {       
                int fi_id = Convert.ToInt32(DESEncrypt.Decrypt(MyRequest.GetQueryString("id")));
                RptBind1(fi_id);
            }
        }
        private void RptBind()
        {
            var bll = new BLL.CCOM.Province();
            this.ddlPro_ID.DataSource = bll.GetAllList();
            this.ddlPro_ID.DataTextField = "Province_name";
            this.ddlPro_ID.DataValueField = "Province_id";
            this.ddlPro_ID.DataBind();
            ListItem item = new ListItem("--请选择省份--", "#");
            this.ddlPro_ID.Items.Insert(0, item);       
        }

        private void RptBind1(int fi_id)
        {
            
            var Fra_model = new BLL.CCOM.Fractional_line().GetModel(fi_id);
            this.txtYiBenWen.Text = Fra_model.WenKeYiBen == 0 ? "" : Fra_model.WenKeYiBen.ToString();
            this.txtYiBenLi.Text = Fra_model.LiKeYiBen == 0 ? "" : Fra_model.LiKeYiBen.ToString();
            this.txtErBenWen.Text = Fra_model.WenKeErBen == 0 ? "" : Fra_model.WenKeErBen.ToString();
            this.txtErBenLi.Text = Fra_model.LiKeErBen == 0 ? "" : Fra_model.LiKeErBen.ToString();
            this.txtSanBenWen.Text = Fra_model.WenKeSanBen == 0 ? "" : Fra_model.WenKeSanBen.ToString();
            this.txtSanBenLi.Text = Fra_model.LiKeSanBen == 0 ? "" : Fra_model.LiKeSanBen.ToString();
            this.txtYiShuWen.Text = Fra_model.WenKeYiShuXian == 0 ? "" : Fra_model.WenKeYiShuXian.ToString();
            this.txtYiShuLi.Text = Fra_model.LiKeYiShuXian == 0 ? "" : Fra_model.LiKeYiShuXian.ToString();
            this.txtManWen.Text = Fra_model.WenKeZongFen == 0 ? "" : Fra_model.WenKeZongFen.ToString();
            this.txtManLi.Text = Fra_model.LiKeZongFen == 0 ? "" : Fra_model.LiKeZongFen.ToString();

            this.ddlPro_ID.Items.FindByValue(Fra_model.Fl_Province.ToString()).Selected = true;
            this.ddlPro_ID.Enabled = false; 
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(this.ddlPro_ID.SelectedItem.Value == "#"){
                JscriptMsg("请选择省份！", "", "Error");
                return;
            }
            if (this.txtManWen.Text.ToString().Trim() == "" || this.txtManLi.Text.ToString().Trim() == "")
            {
                JscriptMsg("文理科满分不能为空！", "", "Error");
                return;
            }
            var model = new Model.CCOM.Fractional_line();
            var _model = new Model.CCOM.Fractional_line();

            int Pro_id = Convert.ToInt32(this.ddlPro_ID.SelectedItem.Value);

            model = new BLL.CCOM.Fractional_line().GetModel(" Period_id = "+period_id+" and Fl_Province="+Pro_id);

            _model.WenKeYiBen = ((this.txtYiBenWen.Text.ToString() == "") ? 0 : (Convert.ToDecimal(this.txtYiBenWen.Text.ToString().Trim())));
            _model.LiKeYiBen = (this.txtYiBenLi.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtYiBenLi.Text.ToString().Trim()));
            _model.WenKeErBen = (this.txtErBenWen.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtErBenWen.Text.ToString().Trim()));
            _model.LiKeErBen = (this.txtErBenLi.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtErBenLi.Text.ToString().Trim()));
            _model.WenKeSanBen = (this.txtSanBenWen.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtSanBenWen.Text.ToString().Trim()));
            _model.LiKeSanBen = (this.txtSanBenLi.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtSanBenLi.Text.ToString().Trim()));
            _model.WenKeYiShuXian = (this.txtYiShuWen.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtYiShuWen.Text.ToString().Trim()));
            _model.LiKeYiShuXian = (this.txtYiShuLi.Text.ToString() == "" ? 0 : Convert.ToDecimal(this.txtYiShuLi.Text.ToString().Trim()));
            _model.WenKeZongFen = Convert.ToDecimal(this.txtManWen.Text.ToString().Trim());
            _model.LiKeZongFen = Convert.ToDecimal(this.txtManLi.Text.ToString().Trim());

            bool isOK = false;
            if (model != null)
            {
                _model.Fl_id = model.Fl_id;
                _model.Period_id = model.Period_id;
                _model.Fl_Province = model.Fl_Province;
                _model.Fl_addtime = model.Fl_addtime;
                isOK = DoUpdate(_model);
            }
            else
            {
                _model.Fl_Province = Pro_id;
                _model.Period_id = period_id;
                _model.Fl_addtime = DateTime.Now;
                isOK = DoAdd(_model);
            }

            if (isOK)
            {
                try
                {
                    new Calculation().calculateFenShuXian();
                    JscriptMsg("分数线添加成功", "FractionallineList.aspx?fun_id=" + get_fun_id("CCOM/CEEManege/FractionallineList.aspx"), "Success");
                }
                catch
                {
                    JscriptMsg("分数线添加失败，请重新尝试", "", "Error");
                }
            }
        }

        protected bool DoAdd(Model.CCOM.Fractional_line Fl)
        {
            try
            {
                BLL.CCOM.Fractional_line Bfl = new BLL.CCOM.Fractional_line();
                Bfl.Add(Fl);
            }
            catch(Exception ex)
            {
                JscriptMsg("添加出错，请重新提交", "", "Error");
                return false;
            }
            return true;
        }
        protected bool DoUpdate(Model.CCOM.Fractional_line Fl)
        {
            try
            {
                BLL.CCOM.Fractional_line Bfl = new BLL.CCOM.Fractional_line();
                Bfl.Update(Fl);
            }
            catch (Exception ex)
            {
                JscriptMsg("添加出错，请重新提交", "", "Error");
                return false;
            }
            return true;
        }
    }
}