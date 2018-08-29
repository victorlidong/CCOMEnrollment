using System; 

namespace university.Model.CCOM{
         //证件类型表
        public class Certificate_type
    {
                
          /// <summary>
        /// Ct_id
        /// </summary>        
        private int _ct_id;
        public int Ct_id
        {
            get{ return _ct_id; }
            set{ _ct_id = value; }
        }        
        /// <summary>
        /// 证件名称
        /// </summary>        
        private string _ct_name;
        public string Ct_name
        {
            get{ return _ct_name; }
            set{ _ct_name = value; }
        }        
                
        
   
    }
}

