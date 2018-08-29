using System; 

namespace university.Model.CCOM{
         //SMS
        public class SMS
    {
                
          /// <summary>
        /// SMS_id
        /// </summary>        
        private long _sms_id;
        public long SMS_id
        {
            get{ return _sms_id; }
            set{ _sms_id = value; }
        }        
        /// <summary>
        /// Notice_id
        /// </summary>        
        private long _notice_id;
        public long Notice_id
        {
            get{ return _notice_id; }
            set{ _notice_id = value; }
        }        
        /// <summary>
        /// SMS_sender_id
        /// </summary>        
        private long _sms_sender_id;
        public long SMS_sender_id
        {
            get{ return _sms_sender_id; }
            set{ _sms_sender_id = value; }
        }        
        /// <summary>
        /// SMS_receiver_id
        /// </summary>        
        private string _sms_receiver_id;
        public string SMS_receiver_id
        {
            get{ return _sms_receiver_id; }
            set{ _sms_receiver_id = value; }
        }        
        /// <summary>
        /// SMS_content
        /// </summary>        
        private string _sms_content;
        public string SMS_content
        {
            get{ return _sms_content; }
            set{ _sms_content = value; }
        }        
        /// <summary>
        /// SMS_date
        /// </summary>        
        private DateTime? _sms_date;
        public DateTime? SMS_date
        {
            get{ return _sms_date; }
            set{ _sms_date = value; }
        }        
                
        
   
    }
}

