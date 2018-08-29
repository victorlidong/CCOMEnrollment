/**  版本信息模板在安装目录下，可自行修改。
* Major.cs
*
* 功 能： N/A
* 类 名： Major
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/16 10:27:58   N/A    初版
*
* Copyright (c) 2012 university Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace university.Model.CCOM
{
	/// <summary>
	/// Major:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Major
	{
		public Major()
		{}
		#region Model
		private int _major_id;
		private string _major_require;
		private string _major_academic;
		private string _major_reference;
		private int _agency_id;
		private int _period_id;
		private string _major_remark;
		/// <summary>
		/// 
		/// </summary>
		public int Major_id
		{
			set{ _major_id=value;}
			get{return _major_id;}
		}
		/// <summary>
		/// 专业方向要求
		/// </summary>
		public string Major_require
		{
			set{ _major_require=value;}
			get{return _major_require;}
		}
		/// <summary>
		/// 学制
		/// </summary>
		public string Major_academic
		{
			set{ _major_academic=value;}
			get{return _major_academic;}
		}
		/// <summary>
		/// 参考书目
		/// </summary>
		public string Major_reference
		{
			set{ _major_reference=value;}
			get{return _major_reference;}
		}
		/// <summary>
		/// 机构id  -- Agency
		/// </summary>
		public int Agency_id
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		/// <summary>
		/// 所属周期
		/// </summary>
		public int Period_id
		{
			set{ _period_id=value;}
			get{return _period_id;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Major_remark
		{
			set{ _major_remark=value;}
			get{return _major_remark;}
		}
		#endregion Model

	}
}

