using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.RoleManage
{
    public partial class PermissionManage : university.UI.ManagePage
    {
        private int id = 0;//修改参数
        private int type = 0;//0角色，1用户
        public PermissionManage()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id = MyRequest.GetQueryInt("id");
            type = MyRequest.GetQueryInt("type");
            BindFunction();
        }

        protected void BindFunction()
        {
            BLL.CCOM.Father_function ffbll = new BLL.CCOM.Father_function();
            BLL.CCOM.Son_function sfbll = new BLL.CCOM.Son_function();
            BLL.CCOM.Role_permission rpbll = new BLL.CCOM.Role_permission();
            //BLL.CCOM.Admin_permission apbll = new BLL.CCOM.Admin_permission();
            List<Model.CCOM.Father_function> ffmodel = ffbll.GetModelList("Ff_fatherID=0");
            for (int i = 0; i < ffmodel.Count; i++)
            {
                HtmlGenericControl rowFluidDiv = new HtmlGenericControl();
                rowFluidDiv.TagName = "div"; 
                rowFluidDiv.Attributes["class"] = "row-fluid"; 
                divControls.Controls.Add(rowFluidDiv);
                HtmlGenericControl span12Div = new HtmlGenericControl();
                span12Div.TagName = "div"; 
                span12Div.Attributes["class"] = "span12"; 
                rowFluidDiv.Controls.Add(span12Div);
                HtmlGenericControl widgetPurpleDiv = new HtmlGenericControl();
                widgetPurpleDiv.TagName = "div"; 
                widgetPurpleDiv.Attributes["class"] = "widget purple"; 
                span12Div.Controls.Add(widgetPurpleDiv);

                HtmlGenericControl widgetTitleDiv = new HtmlGenericControl();
                widgetTitleDiv.TagName = "div"; 
                widgetTitleDiv.Attributes["class"] = "widget-title"; 
                widgetPurpleDiv.Controls.Add(widgetTitleDiv);
                HtmlGenericControl ff1NameH4 = new HtmlGenericControl();
                ff1NameH4.TagName = "h4"; 
                ff1NameH4.InnerHtml = ffmodel[i].Ff_name;
                widgetTitleDiv.Controls.Add(ff1NameH4);
                HtmlGenericControl toolsSpan = new HtmlGenericControl();
                toolsSpan.TagName = "span"; 
                toolsSpan.Attributes["class"] = "tools";
                widgetTitleDiv.Controls.Add(toolsSpan);
                HtmlGenericControl iconA = new HtmlGenericControl();
                iconA.TagName = "a"; 
                iconA.Attributes["href"] =  "javascript:;";
                iconA.Attributes["class"] = "icon-chevron-down"; 
                toolsSpan.Controls.Add(iconA);

                HtmlGenericControl widgetBodyDiv = new HtmlGenericControl();
                widgetBodyDiv.TagName = "div"; 
                widgetBodyDiv.Attributes["class"] = "widget-body"; 
                widgetBodyDiv.Attributes["style"] = "display: block;";
                widgetPurpleDiv.Controls.Add(widgetBodyDiv);
                HtmlGenericControl tableTable = new HtmlGenericControl();
                tableTable.TagName = "table"; 
                tableTable.Attributes["class"] = "table"; 
                widgetBodyDiv.Controls.Add(tableTable);

                List<Model.CCOM.Father_function> ff2model = ffbll.GetModelList("Ff_fatherID="+ffmodel[i].Ff_id);
                for (int j = 0; j < ff2model.Count; j++)
                {
                    HtmlGenericControl thead = new HtmlGenericControl();
                    thead.TagName = "thead"; 
                    tableTable.Controls.Add(thead);
                    HtmlGenericControl theadTr = new HtmlGenericControl();
                    theadTr.TagName = "tr"; 
                    thead.Controls.Add(theadTr);
                    HtmlGenericControl theadTh = new HtmlGenericControl();
                    theadTh.TagName = "th"; 
                    theadTh.InnerHtml = ff2model[j].Ff_name;
                    theadTr.Controls.Add(theadTh);

                    HtmlGenericControl tbody = new HtmlGenericControl();
                    tbody.TagName = "tbody"; 
                    tableTable.Controls.Add(tbody);
                    HtmlGenericControl tbodyTr = null;
                    List<Model.CCOM.Son_function> sfmodel = sfbll.GetModelList("Ff_ID=" + ff2model[j].Ff_id + "ORDER BY Sf_sort");
                    int k;
                    for (k = 0; k < sfmodel.Count; k++)
                    {
                        bool haveModel;
                        haveModel = rpbll.GetModel("Role_id=" + id + "and Sf_ID=" + sfmodel[k].Sf_id) != null;
                        //if (type == 0)
                        //{
                        //    haveModel = rpbll.GetModel("Role_id=" + id + "and Sf_ID=" + sfmodel[k].Sf_id) != null;
                        //}
                        //else
                        //{
                        //    haveModel = apbll.GetModel("User_id=" + id + "and Sf_ID=" + sfmodel[k].Sf_id) != null;
                        //}
                        if (k % 3 == 0)
                        {
                            tbodyTr = new HtmlGenericControl();
                            tbodyTr.TagName = "tr"; 
                            tbody.Controls.Add(tbodyTr);
                        }
                        HtmlGenericControl theadTd = new HtmlGenericControl();
                        theadTd.TagName = "td"; 
                        tbodyTr.Controls.Add(theadTd);
                        CheckBox ckBox = new CheckBox();
                        ckBox.AutoPostBack = true;
                        ckBox.CheckedChanged += btnAble_Click;
                        ckBox.ID = sfmodel[k].Sf_id.ToString();
                        ckBox.Text = sfmodel[k].Sf_name;
                        if (haveModel)
                            ckBox.Checked = true;
                        else
                            ckBox.Checked = false;
                        theadTd.Controls.Add(ckBox);
                    }
                    if (k!=0 && --k % 3 != 2)
                    {
                        while (k++ % 3 != 2)
                        {
                            HtmlGenericControl blankTd = new HtmlGenericControl();
                            blankTd.TagName = "td"; 
                            blankTd.InnerHtml = "&nbsp;";
                            tbodyTr.Controls.Add(blankTd);
                        }
                    }
                }
            }
        }

        protected void btnAble_Click(object sender, EventArgs e)
        {
            var CKx = sender as CheckBox;
            BLL.CCOM.Role_permission rpbll = new BLL.CCOM.Role_permission();
            //BLL.CCOM.Admin_permission apbll = new BLL.CCOM.Admin_permission();
            //if (type == 0)
            //{
                if (CKx.Checked == false)
                {
                    rpbll.Delete("Role_id=" + id + "and Sf_id=" + CKx.ID.ToString());
                }
                else
                {
                    Model.CCOM.Role_permission model;
                    model = new Model.CCOM.Role_permission();
                    model.Role_id = id;
                    model.Sf_id = Convert.ToInt32(CKx.ID.ToString());
                    rpbll.Add(model);
                }
            //}
            //else
            //{
            //    if (CKx.Checked == false)
            //    {
            //        apbll.Delete("User_id=" + id + "and Sf_id=" + CKx.ID.ToString());
            //    }
            //    else
            //    {
            //        Model.CCOM.Admin_permission model;
            //        model = new Model.CCOM.Admin_permission();
            //        model.User_id = id;
            //        model.Sf_id = Convert.ToInt32(CKx.ID.ToString());
            //        apbll.Add(model);
            //    }
            //}
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (type == 0)
            //{
            Response.Redirect("RoleList.aspx?fun_id=" + get_fun_id("CCOM/RoleManage/RoleList.aspx"));
            //}
            //else
            //{
            //    Response.Redirect("../ManagerManage/ManagerList.aspx?fun_id=" + get_fun_id("CCOM/ManagerManage/ManagerList.aspx"));
            //}
        }
    }
}