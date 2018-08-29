/**  版本信息模板在安装目录下，可自行修改。
* Topic.cs
*
* 功 能： N/A
* 类 名： Topic
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
	public partial class Topic
	{
		public Topic()
		{}
		#region Model
		private long _topic_id;
		private string _topic_name;
		private long _teacher_id;
		private string _company;
		private string _topic_nature;
		private string _topic_source;
		private string _topic_content;
		private string _topic_task;
		private bool _selected_state;
		private int _check_state;
		private int _period_id=4;
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
		public long Teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
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
		/// 0：未选；1：已选
		/// </summary>
		public bool Selected_state
		{
			set{ _selected_state=value;}
			get{return _selected_state;}
		}
		/// <summary>
		/// 0：未审核；1：审核已通过；2：审核未通过
		/// </summary>
		public int Check_state
		{
			set{ _check_state=value;}
			get{return _check_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Period_id
		{
			set{ _period_id=value;}
			get{return _period_id;}
		}
		#endregion Model

	}
}

