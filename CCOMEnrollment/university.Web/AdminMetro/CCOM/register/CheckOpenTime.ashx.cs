using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace university.Web.AdminMetro.CCOM.register
{
    /// <summary>
    /// CheckOpenTime 的摘要说明
    /// </summary>
    public class CheckOpenTime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            switch(action)
            {
                case "getOpenTime":
                    {
                        getOpenTime(context);
                        break;
                    }
                default:
                    break;
            }
        }


        private void getOpenTime(HttpContext context)
        {
            Model.CCOM.Period model = new BLL.CCOM.Period().GetModel(" Period_state=1");
            DateTime start;
            DateTime end;
            DateTime now = DateTime.Now;
            if(model==null)
            {
                context.Response.Write("当前暂未开启注册");
            }
            else
            {
                if (model.Period_register_start!=null)
                {
                    start = (DateTime)model.Period_register_start;
                }
                else
                {
                    context.Response.Write("当前暂未开启注册");
                    return;
                }
                if (model.Period_register_end != null)
                {
                    end = (DateTime)model.Period_register_end;
                }
                else
                {
                    context.Response.Write("当前暂未开启注册");
                    return;
                }
                if (now >= start&&now<=end)
                {
                    context.Response.Write("success");
                }
                else
                {
                    if(now<start)
                    {
                        context.Response.Write("当前暂未开启注册");
                        return;
                    }
                    if(now>end)
                    {
                        context.Response.Write("注册已结束");
                        return;
                    }
                    
                }
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}