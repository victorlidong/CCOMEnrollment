using System; 

namespace university.Model.CCOM{
         //User_subject_value
        public class User_subject_value
    {
                
          /// <summary>
        /// Usv_id
        /// </summary>        
        private long _usv_id;
        public long Usv_id
        {
            get{ return _usv_id; }
            set{ _usv_id = value; }
        }        
        /// <summary>
        /// 科目id  -- 考试科目表
        /// </summary>        
        private int _subject_id;
        public int Subject_id
        {
            get{ return _subject_id; }
            set{ _subject_id = value; }
        }        
        /// <summary>
        /// 用户ID  -- 用户基本表
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// Usv_value
        /// </summary>        
        private string _usv_value;
        public string Usv_value
        {
            get{ return _usv_value; }
            set{ _usv_value = value; }
        }        
        /// <summary>
        /// Usv_children
        /// </summary>        
        private int? _usv_children;
        public int? Usv_children
        {
            get{ return _usv_children; }
            set{ _usv_children = value; }
        }        
                
        
   
    }
}

