using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Notice
		public partial class Notice
	{
   		     
		public bool Exists(long Notice_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Notice");
			strSql.Append(" where ");
			                                       strSql.Append(" Notice_id = @Notice_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Notice_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Notice(");			
            strSql.Append("Notice_title,Notice_content,Notice_date,Notice_sender_id,Notice_receiver_id,Notice_type,Notice_URL,Notice_type_id,Notice_last_editor,Notice_flag");
			strSql.Append(") values (");
            strSql.Append("@Notice_title,@Notice_content,@Notice_date,@Notice_sender_id,@Notice_receiver_id,@Notice_type,@Notice_URL,@Notice_type_id,@Notice_last_editor,@Notice_flag");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Notice_title", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Notice_content", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@Notice_sender_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_receiver_id", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Notice_URL", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Notice_type_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_last_editor", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_flag", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Notice_title;                        
            parameters[1].Value = model.Notice_content;                        
            parameters[2].Value = model.Notice_date;                        
            parameters[3].Value = model.Notice_sender_id;                        
            parameters[4].Value = model.Notice_receiver_id;                        
            parameters[5].Value = model.Notice_type;                        
            parameters[6].Value = model.Notice_URL;                        
            parameters[7].Value = model.Notice_type_id;                        
            parameters[8].Value = model.Notice_last_editor;                        
            parameters[9].Value = model.Notice_flag;                        
			   
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
		public bool Update(university.Model.CCOM.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Notice set ");
			                                                
            strSql.Append(" Notice_title = @Notice_title , ");                                    
            strSql.Append(" Notice_content = @Notice_content , ");                                    
            strSql.Append(" Notice_date = @Notice_date , ");                                    
            strSql.Append(" Notice_sender_id = @Notice_sender_id , ");                                    
            strSql.Append(" Notice_receiver_id = @Notice_receiver_id , ");                                    
            strSql.Append(" Notice_type = @Notice_type , ");                                    
            strSql.Append(" Notice_URL = @Notice_URL , ");                                    
            strSql.Append(" Notice_type_id = @Notice_type_id , ");                                    
            strSql.Append(" Notice_last_editor = @Notice_last_editor , ");                                    
            strSql.Append(" Notice_flag = @Notice_flag  ");            			
			strSql.Append(" where Notice_id=@Notice_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Notice_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_title", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Notice_content", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@Notice_sender_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_receiver_id", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Notice_URL", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Notice_type_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_last_editor", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_flag", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Notice_id;                        
            parameters[1].Value = model.Notice_title;                        
            parameters[2].Value = model.Notice_content;                        
            parameters[3].Value = model.Notice_date;                        
            parameters[4].Value = model.Notice_sender_id;                        
            parameters[5].Value = model.Notice_receiver_id;                        
            parameters[6].Value = model.Notice_type;                        
            parameters[7].Value = model.Notice_URL;                        
            parameters[8].Value = model.Notice_type_id;                        
            parameters[9].Value = model.Notice_last_editor;                        
            parameters[10].Value = model.Notice_flag;                        
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
		public bool Delete(long Notice_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
			strSql.Append(" where Notice_id=@Notice_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Notice_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_id;


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
			strSql.Append("delete from Notice ");
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
		public bool DeleteList(string Notice_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
			strSql.Append(" where Notice_id in ("+Notice_idlist + ")  ");
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
		public university.Model.CCOM.Notice GetModel(long Notice_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Notice_id, Notice_title, Notice_content, Notice_date, Notice_sender_id, Notice_receiver_id, Notice_type, Notice_URL, Notice_type_id, Notice_last_editor, Notice_flag  ");			
			strSql.Append("  from Notice ");
			strSql.Append(" where Notice_id=@Notice_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Notice_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_id;

			
			university.Model.CCOM.Notice model=new university.Model.CCOM.Notice();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																				model.Notice_title= ds.Tables[0].Rows[0]["Notice_title"].ToString();
																																model.Notice_content= ds.Tables[0].Rows[0]["Notice_content"].ToString();
																												if(ds.Tables[0].Rows[0]["Notice_date"].ToString()!="")
				{
					model.Notice_date=DateTime.Parse(ds.Tables[0].Rows[0]["Notice_date"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_sender_id"].ToString()!="")
				{
					model.Notice_sender_id=long.Parse(ds.Tables[0].Rows[0]["Notice_sender_id"].ToString());
				}
																																				model.Notice_receiver_id= ds.Tables[0].Rows[0]["Notice_receiver_id"].ToString();
																																												if(ds.Tables[0].Rows[0]["Notice_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Notice_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Notice_type"].ToString().ToLower()=="true"))
					{
					model.Notice_type= true;
					}
					else
					{
					model.Notice_type= false;
					}
				}
																				model.Notice_URL= ds.Tables[0].Rows[0]["Notice_URL"].ToString();
																												if(ds.Tables[0].Rows[0]["Notice_type_id"].ToString()!="")
				{
					model.Notice_type_id=long.Parse(ds.Tables[0].Rows[0]["Notice_type_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_last_editor"].ToString()!="")
				{
					model.Notice_last_editor=long.Parse(ds.Tables[0].Rows[0]["Notice_last_editor"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Notice_flag"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Notice_flag"].ToString()=="1")||(ds.Tables[0].Rows[0]["Notice_flag"].ToString().ToLower()=="true"))
					{
					model.Notice_flag= true;
					}
					else
					{
					model.Notice_flag= false;
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
		public university.Model.CCOM.Notice GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Notice_id, Notice_title, Notice_content, Notice_date, Notice_sender_id, Notice_receiver_id, Notice_type, Notice_URL, Notice_type_id, Notice_last_editor, Notice_flag  ");			
			strSql.Append("  from Notice ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Notice model=new university.Model.CCOM.Notice();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																				model.Notice_title= ds.Tables[0].Rows[0]["Notice_title"].ToString();
																																model.Notice_content= ds.Tables[0].Rows[0]["Notice_content"].ToString();
																												if(ds.Tables[0].Rows[0]["Notice_date"].ToString()!="")
				{
					model.Notice_date=DateTime.Parse(ds.Tables[0].Rows[0]["Notice_date"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_sender_id"].ToString()!="")
				{
					model.Notice_sender_id=long.Parse(ds.Tables[0].Rows[0]["Notice_sender_id"].ToString());
				}
																																				model.Notice_receiver_id= ds.Tables[0].Rows[0]["Notice_receiver_id"].ToString();
																																												if(ds.Tables[0].Rows[0]["Notice_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Notice_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Notice_type"].ToString().ToLower()=="true"))
					{
					model.Notice_type= true;
					}
					else
					{
					model.Notice_type= false;
					}
				}
																				model.Notice_URL= ds.Tables[0].Rows[0]["Notice_URL"].ToString();
																												if(ds.Tables[0].Rows[0]["Notice_type_id"].ToString()!="")
				{
					model.Notice_type_id=long.Parse(ds.Tables[0].Rows[0]["Notice_type_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_last_editor"].ToString()!="")
				{
					model.Notice_last_editor=long.Parse(ds.Tables[0].Rows[0]["Notice_last_editor"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Notice_flag"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Notice_flag"].ToString()=="1")||(ds.Tables[0].Rows[0]["Notice_flag"].ToString().ToLower()=="true"))
					{
					model.Notice_flag= true;
					}
					else
					{
					model.Notice_flag= false;
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
			strSql.Append(" FROM Notice ");
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
			strSql.Append(" FROM Notice ");
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
			strSql.Append(" FROM Notice ");
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
				strSql.Append("order by T.Notice_id desc");
			}
			strSql.Append(")AS Row, T.*  from Notice T ");
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

