﻿using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Transcript
		public partial class Transcript
	{
   		     
		public bool Exists(int Transcript_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Transcript");
			strSql.Append(" where ");
			                                       strSql.Append(" Transcript_id = @Transcript_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Transcript_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Transcript_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Transcript model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Transcript(");			
            strSql.Append("Transcript_AEE_score,Transcript_AEE_sequence,Transcript_AEE_ranking,Transcript_CEE_score,Transcript_CEE_convert_score,Transcript_passline,Transcript_type,Period_id,User_id,Transcript_score");
			strSql.Append(") values (");
            strSql.Append("@Transcript_AEE_score,@Transcript_AEE_sequence,@Transcript_AEE_ranking,@Transcript_CEE_score,@Transcript_CEE_convert_score,@Transcript_passline,@Transcript_type,@Period_id,@User_id,@Transcript_score");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Transcript_AEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_ranking", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_CEE_convert_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_passline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Transcript_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Transcript_score", SqlDbType.Float,8)             
              
            };
			            
            parameters[0].Value = model.Transcript_AEE_score;                        
            parameters[1].Value = model.Transcript_AEE_sequence;                        
            parameters[2].Value = model.Transcript_AEE_ranking;                        
            parameters[3].Value = model.Transcript_CEE_score;                        
            parameters[4].Value = model.Transcript_CEE_convert_score;                        
            parameters[5].Value = model.Transcript_passline;                        
            parameters[6].Value = model.Transcript_type;                        
            parameters[7].Value = model.Period_id;                        
            parameters[8].Value = model.User_id;                        
            parameters[9].Value = model.Transcript_score;                        
			   
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
		public bool Update(university.Model.CCOM.Transcript model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Transcript set ");
			                                                
            strSql.Append(" Transcript_AEE_score = @Transcript_AEE_score , ");                                    
            strSql.Append(" Transcript_AEE_sequence = @Transcript_AEE_sequence , ");                                    
            strSql.Append(" Transcript_AEE_ranking = @Transcript_AEE_ranking , ");                                    
            strSql.Append(" Transcript_CEE_score = @Transcript_CEE_score , ");                                    
            strSql.Append(" Transcript_CEE_convert_score = @Transcript_CEE_convert_score , ");                                    
            strSql.Append(" Transcript_passline = @Transcript_passline , ");                                    
            strSql.Append(" Transcript_type = @Transcript_type , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Transcript_score = @Transcript_score  ");            			
			strSql.Append(" where Transcript_id=@Transcript_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Transcript_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_AEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_ranking", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_CEE_convert_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_passline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Transcript_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Transcript_score", SqlDbType.Float,8)             
              
            };
						            
            parameters[0].Value = model.Transcript_id;                        
            parameters[1].Value = model.Transcript_AEE_score;                        
            parameters[2].Value = model.Transcript_AEE_sequence;                        
            parameters[3].Value = model.Transcript_AEE_ranking;                        
            parameters[4].Value = model.Transcript_CEE_score;                        
            parameters[5].Value = model.Transcript_CEE_convert_score;                        
            parameters[6].Value = model.Transcript_passline;                        
            parameters[7].Value = model.Transcript_type;                        
            parameters[8].Value = model.Period_id;                        
            parameters[9].Value = model.User_id;                        
            parameters[10].Value = model.Transcript_score;                        
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
		public bool Delete(int Transcript_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Transcript ");
			strSql.Append(" where Transcript_id=@Transcript_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Transcript_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Transcript_id;


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
			strSql.Append("delete from Transcript ");
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
		public bool DeleteList(string Transcript_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Transcript ");
			strSql.Append(" where Transcript_id in ("+Transcript_idlist + ")  ");
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
		public university.Model.CCOM.Transcript GetModel(int Transcript_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Transcript_id, Transcript_AEE_score, Transcript_AEE_sequence, Transcript_AEE_ranking, Transcript_CEE_score, Transcript_CEE_convert_score, Transcript_passline, Transcript_type, Period_id, User_id, Transcript_score  ");			
			strSql.Append("  from Transcript ");
			strSql.Append(" where Transcript_id=@Transcript_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Transcript_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Transcript_id;

			
			university.Model.CCOM.Transcript model=new university.Model.CCOM.Transcript();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Transcript_id"].ToString()!="")
				{
					model.Transcript_id=int.Parse(ds.Tables[0].Rows[0]["Transcript_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_score"].ToString()!="")
				{
					model.Transcript_AEE_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_sequence"].ToString()!="")
				{
					model.Transcript_AEE_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_ranking"].ToString()!="")
				{
					model.Transcript_AEE_ranking=int.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_ranking"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_CEE_score"].ToString()!="")
				{
					model.Transcript_CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_CEE_convert_score"].ToString()!="")
				{
					model.Transcript_CEE_convert_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_CEE_convert_score"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Transcript_passline"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Transcript_passline"].ToString()=="1")||(ds.Tables[0].Rows[0]["Transcript_passline"].ToString().ToLower()=="true"))
					{
					model.Transcript_passline= true;
					}
					else
					{
					model.Transcript_passline= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Transcript_type"].ToString()!="")
				{
					model.Transcript_type=int.Parse(ds.Tables[0].Rows[0]["Transcript_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_score"].ToString()!="")
				{
					model.Transcript_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_score"].ToString());
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
		public university.Model.CCOM.Transcript GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Transcript_id, Transcript_AEE_score, Transcript_AEE_sequence, Transcript_AEE_ranking, Transcript_CEE_score, Transcript_CEE_convert_score, Transcript_passline, Transcript_type, Period_id, User_id, Transcript_score  ");			
			strSql.Append("  from Transcript ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Transcript model=new university.Model.CCOM.Transcript();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Transcript_id"].ToString()!="")
				{
					model.Transcript_id=int.Parse(ds.Tables[0].Rows[0]["Transcript_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_score"].ToString()!="")
				{
					model.Transcript_AEE_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_sequence"].ToString()!="")
				{
					model.Transcript_AEE_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_AEE_ranking"].ToString()!="")
				{
					model.Transcript_AEE_ranking=int.Parse(ds.Tables[0].Rows[0]["Transcript_AEE_ranking"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_CEE_score"].ToString()!="")
				{
					model.Transcript_CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_CEE_convert_score"].ToString()!="")
				{
					model.Transcript_CEE_convert_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_CEE_convert_score"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Transcript_passline"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Transcript_passline"].ToString()=="1")||(ds.Tables[0].Rows[0]["Transcript_passline"].ToString().ToLower()=="true"))
					{
					model.Transcript_passline= true;
					}
					else
					{
					model.Transcript_passline= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Transcript_type"].ToString()!="")
				{
					model.Transcript_type=int.Parse(ds.Tables[0].Rows[0]["Transcript_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Transcript_score"].ToString()!="")
				{
					model.Transcript_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_score"].ToString());
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
			strSql.Append(" FROM Transcript ");
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
			strSql.Append(" FROM Transcript ");
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
			strSql.Append(" FROM Transcript ");
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
				strSql.Append("order by T.Transcript_id desc");
			}
			strSql.Append(")AS Row, T.*  from Transcript T ");
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

