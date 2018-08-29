using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject_score
		public partial class Examination_subject_score
	{
   		     
		public bool Exists(long Ess_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject_score");
			strSql.Append(" where ");
			                                       strSql.Append(" Ess_id = @Ess_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Ess_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ess_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Examination_subject_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject_score(");			
            strSql.Append("Esn_id,Ess_score,Ess_sequence,Judge_id,User_id,Ess_score_status,Ess_order_status");
			strSql.Append(") values (");
            strSql.Append("@Esn_id,@Ess_score,@Ess_sequence,@Judge_id,@User_id,@Ess_score_status,@Ess_order_status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ess_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Ess_sequence", SqlDbType.Int,4) ,            
                        new SqlParameter("@Judge_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Ess_score_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ess_order_status", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Esn_id;                        
            parameters[1].Value = model.Ess_score;                        
            parameters[2].Value = model.Ess_sequence;                        
            parameters[3].Value = model.Judge_id;                        
            parameters[4].Value = model.User_id;                        
            parameters[5].Value = model.Ess_score_status;                        
            parameters[6].Value = model.Ess_order_status;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject_score set ");
			                                                
            strSql.Append(" Esn_id = @Esn_id , ");                                    
            strSql.Append(" Ess_score = @Ess_score , ");                                    
            strSql.Append(" Ess_sequence = @Ess_sequence , ");                                    
            strSql.Append(" Judge_id = @Judge_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Ess_score_status = @Ess_score_status , ");                                    
            strSql.Append(" Ess_order_status = @Ess_order_status  ");            			
			strSql.Append(" where Ess_id=@Ess_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Ess_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ess_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Ess_sequence", SqlDbType.Int,4) ,            
                        new SqlParameter("@Judge_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Ess_score_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ess_order_status", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Ess_id;                        
            parameters[1].Value = model.Esn_id;                        
            parameters[2].Value = model.Ess_score;                        
            parameters[3].Value = model.Ess_sequence;                        
            parameters[4].Value = model.Judge_id;                        
            parameters[5].Value = model.User_id;                        
            parameters[6].Value = model.Ess_score_status;                        
            parameters[7].Value = model.Ess_order_status;                        
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
		public bool Delete(long Ess_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_score ");
			strSql.Append(" where Ess_id=@Ess_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ess_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ess_id;


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
			strSql.Append("delete from Examination_subject_score ");
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
		public bool DeleteList(string Ess_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_score ");
			strSql.Append(" where Ess_id in ("+Ess_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject_score GetModel(long Ess_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ess_id, Esn_id, Ess_score, Ess_sequence, Judge_id, User_id, Ess_score_status, Ess_order_status  ");			
			strSql.Append("  from Examination_subject_score ");
			strSql.Append(" where Ess_id=@Ess_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ess_id", SqlDbType.BigInt)
			};
			parameters[0].Value = Ess_id;

			
			university.Model.CCOM.Examination_subject_score model=new university.Model.CCOM.Examination_subject_score();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ess_id"].ToString()!="")
				{
					model.Ess_id=long.Parse(ds.Tables[0].Rows[0]["Ess_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ess_score"].ToString()!="")
				{
					model.Ess_score=decimal.Parse(ds.Tables[0].Rows[0]["Ess_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ess_sequence"].ToString()!="")
				{
					model.Ess_sequence=int.Parse(ds.Tables[0].Rows[0]["Ess_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Judge_id"].ToString()!="")
				{
					model.Judge_id=int.Parse(ds.Tables[0].Rows[0]["Judge_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ess_score_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ess_score_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ess_score_status"].ToString().ToLower()=="true"))
					{
					model.Ess_score_status= true;
					}
					else
					{
					model.Ess_score_status= false;
					}
				}
																																if(ds.Tables[0].Rows[0]["Ess_order_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ess_order_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ess_order_status"].ToString().ToLower()=="true"))
					{
					model.Ess_order_status= true;
					}
					else
					{
					model.Ess_order_status= false;
					}
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
		public university.Model.CCOM.Examination_subject_score GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ess_id, Esn_id, Ess_score, Ess_sequence, Judge_id, User_id, Ess_score_status, Ess_order_status  ");			
			strSql.Append("  from Examination_subject_score ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject_score model=new university.Model.CCOM.Examination_subject_score();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ess_id"].ToString()!="")
				{
					model.Ess_id=long.Parse(ds.Tables[0].Rows[0]["Ess_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ess_score"].ToString()!="")
				{
					model.Ess_score=decimal.Parse(ds.Tables[0].Rows[0]["Ess_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ess_sequence"].ToString()!="")
				{
					model.Ess_sequence=int.Parse(ds.Tables[0].Rows[0]["Ess_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Judge_id"].ToString()!="")
				{
					model.Judge_id=int.Parse(ds.Tables[0].Rows[0]["Judge_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Ess_score_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ess_score_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ess_score_status"].ToString().ToLower()=="true"))
					{
					model.Ess_score_status= true;
					}
					else
					{
					model.Ess_score_status= false;
					}
				}
																																if(ds.Tables[0].Rows[0]["Ess_order_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Ess_order_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Ess_order_status"].ToString().ToLower()=="true"))
					{
					model.Ess_order_status= true;
					}
					else
					{
					model.Ess_order_status= false;
					}
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
			strSql.Append(" FROM Examination_subject_score ");
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
			strSql.Append(" FROM Examination_subject_score ");
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
			strSql.Append(" FROM Examination_subject_score ");
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
				strSql.Append("order by T.Ess_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject_score T ");
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

