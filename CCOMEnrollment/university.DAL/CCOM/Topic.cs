using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Topic
	/// </summary>
	public partial class Topic
	{
		public Topic()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Topic_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Topic");
			strSql.Append(" where Topic_id=@Topic_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Topic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Topic(");
			strSql.Append("Topic_name,Teacher_id,Company,Topic_nature,Topic_source,Topic_content,Topic_task,Selected_state,Check_state,Period_id)");
			strSql.Append(" values (");
			strSql.Append("@Topic_name,@Teacher_id,@Company,@Topic_nature,@Topic_source,@Topic_content,@Topic_task,@Selected_state,@Check_state,@Period_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_name", SqlDbType.VarChar,128),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Company", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_nature", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_source", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_content", SqlDbType.Text),
					new SqlParameter("@Topic_task", SqlDbType.Text),
					new SqlParameter("@Selected_state", SqlDbType.Bit,1),
					new SqlParameter("@Check_state", SqlDbType.Int,4),
					new SqlParameter("@Period_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Topic_name;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.Company;
			parameters[3].Value = model.Topic_nature;
			parameters[4].Value = model.Topic_source;
			parameters[5].Value = model.Topic_content;
			parameters[6].Value = model.Topic_task;
			parameters[7].Value = model.Selected_state;
			parameters[8].Value = model.Check_state;
			parameters[9].Value = model.Period_id;

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
		public bool Update(university.Model.CCOM.Topic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Topic set ");
			strSql.Append("Topic_name=@Topic_name,");
			strSql.Append("Teacher_id=@Teacher_id,");
			strSql.Append("Company=@Company,");
			strSql.Append("Topic_nature=@Topic_nature,");
			strSql.Append("Topic_source=@Topic_source,");
			strSql.Append("Topic_content=@Topic_content,");
			strSql.Append("Topic_task=@Topic_task,");
			strSql.Append("Selected_state=@Selected_state,");
			strSql.Append("Check_state=@Check_state,");
			strSql.Append("Period_id=@Period_id");
			strSql.Append(" where Topic_id=@Topic_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_name", SqlDbType.VarChar,128),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Company", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_nature", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_source", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_content", SqlDbType.Text),
					new SqlParameter("@Topic_task", SqlDbType.Text),
					new SqlParameter("@Selected_state", SqlDbType.Bit,1),
					new SqlParameter("@Check_state", SqlDbType.Int,4),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Topic_name;
			parameters[1].Value = model.Teacher_id;
			parameters[2].Value = model.Company;
			parameters[3].Value = model.Topic_nature;
			parameters[4].Value = model.Topic_source;
			parameters[5].Value = model.Topic_content;
			parameters[6].Value = model.Topic_task;
			parameters[7].Value = model.Selected_state;
			parameters[8].Value = model.Check_state;
			parameters[9].Value = model.Period_id;
			parameters[10].Value = model.Topic_id;

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
		public bool Delete(long Topic_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic ");
			strSql.Append(" where Topic_id=@Topic_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_id;

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
		public bool DeleteList(string Topic_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic ");
			strSql.Append(" where Topic_id in ("+Topic_idlist + ")  ");
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
		public university.Model.CCOM.Topic GetModel(long Topic_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Topic_id,Topic_name,Teacher_id,Company,Topic_nature,Topic_source,Topic_content,Topic_task,Selected_state,Check_state,Period_id from Topic ");
			strSql.Append(" where Topic_id=@Topic_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Topic_id;

			university.Model.CCOM.Topic model=new university.Model.CCOM.Topic();
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
        public university.Model.CCOM.Topic GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Topic_id,Topic_name,Teacher_id,Company,Topic_nature,Topic_source,Topic_content,Topic_task,Selected_state,Check_state,Period_id  ");
            strSql.Append("  from Topic ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Topic model = new university.Model.CCOM.Topic();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Topic_id"] != null && ds.Tables[0].Rows[0]["Topic_id"].ToString() != "")
                {
                    model.Topic_id = long.Parse(ds.Tables[0].Rows[0]["Topic_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_name"] != null)
                {
                    model.Topic_name = ds.Tables[0].Rows[0]["Topic_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Teacher_id"] != null && ds.Tables[0].Rows[0]["Teacher_id"].ToString() != "")
                {
                    model.Teacher_id = long.Parse(ds.Tables[0].Rows[0]["Teacher_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Company"] != null)
                {
                    model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Topic_nature"] != null)
                {
                    model.Topic_nature = ds.Tables[0].Rows[0]["Topic_nature"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Topic_source"] != null)
                {
                    model.Topic_source = ds.Tables[0].Rows[0]["Topic_source"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Topic_content"] != null)
                {
                    model.Topic_content = ds.Tables[0].Rows[0]["Topic_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Topic_task"] != null)
                {
                    model.Topic_task = ds.Tables[0].Rows[0]["Topic_task"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Selected_state"] != null && ds.Tables[0].Rows[0]["Selected_state"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Selected_state"].ToString() == "1") || (ds.Tables[0].Rows[0]["Selected_state"].ToString().ToLower() == "true"))
                    {
                        model.Selected_state = true;
                    }
                    else
                    {
                        model.Selected_state = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Check_state"] != null && ds.Tables[0].Rows[0]["Check_state"].ToString() != "")
                {
                    model.Check_state = int.Parse(ds.Tables[0].Rows[0]["Check_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Period_id"] != null && ds.Tables[0].Rows[0]["Period_id"].ToString() != "")
                {
                    model.Period_id = int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
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
		public university.Model.CCOM.Topic DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Topic model=new university.Model.CCOM.Topic();
			if (row != null)
			{
				if(row["Topic_id"]!=null && row["Topic_id"].ToString()!="")
				{
					model.Topic_id=long.Parse(row["Topic_id"].ToString());
				}
				if(row["Topic_name"]!=null)
				{
					model.Topic_name=row["Topic_name"].ToString();
				}
				if(row["Teacher_id"]!=null && row["Teacher_id"].ToString()!="")
				{
					model.Teacher_id=long.Parse(row["Teacher_id"].ToString());
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Topic_nature"]!=null)
				{
					model.Topic_nature=row["Topic_nature"].ToString();
				}
				if(row["Topic_source"]!=null)
				{
					model.Topic_source=row["Topic_source"].ToString();
				}
				if(row["Topic_content"]!=null)
				{
					model.Topic_content=row["Topic_content"].ToString();
				}
				if(row["Topic_task"]!=null)
				{
					model.Topic_task=row["Topic_task"].ToString();
				}
				if(row["Selected_state"]!=null && row["Selected_state"].ToString()!="")
				{
					if((row["Selected_state"].ToString()=="1")||(row["Selected_state"].ToString().ToLower()=="true"))
					{
						model.Selected_state=true;
					}
					else
					{
						model.Selected_state=false;
					}
				}
				if(row["Check_state"]!=null && row["Check_state"].ToString()!="")
				{
					model.Check_state=int.Parse(row["Check_state"].ToString());
				}
				if(row["Period_id"]!=null && row["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(row["Period_id"].ToString());
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
			strSql.Append("select Topic_id,Topic_name,Teacher_id,Company,Topic_nature,Topic_source,Topic_content,Topic_task,Selected_state,Check_state,Period_id ");
			strSql.Append(" FROM Topic ");
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
			strSql.Append(" Topic_id,Topic_name,Teacher_id,Company,Topic_nature,Topic_source,Topic_content,Topic_task,Selected_state,Check_state,Period_id ");
			strSql.Append(" FROM Topic ");
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
			strSql.Append("select count(1) FROM Topic ");
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
				strSql.Append("order by T.Topic_id desc");
			}
			strSql.Append(")AS Row, T.*  from Topic T ");
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
			parameters[0].Value = "Topic";
			parameters[1].Value = "Topic_id";
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

