using System;

namespace university.Model.CCOM
{
         //Examination_subject_nature
        public class Examination_subject_nature
    {
                
          /// <summary>
        /// Esn_id
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
        }        
        /// <summary>
        /// 科目标题
        /// </summary>        
        private string _esn_title;
        public string Esn_title
        {
            get{ return _esn_title; }
            set{ _esn_title = value; }
        }        
        /// <summary>
        /// 科目描述
        /// </summary>        
        private string _esn_content;
        public string Esn_content
        {
            get{ return _esn_content; }
            set{ _esn_content = value; }
        }        
        /// <summary>
        /// 科目类型 0-笔试 1-面试
        /// </summary>        
        private bool _esn_type;
        public bool Esn_type
        {
            get{ return _esn_type; }
            set{ _esn_type = value; }
        }        
        /// <summary>
        /// 乐器状态 0-无乐器 1-有乐器
        /// </summary>        
        private bool _esn_instrument_status;
        public bool Esn_instrument_status
        {
            get{ return _esn_instrument_status; }
            set{ _esn_instrument_status = value; }
        }        
        /// <summary>
        /// 乐器id --  乐器表
        /// </summary>        
        private int? _esn_mi_id;
        public int? Esn_Mi_id
        {
            get{ return _esn_mi_id; }
            set{ _esn_mi_id = value; }
        }        
        /// <summary>
        /// 负责系id  --  机构表
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
        }        
        /// <summary>
        /// 所属周期  -- 周期表
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
        }        
                
        
   
    }
}

