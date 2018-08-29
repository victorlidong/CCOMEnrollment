/**  版本信息模板在安装目录下，可自行修改。
* Proposal.cs
*
* 功 能： N/A
* 类 名： Proposal
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/29 8:50:23   N/A    初版
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
	/// Proposal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Proposal
	{
		public Proposal()
		{}
		#region Model
		private long _proposal_id;
		private long _topic_relation_id;
		private string _review;
		private int? _score;
		private int _result=0;
		/// <summary>
		/// 开题评审表
		/// </summary>
		public long Proposal_id
		{
			set{ _proposal_id=value;}
			get{return _proposal_id;}
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
		/// 评审意见
		/// </summary>
		public string Review
		{
			set{ _review=value;}
			get{return _review;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 0：未审核；1：已通过；2：未通过
		/// </summary>
		public int Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		#endregion Model

	}
}

