﻿using System; 

namespace university.Model.CCOM{
         //Transcript
        public class Transcript
    {
                
          /// <summary>
        /// Transcript_id
        /// </summary>        
        private int _transcript_id;
        public int Transcript_id
        {
            get{ return _transcript_id; }
            set{ _transcript_id = value; }
        }        
        /// <summary>
        /// Transcript_AEE_score
        /// </summary>        
        private decimal? _transcript_aee_score;
        public decimal? Transcript_AEE_score
        {
            get{ return _transcript_aee_score; }
            set{ _transcript_aee_score = value; }
        }        
        /// <summary>
        /// Transcript_AEE_sequence
        /// </summary>        
        private decimal? _transcript_aee_sequence;
        public decimal? Transcript_AEE_sequence
        {
            get{ return _transcript_aee_sequence; }
            set{ _transcript_aee_sequence = value; }
        }        
        /// <summary>
        /// Transcript_AEE_ranking
        /// </summary>        
        private int? _transcript_aee_ranking;
        public int? Transcript_AEE_ranking
        {
            get{ return _transcript_aee_ranking; }
            set{ _transcript_aee_ranking = value; }
        }        
        /// <summary>
        /// Transcript_CEE_score
        /// </summary>        
        private decimal? _transcript_cee_score;
        public decimal? Transcript_CEE_score
        {
            get{ return _transcript_cee_score; }
            set{ _transcript_cee_score = value; }
        }        
        /// <summary>
        /// Transcript_CEE_convert_score
        /// </summary>        
        private decimal? _transcript_cee_convert_score;
        public decimal? Transcript_CEE_convert_score
        {
            get{ return _transcript_cee_convert_score; }
            set{ _transcript_cee_convert_score = value; }
        }        
        /// <summary>
        /// Transcript_passline
        /// </summary>        
        private bool? _transcript_passline;
        public bool? Transcript_passline
        {
            get{ return _transcript_passline; }
            set{ _transcript_passline = value; }
        }        
        /// <summary>
        /// Transcript_type
        /// </summary>        
        private int _transcript_type;
        public int Transcript_type
        {
            get{ return _transcript_type; }
            set{ _transcript_type = value; }
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
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// Transcript_score
        /// </summary>        
        private decimal? _transcript_score;
        public decimal? Transcript_score
        {
            get{ return _transcript_score; }
            set{ _transcript_score = value; }
        }        
                
        
   
    }
}
