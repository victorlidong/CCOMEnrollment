using System; 

namespace university.Model.CCOM{
         //Role_permission
        public class Role_permission
    {
                
          /// <summary>
        /// Rp_id
        /// </summary>        
        private int _rp_id;
        public int Rp_id
        {
            get{ return _rp_id; }
            set{ _rp_id = value; }
        }        
        /// <summary>
        /// Sf_id
        /// </summary>        
        private int _role_id;
        public int Role_id
        {
            get{ return _role_id; }
            set{ _role_id = value; }
        }        
        /// <summary>
        /// 子功能ID
        /// </summary>        
        private int _sf_id;
        public int Sf_id
        {
            get{ return _sf_id; }
            set{ _sf_id = value; }
        }        
                
        
   
    }
}

