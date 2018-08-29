/**  版本信息模板在安装目录下，可自行修改。
* Title.cs
*
* 功 能： N/A
* 类 名： Title
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/12 20:23:32   N/A    初版
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
	/// Title:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Title
	{
		public Title()
		{}
		#region Model
		private int _title_id;
		private string _title_name;
		/// <summary>
		/// 
		/// </summary>
		public int Title_id
		{
			set{ _title_id=value;}
			get{return _title_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title_name
		{
			set{ _title_name=value;}
			get{return _title_name;}
		}
		#endregion Model

	}
}

