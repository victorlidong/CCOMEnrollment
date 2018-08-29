using System;

namespace university.Model.CCOM
{
         //User_extra_value
        public class User_extra_value
    {
                
          /// <summary>
        /// Uev_id
        /// </summary>        
        private long _Uev_id;
        public long Uev_id
        {
            get{ return _Uev_id; }
            set{ _Uev_id = value; }
        }        
        /// <summary>
        /// Ue_id
        /// </summary>        
        private int _Ue_id;
        public int Ue_id
        {
            get{ return _Ue_id; }
            set{ _Ue_id = value; }
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
        /// Uev_value
        /// </summary>        
        private string _Uev_value;
        public string Uev_value
        {
            get{ return _Uev_value; }
            set{ _Uev_value = value; }
        }        
                
        
   
    }
}

