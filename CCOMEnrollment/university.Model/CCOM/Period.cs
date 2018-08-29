/**  版本信息模板在安装目录下，可自行修改。
* Period.cs
*
* 功 能： N/A
* 类 名： Period
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/21 21:45:06   N/A    初版
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
	public partial class Period
	{
		public Period()
		{}
		#region Model
		private int _period_id;
		private string _period_year;
		private DateTime? _period_start;
		private DateTime? _period_end;
		private bool _period_state= false;
		/// <summary>
		/// 
		/// </summary>
		public int Period_id
		{
			set{ _period_id=value;}
			get{return _period_id;}
		}
		/// <summary>
		/// 年份
		/// </summary>
		public string Period_year
		{
			set{ _period_year=value;}
			get{return _period_year;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? Period_start
		{
			set{ _period_start=value;}
			get{return _period_start;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? Period_end
		{
			set{ _period_end=value;}
			get{return _period_end;}
		}
		/// <summary>
		/// 周期状态 0-停用 1-启用
		/// </summary>
		public bool Period_state
		{
			set{ _period_state=value;}
			get{return _period_state;}
		}
		#endregion Model

	}
}

