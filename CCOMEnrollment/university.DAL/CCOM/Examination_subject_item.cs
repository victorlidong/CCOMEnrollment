using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//Examination_subject_item
		public partial class Examination_subject_item
	{
   		     
		public bool Exists(int Esi_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Examination_subject_item");
			strSql.Append(" where ");
			                                       strSql.Append(" Esi_id = @Esi_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Esi_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esi_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Examination_subject_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Examination_subject_item(");			
            strSql.Append("Esi_type,Esi_text,Esi_remark,Esn_id");
			strSql.Append(") values (");
            strSql.Append("@Esi_type,@Esi_text,@Esi_remark,@Esn_id");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Esi_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esi_text", SqlDbType.Text) ,            
                        new SqlParameter("@Esi_remark", SqlDbType.Text) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Esi_type;                        
            parameters[1].Value = model.Esi_text;                        
            parameters[2].Value = model.Esi_remark;                        
            parameters[3].Value = model.Esn_id;                        
			   
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
		public bool Update(university.Model.CCOM.Examination_subject_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Examination_subject_item set ");
			                                                
            strSql.Append(" Esi_type = @Esi_type , ");                                    
            strSql.Append(" Esi_text = @Esi_text , ");                                    
            strSql.Append(" Esi_remark = @Esi_remark , ");                                    
            strSql.Append(" Esn_id = @Esn_id  ");            			
			strSql.Append(" where Esi_id=@Esi_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Esi_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esi_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Esi_text", SqlDbType.Text) ,            
                        new SqlParameter("@Esi_remark", SqlDbType.Text) ,            
                        new SqlParameter("@Esn_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Esi_id;                        
            parameters[1].Value = model.Esi_type;                        
            parameters[2].Value = model.Esi_text;                        
            parameters[3].Value = model.Esi_remark;                        
            parameters[4].Value = model.Esn_id;                        
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
		public bool Delete(int Esi_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_item ");
			strSql.Append(" where Esi_id=@Esi_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esi_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esi_id;


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
			strSql.Append("delete from Examination_subject_item ");
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
		public bool DeleteList(string Esi_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Examination_subject_item ");
			strSql.Append(" where Esi_id in ("+Esi_idlist + ")  ");
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
		public university.Model.CCOM.Examination_subject_item GetModel(int Esi_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esi_id, Esi_type, Esi_text, Esi_remark, Esn_id  ");			
			strSql.Append("  from Examination_subject_item ");
			strSql.Append(" where Esi_id=@Esi_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Esi_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Esi_id;

			
			university.Model.CCOM.Examination_subject_item model=new university.Model.CCOM.Examination_subject_item();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esi_id"].ToString()!="")
				{
					model.Esi_id=int.Parse(ds.Tables[0].Rows[0]["Esi_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esi_type"].ToString()!="")
				{
					model.Esi_type=int.Parse(ds.Tables[0].Rows[0]["Esi_type"].ToString());
				}
																																				model.Esi_text= ds.Tables[0].Rows[0]["Esi_text"].ToString();
																																model.Esi_remark= ds.Tables[0].Rows[0]["Esi_remark"].ToString();
																												if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
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
		public university.Model.CCOM.Examination_subject_item GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Esi_id, Esi_type, Esi_text, Esi_remark, Esn_id  ");			
			strSql.Append("  from Examination_subject_item ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Examination_subject_item model=new university.Model.CCOM.Examination_subject_item();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Esi_id"].ToString()!="")
				{
					model.Esi_id=int.Parse(ds.Tables[0].Rows[0]["Esi_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Esi_type"].ToString()!="")
				{
					model.Esi_type=int.Parse(ds.Tables[0].Rows[0]["Esi_type"].ToString());
				}
																																				model.Esi_text= ds.Tables[0].Rows[0]["Esi_text"].ToString();
																																model.Esi_remark= ds.Tables[0].Rows[0]["Esi_remark"].ToString();
																												if(ds.Tables[0].Rows[0]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(ds.Tables[0].Rows[0]["Esn_id"].ToString());
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
			strSql.Append(" FROM Examination_subject_item ");
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
			strSql.Append(" FROM Examination_subject_item ");
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
			strSql.Append(" FROM Examination_subject_item ");
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
				strSql.Append("order by T.Esi_id desc");
			}
			strSql.Append(")AS Row, T.*  from Examination_subject_item T ");
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

