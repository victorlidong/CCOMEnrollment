﻿using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//User_sms
		public partial class User_sms
	{
   		     
		public bool Exists(long User_sms_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_sms");
			strSql.Append(" where ");
			                                       strSql.Append(" User_sms_id = @User_sms_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@User_sms_id", SqlDbType.BigInt)
			};
			parameters[0].Value = User_sms_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.User_sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_sms(");			
            strSql.Append("User_id,User_sms_left,User_sms_create_time,User_sms_modify_time");
			strSql.Append(") values (");
            strSql.Append("@User_id,@User_sms_left,@User_sms_create_time,@User_sms_modify_time");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_sms_left", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_sms_create_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_sms_modify_time", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.User_sms_left;                        
            parameters[2].Value = model.User_sms_create_time;                        
            parameters[3].Value = model.User_sms_modify_time;                        
			   
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
		public bool Update(university.Model.CCOM.User_sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_sms set ");
			                                                
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" User_sms_left = @User_sms_left , ");                                    
            strSql.Append(" User_sms_create_time = @User_sms_create_time , ");                                    
            strSql.Append(" User_sms_modify_time = @User_sms_modify_time  ");            			
			strSql.Append(" where User_sms_id=@User_sms_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@User_sms_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_sms_left", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_sms_create_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_sms_modify_time", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.User_sms_id;                        
            parameters[1].Value = model.User_id;                        
            parameters[2].Value = model.User_sms_left;                        
            parameters[3].Value = model.User_sms_create_time;                        
            parameters[4].Value = model.User_sms_modify_time;                        
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
		public bool Delete(long User_sms_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_sms ");
			strSql.Append(" where User_sms_id=@User_sms_id");
						SqlParameter[] parameters = {
					new SqlParameter("@User_sms_id", SqlDbType.BigInt)
			};
			parameters[0].Value = User_sms_id;


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
		public bool Delete(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_sms ");
			strSql.Append(" where " + strWhere);
			

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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string User_sms_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_sms ");
			strSql.Append(" where User_sms_id in ("+User_sms_idlist + ")  ");
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
		public university.Model.CCOM.User_sms GetModel(long User_sms_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_sms_id, User_id, User_sms_left, User_sms_create_time, User_sms_modify_time  ");			
			strSql.Append("  from User_sms ");
			strSql.Append(" where User_sms_id=@User_sms_id");
						SqlParameter[] parameters = {
					new SqlParameter("@User_sms_id", SqlDbType.BigInt)
			};
			parameters[0].Value = User_sms_id;

			
			university.Model.CCOM.User_sms model=new university.Model.CCOM.User_sms();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_sms_id"].ToString()!="")
				{
					model.User_sms_id=long.Parse(ds.Tables[0].Rows[0]["User_sms_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_left"].ToString()!="")
				{
					model.User_sms_left=int.Parse(ds.Tables[0].Rows[0]["User_sms_left"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_create_time"].ToString()!="")
				{
					model.User_sms_create_time=DateTime.Parse(ds.Tables[0].Rows[0]["User_sms_create_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_modify_time"].ToString()!="")
				{
					model.User_sms_modify_time=DateTime.Parse(ds.Tables[0].Rows[0]["User_sms_modify_time"].ToString());
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
		public university.Model.CCOM.User_sms GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_sms_id, User_id, User_sms_left, User_sms_create_time, User_sms_modify_time  ");			
			strSql.Append("  from User_sms ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_sms model=new university.Model.CCOM.User_sms();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_sms_id"].ToString()!="")
				{
					model.User_sms_id=long.Parse(ds.Tables[0].Rows[0]["User_sms_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_left"].ToString()!="")
				{
					model.User_sms_left=int.Parse(ds.Tables[0].Rows[0]["User_sms_left"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_create_time"].ToString()!="")
				{
					model.User_sms_create_time=DateTime.Parse(ds.Tables[0].Rows[0]["User_sms_create_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_sms_modify_time"].ToString()!="")
				{
					model.User_sms_modify_time=DateTime.Parse(ds.Tables[0].Rows[0]["User_sms_modify_time"].ToString());
				}
																														
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM User_sms ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM User_sms ");
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
			strSql.Append("select count(1) ");
			strSql.Append(" FROM User_sms ");
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
				strSql.Append("order by T.User_sms_id desc");
			}
			strSql.Append(")AS Row, T.*  from User_sms T ");
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

