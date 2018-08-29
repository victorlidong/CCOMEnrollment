using System; 

namespace university.Model.CCOM{
         //Admin_role
        public class Admin_role
    {
                
          /// <summary>
        /// Ar_id
        /// </summary>        
        private long _ar_id;
        public long Ar_id
        {
            get{ return _ar_id; }
            set{ _ar_id = value; }
        }        
        /// <summary>
        /// 用户组ID
        /// </summary>        
        private int _role_id;
        public int Role_id
        {
            get{ return _role_id; }
            set{ _role_id = value; }
        }        
        /// <summary>
        /// 用户ID
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
                
        
   
    }
}

