using System; 

namespace university.Model.CCOM{
         //Examination_arrangement
        public class Examination_arrangement
    {
                
          /// <summary>
        /// Ea_id
        /// </summary>        
        private int _ea_id;
        public int Ea_id
        {
            get{ return _ea_id; }
            set{ _ea_id = value; }
        }        
        /// <summary>
        /// 排考名称
        /// </summary>        
        private string _ea_name;
        public string Ea_name
        {
            get{ return _ea_name; }
            set{ _ea_name = value; }
        }        
        /// <summary>
        /// 开始时间
        /// </summary>        
        private DateTime _ea_starttime;
        public DateTime Ea_starttime
        {
            get{ return _ea_starttime; }
            set{ _ea_starttime = value; }
        }        
        /// <summary>
        /// 结束时间
        /// </summary>        
        private DateTime? _ea_endtime;
        public DateTime? Ea_endtime
        {
            get{ return _ea_endtime; }
            set{ _ea_endtime = value; }
        }        
        /// <summary>
        /// 考场ID FK
        /// </summary>        
        private int _ea_room;
        public int Ea_room
        {
            get{ return _ea_room; }
            set{ _ea_room = value; }
        }        
        /// <summary>
        /// 候考场ID FK
        /// </summary>        
        private int? _ea_restroom;
        public int? Ea_restroom
        {
            get{ return _ea_restroom; }
            set{ _ea_restroom = value; }
        }        
                
        
   
    }
}

