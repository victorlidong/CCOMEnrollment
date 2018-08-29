/**  版本信息模板在安装目录下，可自行修改。
* Software_accept.cs
*
* 功 能： N/A
* 类 名： Software_accept
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:44   N/A    初版
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
	/// Software_accept:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Software_accept
	{
		public Software_accept()
		{}
		#region Model
		private long _sa_id;
		private long _topic_relation_id;
		private string _data_list;
		private string _anguage;
		private string _environmental;
		private string _line_count;
		private string _line_hand;
		private string _run_status;
		private string _feature;
		private int? _conclusion;
		private DateTime? _time;
		/// <summary>
		/// 
		/// </summary>
		public long Sa_id
		{
			set{ _sa_id=value;}
			get{return _sa_id;}
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
		/// 验收资料清单
		/// </summary>
		public string Data_list
		{
			set{ _data_list=value;}
			get{return _data_list;}
		}
		/// <summary>
		/// 源语言/开发环境
		/// </summary>
		public string anguage
		{
			set{ _anguage=value;}
			get{return _anguage;}
		}
		/// <summary>
		/// 运行环境/系统配置
		/// </summary>
		public string Environmental
		{
			set{ _environmental=value;}
			get{return _environmental;}
		}
		/// <summary>
		/// 总代码行数/字节数（KB）
		/// </summary>
		public string Line_count
		{
			set{ _line_count=value;}
			get{return _line_count;}
		}
		/// <summary>
		/// 手工编写代码行数
		/// </summary>
		public string Line_hand
		{
			set{ _line_hand=value;}
			get{return _line_hand;}
		}
		/// <summary>
		/// 软件运行状况
		/// </summary>
		public string Run_status
		{
			set{ _run_status=value;}
			get{return _run_status;}
		}
		/// <summary>
		/// 软件特点及应用情况
		/// </summary>
		public string Feature
		{
			set{ _feature=value;}
			get{return _feature;}
		}
		/// <summary>
		/// 得分
		/// </summary>
		public int? Conclusion
		{
			set{ _conclusion=value;}
			get{return _conclusion;}
		}
		/// <summary>
		/// 验收时间
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

