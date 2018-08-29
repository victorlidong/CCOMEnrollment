using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//SMS_apply_record
		public partial class SMS_apply_record
	{
   		     
		public bool Exists(long SMS_apply_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMS_apply_record");
			strSql.Append(" where ");
			                                       strSql.Append(" SMS_apply_id = @SMS_apply_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@SMS_apply_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_apply_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.SMS_apply_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMS_apply_record(");			
            strSql.Append("SMS_apply_number,SMS_apply_status,SMS_apply_reason,SMS_apply_type,User_id,SMS_give_number,SMS_apply_time,SMS_check_reason");
			strSql.Append(") values (");
            strSql.Append("@SMS_apply_number,@SMS_apply_status,@SMS_apply_reason,@SMS_apply_type,@User_id,@SMS_give_number,@SMS_apply_time,@SMS_check_reason");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@SMS_apply_number", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_reason", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@SMS_apply_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_give_number", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@SMS_check_reason", SqlDbType.VarChar,1024)             
              
            };
			            
            parameters[0].Value = model.SMS_apply_number;                        
            parameters[1].Value = model.SMS_apply_status;                        
            parameters[2].Value = model.SMS_apply_reason;                        
            parameters[3].Value = model.SMS_apply_type;                        
            parameters[4].Value = model.User_id;                        
            parameters[5].Value = model.SMS_give_number;                        
            parameters[6].Value = model.SMS_apply_time;                        
            parameters[7].Value = model.SMS_check_reason;                        
			   
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
		public bool Update(university.Model.CCOM.SMS_apply_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMS_apply_record set ");
			                                                
            strSql.Append(" SMS_apply_number = @SMS_apply_number , ");                                    
            strSql.Append(" SMS_apply_status = @SMS_apply_status , ");                                    
            strSql.Append(" SMS_apply_reason = @SMS_apply_reason , ");                                    
            strSql.Append(" SMS_apply_type = @SMS_apply_type , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" SMS_give_number = @SMS_give_number , ");                                    
            strSql.Append(" SMS_apply_time = @SMS_apply_time , ");                                    
            strSql.Append(" SMS_check_reason = @SMS_check_reason  ");            			
			strSql.Append(" where SMS_apply_id=@SMS_apply_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@SMS_apply_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_apply_number", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_reason", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@SMS_apply_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SMS_give_number", SqlDbType.Int,4) ,            
                        new SqlParameter("@SMS_apply_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@SMS_check_reason", SqlDbType.VarChar,1024)             
              
            };
						            
            parameters[0].Value = model.SMS_apply_id;                        
            parameters[1].Value = model.SMS_apply_number;                        
            parameters[2].Value = model.SMS_apply_status;                        
            parameters[3].Value = model.SMS_apply_reason;                        
            parameters[4].Value = model.SMS_apply_type;                        
            parameters[5].Value = model.User_id;                        
            parameters[6].Value = model.SMS_give_number;                        
            parameters[7].Value = model.SMS_apply_time;                        
            parameters[8].Value = model.SMS_check_reason;                        
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
		public bool Delete(long SMS_apply_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMS_apply_record ");
			strSql.Append(" where SMS_apply_id=@SMS_apply_id");
						SqlParameter[] parameters = {
					new SqlParameter("@SMS_apply_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_apply_id;


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
			strSql.Append("delete from SMS_apply_record ");
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
		public bool DeleteList(string SMS_apply_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMS_apply_record ");
			strSql.Append(" where SMS_apply_id in ("+SMS_apply_idlist + ")  ");
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
		public university.Model.CCOM.SMS_apply_record GetModel(long SMS_apply_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SMS_apply_id, SMS_apply_number, SMS_apply_status, SMS_apply_reason, SMS_apply_type, User_id, SMS_give_number, SMS_apply_time, SMS_check_reason  ");			
			strSql.Append("  from SMS_apply_record ");
			strSql.Append(" where SMS_apply_id=@SMS_apply_id");
						SqlParameter[] parameters = {
					new SqlParameter("@SMS_apply_id", SqlDbType.BigInt)
			};
			parameters[0].Value = SMS_apply_id;

			
			university.Model.CCOM.SMS_apply_record model=new university.Model.CCOM.SMS_apply_record();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["SMS_apply_id"].ToString()!="")
				{
					model.SMS_apply_id=long.Parse(ds.Tables[0].Rows[0]["SMS_apply_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_number"].ToString()!="")
				{
					model.SMS_apply_number=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_number"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_status"].ToString()!="")
				{
					model.SMS_apply_status=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_status"].ToString());
				}
																																				model.SMS_apply_reason= ds.Tables[0].Rows[0]["SMS_apply_reason"].ToString();
																												if(ds.Tables[0].Rows[0]["SMS_apply_type"].ToString()!="")
				{
					model.SMS_apply_type=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_give_number"].ToString()!="")
				{
					model.SMS_give_number=int.Parse(ds.Tables[0].Rows[0]["SMS_give_number"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_time"].ToString()!="")
				{
					model.SMS_apply_time=DateTime.Parse(ds.Tables[0].Rows[0]["SMS_apply_time"].ToString());
				}
																																				model.SMS_check_reason= ds.Tables[0].Rows[0]["SMS_check_reason"].ToString();
																										
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
		public university.Model.CCOM.SMS_apply_record GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SMS_apply_id, SMS_apply_number, SMS_apply_status, SMS_apply_reason, SMS_apply_type, User_id, SMS_give_number, SMS_apply_time, SMS_check_reason  ");			
			strSql.Append("  from SMS_apply_record ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.SMS_apply_record model=new university.Model.CCOM.SMS_apply_record();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["SMS_apply_id"].ToString()!="")
				{
					model.SMS_apply_id=long.Parse(ds.Tables[0].Rows[0]["SMS_apply_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_number"].ToString()!="")
				{
					model.SMS_apply_number=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_number"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_status"].ToString()!="")
				{
					model.SMS_apply_status=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_status"].ToString());
				}
																																				model.SMS_apply_reason= ds.Tables[0].Rows[0]["SMS_apply_reason"].ToString();
																												if(ds.Tables[0].Rows[0]["SMS_apply_type"].ToString()!="")
				{
					model.SMS_apply_type=int.Parse(ds.Tables[0].Rows[0]["SMS_apply_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_give_number"].ToString()!="")
				{
					model.SMS_give_number=int.Parse(ds.Tables[0].Rows[0]["SMS_give_number"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SMS_apply_time"].ToString()!="")
				{
					model.SMS_apply_time=DateTime.Parse(ds.Tables[0].Rows[0]["SMS_apply_time"].ToString());
				}
																																				model.SMS_check_reason= ds.Tables[0].Rows[0]["SMS_check_reason"].ToString();
																										
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
			strSql.Append(" FROM SMS_apply_record ");
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
			strSql.Append(" FROM SMS_apply_record ");
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
			strSql.Append(" FROM SMS_apply_record ");
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
				strSql.Append("order by T.SMS_apply_id desc");
			}
			strSql.Append(")AS Row, T.*  from SMS_apply_record T ");
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

