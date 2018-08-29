using System; 

namespace university.Model.CCOM{
         //User_property
        public class User_property
    {
                
          /// <summary>
        /// UP_id
        /// </summary>        
        private long _up_id;
        public long UP_id
        {
            get{ return _up_id; }
            set{ _up_id = value; }
        }        
        /// <summary>
        /// 证件复印件 (A4纸单面打印上传， 不超过300K)
        /// </summary>        
        private string _up_id_picture;
        public string UP_ID_picture
        {
            get{ return _up_id_picture; }
            set{ _up_id_picture = value; }
        }        
        /// <summary>
        /// 近期免冠照片  蓝底，1寸大小（像素比例）
        /// </summary>        
        private string _up_picture;
        public string UP_picture
        {
            get{ return _up_picture; }
            set{ _up_picture = value; }
        }        
        /// <summary>
        /// 国籍
        /// </summary>        
        private int _up_nation;
        public int UP_nation
        {
            get{ return _up_nation; }
            set{ _up_nation = value; }
        }        
        /// <summary>
        /// 民族
        /// </summary>        
        private int _up_nationality;
        public int UP_nationality
        {
            get{ return _up_nationality; }
            set{ _up_nationality = value; }
        }        
        /// <summary>
        /// 政治面貌
        /// </summary>        
        private int _up_politics;
        public int UP_politics
        {
            get{ return _up_politics; }
            set{ _up_politics = value; }
        }        
        /// <summary>
        /// 文化程度
        /// </summary>        
        private int _up_degree;
        public int UP_degree
        {
            get{ return _up_degree; }
            set{ _up_degree = value; }
        }        
        /// <summary>
        /// 高中毕业院校
        /// </summary>        
        private string _up_high_school;
        public string UP_high_school
        {
            get{ return _up_high_school; }
            set{ _up_high_school = value; }
        }        
        /// <summary>
        /// 高考报名号
        /// </summary>        
        private string _up_cee_number;
        public string UP_CEE_number
        {
            get{ return _up_cee_number; }
            set{ _up_cee_number = value; }
        }        
        /// <summary>
        /// 省艺术联考考生号
        /// </summary>        
        private string _up_aee_number;
        public string UP_AEE_number
        {
            get{ return _up_aee_number; }
            set{ _up_aee_number = value; }
        }        
        /// <summary>
        /// 省联考合格证
        /// </summary>        
        private string _up_aee_picture;
        public string UP_AEE_picture
        {
            get{ return _up_aee_picture; }
            set{ _up_aee_picture = value; }
        }        
        /// <summary>
        /// 专业考试期间移动电话
        /// </summary>        
        private string _up_pe_iphone;
        public string UP_PE_Iphone
        {
            get{ return _up_pe_iphone; }
            set{ _up_pe_iphone = value; }
        }        
        /// <summary>
        /// 常规移动电话
        /// </summary>        
        private string _up_pe_aphone;
        public string UP_PE_Aphone
        {
            get{ return _up_pe_aphone; }
            set{ _up_pe_aphone = value; }
        }        
        /// <summary>
        /// 高考所在地
        /// </summary>        
        private int _up_province;
        public int UP_province
        {
            get{ return _up_province; }
            set{ _up_province = value; }
        }        
        /// <summary>
        /// 录取通知书邮寄地址
        /// </summary>        
        private string _up_address;
        public string UP_address
        {
            get{ return _up_address; }
            set{ _up_address = value; }
        }        
        /// <summary>
        /// 收件人
        /// </summary>        
        private string _up_receiver;
        public string UP_receiver
        {
            get{ return _up_receiver; }
            set{ _up_receiver = value; }
        }        
        /// <summary>
        /// 收件人联系电话
        /// </summary>        
        private string _up_receiver_phone;
        public string UP_receiver_phone
        {
            get{ return _up_receiver_phone; }
            set{ _up_receiver_phone = value; }
        }        
        /// <summary>
        /// 邮编
        /// </summary>        
        private string _up_postal_code;
        public string UP_postal_code
        {
            get{ return _up_postal_code; }
            set{ _up_postal_code = value; }
        }        
        /// <summary>
        /// 用户ID  -- 用户表
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
        /// <summary>
        /// 专业ID  -- 机构表
        /// </summary>        
        private int _agency_id;
        public int Agency_id
        {
            get{ return _agency_id; }
            set{ _agency_id = value; }
        }        
        /// <summary>
        /// 所属周期  --  周期表
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
        }        
        /// <summary>
        /// 中央音乐学院生成考生号
        /// </summary>        
        private string _up_ccom_number;
        public string UP_CCOM_number
        {
            get{ return _up_ccom_number; }
            set{ _up_ccom_number = value; }
        }        
        /// <summary>
        /// 0-未报名 1-报名缴费成功 2-进入初试二轮 3-进入复试 4-进入文考（高考） 5-录取
        /// </summary>        
        private int _up_calculation_status;
        public int UP_calculation_status
        {
            get{ return _up_calculation_status; }
            set{ _up_calculation_status = value; }
        }        
        /// <summary>
        /// UP_overseas
        /// </summary>        
        private bool _up_overseas;
        public bool UP_overseas
        {
            get{ return _up_overseas; }
            set{ _up_overseas = value; }
        }        
                
        
   
    }
}

