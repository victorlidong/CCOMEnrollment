using System; 

namespace university.Model.CCOM{
         //Exam_preliminary_subject_score
        public class Exam_preliminary_subject_score
    {
                
          /// <summary>
        /// Epss
        /// </summary>        
        private int _epss;
        public int Epss
        {
            get{ return _epss; }
            set{ _epss = value; }
        }        
        /// <summary>
        /// Eps_id
        /// </summary>        
        private int _eps_id;
        public int Eps_id
        {
            get{ return _eps_id; }
            set{ _eps_id = value; }
        }        
        /// <summary>
        /// User_id
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// Epss_score
        /// </summary>        
        private decimal? _epss_score;
        public decimal? Epss_score
        {
            get{ return _epss_score; }
            set{ _epss_score = value; }
        }        
        /// <summary>
        /// Epss_sequence
        /// </summary>        
        private decimal? _epss_sequence;
        public decimal? Epss_sequence
        {
            get{ return _epss_sequence; }
            set{ _epss_sequence = value; }
        }        
                
        
   
    }
}

