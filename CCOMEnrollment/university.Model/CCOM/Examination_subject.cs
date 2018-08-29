using System; 

namespace university.Model.CCOM{
         //Examination_subject
        public class Examination_subject
    {
                
          /// <summary>
        /// Es_id
        /// </summary>        
        private int _es_id;
        public int Es_id
        {
            get{ return _es_id; }
            set{ _es_id = value; }
        }        
        /// <summary>
        /// 排考id FK
        /// </summary>        
        private int _ea_id;
        public int Ea_id
        {
            get{ return _ea_id; }
            set{ _ea_id = value; }
        }        
        /// <summary>
        /// 科目id FK
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
        }        
                
        
   
    }
}

