/**  版本信息模板在安装目录下，可自行修改。
* Comput_score.cs
*
* 功 能： N/A
* 类 名： Comput_score
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/16 19:52:34   N/A    初版
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
	/// Comput_score:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Comput_score
	{
		public Comput_score()
		{}
		#region Model
		private int _comput_score_id;
		private decimal _ratio_teacher=0M;
		private decimal _ratio_review=0M;
		private decimal _ratio_software=0M;
		/// <summary>
		/// 
		/// </summary>
		public int Comput_score_id
		{
			set{ _comput_score_id=value;}
			get{return _comput_score_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Ratio_teacher
		{
			set{ _ratio_teacher=value;}
			get{return _ratio_teacher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Ratio_review
		{
			set{ _ratio_review=value;}
			get{return _ratio_review;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Ratio_software
		{
			set{ _ratio_software=value;}
			get{return _ratio_software;}
		}
		#endregion Model

	}
}

