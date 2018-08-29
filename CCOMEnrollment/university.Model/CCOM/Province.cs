using System;

namespace university.Model.CCOM
{
         //Province
        public class Province
    {
                
          /// <summary>
        /// Province_id
        /// </summary>        
        private int _province_id;
        public int Province_id
        {
            get{ return _province_id; }
            set{ _province_id = value; }
        }        
        /// <summary>
        /// 省级行政区名称
        /// </summary>        
        private string _province_name;
        public string Province_name
        {
            get{ return _province_name; }
            set{ _province_name = value; }
        }        
                
        
   
    }
}

