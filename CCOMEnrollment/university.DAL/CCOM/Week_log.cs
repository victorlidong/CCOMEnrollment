using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Week_log
	/// </summary>
	public partial class Week_log
	{
		public Week_log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Weeklog_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Week_log");
			strSql.Append(" where Weeklog_id=@Weeklog_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Weeklog_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Week_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Week_log(");
			strSql.Append("Topic_relation_id,Homework_id,Start_time,End_time,Work_condition,Problem,Work_plan,Advice,Submit_time)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Homework_id,@Start_time,@End_time,@Work_condition,@Problem,@Work_plan,@Advice,@Submit_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@Work_condition", SqlDbType.Text),
					new SqlParameter("@Problem", SqlDbType.Text),
					new SqlParameter("@Work_plan", SqlDbType.Text),
					new SqlParameter("@Advice", SqlDbType.Text),
					new SqlParameter("@Submit_time", SqlDbType.DateTime)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Homework_id;
			parameters[2].Value = model.Start_time;
			parameters[3].Value = model.End_time;
			parameters[4].Value = model.Work_condition;
			parameters[5].Value = model.Problem;
			parameters[6].Value = model.Work_plan;
			parameters[7].Value = model.Advice;
			parameters[8].Value = model.Submit_time;

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
		public bool Update(university.Model.CCOM.Week_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Week_log set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Homework_id=@Homework_id,");
			strSql.Append("Start_time=@Start_time,");
			strSql.Append("End_time=@End_time,");
			strSql.Append("Work_condition=@Work_condition,");
			strSql.Append("Problem=@Problem,");
			strSql.Append("Work_plan=@Work_plan,");
			strSql.Append("Advice=@Advice,");
			strSql.Append("Submit_time=@Submit_time");
			strSql.Append(" where Weeklog_id=@Weeklog_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@Work_condition", SqlDbType.Text),
					new SqlParameter("@Problem", SqlDbType.Text),
					new SqlParameter("@Work_plan", SqlDbType.Text),
					new SqlParameter("@Advice", SqlDbType.Text),
					new SqlParameter("@Submit_time", SqlDbType.DateTime),
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Homework_id;
			parameters[2].Value = model.Start_time;
			parameters[3].Value = model.End_time;
			parameters[4].Value = model.Work_condition;
			parameters[5].Value = model.Problem;
			parameters[6].Value = model.Work_plan;
			parameters[7].Value = model.Advice;
			parameters[8].Value = model.Submit_time;
			parameters[9].Value = model.Weeklog_id;

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
		public bool Delete(long Weeklog_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Week_log ");
			strSql.Append(" where Weeklog_id=@Weeklog_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Weeklog_id;

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
		public bool DeleteList(string Weeklog_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Week_log ");
			strSql.Append(" where Weeklog_id in ("+Weeklog_idlist + ")  ");
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
		public university.Model.CCOM.Week_log GetModel(long Weeklog_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Weeklog_id,Topic_relation_id,Homework_id,Start_time,End_time,Work_condition,Problem,Work_plan,Advice,Submit_time from Week_log ");
			strSql.Append(" where Weeklog_id=@Weeklog_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Weeklog_id;

			university.Model.CCOM.Week_log model=new university.Model.CCOM.Week_log();
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
        public university.Model.CCOM.Week_log GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Weeklog_id,Topic_relation_id,Homework_id,Start_time,End_time,Work_condition,Problem,Work_plan,Advice,Submit_time  ");
            strSql.Append("  from Week_log ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Week_log model = new university.Model.CCOM.Week_log();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Weeklog_id"] != null && ds.Tables[0].Rows[0]["Weeklog_id"].ToString() != "")
                {
                    model.Weeklog_id = long.Parse(ds.Tables[0].Rows[0]["Weeklog_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Homework_id"] != null && ds.Tables[0].Rows[0]["Homework_id"].ToString() != "")
                {
                    model.Homework_id = int.Parse(ds.Tables[0].Rows[0]["Homework_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Start_time"] != null && ds.Tables[0].Rows[0]["Start_time"].ToString() != "")
                {
                    model.Start_time = DateTime.Parse(ds.Tables[0].Rows[0]["Start_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["End_time"] != null && ds.Tables[0].Rows[0]["End_time"].ToString() != "")
                {
                    model.End_time = DateTime.Parse(ds.Tables[0].Rows[0]["End_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Work_condition"] != null)
                {
                    model.Work_condition = ds.Tables[0].Rows[0]["Work_condition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Problem"] != null)
                {
                    model.Problem = ds.Tables[0].Rows[0]["Problem"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Work_plan"] != null)
                {
                    model.Work_plan = ds.Tables[0].Rows[0]["Work_plan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Advice"] != null)
                {
                    model.Advice = ds.Tables[0].Rows[0]["Advice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Submit_time"] != null && ds.Tables[0].Rows[0]["Submit_time"].ToString() != "")
                {
                    model.Submit_time = DateTime.Parse(ds.Tables[0].Rows[0]["Submit_time"].ToString());
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
		public university.Model.CCOM.Week_log DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Week_log model=new university.Model.CCOM.Week_log();
			if (row != null)
			{
				if(row["Weeklog_id"]!=null && row["Weeklog_id"].ToString()!="")
				{
					model.Weeklog_id=long.Parse(row["Weeklog_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Homework_id"]!=null && row["Homework_id"].ToString()!="")
				{
					model.Homework_id=int.Parse(row["Homework_id"].ToString());
				}
				if(row["Start_time"]!=null && row["Start_time"].ToString()!="")
				{
					model.Start_time=DateTime.Parse(row["Start_time"].ToString());
				}
				if(row["End_time"]!=null && row["End_time"].ToString()!="")
				{
					model.End_time=DateTime.Parse(row["End_time"].ToString());
				}
				if(row["Work_condition"]!=null)
				{
					model.Work_condition=row["Work_condition"].ToString();
				}
				if(row["Problem"]!=null)
				{
					model.Problem=row["Problem"].ToString();
				}
				if(row["Work_plan"]!=null)
				{
					model.Work_plan=row["Work_plan"].ToString();
				}
				if(row["Advice"]!=null)
				{
					model.Advice=row["Advice"].ToString();
				}
				if(row["Submit_time"]!=null && row["Submit_time"].ToString()!="")
				{
					model.Submit_time=DateTime.Parse(row["Submit_time"].ToString());
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
			strSql.Append("select Weeklog_id,Topic_relation_id,Homework_id,Start_time,End_time,Work_condition,Problem,Work_plan,Advice,Submit_time ");
			strSql.Append(" FROM Week_log ");
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
			strSql.Append(" Weeklog_id,Topic_relation_id,Homework_id,Start_time,End_time,Work_condition,Problem,Work_plan,Advice,Submit_time ");
			strSql.Append(" FROM Week_log ");
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
			strSql.Append("select count(1) FROM Week_log ");
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
				strSql.Append("order by T.Weeklog_id desc");
			}
			strSql.Append(")AS Row, T.*  from Week_log T ");
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
			parameters[0].Value = "Week_log";
			parameters[1].Value = "Weeklog_id";
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

