using System;

namespace university.Model.CCOM
{
         //Examination_room
        public class Examination_room
    {
                
          /// <summary>
        /// Er_id
        /// </summary>        
        private int _er_id;
        public int Er_id
        {
            get{ return _er_id; }
            set{ _er_id = value; }
        }        
        /// <summary>
        /// 考场所在楼
        /// </summary>        
        private string _er_building;
        public string Er_building
        {
            get{ return _er_building; }
            set{ _er_building = value; }
        }        
        /// <summary>
        /// 考场所在楼层
        /// </summary>        
        private int _er_floor;
        public int Er_floor
        {
            get{ return _er_floor; }
            set{ _er_floor = value; }
        }        
        /// <summary>
        /// 考场房间号
        /// </summary>        
        private string _er_room;
        public string Er_room
        {
            get{ return _er_room; }
            set{ _er_room = value; }
        }        
        /// <summary>
        /// 考场容量
        /// </summary>        
        private int _er_capacity;
        public int Er_capacity
        {
            get{ return _er_capacity; }
            set{ _er_capacity = value; }
        }        
        /// <summary>
        /// 备注
        /// </summary>        
        private string _er_remark;
        public string Er_remark
        {
            get{ return _er_remark; }
            set{ _er_remark = value; }
        }        
                
        
   
    }
}

