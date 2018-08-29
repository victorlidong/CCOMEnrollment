using System;
using System.Security.Cryptography;
using System.Web;
using university.Common;


namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class RoomAdd : university.UI.ManagePage
    {
        private string action = MyEnums.ActionEnum.Add.ToString(); //操作类型
        protected long signId;
        public RoomAdd()
        {
            //this.checkFunID = true;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyRequest.GetQueryString("action");
            this.fun_id = DESEncrypt.Decrypt(get_fun_id("CCOM/ResManage/RoomAdd.aspx"));
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
            Model.CCOM.Examination_room model = new BLL.CCOM.Examination_room().GetModel(" Er_id=" + signId);
            if (model != null)
            {
                this.buildingText.Text = model.Er_building;
                this.floorText.Text = Utils.ObjectToStr(model.Er_floor);
                this.roomText.Text = model.Er_room;
                this.capacityText.Text = Utils.ObjectToStr(model.Er_capacity);
                this.remarkText.Text = model.Er_remark;
            }
            else
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String building = this.buildingText.Text;
            String floor = this.floorText.Text;
            String room = this.roomText.Text;
            String capacity = this.capacityText.Text;
            String remark = this.remarkText.Text;
            int floorInt;
            int capacityInt;

            if (building == "")
            {
                JscriptMsg("考场所在楼不能为空！", "", "Error");
                return;
            }
            if (floor == "")
            {
                JscriptMsg("楼层不能为空！", "", "Error");
                return;
            }
            if (room == "")
            {
                JscriptMsg("房间号不能为空！", "", "Error");
                return;
            }
            if (capacity == "")
            {
                JscriptMsg("容量不能为空！", "", "Error");
                return;
            }
            if (Tools.CheckParams(building))
            {
                JscriptMsg("考场所在楼名不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(floor))
            {
                JscriptMsg("考场所在楼层不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(room))
            {
                JscriptMsg("考场所在房间号不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(capacity))
            {
                JscriptMsg("考场容量不合法！", "", "Error");
                return;
            }
            if (Tools.CheckParams(remark))
            {
                JscriptMsg("备注不合法！", "", "Error");
                return;
            }
            try
            {
                floorInt = int.Parse(floor);
                capacityInt = int.Parse(capacity);
            }catch
            {
                JscriptMsg("输入不合法！", "", "Error");
                return;
            }
            

            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
                if (signId != 0)
                {
                    Model.CCOM.Examination_room model = new BLL.CCOM.Examination_room().GetModel(" Er_id=" + signId);
                    if (model != null)
                    {
                        model.Er_building = building;
                        model.Er_floor = floorInt;
                        model.Er_room = room;
                        model.Er_capacity = capacityInt;
                        model.Er_remark = remark;
                        if (new BLL.CCOM.Examination_room().Update(model))
                        {
                            string pageUrl = Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}",
                       DESEncrypt.Encrypt(this.fun_id));
                            JscriptMsg("考场编辑成功！^_^", pageUrl, "Success");
                        }
                        else
                        {
                            JscriptMsg("出现异常，考场编辑失败！", "", "Error");
                        }
                    }
                }
            }
            else
            {
                //add
                Model.CCOM.Examination_room model = new Model.CCOM.Examination_room();
                model.Er_building = building;
                model.Er_floor = floorInt;
                model.Er_room = room;
                model.Er_capacity = capacityInt;
                model.Er_remark = remark;
                model.Er_id = new BLL.CCOM.Examination_room().Add(model);
                if (model.Er_id > 0)
                {
                    string pageUrl = Utils.CombUrlTxt("RoomList.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id));
                    JscriptMsg("考场添加成功！^_^", pageUrl, "Success");
                }
                else
                {
                    JscriptMsg("出现异常，考场添加失败！", "", "Error");
                }

            }
        }

    }
}