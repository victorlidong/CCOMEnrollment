using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Form_value
	/// </summary>
	public partial class Form_value
	{
		public Form_value()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Fv_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Form_value");
			strSql.Append(" where Fv_id=@Fv_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Fv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fv_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Form_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Form_value(");
			strSql.Append("User_id,Form_id,Self_value,Tea_value)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Form_id,@Self_value,@Tea_value)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Form_id", SqlDbType.Int,4),
					new SqlParameter("@Self_value", SqlDbType.Int,4),
					new SqlParameter("@Tea_value", SqlDbType.Int,4)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Form_id;
			parameters[2].Value = model.Self_value;
			parameters[3].Value = model.Tea_value;

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
		public bool Update(university.Model.CCOM.Form_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Form_value set ");
			strSql.Append("User_id=@User_id,");
			strSql.Append("Form_id=@Form_id,");
			strSql.Append("Self_value=@Self_value,");
			strSql.Append("Tea_value=@Tea_value");
			strSql.Append(" where Fv_id=@Fv_id");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Form_id", SqlDbType.Int,4),
					new SqlParameter("@Self_value", SqlDbType.Int,4),
					new SqlParameter("@Tea_value", SqlDbType.Int,4),
					new SqlParameter("@Fv_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Form_id;
			parameters[2].Value = model.Self_value;
			parameters[3].Value = model.Tea_value;
			parameters[4].Value = model.Fv_id;

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
		public bool Delete(long Fv_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Form_value ");
			strSql.Append(" where Fv_id=@Fv_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Fv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fv_id;

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
		public bool DeleteList(string Fv_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Form_value ");
			strSql.Append(" where Fv_id in ("+Fv_idlist + ")  ");
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
		public university.Model.CCOM.Form_value GetModel(long Fv_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Fv_id,User_id,Form_id,Self_value,Tea_value from Form_value ");
			strSql.Append(" where Fv_id=@Fv_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Fv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fv_id;

			university.Model.CCOM.Form_value model=new university.Model.CCOM.Form_value();
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
        public university.Model.CCOM.Form_value GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Fv_id,User_id,Form_id,Self_value,Tea_value  ");
            strSql.Append("  from Form_value ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Form_value model = new university.Model.CCOM.Form_value();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Fv_id"] != null && ds.Tables[0].Rows[0]["Fv_id"].ToString() != "")
                {
                    model.Fv_id = long.Parse(ds.Tables[0].Rows[0]["Fv_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Form_id"] != null && ds.Tables[0].Rows[0]["Form_id"].ToString() != "")
                {
                    model.Form_id = int.Parse(ds.Tables[0].Rows[0]["Form_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Self_value"] != null && ds.Tables[0].Rows[0]["Self_value"].ToString() != "")
                {
                    model.Self_value = int.Parse(ds.Tables[0].Rows[0]["Self_value"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tea_value"] != null && ds.Tables[0].Rows[0]["Tea_value"].ToString() != "")
                {
                    model.Tea_value = int.Parse(ds.Tables[0].Rows[0]["Tea_value"].ToString());
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
		public university.Model.CCOM.Form_value DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Form_value model=new university.Model.CCOM.Form_value();
			if (row != null)
			{
				if(row["Fv_id"]!=null && row["Fv_id"].ToString()!="")
				{
					model.Fv_id=long.Parse(row["Fv_id"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
				}
				if(row["Form_id"]!=null && row["Form_id"].ToString()!="")
				{
					model.Form_id=int.Parse(row["Form_id"].ToString());
				}
				if(row["Self_value"]!=null && row["Self_value"].ToString()!="")
				{
					model.Self_value=int.Parse(row["Self_value"].ToString());
				}
				if(row["Tea_value"]!=null && row["Tea_value"].ToString()!="")
				{
					model.Tea_value=int.Parse(row["Tea_value"].ToString());
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
			strSql.Append("select Fv_id,User_id,Form_id,Self_value,Tea_value ");
			strSql.Append(" FROM Form_value ");
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
			strSql.Append(" Fv_id,User_id,Form_id,Self_value,Tea_value ");
			strSql.Append(" FROM Form_value ");
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
			strSql.Append("select count(1) FROM Form_value ");
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
				strSql.Append("order by T.Fv_id desc");
			}
			strSql.Append(")AS Row, T.*  from Form_value T ");
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
			parameters[0].Value = "Form_value";
			parameters[1].Value = "Fv_id";
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

