using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Comment
	/// </summary>
	public partial class Comment
	{
		public Comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Comment_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Comment");
			strSql.Append(" where Comment_id=@Comment_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Comment_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Comment(");
			strSql.Append("Topic_relation_id,Teacher_comment,Reviewer_comment,problem,Comment_content,Reply_score,Teacher_score)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Teacher_comment,@Reviewer_comment,@problem,@Comment_content,@Reply_score,@Teacher_score)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_comment", SqlDbType.Text),
					new SqlParameter("@Reviewer_comment", SqlDbType.Text),
					new SqlParameter("@problem", SqlDbType.Text),
					new SqlParameter("@Comment_content", SqlDbType.Text),
					new SqlParameter("@Reply_score", SqlDbType.Int,4),
					new SqlParameter("@Teacher_score", SqlDbType.Int,4)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Teacher_comment;
			parameters[2].Value = model.Reviewer_comment;
			parameters[3].Value = model.problem;
			parameters[4].Value = model.Comment_content;
			parameters[5].Value = model.Reply_score;
			parameters[6].Value = model.Teacher_score;

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
		public bool Update(university.Model.CCOM.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Comment set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Teacher_comment=@Teacher_comment,");
			strSql.Append("Reviewer_comment=@Reviewer_comment,");
			strSql.Append("problem=@problem,");
			strSql.Append("Comment_content=@Comment_content,");
			strSql.Append("Reply_score=@Reply_score,");
			strSql.Append("Teacher_score=@Teacher_score");
			strSql.Append(" where Comment_id=@Comment_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_comment", SqlDbType.Text),
					new SqlParameter("@Reviewer_comment", SqlDbType.Text),
					new SqlParameter("@problem", SqlDbType.Text),
					new SqlParameter("@Comment_content", SqlDbType.Text),
					new SqlParameter("@Reply_score", SqlDbType.Int,4),
					new SqlParameter("@Teacher_score", SqlDbType.Int,4),
					new SqlParameter("@Comment_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Teacher_comment;
			parameters[2].Value = model.Reviewer_comment;
			parameters[3].Value = model.problem;
			parameters[4].Value = model.Comment_content;
			parameters[5].Value = model.Reply_score;
			parameters[6].Value = model.Teacher_score;
			parameters[7].Value = model.Comment_id;

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
		public bool Delete(long Comment_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Comment ");
			strSql.Append(" where Comment_id=@Comment_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Comment_id;

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
		public bool DeleteList(string Comment_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Comment ");
			strSql.Append(" where Comment_id in ("+Comment_idlist + ")  ");
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
		public university.Model.CCOM.Comment GetModel(long Comment_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Comment_id,Topic_relation_id,Teacher_comment,Reviewer_comment,problem,Comment_content,Reply_score,Teacher_score from Comment ");
			strSql.Append(" where Comment_id=@Comment_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Comment_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Comment_id;

			university.Model.CCOM.Comment model=new university.Model.CCOM.Comment();
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
        public university.Model.CCOM.Comment GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Comment_id,Topic_relation_id,Teacher_comment,Reviewer_comment,problem,Comment_content,Reply_score,Teacher_score from Comment ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Comment model = new university.Model.CCOM.Comment();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Comment_id"] != null && ds.Tables[0].Rows[0]["Comment_id"].ToString() != "")
                {
                    model.Comment_id = long.Parse(ds.Tables[0].Rows[0]["Comment_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Teacher_comment"] != null)
                {
                    model.Teacher_comment = ds.Tables[0].Rows[0]["Teacher_comment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Reviewer_comment"] != null)
                {
                    model.Reviewer_comment = ds.Tables[0].Rows[0]["Reviewer_comment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["problem"] != null)
                {
                    model.problem = ds.Tables[0].Rows[0]["problem"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Comment_content"] != null)
                {
                    model.Comment_content = ds.Tables[0].Rows[0]["Comment_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Reply_score"] != null && ds.Tables[0].Rows[0]["Reply_score"].ToString() != "")
                {
                    model.Reply_score = int.Parse(ds.Tables[0].Rows[0]["Reply_score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Teacher_score"] != null && ds.Tables[0].Rows[0]["Teacher_score"].ToString() != "")
                {
                    model.Teacher_score = int.Parse(ds.Tables[0].Rows[0]["Teacher_score"].ToString());
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
		public university.Model.CCOM.Comment DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Comment model=new university.Model.CCOM.Comment();
			if (row != null)
			{
				if(row["Comment_id"]!=null && row["Comment_id"].ToString()!="")
				{
					model.Comment_id=long.Parse(row["Comment_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Teacher_comment"]!=null)
				{
					model.Teacher_comment=row["Teacher_comment"].ToString();
				}
				if(row["Reviewer_comment"]!=null)
				{
					model.Reviewer_comment=row["Reviewer_comment"].ToString();
				}
				if(row["problem"]!=null)
				{
					model.problem=row["problem"].ToString();
				}
				if(row["Comment_content"]!=null)
				{
					model.Comment_content=row["Comment_content"].ToString();
				}
				if(row["Reply_score"]!=null && row["Reply_score"].ToString()!="")
				{
					model.Reply_score=int.Parse(row["Reply_score"].ToString());
				}
				if(row["Teacher_score"]!=null && row["Teacher_score"].ToString()!="")
				{
					model.Teacher_score=int.Parse(row["Teacher_score"].ToString());
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
			strSql.Append("select Comment_id,Topic_relation_id,Teacher_comment,Reviewer_comment,problem,Comment_content,Reply_score,Teacher_score ");
			strSql.Append(" FROM Comment ");
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
			strSql.Append(" Comment_id,Topic_relation_id,Teacher_comment,Reviewer_comment,problem,Comment_content,Reply_score,Teacher_score ");
			strSql.Append(" FROM Comment ");
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
			strSql.Append("select count(1) FROM Comment ");
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
				strSql.Append("order by T.Comment_id desc");
			}
			strSql.Append(")AS Row, T.*  from Comment T ");
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
			parameters[0].Value = "Comment";
			parameters[1].Value = "Comment_id";
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

