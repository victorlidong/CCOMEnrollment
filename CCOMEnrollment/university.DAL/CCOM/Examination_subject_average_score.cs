using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject_average_score
		public partial class Examination_subject_average_score
	{
   		     
		public bool Exists(int Esas_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject_average_score");
			strSql.Append(" where ");
			                                       strSql.Append(" Esas_id = @Esas_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Esas_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esas_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_subject_average_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject_average_score(");			
            strSql.Append("Esn_id,Esas_score,Esas_sequence,User_id");
			strSql.Append(") values (");
            strSql.Append("@Esn_id,@Esas_score,@Esas_sequence,@User_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esas_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Esas_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
			            
            parameters[0].Value = model.Esn_id;                        
            parameters[1].Value = model.Esas_score;                        
            parameters[2].Value = model.Esas_sequence;                        
            parameters[3].Value = model.User_id;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject_average_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject_average_score set ");
			                                                
            strSql.Append(" Esn_id = @Esn_id , ");                                    
            strSql.Append(" Esas_score = @Esas_score , ");                                    
            strSql.Append(" Esas_sequence = @Esas_sequence , ");                                    
            strSql.Append(" User_id = @User_id  ");            			
			strSql.Append(" where Esas_id=@Esas_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Esas_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esas_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Esas_sequence", SqlDbType.Float,8) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8)             
              
            };
						            
            parameters[0].Value = model.Esas_id;                        
            parameters[1].Value = model.Esn_id;                        
            parameters[2].Value = model.Esas_score;                        
            parameters[3].Value = model.Esas_sequence;                        
            parameters[4].Value = model.User_id;                        
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
		public bool Delete(int Esas_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_average_score ");
			strSql.Append(" where Esas_id=@Esas_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esas_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esas_id;


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
			strSql.Append("delete from Examination_subject_average_score ");
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
		public bool DeleteList(string Esas_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_average_score ");
			strSql.Append(" where Esas_id in ("+Esas_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject_average_score GetModel(int Esas_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esas_id, Esn_id, Esas_score, Esas_sequence, User_id  ");			
			strSql.Append("  from Examination_subject_average_score ");
			strSql.Append(" where Esas_id=@Esas_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esas_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esas_id;

			
			university.Model.CCOM.Examination_subject_average_score model=new university.Model.CCOM.Examination_subject_average_score();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esas_id"].ToString()!="")
				{
					model.Esas_id=int.Parse(ds.Tables[0].Rows[0]["Esas_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esas_score"].ToString()!="")
				{
					model.Esas_score=decimal.Parse(ds.Tables[0].Rows[0]["Esas_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esas_sequence"].ToString()!="")
				{
					model.Esas_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Esas_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
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
		public university.Model.CCOM.Examination_subject_average_score GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esas_id, Esn_id, Esas_score, Esas_sequence, User_id  ");			
			strSql.Append("  from Examination_subject_average_score ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject_average_score model=new university.Model.CCOM.Examination_subject_average_score();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esas_id"].ToString()!="")
				{
					model.Esas_id=int.Parse(ds.Tables[0].Rows[0]["Esas_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esas_score"].ToString()!="")
				{
					model.Esas_score=decimal.Parse(ds.Tables[0].Rows[0]["Esas_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esas_sequence"].ToString()!="")
				{
					model.Esas_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Esas_sequence"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
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
			strSql.Append(" FROM Examination_subject_average_score ");
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
			strSql.Append(" FROM Examination_subject_average_score ");
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
			strSql.Append(" FROM Examination_subject_average_score ");
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
				strSql.Append("order by T.Esas_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject_average_score T ");
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

