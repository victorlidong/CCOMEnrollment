using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Achievement_degree
	/// </summary>
	public partial class Achievement_degree
	{
		public Achievement_degree()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Ac_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Achievement_degree");
			strSql.Append(" where Ac_id=@Ac_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Ac_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ac_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Achievement_degree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Achievement_degree(");
			strSql.Append("Topic_relation_id,Assess_type,Require_one,Require_two,Require_three,Require_four,Require_five,Require_six)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Assess_type,@Require_one,@Require_two,@Require_three,@Require_four,@Require_five,@Require_six)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Assess_type", SqlDbType.Bit,1),
					new SqlParameter("@Require_one", SqlDbType.Int,4),
					new SqlParameter("@Require_two", SqlDbType.Int,4),
					new SqlParameter("@Require_three", SqlDbType.Int,4),
					new SqlParameter("@Require_four", SqlDbType.Int,4),
					new SqlParameter("@Require_five", SqlDbType.Int,4),
					new SqlParameter("@Require_six", SqlDbType.Int,4)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Assess_type;
			parameters[2].Value = model.Require_one;
			parameters[3].Value = model.Require_two;
			parameters[4].Value = model.Require_three;
			parameters[5].Value = model.Require_four;
			parameters[6].Value = model.Require_five;
			parameters[7].Value = model.Require_six;

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
		public bool Update(university.Model.CCOM.Achievement_degree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Achievement_degree set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Assess_type=@Assess_type,");
			strSql.Append("Require_one=@Require_one,");
			strSql.Append("Require_two=@Require_two,");
			strSql.Append("Require_three=@Require_three,");
			strSql.Append("Require_four=@Require_four,");
			strSql.Append("Require_five=@Require_five,");
			strSql.Append("Require_six=@Require_six");
			strSql.Append(" where Ac_id=@Ac_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Assess_type", SqlDbType.Bit,1),
					new SqlParameter("@Require_one", SqlDbType.Int,4),
					new SqlParameter("@Require_two", SqlDbType.Int,4),
					new SqlParameter("@Require_three", SqlDbType.Int,4),
					new SqlParameter("@Require_four", SqlDbType.Int,4),
					new SqlParameter("@Require_five", SqlDbType.Int,4),
					new SqlParameter("@Require_six", SqlDbType.Int,4),
					new SqlParameter("@Ac_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Assess_type;
			parameters[2].Value = model.Require_one;
			parameters[3].Value = model.Require_two;
			parameters[4].Value = model.Require_three;
			parameters[5].Value = model.Require_four;
			parameters[6].Value = model.Require_five;
			parameters[7].Value = model.Require_six;
			parameters[8].Value = model.Ac_id;

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
		public bool Delete(long Ac_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Achievement_degree ");
			strSql.Append(" where Ac_id=@Ac_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Ac_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ac_id;

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
		public bool DeleteList(string Ac_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Achievement_degree ");
			strSql.Append(" where Ac_id in ("+Ac_idlist + ")  ");
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
		public university.Model.CCOM.Achievement_degree GetModel(long Ac_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Ac_id,Topic_relation_id,Assess_type,Require_one,Require_two,Require_three,Require_four,Require_five,Require_six from Achievement_degree ");
			strSql.Append(" where Ac_id=@Ac_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Ac_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ac_id;

			university.Model.CCOM.Achievement_degree model=new university.Model.CCOM.Achievement_degree();
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
        public university.Model.CCOM.Achievement_degree GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Ac_id,Topic_relation_id,Assess_type,Require_one,Require_two,Require_three,Require_four,Require_five,Require_six from Achievement_degree ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Achievement_degree model = new university.Model.CCOM.Achievement_degree();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["Ac_id"] != null && ds.Tables[0].Rows[0]["Ac_id"].ToString() != "")
                {
                    model.Ac_id = long.Parse(ds.Tables[0].Rows[0]["Ac_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Assess_type"] != null && ds.Tables[0].Rows[0]["Assess_type"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Assess_type"].ToString() == "1") || (ds.Tables[0].Rows[0]["Assess_type"].ToString().ToLower() == "true"))
                    {
                        model.Assess_type = true;
                    }
                    else
                    {
                        model.Assess_type = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Require_one"] != null && ds.Tables[0].Rows[0]["Require_one"].ToString() != "")
                {
                    model.Require_one = int.Parse(ds.Tables[0].Rows[0]["Require_one"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Require_two"] != null && ds.Tables[0].Rows[0]["Require_two"].ToString() != "")
                {
                    model.Require_two = int.Parse(ds.Tables[0].Rows[0]["Require_two"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Require_three"] != null && ds.Tables[0].Rows[0]["Require_three"].ToString() != "")
                {
                    model.Require_three = int.Parse(ds.Tables[0].Rows[0]["Require_three"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Require_four"] != null && ds.Tables[0].Rows[0]["Require_four"].ToString() != "")
                {
                    model.Require_four = int.Parse(ds.Tables[0].Rows[0]["Require_four"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Require_five"] != null && ds.Tables[0].Rows[0]["Require_five"].ToString() != "")
                {
                    model.Require_five = int.Parse(ds.Tables[0].Rows[0]["Require_five"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Require_six"] != null && ds.Tables[0].Rows[0]["Require_six"].ToString() != "")
                {
                    model.Require_six = int.Parse(ds.Tables[0].Rows[0]["Require_six"].ToString());
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
		public university.Model.CCOM.Achievement_degree DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Achievement_degree model=new university.Model.CCOM.Achievement_degree();
			if (row != null)
			{
				if(row["Ac_id"]!=null && row["Ac_id"].ToString()!="")
				{
					model.Ac_id=long.Parse(row["Ac_id"].ToString());
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Assess_type"]!=null && row["Assess_type"].ToString()!="")
				{
					if((row["Assess_type"].ToString()=="1")||(row["Assess_type"].ToString().ToLower()=="true"))
					{
						model.Assess_type=true;
					}
					else
					{
						model.Assess_type=false;
					}
				}
				if(row["Require_one"]!=null && row["Require_one"].ToString()!="")
				{
					model.Require_one=int.Parse(row["Require_one"].ToString());
				}
				if(row["Require_two"]!=null && row["Require_two"].ToString()!="")
				{
					model.Require_two=int.Parse(row["Require_two"].ToString());
				}
				if(row["Require_three"]!=null && row["Require_three"].ToString()!="")
				{
					model.Require_three=int.Parse(row["Require_three"].ToString());
				}
				if(row["Require_four"]!=null && row["Require_four"].ToString()!="")
				{
					model.Require_four=int.Parse(row["Require_four"].ToString());
				}
				if(row["Require_five"]!=null && row["Require_five"].ToString()!="")
				{
					model.Require_five=int.Parse(row["Require_five"].ToString());
				}
				if(row["Require_six"]!=null && row["Require_six"].ToString()!="")
				{
					model.Require_six=int.Parse(row["Require_six"].ToString());
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
			strSql.Append("select Ac_id,Topic_relation_id,Assess_type,Require_one,Require_two,Require_three,Require_four,Require_five,Require_six ");
			strSql.Append(" FROM Achievement_degree ");
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
			strSql.Append(" Ac_id,Topic_relation_id,Assess_type,Require_one,Require_two,Require_three,Require_four,Require_five,Require_six ");
			strSql.Append(" FROM Achievement_degree ");
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
			strSql.Append("select count(1) FROM Achievement_degree ");
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
				strSql.Append("order by T.Ac_id desc");
			}
			strSql.Append(")AS Row, T.*  from Achievement_degree T ");
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
			parameters[0].Value = "Achievement_degree";
			parameters[1].Value = "Ac_id";
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

