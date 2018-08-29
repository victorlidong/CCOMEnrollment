using System;

namespace university.Model.CCOM
{
         //用户权限对应表
        public class User_permission
    {
                
          /// <summary>
        /// Upe_id
        /// </summary>        
        private long _upe_id;
        public long Upe_id
        {
            get{ return _upe_id; }
            set{ _upe_id = value; }
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
        /// <summary>
        /// 功能ID
        /// </summary>        
        private int _sf_id;
        public int Sf_id
        {
            get{ return _sf_id; }
            set{ _sf_id = value; }
        }        
                
        
   
    }
}

