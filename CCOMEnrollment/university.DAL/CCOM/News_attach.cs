using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//News_attach
		public partial class News_attach
	{
   		     
		public bool Exists(int News_attach_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News_attach");
			strSql.Append(" where ");
			                                       strSql.Append(" News_attach_id = @News_attach_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@News_attach_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_attach_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.News_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News_attach(");			
            strSql.Append("News_id,News_attach_name,News_attach_address");
			strSql.Append(") values (");
            strSql.Append("@News_id,@News_attach_name,@News_attach_address");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@News_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_attach_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@News_attach_address", SqlDbType.VarChar,256)             
              
            };
			            
            parameters[0].Value = model.News_id;                        
            parameters[1].Value = model.News_attach_name;                        
            parameters[2].Value = model.News_attach_address;                        
			   
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
		public bool Update(university.Model.CCOM.News_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News_attach set ");
			                                                
            strSql.Append(" News_id = @News_id , ");                                    
            strSql.Append(" News_attach_name = @News_attach_name , ");                                    
            strSql.Append(" News_attach_address = @News_attach_address  ");            			
			strSql.Append(" where News_attach_id=@News_attach_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@News_attach_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@News_attach_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@News_attach_address", SqlDbType.VarChar,256)             
              
            };
						            
            parameters[0].Value = model.News_attach_id;                        
            parameters[1].Value = model.News_id;                        
            parameters[2].Value = model.News_attach_name;                        
            parameters[3].Value = model.News_attach_address;                        
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
		public bool Delete(int News_attach_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News_attach ");
			strSql.Append(" where News_attach_id=@News_attach_id");
						SqlParameter[] parameters = {
					new SqlParameter("@News_attach_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_attach_id;


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
			strSql.Append("delete from News_attach ");
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
		public bool DeleteList(string News_attach_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News_attach ");
			strSql.Append(" where News_attach_id in ("+News_attach_idlist + ")  ");
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
		public university.Model.CCOM.News_attach GetModel(int News_attach_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select News_attach_id, News_id, News_attach_name, News_attach_address  ");			
			strSql.Append("  from News_attach ");
			strSql.Append(" where News_attach_id=@News_attach_id");
						SqlParameter[] parameters = {
					new SqlParameter("@News_attach_id", SqlDbType.Int,4)
			};
			parameters[0].Value = News_attach_id;

			
			university.Model.CCOM.News_attach model=new university.Model.CCOM.News_attach();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["News_attach_id"].ToString()!="")
				{
					model.News_attach_id=int.Parse(ds.Tables[0].Rows[0]["News_attach_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_id"].ToString()!="")
				{
					model.News_id=int.Parse(ds.Tables[0].Rows[0]["News_id"].ToString());
				}
																																				model.News_attach_name= ds.Tables[0].Rows[0]["News_attach_name"].ToString();
																																model.News_attach_address= ds.Tables[0].Rows[0]["News_attach_address"].ToString();
																										
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
		public university.Model.CCOM.News_attach GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select News_attach_id, News_id, News_attach_name, News_attach_address  ");			
			strSql.Append("  from News_attach ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.News_attach model=new university.Model.CCOM.News_attach();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["News_attach_id"].ToString()!="")
				{
					model.News_attach_id=int.Parse(ds.Tables[0].Rows[0]["News_attach_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["News_id"].ToString()!="")
				{
					model.News_id=int.Parse(ds.Tables[0].Rows[0]["News_id"].ToString());
				}
																																				model.News_attach_name= ds.Tables[0].Rows[0]["News_attach_name"].ToString();
																																model.News_attach_address= ds.Tables[0].Rows[0]["News_attach_address"].ToString();
																										
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
			strSql.Append(" FROM News_attach ");
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
			strSql.Append(" FROM News_attach ");
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
			strSql.Append(" FROM News_attach ");
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
				strSql.Append("order by T.News_attach_id desc");
			}
			strSql.Append(")AS Row, T.*  from News_attach T ");
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

