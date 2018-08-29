/**  版本信息模板在安装目录下，可自行修改。
* Topic_relation.cs
*
* 功 能： N/A
* 类 名： Topic_relation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/21 21:45:07   N/A    初版
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
	public partial class Topic_relation
	{
		public Topic_relation()
		{}
		#region Model
		private long _topic_relation_id;
		private long _student_id;
		private long _teacher_id;
		private long _topic_id;
		private DateTime _apply_time;
		private int _accept_state;
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
		public long Teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
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
		public DateTime Apply_time
		{
			set{ _apply_time=value;}
			get{return _apply_time;}
		}
		/// <summary>
		/// 0：已申请，未接受；1：已接受；2：已拒绝
		/// </summary>
		public int Accept_state
		{
			set{ _accept_state=value;}
			get{return _accept_state;}
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

