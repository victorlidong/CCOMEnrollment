using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Topic_relation
	/// </summary>
	public partial class Topic_relation
	{
		public Topic_relation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Topic_relation_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Topic_relation");
			strSql.Append(" where Topic_relation_id=@Topic_relation_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_relation_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Topic_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Topic_relation(");
			strSql.Append("Student_id,Teacher_id,Topic_id,Apply_time,Accept_state,advice)");
			strSql.Append(" values (");
			strSql.Append("@Student_id,@Teacher_id,@Topic_id,@Apply_time,@Accept_state,@advice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Apply_time", SqlDbType.Date,3),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@advice", SqlDbType.Text)};
			parameters[0].Value = model.Student_id;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.Topic_id;
			parameters[3].Value = model.Apply_time;
			parameters[4].Value = model.Accept_state;
			parameters[5].Value = model.advice;

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
		public bool Update(university.Model.CCOM.Topic_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Topic_relation set ");
			strSql.Append("Student_id=@Student_id,");
			strSql.Append("Teacher_id=@Teacher_id,");
			strSql.Append("Topic_id=@Topic_id,");
			strSql.Append("Apply_time=@Apply_time,");
			strSql.Append("Accept_state=@Accept_state,");
			strSql.Append("advice=@advice");
			strSql.Append(" where Topic_relation_id=@Topic_relation_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Apply_time", SqlDbType.Date,3),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@advice", SqlDbType.Text),
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Student_id;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.Topic_id;
			parameters[3].Value = model.Apply_time;
			parameters[4].Value = model.Accept_state;
			parameters[5].Value = model.advice;
			parameters[6].Value = model.Topic_relation_id;

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
		public bool Delete(long Topic_relation_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic_relation ");
			strSql.Append(" where Topic_relation_id=@Topic_relation_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_relation_id;

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
		public bool DeleteList(string Topic_relation_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic_relation ");
			strSql.Append(" where Topic_relation_id in ("+Topic_relation_idlist + ")  ");
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
		public university.Model.CCOM.Topic_relation GetModel(long Topic_relation_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Topic_relation_id,Student_id,Teacher_id,Topic_id,Apply_time,Accept_state,advice from Topic_relation ");
			strSql.Append(" where Topic_relation_id=@Topic_relation_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_relation_id;

			university.Model.CCOM.Topic_relation model=new university.Model.CCOM.Topic_relation();
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
        public university.Model.CCOM.Topic_relation GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Topic_relation_id,Student_id,Teacher_id,Topic_id,Apply_time,Accept_state,advice  ");
            strSql.Append("  from Topic_relation ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Topic_relation model = new university.Model.CCOM.Topic_relation();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Student_id"] != null && ds.Tables[0].Rows[0]["Student_id"].ToString() != "")
                {
                    model.Student_id = long.Parse(ds.Tables[0].Rows[0]["Student_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Teacher_id"] != null && ds.Tables[0].Rows[0]["Teacher_id"].ToString() != "")
                {
                    model.Teacher_id = long.Parse(ds.Tables[0].Rows[0]["Teacher_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_id"] != null && ds.Tables[0].Rows[0]["Topic_id"].ToString() != "")
                {
                    model.Topic_id = long.Parse(ds.Tables[0].Rows[0]["Topic_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Apply_time"] != null && ds.Tables[0].Rows[0]["Apply_time"].ToString() != "")
                {
                    model.Apply_time = DateTime.Parse(ds.Tables[0].Rows[0]["Apply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Accept_state"] != null && ds.Tables[0].Rows[0]["Accept_state"].ToString() != "")
                {
                    model.Accept_state = int.Parse(ds.Tables[0].Rows[0]["Accept_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["advice"] != null)
                {
                    model.advice = ds.Tables[0].Rows[0]["advice"].ToString();
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
		public university.Model.CCOM.Topic_relation DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Topic_relation model=new university.Model.CCOM.Topic_relation();
			if (row != null)
			{
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Student_id"]!=null && row["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(row["Student_id"].ToString());
				}
				if(row["Teacher_id"]!=null && row["Teacher_id"].ToString()!="")
				{
					model.Teacher_id=long.Parse(row["Teacher_id"].ToString());
				}
				if(row["Topic_id"]!=null && row["Topic_id"].ToString()!="")
				{
					model.Topic_id=long.Parse(row["Topic_id"].ToString());
				}
				if(row["Apply_time"]!=null && row["Apply_time"].ToString()!="")
				{
					model.Apply_time=DateTime.Parse(row["Apply_time"].ToString());
				}
				if(row["Accept_state"]!=null && row["Accept_state"].ToString()!="")
				{
					model.Accept_state=int.Parse(row["Accept_state"].ToString());
				}
				if(row["advice"]!=null)
				{
					model.advice=row["advice"].ToString();
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
			strSql.Append("select Topic_relation_id,Student_id,Teacher_id,Topic_id,Apply_time,Accept_state,advice ");
			strSql.Append(" FROM Topic_relation ");
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
			strSql.Append(" Topic_relation_id,Student_id,Teacher_id,Topic_id,Apply_time,Accept_state,advice ");
			strSql.Append(" FROM Topic_relation ");
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
			strSql.Append("select count(1) FROM Topic_relation ");
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
				strSql.Append("order by T.Topic_relation_id desc");
			}
			strSql.Append(")AS Row, T.*  from Topic_relation T ");
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
			parameters[0].Value = "Topic_relation";
			parameters[1].Value = "Topic_relation_id";
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

