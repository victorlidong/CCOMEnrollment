using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	 	//User_extra_value
		public partial class User_extra_value
	{
   		     
		public bool Exists(long Uev_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_extra_value");
			strSql.Append(" where ");
			                                       strSql.Append(" Uev_id = @Uev_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Uev_id", SqlDbType.BigInt,8)			};
			parameters[0].Value = Uev_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.User_extra_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_extra_value(");			
            strSql.Append("Uev_id,Ue_id,User_id,Uev_value");
			strSql.Append(") values (");
            strSql.Append("@Uev_id,@Ue_id,@User_id,@Uev_value");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Uev_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Ue_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Uev_value", SqlDbType.VarChar,4096)             
              
            };
			            
            parameters[0].Value = model.Uev_id;                        
            parameters[1].Value = model.Ue_id;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.Uev_value;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_extra_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_extra_value set ");
			                        
            strSql.Append(" Uev_id = @Uev_id , ");                                    
            strSql.Append(" Ue_id = @Ue_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Uev_value = @Uev_value  ");            			
			strSql.Append(" where Uev_id=@Uev_id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Uev_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Ue_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Uev_value", SqlDbType.VarChar,4096)             
              
            };
						            
            parameters[0].Value = model.Uev_id;                        
            parameters[1].Value = model.Ue_id;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.Uev_value;                        
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
		public bool Delete(long Uev_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_extra_value ");
			strSql.Append(" where Uev_id=@Uev_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Uev_id", SqlDbType.BigInt,8)			};
			parameters[0].Value = Uev_id;


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
			strSql.Append("delete from User_extra_value ");
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
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_extra_value GetModel(long Uev_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Uev_id, Ue_id, User_id, Uev_value  ");			
			strSql.Append("  from User_extra_value ");
			strSql.Append(" where Uev_id=@Uev_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Uev_id", SqlDbType.BigInt,8)			};
			parameters[0].Value = Uev_id;

			
			university.Model.CCOM.User_extra_value model=new university.Model.CCOM.User_extra_value();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Uev_id"].ToString()!="")
				{
					model.Uev_id=long.Parse(ds.Tables[0].Rows[0]["Uev_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(ds.Tables[0].Rows[0]["Ue_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.Uev_value= ds.Tables[0].Rows[0]["Uev_value"].ToString();
																										
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
		public university.Model.CCOM.User_extra_value GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Uev_id, Ue_id, User_id, Uev_value  ");			
			strSql.Append("  from User_extra_value ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_extra_value model=new university.Model.CCOM.User_extra_value();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Uev_id"].ToString()!="")
				{
					model.Uev_id=long.Parse(ds.Tables[0].Rows[0]["Uev_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(ds.Tables[0].Rows[0]["Ue_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.Uev_value= ds.Tables[0].Rows[0]["Uev_value"].ToString();
																										
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
			strSql.Append(" FROM User_extra_value ");
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
			strSql.Append(" FROM User_extra_value ");
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
			strSql.Append(" FROM User_extra_value ");
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
				strSql.Append("order by T.Uev_id desc");
			}
			strSql.Append(")AS Row, T.*  from User_extra_value T ");
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

