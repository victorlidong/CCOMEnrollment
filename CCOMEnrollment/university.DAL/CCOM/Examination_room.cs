using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM{
	 	//Examination_room
		public partial class Examination_room
	{
   		     
		public bool Exists(int Er_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_room");
			strSql.Append(" where ");
			                                       strSql.Append(" Er_id = @Er_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Er_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Er_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_room(");			
            strSql.Append("Er_building,Er_floor,Er_room,Er_capacity,Er_remark");
			strSql.Append(") values (");
            strSql.Append("@Er_building,@Er_floor,@Er_room,@Er_capacity,@Er_remark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Er_building", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Er_floor", SqlDbType.Int,4) ,            
                        new SqlParameter("@Er_room", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Er_capacity", SqlDbType.Int,4) ,            
                        new SqlParameter("@Er_remark", SqlDbType.VarChar,1024)             
              
            };
			            
            parameters[0].Value = model.Er_building;                        
            parameters[1].Value = model.Er_floor;                        
            parameters[2].Value = model.Er_room;                        
            parameters[3].Value = model.Er_capacity;                        
            parameters[4].Value = model.Er_remark;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_room set ");
			                                                
            strSql.Append(" Er_building = @Er_building , ");                                    
            strSql.Append(" Er_floor = @Er_floor , ");                                    
            strSql.Append(" Er_room = @Er_room , ");                                    
            strSql.Append(" Er_capacity = @Er_capacity , ");                                    
            strSql.Append(" Er_remark = @Er_remark  ");            			
			strSql.Append(" where Er_id=@Er_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Er_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Er_building", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Er_floor", SqlDbType.Int,4) ,            
                        new SqlParameter("@Er_room", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@Er_capacity", SqlDbType.Int,4) ,            
                        new SqlParameter("@Er_remark", SqlDbType.VarChar,1024)             
              
            };
						            
            parameters[0].Value = model.Er_id;                        
            parameters[1].Value = model.Er_building;                        
            parameters[2].Value = model.Er_floor;                        
            parameters[3].Value = model.Er_room;                        
            parameters[4].Value = model.Er_capacity;                        
            parameters[5].Value = model.Er_remark;                        
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
		public bool Delete(int Er_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_room ");
			strSql.Append(" where Er_id=@Er_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Er_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Er_id;


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
			strSql.Append("delete from Examination_room ");
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
		public bool DeleteList(string Er_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_room ");
			strSql.Append(" where Er_id in ("+Er_idlist + ")  ");
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
		public university.Model.CCOM.Examination_room GetModel(int Er_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Er_id, Er_building, Er_floor, Er_room, Er_capacity, Er_remark  ");			
			strSql.Append("  from Examination_room ");
			strSql.Append(" where Er_id=@Er_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Er_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Er_id;


            university.Model.CCOM.Examination_room model = new university.Model.CCOM.Examination_room();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Er_id"].ToString()!="")
				{
					model.Er_id=int.Parse(ds.Tables[0].Rows[0]["Er_id"].ToString());
				}
																																				model.Er_building= ds.Tables[0].Rows[0]["Er_building"].ToString();
																												if(ds.Tables[0].Rows[0]["Er_floor"].ToString()!="")
				{
					model.Er_floor=int.Parse(ds.Tables[0].Rows[0]["Er_floor"].ToString());
				}
																																				model.Er_room= ds.Tables[0].Rows[0]["Er_room"].ToString();
																												if(ds.Tables[0].Rows[0]["Er_capacity"].ToString()!="")
				{
					model.Er_capacity=int.Parse(ds.Tables[0].Rows[0]["Er_capacity"].ToString());
				}
																																				model.Er_remark= ds.Tables[0].Rows[0]["Er_remark"].ToString();
																										
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
		public university.Model.CCOM.Examination_room GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Er_id, Er_building, Er_floor, Er_room, Er_capacity, Er_remark  ");			
			strSql.Append("  from Examination_room ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_room model=new university.Model.CCOM.Examination_room();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Er_id"].ToString()!="")
				{
					model.Er_id=int.Parse(ds.Tables[0].Rows[0]["Er_id"].ToString());
				}
																																				model.Er_building= ds.Tables[0].Rows[0]["Er_building"].ToString();
																												if(ds.Tables[0].Rows[0]["Er_floor"].ToString()!="")
				{
					model.Er_floor=int.Parse(ds.Tables[0].Rows[0]["Er_floor"].ToString());
				}
																																				model.Er_room= ds.Tables[0].Rows[0]["Er_room"].ToString();
																												if(ds.Tables[0].Rows[0]["Er_capacity"].ToString()!="")
				{
					model.Er_capacity=int.Parse(ds.Tables[0].Rows[0]["Er_capacity"].ToString());
				}
																																				model.Er_remark= ds.Tables[0].Rows[0]["Er_remark"].ToString();
																										
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
			strSql.Append(" FROM Examination_room ");
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
			strSql.Append(" FROM Examination_room ");
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
			strSql.Append(" FROM Examination_room ");
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
				strSql.Append("order by T.Er_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_room T ");
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

