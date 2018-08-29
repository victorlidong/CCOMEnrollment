using System; 

namespace university.Model.CCOM{
         //Notice_attach
        public class Notice_attach
    {
                
          /// <summary>
        /// Notice_attach_id
        /// </summary>        
        private long _notice_attach_id;
        public long Notice_attach_id
        {
            get{ return _notice_attach_id; }
            set{ _notice_attach_id = value; }
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
        /// Notice_attach_name
        /// </summary>        
        private string _notice_attach_name;
        public string Notice_attach_name
        {
            get{ return _notice_attach_name; }
            set{ _notice_attach_name = value; }
        }        
        /// <summary>
        /// Notice_attach_address
        /// </summary>        
        private string _notice_attach_address;
        public string Notice_attach_address
        {
            get{ return _notice_attach_address; }
            set{ _notice_attach_address = value; }
        }        
                
        
   
    }
}

