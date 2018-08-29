using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	/// <summary>
	/// 数据访问类:Reply_group
	/// </summary>
	public partial class Reply_group
	{
		public Reply_group()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Group_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Reply_group");
			strSql.Append(" where Group_id=@Group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Group_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Reply_group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Reply_group(");
			strSql.Append("Group_name,Group_type,User_id,Reply_time,Reply_room,Period_id)");
			strSql.Append(" values (");
			strSql.Append("@Group_name,@Group_type,@User_id,@Reply_time,@Reply_room,@Period_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_name", SqlDbType.VarChar,128),
					new SqlParameter("@Group_type", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Reply_time", SqlDbType.Date,3),
					new SqlParameter("@Reply_room", SqlDbType.VarChar,128),
					new SqlParameter("@Period_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Group_name;
			parameters[1].Value = model.Group_type;
			parameters[2].Value = model.User_id;
			parameters[3].Value = model.Reply_time;
			parameters[4].Value = model.Reply_room;
			parameters[5].Value = model.Period_id;

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
		public bool Update(university.Model.CCOM.Reply_group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Reply_group set ");
			strSql.Append("Group_name=@Group_name,");
			strSql.Append("Group_type=@Group_type,");
			strSql.Append("User_id=@User_id,");
			strSql.Append("Reply_time=@Reply_time,");
			strSql.Append("Reply_room=@Reply_room,");
			strSql.Append("Period_id=@Period_id");
			strSql.Append(" where Group_id=@Group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_name", SqlDbType.VarChar,128),
					new SqlParameter("@Group_type", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@Reply_time", SqlDbType.Date,3),
					new SqlParameter("@Reply_room", SqlDbType.VarChar,128),
					new SqlParameter("@Period_id", SqlDbType.Int,4),
					new SqlParameter("@Group_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Group_name;
			parameters[1].Value = model.Group_type;
			parameters[2].Value = model.User_id;
			parameters[3].Value = model.Reply_time;
			parameters[4].Value = model.Reply_room;
			parameters[5].Value = model.Period_id;
			parameters[6].Value = model.Group_id;

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
		public bool Delete(long Group_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply_group ");
			strSql.Append(" where Group_id=@Group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Group_id;

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
		public bool DeleteList(string Group_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply_group ");
			strSql.Append(" where Group_id in ("+Group_idlist + ")  ");
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
		public university.Model.CCOM.Reply_group GetModel(long Group_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Group_id,Group_name,Group_type,User_id,Reply_time,Reply_room,Period_id from Reply_group ");
			strSql.Append(" where Group_id=@Group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Group_id;

			university.Model.CCOM.Reply_group model=new university.Model.CCOM.Reply_group();
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
        public university.Model.CCOM.Reply_group GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Group_id,Group_name,Group_type,User_id,Reply_time,Reply_room,Period_id from Reply_group ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.Reply_group model = new university.Model.CCOM.Reply_group();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Group_id"] != null && ds.Tables[0].Rows[0]["Group_id"].ToString() != "")
                {
                    model.Group_id = long.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Group_name"] != null)
                {
                    model.Group_name = ds.Tables[0].Rows[0]["Group_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Group_type"] != null && ds.Tables[0].Rows[0]["Group_type"].ToString() != "")
                {
                    model.Group_type = int.Parse(ds.Tables[0].Rows[0]["Group_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Reply_time"] != null && ds.Tables[0].Rows[0]["Reply_time"].ToString() != "")
                {
                    model.Reply_time = DateTime.Parse(ds.Tables[0].Rows[0]["Reply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Reply_room"] != null)
                {
                    model.Reply_room = ds.Tables[0].Rows[0]["Reply_room"].ToString();
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
		public university.Model.CCOM.Reply_group DataRowToModel(DataRow row)
		{
			university.Model.CCOM.Reply_group model=new university.Model.CCOM.Reply_group();
			if (row != null)
			{
				if(row["Group_id"]!=null && row["Group_id"].ToString()!="")
				{
					model.Group_id=long.Parse(row["Group_id"].ToString());
				}
				if(row["Group_name"]!=null)
				{
					model.Group_name=row["Group_name"].ToString();
				}
				if(row["Group_type"]!=null && row["Group_type"].ToString()!="")
				{
					model.Group_type=int.Parse(row["Group_type"].ToString());
				}
				if(row["User_id"]!=null && row["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(row["User_id"].ToString());
				}
				if(row["Reply_time"]!=null && row["Reply_time"].ToString()!="")
				{
					model.Reply_time=DateTime.Parse(row["Reply_time"].ToString());
				}
				if(row["Reply_room"]!=null)
				{
					model.Reply_room=row["Reply_room"].ToString();
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
			strSql.Append("select Group_id,Group_name,Group_type,User_id,Reply_time,Reply_room,Period_id ");
			strSql.Append(" FROM Reply_group ");
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
			strSql.Append(" Group_id,Group_name,Group_type,User_id,Reply_time,Reply_room,Period_id ");
			strSql.Append(" FROM Reply_group ");
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
			strSql.Append("select count(1) FROM Reply_group ");
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
				strSql.Append("order by T.Group_id desc");
			}
			strSql.Append(")AS Row, T.*  from Reply_group T ");
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
			parameters[0].Value = "Reply_group";
			parameters[1].Value = "Group_id";
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

