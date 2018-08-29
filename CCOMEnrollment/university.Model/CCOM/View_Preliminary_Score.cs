using System; 

namespace university.Model.CCOM{
         //View_Preliminary_Score
        public class View_Preliminary_Score
    {
                
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
        /// UP_CCOM_number
        /// </summary>        
        private string _up_ccom_number;
        public string UP_CCOM_number
        {
            get{ return _up_ccom_number; }
            set{ _up_ccom_number = value; }
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
        /// User_realname
        /// </summary>        
        private string _user_realname;
        public string User_realname
        {
            get{ return _user_realname; }
            set{ _user_realname = value; }
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
        /// Subject_id
        /// </summary>        
        private int _subject_id;
        public int Subject_id
        {
            get{ return _subject_id; }
            set{ _subject_id = value; }
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

