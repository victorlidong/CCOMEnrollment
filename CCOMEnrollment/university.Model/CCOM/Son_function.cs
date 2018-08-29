using System; 

namespace university.Model.CCOM{
         //子功能表
        public class Son_function
    {
                
          /// <summary>
        /// Sf_id
        /// </summary>        
        private int _sf_id;
        public int Sf_id
        {
            get{ return _sf_id; }
            set{ _sf_id = value; }
        }        
        /// <summary>
        /// 子功能名称
        /// </summary>        
        private string _sf_name;
        public string Sf_name
        {
            get{ return _sf_name; }
            set{ _sf_name = value; }
        }        
        /// <summary>
        /// 子功能URL
        /// </summary>        
        private string _sf_url;
        public string Sf_url
        {
            get{ return _sf_url; }
            set{ _sf_url = value; }
        }        
        /// <summary>
        /// 子功能排序
        /// </summary>        
        private int? _sf_sort;
        public int? Sf_sort
        {
            get{ return _sf_sort; }
            set{ _sf_sort = value; }
        }        
        /// <summary>
        /// 子功能状态
        /// </summary>        
        private bool? _sf_status;
        public bool? Sf_status
        {
            get{ return _sf_status; }
            set{ _sf_status = value; }
        }        
        /// <summary>
        /// 父功能ID
        /// </summary>        
        private int _ff_id;
        public int Ff_ID
        {
            get{ return _ff_id; }
            set{ _ff_id = value; }
        }        
                
        
   
    }
}

