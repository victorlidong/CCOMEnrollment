using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Subject
		public partial class Subject
	{
   		     
		public bool Exists(int Subject_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Subject");
			strSql.Append(" where ");
			                                       strSql.Append(" Subject_id = @Subject_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Subject(");			
            strSql.Append("Subject_title,Subject_type,Value_type,Value_count,Manage_Agency_id,Major_Agency_id,Period_id,Subject_weight,Subject_level,Subject_description,Fs_id");
			strSql.Append(") values (");
            strSql.Append("@Subject_title,@Subject_type,@Value_type,@Value_count,@Manage_Agency_id,@Major_Agency_id,@Period_id,@Subject_weight,@Subject_level,@Subject_description,@Fs_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Value_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Value_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@Manage_Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Major_Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_weight", SqlDbType.Float,8) ,            
                        new SqlParameter("@Subject_level", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_description", SqlDbType.Text) ,            
                        new SqlParameter("@Fs_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Subject_title;                        
            parameters[1].Value = model.Subject_type;                        
            parameters[2].Value = model.Value_type;                        
            parameters[3].Value = model.Value_count;                        
            parameters[4].Value = model.Manage_Agency_id;                        
            parameters[5].Value = model.Major_Agency_id;                        
            parameters[6].Value = model.Period_id;                        
            parameters[7].Value = model.Subject_weight;                        
            parameters[8].Value = model.Subject_level;                        
            parameters[9].Value = model.Subject_description;                        
            parameters[10].Value = model.Fs_id;                        
			   
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
		public bool Update(university.Model.CCOM.Subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Subject set ");
			                                                
            strSql.Append(" Subject_title = @Subject_title , ");                                    
            strSql.Append(" Subject_type = @Subject_type , ");                                    
            strSql.Append(" Value_type = @Value_type , ");                                    
            strSql.Append(" Value_count = @Value_count , ");                                    
            strSql.Append(" Manage_Agency_id = @Manage_Agency_id , ");                                    
            strSql.Append(" Major_Agency_id = @Major_Agency_id , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" Subject_weight = @Subject_weight , ");                                    
            strSql.Append(" Subject_level = @Subject_level , ");                                    
            strSql.Append(" Subject_description = @Subject_description , ");                                    
            strSql.Append(" Fs_id = @Fs_id  ");            			
			strSql.Append(" where Subject_id=@Subject_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Subject_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Value_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Value_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@Manage_Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Major_Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_weight", SqlDbType.Float,8) ,            
                        new SqlParameter("@Subject_level", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_description", SqlDbType.Text) ,            
                        new SqlParameter("@Fs_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Subject_id;                        
            parameters[1].Value = model.Subject_title;                        
            parameters[2].Value = model.Subject_type;                        
            parameters[3].Value = model.Value_type;                        
            parameters[4].Value = model.Value_count;                        
            parameters[5].Value = model.Manage_Agency_id;                        
            parameters[6].Value = model.Major_Agency_id;                        
            parameters[7].Value = model.Period_id;                        
            parameters[8].Value = model.Subject_weight;                        
            parameters[9].Value = model.Subject_level;                        
            parameters[10].Value = model.Subject_description;                        
            parameters[11].Value = model.Fs_id;                        
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
		public bool Delete(int Subject_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Subject ");
			strSql.Append(" where Subject_id=@Subject_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;


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
			strSql.Append("delete from Subject ");
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
		public bool DeleteList(string Subject_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Subject ");
			strSql.Append(" where Subject_id in ("+Subject_idlist + ")  ");
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
		public university.Model.CCOM.Subject GetModel(int Subject_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Subject_id, Subject_title, Subject_type, Value_type, Value_count, Manage_Agency_id, Major_Agency_id, Period_id, Subject_weight, Subject_level, Subject_description, Fs_id  ");			
			strSql.Append("  from Subject ");
			strSql.Append(" where Subject_id=@Subject_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;

			
			university.Model.CCOM.Subject model=new university.Model.CCOM.Subject();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																				model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																																												if(ds.Tables[0].Rows[0]["Subject_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Subject_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Subject_type"].ToString().ToLower()=="true"))
					{
					model.Subject_type= true;
					}
					else
					{
					model.Subject_type= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Value_type"].ToString()!="")
				{
					model.Value_type=int.Parse(ds.Tables[0].Rows[0]["Value_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Value_count"].ToString()!="")
				{
					model.Value_count=int.Parse(ds.Tables[0].Rows[0]["Value_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Manage_Agency_id"].ToString()!="")
				{
					model.Manage_Agency_id=int.Parse(ds.Tables[0].Rows[0]["Manage_Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Major_Agency_id"].ToString()!="")
				{
					model.Major_Agency_id=int.Parse(ds.Tables[0].Rows[0]["Major_Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_weight"].ToString()!="")
				{
					model.Subject_weight=decimal.Parse(ds.Tables[0].Rows[0]["Subject_weight"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_level"].ToString()!="")
				{
					model.Subject_level=int.Parse(ds.Tables[0].Rows[0]["Subject_level"].ToString());
				}
																																				model.Subject_description= ds.Tables[0].Rows[0]["Subject_description"].ToString();
																												if(ds.Tables[0].Rows[0]["Fs_id"].ToString()!="")
				{
					model.Fs_id=int.Parse(ds.Tables[0].Rows[0]["Fs_id"].ToString());
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
		public university.Model.CCOM.Subject GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Subject_id, Subject_title, Subject_type, Value_type, Value_count, Manage_Agency_id, Major_Agency_id, Period_id, Subject_weight, Subject_level, Subject_description, Fs_id  ");			
			strSql.Append("  from Subject ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Subject model=new university.Model.CCOM.Subject();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																				model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																																												if(ds.Tables[0].Rows[0]["Subject_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Subject_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Subject_type"].ToString().ToLower()=="true"))
					{
					model.Subject_type= true;
					}
					else
					{
					model.Subject_type= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Value_type"].ToString()!="")
				{
					model.Value_type=int.Parse(ds.Tables[0].Rows[0]["Value_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Value_count"].ToString()!="")
				{
					model.Value_count=int.Parse(ds.Tables[0].Rows[0]["Value_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Manage_Agency_id"].ToString()!="")
				{
					model.Manage_Agency_id=int.Parse(ds.Tables[0].Rows[0]["Manage_Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Major_Agency_id"].ToString()!="")
				{
					model.Major_Agency_id=int.Parse(ds.Tables[0].Rows[0]["Major_Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_weight"].ToString()!="")
				{
					model.Subject_weight=decimal.Parse(ds.Tables[0].Rows[0]["Subject_weight"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_level"].ToString()!="")
				{
					model.Subject_level=int.Parse(ds.Tables[0].Rows[0]["Subject_level"].ToString());
				}
																																				model.Subject_description= ds.Tables[0].Rows[0]["Subject_description"].ToString();
																												if(ds.Tables[0].Rows[0]["Fs_id"].ToString()!="")
				{
					model.Fs_id=int.Parse(ds.Tables[0].Rows[0]["Fs_id"].ToString());
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
			strSql.Append(" FROM Subject ");
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
			strSql.Append(" FROM Subject ");
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
			strSql.Append(" FROM Subject ");
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
				strSql.Append("order by T.Subject_id desc");
			}
			strSql.Append(")AS Row, T.*  from Subject T ");
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

