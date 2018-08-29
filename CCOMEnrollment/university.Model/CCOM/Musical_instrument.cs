using System;

namespace university.Model.CCOM
{
         //Musical_instrument
        public class Musical_instrument
    {
                
          /// <summary>
        /// Mi_id
        /// </summary>        
        private int _mi_id;
        public int Mi_id
        {
            get{ return _mi_id; }
            set{ _mi_id = value; }
        }        
        /// <summary>
        /// 乐器名称
        /// </summary>        
        private string _mi_name;
        public string Mi_name
        {
            get{ return _mi_name; }
            set{ _mi_name = value; }
        }        
                
        
   
    }
}

