using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Tracking_evaluation
	/// </summary>
	public partial class Tracking_evaluation
	{
		public Tracking_evaluation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Te_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tracking_evaluation");
			strSql.Append(" where Te_id=@Te_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Te_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Te_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Tracking_evaluation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tracking_evaluation(");
			strSql.Append("Topic_relation_id,Track_one,Track_two,Track_three,Track_four,Track_five,Track_six)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Track_one,@Track_two,@Track_three,@Track_four,@Track_five,@Track_six)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Track_one", SqlDbType.Int,4),
					new SqlParameter("@Track_two", SqlDbType.Int,4),
					new SqlParameter("@Track_three", SqlDbType.Int,4),
					new SqlParameter("@Track_four", SqlDbType.Int,4),
					new SqlParameter("@Track_five", SqlDbType.Int,4),
					new SqlParameter("@Track_six", SqlDbType.Int,4)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Track_one;
			parameters[2].Value = model.Track_two;
			parameters[3].Value = model.Track_three;
			parameters[4].Value = model.Track_four;
			parameters[5].Value = model.Track_five;
			parameters[6].Value = model.Track_six;

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
		public bool Update(university.Model.CCOM.Tracking_evaluation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tracking_evaluation set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Track_one=@Track_one,");
			strSql.Append("Track_two=@Track_two,");
			strSql.Append("Track_three=@Track_three,");
			strSql.Append("Track_four=@Track_four,");
			strSql.Append("Track_five=@Track_five,");
			strSql.Append("Track_six=@Track_six");
			strSql.Append(" where Te_id=@Te_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Track_one", SqlDbType.Int,4),
					new SqlParameter("@Track_two", SqlDbType.Int,4),
					new SqlParameter("@Track_three", SqlDbType.Int,4),
					new SqlParameter("@Track_four", SqlDbType.Int,4),
					new SqlParameter("@Track_five", SqlDbType.Int,4),
					new SqlParameter("@Track_six", SqlDbType.Int,4),
					new SqlParameter("@Te_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Track_one;
			parameters[2].Value = model.Track_two;
			parameters[3].Value = model.Track_three;
			parameters[4].Value = model.Track_four;
			parameters[5].Value = model.Track_five;
			parameters[6].Value = model.Track_six;
			parameters[7].Value = model.Te_id;

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
		public bool Delete(long Te_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tracking_evaluation ");
			strSql.Append(" where Te_id=@Te_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Te_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Te_id;

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
		public bool DeleteList(string Te_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tracking_evaluation ");
			strSql.Append(" where Te_id in ("+Te_idlist + ")  ");
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
		public university.Model.CCOM.Tracking_evaluation GetModel(long Te_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Te_id,Topic_relation_id,Track_one,Track_two,Track_three,Track_four,Track_five,Track_six from Tracking_evaluation ");
			strSql.Append(" where Te_id=@Te_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Te_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Te_id;

			university.Model.CCOM.Tracking_evaluation model=new university.Model.CCOM.Tracking_evaluation();
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
        public university.Model.CCOM.Tracking_evaluation GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Te_id,Topic_relation_id,Track_one,Track_two,Track_three,Track_four,Track_five,Track_six ");
            strSql.Append(" FROM Tracking_evaluation ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Tracking_evaluation model = new university.Model.CCOM.Tracking_evaluation();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Te_id"] != null && ds.Tables[0].Rows[0]["Te_id"].ToString() != "")
                {
                    model.Te_id = long.Parse(ds.Tables[0].Rows[0]["Te_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_one"] != null && ds.Tables[0].Rows[0]["Track_one"].ToString() != "")
                {
                    model.Track_one = int.Parse(ds.Tables[0].Rows[0]["Track_one"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_two"] != null && ds.Tables[0].Rows[0]["Track_two"].ToString() != "")
                {
                    model.Track_two = int.Parse(ds.Tables[0].Rows[0]["Track_two"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_three"] != null && ds.Tables[0].Rows[0]["Track_three"].ToString() != "")
                {
                    model.Track_three = int.Parse(ds.Tables[0].Rows[0]["Track_three"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_four"] != null && ds.Tables[0].Rows[0]["Track_four"].ToString() != "")
                {
                    model.Track_four = int.Parse(ds.Tables[0].Rows[0]["Track_four"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_five"] != null && ds.Tables[0].Rows[0]["Track_five"].ToString() != "")
                {
                    model.Track_five = int.Parse(ds.Tables[0].Rows[0]["Track_five"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Track_six"] != null && ds.Tables[0].Rows[0]["Track_six"].ToString() != "")
                {
                    model.Track_six = int.Parse(ds.Tables[0].Rows[0]["Track_six"].ToString());
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
		public university.Model.CCOM.Tracking_evaluation DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Tracking_evaluation model=new university.Model.CCOM.Tracking_evaluation();
			if (row != null)
			{
				if(row["Te_id"]!=null && row["Te_id"].ToString()!="")
				{
					model.Te_id=long.Parse(row["Te_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Track_one"]!=null && row["Track_one"].ToString()!="")
				{
					model.Track_one=int.Parse(row["Track_one"].ToString());
				}
				if(row["Track_two"]!=null && row["Track_two"].ToString()!="")
				{
					model.Track_two=int.Parse(row["Track_two"].ToString());
				}
				if(row["Track_three"]!=null && row["Track_three"].ToString()!="")
				{
					model.Track_three=int.Parse(row["Track_three"].ToString());
				}
				if(row["Track_four"]!=null && row["Track_four"].ToString()!="")
				{
					model.Track_four=int.Parse(row["Track_four"].ToString());
				}
				if(row["Track_five"]!=null && row["Track_five"].ToString()!="")
				{
					model.Track_five=int.Parse(row["Track_five"].ToString());
				}
				if(row["Track_six"]!=null && row["Track_six"].ToString()!="")
				{
					model.Track_six=int.Parse(row["Track_six"].ToString());
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
			strSql.Append("select Te_id,Topic_relation_id,Track_one,Track_two,Track_three,Track_four,Track_five,Track_six ");
			strSql.Append(" FROM Tracking_evaluation ");
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
			strSql.Append(" Te_id,Topic_relation_id,Track_one,Track_two,Track_three,Track_four,Track_five,Track_six ");
			strSql.Append(" FROM Tracking_evaluation ");
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
			strSql.Append("select count(1) FROM Tracking_evaluation ");
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
				strSql.Append("order by T.Te_id desc");
			}
			strSql.Append(")AS Row, T.*  from Tracking_evaluation T ");
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
			parameters[0].Value = "Tracking_evaluation";
			parameters[1].Value = "Te_id";
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

