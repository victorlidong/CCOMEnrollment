/**  版本信息模板在安装目录下，可自行修改。
* View_Selete_Topic.cs
*
* 功 能： N/A
* 类 名： View_Selete_Topic
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/25 20:17:00   N/A    初版
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
	/// View_Selete_Topic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Selete_Topic
	{
		public View_Selete_Topic()
		{}
		#region Model
		private long _topic_relation_id;
		private long _student_id;
		private string _user_number;
		private string _student_name;
		private long _teacher_id;
		private string _teacher_name;
		private long _topic_id;
		private string _topic_name;
		private string _topic_nature;
		private string _topic_source;
		private int _check_state;
		private int _accept_state;
		private bool _selected_state;
		private DateTime _apply_time;
		private string _company;
		private string _topic_content;
		private string _topic_task;
		private int _period_id;
		private string _advice;
		/// <summary>
		/// 
		/// </summary>
		public long Topic_relation_id
		{
			set{ _topic_relation_id=value;}
			get{return _topic_relation_id;}
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
		public string User_number
		{
			set{ _user_number=value;}
			get{return _user_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Student_name
		{
			set{ _student_name=value;}
			get{return _student_name;}
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
		public string Teacher_name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Topic_id
		{
			set{ _topic_id=value;}
			get{return _topic_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic_name
		{
			set{ _topic_name=value;}
			get{return _topic_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic_nature
		{
			set{ _topic_nature=value;}
			get{return _topic_nature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic_source
		{
			set{ _topic_source=value;}
			get{return _topic_source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Check_state
		{
			set{ _check_state=value;}
			get{return _check_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Accept_state
		{
			set{ _accept_state=value;}
			get{return _accept_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Selected_state
		{
			set{ _selected_state=value;}
			get{return _selected_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Apply_time
		{
			set{ _apply_time=value;}
			get{return _apply_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic_content
		{
			set{ _topic_content=value;}
			get{return _topic_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic_task
		{
			set{ _topic_task=value;}
			get{return _topic_task;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Period_id
		{
			set{ _period_id=value;}
			get{return _period_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string advice
		{
			set{ _advice=value;}
			get{return _advice;}
		}
		#endregion Model

	}
}

