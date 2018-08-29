/**  版本信息模板在安装目录下，可自行修改。
* View_User.cs
*
* 功 能： N/A
* 类 名： View_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/25 20:14:19   N/A    初版
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
	/// View_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_User
	{
		public View_User()
		{}
		#region Model
		private long _user_id;
		private string _user_realname;
		private string _user_number;
		private string _user_password;
		private string _agency_name;
		private string _role_name;
		private bool _user_gender;
		private DateTime? _user_birthday;
		private DateTime? _user_addtime;
		private bool _user_status;
		private int _role_id;
		private int _agency_id;
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
		public string User_realname
		{
			set{ _user_realname=value;}
			get{return _user_realname;}
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
		/// 
		/// </summary>
		public string User_password
		{
			set{ _user_password=value;}
			get{return _user_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Agency_name
		{
			set{ _agency_name=value;}
			get{return _agency_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool User_gender
		{
			set{ _user_gender=value;}
			get{return _user_gender;}
		}
		/// <summary>
		/// 
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
		/// 
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
		#endregion Model

	}
}

