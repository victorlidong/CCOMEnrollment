using System; 

namespace university.Model.CCOM{
         //News_type
        public class News_type
    {
                
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
        /// News_type_name
        /// </summary>        
        private string _news_type_name;
        public string News_type_name
        {
            get{ return _news_type_name; }
            set{ _news_type_name = value; }
        }        
        /// <summary>
        /// News_type_creator_id
        /// </summary>        
        private int _news_type_creator_id;
        public int News_type_creator_id
        {
            get{ return _news_type_creator_id; }
            set{ _news_type_creator_id = value; }
        }        
        /// <summary>
        /// News_type_date
        /// </summary>        
        private DateTime? _news_type_date;
        public DateTime? News_type_date
        {
            get{ return _news_type_date; }
            set{ _news_type_date = value; }
        }        
                
        
   
    }
}

