using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Teach_week
	/// </summary>
	public partial class Teach_week
	{
		public Teach_week()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("TeachWeek_id", "Teach_week"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TeachWeek_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Teach_week");
			strSql.Append(" where TeachWeek_id=@TeachWeek_id");
			SqlParameter[] parameters = {
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4)
			};
			parameters[0].Value = TeachWeek_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Teach_week model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Teach_week(");
			strSql.Append("Start_time,End_time,State)");
			strSql.Append(" values (");
			strSql.Append("@Start_time,@End_time,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@State", SqlDbType.Bit,1)};
			parameters[0].Value = model.Start_time;
			parameters[1].Value = model.End_time;
			parameters[2].Value = model.State;

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
		public bool Update(university.Model.CCOM.Teach_week model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Teach_week set ");
			strSql.Append("Start_time=@Start_time,");
			strSql.Append("End_time=@End_time,");
			strSql.Append("State=@State");
			strSql.Append(" where TeachWeek_id=@TeachWeek_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Start_time;
			parameters[1].Value = model.End_time;
			parameters[2].Value = model.State;
			parameters[3].Value = model.TeachWeek_id;

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
		public bool Delete(int TeachWeek_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teach_week ");
			strSql.Append(" where TeachWeek_id=@TeachWeek_id");
			SqlParameter[] parameters = {
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4)
			};
			parameters[0].Value = TeachWeek_id;

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
		public bool DeleteList(string TeachWeek_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teach_week ");
			strSql.Append(" where TeachWeek_id in ("+TeachWeek_idlist + ")  ");
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
		public university.Model.CCOM.Teach_week GetModel(int TeachWeek_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TeachWeek_id,Start_time,End_time,State from Teach_week ");
			strSql.Append(" where TeachWeek_id=@TeachWeek_id");
			SqlParameter[] parameters = {
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4)
			};
			parameters[0].Value = TeachWeek_id;

			university.Model.CCOM.Teach_week model=new university.Model.CCOM.Teach_week();
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
		public university.Model.CCOM.Teach_week DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Teach_week model=new university.Model.CCOM.Teach_week();
			if (row != null)
			{
				if(row["TeachWeek_id"]!=null && row["TeachWeek_id"].ToString()!="")
				{
					model.TeachWeek_id=int.Parse(row["TeachWeek_id"].ToString());
				}
				if(row["Start_time"]!=null && row["Start_time"].ToString()!="")
				{
					model.Start_time=DateTime.Parse(row["Start_time"].ToString());
				}
				if(row["End_time"]!=null && row["End_time"].ToString()!="")
				{
					model.End_time=DateTime.Parse(row["End_time"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					if((row["State"].ToString()=="1")||(row["State"].ToString().ToLower()=="true"))
					{
						model.State=true;
					}
					else
					{
						model.State=false;
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
			strSql.Append("select TeachWeek_id,Start_time,End_time,State ");
			strSql.Append(" FROM Teach_week ");
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
			strSql.Append(" TeachWeek_id,Start_time,End_time,State ");
			strSql.Append(" FROM Teach_week ");
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
			strSql.Append("select count(1) FROM Teach_week ");
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
				strSql.Append("order by T.TeachWeek_id desc");
			}
			strSql.Append(")AS Row, T.*  from Teach_week T ");
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
			parameters[0].Value = "Teach_week";
			parameters[1].Value = "TeachWeek_id";
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

