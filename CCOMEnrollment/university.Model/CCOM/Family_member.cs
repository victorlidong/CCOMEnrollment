using System;

namespace university.Model.CCOM
{
         //Family_member
        public class Family_member
    {
                
          /// <summary>
        /// Fm_id
        /// </summary>        
        private long _fm_id;
        public long Fm_id
        {
            get{ return _fm_id; }
            set{ _fm_id = value; }
        }        
        /// <summary>
        /// 家庭成员姓名
        /// </summary>        
        private string _fm_name;
        public string Fm_name
        {
            get{ return _fm_name; }
            set{ _fm_name = value; }
        }        
        /// <summary>
        /// 与用户关系
        /// </summary>        
        private string _fm_relationship;
        public string Fm_relationship
        {
            get{ return _fm_relationship; }
            set{ _fm_relationship = value; }
        }        
        /// <summary>
        /// 工作单位
        /// </summary>        
        private string _fm_company;
        public string Fm_company
        {
            get{ return _fm_company; }
            set{ _fm_company = value; }
        }        
        /// <summary>
        /// 联系方式
        /// </summary>        
        private string _fm_phone;
        public string Fm_phone
        {
            get{ return _fm_phone; }
            set{ _fm_phone = value; }
        }        
        /// <summary>
        /// 政治面貌 链接到外表
        /// </summary>        
        private int _fm_politics;
        public int Fm_politics
        {
            get{ return _fm_politics; }
            set{ _fm_politics = value; }
        }        
        /// <summary>
        /// 用户ID
        /// </summary>        
        private long _user_id;
        public long User_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }        
                
        
   
    }
}

