using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.util;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using LitJson;
using Microsoft.JScript;
using Microsoft.Office.Interop.Excel;
using university.Common;

namespace university.Web.AdminMetro.CCOM.TopicManage
{
    /// <summary>
    /// UpdateSchoolUser 的摘要说明
    /// </summary>
    public class UpdateTopicInfor : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string fun = context.Request["fun"];
            context.Response.ContentType = "text/json";
            switch (fun)
            {
                case "StudentTopicState":
                    context.Response.Write(UpdateTopicState());
                    break;
                
                default:
                    break;
            }

        }

        protected string UpdateTopicState() {
            JsonData data = new JsonData();
            string id = MyRequest.GetString("ID");
            
            string msg = "";

            try
            {
                var bll = new BLL.CCOM.Topic();
                var m = bll.GetModel("Topic_id=" + id);
                Boolean isOn = m.Selected_state == true;
                m.Selected_state = isOn ^ true;
                if (bll.Update(m) == false)
                    msg = "修改发生异常！";
            }
            catch
            {
                msg = "修改发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "修改成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

    }
}