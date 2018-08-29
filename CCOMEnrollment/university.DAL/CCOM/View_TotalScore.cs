using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_TotalScore
		public partial class View_TotalScore
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_TotalScore");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_TotalScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_TotalScore(");			
            strSql.Append("UP_CCOM_number,Period_id,Agency_id,User_id,User_realname,UP_calculation_status,Transcript_id,Transcript_AEE_score,Transcript_AEE_sequence,Transcript_AEE_ranking,Transcript_CEE_score,Transcript_CEE_convert_score,Transcript_passline,Transcript_type,Transcript_score,UP_province");
			strSql.Append(") values (");
            strSql.Append("@UP_CCOM_number,@Period_id,@Agency_id,@User_id,@User_realname,@UP_calculation_status,@Transcript_id,@Transcript_AEE_score,@Transcript_AEE_sequence,@Transcript_AEE_ranking,@Transcript_CEE_score,@Transcript_CEE_convert_score,@Transcript_passline,@Transcript_type,@Transcript_score,@UP_province");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_AEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_ranking", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_CEE_convert_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_passline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Transcript_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Transcript_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.UP_CCOM_number;                        
            parameters[1].Value = model.Period_id;                        
            parameters[2].Value = model.Agency_id;                        
            parameters[3].Value = model.User_id;                        
            parameters[4].Value = model.User_realname;                        
            parameters[5].Value = model.UP_calculation_status;                        
            parameters[6].Value = model.Transcript_id;                        
            parameters[7].Value = model.Transcript_AEE_score;                        
            parameters[8].Value = model.Transcript_AEE_sequence;                        
            parameters[9].Value = model.Transcript_AEE_ranking;                        
            parameters[10].Value = model.Transcript_CEE_score;                        
            parameters[11].Value = model.Transcript_CEE_convert_score;                        
            parameters[12].Value = model.Transcript_passline;                        
            parameters[13].Value = model.Transcript_type;                        
            parameters[14].Value = model.Transcript_score;                        
            parameters[15].Value = model.UP_province;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_TotalScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_TotalScore set ");
			                        
            strSql.Append(" UP_CCOM_number = @UP_CCOM_number , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" User_realname = @User_realname , ");                                    
            strSql.Append(" UP_calculation_status = @UP_calculation_status , ");                                    
            strSql.Append(" Transcript_id = @Transcript_id , ");                                    
            strSql.Append(" Transcript_AEE_score = @Transcript_AEE_score , ");                                    
            strSql.Append(" Transcript_AEE_sequence = @Transcript_AEE_sequence , ");                                    
            strSql.Append(" Transcript_AEE_ranking = @Transcript_AEE_ranking , ");                                    
            strSql.Append(" Transcript_CEE_score = @Transcript_CEE_score , ");                                    
            strSql.Append(" Transcript_CEE_convert_score = @Transcript_CEE_convert_score , ");                                    
            strSql.Append(" Transcript_passline = @Transcript_passline , ");                                    
            strSql.Append(" Transcript_type = @Transcript_type , ");                                    
            strSql.Append(" Transcript_score = @Transcript_score , ");                                    
            strSql.Append(" UP_province = @UP_province  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_AEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_AEE_ranking", SqlDbType.Int,4) ,            
                        new SqlParameter("@Transcript_CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_CEE_convert_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Transcript_passline", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Transcript_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Transcript_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.UP_CCOM_number;                        
            parameters[1].Value = model.Period_id;                        
            parameters[2].Value = model.Agency_id;                        
            parameters[3].Value = model.User_id;                        
            parameters[4].Value = model.User_realname;                        
            parameters[5].Value = model.UP_calculation_status;                        
            parameters[6].Value = model.Transcript_id;                        
            parameters[7].Value = model.Transcript_AEE_score;                        
            parameters[8].Value = model.Transcript_AEE_sequence;                        
            parameters[9].Value = model.Transcript_AEE_ranking;                        
            parameters[10].Value = model.Transcript_CEE_score;                        
            parameters[11].Value = model.Transcript_CEE_convert_score;                        
            parameters[12].Value = model.Transcript_passline;                        
            parameters[13].Value = model.Transcript_type;                        
            parameters[14].Value = model.Transcript_score;                        
            parameters[15].Value = model.UP_province;                        
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
			strSql.Append("delete from View_TotalScore ");
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
			strSql.Append("delete from View_TotalScore ");
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
		public university.Model.CCOM.View_TotalScore GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UP_CCOM_number, Period_id, Agency_id, User_id, User_realname, UP_calculation_status, Transcript_id, Transcript_AEE_score, Transcript_AEE_sequence, Transcript_AEE_ranking, Transcript_CEE_score, Transcript_CEE_convert_score, Transcript_passline, Transcript_type, Transcript_score, UP_province  ");			
			strSql.Append("  from View_TotalScore ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_TotalScore model=new university.Model.CCOM.View_TotalScore();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
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
																																if(ds.Tables[0].Rows[0]["Transcript_score"].ToString()!="")
				{
					model.Transcript_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
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
		public university.Model.CCOM.View_TotalScore GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UP_CCOM_number, Period_id, Agency_id, User_id, User_realname, UP_calculation_status, Transcript_id, Transcript_AEE_score, Transcript_AEE_sequence, Transcript_AEE_ranking, Transcript_CEE_score, Transcript_CEE_convert_score, Transcript_passline, Transcript_type, Transcript_score, UP_province  ");			
			strSql.Append("  from View_TotalScore ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_TotalScore model=new university.Model.CCOM.View_TotalScore();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																				model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
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
																																if(ds.Tables[0].Rows[0]["Transcript_score"].ToString()!="")
				{
					model.Transcript_score=decimal.Parse(ds.Tables[0].Rows[0]["Transcript_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
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
			strSql.Append(" FROM View_TotalScore ");
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
			strSql.Append(" FROM View_TotalScore ");
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
			strSql.Append(" FROM View_TotalScore ");
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
			strSql.Append(")AS Row, T.*  from View_TotalScore T ");
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

