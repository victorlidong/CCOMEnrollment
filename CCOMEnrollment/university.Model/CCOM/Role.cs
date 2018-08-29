using System; 

namespace university.Model.CCOM{
         //Role
        public class Role
    {
                
          /// <summary>
        /// Role_id
        /// </summary>        
        private int _role_id;
        public int Role_id
        {
            get{ return _role_id; }
            set{ _role_id = value; }
        }        
        /// <summary>
        /// 用户组名
        /// </summary>        
        private string _role_name;
        public string Role_name
        {
            get{ return _role_name; }
            set{ _role_name = value; }
        }        
        /// <summary>
        /// 用户组状态
        /// </summary>        
        private bool _role_status;
        public bool Role_status
        {
            get{ return _role_status; }
            set{ _role_status = value; }
        }        
                
        
   
    }
}

