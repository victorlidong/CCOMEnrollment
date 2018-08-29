using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	 	//User_subject_record
		public partial class User_subject_record
	{
   		     
		public bool Exists(long Usr_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_subject_record");
			strSql.Append(" where ");
			                                       strSql.Append(" Usr_id = @Usr_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Usr_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Usr_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.User_subject_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_subject_record(");			
            strSql.Append("Esn_id,User_id,Usr_addtime");
			strSql.Append(") values (");
            strSql.Append("@Esn_id,@User_id,@Usr_addtime");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Usr_addtime", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.Esn_id;                        
            parameters[1].Value = model.User_id;                        
            parameters[2].Value = model.Usr_addtime;                        
			   
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
		public bool Update(university.Model.CCOM.User_subject_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_subject_record set ");
			                                                
            strSql.Append(" Esn_id = @Esn_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Usr_addtime = @Usr_addtime  ");            			
			strSql.Append(" where Usr_id=@Usr_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Usr_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Usr_addtime", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.Usr_id;                        
            parameters[1].Value = model.Esn_id;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.Usr_addtime;                        
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
		public bool Delete(long Usr_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_subject_record ");
			strSql.Append(" where Usr_id=@Usr_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Usr_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Usr_id;


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
			strSql.Append("delete from User_subject_record ");
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
		public bool DeleteList(string Usr_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_subject_record ");
			strSql.Append(" where Usr_id in ("+Usr_idlist + ")  ");
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
		public university.Model.CCOM.User_subject_record GetModel(long Usr_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Usr_id, Esn_id, User_id, Usr_addtime  ");			
			strSql.Append("  from User_subject_record ");
			strSql.Append(" where Usr_id=@Usr_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Usr_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Usr_id;

			
			university.Model.CCOM.User_subject_record model=new university.Model.CCOM.User_subject_record();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Usr_id"].ToString()!="")
				{
					model.Usr_id=long.Parse(ds.Tables[0].Rows[0]["Usr_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Usr_addtime"].ToString()!="")
				{
					model.Usr_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Usr_addtime"].ToString());
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
		public university.Model.CCOM.User_subject_record GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Usr_id, Esn_id, User_id, Usr_addtime  ");			
			strSql.Append("  from User_subject_record ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_subject_record model=new university.Model.CCOM.User_subject_record();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Usr_id"].ToString()!="")
				{
					model.Usr_id=long.Parse(ds.Tables[0].Rows[0]["Usr_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Usr_addtime"].ToString()!="")
				{
					model.Usr_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Usr_addtime"].ToString());
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
			strSql.Append(" FROM User_subject_record ");
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
			strSql.Append(" FROM User_subject_record ");
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
			strSql.Append(" FROM User_subject_record ");
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
				strSql.Append("order by T.Usr_id desc");
			}
			strSql.Append(")AS Row, T.*  from User_subject_record T ");
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

