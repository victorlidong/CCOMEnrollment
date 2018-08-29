using System;

namespace university.Model.CCOM
{
         //Examination_subject_item
        public class Examination_subject_item
    {
                
          /// <summary>
        /// Esi_id
        /// </summary>        
        private int _esi_id;
        public int Esi_id
        {
            get{ return _esi_id; }
            set{ _esi_id = value; }
        }        
        /// <summary>
        /// 科目属id性类型  1-单行文本 2-多行文本 3-	单选 4-下拉菜单 5-复选 6-不填  
        /// </summary>        
        private int _esi_type;
        public int Esi_type
        {
            get{ return _esi_type; }
            set{ _esi_type = value; }
        }        
        /// <summary>
        /// 科目属性选项/提示
        /// </summary>        
        private string _esi_text;
        public string Esi_text
        {
            get{ return _esi_text; }
            set{ _esi_text = value; }
        }        
        /// <summary>
        /// 科目属性备注
        /// </summary>        
        private string _esi_remark;
        public string Esi_remark
        {
            get{ return _esi_remark; }
            set{ _esi_remark = value; }
        }        
        /// <summary>
        /// 科目id  -- 考试科目表
        /// </summary>        
        private int _esn_id;
        public int Esn_id
        {
            get{ return _esn_id; }
            set{ _esn_id = value; }
        }        
                
        
   
    }
}

