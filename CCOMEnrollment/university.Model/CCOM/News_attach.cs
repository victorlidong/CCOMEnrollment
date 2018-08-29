using System; 

namespace university.Model.CCOM{
         //News_attach
        public class News_attach
    {
                
          /// <summary>
        /// News_attach_id
        /// </summary>        
        private int _news_attach_id;
        public int News_attach_id
        {
            get{ return _news_attach_id; }
            set{ _news_attach_id = value; }
        }        
        /// <summary>
        /// News_id
        /// </summary>        
        private int _news_id;
        public int News_id
        {
            get{ return _news_id; }
            set{ _news_id = value; }
        }        
        /// <summary>
        /// News_attach_name
        /// </summary>        
        private string _news_attach_name;
        public string News_attach_name
        {
            get{ return _news_attach_name; }
            set{ _news_attach_name = value; }
        }        
        /// <summary>
        /// News_attach_address
        /// </summary>        
        private string _news_attach_address;
        public string News_attach_address
        {
            get{ return _news_attach_address; }
            set{ _news_attach_address = value; }
        }        
                
        
   
    }
}

