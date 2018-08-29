using System; 

namespace university.Model.CCOM{
         //父功能表
        public class Father_function
    {
                
          /// <summary>
        /// Ff_id
        /// </summary>        
        private int _ff_id;
        public int Ff_id
        {
            get{ return _ff_id; }
            set{ _ff_id = value; }
        }        
        /// <summary>
        /// 功能名称
        /// </summary>        
        private string _ff_name;
        public string Ff_name
        {
            get{ return _ff_name; }
            set{ _ff_name = value; }
        }        
        /// <summary>
        /// 父功能ID
        /// </summary>        
        private int _ff_fatherid;
        public int Ff_fatherID
        {
            get{ return _ff_fatherid; }
            set{ _ff_fatherid = value; }
        }        
        /// <summary>
        /// 功能排序
        /// </summary>        
        private int _ff_sort;
        public int Ff_sort
        {
            get{ return _ff_sort; }
            set{ _ff_sort = value; }
        }        
        /// <summary>
        /// 功能状态
        /// </summary>        
        private bool? _ff_disable;
        public bool? Ff_disable
        {
            get{ return _ff_disable; }
            set{ _ff_disable = value; }
        }        
                
        
   
    }
}

