using System; 

namespace university.Model.CCOM{
         //Fractional_line
        public class Fractional_line
    {
                
          /// <summary>
        /// Fl_id
        /// </summary>        
        private int _fl_id;
        public int Fl_id
        {
            get{ return _fl_id; }
            set{ _fl_id = value; }
        }        
        /// <summary>
        /// 省份 FK
        /// </summary>        
        private int _fl_province;
        public int Fl_Province
        {
            get{ return _fl_province; }
            set{ _fl_province = value; }
        }        
        /// <summary>
        /// 文科一本
        /// </summary>        
        private decimal? _wenkeyiben;
        public decimal? WenKeYiBen
        {
            get{ return _wenkeyiben; }
            set{ _wenkeyiben = value; }
        }        
        /// <summary>
        /// 理科一本
        /// </summary>        
        private decimal? _likeyiben;
        public decimal? LiKeYiBen
        {
            get{ return _likeyiben; }
            set{ _likeyiben = value; }
        }        
        /// <summary>
        /// 文科二本
        /// </summary>        
        private decimal? _wenkeerben;
        public decimal? WenKeErBen
        {
            get{ return _wenkeerben; }
            set{ _wenkeerben = value; }
        }        
        /// <summary>
        /// 理科二本
        /// </summary>        
        private decimal? _likeerben;
        public decimal? LiKeErBen
        {
            get{ return _likeerben; }
            set{ _likeerben = value; }
        }        
        /// <summary>
        /// 文科三本
        /// </summary>        
        private decimal? _wenkesanben;
        public decimal? WenKeSanBen
        {
            get{ return _wenkesanben; }
            set{ _wenkesanben = value; }
        }        
        /// <summary>
        /// 理科三本
        /// </summary>        
        private decimal? _likesanben;
        public decimal? LiKeSanBen
        {
            get{ return _likesanben; }
            set{ _likesanben = value; }
        }        
        /// <summary>
        /// 文科艺术线
        /// </summary>        
        private decimal? _wenkeyishuxian;
        public decimal? WenKeYiShuXian
        {
            get{ return _wenkeyishuxian; }
            set{ _wenkeyishuxian = value; }
        }        
        /// <summary>
        /// 理科艺术线
        /// </summary>        
        private decimal? _likeyishuxian;
        public decimal? LiKeYiShuXian
        {
            get{ return _likeyishuxian; }
            set{ _likeyishuxian = value; }
        }        
        /// <summary>
        /// 文科总分
        /// </summary>        
        private decimal? _wenkezongfen;
        public decimal? WenKeZongFen
        {
            get{ return _wenkezongfen; }
            set{ _wenkezongfen = value; }
        }        
        /// <summary>
        /// 理科总分
        /// </summary>        
        private decimal? _likezongfen;
        public decimal? LiKeZongFen
        {
            get{ return _likezongfen; }
            set{ _likezongfen = value; }
        }        
        /// <summary>
        /// 周期 FK
        /// </summary>        
        private int _period_id;
        public int Period_id
        {
            get{ return _period_id; }
            set{ _period_id = value; }
        }        
        /// <summary>
        /// 添加时间
        /// </summary>        
        private DateTime _fl_addtime;
        public DateTime Fl_addtime
        {
            get{ return _fl_addtime; }
            set{ _fl_addtime = value; }
        }        
                
        
   
    }
}

