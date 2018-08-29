using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_UserAgency
		public partial class View_UserAgency
	{
   		     
		private readonly university.DAL.CCOM.View_UserAgency dal=new university.DAL.CCOM.View_UserAgency();
		public View_UserAgency()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			return dal.Exists();
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(university.Model.CCOM.View_UserAgency model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_UserAgency model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			
			return dal.Delete();
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string strWhere)
		{
			return dal.Delete(strWhere);
		}
		
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_UserAgency GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_UserAgency GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_UserAgency GetModelByCache()
		{
			
			string CacheKey = "View_UserAgencyModel-" + ;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.View_UserAgency)objModel;
		}*/

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_UserAgency> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_UserAgency> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_UserAgency> modelList = new List<university.Model.CCOM.View_UserAgency>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_UserAgency model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_UserAgency();					
													if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																				model.Agency_name= dt.Rows[n]["Agency_name"].ToString();
																																model.User_realname= dt.Rows[n]["User_realname"].ToString();
																																												if(dt.Rows[n]["User_gender"].ToString()!="")
				{
					if((dt.Rows[n]["User_gender"].ToString()=="1")||(dt.Rows[n]["User_gender"].ToString().ToLower()=="true"))
					{
					model.User_gender= true;
					}
					else
					{
					model.User_gender= false;
					}
				}
																if(dt.Rows[n]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(dt.Rows[n]["UP_politics"].ToString());
				}
																																				model.UP_picture= dt.Rows[n]["UP_picture"].ToString();
																																model.UP_CEE_number= dt.Rows[n]["UP_CEE_number"].ToString();
																																model.User_number= dt.Rows[n]["User_number"].ToString();
																												if(dt.Rows[n]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(dt.Rows[n]["UP_nationality"].ToString());
				}
																																																if(dt.Rows[n]["User_status"].ToString()!="")
				{
					if((dt.Rows[n]["User_status"].ToString()=="1")||(dt.Rows[n]["User_status"].ToString().ToLower()=="true"))
					{
					model.User_status= true;
					}
					else
					{
					model.User_status= false;
					}
				}
																if(dt.Rows[n]["User_type"].ToString()!="")
				{
					model.User_type=int.Parse(dt.Rows[n]["User_type"].ToString());
				}
																																if(dt.Rows[n]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(dt.Rows[n]["UP_province"].ToString());
				}
																																if(dt.Rows[n]["User_addtime"].ToString()!="")
				{
					model.User_addtime=DateTime.Parse(dt.Rows[n]["User_addtime"].ToString());
				}
																																if(dt.Rows[n]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(dt.Rows[n]["UP_calculation_status"].ToString());
				}
																																				model.UP_CCOM_number= dt.Rows[n]["UP_CCOM_number"].ToString();
																												if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																				model.UP_address= dt.Rows[n]["UP_address"].ToString();
																																model.UP_receiver= dt.Rows[n]["UP_receiver"].ToString();
																																model.UP_receiver_phone= dt.Rows[n]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= dt.Rows[n]["UP_postal_code"].ToString();
																																model.UP_PE_Aphone= dt.Rows[n]["UP_PE_Aphone"].ToString();
																																model.UP_PE_Iphone= dt.Rows[n]["UP_PE_Iphone"].ToString();
																																model.UP_AEE_picture= dt.Rows[n]["UP_AEE_picture"].ToString();
																																model.UP_AEE_number= dt.Rows[n]["UP_AEE_number"].ToString();
																																model.UP_high_school= dt.Rows[n]["UP_high_school"].ToString();
																												if(dt.Rows[n]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(dt.Rows[n]["UP_degree"].ToString());
				}
																																if(dt.Rows[n]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(dt.Rows[n]["UP_nation"].ToString());
				}
																																				model.UP_ID_picture= dt.Rows[n]["UP_ID_picture"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		
#endregion
   
	}
}