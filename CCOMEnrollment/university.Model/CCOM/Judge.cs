using System;

namespace university.Model.CCOM
{
         //Judge
        public class Judge
    {
                
          /// <summary>
        /// Judge_id
        /// </summary>        
        private int _judge_id;
        public int Judge_id
        {
            get{ return _judge_id; }
            set{ _judge_id = value; }
        }        
        /// <summary>
        /// 评委姓名
        /// </summary>        
        private string _judge_name;
        public string Judge_name
        {
            get{ return _judge_name; }
            set{ _judge_name = value; }
        }        
        /// <summary>
        /// 教工号
        /// </summary>        
        private string _judge_staff_number;
        public string Judge_staff_number
        {
            get{ return _judge_staff_number; }
            set{ _judge_staff_number = value; }
        }        
        /// <summary>
        /// 所属部门
        /// </summary>        
        private string _judge_department;
        public string Judge_department
        {
            get{ return _judge_department; }
            set{ _judge_department = value; }
        }        
        /// <summary>
        /// 评委职称
        /// </summary>        
        private string _judge_title;
        public string Judge_title
        {
            get{ return _judge_title; }
            set{ _judge_title = value; }
        }        
                
        
   
    }
}

