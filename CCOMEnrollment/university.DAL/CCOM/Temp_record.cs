using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Temp_record
		public partial class Temp_record
	{
   		     
		public bool Exists(long Record_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Temp_record");
			strSql.Append(" where ");
			                                       strSql.Append(" Record_id = @Record_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Record_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Record_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Temp_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Temp_record(");			
            strSql.Append("Period_year,Last_CCOM_number");
			strSql.Append(") values (");
            strSql.Append("@Period_year,@Last_CCOM_number");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Period_year", SqlDbType.VarChar,8) ,            
                        new SqlParameter("@Last_CCOM_number", SqlDbType.VarChar,16)             
              
            };
			            
            parameters[0].Value = model.Period_year;                        
            parameters[1].Value = model.Last_CCOM_number;                        
			   
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
		public bool Update(university.Model.CCOM.Temp_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Temp_record set ");
			                                                
            strSql.Append(" Period_year = @Period_year , ");                                    
            strSql.Append(" Last_CCOM_number = @Last_CCOM_number  ");            			
			strSql.Append(" where Record_id=@Record_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Record_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Period_year", SqlDbType.VarChar,8) ,            
                        new SqlParameter("@Last_CCOM_number", SqlDbType.VarChar,16)             
              
            };
						            
            parameters[0].Value = model.Record_id;                        
            parameters[1].Value = model.Period_year;                        
            parameters[2].Value = model.Last_CCOM_number;                        
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
		public bool Delete(long Record_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Temp_record ");
			strSql.Append(" where Record_id=@Record_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Record_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Record_id;


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
			strSql.Append("delete from Temp_record ");
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
		public bool DeleteList(string Record_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Temp_record ");
			strSql.Append(" where Record_id in ("+Record_idlist + ")  ");
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
		public university.Model.CCOM.Temp_record GetModel(long Record_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Record_id, Period_year, Last_CCOM_number  ");			
			strSql.Append("  from Temp_record ");
			strSql.Append(" where Record_id=@Record_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Record_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Record_id;

			
			university.Model.CCOM.Temp_record model=new university.Model.CCOM.Temp_record();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Record_id"].ToString()!="")
				{
					model.Record_id=long.Parse(ds.Tables[0].Rows[0]["Record_id"].ToString());
				}
																																				model.Period_year= ds.Tables[0].Rows[0]["Period_year"].ToString();
																																model.Last_CCOM_number= ds.Tables[0].Rows[0]["Last_CCOM_number"].ToString();
																										
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
		public university.Model.CCOM.Temp_record GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Record_id, Period_year, Last_CCOM_number  ");			
			strSql.Append("  from Temp_record ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Temp_record model=new university.Model.CCOM.Temp_record();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Record_id"].ToString()!="")
				{
					model.Record_id=long.Parse(ds.Tables[0].Rows[0]["Record_id"].ToString());
				}
																																				model.Period_year= ds.Tables[0].Rows[0]["Period_year"].ToString();
																																model.Last_CCOM_number= ds.Tables[0].Rows[0]["Last_CCOM_number"].ToString();
																										
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
			strSql.Append(" FROM Temp_record ");
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
			strSql.Append(" FROM Temp_record ");
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
			strSql.Append(" FROM Temp_record ");
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
				strSql.Append("order by T.Record_id desc");
			}
			strSql.Append(")AS Row, T.*  from Temp_record T ");
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

