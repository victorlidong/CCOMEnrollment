using System; 

namespace university.Model.CCOM{
         //Exam_firstin_subject_score
        public class Exam_firstin_subject_score
    {
                
          /// <summary>
        /// Efss_id
        /// </summary>        
        private int _efss_id;
        public int Efss_id
        {
            get{ return _efss_id; }
            set{ _efss_id = value; }
        }        
        /// <summary>
        /// Efs_id
        /// </summary>        
        private int _efs_id;
        public int Efs_id
        {
            get{ return _efs_id; }
            set{ _efs_id = value; }
        }        
        /// <summary>
        /// User_id
        /// </summary>        
        private long? _user_id;
        public long? User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// Efss_score
        /// </summary>        
        private decimal? _efss_score;
        public decimal? Efss_score
        {
            get{ return _efss_score; }
            set{ _efss_score = value; }
        }        
        /// <summary>
        /// Efss_sequence
        /// </summary>        
        private decimal? _efss_sequence;
        public decimal? Efss_sequence
        {
            get{ return _efss_sequence; }
            set{ _efss_sequence = value; }
        }        
                
        
   
    }
}

