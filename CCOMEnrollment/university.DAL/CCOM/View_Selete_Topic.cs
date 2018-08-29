
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:View_Selete_Topic
	/// </summary>
	public partial class View_Selete_Topic
	{
		public View_Selete_Topic()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(university.Model.CCOM.View_Selete_Topic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Selete_Topic(");
			strSql.Append("Topic_relation_id,Student_id,User_number,Student_name,Teacher_id,Teacher_name,Topic_id,Topic_name,Topic_nature,Topic_source,Check_state,Accept_state,Selected_state,Apply_time,Company,Topic_content,Topic_task,Period_id,advice)");
			strSql.Append(" values (");
			strSql.Append("@Topic_relation_id,@Student_id,@User_number,@Student_name,@Teacher_id,@Teacher_name,@Topic_id,@Topic_name,@Topic_nature,@Topic_source,@Check_state,@Accept_state,@Selected_state,@Apply_time,@Company,@Topic_content,@Topic_task,@Period_id,@advice)");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_number", SqlDbType.VarChar,16),
					new SqlParameter("@Student_name", SqlDbType.VarChar,128),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_nature", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_source", SqlDbType.VarChar,128),
					new SqlParameter("@Check_state", SqlDbType.Int,4),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@Selected_state", SqlDbType.Bit,1),
					new SqlParameter("@Apply_time", SqlDbType.Date,3),
					new SqlParameter("@Company", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_content", SqlDbType.Text),
					new SqlParameter("@Topic_task", SqlDbType.Text),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@advice", SqlDbType.Text)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Student_id;
			parameters[2].Value = model.User_number;
			parameters[3].Value = model.Student_name;
			parameters[4].Value = model.Teacher_id;
			parameters[5].Value = model.Teacher_name;
			parameters[6].Value = model.Topic_id;
			parameters[7].Value = model.Topic_name;
			parameters[8].Value = model.Topic_nature;
			parameters[9].Value = model.Topic_source;
			parameters[10].Value = model.Check_state;
			parameters[11].Value = model.Accept_state;
			parameters[12].Value = model.Selected_state;
			parameters[13].Value = model.Apply_time;
			parameters[14].Value = model.Company;
			parameters[15].Value = model.Topic_content;
			parameters[16].Value = model.Topic_task;
			parameters[17].Value = model.Period_id;
			parameters[18].Value = model.advice;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Selete_Topic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Selete_Topic set ");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Student_id=@Student_id,");
			strSql.Append("User_number=@User_number,");
			strSql.Append("Student_name=@Student_name,");
			strSql.Append("Teacher_id=@Teacher_id,");
			strSql.Append("Teacher_name=@Teacher_name,");
			strSql.Append("Topic_id=@Topic_id,");
			strSql.Append("Topic_name=@Topic_name,");
			strSql.Append("Topic_nature=@Topic_nature,");
			strSql.Append("Topic_source=@Topic_source,");
			strSql.Append("Check_state=@Check_state,");
			strSql.Append("Accept_state=@Accept_state,");
			strSql.Append("Selected_state=@Selected_state,");
			strSql.Append("Apply_time=@Apply_time,");
			strSql.Append("Company=@Company,");
			strSql.Append("Topic_content=@Topic_content,");
			strSql.Append("Topic_task=@Topic_task,");
			strSql.Append("Period_id=@Period_id,");
			strSql.Append("advice=@advice");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_number", SqlDbType.VarChar,16),
					new SqlParameter("@Student_name", SqlDbType.VarChar,128),
					new SqlParameter("@Teacher_id", SqlDbType.BigInt,8),
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_name", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_nature", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_source", SqlDbType.VarChar,128),
					new SqlParameter("@Check_state", SqlDbType.Int,4),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@Selected_state", SqlDbType.Bit,1),
					new SqlParameter("@Apply_time", SqlDbType.Date,3),
					new SqlParameter("@Company", SqlDbType.VarChar,128),
					new SqlParameter("@Topic_content", SqlDbType.Text),
					new SqlParameter("@Topic_task", SqlDbType.Text),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@advice", SqlDbType.Text)};
			parameters[0].Value = model.Topic_relation_id;
			parameters[1].Value = model.Student_id;
			parameters[2].Value = model.User_number;
			parameters[3].Value = model.Student_name;
			parameters[4].Value = model.Teacher_id;
			parameters[5].Value = model.Teacher_name;
			parameters[6].Value = model.Topic_id;
			parameters[7].Value = model.Topic_name;
			parameters[8].Value = model.Topic_nature;
			parameters[9].Value = model.Topic_source;
			parameters[10].Value = model.Check_state;
			parameters[11].Value = model.Accept_state;
			parameters[12].Value = model.Selected_state;
			parameters[13].Value = model.Apply_time;
			parameters[14].Value = model.Company;
			parameters[15].Value = model.Topic_content;
			parameters[16].Value = model.Topic_task;
			parameters[17].Value = model.Period_id;
			parameters[18].Value = model.advice;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from View_Selete_Topic ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_Selete_Topic GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Topic_relation_id,Student_id,User_number,Student_name,Teacher_id,Teacher_name,Topic_id,Topic_name,Topic_nature,Topic_source,Check_state,Accept_state,Selected_state,Apply_time,Company,Topic_content,Topic_task,Period_id,advice from View_Selete_Topic ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			university.Model.CCOM.View_Selete_Topic model=new university.Model.CCOM.View_Selete_Topic();
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
        public university.Model.CCOM.View_Selete_Topic GetModel(string strWhere)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Topic_relation_id,Student_id,User_number,Student_name,Teacher_id,Teacher_name,Topic_id,Topic_name,Topic_nature,Topic_source,Check_state,Accept_state,Selected_state,Apply_time,Company,Topic_content,Topic_task,Period_id,advice from View_Selete_Topic ");
            strSql.Append(" where " + strWhere);

            university.Model.CCOM.View_Selete_Topic model = new university.Model.CCOM.View_Selete_Topic();
            DataSet ds = DBSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
               if(ds.Tables[0].Rows[0]["Topic_relation_id"]!=null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Student_id"]!=null && ds.Tables[0].Rows[0]["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(ds.Tables[0].Rows[0]["Student_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_number"]!=null)
				{
					model.User_number=ds.Tables[0].Rows[0]["User_number"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Student_name"]!=null)
				{
					model.Student_name=ds.Tables[0].Rows[0]["Student_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Teacher_id"]!=null && ds.Tables[0].Rows[0]["Teacher_id"].ToString()!="")
				{
					model.Teacher_id=long.Parse(ds.Tables[0].Rows[0]["Teacher_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Teacher_name"]!=null)
				{
					model.Teacher_name=ds.Tables[0].Rows[0]["Teacher_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Topic_id"]!=null && ds.Tables[0].Rows[0]["Topic_id"].ToString()!="")
				{
					model.Topic_id=long.Parse(ds.Tables[0].Rows[0]["Topic_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Topic_name"]!=null)
				{
					model.Topic_name=ds.Tables[0].Rows[0]["Topic_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Topic_nature"]!=null)
				{
					model.Topic_nature=ds.Tables[0].Rows[0]["Topic_nature"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Topic_source"]!=null)
				{
					model.Topic_source=ds.Tables[0].Rows[0]["Topic_source"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Check_state"]!=null && ds.Tables[0].Rows[0]["Check_state"].ToString()!="")
				{
					model.Check_state=int.Parse(ds.Tables[0].Rows[0]["Check_state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Accept_state"]!=null && ds.Tables[0].Rows[0]["Accept_state"].ToString()!="")
				{
					model.Accept_state=int.Parse(ds.Tables[0].Rows[0]["Accept_state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Selected_state"]!=null && ds.Tables[0].Rows[0]["Selected_state"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Selected_state"].ToString()=="1")||(ds.Tables[0].Rows[0]["Selected_state"].ToString().ToLower()=="true"))
					{
						model.Selected_state=true;
					}
					else
					{
						model.Selected_state=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Apply_time"]!=null && ds.Tables[0].Rows[0]["Apply_time"].ToString()!="")
				{
					model.Apply_time=DateTime.Parse(ds.Tables[0].Rows[0]["Apply_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Company"]!=null)
				{
					model.Company=ds.Tables[0].Rows[0]["Company"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Topic_content"]!=null)
				{
					model.Topic_content=ds.Tables[0].Rows[0]["Topic_content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Topic_task"]!=null)
				{
					model.Topic_task=ds.Tables[0].Rows[0]["Topic_task"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Period_id"]!=null && ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["advice"]!=null)
				{
					model.advice=ds.Tables[0].Rows[0]["advice"].ToString();
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
		public university.Model.CCOM.View_Selete_Topic DataRowToModel(DataRow row)
		{
			university.Model.CCOM.View_Selete_Topic model=new university.Model.CCOM.View_Selete_Topic();
			if (row != null)
			{
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Student_id"]!=null && row["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(row["Student_id"].ToString());
				}
				if(row["User_number"]!=null)
				{
					model.User_number=row["User_number"].ToString();
				}
				if(row["Student_name"]!=null)
				{
					model.Student_name=row["Student_name"].ToString();
				}
				if(row["Teacher_id"]!=null && row["Teacher_id"].ToString()!="")
				{
					model.Teacher_id=long.Parse(row["Teacher_id"].ToString());
				}
				if(row["Teacher_name"]!=null)
				{
					model.Teacher_name=row["Teacher_name"].ToString();
				}
				if(row["Topic_id"]!=null && row["Topic_id"].ToString()!="")
				{
					model.Topic_id=long.Parse(row["Topic_id"].ToString());
				}
				if(row["Topic_name"]!=null)
				{
					model.Topic_name=row["Topic_name"].ToString();
				}
				if(row["Topic_nature"]!=null)
				{
					model.Topic_nature=row["Topic_nature"].ToString();
				}
				if(row["Topic_source"]!=null)
				{
					model.Topic_source=row["Topic_source"].ToString();
				}
				if(row["Check_state"]!=null && row["Check_state"].ToString()!="")
				{
					model.Check_state=int.Parse(row["Check_state"].ToString());
				}
				if(row["Accept_state"]!=null && row["Accept_state"].ToString()!="")
				{
					model.Accept_state=int.Parse(row["Accept_state"].ToString());
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
				if(row["Apply_time"]!=null && row["Apply_time"].ToString()!="")
				{
					model.Apply_time=DateTime.Parse(row["Apply_time"].ToString());
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Topic_content"]!=null)
				{
					model.Topic_content=row["Topic_content"].ToString();
				}
				if(row["Topic_task"]!=null)
				{
					model.Topic_task=row["Topic_task"].ToString();
				}
				if(row["Period_id"]!=null && row["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(row["Period_id"].ToString());
				}
				if(row["advice"]!=null)
				{
					model.advice=row["advice"].ToString();
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
			strSql.Append("select Topic_relation_id,Student_id,User_number,Student_name,Teacher_id,Teacher_name,Topic_id,Topic_name,Topic_nature,Topic_source,Check_state,Accept_state,Selected_state,Apply_time,Company,Topic_content,Topic_task,Period_id,advice ");
			strSql.Append(" FROM View_Selete_Topic ");
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
			strSql.Append(" Topic_relation_id,Student_id,User_number,Student_name,Teacher_id,Teacher_name,Topic_id,Topic_name,Topic_nature,Topic_source,Check_state,Accept_state,Selected_state,Apply_time,Company,Topic_content,Topic_task,Period_id,advice ");
			strSql.Append(" FROM View_Selete_Topic ");
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
			strSql.Append("select count(1) FROM View_Selete_Topic ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from View_Selete_Topic T ");
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
			parameters[0].Value = "View_Selete_Topic";
			parameters[1].Value = "";
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

