using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_Desktop
		public partial class View_Desktop
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_Desktop");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_Desktop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Desktop(");			
            strSql.Append("User_id,Sf_id,Sf_url,Sf_status,Ufd_type,Ufd_sort,Ufd_name,Ufd_showname,Ufd_icon,Ufd_width,Ufd_color,Ufd_remark");
			strSql.Append(") values (");
            strSql.Append("@User_id,@Sf_id,@Sf_url,@Sf_status,@Ufd_type,@Ufd_sort,@Ufd_name,@Ufd_showname,@Ufd_icon,@Ufd_width,@Ufd_color,@Ufd_remark");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Sf_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sf_url", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@Sf_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ufd_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Ufd_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ufd_name", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_showname", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_icon", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Ufd_width", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_color", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_remark", SqlDbType.VarChar,255)             
              
            };
			            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Sf_id;                        
            parameters[2].Value = model.Sf_url;                        
            parameters[3].Value = model.Sf_status;                        
            parameters[4].Value = model.Ufd_type;                        
            parameters[5].Value = model.Ufd_sort;                        
            parameters[6].Value = model.Ufd_name;                        
            parameters[7].Value = model.Ufd_showname;                        
            parameters[8].Value = model.Ufd_icon;                        
            parameters[9].Value = model.Ufd_width;                        
            parameters[10].Value = model.Ufd_color;                        
            parameters[11].Value = model.Ufd_remark;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Desktop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Desktop set ");
			                        
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Sf_id = @Sf_id , ");                                    
            strSql.Append(" Sf_url = @Sf_url , ");                                    
            strSql.Append(" Sf_status = @Sf_status , ");                                    
            strSql.Append(" Ufd_type = @Ufd_type , ");                                    
            strSql.Append(" Ufd_sort = @Ufd_sort , ");                                    
            strSql.Append(" Ufd_name = @Ufd_name , ");                                    
            strSql.Append(" Ufd_showname = @Ufd_showname , ");                                    
            strSql.Append(" Ufd_icon = @Ufd_icon , ");                                    
            strSql.Append(" Ufd_width = @Ufd_width , ");                                    
            strSql.Append(" Ufd_color = @Ufd_color , ");                                    
            strSql.Append(" Ufd_remark = @Ufd_remark  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Sf_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sf_url", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@Sf_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Ufd_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Ufd_sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ufd_name", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_showname", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_icon", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Ufd_width", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_color", SqlDbType.VarChar,64) ,            
                        new SqlParameter("@Ufd_remark", SqlDbType.VarChar,255)             
              
            };
						            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Sf_id;                        
            parameters[2].Value = model.Sf_url;                        
            parameters[3].Value = model.Sf_status;                        
            parameters[4].Value = model.Ufd_type;                        
            parameters[5].Value = model.Ufd_sort;                        
            parameters[6].Value = model.Ufd_name;                        
            parameters[7].Value = model.Ufd_showname;                        
            parameters[8].Value = model.Ufd_icon;                        
            parameters[9].Value = model.Ufd_width;                        
            parameters[10].Value = model.Ufd_color;                        
            parameters[11].Value = model.Ufd_remark;                        
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
			strSql.Append("delete from View_Desktop ");
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
			strSql.Append("delete from View_Desktop ");
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
		public university.Model.CCOM.View_Desktop GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_id, Sf_id, Sf_url, Sf_status, Ufd_type, Ufd_sort, Ufd_name, Ufd_showname, Ufd_icon, Ufd_width, Ufd_color, Ufd_remark  ");			
			strSql.Append("  from View_Desktop ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_Desktop model=new university.Model.CCOM.View_Desktop();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(ds.Tables[0].Rows[0]["Sf_id"].ToString());
				}
																																				model.Sf_url= ds.Tables[0].Rows[0]["Sf_url"].ToString();
																																												if(ds.Tables[0].Rows[0]["Sf_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sf_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sf_status"].ToString().ToLower()=="true"))
					{
					model.Sf_status= true;
					}
					else
					{
					model.Sf_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Ufd_type"].ToString()!="")
				{
					model.Ufd_type=int.Parse(ds.Tables[0].Rows[0]["Ufd_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ufd_sort"].ToString()!="")
				{
					model.Ufd_sort=int.Parse(ds.Tables[0].Rows[0]["Ufd_sort"].ToString());
				}
																																				model.Ufd_name= ds.Tables[0].Rows[0]["Ufd_name"].ToString();
																																model.Ufd_showname= ds.Tables[0].Rows[0]["Ufd_showname"].ToString();
																																model.Ufd_icon= ds.Tables[0].Rows[0]["Ufd_icon"].ToString();
																																model.Ufd_width= ds.Tables[0].Rows[0]["Ufd_width"].ToString();
																																model.Ufd_color= ds.Tables[0].Rows[0]["Ufd_color"].ToString();
																																model.Ufd_remark= ds.Tables[0].Rows[0]["Ufd_remark"].ToString();
																										
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
		public university.Model.CCOM.View_Desktop GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_id, Sf_id, Sf_url, Sf_status, Ufd_type, Ufd_sort, Ufd_name, Ufd_showname, Ufd_icon, Ufd_width, Ufd_color, Ufd_remark  ");			
			strSql.Append("  from View_Desktop ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_Desktop model=new university.Model.CCOM.View_Desktop();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(ds.Tables[0].Rows[0]["Sf_id"].ToString());
				}
																																				model.Sf_url= ds.Tables[0].Rows[0]["Sf_url"].ToString();
																																												if(ds.Tables[0].Rows[0]["Sf_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sf_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sf_status"].ToString().ToLower()=="true"))
					{
					model.Sf_status= true;
					}
					else
					{
					model.Sf_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["Ufd_type"].ToString()!="")
				{
					model.Ufd_type=int.Parse(ds.Tables[0].Rows[0]["Ufd_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Ufd_sort"].ToString()!="")
				{
					model.Ufd_sort=int.Parse(ds.Tables[0].Rows[0]["Ufd_sort"].ToString());
				}
																																				model.Ufd_name= ds.Tables[0].Rows[0]["Ufd_name"].ToString();
																																model.Ufd_showname= ds.Tables[0].Rows[0]["Ufd_showname"].ToString();
																																model.Ufd_icon= ds.Tables[0].Rows[0]["Ufd_icon"].ToString();
																																model.Ufd_width= ds.Tables[0].Rows[0]["Ufd_width"].ToString();
																																model.Ufd_color= ds.Tables[0].Rows[0]["Ufd_color"].ToString();
																																model.Ufd_remark= ds.Tables[0].Rows[0]["Ufd_remark"].ToString();
																										
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
			strSql.Append(" FROM View_Desktop ");
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
			strSql.Append(" FROM View_Desktop ");
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
			strSql.Append(" FROM View_Desktop ");
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
			strSql.Append(")AS Row, T.*  from View_Desktop T ");
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

