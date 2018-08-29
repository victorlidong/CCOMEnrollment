using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_CEE_score
		public partial class Examination_CEE_score
	{
   		     
		public bool Exists(int CEE_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_CEE_score");
			strSql.Append(" where ");
			                                       strSql.Append(" CEE_id = @CEE_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@CEE_id", SqlDbType.Int,4)
			};
			parameters[0].Value = CEE_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_CEE_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_CEE_score(");			
            strSql.Append("CEE_Chinese_score,CEE_Math_score,CEE_English_score,CEE_comprehensive_score,CEE_extra_score,CEE_score,CEE_type,Period_id,User_id,CEE_status");
			strSql.Append(") values (");
            strSql.Append("@CEE_Chinese_score,@CEE_Math_score,@CEE_English_score,@CEE_comprehensive_score,@CEE_extra_score,@CEE_score,@CEE_type,@Period_id,@User_id,@CEE_status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@CEE_Chinese_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Math_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_English_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_comprehensive_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_extra_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@CEE_status", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.CEE_Chinese_score;                        
            parameters[1].Value = model.CEE_Math_score;                        
            parameters[2].Value = model.CEE_English_score;                        
            parameters[3].Value = model.CEE_comprehensive_score;                        
            parameters[4].Value = model.CEE_extra_score;                        
            parameters[5].Value = model.CEE_score;                        
            parameters[6].Value = model.CEE_type;                        
            parameters[7].Value = model.Period_id;                        
            parameters[8].Value = model.User_id;                        
            parameters[9].Value = model.CEE_status;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_CEE_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_CEE_score set ");
			                                                
            strSql.Append(" CEE_Chinese_score = @CEE_Chinese_score , ");                                    
            strSql.Append(" CEE_Math_score = @CEE_Math_score , ");                                    
            strSql.Append(" CEE_English_score = @CEE_English_score , ");                                    
            strSql.Append(" CEE_comprehensive_score = @CEE_comprehensive_score , ");                                    
            strSql.Append(" CEE_extra_score = @CEE_extra_score , ");                                    
            strSql.Append(" CEE_score = @CEE_score , ");                                    
            strSql.Append(" CEE_type = @CEE_type , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" CEE_status = @CEE_status  ");            			
			strSql.Append(" where CEE_id=@CEE_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@CEE_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CEE_Chinese_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Math_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_English_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_comprehensive_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_extra_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@CEE_status", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.CEE_id;                        
            parameters[1].Value = model.CEE_Chinese_score;                        
            parameters[2].Value = model.CEE_Math_score;                        
            parameters[3].Value = model.CEE_English_score;                        
            parameters[4].Value = model.CEE_comprehensive_score;                        
            parameters[5].Value = model.CEE_extra_score;                        
            parameters[6].Value = model.CEE_score;                        
            parameters[7].Value = model.CEE_type;                        
            parameters[8].Value = model.Period_id;                        
            parameters[9].Value = model.User_id;                        
            parameters[10].Value = model.CEE_status;                        
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
		public bool Delete(int CEE_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_CEE_score ");
			strSql.Append(" where CEE_id=@CEE_id");
						SqlParameter[] parameters = {
					new SqlParameter("@CEE_id", SqlDbType.Int,4)
			};
			parameters[0].Value = CEE_id;


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
			strSql.Append("delete from Examination_CEE_score ");
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
		public bool DeleteList(string CEE_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_CEE_score ");
			strSql.Append(" where CEE_id in ("+CEE_idlist + ")  ");
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
		public university.Model.CCOM.Examination_CEE_score GetModel(int CEE_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CEE_id, CEE_Chinese_score, CEE_Math_score, CEE_English_score, CEE_comprehensive_score, CEE_extra_score, CEE_score, CEE_type, Period_id, User_id, CEE_status  ");			
			strSql.Append("  from Examination_CEE_score ");
			strSql.Append(" where CEE_id=@CEE_id");
						SqlParameter[] parameters = {
					new SqlParameter("@CEE_id", SqlDbType.Int,4)
			};
			parameters[0].Value = CEE_id;

			
			university.Model.CCOM.Examination_CEE_score model=new university.Model.CCOM.Examination_CEE_score();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(ds.Tables[0].Rows[0]["CEE_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_English_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(ds.Tables[0].Rows[0]["CEE_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["CEE_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["CEE_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["CEE_status"].ToString().ToLower()=="true"))
					{
					model.CEE_status= true;
					}
					else
					{
					model.CEE_status= false;
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
		public university.Model.CCOM.Examination_CEE_score GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CEE_id, CEE_Chinese_score, CEE_Math_score, CEE_English_score, CEE_comprehensive_score, CEE_extra_score, CEE_score, CEE_type, Period_id, User_id, CEE_status  ");			
			strSql.Append("  from Examination_CEE_score ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_CEE_score model=new university.Model.CCOM.Examination_CEE_score();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(ds.Tables[0].Rows[0]["CEE_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_English_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(ds.Tables[0].Rows[0]["CEE_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["CEE_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["CEE_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["CEE_status"].ToString().ToLower()=="true"))
					{
					model.CEE_status= true;
					}
					else
					{
					model.CEE_status= false;
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
			strSql.Append(" FROM Examination_CEE_score ");
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
			strSql.Append(" FROM Examination_CEE_score ");
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
			strSql.Append(" FROM Examination_CEE_score ");
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
				strSql.Append("order by T.CEE_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_CEE_score T ");
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

