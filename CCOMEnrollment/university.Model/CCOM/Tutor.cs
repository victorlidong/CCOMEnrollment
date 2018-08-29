/**  版本信息模板在安装目录下，可自行修改。
* Tutor.cs
*
* 功 能： N/A
* 类 名： Tutor
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/21 21:45:07   N/A    初版
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
	/// 报名周期表
	/// </summary>
	[Serializable]
	public partial class Tutor
	{
		public Tutor()
		{}
		#region Model
		private long _tutor_id;
		private long _user_id;
		private int? _title_id;
		private string _subject;
		private string _tutor_email;
		private string _tutor_fixedphone;
		private string _tutor_location;
		private string _tutor_introduce;
		private string _tutor_picture;
		/// <summary>
		/// 
		/// </summary>
		public long Tutor_id
		{
			set{ _tutor_id=value;}
			get{return _tutor_id;}
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
		public int? Title_id
		{
			set{ _title_id=value;}
			get{return _title_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_email
		{
			set{ _tutor_email=value;}
			get{return _tutor_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_fixedphone
		{
			set{ _tutor_fixedphone=value;}
			get{return _tutor_fixedphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_location
		{
			set{ _tutor_location=value;}
			get{return _tutor_location;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_introduce
		{
			set{ _tutor_introduce=value;}
			get{return _tutor_introduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tutor_picture
		{
			set{ _tutor_picture=value;}
			get{return _tutor_picture;}
		}
		#endregion Model

	}
}

