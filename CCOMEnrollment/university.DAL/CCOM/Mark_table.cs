using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Mark_table
	/// </summary>
	public partial class Mark_table
	{
		public Mark_table()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Mark_table_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Mark_table");
			strSql.Append(" where Mark_table_id=@Mark_table_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Mark_table_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Mark_table_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Mark_table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Mark_table(");
			strSql.Append("Rs_id,Rc_id,Score,Mark_date)");
			strSql.Append(" values (");
			strSql.Append("@Rs_id,@Rc_id,@Score,@Mark_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Rs_id", SqlDbType.BigInt,8),
					new SqlParameter("@Rc_id", SqlDbType.BigInt,8),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Mark_date", SqlDbType.Date,3)};
			parameters[0].Value = model.Rs_id;
			parameters[1].Value = model.Rc_id;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.Mark_date;

			object obj = DBSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Mark_table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Mark_table set ");
			strSql.Append("Rs_id=@Rs_id,");
			strSql.Append("Rc_id=@Rc_id,");
			strSql.Append("Score=@Score,");
			strSql.Append("Mark_date=@Mark_date");
			strSql.Append(" where Mark_table_id=@Mark_table_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Rs_id", SqlDbType.BigInt,8),
					new SqlParameter("@Rc_id", SqlDbType.BigInt,8),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Mark_date", SqlDbType.Date,3),
					new SqlParameter("@Mark_table_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Rs_id;
			parameters[1].Value = model.Rc_id;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.Mark_date;
			parameters[4].Value = model.Mark_table_id;

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
		public bool Delete(long Mark_table_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Mark_table ");
			strSql.Append(" where Mark_table_id=@Mark_table_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Mark_table_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Mark_table_id;

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
		public bool DeleteList(string Mark_table_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Mark_table ");
			strSql.Append(" where Mark_table_id in ("+Mark_table_idlist + ")  ");
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
		public university.Model.CCOM.Mark_table GetModel(long Mark_table_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Mark_table_id,Rs_id,Rc_id,Score,Mark_date from Mark_table ");
			strSql.Append(" where Mark_table_id=@Mark_table_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Mark_table_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Mark_table_id;

			university.Model.CCOM.Mark_table model=new university.Model.CCOM.Mark_table();
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
        public university.Model.CCOM.Mark_table GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Mark_table_id,Rs_id,Rc_id,Score,Mark_date from Mark_table ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Mark_table model = new university.Model.CCOM.Mark_table();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Mark_table_id"] != null && ds.Tables[0].Rows[0]["Mark_table_id"].ToString() != "")
                {
                    model.Mark_table_id = long.Parse(ds.Tables[0].Rows[0]["Mark_table_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rs_id"] != null && ds.Tables[0].Rows[0]["Rs_id"].ToString() != "")
                {
                    model.Rs_id = long.Parse(ds.Tables[0].Rows[0]["Rs_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rc_id"] != null && ds.Tables[0].Rows[0]["Rc_id"].ToString() != "")
                {
                    model.Rc_id = long.Parse(ds.Tables[0].Rows[0]["Rc_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"] != null && ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Mark_date"] != null && ds.Tables[0].Rows[0]["Mark_date"].ToString() != "")
                {
                    model.Mark_date = DateTime.Parse(ds.Tables[0].Rows[0]["Mark_date"].ToString());
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
		public university.Model.CCOM.Mark_table DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Mark_table model=new university.Model.CCOM.Mark_table();
			if (row != null)
			{
				if(row["Mark_table_id"]!=null && row["Mark_table_id"].ToString()!="")
				{
					model.Mark_table_id=long.Parse(row["Mark_table_id"].ToString());
				}
				if(row["Rs_id"]!=null && row["Rs_id"].ToString()!="")
				{
					model.Rs_id=long.Parse(row["Rs_id"].ToString());
				}
				if(row["Rc_id"]!=null && row["Rc_id"].ToString()!="")
				{
					model.Rc_id=long.Parse(row["Rc_id"].ToString());
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["Mark_date"]!=null && row["Mark_date"].ToString()!="")
				{
					model.Mark_date=DateTime.Parse(row["Mark_date"].ToString());
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
			strSql.Append("select Mark_table_id,Rs_id,Rc_id,Score,Mark_date ");
			strSql.Append(" FROM Mark_table ");
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
			strSql.Append(" Mark_table_id,Rs_id,Rc_id,Score,Mark_date ");
			strSql.Append(" FROM Mark_table ");
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
			strSql.Append("select count(1) FROM Mark_table ");
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
				strSql.Append("order by T.Mark_table_id desc");
			}
			strSql.Append(")AS Row, T.*  from Mark_table T ");
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
			parameters[0].Value = "Mark_table";
			parameters[1].Value = "Mark_table_id";
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

