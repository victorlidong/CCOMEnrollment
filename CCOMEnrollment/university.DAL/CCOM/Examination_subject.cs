using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject
		public partial class Examination_subject
	{
   		     
		public bool Exists(int Es_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject");
			strSql.Append(" where ");
			                                       strSql.Append(" Es_id = @Es_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Es_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Es_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject(");			
            strSql.Append("Ea_id,Esn_id");
			strSql.Append(") values (");
            strSql.Append("@Ea_id,@Esn_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Ea_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Ea_id;                        
            parameters[1].Value = model.Esn_id;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject set ");
			                                                
            strSql.Append(" Ea_id = @Ea_id , ");                                    
            strSql.Append(" Esn_id = @Esn_id  ");            			
			strSql.Append(" where Es_id=@Es_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Es_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ea_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Es_id;                        
            parameters[1].Value = model.Ea_id;                        
            parameters[2].Value = model.Esn_id;                        
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
		public bool Delete(int Es_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject ");
			strSql.Append(" where Es_id=@Es_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Es_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Es_id;


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
			strSql.Append("delete from Examination_subject ");
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
		public bool DeleteList(string Es_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject ");
			strSql.Append(" where Es_id in ("+Es_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject GetModel(int Es_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Es_id, Ea_id, Esn_id  ");			
			strSql.Append("  from Examination_subject ");
			strSql.Append(" where Es_id=@Es_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Es_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Es_id;

			
			university.Model.CCOM.Examination_subject model=new university.Model.CCOM.Examination_subject();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Es_id"].ToString()!="")
				{
					model.Es_id=int.Parse(ds.Tables[0].Rows[0]["Es_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(ds.Tables[0].Rows[0]["Ea_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
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
		public university.Model.CCOM.Examination_subject GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Es_id, Ea_id, Esn_id  ");			
			strSql.Append("  from Examination_subject ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject model=new university.Model.CCOM.Examination_subject();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Es_id"].ToString()!="")
				{
					model.Es_id=int.Parse(ds.Tables[0].Rows[0]["Es_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(ds.Tables[0].Rows[0]["Ea_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
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
			strSql.Append(" FROM Examination_subject ");
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
			strSql.Append(" FROM Examination_subject ");
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
			strSql.Append(" FROM Examination_subject ");
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
				strSql.Append("order by T.Es_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject T ");
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

