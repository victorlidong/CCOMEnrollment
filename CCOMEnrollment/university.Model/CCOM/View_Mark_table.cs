/**  版本信息模板在安装目录下，可自行修改。
* View_Mark_table.cs
*
* 功 能： N/A
* 类 名： View_Mark_table
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/20 17:36:05   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace university.Model.CCOM
{
	/// <summary>
	/// View_Mark_table:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Mark_table
	{
		public View_Mark_table()
		{}
		#region Model
		private long _mark_table_id;
		private long _rs_id;
		private long _rc_id;
		private int? _score;
		private DateTime _mark_date;
		private long _student_id;
		private long _teacher_id;
		/// <summary>
		/// 
		/// </summary>
		public long Mark_table_id
		{
			set{ _mark_table_id=value;}
			get{return _mark_table_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Rs_id
		{
			set{ _rs_id=value;}
			get{return _rs_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Rc_id
		{
			set{ _rc_id=value;}
			get{return _rc_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Mark_date
		{
			set{ _mark_date=value;}
			get{return _mark_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Student_id
		{
			set{ _student_id=value;}
			get{return _student_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		#endregion Model

	}
}

