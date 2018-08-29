using System; 

namespace university.Model.CCOM{
         //View_FirstIn_Score
        public class View_FirstIn_Score
    {
                
          /// <summary>
        /// UP_CCOM_number
        /// </summary>        
        private string _up_ccom_number;
        public string UP_CCOM_number
        {
            get{ return _up_ccom_number; }
            set{ _up_ccom_number = value; }
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
        /// User_realname
        /// </summary>        
        private string _user_realname;
        public string User_realname
        {
            get{ return _user_realname; }
            set{ _user_realname = value; }
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
        /// Subject_id
        /// </summary>        
        private int _subject_id;
        public int Subject_id
        {
            get{ return _subject_id; }
            set{ _subject_id = value; }
        }        
        /// <summary>
        /// Subject_title
        /// </summary>        
        private string _subject_title;
        public string Subject_title
        {
            get{ return _subject_title; }
            set{ _subject_title = value; }
        }        
        /// <summary>
        /// Major_id
        /// </summary>        
        private int _major_id;
        public int Major_id
        {
            get{ return _major_id; }
            set{ _major_id = value; }
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
        /// <summary>
        /// UP_calculation_status
        /// </summary>        
        private int? _up_calculation_status;
        public int? UP_calculation_status
        {
            get{ return _up_calculation_status; }
            set{ _up_calculation_status = value; }
        }        
                
        
   
    }
}

