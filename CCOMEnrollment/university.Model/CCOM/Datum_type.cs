/**  版本信息模板在安装目录下，可自行修改。
* Datum_type.cs
*
* 功 能： N/A
* 类 名： Datum_type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/19 20:54:07   N/A    初版
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
	/// Datum_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Datum_type
	{
		public Datum_type()
		{}
		#region Model
		private int _datumtype_id;
		private string _datumtype_name;
		/// <summary>
		/// 
		/// </summary>
		public int DatumType_id
		{
			set{ _datumtype_id=value;}
			get{return _datumtype_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DatumType_name
		{
			set{ _datumtype_name=value;}
			get{return _datumtype_name;}
		}
		#endregion Model

	}
}

