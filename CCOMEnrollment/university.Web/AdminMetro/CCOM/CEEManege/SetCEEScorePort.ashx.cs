using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;
using log4net;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    /// <summary>
    /// SetCEEScorePort 的摘要说明
    /// </summary>
    public class SetCEEScorePort : IHttpHandler
    {
        protected int period_id = 0;
        public void ProcessRequest(HttpContext context)
        {
            long Id = 0;
            int type = 0;
            string result = "";
            decimal YuWen, ShuXue, YingYu, ZongHe, ErWai, ZongFen;
            YuWen = ShuXue = YingYu = ZongHe = ErWai = ZongFen = 0;

            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }

            try
            {
                Id = Convert.ToInt64(DESEncrypt.Decrypt(context.Request.Params["id"].ToString()));
                type = Convert.ToInt16(context.Request.Params["type"].ToString());
                YuWen = Convert.ToDecimal(context.Request.Params["YuWen"].ToString());
                ShuXue = Convert.ToDecimal(context.Request.Params["ShuXue"].ToString());
                YingYu = Convert.ToDecimal(context.Request.Params["YingYu"].ToString());
                ZongHe = Convert.ToDecimal(context.Request.Params["ZongHe"].ToString());
                ErWai = Convert.ToDecimal(context.Request.Params["ErWai"].ToString());
                ZongFen = Convert.ToDecimal(context.Request.Params["ZongFen"].ToString());

                var model = new Model.CCOM.Examination_CEE_score();
                var _model = new Model.CCOM.Examination_CEE_score();
                BLL.CCOM.Examination_CEE_score Becs = new BLL.CCOM.Examination_CEE_score();

                model = new BLL.CCOM.Examination_CEE_score().GetModel(" Period_id = " + period_id + " and User_id=" + Id);
                _model.CEE_type = type;
                _model.CEE_Chinese_score = YuWen;
                _model.CEE_Math_score = ShuXue;
                _model.CEE_English_score = YingYu;
                _model.CEE_comprehensive_score = ZongHe;
                _model.CEE_extra_score = ErWai;
                _model.CEE_score = ZongFen;
                _model.Period_id = period_id;
                _model.User_id = Id;
                _model.CEE_status = false;
                if (model != null)
                {
                    _model.CEE_id = model.CEE_id;
                    Becs.Update(_model);
                }
                else
                {
                    Becs.Add(_model);
                }

                result += "添加成功";
            }
            catch (Exception ex)
            {
                ILog LOGGER = LogManager.GetLogger("quanquan");
                LOGGER.Debug(ex.Message, ex);
                result += "添加失败，请重新尝试";
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
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