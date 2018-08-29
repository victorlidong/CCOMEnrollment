using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
    /// <summary>
    /// 数据访问类:View_User
    /// </summary>
    public partial class View_User
    {
        public View_User()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(university.Model.CCOM.View_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_User(");
            strSql.Append("User_id,User_realname,User_number,User_password,Agency_name,Role_name,User_gender,User_birthday,User_addtime,User_status,Role_id,Agency_id)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@User_realname,@User_number,@User_password,@Agency_name,@Role_name,@User_gender,@User_birthday,@User_addtime,@User_status,@Role_id,@Agency_id)");
            SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_realname", SqlDbType.VarChar,128),
					new SqlParameter("@User_number", SqlDbType.VarChar,16),
					new SqlParameter("@User_password", SqlDbType.VarChar,128),
					new SqlParameter("@Agency_name", SqlDbType.VarChar,128),
					new SqlParameter("@Role_name", SqlDbType.VarChar,128),
					new SqlParameter("@User_gender", SqlDbType.Bit,1),
					new SqlParameter("@User_birthday", SqlDbType.Date,3),
					new SqlParameter("@User_addtime", SqlDbType.DateTime),
					new SqlParameter("@User_status", SqlDbType.Bit,1),
					new SqlParameter("@Role_id", SqlDbType.Int,4),
					new SqlParameter("@Agency_id", SqlDbType.Int,4)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.User_realname;
            parameters[2].Value = model.User_number;
            parameters[3].Value = model.User_password;
            parameters[4].Value = model.Agency_name;
            parameters[5].Value = model.Role_name;
            parameters[6].Value = model.User_gender;
            parameters[7].Value = model.User_birthday;
            parameters[8].Value = model.User_addtime;
            parameters[9].Value = model.User_status;
            parameters[10].Value = model.Role_id;
            parameters[11].Value = model.Agency_id;

            int rows = DBSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(university.Model.CCOM.View_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_User set ");
            strSql.Append("User_id=@User_id,");
            strSql.Append("User_realname=@User_realname,");
            strSql.Append("User_number=@User_number,");
            strSql.Append("User_password=@User_password,");
            strSql.Append("Agency_name=@Agency_name,");
            strSql.Append("Role_name=@Role_name,");
            strSql.Append("User_gender=@User_gender,");
            strSql.Append("User_birthday=@User_birthday,");
            strSql.Append("User_addtime=@User_addtime,");
            strSql.Append("User_status=@User_status,");
            strSql.Append("Role_id=@Role_id,");
            strSql.Append("Agency_id=@Agency_id");
            strSql.Append(" where  User_id=@User_id");
            SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.BigInt,8),
					new SqlParameter("@User_realname", SqlDbType.VarChar,128),
					new SqlParameter("@User_number", SqlDbType.VarChar,16),
					new SqlParameter("@User_password", SqlDbType.VarChar,128),
					new SqlParameter("@Agency_name", SqlDbType.VarChar,128),
					new SqlParameter("@Role_name", SqlDbType.VarChar,128),
					new SqlParameter("@User_gender", SqlDbType.Bit,1),
					new SqlParameter("@User_birthday", SqlDbType.Date,3),
					new SqlParameter("@User_addtime", SqlDbType.DateTime),
					new SqlParameter("@User_status", SqlDbType.Bit,1),
					new SqlParameter("@Role_id", SqlDbType.Int,4),
					new SqlParameter("@Agency_id", SqlDbType.Int,4)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.User_realname;
            parameters[2].Value = model.User_number;
            parameters[3].Value = model.User_password;
            parameters[4].Value = model.Agency_name;
            parameters[5].Value = model.Role_name;
            parameters[6].Value = model.User_gender;
            parameters[7].Value = model.User_birthday;
            parameters[8].Value = model.User_addtime;
            parameters[9].Value = model.User_status;
            parameters[10].Value = model.Role_id;
            parameters[11].Value = model.Agency_id;

            int rows = DBSQL.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_User ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            int rows = DBSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int User_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_User ");

            strSql.Append(" where User_id=@User_id");
            SqlParameter[] parameters = {
					new SqlParameter("@User_id", SqlDbType.Int,8)
			};
            parameters[0].Value = User_id;

            int rows = DBSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public university.Model.CCOM.View_User GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 User_id,User_realname,User_number,User_password,Agency_name,Role_name,User_gender,User_birthday,User_addtime,User_status,Role_id,Agency_id from View_User ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            university.Model.CCOM.View_User model = new university.Model.CCOM.View_User();
            DataSet ds = DBSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public university.Model.CCOM.View_User GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_id,User_realname,User_number,User_password,Agency_name,Role_name,User_gender,User_birthday,User_addtime,User_status,Role_id,Agency_id ");
            strSql.Append("  from View_User ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.View_User model = new university.Model.CCOM.View_User();
            DataSet ds = DBSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["User_id"] != null && ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_realname"] != null)
                {
                    model.User_realname = ds.Tables[0].Rows[0]["User_realname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User_number"] != null)
                {
                    model.User_number = ds.Tables[0].Rows[0]["User_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User_password"] != null)
                {
                    model.User_password = ds.Tables[0].Rows[0]["User_password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agency_name"] != null)
                {
                    model.Agency_name = ds.Tables[0].Rows[0]["Agency_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Role_name"] != null)
                {
                    model.Role_name = ds.Tables[0].Rows[0]["Role_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["User_gender"] != null && ds.Tables[0].Rows[0]["User_gender"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["User_gender"].ToString() == "1") || (ds.Tables[0].Rows[0]["User_gender"].ToString().ToLower() == "true"))
                    {
                        model.User_gender = true;
                    }
                    else
                    {
                        model.User_gender = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["User_birthday"] != null && ds.Tables[0].Rows[0]["User_birthday"].ToString() != "")
                {
                    model.User_birthday = DateTime.Parse(ds.Tables[0].Rows[0]["User_birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_addtime"] != null && ds.Tables[0].Rows[0]["User_addtime"].ToString() != "")
                {
                    model.User_addtime = DateTime.Parse(ds.Tables[0].Rows[0]["User_addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_status"] != null && ds.Tables[0].Rows[0]["User_status"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["User_status"].ToString() == "1") || (ds.Tables[0].Rows[0]["User_status"].ToString().ToLower() == "true"))
                    {
                        model.User_status = true;
                    }
                    else
                    {
                        model.User_status = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Role_id"] != null && ds.Tables[0].Rows[0]["Role_id"].ToString() != "")
                {
                    model.Role_id = int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agency_id"] != null && ds.Tables[0].Rows[0]["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
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
        public university.Model.CCOM.View_User DataRowToModel(DataRow row)
        {
            university.Model.CCOM.View_User model = new university.Model.CCOM.View_User();
            if (row != null)
            {
                if (row["User_id"] != null && row["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(row["User_id"].ToString());
                }
                if (row["User_realname"] != null)
                {
                    model.User_realname = row["User_realname"].ToString();
                }
                if (row["User_number"] != null)
                {
                    model.User_number = row["User_number"].ToString();
                }
                if (row["User_password"] != null)
                {
                    model.User_password = row["User_password"].ToString();
                }
                if (row["Agency_name"] != null)
                {
                    model.Agency_name = row["Agency_name"].ToString();
                }
                if (row["Role_name"] != null)
                {
                    model.Role_name = row["Role_name"].ToString();
                }
                if (row["User_gender"] != null && row["User_gender"].ToString() != "")
                {
                    if ((row["User_gender"].ToString() == "1") || (row["User_gender"].ToString().ToLower() == "true"))
                    {
                        model.User_gender = true;
                    }
                    else
                    {
                        model.User_gender = false;
                    }
                }
                if (row["User_birthday"] != null && row["User_birthday"].ToString() != "")
                {
                    model.User_birthday = DateTime.Parse(row["User_birthday"].ToString());
                }
                if (row["User_addtime"] != null && row["User_addtime"].ToString() != "")
                {
                    model.User_addtime = DateTime.Parse(row["User_addtime"].ToString());
                }
                if (row["User_status"] != null && row["User_status"].ToString() != "")
                {
                    if ((row["User_status"].ToString() == "1") || (row["User_status"].ToString().ToLower() == "true"))
                    {
                        model.User_status = true;
                    }
                    else
                    {
                        model.User_status = false;
                    }
                }
                if (row["Role_id"] != null && row["Role_id"].ToString() != "")
                {
                    model.Role_id = int.Parse(row["Role_id"].ToString());
                }
                if (row["Agency_id"] != null && row["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(row["Agency_id"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_id,User_realname,User_number,User_password,Agency_name,Role_name,User_gender,User_birthday,User_addtime,User_status,Role_id,Agency_id ");
            strSql.Append(" FROM View_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" User_id,User_realname,User_number,User_password,Agency_name,Role_name,User_gender,User_birthday,User_addtime,User_status,Role_id,Agency_id ");
            strSql.Append(" FROM View_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM View_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from View_User T ");
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
            parameters[0].Value = "View_User";
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

