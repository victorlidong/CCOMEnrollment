using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Student
	/// </summary>
	public partial class Student
	{
		public Student()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Student_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Student");
			strSql.Append(" where Student_id=@Student_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Student_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Student_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Student(");
			strSql.Append("User_id,Period_id)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Period_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Period_id", SqlDbType.Int,4)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Period_id;

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
		public bool Update(university.Model.CCOM.Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Student set ");
			strSql.Append("User_id=@User_id,");
			strSql.Append("Period_id=@Period_id");
			strSql.Append(" where Student_id=@Student_id");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Period_id;
			parameters[2].Value = model.Student_id;

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
		public bool Delete(long Student_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student ");
			strSql.Append(" where Student_id=@Student_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Student_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Student_id;

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
		public bool DeleteList(string Student_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student ");
			strSql.Append(" where Student_id in ("+Student_idlist + ")  ");
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
		public university.Model.CCOM.Student GetModel(long Student_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Student_id,User_id,Period_id from Student ");
			strSql.Append(" where Student_id=@Student_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Student_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Student_id;

			university.Model.CCOM.Student model=new university.Model.CCOM.Student();
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
		public university.Model.CCOM.Student DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Student model=new university.Model.CCOM.Student();
			if (row != null)
			{
				if(row["Student_id"]!=null && row["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(row["Student_id"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
				}
				if(row["Period_id"]!=null && row["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(row["Period_id"].ToString());
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
			strSql.Append("select Student_id,User_id,Period_id ");
			strSql.Append(" FROM Student ");
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
			strSql.Append(" Student_id,User_id,Period_id ");
			strSql.Append(" FROM Student ");
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
			strSql.Append("select count(1) FROM Student ");
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
				strSql.Append("order by T.Student_id desc");
			}
			strSql.Append(")AS Row, T.*  from Student T ");
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
			parameters[0].Value = "Student";
			parameters[1].Value = "Student_id";
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

