using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Homework
	/// </summary>
	public partial class Homework
	{
		public Homework()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBSQL.GetMaxID("Homework_id", "Homework"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Homework_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Homework");
			strSql.Append(" where Homework_id=@Homework_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Homework_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Homework_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Homework model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Homework(");
			strSql.Append("Week_id,DatumType_id)");
			strSql.Append(" values (");
			strSql.Append("@Week_id,@DatumType_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Week_id", SqlDbType.Int,4),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Week_id;
			parameters[1].Value = model.DatumType_id;

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
		public bool Update(university.Model.CCOM.Homework model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Homework set ");
			strSql.Append("Week_id=@Week_id,");
			strSql.Append("DatumType_id=@DatumType_id");
			strSql.Append(" where Homework_id=@Homework_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Week_id", SqlDbType.Int,4),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@Homework_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Week_id;
			parameters[1].Value = model.DatumType_id;
			parameters[2].Value = model.Homework_id;

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
		public bool Delete(int Homework_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Homework ");
			strSql.Append(" where Homework_id=@Homework_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Homework_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Homework_id;

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
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Homework ");
            strSql.Append(" where ");
            strSql.Append(strWhere);

            int rows = DBSQL.ExecuteSql(strSql.ToString());
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
		public bool DeleteList(string Homework_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Homework ");
			strSql.Append(" where Homework_id in ("+Homework_idlist + ")  ");
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
		public university.Model.CCOM.Homework GetModel(int Homework_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Homework_id,Week_id,DatumType_id from Homework ");
			strSql.Append(" where Homework_id=@Homework_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Homework_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Homework_id;

			university.Model.CCOM.Homework model=new university.Model.CCOM.Homework();
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
		public university.Model.CCOM.Homework DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Homework model=new university.Model.CCOM.Homework();
			if (row != null)
			{
				if(row["Homework_id"]!=null && row["Homework_id"].ToString()!="")
				{
					model.Homework_id=int.Parse(row["Homework_id"].ToString());
				}
				if(row["Week_id"]!=null && row["Week_id"].ToString()!="")
				{
					model.Week_id=int.Parse(row["Week_id"].ToString());
				}
				if(row["DatumType_id"]!=null && row["DatumType_id"].ToString()!="")
				{
					model.DatumType_id=int.Parse(row["DatumType_id"].ToString());
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
			strSql.Append("select Homework_id,Week_id,DatumType_id ");
			strSql.Append(" FROM Homework ");
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
			strSql.Append(" Homework_id,Week_id,DatumType_id ");
			strSql.Append(" FROM Homework ");
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
			strSql.Append("select count(1) FROM Homework ");
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
				strSql.Append("order by T.Homework_id desc");
			}
			strSql.Append(")AS Row, T.*  from Homework T ");
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
			parameters[0].Value = "Homework";
			parameters[1].Value = "Homework_id";
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

