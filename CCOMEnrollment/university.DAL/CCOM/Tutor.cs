using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Tutor
	/// </summary>
	public partial class Tutor
	{
		public Tutor()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Tutor_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tutor");
			strSql.Append(" where Tutor_id=@Tutor_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Tutor_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Tutor_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Tutor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tutor(");
			strSql.Append("User_id,Title_id,Subject,Tutor_email,Tutor_fixedphone,Tutor_location,Tutor_introduce,Tutor_picture)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Title_id,@Subject,@Tutor_email,@Tutor_fixedphone,@Tutor_location,@Tutor_introduce,@Tutor_picture)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Title_id", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_email", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_fixedphone", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_location", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_introduce", SqlDbType.Text),
					new SqlParameter("@Tutor_picture", SqlDbType.VarChar,128)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Title_id;
			parameters[2].Value = model.Subject;
			parameters[3].Value = model.Tutor_email;
			parameters[4].Value = model.Tutor_fixedphone;
			parameters[5].Value = model.Tutor_location;
			parameters[6].Value = model.Tutor_introduce;
			parameters[7].Value = model.Tutor_picture;

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
		public bool Update(university.Model.CCOM.Tutor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tutor set ");
			strSql.Append("User_id=@User_id,");
			strSql.Append("Title_id=@Title_id,");
			strSql.Append("Subject=@Subject,");
			strSql.Append("Tutor_email=@Tutor_email,");
			strSql.Append("Tutor_fixedphone=@Tutor_fixedphone,");
			strSql.Append("Tutor_location=@Tutor_location,");
			strSql.Append("Tutor_introduce=@Tutor_introduce,");
			strSql.Append("Tutor_picture=@Tutor_picture");
			strSql.Append(" where Tutor_id=@Tutor_id");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Title_id", SqlDbType.Int,4),
					new SqlParameter("@Subject", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_email", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_fixedphone", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_location", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_introduce", SqlDbType.Text),
					new SqlParameter("@Tutor_picture", SqlDbType.VarChar,128),
					new SqlParameter("@Tutor_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Title_id;
			parameters[2].Value = model.Subject;
			parameters[3].Value = model.Tutor_email;
			parameters[4].Value = model.Tutor_fixedphone;
			parameters[5].Value = model.Tutor_location;
			parameters[6].Value = model.Tutor_introduce;
			parameters[7].Value = model.Tutor_picture;
			parameters[8].Value = model.Tutor_id;

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
		public bool Delete(long Tutor_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tutor ");
			strSql.Append(" where Tutor_id=@Tutor_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Tutor_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Tutor_id;

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
		public bool DeleteList(string Tutor_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tutor ");
			strSql.Append(" where Tutor_id in ("+Tutor_idlist + ")  ");
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
		public university.Model.CCOM.Tutor GetModel(long Tutor_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tutor_id,User_id,Title_id,Subject,Tutor_email,Tutor_fixedphone,Tutor_location,Tutor_introduce,Tutor_picture from Tutor ");
			strSql.Append(" where Tutor_id=@Tutor_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Tutor_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Tutor_id;

			university.Model.CCOM.Tutor model=new university.Model.CCOM.Tutor();
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
        public university.Model.CCOM.Tutor GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Tutor_id,User_id,Title_id,Subject,Tutor_email,Tutor_fixedphone,Tutor_location,Tutor_introduce,Tutor_picture  ");
            strSql.Append("  from Tutor ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Tutor model = new university.Model.CCOM.Tutor();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Tutor_id"] != null && ds.Tables[0].Rows[0]["Tutor_id"].ToString() != "")
                {
                    model.Tutor_id = long.Parse(ds.Tables[0].Rows[0]["Tutor_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title_id"] != null && ds.Tables[0].Rows[0]["Title_id"].ToString() != "")
                {
                    model.Title_id = int.Parse(ds.Tables[0].Rows[0]["Title_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Subject"] != null)
                {
                    model.Subject = ds.Tables[0].Rows[0]["Subject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tutor_email"] != null)
                {
                    model.Tutor_email = ds.Tables[0].Rows[0]["Tutor_email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tutor_fixedphone"] != null)
                {
                    model.Tutor_fixedphone = ds.Tables[0].Rows[0]["Tutor_fixedphone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tutor_location"] != null)
                {
                    model.Tutor_location = ds.Tables[0].Rows[0]["Tutor_location"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tutor_introduce"] != null)
                {
                    model.Tutor_introduce = ds.Tables[0].Rows[0]["Tutor_introduce"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tutor_picture"] != null)
                {
                    model.Tutor_picture = ds.Tables[0].Rows[0]["Tutor_picture"].ToString();
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
		public university.Model.CCOM.Tutor DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Tutor model=new university.Model.CCOM.Tutor();
			if (row != null)
			{
				if(row["Tutor_id"]!=null && row["Tutor_id"].ToString()!="")
				{
					model.Tutor_id=long.Parse(row["Tutor_id"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
				}
				if(row["Title_id"]!=null && row["Title_id"].ToString()!="")
				{
					model.Title_id=int.Parse(row["Title_id"].ToString());
				}
				if(row["Subject"]!=null)
				{
					model.Subject=row["Subject"].ToString();
				}
				if(row["Tutor_email"]!=null)
				{
					model.Tutor_email=row["Tutor_email"].ToString();
				}
				if(row["Tutor_fixedphone"]!=null)
				{
					model.Tutor_fixedphone=row["Tutor_fixedphone"].ToString();
				}
				if(row["Tutor_location"]!=null)
				{
					model.Tutor_location=row["Tutor_location"].ToString();
				}
				if(row["Tutor_introduce"]!=null)
				{
					model.Tutor_introduce=row["Tutor_introduce"].ToString();
				}
				if(row["Tutor_picture"]!=null)
				{
					model.Tutor_picture=row["Tutor_picture"].ToString();
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
			strSql.Append("select Tutor_id,User_id,Title_id,Subject,Tutor_email,Tutor_fixedphone,Tutor_location,Tutor_introduce,Tutor_picture ");
			strSql.Append(" FROM Tutor ");
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
			strSql.Append(" Tutor_id,User_id,Title_id,Subject,Tutor_email,Tutor_fixedphone,Tutor_location,Tutor_introduce,Tutor_picture ");
			strSql.Append(" FROM Tutor ");
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
			strSql.Append("select count(1) FROM Tutor ");
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
				strSql.Append("order by T.Tutor_id desc");
			}
			strSql.Append(")AS Row, T.*  from Tutor T ");
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
			parameters[0].Value = "Tutor";
			parameters[1].Value = "Tutor_id";
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

