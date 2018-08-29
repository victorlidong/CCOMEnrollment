using System; 

namespace university.Model.CCOM{
         //View_AEE_ManegeSubject
        public class View_AEE_ManegeSubject
    {
                
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
        /// Period_id
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
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
        /// Subject_level
        /// </summary>        
        private int _subject_level;
        public int Subject_level
        {
            get{ return _subject_level; }
            set{ _subject_level = value; }
        }        
        /// <summary>
        /// Major_Agency_id
        /// </summary>        
        private int _major_agency_id;
        public int Major_Agency_id
        {
            get{ return _major_agency_id; }
            set{ _major_agency_id = value; }
        }        
        /// <summary>
        /// Ea_id
        /// </summary>        
        private int _ea_id;
        public int Ea_id
        {
            get{ return _ea_id; }
            set{ _ea_id = value; }
        }        
        /// <summary>
        /// Manage_Agency_id
        /// </summary>        
        private int? _manage_agency_id;
        public int? Manage_Agency_id
        {
            get{ return _manage_agency_id; }
            set{ _manage_agency_id = value; }
        }        
                
        
   
    }
}

