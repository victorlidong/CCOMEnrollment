using System; 

namespace university.Model.CCOM{
         //Temp_record
        public class Temp_record
    {
                
          /// <summary>
        /// Record_id
        /// </summary>        
        private long _record_id;
        public long Record_id
        {
            get{ return _record_id; }
            set{ _record_id = value; }
        }        
        /// <summary>
        /// Period_year
        /// </summary>        
        private string _period_year;
        public string Period_year
        {
            get{ return _period_year; }
            set{ _period_year = value; }
        }        
        /// <summary>
        /// Last_CCOM_number
        /// </summary>        
        private string _last_ccom_number;
        public string Last_CCOM_number
        {
            get{ return _last_ccom_number; }
            set{ _last_ccom_number = value; }
        }        
                
        
   
    }
}

