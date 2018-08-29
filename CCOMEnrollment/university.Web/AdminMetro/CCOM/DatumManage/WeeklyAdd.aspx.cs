using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.DatumManage
{
    public partial class WeeklyAdd : university.UI.ManagePage
    {
        public string action; //操作类型
        public int datumId;//修改参数
        public WeeklyAdd()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyEnums.ActionEnum.Add.ToString();
            datumId = 0;
            action = MyRequest.GetQueryString("action");
            datumId = MyRequest.GetQueryInt("weeklyId");
            if (!Page.IsPostBack)
            {
                BindDate();
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {
                    if (datumId == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    ShowInfo(datumId);
                    JscriptMsg("请重新编辑提交类型！", "", "Success");
                }
            } 
        }

        #region 初始化操作=================================
        public void BindDate()
        {
            new BLL.CCOM.Datum_type().BindDDL(this.dep);
        }
        #endregion

        #region 赋值操作=================================
        public void ShowInfo(int week_id)
        {
            Model.CCOM.Teach_week week_model = new BLL.CCOM.Teach_week().GetModel(week_id);
            this.txtStarttime.Value = week_model.Start_time.ToString("yyyy-MM-dd");
            this.txtEndtime.Value = week_model.End_time.ToString("yyyy-MM-dd");
            this.rblState.SelectedValue = week_model.State ? "1" : "0";
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";
            int week_id = datumId;
            BLL.CCOM.Teach_week week_bll = new BLL.CCOM.Teach_week();
            Model.CCOM.Teach_week week_model;
            if (action != MyEnums.ActionEnum.Edit.ToString())
            {
                week_model = new Model.CCOM.Teach_week();
            }
            else 
            { 
                week_model = week_bll.GetModel(datumId);
            }
            string startTime = this.txtStarttime.Value;
            string endTime = this.txtEndtime.Value;
            string state = this.rblState.SelectedValue;
            if (startTime == "") {
                return "请选择开始时间";
            }
            if (endTime == "") {
                return "请选择结束时间";
            }

            DateTime StartDate = Convert.ToDateTime(startTime);
            week_model.Start_time = StartDate;

            DateTime EndDate = Convert.ToDateTime(endTime);
            week_model.End_time = EndDate;

            week_model.State = Convert.ToInt32(state) != 0;

            try
            {
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    week_bll.Update(week_model);
                }
                else
                {
                    week_id = week_bll.Add(week_model);
                }
            }
            catch (Exception ex)
            {
                return action == MyEnums.ActionEnum.Edit.ToString() ? "修改失败" : "添加失败" + ex.Message.ToString();
            }

            if (week_id == 0) return "添加类型数据失败";

            BLL.CCOM.Homework work_bll = new BLL.CCOM.Homework();

            //work_bll.Delete(" Week_id='" + week_id + "'");//首先清空原有数据
            var work_models = work_bll.GetModelList(" Week_id='" + week_id + "'");
            string[] typeList = this.txtAddName.Text.Split('|');
            foreach (Model.CCOM.Homework work_model in work_models)
            {
                string workID = work_model.DatumType_id.ToString();
                int flag = 0;
                for (int i = 0; i < typeList.Length; i++)
                {
                    if (typeList[i] == workID)
                    {
                        typeList[i] = "";
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    work_bll.Delete(" Homework_id=" + work_model.Homework_id);
                }
            }

            foreach (string type in typeList)
            {
                if (type == "") continue;
                int type_id = Int32.Parse(type);
                Model.CCOM.Homework work_model = new Model.CCOM.Homework();
                work_model.Week_id = week_id;
                work_model.DatumType_id = type_id;

                work_bll.Add(work_model);
            }

            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
            {
                JscriptMsg(action == MyEnums.ActionEnum.Edit.ToString() ? "修改成功" : "添加成功", "WeeklyList.aspx", "Success");
                Response.Redirect("WeeklyList.aspx?homeworkId=" + datumId + "&fun_id=" + DESEncrypt.Encrypt("15"));
            }
            else
                JscriptMsg(result, "", "Error");

        }
    }
}