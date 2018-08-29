using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;
using university.Web.AdminMetro.CCOM.CEEManege;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    /// <summary>
    /// SetAEESubjectScorePort 的摘要说明
    /// </summary>
    public class SetAEESubjectScorePort : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            long Id;
            int Id1, Id2;
            string result = "";
            decimal Score = 0;
            try
            {
                Id = Convert.ToInt64(DESEncrypt.Decrypt(context.Request.Params["id"].ToString()));
                Id1 = Convert.ToInt32(DESEncrypt.Decrypt(context.Request.Params["id1"].ToString()));
                Id2 = Convert.ToInt32(DESEncrypt.Decrypt(context.Request.Params["id2"].ToString()));
                Score = Convert.ToDecimal(context.Request.Params["txtScore"].ToString());

                var model = new Model.CCOM.Examination_subject_score();
                var _model = new Model.CCOM.Examination_subject_score();
                BLL.CCOM.Examination_subject_score Bess = new BLL.CCOM.Examination_subject_score();

                model = new BLL.CCOM.Examination_subject_score().GetModel(" Esn_id = " + Id1 + " AND User_id=" + Id + " AND Judge_id=" + Id2);
                _model.Esn_id = Id1;
                _model.Ess_score = Score;
                _model.Judge_id = Id2;
                _model.User_id = Id;
                _model.Ess_score_status = true;
                _model.Ess_order_status = true;
                if (model != null)
                {
                    _model.Ess_id = model.Ess_id;
                    Bess.Update(_model);
                }
                else
                {
                    Bess.Add(_model);
                }
                new Calculation().calculateSubjectXu(Id1.ToString(), Id2.ToString());
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