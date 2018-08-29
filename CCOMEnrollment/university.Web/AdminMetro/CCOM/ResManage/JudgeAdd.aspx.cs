using System;
using System.Security.Cryptography;
using System.Web;
using university.Common;


namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class JudgeAdd : university.UI.ManagePage
    {
        private string action = MyEnums.ActionEnum.Add.ToString(); //操作类型
        protected long signId;
        public JudgeAdd()
        {
            //this.checkFunID = true;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyRequest.GetQueryString("action");
            this.fun_id = DESEncrypt.Decrypt(get_fun_id("CCOM/ResManage/JudgeAdd.aspx"));
            var t_signid = MyRequest.GetQueryString("id");
            if (t_signid != "")
            {
                signId = long.Parse(DESEncrypt.Decrypt(t_signid));
            }
            if (!Page.IsPostBack)
            {
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {

                    if (signId == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    BindSignInfo(signId);
                    this.btnSubmit.Text = "确认保存";
                }
                else
                {
                    this.btnSubmit.Text = "确认添加";
                }
            }
        }

        protected void BindSignInfo(long signId)
        {
            Model.CCOM.Judge model = new BLL.CCOM.Judge().GetModel(" Judge_id=" + signId);
            if (model != null)
            {
                this.nameText.Text = model.Judge_name;
                this.staffText.Text = model.Judge_staff_number;
                this.depText.Text = model.Judge_department;
                this.titleText.Text = model.Judge_title;
            }
            else
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String name = this.nameText.Text;
            String staff = this.staffText.Text;
            String dep = this.depText.Text;
            String title = this.titleText.Text;

            if (name == "")
            {
                JscriptMsg("评委姓名不能为空！", "", "Error");
                return;
            }
            if (staff == "")
            {
                JscriptMsg("教工号不能为空！", "", "Error");
                return;
            }
            if (dep == "")
            {
                JscriptMsg("所属部门不能为空！", "", "Error");
                return;
            }
            if (title == "")
            {
                JscriptMsg("职称不能为空！", "", "Error");
                return;
            }
            if (Tools.CheckParams(name))
            {
                JscriptMsg("评委姓名不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(staff))
            {
                JscriptMsg("教工号不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(dep))
            {
                JscriptMsg("所属部门不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(title))
            {
                JscriptMsg("评委职称不合法！", "", "Error");
                return;
            }

            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
                if (signId != 0)
                {
                    Model.CCOM.Judge model = new BLL.CCOM.Judge().GetModel(" Judge_id=" + signId);
                    if (model != null)
                    {
                        model.Judge_name = name;
                        model.Judge_staff_number = staff;
                        model.Judge_department = dep;
                        model.Judge_title = title;
                        if (new BLL.CCOM.Judge().Update(model))
                        {
                            string pageUrl = Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}",
                       DESEncrypt.Encrypt(this.fun_id));
                            JscriptMsg("评委信息编辑成功！^_^", pageUrl, "Success");
                        }
                        else
                        {
                            JscriptMsg("出现异常，评委信息编辑失败！", "", "Error");
                        }
                    }
                }
            }
            else
            {
                //add
                Model.CCOM.Judge model = new Model.CCOM.Judge();
                model.Judge_name = name;
                model.Judge_staff_number = staff;
                model.Judge_department = dep;
                model.Judge_title = title;
                model.Judge_id = new BLL.CCOM.Judge().Add(model);
                if (model.Judge_id > 0)
                {
                    string pageUrl = Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id));
                    JscriptMsg("添加评委成功！^_^", pageUrl, "Success");
                }
                else
                {
                    JscriptMsg("出现异常，添加评委失败！", "", "Error");
                }

            }
        }

    }
}