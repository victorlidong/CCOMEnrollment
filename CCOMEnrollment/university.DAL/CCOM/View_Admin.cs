﻿using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
    //View_Admin
    public partial class View_Admin
    {

        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_Admin");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            return DBSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(university.Model.CCOM.View_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_Admin(");
            strSql.Append("User_id,User_number,User_password,User_realname,User_ID_number_type,User_ID_number,User_gender,User_birthday,User_type,User_addtime,User_status,Agency_id,Agency_name,Role_id,Role_name");
            strSql.Append(") values (");
            strSql.Append("@User_id,@User_number,@User_password,@User_realname,@User_ID_number_type,@User_ID_number,@User_gender,@User_birthday,@User_type,@User_addtime,@User_status,@Agency_id,@Agency_name,@Role_id,@Role_name");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_password", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_ID_number_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_ID_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_gender", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_birthday", SqlDbType.Date,3) ,            
                        new SqlParameter("@User_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@User_addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Role_name", SqlDbType.VarChar,128)             
              
            };

            parameters[0].Value = model.User_id;
            parameters[1].Value = model.User_number;
            parameters[2].Value = model.User_password;
            parameters[3].Value = model.User_realname;
            parameters[4].Value = model.User_ID_number_type;
            parameters[5].Value = model.User_ID_number;
            parameters[6].Value = model.User_gender;
            parameters[7].Value = model.User_birthday;
            parameters[8].Value = model.User_type;
            parameters[9].Value = model.User_addtime;
            parameters[10].Value = model.User_status;
            parameters[11].Value = model.Agency_id;
            parameters[12].Value = model.Agency_name;
            parameters[13].Value = model.Role_id;
            parameters[14].Value = model.Role_name;
            DBSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(university.Model.CCOM.View_Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_Admin set ");

            strSql.Append(" User_id = @User_id , ");
            strSql.Append(" User_number = @User_number , ");
            strSql.Append(" User_password = @User_password , ");
            strSql.Append(" User_realname = @User_realname , ");
            strSql.Append(" User_ID_number_type = @User_ID_number_type , ");
            strSql.Append(" User_ID_number = @User_ID_number , ");
            strSql.Append(" User_gender = @User_gender , ");
            strSql.Append(" User_birthday = @User_birthday , ");
            strSql.Append(" User_type = @User_type , ");
            strSql.Append(" User_addtime = @User_addtime , ");
            strSql.Append(" User_status = @User_status , ");
            strSql.Append(" Agency_id = @Agency_id , ");
            strSql.Append(" Agency_name = @Agency_name , ");
            strSql.Append(" Role_id = @Role_id , ");
            strSql.Append(" Role_name = @Role_name  ");
            strSql.Append(" where  User_id=@User_id");

            SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_password", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_ID_number_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_ID_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_gender", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_birthday", SqlDbType.Date,3) ,            
                        new SqlParameter("@User_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@User_addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Role_name", SqlDbType.VarChar,128)             
              
            };

            parameters[0].Value = model.User_id;
            parameters[1].Value = model.User_number;
            parameters[2].Value = model.User_password;
            parameters[3].Value = model.User_realname;
            parameters[4].Value = model.User_ID_number_type;
            parameters[5].Value = model.User_ID_number;
            parameters[6].Value = model.User_gender;
            parameters[7].Value = model.User_birthday;
            parameters[8].Value = model.User_type;
            parameters[9].Value = model.User_addtime;
            parameters[10].Value = model.User_status;
            parameters[11].Value = model.Agency_id;
            parameters[12].Value = model.Agency_name;
            parameters[13].Value = model.Role_id;
            parameters[14].Value = model.Role_name;
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_Admin ");
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
            strSql.Append("delete from View_Admin ");

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_Admin ");
            strSql.Append(" where " + strWhere);


            int rows = DBSQL.ExecuteSql(strSql.ToString());
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
        public university.Model.CCOM.View_Admin GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_id, User_number, User_password, User_realname, User_ID_number_type, User_ID_number, User_gender, User_birthday, User_type, User_addtime, User_status, Agency_id, Agency_name, Role_id, Role_name  ");
            strSql.Append("  from View_Admin ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};


            university.Model.CCOM.View_Admin model = new university.Model.CCOM.View_Admin();
            DataSet ds = DBSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                model.User_number = ds.Tables[0].Rows[0]["User_number"].ToString();
                model.User_password = ds.Tables[0].Rows[0]["User_password"].ToString();
                model.User_realname = ds.Tables[0].Rows[0]["User_realname"].ToString();
                if (ds.Tables[0].Rows[0]["User_ID_number_type"].ToString() != "")
                {
                    model.User_ID_number_type = int.Parse(ds.Tables[0].Rows[0]["User_ID_number_type"].ToString());
                }
                model.User_ID_number = ds.Tables[0].Rows[0]["User_ID_number"].ToString();
                if (ds.Tables[0].Rows[0]["User_gender"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["User_birthday"].ToString() != "")
                {
                    model.User_birthday = DateTime.Parse(ds.Tables[0].Rows[0]["User_birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_type"].ToString() != "")
                {
                    model.User_type = int.Parse(ds.Tables[0].Rows[0]["User_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_addtime"].ToString() != "")
                {
                    model.User_addtime = DateTime.Parse(ds.Tables[0].Rows[0]["User_addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_status"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
                }
                model.Agency_name = ds.Tables[0].Rows[0]["Agency_name"].ToString();
                if (ds.Tables[0].Rows[0]["Role_id"].ToString() != "")
                {
                    model.Role_id = int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
                }
                model.Role_name = ds.Tables[0].Rows[0]["Role_name"].ToString();

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
        public university.Model.CCOM.View_Admin GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_id, User_number, User_password, User_realname, User_ID_number_type, User_ID_number, User_gender, User_birthday, User_type, User_addtime, User_status, Agency_id, Agency_name, Role_id, Role_name  ");
            strSql.Append("  from View_Admin ");
            strSql.Append(" where " + strWhere);


            university.Model.CCOM.View_Admin model = new university.Model.CCOM.View_Admin();
            DataSet ds = DBSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["User_id"].ToString() != "")
                {
                    model.User_id = long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
                }
                model.User_number = ds.Tables[0].Rows[0]["User_number"].ToString();
                model.User_password = ds.Tables[0].Rows[0]["User_password"].ToString();
                model.User_realname = ds.Tables[0].Rows[0]["User_realname"].ToString();
                if (ds.Tables[0].Rows[0]["User_ID_number_type"].ToString() != "")
                {
                    model.User_ID_number_type = int.Parse(ds.Tables[0].Rows[0]["User_ID_number_type"].ToString());
                }
                model.User_ID_number = ds.Tables[0].Rows[0]["User_ID_number"].ToString();
                if (ds.Tables[0].Rows[0]["User_gender"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["User_birthday"].ToString() != "")
                {
                    model.User_birthday = DateTime.Parse(ds.Tables[0].Rows[0]["User_birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_type"].ToString() != "")
                {
                    model.User_type = int.Parse(ds.Tables[0].Rows[0]["User_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_addtime"].ToString() != "")
                {
                    model.User_addtime = DateTime.Parse(ds.Tables[0].Rows[0]["User_addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_status"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
                }
                model.Agency_name = ds.Tables[0].Rows[0]["Agency_name"].ToString();
                if (ds.Tables[0].Rows[0]["Role_id"].ToString() != "")
                {
                    model.Role_id = int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
                }
                model.Role_name = ds.Tables[0].Rows[0]["Role_name"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_Admin ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM View_Admin ");
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
            strSql.Append("select count(1) ");
            strSql.Append(" FROM View_Admin ");
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
            strSql.Append(")AS Row, T.*  from View_Admin T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBSQL.Query(strSql.ToString());
        }



    }
}

