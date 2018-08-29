using System; 

namespace university.Model.CCOM{
         //User_notice
        public class User_notice
    {
                
          /// <summary>
        /// id
        /// </summary>        
        private long _id;
        public long id
        {
            get{ return _id; }
            set{ _id = value; }
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
        /// Notice_id
        /// </summary>        
        private string _notice_id;
        public string Notice_id
        {
            get{ return _notice_id; }
            set{ _notice_id = value; }
        }        
        /// <summary>
        /// Notice_read_id
        /// </summary>        
        private string _notice_read_id;
        public string Notice_read_id
        {
            get{ return _notice_read_id; }
            set{ _notice_read_id = value; }
        }        
                
        
   
    }
}

