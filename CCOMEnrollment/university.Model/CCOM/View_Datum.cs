/**  版本信息模板在安装目录下，可自行修改。
* View_Datum.cs
*
* 功 能： N/A
* 类 名： View_Datum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/20 23:52:07   N/A    初版
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
	/// View_Datum:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Datum
	{
		public View_Datum()
		{}
		#region Model
		private long _datum_id;
		private long _student_id;
		private long _tutor_id;
		private long _topic_id;
		private int _accept_state;
		private string _file_path;
		private string _file_name;
		private int _datumtype_id;
		private string _datumtype_name;
		private DateTime _submit_time;
		private string _tutor_advice;
		private int _teachweek_id;
		private DateTime _start_time;
		private DateTime _end_time;
		private bool _state;
		private long _topic_relation_id;
		private int _homework_id;
		/// <summary>
		/// 
		/// </summary>
		public long Datum_id
		{
			set{ _datum_id=value;}
			get{return _datum_id;}
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
		public long Tutor_id
		{
			set{ _tutor_id=value;}
			get{return _tutor_id;}
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
		public int Accept_state
		{
			set{ _accept_state=value;}
			get{return _accept_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string File_path
		{
			set{ _file_path=value;}
			get{return _file_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string File_name
		{
			set{ _file_name=value;}
			get{return _file_name;}
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
		public string DatumType_name
		{
			set{ _datumtype_name=value;}
			get{return _datumtype_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Submit_time
		{
			set{ _submit_time=value;}
			get{return _submit_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_advice
		{
			set{ _tutor_advice=value;}
			get{return _tutor_advice;}
		}
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
		public int Homework_id
		{
			set{ _homework_id=value;}
			get{return _homework_id;}
		}
		#endregion Model

	}
}

