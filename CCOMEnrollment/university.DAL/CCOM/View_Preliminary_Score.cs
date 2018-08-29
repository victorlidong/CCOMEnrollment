using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_Preliminary_Score
		public partial class View_Preliminary_Score
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_Preliminary_Score");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_Preliminary_Score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Preliminary_Score(");			
            strSql.Append("Period_id,UP_CCOM_number,User_id,User_realname,Subject_title,Subject_id,Epss_score,Epss_sequence,Major_id,UP_calculation_status");
			strSql.Append(") values (");
            strSql.Append("@Period_id,@UP_CCOM_number,@User_id,@User_realname,@Subject_title,@Subject_id,@Epss_score,@Epss_sequence,@Major_id,@UP_calculation_status");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Epss_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Epss_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Major_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Period_id;                        
            parameters[1].Value = model.UP_CCOM_number;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.User_realname;                        
            parameters[4].Value = model.Subject_title;                        
            parameters[5].Value = model.Subject_id;                        
            parameters[6].Value = model.Epss_score;                        
            parameters[7].Value = model.Epss_sequence;                        
            parameters[8].Value = model.Major_id;                        
            parameters[9].Value = model.UP_calculation_status;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Preliminary_Score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Preliminary_Score set ");
			                        
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" UP_CCOM_number = @UP_CCOM_number , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" User_realname = @User_realname , ");                                    
            strSql.Append(" Subject_title = @Subject_title , ");                                    
            strSql.Append(" Subject_id = @Subject_id , ");                                    
            strSql.Append(" Epss_score = @Epss_score , ");                                    
            strSql.Append(" Epss_sequence = @Epss_sequence , ");                                    
            strSql.Append(" Major_id = @Major_id , ");                                    
            strSql.Append(" UP_calculation_status = @UP_calculation_status  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Subject_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Epss_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Epss_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Major_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Period_id;                        
            parameters[1].Value = model.UP_CCOM_number;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.User_realname;                        
            parameters[4].Value = model.Subject_title;                        
            parameters[5].Value = model.Subject_id;                        
            parameters[6].Value = model.Epss_score;                        
            parameters[7].Value = model.Epss_sequence;                        
            parameters[8].Value = model.Major_id;                        
            parameters[9].Value = model.UP_calculation_status;                        
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
			strSql.Append("delete from View_Preliminary_Score ");
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
			strSql.Append("delete from View_Preliminary_Score ");
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
		public university.Model.CCOM.View_Preliminary_Score GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Period_id, UP_CCOM_number, User_id, User_realname, Subject_title, Subject_id, Epss_score, Epss_sequence, Major_id, UP_calculation_status  ");			
			strSql.Append("  from View_Preliminary_Score ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_Preliminary_Score model=new university.Model.CCOM.View_Preliminary_Score();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																																model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																												if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_score"].ToString()!="")
				{
					model.Epss_score=decimal.Parse(ds.Tables[0].Rows[0]["Epss_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_sequence"].ToString()!="")
				{
					model.Epss_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Epss_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Major_id"].ToString()!="")
				{
					model.Major_id=int.Parse(ds.Tables[0].Rows[0]["Major_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
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
		public university.Model.CCOM.View_Preliminary_Score GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Period_id, UP_CCOM_number, User_id, User_realname, Subject_title, Subject_id, Epss_score, Epss_sequence, Major_id, UP_calculation_status  ");			
			strSql.Append("  from View_Preliminary_Score ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_Preliminary_Score model=new university.Model.CCOM.View_Preliminary_Score();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																																model.Subject_title= ds.Tables[0].Rows[0]["Subject_title"].ToString();
																												if(ds.Tables[0].Rows[0]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(ds.Tables[0].Rows[0]["Subject_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_score"].ToString()!="")
				{
					model.Epss_score=decimal.Parse(ds.Tables[0].Rows[0]["Epss_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_sequence"].ToString()!="")
				{
					model.Epss_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Epss_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Major_id"].ToString()!="")
				{
					model.Major_id=int.Parse(ds.Tables[0].Rows[0]["Major_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
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
			strSql.Append(" FROM View_Preliminary_Score ");
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
			strSql.Append(" FROM View_Preliminary_Score ");
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
			strSql.Append(" FROM View_Preliminary_Score ");
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
			strSql.Append(")AS Row, T.*  from View_Preliminary_Score T ");
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

