/**  版本信息模板在安装目录下，可自行修改。
* Teach_week.cs
*
* 功 能： N/A
* 类 名： Teach_week
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/19 20:54:08   N/A    初版
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
	/// Teach_week:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Teach_week
	{
		public Teach_week()
		{}
		#region Model
		private int _teachweek_id;
		private DateTime _start_time;
		private DateTime _end_time;
		private bool _state;
		/// <summary>
		/// 
		/// </summary>
		public int TeachWeek_id
		{
			set{ _teachweek_id=value;}
			get{return _teachweek_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Start_time
		{
			set{ _start_time=value;}
			get{return _start_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime End_time
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

