using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//User_property
		public partial class User_property
	{
   		     
		public bool Exists(long UP_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_property");
			strSql.Append(" where ");
			                                       strSql.Append(" UP_id = @UP_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@UP_id", SqlDbType.BigInt)
			};
			parameters[0].Value = UP_id;

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.User_property model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_property(");			
            strSql.Append("UP_ID_picture,UP_picture,UP_nation,UP_nationality,UP_politics,UP_degree,UP_high_school,UP_CEE_number,UP_AEE_number,UP_AEE_picture,UP_PE_Iphone,UP_PE_Aphone,UP_province,UP_address,UP_receiver,UP_receiver_phone,UP_postal_code,User_id,Agency_id,Period_id,UP_CCOM_number,UP_calculation_status,UP_overseas");
			strSql.Append(") values (");
            strSql.Append("@UP_ID_picture,@UP_picture,@UP_nation,@UP_nationality,@UP_politics,@UP_degree,@UP_high_school,@UP_CEE_number,@UP_AEE_number,@UP_AEE_picture,@UP_PE_Iphone,@UP_PE_Aphone,@UP_province,@UP_address,@UP_receiver,@UP_receiver_phone,@UP_postal_code,@User_id,@Agency_id,@Period_id,@UP_CCOM_number,@UP_calculation_status,@UP_overseas");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@UP_ID_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_nation", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_nationality", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_degree", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_high_school", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_AEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_AEE_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_PE_Iphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Aphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_address", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@UP_receiver", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_receiver_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_postal_code", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_overseas", SqlDbType.Bit,1)             
              
            };
			            
            parameters[0].Value = model.UP_ID_picture;                        
            parameters[1].Value = model.UP_picture;                        
            parameters[2].Value = model.UP_nation;                        
            parameters[3].Value = model.UP_nationality;                        
            parameters[4].Value = model.UP_politics;                        
            parameters[5].Value = model.UP_degree;                        
            parameters[6].Value = model.UP_high_school;                        
            parameters[7].Value = model.UP_CEE_number;                        
            parameters[8].Value = model.UP_AEE_number;                        
            parameters[9].Value = model.UP_AEE_picture;                        
            parameters[10].Value = model.UP_PE_Iphone;                        
            parameters[11].Value = model.UP_PE_Aphone;                        
            parameters[12].Value = model.UP_province;                        
            parameters[13].Value = model.UP_address;                        
            parameters[14].Value = model.UP_receiver;                        
            parameters[15].Value = model.UP_receiver_phone;                        
            parameters[16].Value = model.UP_postal_code;                        
            parameters[17].Value = model.User_id;                        
            parameters[18].Value = model.Agency_id;                        
            parameters[19].Value = model.Period_id;                        
            parameters[20].Value = model.UP_CCOM_number;                        
            parameters[21].Value = model.UP_calculation_status;                        
            parameters[22].Value = model.UP_overseas;                        
			   
			object obj = DBSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                                    
            	return Convert.ToInt64(obj);
                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_property model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_property set ");
			                                                
            strSql.Append(" UP_ID_picture = @UP_ID_picture , ");                                    
            strSql.Append(" UP_picture = @UP_picture , ");                                    
            strSql.Append(" UP_nation = @UP_nation , ");                                    
            strSql.Append(" UP_nationality = @UP_nationality , ");                                    
            strSql.Append(" UP_politics = @UP_politics , ");                                    
            strSql.Append(" UP_degree = @UP_degree , ");                                    
            strSql.Append(" UP_high_school = @UP_high_school , ");                                    
            strSql.Append(" UP_CEE_number = @UP_CEE_number , ");                                    
            strSql.Append(" UP_AEE_number = @UP_AEE_number , ");                                    
            strSql.Append(" UP_AEE_picture = @UP_AEE_picture , ");                                    
            strSql.Append(" UP_PE_Iphone = @UP_PE_Iphone , ");                                    
            strSql.Append(" UP_PE_Aphone = @UP_PE_Aphone , ");                                    
            strSql.Append(" UP_province = @UP_province , ");                                    
            strSql.Append(" UP_address = @UP_address , ");                                    
            strSql.Append(" UP_receiver = @UP_receiver , ");                                    
            strSql.Append(" UP_receiver_phone = @UP_receiver_phone , ");                                    
            strSql.Append(" UP_postal_code = @UP_postal_code , ");                                    
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" UP_CCOM_number = @UP_CCOM_number , ");                                    
            strSql.Append(" UP_calculation_status = @UP_calculation_status , ");                                    
            strSql.Append(" UP_overseas = @UP_overseas  ");            			
			strSql.Append(" where UP_id=@UP_id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@UP_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@UP_ID_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_nation", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_nationality", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_degree", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_high_school", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_AEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_AEE_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_PE_Iphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Aphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_address", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@UP_receiver", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_receiver_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_postal_code", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_overseas", SqlDbType.Bit,1)             
              
            };
						            
            parameters[0].Value = model.UP_id;                        
            parameters[1].Value = model.UP_ID_picture;                        
            parameters[2].Value = model.UP_picture;                        
            parameters[3].Value = model.UP_nation;                        
            parameters[4].Value = model.UP_nationality;                        
            parameters[5].Value = model.UP_politics;                        
            parameters[6].Value = model.UP_degree;                        
            parameters[7].Value = model.UP_high_school;                        
            parameters[8].Value = model.UP_CEE_number;                        
            parameters[9].Value = model.UP_AEE_number;                        
            parameters[10].Value = model.UP_AEE_picture;                        
            parameters[11].Value = model.UP_PE_Iphone;                        
            parameters[12].Value = model.UP_PE_Aphone;                        
            parameters[13].Value = model.UP_province;                        
            parameters[14].Value = model.UP_address;                        
            parameters[15].Value = model.UP_receiver;                        
            parameters[16].Value = model.UP_receiver_phone;                        
            parameters[17].Value = model.UP_postal_code;                        
            parameters[18].Value = model.User_id;                        
            parameters[19].Value = model.Agency_id;                        
            parameters[20].Value = model.Period_id;                        
            parameters[21].Value = model.UP_CCOM_number;                        
            parameters[22].Value = model.UP_calculation_status;                        
            parameters[23].Value = model.UP_overseas;                        
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
		public bool Delete(long UP_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_property ");
			strSql.Append(" where UP_id=@UP_id");
						SqlParameter[] parameters = {
					new SqlParameter("@UP_id", SqlDbType.BigInt)
			};
			parameters[0].Value = UP_id;


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
			strSql.Append("delete from User_property ");
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
		public bool DeleteList(string UP_idlist )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_property ");
			strSql.Append(" where UP_id in ("+UP_idlist + ")  ");
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
		public university.Model.CCOM.User_property GetModel(long UP_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UP_id, UP_ID_picture, UP_picture, UP_nation, UP_nationality, UP_politics, UP_degree, UP_high_school, UP_CEE_number, UP_AEE_number, UP_AEE_picture, UP_PE_Iphone, UP_PE_Aphone, UP_province, UP_address, UP_receiver, UP_receiver_phone, UP_postal_code, User_id, Agency_id, Period_id, UP_CCOM_number, UP_calculation_status, UP_overseas  ");			
			strSql.Append("  from User_property ");
			strSql.Append(" where UP_id=@UP_id");
						SqlParameter[] parameters = {
					new SqlParameter("@UP_id", SqlDbType.BigInt)
			};
			parameters[0].Value = UP_id;

			
			university.Model.CCOM.User_property model=new university.Model.CCOM.User_property();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["UP_id"].ToString()!="")
				{
					model.UP_id=long.Parse(ds.Tables[0].Rows[0]["UP_id"].ToString());
				}
																																				model.UP_ID_picture= ds.Tables[0].Rows[0]["UP_ID_picture"].ToString();
																																model.UP_picture= ds.Tables[0].Rows[0]["UP_picture"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(ds.Tables[0].Rows[0]["UP_nation"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(ds.Tables[0].Rows[0]["UP_nationality"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(ds.Tables[0].Rows[0]["UP_politics"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(ds.Tables[0].Rows[0]["UP_degree"].ToString());
				}
																																				model.UP_high_school= ds.Tables[0].Rows[0]["UP_high_school"].ToString();
																																model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																																model.UP_AEE_number= ds.Tables[0].Rows[0]["UP_AEE_number"].ToString();
																																model.UP_AEE_picture= ds.Tables[0].Rows[0]["UP_AEE_picture"].ToString();
																																model.UP_PE_Iphone= ds.Tables[0].Rows[0]["UP_PE_Iphone"].ToString();
																																model.UP_PE_Aphone= ds.Tables[0].Rows[0]["UP_PE_Aphone"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																				model.UP_address= ds.Tables[0].Rows[0]["UP_address"].ToString();
																																model.UP_receiver= ds.Tables[0].Rows[0]["UP_receiver"].ToString();
																																model.UP_receiver_phone= ds.Tables[0].Rows[0]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= ds.Tables[0].Rows[0]["UP_postal_code"].ToString();
																												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["UP_overseas"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["UP_overseas"].ToString()=="1")||(ds.Tables[0].Rows[0]["UP_overseas"].ToString().ToLower()=="true"))
					{
					model.UP_overseas= true;
					}
					else
					{
					model.UP_overseas= false;
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
		public university.Model.CCOM.User_property GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UP_id, UP_ID_picture, UP_picture, UP_nation, UP_nationality, UP_politics, UP_degree, UP_high_school, UP_CEE_number, UP_AEE_number, UP_AEE_picture, UP_PE_Iphone, UP_PE_Aphone, UP_province, UP_address, UP_receiver, UP_receiver_phone, UP_postal_code, User_id, Agency_id, Period_id, UP_CCOM_number, UP_calculation_status, UP_overseas  ");			
			strSql.Append("  from User_property ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.User_property model=new university.Model.CCOM.User_property();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["UP_id"].ToString()!="")
				{
					model.UP_id=long.Parse(ds.Tables[0].Rows[0]["UP_id"].ToString());
				}
																																				model.UP_ID_picture= ds.Tables[0].Rows[0]["UP_ID_picture"].ToString();
																																model.UP_picture= ds.Tables[0].Rows[0]["UP_picture"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(ds.Tables[0].Rows[0]["UP_nation"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(ds.Tables[0].Rows[0]["UP_nationality"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(ds.Tables[0].Rows[0]["UP_politics"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(ds.Tables[0].Rows[0]["UP_degree"].ToString());
				}
																																				model.UP_high_school= ds.Tables[0].Rows[0]["UP_high_school"].ToString();
																																model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																																model.UP_AEE_number= ds.Tables[0].Rows[0]["UP_AEE_number"].ToString();
																																model.UP_AEE_picture= ds.Tables[0].Rows[0]["UP_AEE_picture"].ToString();
																																model.UP_PE_Iphone= ds.Tables[0].Rows[0]["UP_PE_Iphone"].ToString();
																																model.UP_PE_Aphone= ds.Tables[0].Rows[0]["UP_PE_Aphone"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																				model.UP_address= ds.Tables[0].Rows[0]["UP_address"].ToString();
																																model.UP_receiver= ds.Tables[0].Rows[0]["UP_receiver"].ToString();
																																model.UP_receiver_phone= ds.Tables[0].Rows[0]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= ds.Tables[0].Rows[0]["UP_postal_code"].ToString();
																												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["UP_overseas"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["UP_overseas"].ToString()=="1")||(ds.Tables[0].Rows[0]["UP_overseas"].ToString().ToLower()=="true"))
					{
					model.UP_overseas= true;
					}
					else
					{
					model.UP_overseas= false;
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
			strSql.Append(" FROM User_property ");
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
			strSql.Append(" FROM User_property ");
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
			strSql.Append(" FROM User_property ");
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
				strSql.Append("order by T.UP_id desc");
			}
			strSql.Append(")AS Row, T.*  from User_property T ");
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

