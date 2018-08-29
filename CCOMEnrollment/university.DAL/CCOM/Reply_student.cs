using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Reply_student
	/// </summary>
	public partial class Reply_student
	{
		public Reply_student()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Rs_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Reply_student");
			strSql.Append(" where Rs_id=@Rs_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Rs_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Rs_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Reply_student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Reply_student(");
			strSql.Append("Group_id,User_id)");
			strSql.Append(" values (");
			strSql.Append("@Group_id,@User_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Group_id;
			parameters[1].Value = model.User_id;

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
		public bool Update(university.Model.CCOM.Reply_student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Reply_student set ");
			strSql.Append("Group_id=@Group_id,");
			strSql.Append("User_id=@User_id");
			strSql.Append(" where Rs_id=@Rs_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Rs_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Group_id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.Rs_id;

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
		public bool Delete(long Rs_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply_student ");
			strSql.Append(" where Rs_id=@Rs_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Rs_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Rs_id;

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
		public bool DeleteList(string Rs_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply_student ");
			strSql.Append(" where Rs_id in ("+Rs_idlist + ")  ");
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
		public university.Model.CCOM.Reply_student GetModel(long Rs_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Rs_id,Group_id,User_id from Reply_student ");
			strSql.Append(" where Rs_id=@Rs_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Rs_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Rs_id;

			university.Model.CCOM.Reply_student model=new university.Model.CCOM.Reply_student();
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
        public university.Model.CCOM.Reply_student GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Rs_id,Group_id,User_id from Reply_student ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Reply_student model = new university.Model.CCOM.Reply_student();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Rs_id"] != null && ds.Tables[0].Rows[0]["Rs_id"].ToString() != "")
                {
                    model.Rs_id = long.Parse(ds.Tables[0].Rows[0]["Rs_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Group_id"] != null && ds.Tables[0].Rows[0]["Group_id"].ToString() != "")
                {
                    model.Group_id = long.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
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
		public university.Model.CCOM.Reply_student DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Reply_student model=new university.Model.CCOM.Reply_student();
			if (row != null)
			{
				if(row["Rs_id"]!=null && row["Rs_id"].ToString()!="")
				{
					model.Rs_id=long.Parse(row["Rs_id"].ToString());
				}
				if(row["Group_id"]!=null && row["Group_id"].ToString()!="")
				{
					model.Group_id=long.Parse(row["Group_id"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
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
			strSql.Append("select Rs_id,Group_id,User_id ");
			strSql.Append(" FROM Reply_student ");
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
			strSql.Append(" Rs_id,Group_id,User_id ");
			strSql.Append(" FROM Reply_student ");
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
			strSql.Append("select count(1) FROM Reply_student ");
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
				strSql.Append("order by T.Rs_id desc");
			}
			strSql.Append(")AS Row, T.*  from Reply_student T ");
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
			parameters[0].Value = "Reply_student";
			parameters[1].Value = "Rs_id";
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

