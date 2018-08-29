using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using university.Database;

namespace university.DAL.CCOM
{
	 	//View_UserAgency
		public partial class View_UserAgency
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from View_UserAgency");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DBSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(university.Model.CCOM.View_UserAgency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_UserAgency(");			
            strSql.Append("User_id,Agency_id,Agency_name,User_realname,User_gender,UP_politics,UP_picture,UP_CEE_number,User_number,UP_nationality,User_status,User_type,UP_province,User_addtime,UP_calculation_status,UP_CCOM_number,Period_id,UP_address,UP_receiver,UP_receiver_phone,UP_postal_code,UP_PE_Aphone,UP_PE_Iphone,UP_AEE_picture,UP_AEE_number,UP_high_school,UP_degree,UP_nation,UP_ID_picture");
			strSql.Append(") values (");
            strSql.Append("@User_id,@Agency_id,@Agency_name,@User_realname,@User_gender,@UP_politics,@UP_picture,@UP_CEE_number,@User_number,@UP_nationality,@User_status,@User_type,@UP_province,@User_addtime,@UP_calculation_status,@UP_CCOM_number,@Period_id,@UP_address,@UP_receiver,@UP_receiver_phone,@UP_postal_code,@UP_PE_Aphone,@UP_PE_Iphone,@UP_AEE_picture,@UP_AEE_number,@UP_high_school,@UP_degree,@UP_nation,@UP_ID_picture");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_gender", SqlDbType.Bit,1) ,            
                        new SqlParameter("@UP_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_nationality", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_address", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@UP_receiver", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_receiver_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_postal_code", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Aphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Iphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_AEE_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_AEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_high_school", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_degree", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_nation", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_ID_picture", SqlDbType.VarChar,512)             
              
            };
			            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Agency_id;                        
            parameters[2].Value = model.Agency_name;                        
            parameters[3].Value = model.User_realname;                        
            parameters[4].Value = model.User_gender;                        
            parameters[5].Value = model.UP_politics;                        
            parameters[6].Value = model.UP_picture;                        
            parameters[7].Value = model.UP_CEE_number;                        
            parameters[8].Value = model.User_number;                        
            parameters[9].Value = model.UP_nationality;                        
            parameters[10].Value = model.User_status;                        
            parameters[11].Value = model.User_type;                        
            parameters[12].Value = model.UP_province;                        
            parameters[13].Value = model.User_addtime;                        
            parameters[14].Value = model.UP_calculation_status;                        
            parameters[15].Value = model.UP_CCOM_number;                        
            parameters[16].Value = model.Period_id;                        
            parameters[17].Value = model.UP_address;                        
            parameters[18].Value = model.UP_receiver;                        
            parameters[19].Value = model.UP_receiver_phone;                        
            parameters[20].Value = model.UP_postal_code;                        
            parameters[21].Value = model.UP_PE_Aphone;                        
            parameters[22].Value = model.UP_PE_Iphone;                        
            parameters[23].Value = model.UP_AEE_picture;                        
            parameters[24].Value = model.UP_AEE_number;                        
            parameters[25].Value = model.UP_high_school;                        
            parameters[26].Value = model.UP_degree;                        
            parameters[27].Value = model.UP_nation;                        
            parameters[28].Value = model.UP_ID_picture;                        
			            DBSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_UserAgency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_UserAgency set ");
			                        
            strSql.Append(" User_id = @User_id , ");                                    
            strSql.Append(" Agency_id = @Agency_id , ");                                    
            strSql.Append(" Agency_name = @Agency_name , ");                                    
            strSql.Append(" User_realname = @User_realname , ");                                    
            strSql.Append(" User_gender = @User_gender , ");                                    
            strSql.Append(" UP_politics = @UP_politics , ");                                    
            strSql.Append(" UP_picture = @UP_picture , ");                                    
            strSql.Append(" UP_CEE_number = @UP_CEE_number , ");                                    
            strSql.Append(" User_number = @User_number , ");                                    
            strSql.Append(" UP_nationality = @UP_nationality , ");                                    
            strSql.Append(" User_status = @User_status , ");                                    
            strSql.Append(" User_type = @User_type , ");                                    
            strSql.Append(" UP_province = @UP_province , ");                                    
            strSql.Append(" User_addtime = @User_addtime , ");                                    
            strSql.Append(" UP_calculation_status = @UP_calculation_status , ");                                    
            strSql.Append(" UP_CCOM_number = @UP_CCOM_number , ");                                    
            strSql.Append(" Period_id = @Period_id , ");                                    
            strSql.Append(" UP_address = @UP_address , ");                                    
            strSql.Append(" UP_receiver = @UP_receiver , ");                                    
            strSql.Append(" UP_receiver_phone = @UP_receiver_phone , ");                                    
            strSql.Append(" UP_postal_code = @UP_postal_code , ");                                    
            strSql.Append(" UP_PE_Aphone = @UP_PE_Aphone , ");                                    
            strSql.Append(" UP_PE_Iphone = @UP_PE_Iphone , ");                                    
            strSql.Append(" UP_AEE_picture = @UP_AEE_picture , ");                                    
            strSql.Append(" UP_AEE_number = @UP_AEE_number , ");                                    
            strSql.Append(" UP_high_school = @UP_high_school , ");                                    
            strSql.Append(" UP_degree = @UP_degree , ");                                    
            strSql.Append(" UP_nation = @UP_nation , ");                                    
            strSql.Append(" UP_ID_picture = @UP_ID_picture  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@User_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Agency_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Agency_name", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_realname", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_gender", SqlDbType.Bit,1) ,            
                        new SqlParameter("@UP_politics", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_CEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@User_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_nationality", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UP_province", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UP_calculation_status", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_CCOM_number", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@Period_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_address", SqlDbType.VarChar,1024) ,            
                        new SqlParameter("@UP_receiver", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_receiver_phone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_postal_code", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Aphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_PE_Iphone", SqlDbType.VarChar,16) ,            
                        new SqlParameter("@UP_AEE_picture", SqlDbType.VarChar,512) ,            
                        new SqlParameter("@UP_AEE_number", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_high_school", SqlDbType.VarChar,128) ,            
                        new SqlParameter("@UP_degree", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_nation", SqlDbType.Int,4) ,            
                        new SqlParameter("@UP_ID_picture", SqlDbType.VarChar,512)             
              
            };
						            
            parameters[0].Value = model.User_id;                        
            parameters[1].Value = model.Agency_id;                        
            parameters[2].Value = model.Agency_name;                        
            parameters[3].Value = model.User_realname;                        
            parameters[4].Value = model.User_gender;                        
            parameters[5].Value = model.UP_politics;                        
            parameters[6].Value = model.UP_picture;                        
            parameters[7].Value = model.UP_CEE_number;                        
            parameters[8].Value = model.User_number;                        
            parameters[9].Value = model.UP_nationality;                        
            parameters[10].Value = model.User_status;                        
            parameters[11].Value = model.User_type;                        
            parameters[12].Value = model.UP_province;                        
            parameters[13].Value = model.User_addtime;                        
            parameters[14].Value = model.UP_calculation_status;                        
            parameters[15].Value = model.UP_CCOM_number;                        
            parameters[16].Value = model.Period_id;                        
            parameters[17].Value = model.UP_address;                        
            parameters[18].Value = model.UP_receiver;                        
            parameters[19].Value = model.UP_receiver_phone;                        
            parameters[20].Value = model.UP_postal_code;                        
            parameters[21].Value = model.UP_PE_Aphone;                        
            parameters[22].Value = model.UP_PE_Iphone;                        
            parameters[23].Value = model.UP_AEE_picture;                        
            parameters[24].Value = model.UP_AEE_number;                        
            parameters[25].Value = model.UP_high_school;                        
            parameters[26].Value = model.UP_degree;                        
            parameters[27].Value = model.UP_nation;                        
            parameters[28].Value = model.UP_ID_picture;                        
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
			strSql.Append("delete from View_UserAgency ");
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
			strSql.Append("delete from View_UserAgency ");
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
		public university.Model.CCOM.View_UserAgency GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_id, Agency_id, Agency_name, User_realname, User_gender, UP_politics, UP_picture, UP_CEE_number, User_number, UP_nationality, User_status, User_type, UP_province, User_addtime, UP_calculation_status, UP_CCOM_number, Period_id, UP_address, UP_receiver, UP_receiver_phone, UP_postal_code, UP_PE_Aphone, UP_PE_Iphone, UP_AEE_picture, UP_AEE_number, UP_high_school, UP_degree, UP_nation, UP_ID_picture  ");			
			strSql.Append("  from View_UserAgency ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			university.Model.CCOM.View_UserAgency model=new university.Model.CCOM.View_UserAgency();
			DataSet ds=DBSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.Agency_name= ds.Tables[0].Rows[0]["Agency_name"].ToString();
																																model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																																												if(ds.Tables[0].Rows[0]["User_gender"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["User_gender"].ToString()=="1")||(ds.Tables[0].Rows[0]["User_gender"].ToString().ToLower()=="true"))
					{
					model.User_gender= true;
					}
					else
					{
					model.User_gender= false;
					}
				}
																if(ds.Tables[0].Rows[0]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(ds.Tables[0].Rows[0]["UP_politics"].ToString());
				}
																																				model.UP_picture= ds.Tables[0].Rows[0]["UP_picture"].ToString();
																																model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																																model.User_number= ds.Tables[0].Rows[0]["User_number"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(ds.Tables[0].Rows[0]["UP_nationality"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["User_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["User_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["User_status"].ToString().ToLower()=="true"))
					{
					model.User_status= true;
					}
					else
					{
					model.User_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["User_type"].ToString()!="")
				{
					model.User_type=int.Parse(ds.Tables[0].Rows[0]["User_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_addtime"].ToString()!="")
				{
					model.User_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["User_addtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_address= ds.Tables[0].Rows[0]["UP_address"].ToString();
																																model.UP_receiver= ds.Tables[0].Rows[0]["UP_receiver"].ToString();
																																model.UP_receiver_phone= ds.Tables[0].Rows[0]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= ds.Tables[0].Rows[0]["UP_postal_code"].ToString();
																																model.UP_PE_Aphone= ds.Tables[0].Rows[0]["UP_PE_Aphone"].ToString();
																																model.UP_PE_Iphone= ds.Tables[0].Rows[0]["UP_PE_Iphone"].ToString();
																																model.UP_AEE_picture= ds.Tables[0].Rows[0]["UP_AEE_picture"].ToString();
																																model.UP_AEE_number= ds.Tables[0].Rows[0]["UP_AEE_number"].ToString();
																																model.UP_high_school= ds.Tables[0].Rows[0]["UP_high_school"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(ds.Tables[0].Rows[0]["UP_degree"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(ds.Tables[0].Rows[0]["UP_nation"].ToString());
				}
																																				model.UP_ID_picture= ds.Tables[0].Rows[0]["UP_ID_picture"].ToString();
																										
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
		public university.Model.CCOM.View_UserAgency GetModel(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select User_id, Agency_id, Agency_name, User_realname, User_gender, UP_politics, UP_picture, UP_CEE_number, User_number, UP_nationality, User_status, User_type, UP_province, User_addtime, UP_calculation_status, UP_CCOM_number, Period_id, UP_address, UP_receiver, UP_receiver_phone, UP_postal_code, UP_PE_Aphone, UP_PE_Iphone, UP_AEE_picture, UP_AEE_number, UP_high_school, UP_degree, UP_nation, UP_ID_picture  ");			
			strSql.Append("  from View_UserAgency ");
			strSql.Append(" where " + strWhere);
			
			
			university.Model.CCOM.View_UserAgency model=new university.Model.CCOM.View_UserAgency();
			DataSet ds=DBSQL.Query(strSql.ToString());
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(ds.Tables[0].Rows[0]["Agency_id"].ToString());
				}
																																				model.Agency_name= ds.Tables[0].Rows[0]["Agency_name"].ToString();
																																model.User_realname= ds.Tables[0].Rows[0]["User_realname"].ToString();
																																												if(ds.Tables[0].Rows[0]["User_gender"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["User_gender"].ToString()=="1")||(ds.Tables[0].Rows[0]["User_gender"].ToString().ToLower()=="true"))
					{
					model.User_gender= true;
					}
					else
					{
					model.User_gender= false;
					}
				}
																if(ds.Tables[0].Rows[0]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(ds.Tables[0].Rows[0]["UP_politics"].ToString());
				}
																																				model.UP_picture= ds.Tables[0].Rows[0]["UP_picture"].ToString();
																																model.UP_CEE_number= ds.Tables[0].Rows[0]["UP_CEE_number"].ToString();
																																model.User_number= ds.Tables[0].Rows[0]["User_number"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(ds.Tables[0].Rows[0]["UP_nationality"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["User_status"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["User_status"].ToString()=="1")||(ds.Tables[0].Rows[0]["User_status"].ToString().ToLower()=="true"))
					{
					model.User_status= true;
					}
					else
					{
					model.User_status= false;
					}
				}
																if(ds.Tables[0].Rows[0]["User_type"].ToString()!="")
				{
					model.User_type=int.Parse(ds.Tables[0].Rows[0]["User_type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(ds.Tables[0].Rows[0]["UP_province"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["User_addtime"].ToString()!="")
				{
					model.User_addtime=DateTime.Parse(ds.Tables[0].Rows[0]["User_addtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(ds.Tables[0].Rows[0]["UP_calculation_status"].ToString());
				}
																																				model.UP_CCOM_number= ds.Tables[0].Rows[0]["UP_CCOM_number"].ToString();
																												if(ds.Tables[0].Rows[0]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(ds.Tables[0].Rows[0]["Period_id"].ToString());
				}
																																				model.UP_address= ds.Tables[0].Rows[0]["UP_address"].ToString();
																																model.UP_receiver= ds.Tables[0].Rows[0]["UP_receiver"].ToString();
																																model.UP_receiver_phone= ds.Tables[0].Rows[0]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= ds.Tables[0].Rows[0]["UP_postal_code"].ToString();
																																model.UP_PE_Aphone= ds.Tables[0].Rows[0]["UP_PE_Aphone"].ToString();
																																model.UP_PE_Iphone= ds.Tables[0].Rows[0]["UP_PE_Iphone"].ToString();
																																model.UP_AEE_picture= ds.Tables[0].Rows[0]["UP_AEE_picture"].ToString();
																																model.UP_AEE_number= ds.Tables[0].Rows[0]["UP_AEE_number"].ToString();
																																model.UP_high_school= ds.Tables[0].Rows[0]["UP_high_school"].ToString();
																												if(ds.Tables[0].Rows[0]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(ds.Tables[0].Rows[0]["UP_degree"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(ds.Tables[0].Rows[0]["UP_nation"].ToString());
				}
																																				model.UP_ID_picture= ds.Tables[0].Rows[0]["UP_ID_picture"].ToString();
																										
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
			strSql.Append(" FROM View_UserAgency ");
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
			strSql.Append(" FROM View_UserAgency ");
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
			strSql.Append(" FROM View_UserAgency ");
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
			strSql.Append(")AS Row, T.*  from View_UserAgency T ");
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

