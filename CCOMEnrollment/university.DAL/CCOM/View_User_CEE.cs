using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_User_CEE
		public partial class View_User_CEE
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_User_CEE");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_User_CEE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_User_CEE(");			
            strSql.Append("CEE_extra_score,CEE_comprehensive_score,CEE_score,CEE_type,CEE_English_score,CEE_Math_score,CEE_Chinese_score,CEE_id,CEE_status,User_id,UP_province,Period_id,UP_CCOM_number,User_realname,Agency_id,UP_CEE_number");
			strSql.Append(") values (");
            strSql.Append("@CEE_extra_score,@CEE_comprehensive_score,@CEE_score,@CEE_type,@CEE_English_score,@CEE_Math_score,@CEE_Chinese_score,@CEE_id,@CEE_status,@User_id,@UP_province,@Period_id,@UP_CCOM_number,@User_realname,@Agency_id,@UP_CEE_number");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@CEE_extra_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_comprehensive_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CEE_English_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Math_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Chinese_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CEE_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128)             
              
            };
			            
            parameters[0].Value = model.CEE_extra_score;                        
            parameters[1].Value = model.CEE_comprehensive_score;                        
            parameters[2].Value = model.CEE_score;                        
            parameters[3].Value = model.CEE_type;                        
            parameters[4].Value = model.CEE_English_score;                        
            parameters[5].Value = model.CEE_Math_score;                        
            parameters[6].Value = model.CEE_Chinese_score;                        
            parameters[7].Value = model.CEE_id;                        
            parameters[8].Value = model.CEE_status;                        
            parameters[9].Value = model.User_id;                        
            parameters[10].Value = model.UP_province;                        
            parameters[11].Value = model.Period_id;                        
            parameters[12].Value = model.UP_CCOM_number;                        
            parameters[13].Value = model.User_realname;                        
            parameters[14].Value = model.Agency_id;                        
            parameters[15].Value = model.UP_CEE_number;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_User_CEE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_User_CEE set ");
			                        
            strSql.Append(" CEE_extra_score = @CEE_extra_score , ");                                    
            strSql.Append(" CEE_comprehensive_score = @CEE_comprehensive_score , ");                                    
            strSql.Append(" CEE_score = @CEE_score , ");                                    
            strSql.Append(" CEE_type = @CEE_type , ");                                    
            strSql.Append(" CEE_English_score = @CEE_English_score , ");                                    
            strSql.Append(" CEE_Math_score = @CEE_Math_score , ");                                    
            strSql.Append(" CEE_Chinese_score = @CEE_Chinese_score , ");                                    
            strSql.Append(" CEE_id = @CEE_id , ");                                    
            strSql.Append(" CEE_status = @CEE_status , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" UP_province = @UP_province , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" UP_CCOM_number = @UP_CCOM_number , ");                                    
            strSql.Append(" User_realname = @User_realname , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" UP_CEE_number = @UP_CEE_number  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@CEE_extra_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_comprehensive_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CEE_English_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Math_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_Chinese_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@CEE_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CEE_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128)             
              
            };
						            
            parameters[0].Value = model.CEE_extra_score;                        
            parameters[1].Value = model.CEE_comprehensive_score;                        
            parameters[2].Value = model.CEE_score;                        
            parameters[3].Value = model.CEE_type;                        
            parameters[4].Value = model.CEE_English_score;                        
            parameters[5].Value = model.CEE_Math_score;                        
            parameters[6].Value = model.CEE_Chinese_score;                        
            parameters[7].Value = model.CEE_id;                        
            parameters[8].Value = model.CEE_status;                        
            parameters[9].Value = model.User_id;                        
            parameters[10].Value = model.UP_province;                        
            parameters[11].Value = model.Period_id;                        
            parameters[12].Value = model.UP_CCOM_number;                        
            parameters[13].Value = model.User_realname;                        
            parameters[14].Value = model.Agency_id;                        
            parameters[15].Value = model.UP_CEE_number;                        
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
			strSql.Append("delete from View_User_CEE ");
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
			strSql.Append("delete from View_User_CEE ");
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
		public university.Model.CCOM.View_User_CEE GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CEE_extra_score, CEE_comprehensive_score, CEE_score, CEE_type, CEE_English_score, CEE_Math_score, CEE_Chinese_score, CEE_id, CEE_status, User_id, UP_province, Period_id, UP_CCOM_number, User_realname, Agency_id, UP_CEE_number  ");			
			strSql.Append("  from View_User_CEE ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_User_CEE model=new university.Model.CCOM.View_User_CEE();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(ds.Tables[0].Rows[0]["CEE_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_English_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(ds.Tables[0].Rows[0]["CEE_id"].ToString());
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
																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																																model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																												if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																										
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
		public university.Model.CCOM.View_User_CEE GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CEE_extra_score, CEE_comprehensive_score, CEE_score, CEE_type, CEE_English_score, CEE_Math_score, CEE_Chinese_score, CEE_id, CEE_status, User_id, UP_province, Period_id, UP_CCOM_number, User_realname, Agency_id, UP_CEE_number  ");			
			strSql.Append("  from View_User_CEE ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_User_CEE model=new university.Model.CCOM.View_User_CEE();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_extra_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_comprehensive_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(ds.Tables[0].Rows[0]["CEE_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_English_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Math_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(ds.Tables[0].Rows[0]["CEE_Chinese_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(ds.Tables[0].Rows[0]["CEE_id"].ToString());
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
																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																																model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																												if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																										
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
			strSql.Append(" FROM View_User_CEE ");
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
			strSql.Append(" FROM View_User_CEE ");
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
			strSql.Append(" FROM View_User_CEE ");
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
			strSql.Append(")AS Row, T.*  from View_User_CEE T ");
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

