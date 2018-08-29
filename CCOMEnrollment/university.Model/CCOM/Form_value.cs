/**  版本信息模板在安装目录下，可自行修改。
* Form_value.cs
*
* 功 能： N/A
* 类 名： Form_value
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/4 19:02:08   N/A    初版
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
	/// Form_value:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Form_value
	{
		public Form_value()
		{}
		#region Model
		private long _fv_id;
		private long _user_id;
		private int _form_id;
		private int _self_value=0;
		private int _tea_value=0;
		/// <summary>
		/// 
		/// </summary>
		public long Fv_id
		{
			set{ _fv_id=value;}
			get{return _fv_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Form_id
		{
			set{ _form_id=value;}
			get{return _form_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Self_value
		{
			set{ _self_value=value;}
			get{return _self_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Tea_value
		{
			set{ _tea_value=value;}
			get{return _tea_value;}
		}
		#endregion Model

	}
}

