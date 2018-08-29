using System; 

namespace university.Model.CCOM{
         //Examination_subject_average_score
        public class Examination_subject_average_score
    {
                
          /// <summary>
        /// Esas_id
        /// </summary>        
        private int _esas_id;
        public int Esas_id
        {
            get{ return _esas_id; }
            set{ _esas_id = value; }
        }        
        /// <summary>
        /// 科目ID FK
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
        }        
        /// <summary>
        /// Esas_score
        /// </summary>        
        private decimal _esas_score;
        public decimal Esas_score
        {
            get{ return _esas_score; }
            set{ _esas_score = value; }
        }        
        /// <summary>
        /// Esas_sequence
        /// </summary>        
        private decimal? _esas_sequence;
        public decimal? Esas_sequence
        {
            get{ return _esas_sequence; }
            set{ _esas_sequence = value; }
        }        
        /// <summary>
        /// 用户ID FK
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
                
        
   
    }
}

