/**  版本信息模板在安装目录下，可自行修改。
* Homework.cs
*
* 功 能： N/A
* 类 名： Homework
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
	/// Homework:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Homework
	{
		public Homework()
		{}
		#region Model
		private int _homework_id;
		private int _week_id;
		private int _datumtype_id;
		/// <summary>
		/// 
		/// </summary>
		public int Homework_id
		{
			set{ _homework_id=value;}
			get{return _homework_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Week_id
		{
			set{ _week_id=value;}
			get{return _week_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DatumType_id
		{
			set{ _datumtype_id=value;}
			get{return _datumtype_id;}
		}
		#endregion Model

	}
}

