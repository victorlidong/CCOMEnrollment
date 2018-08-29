using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Admin_role
		public partial class Admin_role
	{
   		     
		public bool Exists(long Ar_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin_role");
			strSql.Append(" where ");
			                                       strSql.Append(" Ar_id = @Ar_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Ar_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ar_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Admin_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin_role(");			
            strSql.Append("Role_id,User_id");
			strSql.Append(") values (");
            strSql.Append("@Role_id,@User_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
			            
            parameters[0].Value = model.Role_id;                        
            parameters[1].Value = model.User_id;                        
			   
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
		public bool Update(university.Model.CCOM.Admin_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin_role set ");
			                                                
            strSql.Append(" Role_id = @Role_id , ");                                    
            strSql.Append(" User_id = @User_id  ");            			
			strSql.Append(" where Ar_id=@Ar_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Ar_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Role_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
						            
            parameters[0].Value = model.Ar_id;                        
            parameters[1].Value = model.Role_id;                        
            parameters[2].Value = model.User_id;                        
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
		public bool Delete(long Ar_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin_role ");
			strSql.Append(" where Ar_id=@Ar_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ar_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ar_id;


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
			strSql.Append("delete from Admin_role ");
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
		public bool DeleteList(string Ar_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin_role ");
			strSql.Append(" where Ar_id in ("+Ar_idlist + ")  ");
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
		public university.Model.CCOM.Admin_role GetModel(long Ar_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ar_id, Role_id, User_id  ");			
			strSql.Append("  from Admin_role ");
			strSql.Append(" where Ar_id=@Ar_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ar_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ar_id;

			
			university.Model.CCOM.Admin_role model=new university.Model.CCOM.Admin_role();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ar_id"].ToString()!="")
				{
					model.Ar_id=long.Parse(ds.Tables[0].Rows[0]["Ar_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
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
		public university.Model.CCOM.Admin_role GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ar_id, Role_id, User_id  ");			
			strSql.Append("  from Admin_role ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Admin_role model=new university.Model.CCOM.Admin_role();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ar_id"].ToString()!="")
				{
					model.Ar_id=long.Parse(ds.Tables[0].Rows[0]["Ar_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
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
			strSql.Append(" FROM Admin_role ");
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
			strSql.Append(" FROM Admin_role ");
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
			strSql.Append(" FROM Admin_role ");
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
				strSql.Append("order by T.Ar_id desc");
			}
			strSql.Append(")AS Row, T.*  from Admin_role T ");
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

