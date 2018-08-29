using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//News
		public partial class News
	{
   		     
		public bool Exists(int News_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News");
			strSql.Append(" where ");
			                                       strSql.Append(" News_id = @News_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@News_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News(");			
            strSql.Append("News_type_id,News_title,News_creator_id,News_content,News_date,News_URL,News_readnumber,News_last_editor,News_top,News_top_time");
			strSql.Append(") values (");
            strSql.Append("@News_type_id,@News_title,@News_creator_id,@News_content,@News_date,@News_URL,@News_readnumber,@News_last_editor,@News_top,@News_top_time");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@News_type_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@News_creator_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_content", SqlDbType.Text) ,            
                        new SqlParameter("@News_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@News_URL", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@News_readnumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_last_editor", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_top", SqlDbType.Bit,1) ,            
                        new SqlParameter("@News_top_time", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.News_type_id;                        
            parameters[1].Value = model.News_title;                        
            parameters[2].Value = model.News_creator_id;                        
            parameters[3].Value = model.News_content;                        
            parameters[4].Value = model.News_date;                        
            parameters[5].Value = model.News_URL;                        
            parameters[6].Value = model.News_readnumber;                        
            parameters[7].Value = model.News_last_editor;                        
            parameters[8].Value = model.News_top;                        
            parameters[9].Value = model.News_top_time;                        
			   
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
		public bool Update(university.Model.CCOM.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News set ");
			                                                
            strSql.Append(" News_type_id = @News_type_id , ");                                    
            strSql.Append(" News_title = @News_title , ");                                    
            strSql.Append(" News_creator_id = @News_creator_id , ");                                    
            strSql.Append(" News_content = @News_content , ");                                    
            strSql.Append(" News_date = @News_date , ");                                    
            strSql.Append(" News_URL = @News_URL , ");                                    
            strSql.Append(" News_readnumber = @News_readnumber , ");                                    
            strSql.Append(" News_last_editor = @News_last_editor , ");                                    
            strSql.Append(" News_top = @News_top , ");                                    
            strSql.Append(" News_top_time = @News_top_time  ");            			
			strSql.Append(" where News_id=@News_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@News_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_type_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@News_creator_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_content", SqlDbType.Text) ,            
                        new SqlParameter("@News_date", SqlDbType.DateTime) ,            
                        new SqlParameter("@News_URL", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@News_readnumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_last_editor", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_top", SqlDbType.Bit,1) ,            
                        new SqlParameter("@News_top_time", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.News_id;                        
            parameters[1].Value = model.News_type_id;                        
            parameters[2].Value = model.News_title;                        
            parameters[3].Value = model.News_creator_id;                        
            parameters[4].Value = model.News_content;                        
            parameters[5].Value = model.News_date;                        
            parameters[6].Value = model.News_URL;                        
            parameters[7].Value = model.News_readnumber;                        
            parameters[8].Value = model.News_last_editor;                        
            parameters[9].Value = model.News_top;                        
            parameters[10].Value = model.News_top_time;                        
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
		public bool Delete(int News_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where News_id=@News_id");
						SqlParameter[] parameters = {
					new SqlParameter("@News_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_id;


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
			strSql.Append("delete from News ");
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
		public bool DeleteList(string News_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where News_id in ("+News_idlist + ")  ");
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
		public university.Model.CCOM.News GetModel(int News_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select News_id, News_type_id, News_title, News_creator_id, News_content, News_date, News_URL, News_readnumber, News_last_editor, News_top, News_top_time  ");			
			strSql.Append("  from News ");
			strSql.Append(" where News_id=@News_id");
						SqlParameter[] parameters = {
					new SqlParameter("@News_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_id;

			
			university.Model.CCOM.News model=new university.Model.CCOM.News();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["News_id"].ToString()!="")
				{
					model.News_id=int.Parse(ds.Tables[0].Rows[0]["News_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_type_id"].ToString()!="")
				{
					model.News_type_id=int.Parse(ds.Tables[0].Rows[0]["News_type_id"].ToString());
				}
																																				model.News_title= ds.Tables[0].Rows[0]["News_title"].ToString();
																												if(ds.Tables[0].Rows[0]["News_creator_id"].ToString()!="")
				{
					model.News_creator_id=int.Parse(ds.Tables[0].Rows[0]["News_creator_id"].ToString());
				}
																																				model.News_content= ds.Tables[0].Rows[0]["News_content"].ToString();
																												if(ds.Tables[0].Rows[0]["News_date"].ToString()!="")
				{
					model.News_date=DateTime.Parse(ds.Tables[0].Rows[0]["News_date"].ToString());
				}
																																				model.News_URL= ds.Tables[0].Rows[0]["News_URL"].ToString();
																												if(ds.Tables[0].Rows[0]["News_readnumber"].ToString()!="")
				{
					model.News_readnumber=int.Parse(ds.Tables[0].Rows[0]["News_readnumber"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_last_editor"].ToString()!="")
				{
					model.News_last_editor=int.Parse(ds.Tables[0].Rows[0]["News_last_editor"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["News_top"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["News_top"].ToString()=="1")||(ds.Tables[0].Rows[0]["News_top"].ToString().ToLower()=="true"))
					{
					model.News_top= true;
					}
					else
					{
					model.News_top= false;
					}
				}
																if(ds.Tables[0].Rows[0]["News_top_time"].ToString()!="")
				{
					model.News_top_time=int.Parse(ds.Tables[0].Rows[0]["News_top_time"].ToString());
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
		public university.Model.CCOM.News GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select News_id, News_type_id, News_title, News_creator_id, News_content, News_date, News_URL, News_readnumber, News_last_editor, News_top, News_top_time  ");			
			strSql.Append("  from News ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.News model=new university.Model.CCOM.News();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["News_id"].ToString()!="")
				{
					model.News_id=int.Parse(ds.Tables[0].Rows[0]["News_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_type_id"].ToString()!="")
				{
					model.News_type_id=int.Parse(ds.Tables[0].Rows[0]["News_type_id"].ToString());
				}
																																				model.News_title= ds.Tables[0].Rows[0]["News_title"].ToString();
																												if(ds.Tables[0].Rows[0]["News_creator_id"].ToString()!="")
				{
					model.News_creator_id=int.Parse(ds.Tables[0].Rows[0]["News_creator_id"].ToString());
				}
																																				model.News_content= ds.Tables[0].Rows[0]["News_content"].ToString();
																												if(ds.Tables[0].Rows[0]["News_date"].ToString()!="")
				{
					model.News_date=DateTime.Parse(ds.Tables[0].Rows[0]["News_date"].ToString());
				}
																																				model.News_URL= ds.Tables[0].Rows[0]["News_URL"].ToString();
																												if(ds.Tables[0].Rows[0]["News_readnumber"].ToString()!="")
				{
					model.News_readnumber=int.Parse(ds.Tables[0].Rows[0]["News_readnumber"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_last_editor"].ToString()!="")
				{
					model.News_last_editor=int.Parse(ds.Tables[0].Rows[0]["News_last_editor"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["News_top"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["News_top"].ToString()=="1")||(ds.Tables[0].Rows[0]["News_top"].ToString().ToLower()=="true"))
					{
					model.News_top= true;
					}
					else
					{
					model.News_top= false;
					}
				}
																if(ds.Tables[0].Rows[0]["News_top_time"].ToString()!="")
				{
					model.News_top_time=int.Parse(ds.Tables[0].Rows[0]["News_top_time"].ToString());
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
			strSql.Append(" FROM News ");
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
			strSql.Append(" FROM News ");
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
			strSql.Append(" FROM News ");
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
				strSql.Append("order by T.News_id desc");
			}
			strSql.Append(")AS Row, T.*  from News T ");
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

