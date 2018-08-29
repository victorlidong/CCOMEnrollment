/**  版本信息模板在安装目录下，可自行修改。
* User_information.cs
*
* 功 能： N/A
* 类 名： User_information
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/21 21:45:08   N/A    初版
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
	public partial class User_information
	{
		public User_information()
		{}
		#region Model
		private long _user_id;
		private string _user_number;
		private string _user_password;
		private string _user_realname;
		private bool _user_gender;
		private DateTime? _user_birthday;
		private DateTime? _user_addtime= DateTime.Now;
		private bool _user_status= true;
		private int _role_id;
		private int _agency_id;
		private string _user_phone;
		private int? _nationality_id;
		private int? _politic_id;
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
		public string User_number
		{
			set{ _user_number=value;}
			get{return _user_number;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string User_password
		{
			set{ _user_password=value;}
			get{return _user_password;}
		}
		/// <summary>
		/// 用户真实姓名
		/// </summary>
		public string User_realname
		{
			set{ _user_realname=value;}
			get{return _user_realname;}
		}
		/// <summary>
		/// 性别 0-男 1-女
		/// </summary>
		public bool User_gender
		{
			set{ _user_gender=value;}
			get{return _user_gender;}
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public DateTime? User_birthday
		{
			set{ _user_birthday=value;}
			get{return _user_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? User_addtime
		{
			set{ _user_addtime=value;}
			get{return _user_addtime;}
		}
		/// <summary>
		/// 用户状态 0-停用 1-正常
		/// </summary>
		public bool User_status
		{
			set{ _user_status=value;}
			get{return _user_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Agency_id
		{
			set{ _agency_id=value;}
			get{return _agency_id;}
		}
		/// <summary>
		/// 用户手机号
		/// </summary>
		public string User_phone
		{
			set{ _user_phone=value;}
			get{return _user_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Nationality_id
		{
			set{ _nationality_id=value;}
			get{return _nationality_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Politic_id
		{
			set{ _politic_id=value;}
			get{return _politic_id;}
		}
		#endregion Model

	}
}

