using System; 

namespace university.Model.CCOM{
         //Examination_subject_score
        public class Examination_subject_score
    {
                
          /// <summary>
        /// Ess_id
        /// </summary>        
        private long _ess_id;
        public long Ess_id
        {
            get{ return _ess_id; }
            set{ _ess_id = value; }
        }        
        /// <summary>
        /// 科目ID -- FK
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
        }        
        /// <summary>
        /// Ess_score
        /// </summary>        
        private decimal _ess_score;
        public decimal Ess_score
        {
            get{ return _ess_score; }
            set{ _ess_score = value; }
        }        
        /// <summary>
        /// Ess_sequence
        /// </summary>        
        private int? _ess_sequence;
        public int? Ess_sequence
        {
            get{ return _ess_sequence; }
            set{ _ess_sequence = value; }
        }        
        /// <summary>
        /// Judge_id
        /// </summary>        
        private int _judge_id;
        public int Judge_id
        {
            get{ return _judge_id; }
            set{ _judge_id = value; }
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
        /// 0-舍去 1-保留求平均
        /// </summary>        
        private bool? _ess_score_status;
        public bool? Ess_score_status
        {
            get{ return _ess_score_status; }
            set{ _ess_score_status = value; }
        }        
        /// <summary>
        /// 序状态
        /// </summary>        
        private bool? _ess_order_status;
        public bool? Ess_order_status
        {
            get{ return _ess_order_status; }
            set{ _ess_order_status = value; }
        }        
                
        
   
    }
}

