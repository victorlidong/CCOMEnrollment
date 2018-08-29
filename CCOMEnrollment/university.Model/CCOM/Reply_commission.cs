/**  版本信息模板在安装目录下，可自行修改。
* Reply_commission.cs
*
* 功 能： N/A
* 类 名： Reply_commission
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/22 14:51:54   N/A    初版
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
	/// Reply_commission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Reply_commission
	{
		public Reply_commission()
		{}
		#region Model
		private long _rc_id;
		private long _group_id;
		private long _user_id;
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
		public long Group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		#endregion Model

	}
}

