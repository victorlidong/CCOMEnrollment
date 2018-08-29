using System;

namespace university.Model.CCOM
{
         //Nationality
        public class Nationality
    {
                
          /// <summary>
        /// Nationality_id
        /// </summary>        
        private int _nationality_id;
        public int Nationality_id
        {
            get{ return _nationality_id; }
            set{ _nationality_id = value; }
        }        
        /// <summary>
        /// 民族名称
        /// </summary>        
        private string _nationality_name;
        public string Nationality_name
        {
            get{ return _nationality_name; }
            set{ _nationality_name = value; }
        }        
                
        
   
    }
}

