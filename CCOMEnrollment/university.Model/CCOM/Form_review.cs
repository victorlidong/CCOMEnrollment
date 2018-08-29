/**  版本信息模板在安装目录下，可自行修改。
* Form_review.cs
*
* 功 能： N/A
* 类 名： Form_review
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/12 17:58:09   N/A    初版
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
	/// Form_review:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Form_review
	{
		public Form_review()
		{}
		#region Model
		private long _form_review_id;
		private long _user_id;
		private int _form_type_id;
		private int _review_result=0;
		/// <summary>
		/// 
		/// </summary>
		public long Form_review_id
		{
			set{ _form_review_id=value;}
			get{return _form_review_id;}
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
		/// 1：形式审查表一；2：形式审查表二
		/// </summary>
		public int Form_type_id
		{
			set{ _form_type_id=value;}
			get{return _form_type_id;}
		}
		/// <summary>
		/// 0：未审核；1：及格；2：不及格
		/// </summary>
		public int Review_result
		{
			set{ _review_result=value;}
			get{return _review_result;}
		}
		#endregion Model

	}
}

