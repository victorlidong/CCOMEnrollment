using System; 

namespace university.Model.CCOM{
         //View_UserAgency
        public class View_UserAgency
    {
                
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
        /// Agency_id
        /// </summary>        
        private int? _agency_id;
        public int? Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
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
        /// User_realname
        /// </summary>        
        private string _user_realname;
        public string User_realname
        {
            get{ return _user_realname; }
            set{ _user_realname = value; }
        }        
        /// <summary>
        /// User_gender
        /// </summary>        
        private bool? _user_gender;
        public bool? User_gender
        {
            get{ return _user_gender; }
            set{ _user_gender = value; }
        }        
        /// <summary>
        /// UP_politics
        /// </summary>        
        private int? _up_politics;
        public int? UP_politics
        {
            get{ return _up_politics; }
            set{ _up_politics = value; }
        }        
        /// <summary>
        /// UP_picture
        /// </summary>        
        private string _up_picture;
        public string UP_picture
        {
            get{ return _up_picture; }
            set{ _up_picture = value; }
        }        
        /// <summary>
        /// UP_CEE_number
        /// </summary>        
        private string _up_cee_number;
        public string UP_CEE_number
        {
            get{ return _up_cee_number; }
            set{ _up_cee_number = value; }
        }        
        /// <summary>
        /// User_number
        /// </summary>        
        private string _User_number;
        public string User_number
        {
            get{ return _User_number; }
            set{ _User_number = value; }
        }        
        /// <summary>
        /// UP_nationality
        /// </summary>        
        private int? _up_nationality;
        public int? UP_nationality
        {
            get{ return _up_nationality; }
            set{ _up_nationality = value; }
        }        
        /// <summary>
        /// User_status
        /// </summary>        
        private bool _user_status;
        public bool User_status
        {
            get{ return _user_status; }
            set{ _user_status = value; }
        }        
        /// <summary>
        /// User_type
        /// </summary>        
        private int? _user_type;
        public int? User_type
        {
            get{ return _user_type; }
            set{ _user_type = value; }
        }        
        /// <summary>
        /// UP_province
        /// </summary>        
        private int? _up_province;
        public int? UP_province
        {
            get{ return _up_province; }
            set{ _up_province = value; }
        }        
        /// <summary>
        /// User_addtime
        /// </summary>        
        private DateTime? _user_addtime;
        public DateTime? User_addtime
        {
            get{ return _user_addtime; }
            set{ _user_addtime = value; }
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
        /// UP_address
        /// </summary>        
        private string _up_address;
        public string UP_address
        {
            get{ return _up_address; }
            set{ _up_address = value; }
        }        
        /// <summary>
        /// UP_receiver
        /// </summary>        
        private string _up_receiver;
        public string UP_receiver
        {
            get{ return _up_receiver; }
            set{ _up_receiver = value; }
        }        
        /// <summary>
        /// UP_receiver_phone
        /// </summary>        
        private string _up_receiver_phone;
        public string UP_receiver_phone
        {
            get{ return _up_receiver_phone; }
            set{ _up_receiver_phone = value; }
        }        
        /// <summary>
        /// UP_postal_code
        /// </summary>        
        private string _up_postal_code;
        public string UP_postal_code
        {
            get{ return _up_postal_code; }
            set{ _up_postal_code = value; }
        }        
        /// <summary>
        /// UP_PE_Aphone
        /// </summary>        
        private string _up_pe_aphone;
        public string UP_PE_Aphone
        {
            get{ return _up_pe_aphone; }
            set{ _up_pe_aphone = value; }
        }        
        /// <summary>
        /// UP_PE_Iphone
        /// </summary>        
        private string _up_pe_iphone;
        public string UP_PE_Iphone
        {
            get{ return _up_pe_iphone; }
            set{ _up_pe_iphone = value; }
        }        
        /// <summary>
        /// UP_AEE_picture
        /// </summary>        
        private string _up_aee_picture;
        public string UP_AEE_picture
        {
            get{ return _up_aee_picture; }
            set{ _up_aee_picture = value; }
        }        
        /// <summary>
        /// UP_AEE_number
        /// </summary>        
        private string _up_aee_number;
        public string UP_AEE_number
        {
            get{ return _up_aee_number; }
            set{ _up_aee_number = value; }
        }        
        /// <summary>
        /// UP_high_school
        /// </summary>        
        private string _up_high_school;
        public string UP_high_school
        {
            get{ return _up_high_school; }
            set{ _up_high_school = value; }
        }        
        /// <summary>
        /// UP_degree
        /// </summary>        
        private int? _up_degree;
        public int? UP_degree
        {
            get{ return _up_degree; }
            set{ _up_degree = value; }
        }        
        /// <summary>
        /// UP_nation
        /// </summary>        
        private int? _up_nation;
        public int? UP_nation
        {
            get{ return _up_nation; }
            set{ _up_nation = value; }
        }        
        /// <summary>
        /// UP_ID_picture
        /// </summary>        
        private string _up_id_picture;
        public string UP_ID_picture
        {
            get{ return _up_id_picture; }
            set{ _up_id_picture = value; }
        }        
                
        
   
    }
}

