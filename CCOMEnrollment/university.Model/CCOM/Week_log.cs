/**  版本信息模板在安装目录下，可自行修改。
* Week_log.cs
*
* 功 能： N/A
* 类 名： Week_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/21 21:45:08   N/A    初版
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
	/// 报名周期表
	/// </summary>
	[Serializable]
	public partial class Week_log
	{
		public Week_log()
		{}
		#region Model
		private long _weeklog_id;
		private long _topic_relation_id;
		private int _homework_id;
		private DateTime _start_time;
		private DateTime _end_time;
		private string _work_condition;
		private string _problem;
		private string _work_plan;
		private string _advice;
		private DateTime _submit_time= DateTime.Now;
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
		/// 工作情况
		/// </summary>
		public string Work_condition
		{
			set{ _work_condition=value;}
			get{return _work_condition;}
		}
		/// <summary>
		/// 存在问题
		/// </summary>
		public string Problem
		{
			set{ _problem=value;}
			get{return _problem;}
		}
		/// <summary>
		/// 工作计划
		/// </summary>
		public string Work_plan
		{
			set{ _work_plan=value;}
			get{return _work_plan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Advice
		{
			set{ _advice=value;}
			get{return _advice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Submit_time
		{
			set{ _submit_time=value;}
			get{return _submit_time;}
		}
		#endregion Model

	}
}

