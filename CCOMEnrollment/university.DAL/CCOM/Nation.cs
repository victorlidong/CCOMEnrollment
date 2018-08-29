using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Nation
		public partial class Nation
	{
   		     
		public bool Exists(int Nation_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Nation");
			strSql.Append(" where ");
			                                       strSql.Append(" Nation_id = @Nation_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Nation_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Nation_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Nation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Nation(");			
            strSql.Append("Nation_name");
			strSql.Append(") values (");
            strSql.Append("@Nation_name");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Nation_name", SqlDbType.VarChar,255)             
              
            };
			            
            parameters[0].Value = model.Nation_name;                        
			   
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
		public bool Update(university.Model.CCOM.Nation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Nation set ");
			                                                
            strSql.Append(" Nation_name = @Nation_name  ");            			
			strSql.Append(" where Nation_id=@Nation_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Nation_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Nation_name", SqlDbType.VarChar,255)             
              
            };
						            
            parameters[0].Value = model.Nation_id;                        
            parameters[1].Value = model.Nation_name;                        
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
		public bool Delete(int Nation_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation ");
			strSql.Append(" where Nation_id=@Nation_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Nation_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Nation_id;


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
			strSql.Append("delete from Nation ");
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
		public bool DeleteList(string Nation_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation ");
			strSql.Append(" where Nation_id in ("+Nation_idlist + ")  ");
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
		public university.Model.CCOM.Nation GetModel(int Nation_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Nation_id, Nation_name  ");			
			strSql.Append("  from Nation ");
			strSql.Append(" where Nation_id=@Nation_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Nation_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Nation_id;

			
			university.Model.CCOM.Nation model=new university.Model.CCOM.Nation();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Nation_id"].ToString()!="")
				{
					model.Nation_id=int.Parse(ds.Tables[0].Rows[0]["Nation_id"].ToString());
				}
																																				model.Nation_name= ds.Tables[0].Rows[0]["Nation_name"].ToString();
																										
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
		public university.Model.CCOM.Nation GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Nation_id, Nation_name  ");			
			strSql.Append("  from Nation ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Nation model=new university.Model.CCOM.Nation();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Nation_id"].ToString()!="")
				{
					model.Nation_id=int.Parse(ds.Tables[0].Rows[0]["Nation_id"].ToString());
				}
																																				model.Nation_name= ds.Tables[0].Rows[0]["Nation_name"].ToString();
																										
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
			strSql.Append(" FROM Nation ");
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
			strSql.Append(" FROM Nation ");
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
			strSql.Append(" FROM Nation ");
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
				strSql.Append("order by T.Nation_id desc");
			}
			strSql.Append(")AS Row, T.*  from Nation T ");
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

