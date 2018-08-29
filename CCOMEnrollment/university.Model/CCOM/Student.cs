/**  版本信息模板在安装目录下，可自行修改。
* Student.cs
*
* 功 能： N/A
* 类 名： Student
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
	public partial class Student
	{
		public Student()
		{}
		#region Model
		private long _student_id;
		private long _user_id;
		private int _period_id;
		/// <summary>
		/// 
		/// </summary>
		public long Student_id
		{
			set{ _student_id=value;}
			get{return _student_id;}
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
		public int Period_id
		{
			set{ _period_id=value;}
			get{return _period_id;}
		}
		#endregion Model

	}
}

