/**  版本信息模板在安装目录下，可自行修改。
* Tracking_evaluation.cs
*
* 功 能： N/A
* 类 名： Tracking_evaluation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:53   N/A    初版
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
	/// Tracking_evaluation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tracking_evaluation
	{
		public Tracking_evaluation()
		{}
		#region Model
		private long _te_id;
		private long _topic_relation_id;
		private int _track_one;
		private int _track_two;
		private int _track_three;
		private int _track_four;
		private int _track_five;
		private int _track_six;
		/// <summary>
		/// 
		/// </summary>
		public long Te_id
		{
			set{ _te_id=value;}
			get{return _te_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Topic_relation_id
		{
			set{ _topic_relation_id=value;}
			get{return _topic_relation_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_one
		{
			set{ _track_one=value;}
			get{return _track_one;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_two
		{
			set{ _track_two=value;}
			get{return _track_two;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_three
		{
			set{ _track_three=value;}
			get{return _track_three;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_four
		{
			set{ _track_four=value;}
			get{return _track_four;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_five
		{
			set{ _track_five=value;}
			get{return _track_five;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Track_six
		{
			set{ _track_six=value;}
			get{return _track_six;}
		}
		#endregion Model

	}
}

