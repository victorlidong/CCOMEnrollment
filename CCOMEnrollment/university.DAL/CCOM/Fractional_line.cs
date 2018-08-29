using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Fractional_line
		public partial class Fractional_line
	{
   		     
		public bool Exists(int Fl_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Fractional_line");
			strSql.Append(" where ");
			                                       strSql.Append(" Fl_id = @Fl_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Fl_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Fl_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Fractional_line model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Fractional_line(");			
            strSql.Append("Fl_Province,WenKeYiBen,LiKeYiBen,WenKeErBen,LiKeErBen,WenKeSanBen,LiKeSanBen,WenKeYiShuXian,LiKeYiShuXian,WenKeZongFen,LiKeZongFen,Period_id,Fl_addtime");
			strSql.Append(") values (");
            strSql.Append("@Fl_Province,@WenKeYiBen,@LiKeYiBen,@WenKeErBen,@LiKeErBen,@WenKeSanBen,@LiKeSanBen,@WenKeYiShuXian,@LiKeYiShuXian,@WenKeZongFen,@LiKeZongFen,@Period_id,@Fl_addtime");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Fl_Province", SqlDbType.Int,4) ,            
                        new SqlParameter("@WenKeYiBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeYiBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeErBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeErBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeSanBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeSanBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeYiShuXian", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeYiShuXian", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeZongFen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeZongFen", SqlDbType.Float,8) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Fl_addtime", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.Fl_Province;                        
            parameters[1].Value = model.WenKeYiBen;                        
            parameters[2].Value = model.LiKeYiBen;                        
            parameters[3].Value = model.WenKeErBen;                        
            parameters[4].Value = model.LiKeErBen;                        
            parameters[5].Value = model.WenKeSanBen;                        
            parameters[6].Value = model.LiKeSanBen;                        
            parameters[7].Value = model.WenKeYiShuXian;                        
            parameters[8].Value = model.LiKeYiShuXian;                        
            parameters[9].Value = model.WenKeZongFen;                        
            parameters[10].Value = model.LiKeZongFen;                        
            parameters[11].Value = model.Period_id;                        
            parameters[12].Value = model.Fl_addtime;                        
			   
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
		public bool Update(university.Model.CCOM.Fractional_line model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Fractional_line set ");
			                                                
            strSql.Append(" Fl_Province = @Fl_Province , ");                                    
            strSql.Append(" WenKeYiBen = @WenKeYiBen , ");                                    
            strSql.Append(" LiKeYiBen = @LiKeYiBen , ");                                    
            strSql.Append(" WenKeErBen = @WenKeErBen , ");                                    
            strSql.Append(" LiKeErBen = @LiKeErBen , ");                                    
            strSql.Append(" WenKeSanBen = @WenKeSanBen , ");                                    
            strSql.Append(" LiKeSanBen = @LiKeSanBen , ");                                    
            strSql.Append(" WenKeYiShuXian = @WenKeYiShuXian , ");                                    
            strSql.Append(" LiKeYiShuXian = @LiKeYiShuXian , ");                                    
            strSql.Append(" WenKeZongFen = @WenKeZongFen , ");                                    
            strSql.Append(" LiKeZongFen = @LiKeZongFen , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" Fl_addtime = @Fl_addtime  ");            			
			strSql.Append(" where Fl_id=@Fl_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Fl_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Fl_Province", SqlDbType.Int,4) ,            
                        new SqlParameter("@WenKeYiBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeYiBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeErBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeErBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeSanBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeSanBen", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeYiShuXian", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeYiShuXian", SqlDbType.Float,8) ,            
                        new SqlParameter("@WenKeZongFen", SqlDbType.Float,8) ,            
                        new SqlParameter("@LiKeZongFen", SqlDbType.Float,8) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Fl_addtime", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.Fl_id;                        
            parameters[1].Value = model.Fl_Province;                        
            parameters[2].Value = model.WenKeYiBen;                        
            parameters[3].Value = model.LiKeYiBen;                        
            parameters[4].Value = model.WenKeErBen;                        
            parameters[5].Value = model.LiKeErBen;                        
            parameters[6].Value = model.WenKeSanBen;                        
            parameters[7].Value = model.LiKeSanBen;                        
            parameters[8].Value = model.WenKeYiShuXian;                        
            parameters[9].Value = model.LiKeYiShuXian;                        
            parameters[10].Value = model.WenKeZongFen;                        
            parameters[11].Value = model.LiKeZongFen;                        
            parameters[12].Value = model.Period_id;                        
            parameters[13].Value = model.Fl_addtime;                        
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
		public bool Delete(int Fl_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Fractional_line ");
			strSql.Append(" where Fl_id=@Fl_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Fl_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Fl_id;


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
			strSql.Append("delete from Fractional_line ");
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
		public bool DeleteList(string Fl_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Fractional_line ");
			strSql.Append(" where Fl_id in ("+Fl_idlist + ")  ");
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
		public university.Model.CCOM.Fractional_line GetModel(int Fl_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Fl_id, Fl_Province, WenKeYiBen, LiKeYiBen, WenKeErBen, LiKeErBen, WenKeSanBen, LiKeSanBen, WenKeYiShuXian, LiKeYiShuXian, WenKeZongFen, LiKeZongFen, Period_id, Fl_addtime  ");			
			strSql.Append("  from Fractional_line ");
			strSql.Append(" where Fl_id=@Fl_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Fl_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Fl_id;

			
			university.Model.CCOM.Fractional_line model=new university.Model.CCOM.Fractional_line();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Fl_id"].ToString()!="")
				{
					model.Fl_id=int.Parse(ds.Tables[0].Rows[0]["Fl_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fl_Province"].ToString()!="")
				{
					model.Fl_Province=int.Parse(ds.Tables[0].Rows[0]["Fl_Province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeYiBen"].ToString()!="")
				{
					model.WenKeYiBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeYiBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeYiBen"].ToString()!="")
				{
					model.LiKeYiBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeYiBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeErBen"].ToString()!="")
				{
					model.WenKeErBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeErBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeErBen"].ToString()!="")
				{
					model.LiKeErBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeErBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeSanBen"].ToString()!="")
				{
					model.WenKeSanBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeSanBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeSanBen"].ToString()!="")
				{
					model.LiKeSanBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeSanBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeYiShuXian"].ToString()!="")
				{
					model.WenKeYiShuXian=decimal.Parse(ds.Tables[0].Rows[0]["WenKeYiShuXian"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeYiShuXian"].ToString()!="")
				{
					model.LiKeYiShuXian=decimal.Parse(ds.Tables[0].Rows[0]["LiKeYiShuXian"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeZongFen"].ToString()!="")
				{
					model.WenKeZongFen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeZongFen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeZongFen"].ToString()!="")
				{
					model.LiKeZongFen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeZongFen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fl_addtime"].ToString()!="")
				{
					model.Fl_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Fl_addtime"].ToString());
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
		public university.Model.CCOM.Fractional_line GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Fl_id, Fl_Province, WenKeYiBen, LiKeYiBen, WenKeErBen, LiKeErBen, WenKeSanBen, LiKeSanBen, WenKeYiShuXian, LiKeYiShuXian, WenKeZongFen, LiKeZongFen, Period_id, Fl_addtime  ");			
			strSql.Append("  from Fractional_line ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Fractional_line model=new university.Model.CCOM.Fractional_line();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Fl_id"].ToString()!="")
				{
					model.Fl_id=int.Parse(ds.Tables[0].Rows[0]["Fl_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fl_Province"].ToString()!="")
				{
					model.Fl_Province=int.Parse(ds.Tables[0].Rows[0]["Fl_Province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeYiBen"].ToString()!="")
				{
					model.WenKeYiBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeYiBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeYiBen"].ToString()!="")
				{
					model.LiKeYiBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeYiBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeErBen"].ToString()!="")
				{
					model.WenKeErBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeErBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeErBen"].ToString()!="")
				{
					model.LiKeErBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeErBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeSanBen"].ToString()!="")
				{
					model.WenKeSanBen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeSanBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeSanBen"].ToString()!="")
				{
					model.LiKeSanBen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeSanBen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeYiShuXian"].ToString()!="")
				{
					model.WenKeYiShuXian=decimal.Parse(ds.Tables[0].Rows[0]["WenKeYiShuXian"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeYiShuXian"].ToString()!="")
				{
					model.LiKeYiShuXian=decimal.Parse(ds.Tables[0].Rows[0]["LiKeYiShuXian"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["WenKeZongFen"].ToString()!="")
				{
					model.WenKeZongFen=decimal.Parse(ds.Tables[0].Rows[0]["WenKeZongFen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["LiKeZongFen"].ToString()!="")
				{
					model.LiKeZongFen=decimal.Parse(ds.Tables[0].Rows[0]["LiKeZongFen"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Fl_addtime"].ToString()!="")
				{
					model.Fl_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Fl_addtime"].ToString());
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
			strSql.Append(" FROM Fractional_line ");
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
			strSql.Append(" FROM Fractional_line ");
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
			strSql.Append(" FROM Fractional_line ");
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
				strSql.Append("order by T.Fl_id desc");
			}
			strSql.Append(")AS Row, T.*  from Fractional_line T ");
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

