using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//User_notice
		public partial class User_notice
	{
   		     
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_notice");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
			parameters[0].Value = id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.User_notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_notice(");			
            strSql.Append("User_id,Notice_id,Notice_read_id");
			strSql.Append(") values (");
            strSql.Append("@User_id,@Notice_id,@Notice_read_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_id", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_read_id", SqlDbType.Text)             
              
            };
			            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Notice_id;                        
            parameters[2].Value = model.Notice_read_id;                        
			   
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
		public bool Update(university.Model.CCOM.User_notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_notice set ");
			                                                
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Notice_id = @Notice_id , ");                                    
            strSql.Append(" Notice_read_id = @Notice_read_id  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_id", SqlDbType.Text) ,            
                        new SqlParameter("@Notice_read_id", SqlDbType.Text)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.User_id;                        
            parameters[2].Value = model.Notice_id;                        
            parameters[3].Value = model.Notice_read_id;                        
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
		public bool Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_notice ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
			parameters[0].Value = id;


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
			strSql.Append("delete from User_notice ");
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
		public bool DeleteList(string idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_notice ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public university.Model.CCOM.User_notice GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, User_id, Notice_id, Notice_read_id  ");			
			strSql.Append("  from User_notice ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
			parameters[0].Value = id;

			
			university.Model.CCOM.User_notice model=new university.Model.CCOM.User_notice();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.Notice_id= ds.Tables[0].Rows[0]["Notice_id"].ToString();
																																model.Notice_read_id= ds.Tables[0].Rows[0]["Notice_read_id"].ToString();
																										
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
		public university.Model.CCOM.User_notice GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, User_id, Notice_id, Notice_read_id  ");			
			strSql.Append("  from User_notice ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_notice model=new university.Model.CCOM.User_notice();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.Notice_id= ds.Tables[0].Rows[0]["Notice_id"].ToString();
																																model.Notice_read_id= ds.Tables[0].Rows[0]["Notice_read_id"].ToString();
																										
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
			strSql.Append(" FROM User_notice ");
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
			strSql.Append(" FROM User_notice ");
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
			strSql.Append(" FROM User_notice ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from User_notice T ");
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

