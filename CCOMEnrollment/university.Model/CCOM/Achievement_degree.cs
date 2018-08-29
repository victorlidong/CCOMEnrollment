/**  版本信息模板在安装目录下，可自行修改。
* Achievement_degree.cs
*
* 功 能： N/A
* 类 名： Achievement_degree
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:03   N/A    初版
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
	/// Achievement_degree:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Achievement_degree
	{
		public Achievement_degree()
		{}
		#region Model
		private long _ac_id;
		private long _topic_relation_id;
		private bool _assess_type;
		private int _require_one;
		private int _require_two;
		private int _require_three;
		private int _require_four;
		private int _require_five;
		private int _require_six;
		/// <summary>
		/// 
		/// </summary>
		public long Ac_id
		{
			set{ _ac_id=value;}
			get{return _ac_id;}
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
		/// 0：指导教师；1：学生
		/// </summary>
		public bool Assess_type
		{
			set{ _assess_type=value;}
			get{return _assess_type;}
		}
		/// <summary>
		/// 能够了解应用领域背景知识，完成复杂软件系统的需求分析，说明其合理性
		/// </summary>
		public int Require_one
		{
			set{ _require_one=value;}
			get{return _require_one;}
		}
		/// <summary>
		/// 能够采用适当的方法评价工程实践对社会、健康、安全、法律以及文化的影响，并理解应承担的责任
		/// </summary>
		public int Require_two
		{
			set{ _require_two=value;}
			get{return _require_two;}
		}
		/// <summary>
		/// 能够了解国内外行业标准、规范和技术发展趋势
		/// </summary>
		public int Require_three
		{
			set{ _require_three=value;}
			get{return _require_three;}
		}
		/// <summary>
		/// 能够理解复杂软件工程问题的专业实践和对环境以及社会可持续发展的影响
		/// </summary>
		public int Require_four
		{
			set{ _require_four=value;}
			get{return _require_four;}
		}
		/// <summary>
		/// 能够具备一定的国际视野，能够了解和跟踪软件工程专业的最新发展趋势
		/// </summary>
		public int Require_five
		{
			set{ _require_five=value;}
			get{return _require_five;}
		}
		/// <summary>
		/// 能够运用科学的学习方法，管理知识和处理信息，做到学以致用
		/// </summary>
		public int Require_six
		{
			set{ _require_six=value;}
			get{return _require_six;}
		}
		#endregion Model

	}
}

