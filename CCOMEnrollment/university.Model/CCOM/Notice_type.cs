using System; 

namespace university.Model.CCOM{
         //Notice_type
        public class Notice_type
    {
                
          /// <summary>
        /// Notice_type_id
        /// </summary>        
        private long _notice_type_id;
        public long Notice_type_id
        {
            get{ return _notice_type_id; }
            set{ _notice_type_id = value; }
        }        
        /// <summary>
        /// Notice_type_name
        /// </summary>        
        private string _notice_type_name;
        public string Notice_type_name
        {
            get{ return _notice_type_name; }
            set{ _notice_type_name = value; }
        }        
        /// <summary>
        /// Notice_type_creator_id
        /// </summary>        
        private long _notice_type_creator_id;
        public long Notice_type_creator_id
        {
            get{ return _notice_type_creator_id; }
            set{ _notice_type_creator_id = value; }
        }        
        /// <summary>
        /// Notice_type_date
        /// </summary>        
        private DateTime? _notice_type_date;
        public DateTime? Notice_type_date
        {
            get{ return _notice_type_date; }
            set{ _notice_type_date = value; }
        }        
                
        
   
    }
}

