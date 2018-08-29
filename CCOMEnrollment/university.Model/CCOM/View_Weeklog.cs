/**  版本信息模板在安装目录下，可自行修改。
* View_Weeklog.cs
*
* 功 能： N/A
* 类 名： View_Weeklog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/24 20:20:01   N/A    初版
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
	/// View_Weeklog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Weeklog
	{
		public View_Weeklog()
		{}
		#region Model
		private int _teachweek_id;
		private long _teacher_id;
		private int _datumtype_id;
		private long _student_id;
		private int _homework_id;
		private long _weeklog_id;
		private string _user_realname;
		private string _datumtype_name;
		private long _topic_relation_id;
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
		public long Teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DatumType_id
		{
			set{ _datumtype_id=value;}
			get{return _datumtype_id;}
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
		public int Homework_id
		{
			set{ _homework_id=value;}
			get{return _homework_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Weeklog_id
		{
			set{ _weeklog_id=value;}
			get{return _weeklog_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_realname
		{
			set{ _user_realname=value;}
			get{return _user_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DatumType_name
		{
			set{ _datumtype_name=value;}
			get{return _datumtype_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Topic_relation_id
		{
			set{ _topic_relation_id=value;}
			get{return _topic_relation_id;}
		}
		#endregion Model

	}
}

