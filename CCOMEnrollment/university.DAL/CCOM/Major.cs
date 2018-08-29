/**  版本信息模板在安装目录下，可自行修改。
* Major.cs
*
* 功 能： N/A
* 类 名： Major
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/16 10:27:58   N/A    初版
*
* Copyright (c) 2012 university Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Major
	/// </summary>
	public partial class Major
	{
		public Major()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("Major_id", "Major"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Major_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Major");
			strSql.Append(" where Major_id=@Major_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Major_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Major_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Major(");
			strSql.Append("Major_require,Major_academic,Major_reference,Agency_id,Period_id,Major_remark)");
			strSql.Append(" values (");
			strSql.Append("@Major_require,@Major_academic,@Major_reference,@Agency_id,@Period_id,@Major_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Major_require", SqlDbType.Text),
					new SqlParameter("@Major_academic", SqlDbType.VarChar,64),
					new SqlParameter("@Major_reference", SqlDbType.Text),
					new SqlParameter("@Agency_id", SqlDbType.Int,4),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@Major_remark", SqlDbType.Text)};
			parameters[0].Value = model.Major_require;
			parameters[1].Value = model.Major_academic;
			parameters[2].Value = model.Major_reference;
			parameters[3].Value = model.Agency_id;
			parameters[4].Value = model.Period_id;
			parameters[5].Value = model.Major_remark;

			object obj = DBSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Major set ");
			strSql.Append("Major_require=@Major_require,");
			strSql.Append("Major_academic=@Major_academic,");
			strSql.Append("Major_reference=@Major_reference,");
			strSql.Append("Agency_id=@Agency_id,");
			strSql.Append("Period_id=@Period_id,");
			strSql.Append("Major_remark=@Major_remark");
			strSql.Append(" where Major_id=@Major_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Major_require", SqlDbType.Text),
					new SqlParameter("@Major_academic", SqlDbType.VarChar,64),
					new SqlParameter("@Major_reference", SqlDbType.Text),
					new SqlParameter("@Agency_id", SqlDbType.Int,4),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@Major_remark", SqlDbType.Text),
					new SqlParameter("@Major_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Major_require;
			parameters[1].Value = model.Major_academic;
			parameters[2].Value = model.Major_reference;
			parameters[3].Value = model.Agency_id;
			parameters[4].Value = model.Period_id;
			parameters[5].Value = model.Major_remark;
			parameters[6].Value = model.Major_id;

			int rows=DBSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Major_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Major ");
			strSql.Append(" where Major_id=@Major_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Major_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Major_id;

			int rows=DBSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Major_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Major ");
			strSql.Append(" where Major_id in ("+Major_idlist + ")  ");
			int rows=DBSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Major GetModel(int Major_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Major_id,Major_require,Major_academic,Major_reference,Agency_id,Period_id,Major_remark from Major ");
			strSql.Append(" where Major_id=@Major_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Major_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Major_id;

			university.Model.CCOM.Major model=new university.Model.CCOM.Major();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public university.Model.CCOM.Major GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Major_id,Major_require,Major_academic,Major_reference,Agency_id,Period_id,Major_remark from Major ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Major model = new university.Model.CCOM.Major();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Major_id"].ToString() != "")
                {
                    model.Major_id = int.Parse(ds.Tables[0].Rows[0]["Major_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Major_require"].ToString() != "")
                {
                    model.Major_require = ds.Tables[0].Rows[0]["Major_require"].ToString();
                }
                model.Major_academic = ds.Tables[0].Rows[0]["Major_academic"].ToString();
                model.Major_reference = ds.Tables[0].Rows[0]["Major_reference"].ToString();
                if (ds.Tables[0].Rows[0]["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Period_id"].ToString() != "")
                {
                    model.Period_id = int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
                }
                model.Major_remark = ds.Tables[0].Rows[0]["Major_remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Major DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Major model=new university.Model.CCOM.Major();
			if (row != null)
			{
				if(row["Major_id"]!=null && row["Major_id"].ToString()!="")
				{
					model.Major_id=int.Parse(row["Major_id"].ToString());
				}
				if(row["Major_require"]!=null)
				{
					model.Major_require=row["Major_require"].ToString();
				}
				if(row["Major_academic"]!=null)
				{
					model.Major_academic=row["Major_academic"].ToString();
				}
				if(row["Major_reference"]!=null)
				{
					model.Major_reference=row["Major_reference"].ToString();
				}
				if(row["Agency_id"]!=null && row["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(row["Agency_id"].ToString());
				}
				if(row["Period_id"]!=null && row["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(row["Period_id"].ToString());
				}
				if(row["Major_remark"]!=null)
				{
					model.Major_remark=row["Major_remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Major_id,Major_require,Major_academic,Major_reference,Agency_id,Period_id,Major_remark ");
			strSql.Append(" FROM Major ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Major_id,Major_require,Major_academic,Major_reference,Agency_id,Period_id,Major_remark ");
			strSql.Append(" FROM Major ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Major ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DBSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Major_id desc");
			}
			strSql.Append(")AS Row, T.*  from Major T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Major";
			parameters[1].Value = "Major_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

