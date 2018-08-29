using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//User_extra
		public partial class User_extra
	{
   		     
		public bool Exists(int Ue_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_extra");
			strSql.Append(" where ");
			                                       strSql.Append(" Ue_id = @Ue_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Ue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ue_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.User_extra model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_extra(");			
            strSql.Append("Ue_name,Ue_type,Ue_null");
			strSql.Append(") values (");
            strSql.Append("@Ue_name,@Ue_type,@Ue_null");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Ue_name", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ue_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ue_null", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Ue_name;                        
            parameters[1].Value = model.Ue_type;                        
            parameters[2].Value = model.Ue_null;                        
			   
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
		public bool Update(university.Model.CCOM.User_extra model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_extra set ");
			                                                
            strSql.Append(" Ue_name = @Ue_name , ");                                    
            strSql.Append(" Ue_type = @Ue_type , ");                                    
            strSql.Append(" Ue_null = @Ue_null  ");            			
			strSql.Append(" where Ue_id=@Ue_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Ue_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ue_name", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ue_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ue_null", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Ue_id;                        
            parameters[1].Value = model.Ue_name;                        
            parameters[2].Value = model.Ue_type;                        
            parameters[3].Value = model.Ue_null;                        
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
		public bool Delete(int Ue_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_extra ");
			strSql.Append(" where Ue_id=@Ue_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ue_id;


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
			strSql.Append("delete from User_extra ");
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
		public bool DeleteList(string Ue_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_extra ");
			strSql.Append(" where Ue_id in ("+Ue_idlist + ")  ");
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
		public university.Model.CCOM.User_extra GetModel(int Ue_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ue_id, Ue_name, Ue_type, Ue_null  ");			
			strSql.Append("  from User_extra ");
			strSql.Append(" where Ue_id=@Ue_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ue_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ue_id;

			
			university.Model.CCOM.User_extra model=new university.Model.CCOM.User_extra();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(ds.Tables[0].Rows[0]["Ue_id"].ToString());
				}
																																				model.Ue_name= ds.Tables[0].Rows[0]["Ue_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ue_type"].ToString()!="")
				{
					model.Ue_type=int.Parse(ds.Tables[0].Rows[0]["Ue_type"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ue_null"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ue_null"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ue_null"].ToString().ToLower()=="true"))
					{
					model.Ue_null= true;
					}
					else
					{
					model.Ue_null= false;
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
		public university.Model.CCOM.User_extra GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ue_id, Ue_name, Ue_type, Ue_null  ");			
			strSql.Append("  from User_extra ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_extra model=new university.Model.CCOM.User_extra();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(ds.Tables[0].Rows[0]["Ue_id"].ToString());
				}
																																				model.Ue_name= ds.Tables[0].Rows[0]["Ue_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ue_type"].ToString()!="")
				{
					model.Ue_type=int.Parse(ds.Tables[0].Rows[0]["Ue_type"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ue_null"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ue_null"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ue_null"].ToString().ToLower()=="true"))
					{
					model.Ue_null= true;
					}
					else
					{
					model.Ue_null= false;
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
			strSql.Append(" FROM User_extra ");
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
			strSql.Append(" FROM User_extra ");
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
			strSql.Append(" FROM User_extra ");
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
				strSql.Append("order by T.Ue_id desc");
			}
			strSql.Append(")AS Row, T.*  from User_extra T ");
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

