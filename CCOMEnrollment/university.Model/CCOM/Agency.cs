using System; 

namespace university.Model.CCOM{
         //机构表
        public class Agency
    {
                
          /// <summary>
        /// Agency_id
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
        }        
        /// <summary>
        /// 机构名称
        /// </summary>        
        private string _agency_name;
        public string Agency_name
        {
            get{ return _agency_name; }
            set{ _agency_name = value; }
        }        
        /// <summary>
        /// 父机构id
        /// </summary>        
        private int _agency_father;
        public int Agency_father
        {
            get{ return _agency_father; }
            set{ _agency_father = value; }
        }        
        /// <summary>
        /// 机构类别
        /// </summary>        
        private int _agency_type;
        public int Agency_type
        {
            get{ return _agency_type; }
            set{ _agency_type = value; }
        }        
        /// <summary>
        /// 机构状态  0-弃用 1-启用
        /// </summary>        
        private bool _agency_status;
        public bool Agency_status
        {
            get{ return _agency_status; }
            set{ _agency_status = value; }
        }        
                
        
   
    }
}

