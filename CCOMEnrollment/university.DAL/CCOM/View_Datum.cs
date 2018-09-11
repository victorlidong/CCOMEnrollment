using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:View_Datum
	/// </summary>
	public partial class View_Datum
	{
		public View_Datum()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(university.Model.CCOM.View_Datum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Datum(");
			strSql.Append("Datum_id,Student_id,Tutor_id,Topic_id,Accept_state,File_path,File_name,DatumType_id,DatumType_name,Submit_time,Tutor_advice,TeachWeek_id,Start_time,End_time,State,Topic_relation_id,Homework_id,User_id)");
			strSql.Append(" values (");
			strSql.Append("@Datum_id,@Student_id,@Tutor_id,@Topic_id,@Accept_state,@File_path,@File_name,@DatumType_id,@DatumType_name,@Submit_time,@Tutor_advice,@TeachWeek_id,@Start_time,@End_time,@State,@Topic_relation_id,@Homework_id,@User_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@Datum_id", SqlDbType.BigInt,8),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Tutor_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@File_path", SqlDbType.VarChar,128),
					new SqlParameter("@File_name", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@DatumType_name", SqlDbType.VarChar,128),
					new SqlParameter("@Submit_time", SqlDbType.Date,3),
					new SqlParameter("@Tutor_advice", SqlDbType.Text),
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4),
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4),
                    new SqlParameter("@User_id", SqlDbType.BigInt,4)};
            parameters[0].Value = model.Datum_id;
			parameters[1].Value = model.Student_id;
			parameters[2].Value = model.Tutor_id;
			parameters[3].Value = model.Topic_id;
			parameters[4].Value = model.Accept_state;
			parameters[5].Value = model.File_path;
			parameters[6].Value = model.File_name;
			parameters[7].Value = model.DatumType_id;
			parameters[8].Value = model.DatumType_name;
			parameters[9].Value = model.Submit_time;
			parameters[10].Value = model.Tutor_advice;
			parameters[11].Value = model.TeachWeek_id;
			parameters[12].Value = model.Start_time;
			parameters[13].Value = model.End_time;
			parameters[14].Value = model.State;
			parameters[15].Value = model.Topic_relation_id;
			parameters[16].Value = model.Homework_id;
            parameters[17].Value = model.User_id;
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
		public bool Update(university.Model.CCOM.View_Datum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Datum set ");
			strSql.Append("Datum_id=@Datum_id,");
			strSql.Append("Student_id=@Student_id,");
			strSql.Append("Tutor_id=@Tutor_id,");
			strSql.Append("Topic_id=@Topic_id,");
			strSql.Append("Accept_state=@Accept_state,");
			strSql.Append("File_path=@File_path,");
			strSql.Append("File_name=@File_name,");
			strSql.Append("DatumType_id=@DatumType_id,");
			strSql.Append("DatumType_name=@DatumType_name,");
			strSql.Append("Submit_time=@Submit_time,");
			strSql.Append("Tutor_advice=@Tutor_advice,");
			strSql.Append("TeachWeek_id=@TeachWeek_id,");
			strSql.Append("Start_time=@Start_time,");
			strSql.Append("End_time=@End_time,");
			strSql.Append("State=@State,");
			strSql.Append("Topic_relation_id=@Topic_relation_id,");
			strSql.Append("Homework_id=@Homework_id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Datum_id", SqlDbType.BigInt,8),
					new SqlParameter("@Student_id", SqlDbType.BigInt,8),
					new SqlParameter("@Tutor_id", SqlDbType.BigInt,8),
					new SqlParameter("@Topic_id", SqlDbType.BigInt,8),
					new SqlParameter("@Accept_state", SqlDbType.Int,4),
					new SqlParameter("@File_path", SqlDbType.VarChar,128),
					new SqlParameter("@File_name", SqlDbType.VarChar,128),
					new SqlParameter("@DatumType_id", SqlDbType.Int,4),
					new SqlParameter("@DatumType_name", SqlDbType.VarChar,128),
					new SqlParameter("@Submit_time", SqlDbType.Date,3),
					new SqlParameter("@Tutor_advice", SqlDbType.Text),
					new SqlParameter("@TeachWeek_id", SqlDbType.Int,4),
					new SqlParameter("@Start_time", SqlDbType.Date,3),
					new SqlParameter("@End_time", SqlDbType.Date,3),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@Topic_relation_id", SqlDbType.BigInt,8),
					new SqlParameter("@Homework_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Datum_id;
			parameters[1].Value = model.Student_id;
			parameters[2].Value = model.Tutor_id;
			parameters[3].Value = model.Topic_id;
			parameters[4].Value = model.Accept_state;
			parameters[5].Value = model.File_path;
			parameters[6].Value = model.File_name;
			parameters[7].Value = model.DatumType_id;
			parameters[8].Value = model.DatumType_name;
			parameters[9].Value = model.Submit_time;
			parameters[10].Value = model.Tutor_advice;
			parameters[11].Value = model.TeachWeek_id;
			parameters[12].Value = model.Start_time;
			parameters[13].Value = model.End_time;
			parameters[14].Value = model.State;
			parameters[15].Value = model.Topic_relation_id;
			parameters[16].Value = model.Homework_id;

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
			strSql.Append("delete from View_Datum ");
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
		public university.Model.CCOM.View_Datum GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Datum_id,Student_id,Tutor_id,Topic_id,Accept_state,File_path,File_name,DatumType_id,DatumType_name,Submit_time,Tutor_advice,TeachWeek_id,Start_time,End_time,State,Topic_relation_id,Homework_id from View_Datum ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			university.Model.CCOM.View_Datum model=new university.Model.CCOM.View_Datum();
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
        public university.Model.CCOM.View_Datum GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Datum_id,Student_id,Tutor_id,Topic_id,Accept_state,File_path,File_name,DatumType_id,DatumType_name,Submit_time,Tutor_advice,TeachWeek_id,Start_time,End_time,State,Topic_relation_id,Homework_id  ");
            strSql.Append("  from View_Datum ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.View_Datum model = new university.Model.CCOM.View_Datum();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Datum_id"] != null && ds.Tables[0].Rows[0]["Datum_id"].ToString() != "")
                {
                    model.Datum_id = long.Parse(ds.Tables[0].Rows[0]["Datum_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Student_id"] != null && ds.Tables[0].Rows[0]["Student_id"].ToString() != "")
                {
                    model.Student_id = long.Parse(ds.Tables[0].Rows[0]["Student_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tutor_id"] != null && ds.Tables[0].Rows[0]["Tutor_id"].ToString() != "")
                {
                    model.Tutor_id = long.Parse(ds.Tables[0].Rows[0]["Tutor_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Topic_id"] != null && ds.Tables[0].Rows[0]["Topic_id"].ToString() != "")
                {
                    model.Topic_id = long.Parse(ds.Tables[0].Rows[0]["Topic_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Accept_state"] != null && ds.Tables[0].Rows[0]["Accept_state"].ToString() != "")
                {
                    model.Accept_state = int.Parse(ds.Tables[0].Rows[0]["Accept_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["File_path"] != null)
                {
                    model.File_path = ds.Tables[0].Rows[0]["File_path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["File_name"] != null)
                {
                    model.File_name = ds.Tables[0].Rows[0]["File_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DatumType_id"] != null && ds.Tables[0].Rows[0]["DatumType_id"].ToString() != "")
                {
                    model.DatumType_id = int.Parse(ds.Tables[0].Rows[0]["DatumType_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DatumType_name"] != null)
                {
                    model.DatumType_name = ds.Tables[0].Rows[0]["DatumType_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Submit_time"] != null && ds.Tables[0].Rows[0]["Submit_time"].ToString() != "")
                {
                    model.Submit_time = DateTime.Parse(ds.Tables[0].Rows[0]["Submit_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tutor_advice"] != null)
                {
                    model.Tutor_advice = ds.Tables[0].Rows[0]["Tutor_advice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TeachWeek_id"] != null && ds.Tables[0].Rows[0]["TeachWeek_id"].ToString() != "")
                {
                    model.TeachWeek_id = int.Parse(ds.Tables[0].Rows[0]["TeachWeek_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Start_time"] != null && ds.Tables[0].Rows[0]["Start_time"].ToString() != "")
                {
                    model.Start_time = DateTime.Parse(ds.Tables[0].Rows[0]["Start_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["End_time"] != null && ds.Tables[0].Rows[0]["End_time"].ToString() != "")
                {
                    model.End_time = DateTime.Parse(ds.Tables[0].Rows[0]["End_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["State"].ToString() == "1") || (ds.Tables[0].Rows[0]["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Topic_relation_id"] != null && ds.Tables[0].Rows[0]["Topic_relation_id"].ToString() != "")
                {
                    model.Topic_relation_id = long.Parse(ds.Tables[0].Rows[0]["Topic_relation_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Homework_id"] != null && ds.Tables[0].Rows[0]["Homework_id"].ToString() != "")
                {
                    model.Homework_id = int.Parse(ds.Tables[0].Rows[0]["Homework_id"].ToString());
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
		public university.Model.CCOM.View_Datum DataRowToModel(DataRow row)
		{
			university.Model.CCOM.View_Datum model=new university.Model.CCOM.View_Datum();
			if (row != null)
			{
				if(row["Datum_id"]!=null && row["Datum_id"].ToString()!="")
				{
					model.Datum_id=long.Parse(row["Datum_id"].ToString());
				}
				if(row["Student_id"]!=null && row["Student_id"].ToString()!="")
				{
					model.Student_id=long.Parse(row["Student_id"].ToString());
				}
				if(row["Tutor_id"]!=null && row["Tutor_id"].ToString()!="")
				{
					model.Tutor_id=long.Parse(row["Tutor_id"].ToString());
				}
				if(row["Topic_id"]!=null && row["Topic_id"].ToString()!="")
				{
					model.Topic_id=long.Parse(row["Topic_id"].ToString());
				}
				if(row["Accept_state"]!=null && row["Accept_state"].ToString()!="")
				{
					model.Accept_state=int.Parse(row["Accept_state"].ToString());
				}
				if(row["File_path"]!=null)
				{
					model.File_path=row["File_path"].ToString();
				}
				if(row["File_name"]!=null)
				{
					model.File_name=row["File_name"].ToString();
				}
				if(row["DatumType_id"]!=null && row["DatumType_id"].ToString()!="")
				{
					model.DatumType_id=int.Parse(row["DatumType_id"].ToString());
				}
				if(row["DatumType_name"]!=null)
				{
					model.DatumType_name=row["DatumType_name"].ToString();
				}
				if(row["Submit_time"]!=null && row["Submit_time"].ToString()!="")
				{
					model.Submit_time=DateTime.Parse(row["Submit_time"].ToString());
				}
				if(row["Tutor_advice"]!=null)
				{
					model.Tutor_advice=row["Tutor_advice"].ToString();
				}
				if(row["TeachWeek_id"]!=null && row["TeachWeek_id"].ToString()!="")
				{
					model.TeachWeek_id=int.Parse(row["TeachWeek_id"].ToString());
				}
				if(row["Start_time"]!=null && row["Start_time"].ToString()!="")
				{
					model.Start_time=DateTime.Parse(row["Start_time"].ToString());
				}
				if(row["End_time"]!=null && row["End_time"].ToString()!="")
				{
					model.End_time=DateTime.Parse(row["End_time"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					if((row["State"].ToString()=="1")||(row["State"].ToString().ToLower()=="true"))
					{
						model.State=true;
					}
					else
					{
						model.State=false;
					}
				}
				if(row["Topic_relation_id"]!=null && row["Topic_relation_id"].ToString()!="")
				{
					model.Topic_relation_id=long.Parse(row["Topic_relation_id"].ToString());
				}
				if(row["Homework_id"]!=null && row["Homework_id"].ToString()!="")
				{
					model.Homework_id=int.Parse(row["Homework_id"].ToString());
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
			strSql.Append("select Datum_id,Student_id,Tutor_id,Topic_id,Accept_state,File_path,File_name,DatumType_id,DatumType_name,Submit_time,Tutor_advice,TeachWeek_id,Start_time,End_time,State,Topic_relation_id,Homework_id ");
			strSql.Append(" FROM View_Datum ");
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
			strSql.Append(" Datum_id,Student_id,Tutor_id,Topic_id,Accept_state,File_path,File_name,DatumType_id,DatumType_name,Submit_time,Tutor_advice,TeachWeek_id,Start_time,End_time,State,Topic_relation_id,Homework_id ");
			strSql.Append(" FROM View_Datum ");
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
			strSql.Append("select count(1) FROM View_Datum ");
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
				strSql.Append("order by T.Datum_id desc");
			}
			strSql.Append(")AS Row, T.*  from View_Datum T ");
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
			parameters[0].Value = "View_Datum";
			parameters[1].Value = "Datum_id";
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

