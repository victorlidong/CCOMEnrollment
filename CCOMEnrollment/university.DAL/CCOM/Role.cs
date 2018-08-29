﻿using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Role
		public partial class Role
	{
   		     
		public bool Exists(int Role_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Role");
			strSql.Append(" where ");
			                                       strSql.Append(" Role_id = @Role_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Role(");			
            strSql.Append("Role_name,Role_status");
			strSql.Append(") values (");
            strSql.Append("@Role_name,@Role_status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Role_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Role_status", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Role_name;                        
            parameters[1].Value = model.Role_status;                        
			   
			object obj = DBSQL.GetSingle(strSql.ToString(),parameters);			
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
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Role set ");
			                                                
            strSql.Append(" Role_name = @Role_name , ");                                    
            strSql.Append(" Role_status = @Role_status  ");            			
			strSql.Append(" where Role_id=@Role_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Role_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Role_status", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Role_id;                        
            parameters[1].Value = model.Role_name;                        
            parameters[2].Value = model.Role_status;                        
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
		public bool Delete(int Role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Role ");
			strSql.Append(" where Role_id=@Role_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;


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
			strSql.Append("delete from Role ");
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
		public bool DeleteList(string Role_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Role ");
			strSql.Append(" where Role_id in ("+Role_idlist + ")  ");
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
		public university.Model.CCOM.Role GetModel(int Role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Role_id, Role_name, Role_status  ");			
			strSql.Append("  from Role ");
			strSql.Append(" where Role_id=@Role_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;

			
			university.Model.CCOM.Role model=new university.Model.CCOM.Role();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
				}
																																				model.Role_name= ds.Tables[0].Rows[0]["Role_name"].ToString();
																																												if(ds.Tables[0].Rows[0]["Role_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Role_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Role_status"].ToString().ToLower()=="true"))
					{
					model.Role_status= true;
					}
					else
					{
					model.Role_status= false;
					}
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
		public university.Model.CCOM.Role GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Role_id, Role_name, Role_status  ");			
			strSql.Append("  from Role ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Role model=new university.Model.CCOM.Role();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
				}
																																				model.Role_name= ds.Tables[0].Rows[0]["Role_name"].ToString();
																																												if(ds.Tables[0].Rows[0]["Role_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Role_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Role_status"].ToString().ToLower()=="true"))
					{
					model.Role_status= true;
					}
					else
					{
					model.Role_status= false;
					}
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
			strSql.Append(" FROM Role ");
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
			strSql.Append(" FROM Role ");
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
			strSql.Append(" FROM Role ");
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
				strSql.Append("order by T.Role_id desc");
			}
			strSql.Append(")AS Row, T.*  from Role T ");
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
