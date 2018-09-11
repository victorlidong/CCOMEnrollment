using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Datum
	/// </summary>
	public partial class Datum
	{
		public Datum()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Datum_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Datum");
			strSql.Append(" where Datum_id=@Datum_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Datum_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Datum_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Datum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Datum(");
			strSql.Append("Topic_relation_id,File_path,File_name,DatumType_id,Submit_time,Tutor_advice,Homework_id,User_id)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@File_path,@File_name,@DatumType_id,@Submit_time,@Tutor_advice,@Homework_id,@User_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@File_path", SqlDbType.VarChar,128),
					new SqlParameter("@File_name", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@Submit_time", SqlDbType.Date,3),
					new SqlParameter("@Tutor_advice", SqlDbType.Text),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
                    new SqlParameter("@User_id", SqlDbType.BigInt, 8)};
        parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.File_path;
			parameters[2].Value = model.File_name;
			parameters[3].Value = model.DatumType_id;
			parameters[4].Value = model.Submit_time;
			parameters[5].Value = model.Tutor_advice;
			parameters[6].Value = model.Homework_id;
            parameters[7].Value = model.User_id;
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
		public bool Update(university.Model.CCOM.Datum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Datum set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("File_path=@File_path,");
			strSql.Append("File_name=@File_name,");
			strSql.Append("DatumType_id=@DatumType_id,");
			strSql.Append("Submit_time=@Submit_time,");
			strSql.Append("Tutor_advice=@Tutor_advice,");
			strSql.Append("Homework_id=@Homework_id");
			strSql.Append(" where Datum_id=@Datum_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@File_path", SqlDbType.VarChar,128),
					new SqlParameter("@File_name", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@Submit_time", SqlDbType.Date,3),
					new SqlParameter("@Tutor_advice", SqlDbType.Text),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
					new SqlParameter("@Datum_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.File_path;
			parameters[2].Value = model.File_name;
			parameters[3].Value = model.DatumType_id;
			parameters[4].Value = model.Submit_time;
			parameters[5].Value = model.Tutor_advice;
			parameters[6].Value = model.Homework_id;
			parameters[7].Value = model.Datum_id;

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
		public bool Delete(long Datum_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Datum ");
			strSql.Append(" where Datum_id=@Datum_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Datum_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Datum_id;

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
		public bool DeleteList(string Datum_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Datum ");
			strSql.Append(" where Datum_id in ("+Datum_idlist + ")  ");
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
		public university.Model.CCOM.Datum GetModel(long Datum_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Datum_id,Topic_relation_id,File_path,File_name,DatumType_id,Submit_time,Tutor_advice,Homework_id from Datum ");
			strSql.Append(" where Datum_id=@Datum_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Datum_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Datum_id;

			university.Model.CCOM.Datum model=new university.Model.CCOM.Datum();
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
		public university.Model.CCOM.Datum DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Datum model=new university.Model.CCOM.Datum();
			if (row != null)
			{
				if(row["Datum_id"]!=null && row["Datum_id"].ToString()!="")
				{
					model.Datum_id=long.Parse(row["Datum_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["File_path"]!=null)
				{
					model.File_path=row["File_path"].ToString();
				}
				if(row["File_name"]!=null)
				{
					model.File_name=row["File_name"].ToString();
				}
				if(row["DatumType_id"]!=null && row["DatumType_id"].ToString()!="")
				{
					model.DatumType_id=int.Parse(row["DatumType_id"].ToString());
				}
				if(row["Submit_time"]!=null && row["Submit_time"].ToString()!="")
				{
					model.Submit_time=DateTime.Parse(row["Submit_time"].ToString());
				}
				if(row["Tutor_advice"]!=null)
				{
					model.Tutor_advice=row["Tutor_advice"].ToString();
				}
				if(row["Homework_id"]!=null && row["Homework_id"].ToString()!="")
				{
					model.Homework_id=int.Parse(row["Homework_id"].ToString());
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
			strSql.Append("select Datum_id,Topic_relation_id,File_path,File_name,DatumType_id,Submit_time,Tutor_advice,Homework_id ");
			strSql.Append(" FROM Datum ");
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
			strSql.Append(" Datum_id,Topic_relation_id,File_path,File_name,DatumType_id,Submit_time,Tutor_advice,Homework_id ");
			strSql.Append(" FROM Datum ");
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
			strSql.Append("select count(1) FROM Datum ");
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
				strSql.Append("order by T.Datum_id desc");
			}
			strSql.Append(")AS Row, T.*  from Datum T ");
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
			parameters[0].Value = "Datum";
			parameters[1].Value = "Datum_id";
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

