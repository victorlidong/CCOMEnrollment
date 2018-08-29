using System; 

namespace university.Model.CCOM{
         //View_Major_Preliminary
        public class View_Major_Preliminary
    {
                
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
        /// Subject_weight
        /// </summary>        
        private decimal? _subject_weight;
        public decimal? Subject_weight
        {
            get{ return _subject_weight; }
            set{ _subject_weight = value; }
        }        
        /// <summary>
        /// Agency_id
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
        }        
        /// <summary>
        /// Fs_id
        /// </summary>        
        private int _fs_id;
        public int Fs_id
        {
            get{ return _fs_id; }
            set{ _fs_id = value; }
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
        /// Period_id
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
        }        
                
        
   
    }
}

