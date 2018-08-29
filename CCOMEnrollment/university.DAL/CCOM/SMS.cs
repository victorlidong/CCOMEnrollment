using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//SMS
		public partial class SMS
	{
   		     
		public bool Exists(long SMS_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMS");
			strSql.Append(" where ");
			                                       strSql.Append(" SMS_id = @SMS_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@SMS_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.SMS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMS(");			
            strSql.Append("Notice_id,SMS_sender_id,SMS_receiver_id,SMS_content,SMS_date");
			strSql.Append(") values (");
            strSql.Append("@Notice_id,@SMS_sender_id,@SMS_receiver_id,@SMS_content,@SMS_date");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Notice_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_sender_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_receiver_id", SqlDbType.Text) ,            
                        new SqlParameter("@SMS_content", SqlDbType.Text) ,            
                        new SqlParameter("@SMS_date", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.Notice_id;                        
            parameters[1].Value = model.SMS_sender_id;                        
            parameters[2].Value = model.SMS_receiver_id;                        
            parameters[3].Value = model.SMS_content;                        
            parameters[4].Value = model.SMS_date;                        
			   
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
		public bool Update(university.Model.CCOM.SMS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMS set ");
			                                                
            strSql.Append(" Notice_id = @Notice_id , ");                                    
            strSql.Append(" SMS_sender_id = @SMS_sender_id , ");                                    
            strSql.Append(" SMS_receiver_id = @SMS_receiver_id , ");                                    
            strSql.Append(" SMS_content = @SMS_content , ");                                    
            strSql.Append(" SMS_date = @SMS_date  ");            			
			strSql.Append(" where SMS_id=@SMS_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@SMS_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_sender_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_receiver_id", SqlDbType.Text) ,            
                        new SqlParameter("@SMS_content", SqlDbType.Text) ,            
                        new SqlParameter("@SMS_date", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.SMS_id;                        
            parameters[1].Value = model.Notice_id;                        
            parameters[2].Value = model.SMS_sender_id;                        
            parameters[3].Value = model.SMS_receiver_id;                        
            parameters[4].Value = model.SMS_content;                        
            parameters[5].Value = model.SMS_date;                        
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
		public bool Delete(long SMS_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMS ");
			strSql.Append(" where SMS_id=@SMS_id");
						SqlParameter[] parameters = {
					new SqlParameter("@SMS_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_id;


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
			strSql.Append("delete from SMS ");
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
		public bool DeleteList(string SMS_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMS ");
			strSql.Append(" where SMS_id in ("+SMS_idlist + ")  ");
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
		public university.Model.CCOM.SMS GetModel(long SMS_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SMS_id, Notice_id, SMS_sender_id, SMS_receiver_id, SMS_content, SMS_date  ");			
			strSql.Append("  from SMS ");
			strSql.Append(" where SMS_id=@SMS_id");
						SqlParameter[] parameters = {
					new SqlParameter("@SMS_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_id;

			
			university.Model.CCOM.SMS model=new university.Model.CCOM.SMS();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["SMS_id"].ToString()!="")
				{
					model.SMS_id=long.Parse(ds.Tables[0].Rows[0]["SMS_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_sender_id"].ToString()!="")
				{
					model.SMS_sender_id=long.Parse(ds.Tables[0].Rows[0]["SMS_sender_id"].ToString());
				}
																																				model.SMS_receiver_id= ds.Tables[0].Rows[0]["SMS_receiver_id"].ToString();
																																model.SMS_content= ds.Tables[0].Rows[0]["SMS_content"].ToString();
																												if(ds.Tables[0].Rows[0]["SMS_date"].ToString()!="")
				{
					model.SMS_date=DateTime.Parse(ds.Tables[0].Rows[0]["SMS_date"].ToString());
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
		public university.Model.CCOM.SMS GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SMS_id, Notice_id, SMS_sender_id, SMS_receiver_id, SMS_content, SMS_date  ");			
			strSql.Append("  from SMS ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.SMS model=new university.Model.CCOM.SMS();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["SMS_id"].ToString()!="")
				{
					model.SMS_id=long.Parse(ds.Tables[0].Rows[0]["SMS_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_sender_id"].ToString()!="")
				{
					model.SMS_sender_id=long.Parse(ds.Tables[0].Rows[0]["SMS_sender_id"].ToString());
				}
																																				model.SMS_receiver_id= ds.Tables[0].Rows[0]["SMS_receiver_id"].ToString();
																																model.SMS_content= ds.Tables[0].Rows[0]["SMS_content"].ToString();
																												if(ds.Tables[0].Rows[0]["SMS_date"].ToString()!="")
				{
					model.SMS_date=DateTime.Parse(ds.Tables[0].Rows[0]["SMS_date"].ToString());
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
			strSql.Append(" FROM SMS ");
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
			strSql.Append(" FROM SMS ");
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
			strSql.Append(" FROM SMS ");
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
				strSql.Append("order by T.SMS_id desc");
			}
			strSql.Append(")AS Row, T.*  from SMS T ");
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

