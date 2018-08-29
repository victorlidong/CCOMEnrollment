using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_Major_Preliminary
		public partial class View_Major_Preliminary
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_Major_Preliminary");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_Major_Preliminary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Major_Preliminary(");			
            strSql.Append("Subject_title,Subject_weight,Agency_id,Fs_id,Subject_id,Period_id");
			strSql.Append(") values (");
            strSql.Append("@Subject_title,@Subject_weight,@Agency_id,@Fs_id,@Subject_id,@Period_id");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_weight", SqlDbType.Float,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Fs_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Subject_title;                        
            parameters[1].Value = model.Subject_weight;                        
            parameters[2].Value = model.Agency_id;                        
            parameters[3].Value = model.Fs_id;                        
            parameters[4].Value = model.Subject_id;                        
            parameters[5].Value = model.Period_id;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Major_Preliminary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Major_Preliminary set ");
			                        
            strSql.Append(" Subject_title = @Subject_title , ");                                    
            strSql.Append(" Subject_weight = @Subject_weight , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" Fs_id = @Fs_id , ");                                    
            strSql.Append(" Subject_id = @Subject_id , ");                                    
            strSql.Append(" Period_id = @Period_id  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_weight", SqlDbType.Float,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Fs_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Subject_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Subject_title;                        
            parameters[1].Value = model.Subject_weight;                        
            parameters[2].Value = model.Agency_id;                        
            parameters[3].Value = model.Fs_id;                        
            parameters[4].Value = model.Subject_id;                        
            parameters[5].Value = model.Period_id;                        
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
		public bool Delete()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from View_Major_Preliminary ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};


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
			strSql.Append("delete from View_Major_Preliminary ");
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
		public university.Model.CCOM.View_Major_Preliminary GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Subject_title, Subject_weight, Agency_id, Fs_id, Subject_id, Period_id  ");			
			strSql.Append("  from View_Major_Preliminary ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_Major_Preliminary model=new university.Model.CCOM.View_Major_Preliminary();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																												if(ds.Tables[0].Rows[0]["Subject_weight"].ToString()!="")
				{
					model.Subject_weight=decimal.Parse(ds.Tables[0].Rows[0]["Subject_weight"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fs_id"].ToString()!="")
				{
					model.Fs_id=int.Parse(ds.Tables[0].Rows[0]["Fs_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
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
		public university.Model.CCOM.View_Major_Preliminary GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Subject_title, Subject_weight, Agency_id, Fs_id, Subject_id, Period_id  ");			
			strSql.Append("  from View_Major_Preliminary ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_Major_Preliminary model=new university.Model.CCOM.View_Major_Preliminary();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																												if(ds.Tables[0].Rows[0]["Subject_weight"].ToString()!="")
				{
					model.Subject_weight=decimal.Parse(ds.Tables[0].Rows[0]["Subject_weight"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fs_id"].ToString()!="")
				{
					model.Fs_id=int.Parse(ds.Tables[0].Rows[0]["Fs_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
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
			strSql.Append(" FROM View_Major_Preliminary ");
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
			strSql.Append(" FROM View_Major_Preliminary ");
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
			strSql.Append(" FROM View_Major_Preliminary ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from View_Major_Preliminary T ");
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

