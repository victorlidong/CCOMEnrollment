using System; 

namespace university.Model.CCOM{
         //Examination_AEE_score
        public class Examination_AEE_score
    {
                
          /// <summary>
        /// AEE_id
        /// </summary>        
        private int _aee_id;
        public int AEE_id
        {
            get{ return _aee_id; }
            set{ _aee_id = value; }
        }        
        /// <summary>
        /// AEE_score
        /// </summary>        
        private decimal _aee_score;
        public decimal AEE_score
        {
            get{ return _aee_score; }
            set{ _aee_score = value; }
        }        
        /// <summary>
        /// AEE_sequence
        /// </summary>        
        private decimal? _aee_sequence;
        public decimal? AEE_sequence
        {
            get{ return _aee_sequence; }
            set{ _aee_sequence = value; }
        }        
        /// <summary>
        /// AEE_ranking
        /// </summary>        
        private int? _aee_ranking;
        public int? AEE_ranking
        {
            get{ return _aee_ranking; }
            set{ _aee_ranking = value; }
        }        
        /// <summary>
        /// Period_id
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
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
                
        
   
    }
}

