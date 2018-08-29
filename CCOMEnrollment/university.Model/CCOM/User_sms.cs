using System; 

namespace university.Model.CCOM{
         //User_sms
        public class User_sms
    {
                
          /// <summary>
        /// User_sms_id
        /// </summary>        
        private long _user_sms_id;
        public long User_sms_id
        {
            get{ return _user_sms_id; }
            set{ _user_sms_id = value; }
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
        /// User_sms_left
        /// </summary>        
        private int _user_sms_left;
        public int User_sms_left
        {
            get{ return _user_sms_left; }
            set{ _user_sms_left = value; }
        }        
        /// <summary>
        /// User_sms_create_time
        /// </summary>        
        private DateTime _user_sms_create_time;
        public DateTime User_sms_create_time
        {
            get{ return _user_sms_create_time; }
            set{ _user_sms_create_time = value; }
        }        
        /// <summary>
        /// User_sms_modify_time
        /// </summary>        
        private DateTime? _user_sms_modify_time;
        public DateTime? User_sms_modify_time
        {
            get{ return _user_sms_modify_time; }
            set{ _user_sms_modify_time = value; }
        }        
                
        
   
    }
}

