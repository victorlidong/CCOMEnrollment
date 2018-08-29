/**  版本信息模板在安装目录下，可自行修改。
* Comment.cs
*
* 功 能： N/A
* 类 名： Comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/8 13:25:30   N/A    初版
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
	/// Comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Comment
	{
		public Comment()
		{}
		#region Model
		private long _comment_id;
		private long _topic_relation_id;
		private string _teacher_comment;
		private string _reviewer_comment;
		private string _problem;
		private string _comment_content;
		private int? _reply_score;
		private int? _teacher_score;
		/// <summary>
		/// 
		/// </summary>
		public long Comment_id
		{
			set{ _comment_id=value;}
			get{return _comment_id;}
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
		public string Teacher_comment
		{
			set{ _teacher_comment=value;}
			get{return _teacher_comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reviewer_comment
		{
			set{ _reviewer_comment=value;}
			get{return _reviewer_comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string problem
		{
			set{ _problem=value;}
			get{return _problem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment_content
		{
			set{ _comment_content=value;}
			get{return _comment_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Reply_score
		{
			set{ _reply_score=value;}
			get{return _reply_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Teacher_score
		{
			set{ _teacher_score=value;}
			get{return _teacher_score;}
		}
		#endregion Model

	}
}

