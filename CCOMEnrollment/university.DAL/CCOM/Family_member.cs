using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Family_member
		public partial class Family_member
	{
   		     
		public bool Exists(long Fm_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Family_member");
			strSql.Append(" where ");
			                                       strSql.Append(" Fm_id = @Fm_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Fm_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fm_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Family_member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Family_member(");			
            strSql.Append("Fm_name,Fm_relationship,Fm_company,Fm_phone,Fm_politics,User_id");
			strSql.Append(") values (");
            strSql.Append("@Fm_name,@Fm_relationship,@Fm_company,@Fm_phone,@Fm_politics,@User_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Fm_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Fm_relationship", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Fm_company", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Fm_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Fm_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
			            
            parameters[0].Value = model.Fm_name;                        
            parameters[1].Value = model.Fm_relationship;                        
            parameters[2].Value = model.Fm_company;                        
            parameters[3].Value = model.Fm_phone;                        
            parameters[4].Value = model.Fm_politics;                        
            parameters[5].Value = model.User_id;                        
			   
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
		public bool Update(university.Model.CCOM.Family_member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Family_member set ");
			                                                
            strSql.Append(" Fm_name = @Fm_name , ");                                    
            strSql.Append(" Fm_relationship = @Fm_relationship , ");                                    
            strSql.Append(" Fm_company = @Fm_company , ");                                    
            strSql.Append(" Fm_phone = @Fm_phone , ");                                    
            strSql.Append(" Fm_politics = @Fm_politics , ");                                    
            strSql.Append(" User_id = @User_id  ");            			
			strSql.Append(" where Fm_id=@Fm_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Fm_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Fm_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Fm_relationship", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Fm_company", SqlDbType.VarChar,256) ,            
                        new SqlParameter("@Fm_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Fm_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
						            
            parameters[0].Value = model.Fm_id;                        
            parameters[1].Value = model.Fm_name;                        
            parameters[2].Value = model.Fm_relationship;                        
            parameters[3].Value = model.Fm_company;                        
            parameters[4].Value = model.Fm_phone;                        
            parameters[5].Value = model.Fm_politics;                        
            parameters[6].Value = model.User_id;                        
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
		public bool Delete(long Fm_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Family_member ");
			strSql.Append(" where Fm_id=@Fm_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Fm_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fm_id;


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
			strSql.Append("delete from Family_member ");
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
		public bool DeleteList(string Fm_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Family_member ");
			strSql.Append(" where Fm_id in ("+Fm_idlist + ")  ");
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
		public university.Model.CCOM.Family_member GetModel(long Fm_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Fm_id, Fm_name, Fm_relationship, Fm_company, Fm_phone, Fm_politics, User_id  ");			
			strSql.Append("  from Family_member ");
			strSql.Append(" where Fm_id=@Fm_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Fm_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Fm_id;

			
			university.Model.CCOM.Family_member model=new university.Model.CCOM.Family_member();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Fm_id"].ToString()!="")
				{
					model.Fm_id=long.Parse(ds.Tables[0].Rows[0]["Fm_id"].ToString());
				}
																																				model.Fm_name= ds.Tables[0].Rows[0]["Fm_name"].ToString();
																																model.Fm_relationship= ds.Tables[0].Rows[0]["Fm_relationship"].ToString();
																																model.Fm_company= ds.Tables[0].Rows[0]["Fm_company"].ToString();
																																model.Fm_phone= ds.Tables[0].Rows[0]["Fm_phone"].ToString();
																												if(ds.Tables[0].Rows[0]["Fm_politics"].ToString()!="")
				{
					model.Fm_politics=int.Parse(ds.Tables[0].Rows[0]["Fm_politics"].ToString());
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
		public university.Model.CCOM.Family_member GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Fm_id, Fm_name, Fm_relationship, Fm_company, Fm_phone, Fm_politics, User_id  ");			
			strSql.Append("  from Family_member ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Family_member model=new university.Model.CCOM.Family_member();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Fm_id"].ToString()!="")
				{
					model.Fm_id=long.Parse(ds.Tables[0].Rows[0]["Fm_id"].ToString());
				}
																																				model.Fm_name= ds.Tables[0].Rows[0]["Fm_name"].ToString();
																																model.Fm_relationship= ds.Tables[0].Rows[0]["Fm_relationship"].ToString();
																																model.Fm_company= ds.Tables[0].Rows[0]["Fm_company"].ToString();
																																model.Fm_phone= ds.Tables[0].Rows[0]["Fm_phone"].ToString();
																												if(ds.Tables[0].Rows[0]["Fm_politics"].ToString()!="")
				{
					model.Fm_politics=int.Parse(ds.Tables[0].Rows[0]["Fm_politics"].ToString());
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
			strSql.Append(" FROM Family_member ");
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
			strSql.Append(" FROM Family_member ");
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
			strSql.Append(" FROM Family_member ");
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
				strSql.Append("order by T.Fm_id desc");
			}
			strSql.Append(")AS Row, T.*  from Family_member T ");
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

