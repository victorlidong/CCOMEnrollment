using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Proposal
	/// </summary>
	public partial class Proposal
	{
		public Proposal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Proposal_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Proposal");
			strSql.Append(" where Proposal_id=@Proposal_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Proposal_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Proposal_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Proposal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Proposal(");
			strSql.Append("Topic_relation_id,Review,Score,Result)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Review,@Score,@Result)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Review", SqlDbType.Text),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Result", SqlDbType.Int,4)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Review;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.Result;

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
		public bool Update(university.Model.CCOM.Proposal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Proposal set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Review=@Review,");
			strSql.Append("Score=@Score,");
			strSql.Append("Result=@Result");
			strSql.Append(" where Proposal_id=@Proposal_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Review", SqlDbType.Text),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Result", SqlDbType.Int,4),
					new SqlParameter("@Proposal_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Review;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Proposal_id;

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
		public bool Delete(long Proposal_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Proposal ");
			strSql.Append(" where Proposal_id=@Proposal_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Proposal_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Proposal_id;

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
		public bool DeleteList(string Proposal_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Proposal ");
			strSql.Append(" where Proposal_id in ("+Proposal_idlist + ")  ");
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
		public university.Model.CCOM.Proposal GetModel(long Proposal_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Proposal_id,Topic_relation_id,Review,Score,Result from Proposal ");
			strSql.Append(" where Proposal_id=@Proposal_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Proposal_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Proposal_id;

			university.Model.CCOM.Proposal model=new university.Model.CCOM.Proposal();
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
        public university.Model.CCOM.Proposal GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Proposal_id,Topic_relation_id,Review,Score,Result  ");
            strSql.Append("  from Proposal ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Proposal model = new university.Model.CCOM.Proposal();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Proposal_id"] != null && ds.Tables[0].Rows[0]["Proposal_id"].ToString() != "")
                {
                    model.Proposal_id = long.Parse(ds.Tables[0].Rows[0]["Proposal_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Review"] != null)
                {
                    model.Review = ds.Tables[0].Rows[0]["Review"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Score"] != null && ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Result"] != null && ds.Tables[0].Rows[0]["Result"].ToString() != "")
                {
                    model.Result = int.Parse(ds.Tables[0].Rows[0]["Result"].ToString());
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
		public university.Model.CCOM.Proposal DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Proposal model=new university.Model.CCOM.Proposal();
			if (row != null)
			{
				if(row["Proposal_id"]!=null && row["Proposal_id"].ToString()!="")
				{
					model.Proposal_id=long.Parse(row["Proposal_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Review"]!=null)
				{
					model.Review=row["Review"].ToString();
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["Result"]!=null && row["Result"].ToString()!="")
				{
					model.Result=int.Parse(row["Result"].ToString());
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
			strSql.Append("select Proposal_id,Topic_relation_id,Review,Score,Result ");
			strSql.Append(" FROM Proposal ");
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
			strSql.Append(" Proposal_id,Topic_relation_id,Review,Score,Result ");
			strSql.Append(" FROM Proposal ");
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
			strSql.Append("select count(1) FROM Proposal ");
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
				strSql.Append("order by T.Proposal_id desc");
			}
			strSql.Append(")AS Row, T.*  from Proposal T ");
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
			parameters[0].Value = "Proposal";
			parameters[1].Value = "Proposal_id";
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

