using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Admin_agency
		public partial class Admin_agency
	{
   		     
		public bool Exists(int Aa_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin_agency");
			strSql.Append(" where ");
			                                       strSql.Append(" Aa_id = @Aa_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Aa_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Aa_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Admin_agency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin_agency(");			
            strSql.Append("User_id,Agency_id");
			strSql.Append(") values (");
            strSql.Append("@User_id,@Agency_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Agency_id;                        
			   
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
		public bool Update(university.Model.CCOM.Admin_agency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin_agency set ");
			                                                
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Agency_id = @Agency_id  ");            			
			strSql.Append(" where Aa_id=@Aa_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Aa_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Aa_id;                        
            parameters[1].Value = model.User_id;                        
            parameters[2].Value = model.Agency_id;                        
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
		public bool Delete(int Aa_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin_agency ");
			strSql.Append(" where Aa_id=@Aa_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Aa_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Aa_id;


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
			strSql.Append("delete from Admin_agency ");
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
		public bool DeleteList(string Aa_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin_agency ");
			strSql.Append(" where Aa_id in ("+Aa_idlist + ")  ");
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
		public university.Model.CCOM.Admin_agency GetModel(int Aa_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Aa_id, User_id, Agency_id  ");			
			strSql.Append("  from Admin_agency ");
			strSql.Append(" where Aa_id=@Aa_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Aa_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Aa_id;

			
			university.Model.CCOM.Admin_agency model=new university.Model.CCOM.Admin_agency();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Aa_id"].ToString()!="")
				{
					model.Aa_id=int.Parse(ds.Tables[0].Rows[0]["Aa_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
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
		public university.Model.CCOM.Admin_agency GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Aa_id, User_id, Agency_id  ");			
			strSql.Append("  from Admin_agency ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Admin_agency model=new university.Model.CCOM.Admin_agency();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Aa_id"].ToString()!="")
				{
					model.Aa_id=int.Parse(ds.Tables[0].Rows[0]["Aa_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
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
			strSql.Append(" FROM Admin_agency ");
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
			strSql.Append(" FROM Admin_agency ");
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
			strSql.Append(" FROM Admin_agency ");
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
				strSql.Append("order by T.Aa_id desc");
			}
			strSql.Append(")AS Row, T.*  from Admin_agency T ");
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

