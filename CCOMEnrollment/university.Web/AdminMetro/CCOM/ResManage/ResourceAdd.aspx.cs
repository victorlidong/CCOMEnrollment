using System;
using System.Security.Cryptography;
using System.Web;
using university.Common;


namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class ResourceAdd : university.UI.ManagePage
    {
        private string action = MyEnums.ActionEnum.Add.ToString(); //操作类型
        protected long signId;
        protected string selectid;
        public ResourceAdd()
        {
            //this.checkFunID = true;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyRequest.GetQueryString("action");
            var t_signid = MyRequest.GetQueryString("id");
            this.selectid = MyRequest.GetQueryString("selectid");
            if (t_signid != "")
            {
                signId = long.Parse(DESEncrypt.Decrypt(t_signid));
            }
            if (selectid.Equals("")) selectid = "1";

            if (!Page.IsPostBack)
            {
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {
                    if (signId == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    this.ddlResourceType.Enabled = false;
                    BindSignInfo(signId);
                    this.btnSubmit.Text = "确认保存";
                }
                else
                {
                    this.ddlResourceType.Enabled = true;
                    this.btnSubmit.Text = "确认添加";
                }
            }
        }

        protected void BindSignInfo(long signId)
        {
            this.ddlResourceType.SelectedValue = selectid;
            switch (this.selectid)
            {
                case "1":
                    Model.CCOM.Province model_province = new BLL.CCOM.Province().GetModel(" Province_id=" + signId);
                    if (model_province != null) this.nameText.Text = model_province.Province_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "2":
                    Model.CCOM.Politics model_politics = new BLL.CCOM.Politics().GetModel(" Politics_id=" + signId);
                    if (model_politics != null) this.nameText.Text = model_politics.Politics_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "3":
                    Model.CCOM.Nationality model_nationality = new BLL.CCOM.Nationality().GetModel(" Nationality_id=" + signId);
                    if (model_nationality != null) this.nameText.Text = model_nationality.Nationality_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "4":
                    Model.CCOM.Nation model_nation = new BLL.CCOM.Nation().GetModel(" Nation_id=" + signId);
                    if (model_nation != null) this.nameText.Text = model_nation.Nation_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "5":
                    Model.CCOM.Musical_instrument model_musical_instrument = new BLL.CCOM.Musical_instrument().GetModel(" Mi_id=" + signId);
                    if (model_musical_instrument != null) this.nameText.Text = model_musical_instrument.Mi_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "6":
                    Model.CCOM.Degree model_degree = new BLL.CCOM.Degree().GetModel(" Degree_id=" + signId);
                    if (model_degree != null) this.nameText.Text = model_degree.Degree_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                case "7":
                    Model.CCOM.Certificate_type model_certificate_type = new BLL.CCOM.Certificate_type().GetModel(" Ct_id=" + signId);
                    if (model_certificate_type != null) this.nameText.Text = model_certificate_type.Ct_name;
                    else JscriptMsg("传输参数不正确！", "back", "Error");
                    break;
                default:
                    break;
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String select = this.ddlResourceType.SelectedValue;
            String name = this.nameText.Text;

            if (name == "")
            {
                JscriptMsg("资源名称不能为空！", "", "Error");
                return;
            }
            if (select == "")
            {
                JscriptMsg("资源类型不能为空！", "", "Error");
                return;
            }
            if (Tools.CheckParams(name + select))
            {
                JscriptMsg("输入参数不合法！", "", "Error");
                return;
            }
            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
                if (signId != 0)
                {
                    string pageUrl = Utils.CombUrlTxt("ResourceList.aspx", "fun_id={0}&selectid={1}",
                                        DESEncrypt.Encrypt(this.fun_id), selectid);
                    switch (select)
                    {
                        case "1":
                            Model.CCOM.Province model_province = new BLL.CCOM.Province().GetModel(" Province_id=" + signId);
                            if (model_province != null) {
                                model_province.Province_name = name;
                                if (new BLL.CCOM.Province().GetModel(" Province_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Province().Update(model_province)) JscriptMsg("生源地编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，生源地编辑失败！", "", "Error");
                            }
                            break;
                        case "2":
                            Model.CCOM.Politics model_politics = new BLL.CCOM.Politics().GetModel(" Politics_id=" + signId);
                            if (model_politics != null)
                            {
                                model_politics.Politics_name = name;
                                if (new BLL.CCOM.Politics().GetModel(" Politics_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Politics().Update(model_politics)) JscriptMsg("政治面貌编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，政治面貌编辑失败！", "", "Error"); 
                            }
                            break;
                        case "3":
                            Model.CCOM.Nationality model_nationality = new BLL.CCOM.Nationality().GetModel(" Nationality_id=" + signId);
                            if (model_nationality != null)
                            {
                                model_nationality.Nationality_name = name;
                                if (new BLL.CCOM.Nationality().GetModel(" Nationality_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Nationality().Update(model_nationality)) JscriptMsg("民族编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，民族编辑失败！", "", "Error"); 
                            }
                            break;
                        case "4":
                            Model.CCOM.Nation model_nation = new BLL.CCOM.Nation().GetModel(" Nation_id=" + signId);
                            if (model_nation != null)
                            {
                                model_nation.Nation_name = name;
                                if (new BLL.CCOM.Nation().GetModel(" Nation_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Nation().Update(model_nation)) JscriptMsg("国籍编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，国籍编辑失败！", "", "Error"); 
                            }
                            break;
                        case "5":
                            Model.CCOM.Musical_instrument model_musical_instrument = new BLL.CCOM.Musical_instrument().GetModel(" Mi_id=" + signId);
                            if (model_musical_instrument != null)
                            {
                                model_musical_instrument.Mi_name = name;
                                if (new BLL.CCOM.Musical_instrument().GetModel(" Mi_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Musical_instrument().Update(model_musical_instrument)) JscriptMsg("乐器编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，乐器编辑失败！", "", "Error"); 
                            }
                            break;
                        case "6":
                            Model.CCOM.Degree model_degree = new BLL.CCOM.Degree().GetModel(" Degree_id=" + signId);
                            if (model_degree != null)
                            {
                                model_degree.Degree_name = name;
                                if (new BLL.CCOM.Degree().GetModel(" Degree_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Degree().Update(model_degree)) JscriptMsg("教育程度编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，教育程度编辑失败！", "", "Error"); 
                            }
                            break;
                        case "7":
                            Model.CCOM.Certificate_type model_certificate_type = new BLL.CCOM.Certificate_type().GetModel(" Ct_id=" + signId);
                            if (model_certificate_type != null)
                            {
                                model_certificate_type.Ct_name = name;
                                if (new BLL.CCOM.Certificate_type().GetModel(" Ct_name='" + name + "'") != null) JscriptMsg("系统中已有该资源！", "", "Error");
                                else if (new BLL.CCOM.Certificate_type().Update(model_certificate_type)) JscriptMsg("证件类型编辑成功！^_^", pageUrl, "Success");
                                else JscriptMsg("出现异常，证件类型编辑失败！", "", "Error"); 
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                //add
                string pageUrl = Utils.CombUrlTxt("ResourceList.aspx", "fun_id={0}&selectid={1}", DESEncrypt.Encrypt(this.fun_id), select);
                int id = 0;
                switch (select)
                {
                    case "1":
                        Model.CCOM.Province model_province = new Model.CCOM.Province();
                        model_province.Province_name = name;
                        if (new BLL.CCOM.Province().GetModel(" Province_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Province().Add(model_province);
                        break;
                    case "2":
                        Model.CCOM.Politics model_politics = new Model.CCOM.Politics();
                        model_politics.Politics_name = name;
                        if (new BLL.CCOM.Politics().GetModel(" Politics_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Politics().Add(model_politics);
                        break;
                    case "3":
                        Model.CCOM.Nationality model_nationality = new Model.CCOM.Nationality();
                        model_nationality.Nationality_name = name;
                        if (new BLL.CCOM.Nationality().GetModel(" Nationality_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Nationality().Add(model_nationality);
                        break;
                    case "4":
                        Model.CCOM.Nation model_nation = new Model.CCOM.Nation();
                        model_nation.Nation_name = name;
                        if (new BLL.CCOM.Nation().GetModel(" Nation_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Nation().Add(model_nation);
                        break;
                    case "5":
                        Model.CCOM.Musical_instrument model_musical_instrument = new Model.CCOM.Musical_instrument();
                        model_musical_instrument.Mi_name = name;
                        if (new BLL.CCOM.Musical_instrument().GetModel(" Mi_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Musical_instrument().Add(model_musical_instrument);
                        break;
                    case "6":
                        Model.CCOM.Degree model_degree = new Model.CCOM.Degree();
                        model_degree.Degree_name = name;
                        if (new BLL.CCOM.Degree().GetModel(" Degree_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Degree().Add(model_degree);
                        break;
                    case "7":
                        Model.CCOM.Certificate_type model_certificate_type = new Model.CCOM.Certificate_type();
                        model_certificate_type.Ct_name = name;
                        if (new BLL.CCOM.Certificate_type().GetModel(" Ct_name='" + name + "'") != null) id = -100;
                        else id = new BLL.CCOM.Certificate_type().Add(model_certificate_type);
                        break;
                    default:
                        break;
                }
                if (id > 0)
                {
                    JscriptMsg("添加资源成功！^_^", pageUrl, "Success");
                }
                else if (id == -100)
                {
                    JscriptMsg("系统中已有该资源！", "", "Error");
                }
                else
                {
                    JscriptMsg("出现异常，添加资源失败！", "", "Error");
                }

            }
        }

    }
}