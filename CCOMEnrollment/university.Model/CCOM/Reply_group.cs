/**  版本信息模板在安装目录下，可自行修改。
* Reply_group.cs
*
* 功 能： N/A
* 类 名： Reply_group
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/29 8:50:23   N/A    初版
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
	/// Reply_group:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Reply_group
	{
		public Reply_group()
		{}
		#region Model
		private long _group_id;
		private string _group_name;
		private int _group_type;
		private long _user_id;
		private DateTime _reply_time;
		private string _reply_room;
		private int _period_id=4;
		/// <summary>
		/// 
		/// </summary>
		public long Group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Group_name
		{
			set{ _group_name=value;}
			get{return _group_name;}
		}
		/// <summary>
		/// 0：口头答辩；1：软件验收；2：开题评审
		/// </summary>
		public int Group_type
		{
			set{ _group_type=value;}
			get{return _group_type;}
		}
		/// <summary>
		/// 组长id
		/// </summary>
		public long User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Reply_time
		{
			set{ _reply_time=value;}
			get{return _reply_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reply_room
		{
			set{ _reply_room=value;}
			get{return _reply_room;}
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

