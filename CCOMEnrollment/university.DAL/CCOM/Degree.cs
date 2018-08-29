using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Degree
		public partial class Degree
	{
   		     
		public bool Exists(int Degree_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Degree");
			strSql.Append(" where ");
			                                       strSql.Append(" Degree_id = @Degree_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Degree_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Degree_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Degree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Degree(");			
            strSql.Append("Degree_name");
			strSql.Append(") values (");
            strSql.Append("@Degree_name");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Degree_name", SqlDbType.VarChar,255)             
              
            };
			            
            parameters[0].Value = model.Degree_name;                        
			   
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
		public bool Update(university.Model.CCOM.Degree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Degree set ");
			                                                
            strSql.Append(" Degree_name = @Degree_name  ");            			
			strSql.Append(" where Degree_id=@Degree_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Degree_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Degree_name", SqlDbType.VarChar,255)             
              
            };
						            
            parameters[0].Value = model.Degree_id;                        
            parameters[1].Value = model.Degree_name;                        
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
		public bool Delete(int Degree_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Degree ");
			strSql.Append(" where Degree_id=@Degree_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Degree_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Degree_id;


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
			strSql.Append("delete from Degree ");
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
		public bool DeleteList(string Degree_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Degree ");
			strSql.Append(" where Degree_id in ("+Degree_idlist + ")  ");
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
		public university.Model.CCOM.Degree GetModel(int Degree_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Degree_id, Degree_name  ");			
			strSql.Append("  from Degree ");
			strSql.Append(" where Degree_id=@Degree_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Degree_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Degree_id;

			
			university.Model.CCOM.Degree model=new university.Model.CCOM.Degree();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Degree_id"].ToString()!="")
				{
					model.Degree_id=int.Parse(ds.Tables[0].Rows[0]["Degree_id"].ToString());
				}
																																				model.Degree_name= ds.Tables[0].Rows[0]["Degree_name"].ToString();
																										
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
		public university.Model.CCOM.Degree GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Degree_id, Degree_name  ");			
			strSql.Append("  from Degree ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Degree model=new university.Model.CCOM.Degree();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Degree_id"].ToString()!="")
				{
					model.Degree_id=int.Parse(ds.Tables[0].Rows[0]["Degree_id"].ToString());
				}
																																				model.Degree_name= ds.Tables[0].Rows[0]["Degree_name"].ToString();
																										
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
			strSql.Append(" FROM Degree ");
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
			strSql.Append(" FROM Degree ");
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
			strSql.Append(" FROM Degree ");
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
				strSql.Append("order by T.Degree_id desc");
			}
			strSql.Append(")AS Row, T.*  from Degree T ");
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

