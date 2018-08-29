using System; 

namespace university.Model.CCOM{
         //Subject
        public class Subject
    {
                
          /// <summary>
        /// Subject_id
        /// </summary>        
        private int _subject_id;
        public int Subject_id
        {
            get{ return _subject_id; }
            set{ _subject_id = value; }
        }        
        /// <summary>
        /// 科目标题
        /// </summary>        
        private string _subject_title;
        public string Subject_title
        {
            get{ return _subject_title; }
            set{ _subject_title = value; }
        }        
        /// <summary>
        /// 科目类型 0-笔试 1-面试
        /// </summary>        
        private bool? _subject_type;
        public bool? Subject_type
        {
            get{ return _subject_type; }
            set{ _subject_type = value; }
        }        
        /// <summary>
        /// 值类型 0-多项 1-单选 2-双选 3-三选 4-文本 5-不填
        /// </summary>        
        private int _value_type;
        public int Value_type
        {
            get{ return _value_type; }
            set{ _value_type = value; }
        }        
        /// <summary>
        /// Value_count
        /// </summary>        
        private int? _value_count;
        public int? Value_count
        {
            get{ return _value_count; }
            set{ _value_count = value; }
        }        
        /// <summary>
        /// 负责系id  --  机构表
        /// </summary>        
        private int? _manage_agency_id;
        public int? Manage_Agency_id
        {
            get{ return _manage_agency_id; }
            set{ _manage_agency_id = value; }
        }        
        /// <summary>
        /// Major_Agency_id
        /// </summary>        
        private int _major_agency_id;
        public int Major_Agency_id
        {
            get{ return _major_agency_id; }
            set{ _major_agency_id = value; }
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
        /// <summary>
        /// Subject_weight
        /// </summary>        
        private decimal? _subject_weight;
        public decimal? Subject_weight
        {
            get{ return _subject_weight; }
            set{ _subject_weight = value; }
        }        
        /// <summary>
        /// Subject_level
        /// </summary>        
        private int _subject_level;
        public int Subject_level
        {
            get{ return _subject_level; }
            set{ _subject_level = value; }
        }        
        /// <summary>
        /// Subject_description
        /// </summary>        
        private string _subject_description;
        public string Subject_description
        {
            get{ return _subject_description; }
            set{ _subject_description = value; }
        }        
        /// <summary>
        /// Fs_id
        /// </summary>        
        private int _fs_id;
        public int Fs_id
        {
            get{ return _fs_id; }
            set{ _fs_id = value; }
        }        
                
        
   
    }
}

