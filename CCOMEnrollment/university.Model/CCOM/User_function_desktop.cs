using System; 

namespace university.Model.CCOM{
         //User_function_desktop
        public class User_function_desktop
    {
                
          /// <summary>
        /// Ufd_id
        /// </summary>        
        private int _ufd_id;
        public int Ufd_id
        {
            get{ return _ufd_id; }
            set{ _ufd_id = value; }
        }        
        /// <summary>
        /// 应用类型 1-普通功能  2-办公功能
        /// </summary>        
        private int _ufd_type;
        public int Ufd_type
        {
            get{ return _ufd_type; }
            set{ _ufd_type = value; }
        }        
        /// <summary>
        /// 功能ID  FK
        /// </summary>        
        private int? _sf_id;
        public int? Sf_id
        {
            get{ return _sf_id; }
            set{ _sf_id = value; }
        }        
        /// <summary>
        /// 应用排序
        /// </summary>        
        private int? _ufd_sort;
        public int? Ufd_sort
        {
            get{ return _ufd_sort; }
            set{ _ufd_sort = value; }
        }        
        /// <summary>
        /// 应用名称
        /// </summary>        
        private string _ufd_name;
        public string Ufd_name
        {
            get{ return _ufd_name; }
            set{ _ufd_name = value; }
        }        
        /// <summary>
        /// 应用显示名称
        /// </summary>        
        private string _ufd_showname;
        public string Ufd_showname
        {
            get{ return _ufd_showname; }
            set{ _ufd_showname = value; }
        }        
        /// <summary>
        /// 应用显示图标
        /// </summary>        
        private string _ufd_icon;
        public string Ufd_icon
        {
            get{ return _ufd_icon; }
            set{ _ufd_icon = value; }
        }        
        /// <summary>
        /// 应用显示宽度
        /// </summary>        
        private string _ufd_width;
        public string Ufd_width
        {
            get{ return _ufd_width; }
            set{ _ufd_width = value; }
        }        
        /// <summary>
        /// 应用显示颜色
        /// </summary>        
        private string _ufd_color;
        public string Ufd_color
        {
            get{ return _ufd_color; }
            set{ _ufd_color = value; }
        }        
        /// <summary>
        /// 应用备注
        /// </summary>        
        private string _ufd_remark;
        public string Ufd_remark
        {
            get{ return _ufd_remark; }
            set{ _ufd_remark = value; }
        }        
                
        
   
    }
}

