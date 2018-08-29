using System; 

namespace university.Model.CCOM{
         //Notice
        public class Notice
    {
                
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
        /// Notice_title
        /// </summary>        
        private string _notice_title;
        public string Notice_title
        {
            get{ return _notice_title; }
            set{ _notice_title = value; }
        }        
        /// <summary>
        /// Notice_content
        /// </summary>        
        private string _notice_content;
        public string Notice_content
        {
            get{ return _notice_content; }
            set{ _notice_content = value; }
        }        
        /// <summary>
        /// Notice_date
        /// </summary>        
        private DateTime? _notice_date;
        public DateTime? Notice_date
        {
            get{ return _notice_date; }
            set{ _notice_date = value; }
        }        
        /// <summary>
        /// Notice_sender_id
        /// </summary>        
        private long _notice_sender_id;
        public long Notice_sender_id
        {
            get{ return _notice_sender_id; }
            set{ _notice_sender_id = value; }
        }        
        /// <summary>
        /// Notice_receiver_id
        /// </summary>        
        private string _notice_receiver_id;
        public string Notice_receiver_id
        {
            get{ return _notice_receiver_id; }
            set{ _notice_receiver_id = value; }
        }        
        /// <summary>
        /// Notice_type
        /// </summary>        
        private bool? _notice_type;
        public bool? Notice_type
        {
            get{ return _notice_type; }
            set{ _notice_type = value; }
        }        
        /// <summary>
        /// Notice_URL
        /// </summary>        
        private string _notice_url;
        public string Notice_URL
        {
            get{ return _notice_url; }
            set{ _notice_url = value; }
        }        
        /// <summary>
        /// Notice_type_id
        /// </summary>        
        private long? _notice_type_id;
        public long? Notice_type_id
        {
            get{ return _notice_type_id; }
            set{ _notice_type_id = value; }
        }        
        /// <summary>
        /// Notice_last_editor
        /// </summary>        
        private long? _notice_last_editor;
        public long? Notice_last_editor
        {
            get{ return _notice_last_editor; }
            set{ _notice_last_editor = value; }
        }        
        /// <summary>
        /// Notice_flag
        /// </summary>        
        private bool? _notice_flag;
        public bool? Notice_flag
        {
            get{ return _notice_flag; }
            set{ _notice_flag = value; }
        }        
                
        
   
    }
}

