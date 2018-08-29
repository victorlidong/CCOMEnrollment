using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using university.Database;
namespace university.DAL.CCOM
{
	 	//机构表
		public partial class Agency
	{
   		     
		public bool Exists(int Agency_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Agency");
			strSql.Append(" where ");
			                                       strSql.Append(" Agency_id = @Agency_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Agency_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Agency_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(university.Model.CCOM.Agency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Agency(");			
            strSql.Append("Agency_name,Agency_father,Agency_type,Agency_status");
			strSql.Append(") values (");
            strSql.Append("@Agency_name,@Agency_father,@Agency_type,@Agency_status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Agency_father", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_status", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.Agency_name;                        
            parameters[1].Value = model.Agency_father;                        
            parameters[2].Value = model.Agency_type;                        
            parameters[3].Value = model.Agency_status;                        
			   
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
		public bool Update(university.Model.CCOM.Agency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Agency set ");
			                                                
            strSql.Append(" Agency_name = @Agency_name , ");                                    
            strSql.Append(" Agency_father = @Agency_father , ");                                    
            strSql.Append(" Agency_type = @Agency_type , ");                                    
            strSql.Append(" Agency_status = @Agency_status  ");            			
			strSql.Append(" where Agency_id=@Agency_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@Agency_father", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_status", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.Agency_id;                        
            parameters[1].Value = model.Agency_name;                        
            parameters[2].Value = model.Agency_father;                        
            parameters[3].Value = model.Agency_type;                        
            parameters[4].Value = model.Agency_status;                        
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
		public bool Delete(int Agency_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Agency ");
			strSql.Append(" where Agency_id=@Agency_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Agency_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Agency_id;


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
			strSql.Append("delete from Agency ");
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
		public bool DeleteList(string Agency_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Agency ");
			strSql.Append(" where Agency_id in ("+Agency_idlist + ")  ");
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
		public university.Model.CCOM.Agency GetModel(int Agency_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Agency_id, Agency_name, Agency_father, Agency_type, Agency_status  ");			
			strSql.Append("  from Agency ");
			strSql.Append(" where Agency_id=@Agency_id");
						SqlParameter[] parameters = {
					new SqlParameter("@Agency_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Agency_id;

			
			university.Model.CCOM.Agency model=new university.Model.CCOM.Agency();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.Agency_name= ds.Tables[0].Rows[0]["Agency_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Agency_father"].ToString()!="")
				{
					model.Agency_father=int.Parse(ds.Tables[0].Rows[0]["Agency_father"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_type"].ToString()!="")
				{
					model.Agency_type=int.Parse(ds.Tables[0].Rows[0]["Agency_type"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Agency_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Agency_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Agency_status"].ToString().ToLower()=="true"))
					{
					model.Agency_status= true;
					}
					else
					{
					model.Agency_status= false;
					}
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
		public university.Model.CCOM.Agency GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Agency_id, Agency_name, Agency_father, Agency_type, Agency_status  ");			
			strSql.Append("  from Agency ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.Agency model=new university.Model.CCOM.Agency();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.Agency_name= ds.Tables[0].Rows[0]["Agency_name"].ToString();
																												if(ds.Tables[0].Rows[0]["Agency_father"].ToString()!="")
				{
					model.Agency_father=int.Parse(ds.Tables[0].Rows[0]["Agency_father"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_type"].ToString()!="")
				{
					model.Agency_type=int.Parse(ds.Tables[0].Rows[0]["Agency_type"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["Agency_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Agency_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["Agency_status"].ToString().ToLower()=="true"))
					{
					model.Agency_status= true;
					}
					else
					{
					model.Agency_status= false;
					}
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
			strSql.Append(" FROM Agency ");
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
			strSql.Append(" FROM Agency ");
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
			strSql.Append(" FROM Agency ");
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
				strSql.Append("order by T.Agency_id desc");
			}
			strSql.Append(")AS Row, T.*  from Agency T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBSQL.Query(strSql.ToString());
		}




        public Model.CCOM.Agency GetModel(long Agency_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Agency_id, Agency_name, Agency_father, Agency_type, Agency_status  ");
            strSql.Append("  from Agency ");
            strSql.Append(" where Agency_id=@Agency_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Agency_id", SqlDbType.BigInt)
			};
            parameters[0].Value = Agency_id;

            university.Model.CCOM.Agency model = new university.Model.CCOM.Agency();
            DataSet ds = DBSQL.Query(strSql.ToString(),parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Agency_id"].ToString() != "")
                {
                    model.Agency_id = int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
                }
                model.Agency_name = ds.Tables[0].Rows[0]["Agency_name"].ToString();
                if (ds.Tables[0].Rows[0]["Agency_father"].ToString() != "")
                {
                    model.Agency_father = int.Parse(ds.Tables[0].Rows[0]["Agency_father"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agency_type"].ToString() != "")
                {
                    model.Agency_type = int.Parse(ds.Tables[0].Rows[0]["Agency_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agency_status"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Agency_status"].ToString() == "1") || (ds.Tables[0].Rows[0]["Agency_status"].ToString().ToLower() == "true"))
                    {
                        model.Agency_status = true;
                    }
                    else
                    {
                        model.Agency_status = false;
                    }
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

