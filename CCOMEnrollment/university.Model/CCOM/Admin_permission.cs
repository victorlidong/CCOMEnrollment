using System; 

namespace university.Model.CCOM{
         //Admin_permission
        public class Admin_permission
    {
                
          /// <summary>
        /// Ap_id
        /// </summary>        
        private int _ap_id;
        public int Ap_id
        {
            get{ return _ap_id; }
            set{ _ap_id = value; }
        }        
        /// <summary>
        /// User_id
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// Sf_id
        /// </summary>        
        private int _sf_id;
        public int Sf_id
        {
            get{ return _sf_id; }
            set{ _sf_id = value; }
        }        
                
        
   
    }
}

