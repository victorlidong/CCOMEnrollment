using System;

namespace university.Model.CCOM
{
         //User_subject_record
        public class User_subject_record
    {
                
          /// <summary>
        /// Usr_id
        /// </summary>        
        private long _usr_id;
        public long Usr_id
        {
            get{ return _usr_id; }
            set{ _usr_id = value; }
        }        
        /// <summary>
        /// 科目id  -- 考试科目表
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
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
        /// 记录添加时间
        /// </summary>        
        private DateTime _usr_addtime;
        public DateTime Usr_addtime
        {
            get{ return _usr_addtime; }
            set{ _usr_addtime = value; }
        }        
                
        
   
    }
}

