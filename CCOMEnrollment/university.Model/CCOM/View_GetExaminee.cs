using System; 

namespace university.Model.CCOM{
         //View_GetExaminee
        public class View_GetExaminee
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
        /// Agency_id
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
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
        /// Agency_name
        /// </summary>        
        private string _agency_name;
        public string Agency_name
        {
            get{ return _agency_name; }
            set{ _agency_name = value; }
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

