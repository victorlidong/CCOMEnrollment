using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Software_accept
	/// </summary>
	public partial class Software_accept
	{
		public Software_accept()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Sa_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Software_accept");
			strSql.Append(" where Sa_id=@Sa_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Sa_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Sa_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Software_accept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Software_accept(");
			strSql.Append("Topic_relation_id,Data_list,anguage,Environmental,Line_count,Line_hand,Run_status,Feature,Conclusion,Time)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Data_list,@anguage,@Environmental,@Line_count,@Line_hand,@Run_status,@Feature,@Conclusion,@Time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Data_list", SqlDbType.Text),
					new SqlParameter("@anguage", SqlDbType.Text),
					new SqlParameter("@Environmental", SqlDbType.Text),
					new SqlParameter("@Line_count", SqlDbType.Text),
					new SqlParameter("@Line_hand", SqlDbType.Text),
					new SqlParameter("@Run_status", SqlDbType.Text),
					new SqlParameter("@Feature", SqlDbType.Text),
					new SqlParameter("@Conclusion", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.Date,3)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Data_list;
			parameters[2].Value = model.anguage;
			parameters[3].Value = model.Environmental;
			parameters[4].Value = model.Line_count;
			parameters[5].Value = model.Line_hand;
			parameters[6].Value = model.Run_status;
			parameters[7].Value = model.Feature;
			parameters[8].Value = model.Conclusion;
			parameters[9].Value = model.Time;

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
		public bool Update(university.Model.CCOM.Software_accept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Software_accept set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Data_list=@Data_list,");
			strSql.Append("anguage=@anguage,");
			strSql.Append("Environmental=@Environmental,");
			strSql.Append("Line_count=@Line_count,");
			strSql.Append("Line_hand=@Line_hand,");
			strSql.Append("Run_status=@Run_status,");
			strSql.Append("Feature=@Feature,");
			strSql.Append("Conclusion=@Conclusion,");
			strSql.Append("Time=@Time");
			strSql.Append(" where Sa_id=@Sa_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Data_list", SqlDbType.Text),
					new SqlParameter("@anguage", SqlDbType.Text),
					new SqlParameter("@Environmental", SqlDbType.Text),
					new SqlParameter("@Line_count", SqlDbType.Text),
					new SqlParameter("@Line_hand", SqlDbType.Text),
					new SqlParameter("@Run_status", SqlDbType.Text),
					new SqlParameter("@Feature", SqlDbType.Text),
					new SqlParameter("@Conclusion", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.Date,3),
					new SqlParameter("@Sa_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Data_list;
			parameters[2].Value = model.anguage;
			parameters[3].Value = model.Environmental;
			parameters[4].Value = model.Line_count;
			parameters[5].Value = model.Line_hand;
			parameters[6].Value = model.Run_status;
			parameters[7].Value = model.Feature;
			parameters[8].Value = model.Conclusion;
			parameters[9].Value = model.Time;
			parameters[10].Value = model.Sa_id;

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
		public bool Delete(long Sa_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Software_accept ");
			strSql.Append(" where Sa_id=@Sa_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Sa_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Sa_id;

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
		public bool DeleteList(string Sa_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Software_accept ");
			strSql.Append(" where Sa_id in ("+Sa_idlist + ")  ");
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
		public university.Model.CCOM.Software_accept GetModel(long Sa_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sa_id,Topic_relation_id,Data_list,anguage,Environmental,Line_count,Line_hand,Run_status,Feature,Conclusion,Time from Software_accept ");
			strSql.Append(" where Sa_id=@Sa_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Sa_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Sa_id;

			university.Model.CCOM.Software_accept model=new university.Model.CCOM.Software_accept();
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
        public university.Model.CCOM.Software_accept GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Sa_id,Topic_relation_id,Data_list,anguage,Environmental,Line_count,Line_hand,Run_status,Feature,Conclusion,Time ");
            strSql.Append(" FROM Software_accept ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Software_accept model = new university.Model.CCOM.Software_accept();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Sa_id"] != null && ds.Tables[0].Rows[0]["Sa_id"].ToString() != "")
                {
                    model.Sa_id = long.Parse(ds.Tables[0].Rows[0]["Sa_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Data_list"] != null)
                {
                    model.Data_list = ds.Tables[0].Rows[0]["Data_list"].ToString();
                }
                if (ds.Tables[0].Rows[0]["anguage"] != null)
                {
                    model.anguage = ds.Tables[0].Rows[0]["anguage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Environmental"] != null)
                {
                    model.Environmental = ds.Tables[0].Rows[0]["Environmental"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Line_count"] != null)
                {
                    model.Line_count = ds.Tables[0].Rows[0]["Line_count"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Line_hand"] != null)
                {
                    model.Line_hand = ds.Tables[0].Rows[0]["Line_hand"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Run_status"] != null)
                {
                    model.Run_status = ds.Tables[0].Rows[0]["Run_status"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Feature"] != null)
                {
                    model.Feature = ds.Tables[0].Rows[0]["Feature"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Conclusion"] != null && ds.Tables[0].Rows[0]["Conclusion"].ToString() != "")
                {
                    model.Conclusion = int.Parse(ds.Tables[0].Rows[0]["Conclusion"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Time"] != null && ds.Tables[0].Rows[0]["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(ds.Tables[0].Rows[0]["Time"].ToString());
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
		public university.Model.CCOM.Software_accept DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Software_accept model=new university.Model.CCOM.Software_accept();
			if (row != null)
			{
				if(row["Sa_id"]!=null && row["Sa_id"].ToString()!="")
				{
					model.Sa_id=long.Parse(row["Sa_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Data_list"]!=null)
				{
					model.Data_list=row["Data_list"].ToString();
				}
				if(row["anguage"]!=null)
				{
					model.anguage=row["anguage"].ToString();
				}
				if(row["Environmental"]!=null)
				{
					model.Environmental=row["Environmental"].ToString();
				}
				if(row["Line_count"]!=null)
				{
					model.Line_count=row["Line_count"].ToString();
				}
				if(row["Line_hand"]!=null)
				{
					model.Line_hand=row["Line_hand"].ToString();
				}
				if(row["Run_status"]!=null)
				{
					model.Run_status=row["Run_status"].ToString();
				}
				if(row["Feature"]!=null)
				{
					model.Feature=row["Feature"].ToString();
				}
				if(row["Conclusion"]!=null && row["Conclusion"].ToString()!="")
				{
					model.Conclusion=int.Parse(row["Conclusion"].ToString());
				}
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=DateTime.Parse(row["Time"].ToString());
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
			strSql.Append("select Sa_id,Topic_relation_id,Data_list,anguage,Environmental,Line_count,Line_hand,Run_status,Feature,Conclusion,Time ");
			strSql.Append(" FROM Software_accept ");
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
			strSql.Append(" Sa_id,Topic_relation_id,Data_list,anguage,Environmental,Line_count,Line_hand,Run_status,Feature,Conclusion,Time ");
			strSql.Append(" FROM Software_accept ");
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
			strSql.Append("select count(1) FROM Software_accept ");
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
				strSql.Append("order by T.Sa_id desc");
			}
			strSql.Append(")AS Row, T.*  from Software_accept T ");
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
			parameters[0].Value = "Software_accept";
			parameters[1].Value = "Sa_id";
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

