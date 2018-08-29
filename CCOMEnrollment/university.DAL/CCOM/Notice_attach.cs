using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Notice_attach
		public partial class Notice_attach
	{
   		     
		public bool Exists(long Notice_attach_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Notice_attach");
			strSql.Append(" where ");
			                                       strSql.Append(" Notice_attach_id = @Notice_attach_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Notice_attach_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_attach_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Notice_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Notice_attach(");			
            strSql.Append("Notice_id,Notice_attach_name,Notice_attach_address");
			strSql.Append(") values (");
            strSql.Append("@Notice_id,@Notice_attach_name,@Notice_attach_address");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Notice_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_attach_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Notice_attach_address", SqlDbType.VarChar,256)             
              
            };
			            
            parameters[0].Value = model.Notice_id;                        
            parameters[1].Value = model.Notice_attach_name;                        
            parameters[2].Value = model.Notice_attach_address;                        
			   
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
		public bool Update(university.Model.CCOM.Notice_attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Notice_attach set ");
			                                                
            strSql.Append(" Notice_id = @Notice_id , ");                                    
            strSql.Append(" Notice_attach_name = @Notice_attach_name , ");                                    
            strSql.Append(" Notice_attach_address = @Notice_attach_address  ");            			
			strSql.Append(" where Notice_attach_id=@Notice_attach_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Notice_attach_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Notice_attach_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Notice_attach_address", SqlDbType.VarChar,256)             
              
            };
						            
            parameters[0].Value = model.Notice_attach_id;                        
            parameters[1].Value = model.Notice_id;                        
            parameters[2].Value = model.Notice_attach_name;                        
            parameters[3].Value = model.Notice_attach_address;                        
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
		public bool Delete(long Notice_attach_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice_attach ");
			strSql.Append(" where Notice_attach_id=@Notice_attach_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Notice_attach_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_attach_id;


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
			strSql.Append("delete from Notice_attach ");
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
		public bool DeleteList(string Notice_attach_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice_attach ");
			strSql.Append(" where Notice_attach_id in ("+Notice_attach_idlist + ")  ");
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
		public university.Model.CCOM.Notice_attach GetModel(long Notice_attach_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Notice_attach_id, Notice_id, Notice_attach_name, Notice_attach_address  ");			
			strSql.Append("  from Notice_attach ");
			strSql.Append(" where Notice_attach_id=@Notice_attach_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Notice_attach_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Notice_attach_id;

			
			university.Model.CCOM.Notice_attach model=new university.Model.CCOM.Notice_attach();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Notice_attach_id"].ToString()!="")
				{
					model.Notice_attach_id=long.Parse(ds.Tables[0].Rows[0]["Notice_attach_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																				model.Notice_attach_name= ds.Tables[0].Rows[0]["Notice_attach_name"].ToString();
																																model.Notice_attach_address= ds.Tables[0].Rows[0]["Notice_attach_address"].ToString();
																										
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
		public university.Model.CCOM.Notice_attach GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Notice_attach_id, Notice_id, Notice_attach_name, Notice_attach_address  ");			
			strSql.Append("  from Notice_attach ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Notice_attach model=new university.Model.CCOM.Notice_attach();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Notice_attach_id"].ToString()!="")
				{
					model.Notice_attach_id=long.Parse(ds.Tables[0].Rows[0]["Notice_attach_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(ds.Tables[0].Rows[0]["Notice_id"].ToString());
				}
																																				model.Notice_attach_name= ds.Tables[0].Rows[0]["Notice_attach_name"].ToString();
																																model.Notice_attach_address= ds.Tables[0].Rows[0]["Notice_attach_address"].ToString();
																										
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
			strSql.Append(" FROM Notice_attach ");
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
			strSql.Append(" FROM Notice_attach ");
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
			strSql.Append(" FROM Notice_attach ");
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
				strSql.Append("order by T.Notice_attach_id desc");
			}
			strSql.Append(")AS Row, T.*  from Notice_attach T ");
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

