using System; 

namespace university.Model.CCOM{
         //Degree
        public class Degree
    {
                
          /// <summary>
        /// Degree_id
        /// </summary>        
        private int _degree_id;
        public int Degree_id
        {
            get{ return _degree_id; }
            set{ _degree_id = value; }
        }        
        /// <summary>
        /// 学历名称
        /// </summary>        
        private string _degree_name;
        public string Degree_name
        {
            get{ return _degree_name; }
            set{ _degree_name = value; }
        }        
                
        
   
    }
}

