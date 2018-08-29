/**  版本信息模板在安装目录下，可自行修改。
* Form.cs
*
* 功 能： N/A
* 类 名： Form
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:25   N/A    初版
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
	/// Form:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Form
	{
		public Form()
		{}
		#region Model
		private int _form_id;
		private string _form_name;
		private int _form_page;
		private int _ff_id=0;
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
		public string Form_name
		{
			set{ _form_name=value;}
			get{return _form_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Form_page
		{
			set{ _form_page=value;}
			get{return _form_page;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Ff_id
		{
			set{ _ff_id=value;}
			get{return _ff_id;}
		}
		#endregion Model

	}
}

