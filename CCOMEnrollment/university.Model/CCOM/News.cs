using System; 

namespace university.Model.CCOM{
         //News
        public class News
    {
                
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
        /// News_type_id
        /// </summary>        
        private int _news_type_id;
        public int News_type_id
        {
            get{ return _news_type_id; }
            set{ _news_type_id = value; }
        }        
        /// <summary>
        /// News_title
        /// </summary>        
        private string _news_title;
        public string News_title
        {
            get{ return _news_title; }
            set{ _news_title = value; }
        }        
        /// <summary>
        /// News_creator_id
        /// </summary>        
        private int _news_creator_id;
        public int News_creator_id
        {
            get{ return _news_creator_id; }
            set{ _news_creator_id = value; }
        }        
        /// <summary>
        /// News_content
        /// </summary>        
        private string _news_content;
        public string News_content
        {
            get{ return _news_content; }
            set{ _news_content = value; }
        }        
        /// <summary>
        /// News_date
        /// </summary>        
        private DateTime? _news_date;
        public DateTime? News_date
        {
            get{ return _news_date; }
            set{ _news_date = value; }
        }        
        /// <summary>
        /// News_URL
        /// </summary>        
        private string _news_url;
        public string News_URL
        {
            get{ return _news_url; }
            set{ _news_url = value; }
        }        
        /// <summary>
        /// News_readnumber
        /// </summary>        
        private int? _news_readnumber;
        public int? News_readnumber
        {
            get{ return _news_readnumber; }
            set{ _news_readnumber = value; }
        }        
        /// <summary>
        /// News_last_editor
        /// </summary>        
        private int? _news_last_editor;
        public int? News_last_editor
        {
            get{ return _news_last_editor; }
            set{ _news_last_editor = value; }
        }        
        /// <summary>
        /// News_top
        /// </summary>        
        private bool? _news_top;
        public bool? News_top
        {
            get{ return _news_top; }
            set{ _news_top = value; }
        }        
        /// <summary>
        /// News_top_time
        /// </summary>        
        private int? _news_top_time;
        public int? News_top_time
        {
            get{ return _news_top_time; }
            set{ _news_top_time = value; }
        }        
                
        
   
    }
}

