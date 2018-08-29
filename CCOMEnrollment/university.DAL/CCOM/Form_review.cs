using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Form_review
	/// </summary>
	public partial class Form_review
	{
		public Form_review()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Form_review_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Form_review");
			strSql.Append(" where Form_review_id=@Form_review_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Form_review_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Form_review_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Form_review model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Form_review(");
			strSql.Append("User_id,Form_type_id,Review_result)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Form_type_id,@Review_result)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Form_type_id", SqlDbType.Int,4),
					new SqlParameter("@Review_result", SqlDbType.Int,4)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Form_type_id;
			parameters[2].Value = model.Review_result;

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
		public bool Update(university.Model.CCOM.Form_review model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Form_review set ");
			strSql.Append("User_id=@User_id,");
			strSql.Append("Form_type_id=@Form_type_id,");
			strSql.Append("Review_result=@Review_result");
			strSql.Append(" where Form_review_id=@Form_review_id");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Form_type_id", SqlDbType.Int,4),
					new SqlParameter("@Review_result", SqlDbType.Int,4),
					new SqlParameter("@Form_review_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.User_id;
			parameters[1].Value = model.Form_type_id;
			parameters[2].Value = model.Review_result;
			parameters[3].Value = model.Form_review_id;

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
		public bool Delete(long Form_review_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Form_review ");
			strSql.Append(" where Form_review_id=@Form_review_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Form_review_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Form_review_id;

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
		public bool DeleteList(string Form_review_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Form_review ");
			strSql.Append(" where Form_review_id in ("+Form_review_idlist + ")  ");
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
		public university.Model.CCOM.Form_review GetModel(long Form_review_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Form_review_id,User_id,Form_type_id,Review_result from Form_review ");
			strSql.Append(" where Form_review_id=@Form_review_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Form_review_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Form_review_id;

			university.Model.CCOM.Form_review model=new university.Model.CCOM.Form_review();
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
        public university.Model.CCOM.Form_review GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Form_review_id,User_id,Form_type_id,Review_result  ");
            strSql.Append("  from Form_review ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Form_review model = new university.Model.CCOM.Form_review();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Form_review_id"] != null && ds.Tables[0].Rows[0]["Form_review_id"].ToString() != "")
                {
                    model.Form_review_id = long.Parse(ds.Tables[0].Rows[0]["Form_review_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Form_type_id"] != null && ds.Tables[0].Rows[0]["Form_type_id"].ToString() != "")
                {
                    model.Form_type_id = int.Parse(ds.Tables[0].Rows[0]["Form_type_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Review_result"] != null && ds.Tables[0].Rows[0]["Review_result"].ToString() != "")
                {
                    model.Review_result = int.Parse(ds.Tables[0].Rows[0]["Review_result"].ToString());
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
		public university.Model.CCOM.Form_review DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Form_review model=new university.Model.CCOM.Form_review();
			if (row != null)
			{
				if(row["Form_review_id"]!=null && row["Form_review_id"].ToString()!="")
				{
					model.Form_review_id=long.Parse(row["Form_review_id"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
				}
				if(row["Form_type_id"]!=null && row["Form_type_id"].ToString()!="")
				{
					model.Form_type_id=int.Parse(row["Form_type_id"].ToString());
				}
				if(row["Review_result"]!=null && row["Review_result"].ToString()!="")
				{
					model.Review_result=int.Parse(row["Review_result"].ToString());
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
			strSql.Append("select Form_review_id,User_id,Form_type_id,Review_result ");
			strSql.Append(" FROM Form_review ");
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
			strSql.Append(" Form_review_id,User_id,Form_type_id,Review_result ");
			strSql.Append(" FROM Form_review ");
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
			strSql.Append("select count(1) FROM Form_review ");
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
				strSql.Append("order by T.Form_review_id desc");
			}
			strSql.Append(")AS Row, T.*  from Form_review T ");
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
			parameters[0].Value = "Form_review";
			parameters[1].Value = "Form_review_id";
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

