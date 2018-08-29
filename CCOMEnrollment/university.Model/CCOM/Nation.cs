using System;

namespace university.Model.CCOM
{
         //Nation
        public class Nation
    {
                
          /// <summary>
        /// Nation_id
        /// </summary>        
        private int _nation_id;
        public int Nation_id
        {
            get{ return _nation_id; }
            set{ _nation_id = value; }
        }        
        /// <summary>
        /// 国家名称
        /// </summary>        
        private string _nation_name;
        public string Nation_name
        {
            get{ return _nation_name; }
            set{ _nation_name = value; }
        }        
                
        
   
    }
}

