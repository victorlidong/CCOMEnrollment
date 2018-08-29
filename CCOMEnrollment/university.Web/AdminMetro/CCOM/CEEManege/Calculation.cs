using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    public class Calculation
    {
        protected int period_id = 0;
        public Calculation()
        {
            var period = new BLL.CCOM.Period().GetModel(" Period_state = " + DataDic.Period_state_On);
            if (period != null) period_id = period.Period_id;
        }

        /// <summary>
        /// 如果某省市没有设定分数线，那么用北京的分数线进行折算
        /// </summary>
        /// <returns>成功返回true</returns>
        public bool calculateFenShuXian()
        {
            var bll = new BLL.CCOM.Fractional_line();
            var modelBJ = bll.GetModelList("Fl_Province in (select Province_id from Province where Province_name = '北京市') and Period_id = " + period_id);
            if (modelBJ != null && modelBJ.Count > 0)
            {
                var BeiJingXian = modelBJ[0];
                var provinceList = new BLL.CCOM.Province().GetModelList("");
                foreach (var province in provinceList)
                {
                    var model = bll.GetModelList("Fl_Province = " + province.Province_id + " and Period_id = " + period_id);
                    if (model != null && model.Count > 0)
                    {
                        ///先算三本线
                        //理科
                        if (model[0].LiKeSanBen.ToString() == "0")
                        {
                            if (model[0].LiKeErBen.ToString() != "0")
                            {
                                model[0].LiKeSanBen = BeiJingXian.LiKeSanBen * model[0].LiKeErBen / BeiJingXian.LiKeErBen;
                            }
                            else if (model[0].LiKeYiBen.ToString() != "0")
                            {
                                model[0].LiKeSanBen = BeiJingXian.LiKeSanBen * model[0].LiKeYiBen / BeiJingXian.LiKeYiBen;
                            }
                        }
                        //文科
                        if (model[0].WenKeSanBen.ToString() == "0")
                        {
                            if (model[0].WenKeErBen.ToString() != "0")
                            {
                                model[0].WenKeSanBen = BeiJingXian.WenKeSanBen * model[0].WenKeErBen / BeiJingXian.WenKeErBen;
                            }
                            else if (model[0].WenKeYiBen.ToString() != "0")
                            {
                                model[0].WenKeSanBen = BeiJingXian.WenKeSanBen * model[0].WenKeYiBen / BeiJingXian.WenKeYiBen;
                            }
                        }

                        ///再算艺术线
                        //理科
                        if (model[0].LiKeYiShuXian.ToString() == "0")
                        {
                            if (model[0].LiKeSanBen.ToString() != "0")
                            {
                                model[0].LiKeYiShuXian = BeiJingXian.LiKeYiShuXian * model[0].LiKeSanBen / BeiJingXian.LiKeSanBen;
                            }
                        }
                        //文科
                        if (model[0].WenKeYiShuXian.ToString() == "0")
                        {
                            if (model[0].WenKeSanBen.ToString() != "0")
                            {
                                model[0].WenKeYiShuXian = BeiJingXian.WenKeYiShuXian * model[0].WenKeSanBen / BeiJingXian.WenKeSanBen;
                            }
                        }

                        bll.Update(model[0]);
                    }
                }
            }
            return true;
        }


        public bool calculateSubjectXu(string esn_id, string jugde_id)
        {
            var bll = new BLL.CCOM.Examination_subject_score();

            var modelList = bll.GetModelList(" Esn_id =" + esn_id + " AND Judge_id=" + jugde_id + "order by Ess_score desc");
            int totalCount = modelList.Count;
            decimal _score = 200;
            int order = 0;
            if (totalCount > 0)
            {
                int count = 1;
                foreach (var model in modelList)
                {
                    if (model.Ess_score < _score)
                    {
                        model.Ess_sequence = count;
                        bll.Update(model);
                        _score = model.Ess_score;
                        order = count;
                    }
                    else
                    {
                        model.Ess_sequence = order;
                        bll.Update(model);
                    }
                    count++;
                }
            }
            return true;
        }


        /// <summary>
        /// 计算成绩，计算这个App_CCOM_TestScores表中 ShiJian是当前年份的记录
        /// 要求该表中以下字段不为空：UserID、SchoolUserID、WenLi、ZongFen、ZhuanYeMingCheng、ZhuanYeFenShu、ShiJian，SchoolUser_HomeProvince
        /// 最终计算的出WenKaoGuoXian、WenKeFenShu、以及ZuiZhongFenShu
        /// 计算规则：先判断其文考成绩是否过线（根据各省分数线以及不同专业的那个要求）；而后将理科考生的成绩按照公式转化为文科成绩，文科考生不做处理；
        /// 紧接着将文科成绩按照公式转化为百分制；最后文科成绩和艺术专业成绩按照各50%计算出最终成绩。
        /// </summary>
        /// <returns></returns>
        public bool Calculate(string major_id)
        {
            //calculateFenShuXian();
            try
            {
                BLL.CCOM.View_TotalScore bll = new BLL.CCOM.View_TotalScore();
                var userList = bll.GetModelList(" Period_id=" + period_id + " AND Agency_id=" + major_id); //本年度的学生
                foreach (var user in userList)
                {
                    var userInfo = new BLL.CCOM.User_property().GetModel(" User_id=" + user.User_id);
                    var userCEE = new BLL.CCOM.Examination_CEE_score().GetModel(" User_id=" + user.User_id + " AND Period_id=" + period_id);
                    var model = new BLL.CCOM.Transcript().GetModel(" User_id=" + user.User_id + " AND Period_id=" + period_id);
                    if (userInfo != null)
                    {
                        var fenshuxian = new BLL.CCOM.Fractional_line().GetModelList("Fl_Province = " + userInfo.UP_province + " and Period_id = " + period_id);
                        if (fenshuxian == null || fenshuxian.Count == 0) continue;

                        int WenLi = (int)(userCEE.CEE_type);
                        ///判断是否过线
                        string zhuanye = new BLL.CCOM.Agency().GetModel("Agency_id=" + major_id).Agency_name;
                        var guoxianfen = guoxianFen(zhuanye, WenLi, fenshuxian[0]);
                        if (guoxianfen == 0) continue;

                        bool passline = false;
                        if (guoxianfen <= Convert.ToDecimal(userCEE.CEE_score)) passline = true;
                        else passline = false;

                        decimal wenkaofenshu = (decimal)userCEE.CEE_score;
                        if (WenLi == 2)  //理科
                        {
                            wenkaofenshu = wenkaofenshu / (decimal)fenshuxian[0].LiKeSanBen * (decimal)fenshuxian[0].WenKeSanBen;
                        }
                        wenkaofenshu = wenkaofenshu / (decimal)fenshuxian[0].WenKeZongFen * 100;  //转换为百分制
                        user.Transcript_CEE_convert_score = wenkaofenshu;
                        user.Transcript_CEE_score = userCEE.CEE_score;

                        decimal score = 0;
                        if (zhuanye == "音乐学" || zhuanye == "音乐艺术管理" || zhuanye == "音乐治疗" || zhuanye == "音乐教育" || zhuanye == "音乐教育（协作计划）")
                        {
                            score = wenkaofenshu * (decimal)0.5 + (decimal)user.Transcript_AEE_score * (decimal)0.5;
                        }
                        else score = (decimal)user.Transcript_AEE_score;

                        model.Transcript_CEE_score = userCEE.CEE_score;
                        model.Transcript_CEE_convert_score = wenkaofenshu;
                        model.Transcript_passline = passline;
                        model.Transcript_score = score;
                    }
                    new BLL.CCOM.Transcript().Update(model);
                }
            }
            catch
            {

            }
            return true;
        }

        public decimal guoxianFen(String zhuanye, int WenLi, Model.CCOM.Fractional_line fenshuxian)
        {
            try
            {
                if (WenLi == 1) //文科
                {
                    if (zhuanye == "音乐学" || zhuanye == "音乐艺术管理" || zhuanye == "音乐治疗")
                    {
                        return Convert.ToDecimal(fenshuxian.WenKeSanBen);
                    }
                    else if (zhuanye == "音乐教育" || zhuanye == "音乐教育（协作计划）")
                    {
                        return Convert.ToDecimal(fenshuxian.WenKeSanBen) * (decimal)0.8;
                    }
                    else return Convert.ToDecimal(fenshuxian.WenKeYiShuXian);
                }
                else if (WenLi == 2)  //理科
                {
                    if (zhuanye == "音乐学" || zhuanye == "音乐艺术管理" || zhuanye == "音乐治疗")
                    {
                        return Convert.ToDecimal(fenshuxian.LiKeSanBen);
                    }
                    else if (zhuanye == "音乐教育" || zhuanye == "音乐教育（协作计划）")
                    {
                        return Convert.ToDecimal(fenshuxian.LiKeSanBen) * (decimal)0.8;
                    }
                    else return Convert.ToDecimal(fenshuxian.LiKeYiShuXian);
                }
                else return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}