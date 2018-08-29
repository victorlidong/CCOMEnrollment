using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Exam_preliminary_subject_score
		public partial class Exam_preliminary_subject_score
	{
   		     
		public bool Exists(int Epss)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Exam_preliminary_subject_score");
			strSql.Append(" where ");
			                                       strSql.Append(" Epss = @Epss  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Epss", SqlDbType.Int,4)
			};
			parameters[0].Value = Epss;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Exam_preliminary_subject_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Exam_preliminary_subject_score(");			
            strSql.Append("Eps_id,User_id,Epss_score,Epss_sequence");
			strSql.Append(") values (");
            strSql.Append("@Eps_id,@User_id,@Epss_score,@Epss_sequence");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Eps_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Epss_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Epss_sequence", SqlDbType.Float,8)             
              
            };
			            
            parameters[0].Value = model.Eps_id;                        
            parameters[1].Value = model.User_id;                        
            parameters[2].Value = model.Epss_score;                        
            parameters[3].Value = model.Epss_sequence;                        
			   
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
		public bool Update(university.Model.CCOM.Exam_preliminary_subject_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Exam_preliminary_subject_score set ");
			                                                
            strSql.Append(" Eps_id = @Eps_id , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Epss_score = @Epss_score , ");                                    
            strSql.Append(" Epss_sequence = @Epss_sequence  ");            			
			strSql.Append(" where Epss=@Epss ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Epss", SqlDbType.Int,4) ,            
                        new SqlParameter("@Eps_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Epss_score", SqlDbType.Float,8) ,            
                        new SqlParameter("@Epss_sequence", SqlDbType.Float,8)             
              
            };
						            
            parameters[0].Value = model.Epss;                        
            parameters[1].Value = model.Eps_id;                        
            parameters[2].Value = model.User_id;                        
            parameters[3].Value = model.Epss_score;                        
            parameters[4].Value = model.Epss_sequence;                        
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
		public bool Delete(int Epss)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Exam_preliminary_subject_score ");
			strSql.Append(" where Epss=@Epss");
						SqlParameter[] parameters = {
					new SqlParameter("@Epss", SqlDbType.Int,4)
			};
			parameters[0].Value = Epss;


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
			strSql.Append("delete from Exam_preliminary_subject_score ");
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
		public bool DeleteList(string Epsslist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Exam_preliminary_subject_score ");
			strSql.Append(" where Epss in ("+Epsslist + ")  ");
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
		public university.Model.CCOM.Exam_preliminary_subject_score GetModel(int Epss)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Epss, Eps_id, User_id, Epss_score, Epss_sequence  ");			
			strSql.Append("  from Exam_preliminary_subject_score ");
			strSql.Append(" where Epss=@Epss");
						SqlParameter[] parameters = {
					new SqlParameter("@Epss", SqlDbType.Int,4)
			};
			parameters[0].Value = Epss;

			
			university.Model.CCOM.Exam_preliminary_subject_score model=new university.Model.CCOM.Exam_preliminary_subject_score();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Epss"].ToString()!="")
				{
					model.Epss=int.Parse(ds.Tables[0].Rows[0]["Epss"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Eps_id"].ToString()!="")
				{
					model.Eps_id=int.Parse(ds.Tables[0].Rows[0]["Eps_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_score"].ToString()!="")
				{
					model.Epss_score=decimal.Parse(ds.Tables[0].Rows[0]["Epss_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_sequence"].ToString()!="")
				{
					model.Epss_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Epss_sequence"].ToString());
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
		public university.Model.CCOM.Exam_preliminary_subject_score GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Epss, Eps_id, User_id, Epss_score, Epss_sequence  ");			
			strSql.Append("  from Exam_preliminary_subject_score ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Exam_preliminary_subject_score model=new university.Model.CCOM.Exam_preliminary_subject_score();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Epss"].ToString()!="")
				{
					model.Epss=int.Parse(ds.Tables[0].Rows[0]["Epss"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Eps_id"].ToString()!="")
				{
					model.Eps_id=int.Parse(ds.Tables[0].Rows[0]["Eps_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_score"].ToString()!="")
				{
					model.Epss_score=decimal.Parse(ds.Tables[0].Rows[0]["Epss_score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Epss_sequence"].ToString()!="")
				{
					model.Epss_sequence=decimal.Parse(ds.Tables[0].Rows[0]["Epss_sequence"].ToString());
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
			strSql.Append(" FROM Exam_preliminary_subject_score ");
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
			strSql.Append(" FROM Exam_preliminary_subject_score ");
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
			strSql.Append(" FROM Exam_preliminary_subject_score ");
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
				strSql.Append("order by T.Epss desc");
			}
			strSql.Append(")AS Row, T.*  from Exam_preliminary_subject_score T ");
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

