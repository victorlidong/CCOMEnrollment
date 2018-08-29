using System; 

namespace university.Model.CCOM{
         //Examination_arrangement_detail
        public class Examination_arrangement_detail
    {
                
          /// <summary>
        /// 排考详情ID
        /// </summary>        
        private long _ead_id;
        public long Ead_id
        {
            get{ return _ead_id; }
            set{ _ead_id = value; }
        }        
        /// <summary>
        /// 排考ID FK
        /// </summary>        
        private int _ea_id;
        public int Ea_id
        {
            get{ return _ea_id; }
            set{ _ea_id = value; }
        }        
        /// <summary>
        /// 用户ID FK
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
                
        
   
    }
}

