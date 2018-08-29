using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Period
	/// </summary>
	public partial class Period
	{
		public Period()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("Period_id", "Period"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Period_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Period");
			strSql.Append(" where Period_id=@Period_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Period_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Period_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Period model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Period(");
			strSql.Append("Period_year,Period_start,Period_end,Period_state)");
			strSql.Append(" values (");
			strSql.Append("@Period_year,@Period_start,@Period_end,@Period_state)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Period_year", SqlDbType.VarChar,8),
					new SqlParameter("@Period_start", SqlDbType.DateTime),
					new SqlParameter("@Period_end", SqlDbType.DateTime),
					new SqlParameter("@Period_state", SqlDbType.Bit,1)};
			parameters[0].Value = model.Period_year;
			parameters[1].Value = model.Period_start;
			parameters[2].Value = model.Period_end;
			parameters[3].Value = model.Period_state;

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
		public bool Update(university.Model.CCOM.Period model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Period set ");
			strSql.Append("Period_year=@Period_year,");
			strSql.Append("Period_start=@Period_start,");
			strSql.Append("Period_end=@Period_end,");
			strSql.Append("Period_state=@Period_state");
			strSql.Append(" where Period_id=@Period_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Period_year", SqlDbType.VarChar,8),
					new SqlParameter("@Period_start", SqlDbType.DateTime),
					new SqlParameter("@Period_end", SqlDbType.DateTime),
					new SqlParameter("@Period_state", SqlDbType.Bit,1),
					new SqlParameter("@Period_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Period_year;
			parameters[1].Value = model.Period_start;
			parameters[2].Value = model.Period_end;
			parameters[3].Value = model.Period_state;
			parameters[4].Value = model.Period_id;

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
		public bool Delete(int Period_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Period ");
			strSql.Append(" where Period_id=@Period_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Period_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Period_id;

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
		public bool DeleteList(string Period_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Period ");
			strSql.Append(" where Period_id in ("+Period_idlist + ")  ");
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
		public university.Model.CCOM.Period GetModel(int Period_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Period_id,Period_year,Period_start,Period_end,Period_state from Period ");
			strSql.Append(" where Period_id=@Period_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Period_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Period_id;

			university.Model.CCOM.Period model=new university.Model.CCOM.Period();
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
        public university.Model.CCOM.Period GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Period_id,Period_year,Period_start,Period_end,Period_state  ");
            strSql.Append("  from Period ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Period model = new university.Model.CCOM.Period();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["Period_id"] != null && ds.Tables[0].Rows[0]["Period_id"].ToString() != "")
                {
                    model.Period_id = int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Period_year"] != null)
                {
                    model.Period_year = ds.Tables[0].Rows[0]["Period_year"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Period_start"] != null && ds.Tables[0].Rows[0]["Period_start"].ToString() != "")
                {
                    model.Period_start = DateTime.Parse(ds.Tables[0].Rows[0]["Period_start"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Period_end"] != null && ds.Tables[0].Rows[0]["Period_end"].ToString() != "")
                {
                    model.Period_end = DateTime.Parse(ds.Tables[0].Rows[0]["Period_end"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Period_state"] != null && ds.Tables[0].Rows[0]["Period_state"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Period_state"].ToString() == "1") || (ds.Tables[0].Rows[0]["Period_state"].ToString().ToLower() == "true"))
                    {
                        model.Period_state = true;
                    }
                    else
                    {
                        model.Period_state = false;
                    }
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
		public university.Model.CCOM.Period DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Period model=new university.Model.CCOM.Period();
			if (row != null)
			{
				if(row["Period_id"]!=null && row["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(row["Period_id"].ToString());
				}
				if(row["Period_year"]!=null)
				{
					model.Period_year=row["Period_year"].ToString();
				}
				if(row["Period_start"]!=null && row["Period_start"].ToString()!="")
				{
					model.Period_start=DateTime.Parse(row["Period_start"].ToString());
				}
				if(row["Period_end"]!=null && row["Period_end"].ToString()!="")
				{
					model.Period_end=DateTime.Parse(row["Period_end"].ToString());
				}
				if(row["Period_state"]!=null && row["Period_state"].ToString()!="")
				{
					if((row["Period_state"].ToString()=="1")||(row["Period_state"].ToString().ToLower()=="true"))
					{
						model.Period_state=true;
					}
					else
					{
						model.Period_state=false;
					}
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
			strSql.Append("select Period_id,Period_year,Period_start,Period_end,Period_state ");
			strSql.Append(" FROM Period ");
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
			strSql.Append(" Period_id,Period_year,Period_start,Period_end,Period_state ");
			strSql.Append(" FROM Period ");
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
			strSql.Append("select count(1) FROM Period ");
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
				strSql.Append("order by T.Period_id desc");
			}
			strSql.Append(")AS Row, T.*  from Period T ");
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
			parameters[0].Value = "Period";
			parameters[1].Value = "Period_id";
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

