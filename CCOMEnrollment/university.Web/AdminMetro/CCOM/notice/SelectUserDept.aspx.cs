using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Database;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class SelectUserDept : university.UI.ManagePage
    {
        private static int DEPT_TYPE = 1;
        private static int GROUP_TYPE = 2;
        private static int USER_TYPE = 3;

        private int isSendCounsellor = 0;
        public SelectUserDept()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.fun_id = get_fun_id("CCOM/notice/SelectUserDept.aspx");
            this.isSendCounsellor = MyRequest.GetQueryInt("isSendCounsellor");
            if (!IsPostBack)
            {
                //绑定机构树
                DepartmentTreeBindNoCheck(this.trDepartmentList);
                //绑定通讯组树
                //UserGroupTreeBindNoCheck(this.trUserGroup);
                //绑定通讯录
                BindDDL();

                this.trDepartmentList.Attributes.Add("onclick", "CheckEvent()");
                //this.trUserGroup.Attributes.Add("onclick", "CheckEvent()");
            }
        }

        #region  ==========================绑定机构树
        //绑定机构树
        private void DepartmentTreeBindNoCheck(TreeView tv)
        {
           
            string groupIdStr = Server.UrlDecode(MyRequest.GetQueryString("groupList"));
            
            List<String> groupIdList = groupIdStr.Split(',').ToList();
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            TreeBindNoCheck_UOAndUser(tv, 1);
            //UpdateTreenodeStatus(tv.Nodes[0], userIdList);
            UpdateTreenodeStatus(tv.Nodes[0], groupIdList);

        }


        private void TreeBindNoCheck_UOAndUser(TreeView tv, int _ID)
        {
            tv.Nodes.Clear();
            //父节点
            var pud = new BLL.CCOM.Agency().GetModel(_ID);
            if (pud != null)
            {
                var tn = new TreeNode(pud.Agency_name, 'O' + pud.Agency_id.ToString());
                tn.Expanded = true;
                tn.ImageUrl = "/images/folder.png";
                tv.Nodes.Add(tn);
                TreeAddChildNoCheck_UOAndUser(tn, pud);

            }
        }

        public void TreeAddChildNoCheck_UOAndUser(TreeNode tn, Model.CCOM.Agency ud)
        {
            var bll = new BLL.CCOM.Agency();
            var uds = bll.GetModelList(" Agency_father=" + ud.Agency_id.ToString());
            if(uds!=null)
            {
                foreach (var cud in uds)
                {
                    var ctn = new TreeNode(cud.Agency_name, 'O' + cud.Agency_id.ToString());
                    ctn.Expanded = false;
                    ctn.ImageUrl = "/images/folder.png";
                    tn.ChildNodes.Add(ctn);
                    TreeAddChildNoCheck_UOAndUser(ctn, cud);
                }
            }

        }
        //更新节点选中状态
        private void UpdateTreenodeStatus(TreeNode node, List<String> valueList)
        {
            if (valueList.Contains(node.Value.Substring(1)))
            {
                if (node.Parent != null)
                    node.Parent.Expanded = true;
                node.Checked = true;
            }

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                UpdateTreenodeStatus(node.ChildNodes[i], valueList);
            }
        }
        #endregion

        


        #region ================================绑定通讯录
        private void BindDDL()
        {
            //一级下拉菜单
            var firstList = new BLL.CCOM.Agency().GetList("Agency_father = 1 and Agency_status=1");
            if (firstList.Tables[0].DefaultView.Count <= 0) return;
            this.DropDownList0.DataSource = firstList;
            this.DropDownList0.DataTextField = "Agency_name";
            this.DropDownList0.DataValueField = "Agency_id";
            this.DropDownList0.DataBind();
            this.DropDownList0.Items.Insert(0, new ListItem("请您选择...", "0"));
            this.DropDownList1.Items.Insert(0, new ListItem("请您选择...", "0"));
            this.DropDownList2.Items.Insert(0, new ListItem("请您选择...", "0"));
        }
        protected void DropDownList0_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            int selectValue = Convert.ToInt32(this.DropDownList0.SelectedValue);
            if (selectValue!=0)
            {
                var secondUOList = bll.GetList("Agency_father = " + selectValue + " and Agency_status=1");
                this.DropDownList1.DataSource = secondUOList;
                this.DropDownList1.DataTextField = "Agency_name";
                this.DropDownList1.DataValueField = "Agency_id";
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, new ListItem("请您选择...", "0"));
            }
            this.tabIndex.Value = "3";
            BindUserList();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            DropDownList2.Items.Clear();
            int selectValue = Convert.ToInt32(this.DropDownList1.SelectedValue);
            if(selectValue!=0)
            {
                var thirdUOList = bll.GetList("Agency_father = " + selectValue + " and Agency_status=1");
                DropDownList2.Items.Clear();
                this.DropDownList2.DataSource = thirdUOList;
                this.DropDownList2.DataTextField = "Agency_name";
                this.DropDownList2.DataValueField = "Agency_id";
                this.DropDownList2.DataBind();
                this.DropDownList2.Items.Insert(0, new ListItem("请您选择...", "0"));
                
            }
            this.tabIndex.Value = "3";
            BindUserList();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabIndex.Value = "3";
            BindUserList();
        }

        //绑定某机构下用户列表
        public void BindUserList()
        {
            var period = new BLL.CCOM.Period().GetModel(" Period_state=1");
            if(this.DropDownList0.SelectedValue=="0")//列举筛选所有用户
            {
                List<Model.CCOM.User_information> user_list = new List<Model.CCOM.User_information>();
                var userList = new BLL.CCOM.User_property().GetModelList( " Period_id=" + period.Period_id);
                if (userList != null && userList.Count > 0)
                {
                    foreach (var user in userList)
                    {
                        var m = new BLL.CCOM.User_information().GetModel(user.User_id);
                        if (m != null)
                        {
                            user_list.Add(m);//用户
                        }
                    }
                }
                //绑定数据
                if (user_list != null && user_list.Count > 0)
                {
                    this.rptList.DataSource = user_list;
                    this.rptList.DataBind();
                }
                //DataTable newDataTable = new BLL.CCOM.User_information().GetAllList().Tables[0];
                //if (newDataTable != null && newDataTable.Rows.Count>0)
                //{
                //    this.rptList.DataSource = newDataTable;
                //    this.rptList.DataBind();
                //}
                return;
            }
            if (this.DropDownList1.SelectedValue == "0")//列举筛选部分用户
            {
                List<Model.CCOM.User_information> user_list = new List<Model.CCOM.User_information>();
                BLL.CCOM.Agency bll=new BLL.CCOM.Agency();
                
                var list = bll.GetModelList("Agency_father=" + this.DropDownList0.SelectedValue);//第二层机构
                if (list.Count > 0 && list.Count > 0)
                {
                    foreach (Model.CCOM.Agency model in list)
                    {
                        var li = bll.GetModelList("Agency_father=" + model.Agency_id);//第三层机构
                        if(li!=null&&li.Count>0)
                        {
                            foreach(Model.CCOM.Agency mod in li)
                            {
                                var userList = new BLL.CCOM.User_property().GetModelList("Agency_id=" + mod.Agency_id + " and Period_id=" + period.Period_id);
                                if(userList!=null&&userList.Count>0)
                                {
                                    foreach(var user in userList)
                                    {
                                        var m = new BLL.CCOM.User_information().GetModel(user.User_id);
                                        if (m != null)
                                        {
                                            user_list.Add(m);//用户
                                        } 
                                    }
                                }
                            }
                        }
                    }
                    
                    //绑定数据
                    if (user_list != null && user_list.Count > 0)
                    {
                        this.rptList.DataSource = user_list;
                        this.rptList.DataBind();
                    }
                }
                return;
            }
            if (this.DropDownList2.SelectedValue == "0")//列举筛选部分用户
            {
                List<Model.CCOM.User_information> user_list = new List<Model.CCOM.User_information>();
                BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
                var AgencyList = bll.GetModelList("Agency_father=" + this.DropDownList1.SelectedValue);//第三层机构
                if (AgencyList != null && AgencyList.Count>0)
                {
                    foreach(Model.CCOM.Agency model in AgencyList)
                    {
                        var userList = new BLL.CCOM.User_property().GetModelList("Agency_id=" + model.Agency_id + " and Period_id=" + period.Period_id);
                        if (userList != null && userList.Count > 0)
                        {
                            foreach (var user in userList)
                            {
                                var m = new BLL.CCOM.User_information().GetModel(user.User_id);
                                if (m != null)
                                {
                                    user_list.Add(m);//用户
                                }
                            }
                        }
                    }
                    if(user_list!=null&&user_list.Count>0)
                    {
                        this.rptList.DataSource = user_list;
                        this.rptList.DataBind();
                    }
                    //绑定数据
                    
                }
                return;
            }

            
        }
        #endregion



        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var deptIdList = new List<string>();
            var groupIdList = new List<string>();

            var nameNodeList  = new Hashtable();
            List<String> userIdList = null;
            string userIdStr = Server.UrlDecode(MyRequest.GetQueryString("userList"));
            var nodeName = Server.UrlDecode(MyRequest.GetQueryString("nodeNameList"));
            //var list=JsonConvert.DeserializeObject(nodeName);
            var js1 = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jarr = js1.Deserialize<Dictionary<string, object>>(nodeName);

            if (!string.IsNullOrEmpty(userIdStr))
            {
                var values = jarr.Values.ToList();
                var key = jarr.Keys.ToList();
                userIdList = userIdStr.Split(',').ToList();
                var nameList = nodeName.Split(',').ToList();

                for (int i = 0; i < userIdList.Count; i++)
                {
                    if (!nameNodeList.Contains(USER_TYPE + "|" + userIdList[i]))
                    {
                        nameNodeList.Add(USER_TYPE + "|" + userIdList[i], values[i]);
                    }
                }
            }
            else
            {
                userIdList = new List<string>();
                
            }

            for (int i = 0; i < this.trDepartmentList.CheckedNodes.Count; i++)
            {
                var checkedNode = this.trDepartmentList.CheckedNodes[i];
                groupIdList.Add(checkedNode.Value.Substring(1));
                ////加入返回的节点集合中，格式为(type|id, name)
                //nameNodeList.Add(GROUP_TYPE + "|" + checkedNode.Value, checkedNode.Text);
                
            }


            for (int i = 0; i < rptList.Items.Count; i++)
            {
                var value = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                if (cb.Checked)
                {
                    string userId = value.Split('_')[0];
                    if (!userIdList.Contains(userId))
                    {
                        userIdList.Add(userId);
                        //加入返回的节点集合中，格式为(type|id, name)
                        var userName = new BLL.CCOM.User_information().GetModel(long.Parse(userId)).User_realname;
                        nameNodeList.Add(USER_TYPE + "|" + userId, userName);
                    }
                }
                else
                {
                    string userId = value.Split('_')[0];
                    if (userIdList.Contains(userId))//未选中且包含则去除
                    {
                        
                        userIdList.Remove(userId);
                        nameNodeList.Remove(USER_TYPE + "|" + userId);
                    }
                }
            }

            int totalUserCount;
            if (this.isSendCounsellor == 1)
            {
                totalUserCount = GetTotalUserCount(null, groupIdList, userIdList,nameNodeList);
            }
            else
            {
                totalUserCount = GetTotalUserCount(deptIdList, groupIdList, userIdList,nameNodeList);
            }

            //调用前台js函数，将结果返回父页面
            var js = "selectDeptSuccess('" + String.Join(",", deptIdList.ToArray()) + "','" + String.Join(",", groupIdList.ToArray()) +
                "','" + String.Join(",", userIdList.ToArray()) + "','" + LitJson.JsonMapper.ToJson(nameNodeList) + "','" + totalUserCount + "')";
            JscriptReponse(js);
        }


        //计算选中的推送用户数
        private int GetTotalUserCount(List<string> deptIdList, List<string> groupIdList, List<string> userIdList,Hashtable nameNodeList)
        {
            //list参数是引用传递，会影响原来的值，不能直接加入到userIdList
            List<string> idList = new List<string>(userIdList);
            var period = new BLL.CCOM.Period().GetModel(" Period_state=1");
            //加入机构列表包含的所有UserId
            if (deptIdList != null && deptIdList.Count>0)
            {
                
            }

            //加入通讯组列表包含的所有UserId
            if (groupIdList!=null&&groupIdList.Count > 0)
            {
                for(int i=0;i<groupIdList.Count;i++)
                {
                    var model_list = new BLL.CCOM.User_property().GetModelList(" Agency_id=" + groupIdList[i] + " and Period_id=" + period.Period_id);
                    if(model_list!=null&&model_list.Count>0)
                    {
                        for(int j=0;j<model_list.Count;j++)
                        {
                            if (!userIdList.Contains(model_list[j].User_id.ToString()))
                            {
                                idList.Add(model_list[j].User_id.ToString());
                                userIdList.Add(model_list[j].User_id.ToString());
                                var _model=new BLL.CCOM.User_information().GetModel("User_id=" + model_list[j].User_id);
                                if(_model!=null)
                                {
                                    string realname = _model.User_realname;
                                    nameNodeList.Add(USER_TYPE + "|" + model_list[j].User_id,realname);
                                }
                                
                            }  
                        }
                    }
                }
            }

            return idList.Count;
        }

        //获取机构
        protected string GetAgency(int user_id)
        {
            var model = new BLL.CCOM.User_property().GetModel(" User_id="+user_id);
            if(model!=null)
            {
                return new BLL.CCOM.Agency().GetModel(model.Agency_id).Agency_name;
            }
            return "---";
        }

        protected bool IsContain(string user_id)
        {
            string userIdStr = Server.UrlDecode(MyRequest.GetQueryString("userList"));
            string list = MyRequest.GetQueryString("userList");
            List<String> userIdList = userIdStr.Split(',').ToList();
            if(userIdList.Contains(user_id))
            {
                return true;
            }
            return false;
        }
    }
}