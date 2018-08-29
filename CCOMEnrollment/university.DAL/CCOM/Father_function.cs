using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//父功能表
		public partial class Father_function
	{
   		     
		public bool Exists(int Ff_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Father_function");
			strSql.Append(" where ");
			                                       strSql.Append(" Ff_id = @Ff_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Ff_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ff_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Father_function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Father_function(");			
            strSql.Append("Ff_name,Ff_fatherID,Ff_sort,Ff_disable");
			strSql.Append(") values (");
            strSql.Append("@Ff_name,@Ff_fatherID,@Ff_sort,@Ff_disable");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Ff_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Ff_fatherID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ff_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ff_disable", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Ff_name;                        
            parameters[1].Value = model.Ff_fatherID;                        
            parameters[2].Value = model.Ff_sort;                        
            parameters[3].Value = model.Ff_disable;                        
			   
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
		public bool Update(university.Model.CCOM.Father_function model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Father_function set ");
			                                                
            strSql.Append(" Ff_name = @Ff_name , ");                                    
            strSql.Append(" Ff_fatherID = @Ff_fatherID , ");                                    
            strSql.Append(" Ff_sort = @Ff_sort , ");                                    
            strSql.Append(" Ff_disable = @Ff_disable  ");            			
			strSql.Append(" where Ff_id=@Ff_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Ff_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ff_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Ff_fatherID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ff_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ff_disable", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Ff_id;                        
            parameters[1].Value = model.Ff_name;                        
            parameters[2].Value = model.Ff_fatherID;                        
            parameters[3].Value = model.Ff_sort;                        
            parameters[4].Value = model.Ff_disable;                        
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
		public bool Delete(int Ff_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Father_function ");
			strSql.Append(" where Ff_id=@Ff_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ff_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ff_id;


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
			strSql.Append("delete from Father_function ");
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
		public bool DeleteList(string Ff_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Father_function ");
			strSql.Append(" where Ff_id in ("+Ff_idlist + ")  ");
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
		public university.Model.CCOM.Father_function GetModel(int Ff_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ff_id, Ff_name, Ff_fatherID, Ff_sort, Ff_disable  ");			
			strSql.Append("  from Father_function ");
			strSql.Append(" where Ff_id=@Ff_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ff_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ff_id;

			
			university.Model.CCOM.Father_function model=new university.Model.CCOM.Father_function();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ff_id"].ToString()!="")
				{
					model.Ff_id=int.Parse(ds.Tables[0].Rows[0]["Ff_id"].ToString());
				}
																																				model.Ff_name= ds.Tables[0].Rows[0]["Ff_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ff_fatherID"].ToString()!="")
				{
					model.Ff_fatherID=int.Parse(ds.Tables[0].Rows[0]["Ff_fatherID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ff_sort"].ToString()!="")
				{
					model.Ff_sort=int.Parse(ds.Tables[0].Rows[0]["Ff_sort"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ff_disable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ff_disable"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ff_disable"].ToString().ToLower()=="true"))
					{
					model.Ff_disable= true;
					}
					else
					{
					model.Ff_disable= false;
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
		public university.Model.CCOM.Father_function GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ff_id, Ff_name, Ff_fatherID, Ff_sort, Ff_disable  ");			
			strSql.Append("  from Father_function ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Father_function model=new university.Model.CCOM.Father_function();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ff_id"].ToString()!="")
				{
					model.Ff_id=int.Parse(ds.Tables[0].Rows[0]["Ff_id"].ToString());
				}
																																				model.Ff_name= ds.Tables[0].Rows[0]["Ff_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ff_fatherID"].ToString()!="")
				{
					model.Ff_fatherID=int.Parse(ds.Tables[0].Rows[0]["Ff_fatherID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ff_sort"].ToString()!="")
				{
					model.Ff_sort=int.Parse(ds.Tables[0].Rows[0]["Ff_sort"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ff_disable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ff_disable"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ff_disable"].ToString().ToLower()=="true"))
					{
					model.Ff_disable= true;
					}
					else
					{
					model.Ff_disable= false;
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
			strSql.Append(" FROM Father_function ");
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
			strSql.Append(" FROM Father_function ");
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
			strSql.Append(" FROM Father_function ");
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
				strSql.Append("order by T.Ff_id desc");
			}
			strSql.Append(")AS Row, T.*  from Father_function T ");
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

