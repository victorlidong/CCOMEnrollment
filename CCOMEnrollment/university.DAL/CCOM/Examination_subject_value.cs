using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject_value
		public partial class Examination_subject_value
	{
   		     
		public bool Exists(long Esv_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject_value");
			strSql.Append(" where ");
			                                       strSql.Append(" Esv_id = @Esv_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Esv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Esv_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Examination_subject_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject_value(");			
            strSql.Append("Usr_id,Esv_value");
			strSql.Append(") values (");
            strSql.Append("@Usr_id,@Esv_value");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Usr_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Esv_value", SqlDbType.Text)             
              
            };
			            
            parameters[0].Value = model.Usr_id;                        
            parameters[1].Value = model.Esv_value;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject_value set ");
			                                                
            strSql.Append(" Usr_id = @Usr_id , ");                                    
            strSql.Append(" Esv_value = @Esv_value  ");            			
			strSql.Append(" where Esv_id=@Esv_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Esv_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Usr_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Esv_value", SqlDbType.Text)             
              
            };
						            
            parameters[0].Value = model.Esv_id;                        
            parameters[1].Value = model.Usr_id;                        
            parameters[2].Value = model.Esv_value;                        
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
		public bool Delete(long Esv_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_value ");
			strSql.Append(" where Esv_id=@Esv_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Esv_id;


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
			strSql.Append("delete from Examination_subject_value ");
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
		public bool DeleteList(string Esv_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_value ");
			strSql.Append(" where Esv_id in ("+Esv_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject_value GetModel(long Esv_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esv_id, Usr_id, Esv_value  ");			
			strSql.Append("  from Examination_subject_value ");
			strSql.Append(" where Esv_id=@Esv_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esv_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Esv_id;

			
			university.Model.CCOM.Examination_subject_value model=new university.Model.CCOM.Examination_subject_value();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esv_id"].ToString()!="")
				{
					model.Esv_id=long.Parse(ds.Tables[0].Rows[0]["Esv_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Usr_id"].ToString()!="")
				{
					model.Usr_id=long.Parse(ds.Tables[0].Rows[0]["Usr_id"].ToString());
				}
																																				model.Esv_value= ds.Tables[0].Rows[0]["Esv_value"].ToString();
																										
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
		public university.Model.CCOM.Examination_subject_value GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esv_id, Usr_id, Esv_value  ");			
			strSql.Append("  from Examination_subject_value ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject_value model=new university.Model.CCOM.Examination_subject_value();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esv_id"].ToString()!="")
				{
					model.Esv_id=long.Parse(ds.Tables[0].Rows[0]["Esv_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Usr_id"].ToString()!="")
				{
					model.Usr_id=long.Parse(ds.Tables[0].Rows[0]["Usr_id"].ToString());
				}
																																				model.Esv_value= ds.Tables[0].Rows[0]["Esv_value"].ToString();
																										
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
			strSql.Append(" FROM Examination_subject_value ");
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
			strSql.Append(" FROM Examination_subject_value ");
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
			strSql.Append(" FROM Examination_subject_value ");
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
				strSql.Append("order by T.Esv_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject_value T ");
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

