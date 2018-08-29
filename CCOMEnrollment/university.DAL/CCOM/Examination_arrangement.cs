using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_arrangement
		public partial class Examination_arrangement
	{
   		     
		public bool Exists(int Ea_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_arrangement");
			strSql.Append(" where ");
			                                       strSql.Append(" Ea_id = @Ea_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Ea_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ea_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_arrangement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_arrangement(");			
            strSql.Append("Ea_name,Ea_starttime,Ea_endtime,Ea_room,Ea_restroom");
			strSql.Append(") values (");
            strSql.Append("@Ea_name,@Ea_starttime,@Ea_endtime,@Ea_room,@Ea_restroom");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Ea_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Ea_starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Ea_endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Ea_room", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ea_restroom", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Ea_name;                        
            parameters[1].Value = model.Ea_starttime;                        
            parameters[2].Value = model.Ea_endtime;                        
            parameters[3].Value = model.Ea_room;                        
            parameters[4].Value = model.Ea_restroom;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_arrangement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_arrangement set ");
			                                                
            strSql.Append(" Ea_name = @Ea_name , ");                                    
            strSql.Append(" Ea_starttime = @Ea_starttime , ");                                    
            strSql.Append(" Ea_endtime = @Ea_endtime , ");                                    
            strSql.Append(" Ea_room = @Ea_room , ");                                    
            strSql.Append(" Ea_restroom = @Ea_restroom  ");            			
			strSql.Append(" where Ea_id=@Ea_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Ea_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ea_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Ea_starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Ea_endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Ea_room", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ea_restroom", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Ea_id;                        
            parameters[1].Value = model.Ea_name;                        
            parameters[2].Value = model.Ea_starttime;                        
            parameters[3].Value = model.Ea_endtime;                        
            parameters[4].Value = model.Ea_room;                        
            parameters[5].Value = model.Ea_restroom;                        
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
		public bool Delete(int Ea_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_arrangement ");
			strSql.Append(" where Ea_id=@Ea_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ea_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ea_id;


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
			strSql.Append("delete from Examination_arrangement ");
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
		public bool DeleteList(string Ea_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_arrangement ");
			strSql.Append(" where Ea_id in ("+Ea_idlist + ")  ");
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
		public university.Model.CCOM.Examination_arrangement GetModel(int Ea_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ea_id, Ea_name, Ea_starttime, Ea_endtime, Ea_room, Ea_restroom  ");			
			strSql.Append("  from Examination_arrangement ");
			strSql.Append(" where Ea_id=@Ea_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Ea_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Ea_id;

			
			university.Model.CCOM.Examination_arrangement model=new university.Model.CCOM.Examination_arrangement();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(ds.Tables[0].Rows[0]["Ea_id"].ToString());
				}
																																				model.Ea_name= ds.Tables[0].Rows[0]["Ea_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ea_starttime"].ToString()!="")
				{
					model.Ea_starttime=DateTime.Parse(ds.Tables[0].Rows[0]["Ea_starttime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_endtime"].ToString()!="")
				{
					model.Ea_endtime=DateTime.Parse(ds.Tables[0].Rows[0]["Ea_endtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_room"].ToString()!="")
				{
					model.Ea_room=int.Parse(ds.Tables[0].Rows[0]["Ea_room"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_restroom"].ToString()!="")
				{
					model.Ea_restroom=int.Parse(ds.Tables[0].Rows[0]["Ea_restroom"].ToString());
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
		public university.Model.CCOM.Examination_arrangement GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Ea_id, Ea_name, Ea_starttime, Ea_endtime, Ea_room, Ea_restroom  ");			
			strSql.Append("  from Examination_arrangement ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_arrangement model=new university.Model.CCOM.Examination_arrangement();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(ds.Tables[0].Rows[0]["Ea_id"].ToString());
				}
																																				model.Ea_name= ds.Tables[0].Rows[0]["Ea_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Ea_starttime"].ToString()!="")
				{
					model.Ea_starttime=DateTime.Parse(ds.Tables[0].Rows[0]["Ea_starttime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_endtime"].ToString()!="")
				{
					model.Ea_endtime=DateTime.Parse(ds.Tables[0].Rows[0]["Ea_endtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_room"].ToString()!="")
				{
					model.Ea_room=int.Parse(ds.Tables[0].Rows[0]["Ea_room"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ea_restroom"].ToString()!="")
				{
					model.Ea_restroom=int.Parse(ds.Tables[0].Rows[0]["Ea_restroom"].ToString());
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
			strSql.Append(" FROM Examination_arrangement ");
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
			strSql.Append(" FROM Examination_arrangement ");
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
			strSql.Append(" FROM Examination_arrangement ");
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
				strSql.Append("order by T.Ea_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_arrangement T ");
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

