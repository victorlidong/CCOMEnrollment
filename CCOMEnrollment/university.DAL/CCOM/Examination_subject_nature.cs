using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject_nature
		public partial class Examination_subject_nature
	{
   		     
		public bool Exists(int Esn_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject_nature");
			strSql.Append(" where ");
			                                       strSql.Append(" Esn_id = @Esn_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Esn_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esn_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_subject_nature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject_nature(");			
            strSql.Append("Esn_title,Esn_content,Esn_type,Esn_instrument_status,Esn_Mi_id,Agency_id,Period_id");
			strSql.Append(") values (");
            strSql.Append("@Esn_title,@Esn_content,@Esn_type,@Esn_instrument_status,@Esn_Mi_id,@Agency_id,@Period_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Esn_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Esn_content", SqlDbType.Text) ,            
                        new SqlParameter("@Esn_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Esn_instrument_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Esn_Mi_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Esn_title;                        
            parameters[1].Value = model.Esn_content;                        
            parameters[2].Value = model.Esn_type;                        
            parameters[3].Value = model.Esn_instrument_status;                        
            parameters[4].Value = model.Esn_Mi_id;                        
            parameters[5].Value = model.Agency_id;                        
            parameters[6].Value = model.Period_id;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject_nature model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject_nature set ");
			                                                
            strSql.Append(" Esn_title = @Esn_title , ");                                    
            strSql.Append(" Esn_content = @Esn_content , ");                                    
            strSql.Append(" Esn_type = @Esn_type , ");                                    
            strSql.Append(" Esn_instrument_status = @Esn_instrument_status , ");                                    
            strSql.Append(" Esn_Mi_id = @Esn_Mi_id , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" Period_id = @Period_id  ");            			
			strSql.Append(" where Esn_id=@Esn_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esn_title", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Esn_content", SqlDbType.Text) ,            
                        new SqlParameter("@Esn_type", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Esn_instrument_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Esn_Mi_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Esn_id;                        
            parameters[1].Value = model.Esn_title;                        
            parameters[2].Value = model.Esn_content;                        
            parameters[3].Value = model.Esn_type;                        
            parameters[4].Value = model.Esn_instrument_status;                        
            parameters[5].Value = model.Esn_Mi_id;                        
            parameters[6].Value = model.Agency_id;                        
            parameters[7].Value = model.Period_id;                        
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
		public bool Delete(int Esn_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_nature ");
			strSql.Append(" where Esn_id=@Esn_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esn_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esn_id;


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
			strSql.Append("delete from Examination_subject_nature ");
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
		public bool DeleteList(string Esn_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_nature ");
			strSql.Append(" where Esn_id in ("+Esn_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject_nature GetModel(int Esn_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esn_id, Esn_title, Esn_content, Esn_type, Esn_instrument_status, Esn_Mi_id, Agency_id, Period_id  ");			
			strSql.Append("  from Examination_subject_nature ");
			strSql.Append(" where Esn_id=@Esn_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esn_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esn_id;

			
			university.Model.CCOM.Examination_subject_nature model=new university.Model.CCOM.Examination_subject_nature();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																				model.Esn_title= ds.Tables[0].Rows[0]["Esn_title"].ToString();
																																model.Esn_content= ds.Tables[0].Rows[0]["Esn_content"].ToString();
																																												if(ds.Tables[0].Rows[0]["Esn_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Esn_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Esn_type"].ToString().ToLower()=="true"))
					{
					model.Esn_type= true;
					}
					else
					{
					model.Esn_type= false;
					}
				}
																																if(ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString().ToLower()=="true"))
					{
					model.Esn_instrument_status= true;
					}
					else
					{
					model.Esn_instrument_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Esn_Mi_id"].ToString()!="")
				{
					model.Esn_Mi_id=int.Parse(ds.Tables[0].Rows[0]["Esn_Mi_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
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
		public university.Model.CCOM.Examination_subject_nature GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esn_id, Esn_title, Esn_content, Esn_type, Esn_instrument_status, Esn_Mi_id, Agency_id, Period_id  ");			
			strSql.Append("  from Examination_subject_nature ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject_nature model=new university.Model.CCOM.Examination_subject_nature();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																				model.Esn_title= ds.Tables[0].Rows[0]["Esn_title"].ToString();
																																model.Esn_content= ds.Tables[0].Rows[0]["Esn_content"].ToString();
																																												if(ds.Tables[0].Rows[0]["Esn_type"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Esn_type"].ToString()=="1")||(ds.Tables[0].Rows[0]["Esn_type"].ToString().ToLower()=="true"))
					{
					model.Esn_type= true;
					}
					else
					{
					model.Esn_type= false;
					}
				}
																																if(ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Esn_instrument_status"].ToString().ToLower()=="true"))
					{
					model.Esn_instrument_status= true;
					}
					else
					{
					model.Esn_instrument_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Esn_Mi_id"].ToString()!="")
				{
					model.Esn_Mi_id=int.Parse(ds.Tables[0].Rows[0]["Esn_Mi_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
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
			strSql.Append(" FROM Examination_subject_nature ");
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
			strSql.Append(" FROM Examination_subject_nature ");
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
			strSql.Append(" FROM Examination_subject_nature ");
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
				strSql.Append("order by T.Esn_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject_nature T ");
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

