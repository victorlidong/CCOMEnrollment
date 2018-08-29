using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using org.in2bits.MyXls;
using university.Common;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace university.Web.AdminMetro.CCOM.ScoreManage
{
    public partial class GroupStudentList : university.UI.ManagePage
    {
        protected long apply_id = 0;
        protected string PageTitle;
        //存放导出数据的表头
        protected ArrayList urlParamsList = new ArrayList();

        public GroupStudentList()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = get_fun_id("CCOM/ScoreManage/StudentList.aspx");
            this.apply_id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("groupid")));
            if (this.apply_id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            Model.CCOM.Reply_group model = new BLL.CCOM.Reply_group().GetModel(apply_id);
            if (model.Group_type == 0) PageTitle = "口头答辩打分";
            else if (model.Group_type == 1) PageTitle = "软件验收打分";
            else if (model.Group_type == 2) PageTitle = "开题评审打分";
            if (!Page.IsPostBack)
            {
                ShowApplyTitle();
                RptBind(" User_id desc ");
            }
       
        }

        protected bool HasApplyAttach()
        {
            var ml =
                new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + this.apply_id);
            return ml != null && ml.Count > 0;
        }
        private void ShowApplyTitle()
        {
            var m = new BLL.CCOM.Reply_group().GetModel((int) this.apply_id);
            this.lblTitle.Text += m.Group_name ;

        }
        private void RptBind(string _order)
        {
            var bll = new BLL.CCOM.Reply_student();
            //计算数量
            int totalCount = bll.GetRecordCount(" Group_id=" + apply_id);

            //绑定当页
            this.rptList.DataSource = bll.GetList(" Group_id=" + apply_id);
            this.rptList.DataBind();

           string pageUrl = Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&groupid={1}", MyRequest.GetQueryString("fun_id"), MyRequest.GetQueryString("groupid"));
        }

        protected String GetHref()
        {
            Model.CCOM.Reply_group model = new BLL.CCOM.Reply_group().GetModel(apply_id);
            if (model.Group_type == 1) {
                return "SoftwareScore";
            }
            else if (model.Group_type == 0) 
            {
                return "CommentScore";
            }
            else if (model.Group_type == 2)//需要添加开题评审页面
            {
                return "ProposalReview";
            }
            else
            {
                return "";
            }
        }

        protected String GetStudentName(long userId)
        {
            var model = new BLL.CCOM.User_information().GetModel(userId);
            return model.User_realname;
        }

        protected String GetStudentGender(long userId)
        {
            var model = new BLL.CCOM.User_information().GetModel(userId);
            return !model.User_gender?"男":"女";
        }

        protected String GetStudentNumber(long userId)
        {
            var model = new BLL.CCOM.User_information().GetModel(userId);
            return model.User_number;
        }

        protected String GetStudentBan(long userId)
        {
            var model = new BLL.CCOM.View_User().GetModel(" User_id=" + userId);
            return model.Agency_name;
        }

        protected String GetStudentStatus(long userId, long Group_id)
        {
            Model.CCOM.Reply_group model = new BLL.CCOM.Reply_group().GetModel(Group_id);
            try
            {
                if (model.Group_type == 0)
                {    //口头答辩
                    var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
                    if (GetAdminInfo_CCOM().User_id != group_model.User_id)//组员
                    {
                        var mark_table_model = new BLL.CCOM.View_Mark_table().GetModel(" Teacher_id=" + GetAdminInfo_CCOM().User_id);
                        if (mark_table_model != null)
                        {
                            return "<b style=\"color: green;\">已评分</b>";
                        }
                        else
                        {
                            return "<b style=\"color: red;\">未评分</b>";
                        }
                    }
                    else
                    {
                        long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId).Topic_relation_id;
                        var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + Topic_relation_id);
                        if (comment_model != null && comment_model.Reply_score != null)
                        {
                            return "<b style=\"color: green;\">已评分</b>";
                        }
                        else
                        {
                            return "<b style=\"color: red;\">未评分</b>";
                        }
                    }
                }
                else if (model.Group_type == 1)                       //软件验收
                {
                    long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId).Topic_relation_id;
                    var software_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + Topic_relation_id);
                    if (software_model != null && software_model.Conclusion != null)
                    {
                        return "<b style=\"color: green;\">已评分</b>";
                    }
                    else
                    {
                        return "<b style=\"color: red;\">未评分</b>";
                    }
                }
                else if (model.Group_type == 2)                       //开题评审
                {
                    long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId).Topic_relation_id;
                    var proposal_model = new BLL.CCOM.Proposal().GetModel(" Topic_relation_id=" + Topic_relation_id);
                    if (proposal_model != null && proposal_model.Result > 0)
                    {
                        if (proposal_model.Result == 1) return "<b style=\"color: green;\">已通过</b>";
                        else if (proposal_model.Result == 2) return "<b style=\"color: red;\">未通过</b>";
                        else return "";
                    }
                    else
                    {
                        return "<b>未审核</b>";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch {
                return "--";
            }
        }
    }
}