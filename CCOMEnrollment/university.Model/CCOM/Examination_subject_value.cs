using System;

namespace university.Model.CCOM
{
         //Examination_subject_value
        public class Examination_subject_value
    {
                
          /// <summary>
        /// Esv_id
        /// </summary>        
        private long _esv_id;
        public long Esv_id
        {
            get{ return _esv_id; }
            set{ _esv_id = value; }
        }        
        /// <summary>
        /// 科目记录ID -- 用户科目填报记录表
        /// </summary>        
        private long _usr_id;
        public long Usr_id
        {
            get{ return _usr_id; }
            set{ _usr_id = value; }
        }        
        /// <summary>
        /// 科目填报值
        /// </summary>        
        private string _esv_value;
        public string Esv_value
        {
            get{ return _esv_value; }
            set{ _esv_value = value; }
        }        
                
        
   
    }
}

