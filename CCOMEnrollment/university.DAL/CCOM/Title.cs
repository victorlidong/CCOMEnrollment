﻿using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Title
	/// </summary>
	public partial class Title
	{
		public Title()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("Title_id", "Title"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Title_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Title");
			strSql.Append(" where Title_id=@Title_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Title_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Title model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Title(");
			strSql.Append("Title_name)");
			strSql.Append(" values (");
			strSql.Append("@Title_name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title_name", SqlDbType.VarChar,128)};
			parameters[0].Value = model.Title_name;

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
		public bool Update(university.Model.CCOM.Title model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Title set ");
			strSql.Append("Title_name=@Title_name");
			strSql.Append(" where Title_id=@Title_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title_name", SqlDbType.VarChar,128),
					new SqlParameter("@Title_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title_name;
			parameters[1].Value = model.Title_id;

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
		public bool Delete(int Title_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Title ");
			strSql.Append(" where Title_id=@Title_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Title_id;

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
		public bool DeleteList(string Title_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Title ");
			strSql.Append(" where Title_id in ("+Title_idlist + ")  ");
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
		public university.Model.CCOM.Title GetModel(int Title_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Title_id,Title_name from Title ");
			strSql.Append(" where Title_id=@Title_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Title_id;

			university.Model.CCOM.Title model=new university.Model.CCOM.Title();
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
        public university.Model.CCOM.Title GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Title_id,Title_name ");
            strSql.Append(" FROM Title ");
            strSql.Append(" where " + strWhere);
            university.Model.CCOM.Title model = new university.Model.CCOM.Title();
            DataSet ds = DBSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Title_id"] != null && ds.Tables[0].Rows[0]["Title_id"].ToString() != "")
                {
                    model.Title_id = int.Parse(ds.Tables[0].Rows[0]["Title_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title_name"] != null)
                {
                    model.Title_name = ds.Tables[0].Rows[0]["Title_name"].ToString();
                }
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
		public university.Model.CCOM.Title DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Title model=new university.Model.CCOM.Title();
			if (row != null)
			{
				if(row["Title_id"]!=null && row["Title_id"].ToString()!="")
				{
					model.Title_id=int.Parse(row["Title_id"].ToString());
				}
				if(row["Title_name"]!=null)
				{
					model.Title_name=row["Title_name"].ToString();
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
			strSql.Append("select Title_id,Title_name ");
			strSql.Append(" FROM Title ");
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
			strSql.Append(" Title_id,Title_name ");
			strSql.Append(" FROM Title ");
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
			strSql.Append("select count(1) FROM Title ");
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
				strSql.Append("order by T.Title_id desc");
			}
			strSql.Append(")AS Row, T.*  from Title T ");
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
			parameters[0].Value = "Title";
			parameters[1].Value = "Title_id";
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

