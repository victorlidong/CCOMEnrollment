using System; 

namespace university.Model.CCOM{
         //Admin_agency
        public class Admin_agency
    {
                
          /// <summary>
        /// Aa_id
        /// </summary>        
        private int _aa_id;
        public int Aa_id
        {
            get{ return _aa_id; }
            set{ _aa_id = value; }
        }        
        /// <summary>
        /// 用户ID -- 用户基本表
        /// </summary>        
        private long? _user_id;
        public long? User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// 机构id  -- 机构表
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
        }        
                
        
   
    }
}

