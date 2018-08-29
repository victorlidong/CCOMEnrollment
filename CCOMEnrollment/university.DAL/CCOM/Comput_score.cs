using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Comput_score
	/// </summary>
	public partial class Comput_score
	{
		public Comput_score()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("Comput_score_id", "Comput_score"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Comput_score_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Comput_score");
			strSql.Append(" where Comput_score_id=@Comput_score_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comput_score_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Comput_score_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Comput_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Comput_score(");
			strSql.Append("Ratio_teacher,Ratio_review,Ratio_software)");
			strSql.Append(" values (");
			strSql.Append("@Ratio_teacher,@Ratio_review,@Ratio_software)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Ratio_teacher", SqlDbType.Float,8),
					new SqlParameter("@Ratio_review", SqlDbType.Float,8),
					new SqlParameter("@Ratio_software", SqlDbType.Float,8)};
			parameters[0].Value = model.Ratio_teacher;
			parameters[1].Value = model.Ratio_review;
			parameters[2].Value = model.Ratio_software;

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
		public bool Update(university.Model.CCOM.Comput_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Comput_score set ");
			strSql.Append("Ratio_teacher=@Ratio_teacher,");
			strSql.Append("Ratio_review=@Ratio_review,");
			strSql.Append("Ratio_software=@Ratio_software");
			strSql.Append(" where Comput_score_id=@Comput_score_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Ratio_teacher", SqlDbType.Float,8),
					new SqlParameter("@Ratio_review", SqlDbType.Float,8),
					new SqlParameter("@Ratio_software", SqlDbType.Float,8),
					new SqlParameter("@Comput_score_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Ratio_teacher;
			parameters[1].Value = model.Ratio_review;
			parameters[2].Value = model.Ratio_software;
			parameters[3].Value = model.Comput_score_id;

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
		public bool Delete(int Comput_score_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Comput_score ");
			strSql.Append(" where Comput_score_id=@Comput_score_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comput_score_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Comput_score_id;

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
		public bool DeleteList(string Comput_score_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Comput_score ");
			strSql.Append(" where Comput_score_id in ("+Comput_score_idlist + ")  ");
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
		public university.Model.CCOM.Comput_score GetModel(int Comput_score_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Comput_score_id,Ratio_teacher,Ratio_review,Ratio_software from Comput_score ");
			strSql.Append(" where Comput_score_id=@Comput_score_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comput_score_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Comput_score_id;

			university.Model.CCOM.Comput_score model=new university.Model.CCOM.Comput_score();
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
		public university.Model.CCOM.Comput_score DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Comput_score model=new university.Model.CCOM.Comput_score();
			if (row != null)
			{
				if(row["Comput_score_id"]!=null && row["Comput_score_id"].ToString()!="")
				{
					model.Comput_score_id=int.Parse(row["Comput_score_id"].ToString());
				}
				if(row["Ratio_teacher"]!=null && row["Ratio_teacher"].ToString()!="")
				{
					model.Ratio_teacher=decimal.Parse(row["Ratio_teacher"].ToString());
				}
				if(row["Ratio_review"]!=null && row["Ratio_review"].ToString()!="")
				{
					model.Ratio_review=decimal.Parse(row["Ratio_review"].ToString());
				}
				if(row["Ratio_software"]!=null && row["Ratio_software"].ToString()!="")
				{
					model.Ratio_software=decimal.Parse(row["Ratio_software"].ToString());
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
			strSql.Append("select Comput_score_id,Ratio_teacher,Ratio_review,Ratio_software ");
			strSql.Append(" FROM Comput_score ");
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
			strSql.Append(" Comput_score_id,Ratio_teacher,Ratio_review,Ratio_software ");
			strSql.Append(" FROM Comput_score ");
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
			strSql.Append("select count(1) FROM Comput_score ");
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
				strSql.Append("order by T.Comput_score_id desc");
			}
			strSql.Append(")AS Row, T.*  from Comput_score T ");
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
			parameters[0].Value = "Comput_score";
			parameters[1].Value = "Comput_score_id";
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

