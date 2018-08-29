using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Judge
		public partial class Judge
	{

            public bool Exists(int Judge_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Judge");
			strSql.Append(" where ");
			                            			SqlParameter[] parameters = {
					new SqlParameter("@Judge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Judge_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Judge(");			
            strSql.Append("Judge_name,Judge_staff_number,Judge_department,Judge_title");
			strSql.Append(") values (");
            strSql.Append("@Judge_name,@Judge_staff_number,@Judge_department,@Judge_title");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Judge_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_staff_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_department", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_title", SqlDbType.VarChar,128)             
              
            };
			            
            parameters[0].Value = model.Judge_name;                        
            parameters[1].Value = model.Judge_staff_number;                        
            parameters[2].Value = model.Judge_department;                        
            parameters[3].Value = model.Judge_title;                        
			   
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
		public bool Update(university.Model.CCOM.Judge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Judge set ");
			                                                
            strSql.Append(" Judge_name = @Judge_name , ");                                    
            strSql.Append(" Judge_staff_number = @Judge_staff_number , ");                                    
            strSql.Append(" Judge_department = @Judge_department , ");                                    
            strSql.Append(" Judge_title = @Judge_title  ");            			
			strSql.Append(" where Judge_id=@Judge_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Judge_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Judge_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_staff_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_department", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Judge_title", SqlDbType.VarChar,128)             
              
            };
						            
            parameters[0].Value = model.Judge_id;                        
            parameters[1].Value = model.Judge_name;                        
            parameters[2].Value = model.Judge_staff_number;                        
            parameters[3].Value = model.Judge_department;                        
            parameters[4].Value = model.Judge_title;                        
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
		public bool Delete(int Judge_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Judge ");
			strSql.Append(" where Judge_id=@Judge_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Judge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Judge_id;


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
			strSql.Append("delete from Judge ");
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
		public bool DeleteList(string Judge_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Judge ");
			strSql.Append(" where Judge_id in ("+Judge_idlist + ")  ");
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
		public university.Model.CCOM.Judge GetModel(int Judge_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Judge_id, Judge_name, Judge_staff_number, Judge_department, Judge_title  ");			
			strSql.Append("  from Judge ");
			strSql.Append(" where Judge_id=@Judge_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Judge_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Judge_id;

			
			university.Model.CCOM.Judge model=new university.Model.CCOM.Judge();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Judge_id"].ToString()!="")
				{
					model.Judge_id=int.Parse(ds.Tables[0].Rows[0]["Judge_id"].ToString());
				}
																																				model.Judge_name= ds.Tables[0].Rows[0]["Judge_name"].ToString();
																																model.Judge_staff_number= ds.Tables[0].Rows[0]["Judge_staff_number"].ToString();
																																model.Judge_department= ds.Tables[0].Rows[0]["Judge_department"].ToString();
																																model.Judge_title= ds.Tables[0].Rows[0]["Judge_title"].ToString();
																										
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
		public university.Model.CCOM.Judge GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Judge_id, Judge_name, Judge_staff_number, Judge_department, Judge_title  ");			
			strSql.Append("  from Judge ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Judge model=new university.Model.CCOM.Judge();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Judge_id"].ToString()!="")
				{
					model.Judge_id=int.Parse(ds.Tables[0].Rows[0]["Judge_id"].ToString());
				}
																																				model.Judge_name= ds.Tables[0].Rows[0]["Judge_name"].ToString();
																																model.Judge_staff_number= ds.Tables[0].Rows[0]["Judge_staff_number"].ToString();
																																model.Judge_department= ds.Tables[0].Rows[0]["Judge_department"].ToString();
																																model.Judge_title= ds.Tables[0].Rows[0]["Judge_title"].ToString();
																										
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
			strSql.Append(" FROM Judge ");
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
			strSql.Append(" FROM Judge ");
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
			strSql.Append(" FROM Judge ");
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
				strSql.Append("order by T.Judge_id desc");
			}
			strSql.Append(")AS Row, T.*  from Judge T ");
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

