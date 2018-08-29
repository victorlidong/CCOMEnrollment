﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//子功能表
		public partial class Son_function
	{
   		     
		public bool Exists(int Sf_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Son_function");
			strSql.Append(" where ");
			                                       strSql.Append(" Sf_id = @Sf_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Sf_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Sf_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Son_function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Son_function(");			
            strSql.Append("Sf_name,Sf_url,Sf_sort,Sf_status,Ff_ID");
			strSql.Append(") values (");
            strSql.Append("@Sf_name,@Sf_url,@Sf_sort,@Sf_status,@Ff_ID");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Sf_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Sf_url", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@Sf_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sf_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ff_ID", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Sf_name;                        
            parameters[1].Value = model.Sf_url;                        
            parameters[2].Value = model.Sf_sort;                        
            parameters[3].Value = model.Sf_status;                        
            parameters[4].Value = model.Ff_ID;                        
			   
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
		public bool Update(university.Model.CCOM.Son_function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Son_function set ");
			                                                
            strSql.Append(" Sf_name = @Sf_name , ");                                    
            strSql.Append(" Sf_url = @Sf_url , ");                                    
            strSql.Append(" Sf_sort = @Sf_sort , ");                                    
            strSql.Append(" Sf_status = @Sf_status , ");                                    
            strSql.Append(" Ff_ID = @Ff_ID  ");            			
			strSql.Append(" where Sf_id=@Sf_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Sf_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sf_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Sf_url", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@Sf_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sf_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ff_ID", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Sf_id;                        
            parameters[1].Value = model.Sf_name;                        
            parameters[2].Value = model.Sf_url;                        
            parameters[3].Value = model.Sf_sort;                        
            parameters[4].Value = model.Sf_status;                        
            parameters[5].Value = model.Ff_ID;                        
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
		public bool Delete(int Sf_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Son_function ");
			strSql.Append(" where Sf_id=@Sf_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Sf_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Sf_id;


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
			strSql.Append("delete from Son_function ");
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
		public bool DeleteList(string Sf_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Son_function ");
			strSql.Append(" where Sf_id in ("+Sf_idlist + ")  ");
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
		public university.Model.CCOM.Son_function GetModel(int Sf_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Sf_id, Sf_name, Sf_url, Sf_sort, Sf_status, Ff_ID  ");			
			strSql.Append("  from Son_function ");
			strSql.Append(" where Sf_id=@Sf_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Sf_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Sf_id;

			
			university.Model.CCOM.Son_function model=new university.Model.CCOM.Son_function();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(ds.Tables[0].Rows[0]["Sf_id"].ToString());
				}
																																				model.Sf_name= ds.Tables[0].Rows[0]["Sf_name"].ToString();
																																model.Sf_url= ds.Tables[0].Rows[0]["Sf_url"].ToString();
																												if(ds.Tables[0].Rows[0]["Sf_sort"].ToString()!="")
				{
					model.Sf_sort=int.Parse(ds.Tables[0].Rows[0]["Sf_sort"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Sf_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sf_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sf_status"].ToString().ToLower()=="true"))
					{
					model.Sf_status= true;
					}
					else
					{
					model.Sf_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Ff_ID"].ToString()!="")
				{
					model.Ff_ID=int.Parse(ds.Tables[0].Rows[0]["Ff_ID"].ToString());
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
		public university.Model.CCOM.Son_function GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Sf_id, Sf_name, Sf_url, Sf_sort, Sf_status, Ff_ID  ");			
			strSql.Append("  from Son_function ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Son_function model=new university.Model.CCOM.Son_function();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(ds.Tables[0].Rows[0]["Sf_id"].ToString());
				}
																																				model.Sf_name= ds.Tables[0].Rows[0]["Sf_name"].ToString();
																																model.Sf_url= ds.Tables[0].Rows[0]["Sf_url"].ToString();
																												if(ds.Tables[0].Rows[0]["Sf_sort"].ToString()!="")
				{
					model.Sf_sort=int.Parse(ds.Tables[0].Rows[0]["Sf_sort"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Sf_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sf_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sf_status"].ToString().ToLower()=="true"))
					{
					model.Sf_status= true;
					}
					else
					{
					model.Sf_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Ff_ID"].ToString()!="")
				{
					model.Ff_ID=int.Parse(ds.Tables[0].Rows[0]["Ff_ID"].ToString());
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
			strSql.Append(" FROM Son_function ");
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
			strSql.Append(" FROM Son_function ");
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
			strSql.Append(" FROM Son_function ");
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
				strSql.Append("order by T.Sf_id desc");
			}
			strSql.Append(")AS Row, T.*  from Son_function T ");
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
