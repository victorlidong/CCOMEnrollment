using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:View_Weeklog
	/// </summary>
	public partial class View_Weeklog
	{
		public View_Weeklog()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(university.Model.CCOM.View_Weeklog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Weeklog(");
			strSql.Append("TeachWeek_id,Teacher_id,DatumType_id,Student_id,Homework_id,Weeklog_id,User_realname,DatumType_name,Topic_relation_id)");
			strSql.Append(" values (");
			strSql.Append("@TeachWeek_id,@Teacher_id,@DatumType_id,@Student_id,@Homework_id,@Weeklog_id,@User_realname,@DatumType_name,@Topic_relation_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_realname", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.TeachWeek_id;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.DatumType_id;
			parameters[3].Value = model.Student_id;
			parameters[4].Value = model.Homework_id;
			parameters[5].Value = model.Weeklog_id;
			parameters[6].Value = model.User_realname;
			parameters[7].Value = model.DatumType_name;
			parameters[8].Value = model.Topic_relation_id;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Weeklog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Weeklog set ");
			strSql.Append("TeachWeek_id=@TeachWeek_id,");
			strSql.Append("Teacher_id=@Teacher_id,");
			strSql.Append("DatumType_id=@DatumType_id,");
			strSql.Append("Student_id=@Student_id,");
			strSql.Append("Homework_id=@Homework_id,");
			strSql.Append("Weeklog_id=@Weeklog_id,");
			strSql.Append("User_realname=@User_realname,");
			strSql.Append("DatumType_name=@DatumType_name,");
			strSql.Append("Topic_relation_id=@Topic_relation_id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
					new SqlParameter("@Weeklog_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_realname", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.TeachWeek_id;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.DatumType_id;
			parameters[3].Value = model.Student_id;
			parameters[4].Value = model.Homework_id;
			parameters[5].Value = model.Weeklog_id;
			parameters[6].Value = model.User_realname;
			parameters[7].Value = model.DatumType_name;
			parameters[8].Value = model.Topic_relation_id;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from View_Weeklog ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_Weeklog GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TeachWeek_id,Teacher_id,DatumType_id,Student_id,Homework_id,Weeklog_id,User_realname,DatumType_name,Topic_relation_id from View_Weeklog ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			university.Model.CCOM.View_Weeklog model=new university.Model.CCOM.View_Weeklog();
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
		public university.Model.CCOM.View_Weeklog DataRowToModel(DataRow row)
		{
			university.Model.CCOM.View_Weeklog model=new university.Model.CCOM.View_Weeklog();
			if (row != null)
			{
				if(row["TeachWeek_id"]!=null && row["TeachWeek_id"].ToString()!="")
				{
					model.TeachWeek_id=int.Parse(row["TeachWeek_id"].ToString());
				}
				if(row["Teacher_id"]!=null && row["Teacher_id"].ToString()!="")
				{
					model.Teacher_id=long.Parse(row["Teacher_id"].ToString());
				}
				if(row["DatumType_id"]!=null && row["DatumType_id"].ToString()!="")
				{
					model.DatumType_id=int.Parse(row["DatumType_id"].ToString());
				}
				if(row["Student_id"]!=null && row["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(row["Student_id"].ToString());
				}
				if(row["Homework_id"]!=null && row["Homework_id"].ToString()!="")
				{
					model.Homework_id=int.Parse(row["Homework_id"].ToString());
				}
				if(row["Weeklog_id"]!=null && row["Weeklog_id"].ToString()!="")
				{
					model.Weeklog_id=long.Parse(row["Weeklog_id"].ToString());
				}
				if(row["User_realname"]!=null)
				{
					model.User_realname=row["User_realname"].ToString();
				}
				if(row["DatumType_name"]!=null)
				{
					model.DatumType_name=row["DatumType_name"].ToString();
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
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
			strSql.Append("select TeachWeek_id,Teacher_id,DatumType_id,Student_id,Homework_id,Weeklog_id,User_realname,DatumType_name,Topic_relation_id ");
			strSql.Append(" FROM View_Weeklog ");
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
			strSql.Append(" TeachWeek_id,Teacher_id,DatumType_id,Student_id,Homework_id,Weeklog_id,User_realname,DatumType_name,Topic_relation_id ");
			strSql.Append(" FROM View_Weeklog ");
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
			strSql.Append("select count(1) FROM View_Weeklog ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from View_Weeklog T ");
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
			parameters[0].Value = "View_Weeklog";
			parameters[1].Value = "";
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

