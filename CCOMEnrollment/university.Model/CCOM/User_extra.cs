using System;

namespace university.Model.CCOM
{
         //User_extra
        public class User_extra
    {
                
          /// <summary>
        /// Ue_id
        /// </summary>        
        private int _ue_id;
        public int Ue_id
        {
            get{ return _ue_id; }
            set{ _ue_id = value; }
        }        
        /// <summary>
        /// 属性名
        /// </summary>        
        private string _Ue_name;
        public string Ue_name
        {
            get{ return _Ue_name; }
            set{ _Ue_name = value; }
        }        
        /// <summary>
        /// 属性类别
        /// </summary>        
        private int _Ue_type;
        public int Ue_type
        {
            get{ return _Ue_type; }
            set{ _Ue_type = value; }
        }        
        /// <summary>
        /// 字段值可否为空  0--可以  1--不可以
        /// </summary>        
        private bool _ue_null;
        public bool Ue_null
        {
            get{ return _ue_null; }
            set{ _ue_null = value; }
        }        
                
        
   
    }
}

