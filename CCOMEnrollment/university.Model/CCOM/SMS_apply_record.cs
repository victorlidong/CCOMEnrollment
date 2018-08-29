using System; 

namespace university.Model.CCOM{
         //SMS_apply_record
        public class SMS_apply_record
    {
                
          /// <summary>
        /// SMS_apply_id
        /// </summary>        
        private long _sms_apply_id;
        public long SMS_apply_id
        {
            get{ return _sms_apply_id; }
            set{ _sms_apply_id = value; }
        }        
        /// <summary>
        /// SMS_apply_number
        /// </summary>        
        private int _sms_apply_number;
        public int SMS_apply_number
        {
            get{ return _sms_apply_number; }
            set{ _sms_apply_number = value; }
        }        
        /// <summary>
        /// SMS_apply_status
        /// </summary>        
        private int _sms_apply_status;
        public int SMS_apply_status
        {
            get{ return _sms_apply_status; }
            set{ _sms_apply_status = value; }
        }        
        /// <summary>
        /// SMS_apply_reason
        /// </summary>        
        private string _sms_apply_reason;
        public string SMS_apply_reason
        {
            get{ return _sms_apply_reason; }
            set{ _sms_apply_reason = value; }
        }        
        /// <summary>
        /// SMS_apply_type
        /// </summary>        
        private int _sms_apply_type;
        public int SMS_apply_type
        {
            get{ return _sms_apply_type; }
            set{ _sms_apply_type = value; }
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
        /// SMS_give_number
        /// </summary>        
        private int _sms_give_number;
        public int SMS_give_number
        {
            get{ return _sms_give_number; }
            set{ _sms_give_number = value; }
        }        
        /// <summary>
        /// SMS_apply_time
        /// </summary>        
        private DateTime? _sms_apply_time;
        public DateTime? SMS_apply_time
        {
            get{ return _sms_apply_time; }
            set{ _sms_apply_time = value; }
        }        
        /// <summary>
        /// SMS_check_reason
        /// </summary>        
        private string _sms_check_reason;
        public string SMS_check_reason
        {
            get{ return _sms_check_reason; }
            set{ _sms_check_reason = value; }
        }        
                
        
   
    }
}

