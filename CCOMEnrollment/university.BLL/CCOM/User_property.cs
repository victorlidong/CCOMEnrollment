using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//User_property
		public partial class User_property
	{
   		     
		private readonly university.DAL.CCOM.User_property dal=new university.DAL.CCOM.User_property();
		public User_property()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UP_id)
		{
			return dal.Exists(UP_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.User_property model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_property model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UP_id)
		{
			
			return dal.Delete(UP_id);
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string strWhere)
		{
			return dal.Delete(strWhere);
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string UP_idlist )
		{
			return dal.DeleteList(UP_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_property GetModel(long UP_id)
		{
			
			return dal.GetModel(UP_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_property GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_property GetModelByCache(long UP_id)
		{
			
			string CacheKey = "User_propertyModel-" + UP_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UP_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_property)objModel;
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
		public List<university.Model.CCOM.User_property> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_property> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_property> modelList = new List<university.Model.CCOM.User_property>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_property model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_property();					
													if(dt.Rows[n]["UP_id"].ToString()!="")
				{
					model.UP_id=long.Parse(dt.Rows[n]["UP_id"].ToString());
				}
																																				model.UP_ID_picture= dt.Rows[n]["UP_ID_picture"].ToString();
																																model.UP_picture= dt.Rows[n]["UP_picture"].ToString();
																												if(dt.Rows[n]["UP_nation"].ToString()!="")
				{
					model.UP_nation=int.Parse(dt.Rows[n]["UP_nation"].ToString());
				}
																																if(dt.Rows[n]["UP_nationality"].ToString()!="")
				{
					model.UP_nationality=int.Parse(dt.Rows[n]["UP_nationality"].ToString());
				}
																																if(dt.Rows[n]["UP_politics"].ToString()!="")
				{
					model.UP_politics=int.Parse(dt.Rows[n]["UP_politics"].ToString());
				}
																																if(dt.Rows[n]["UP_degree"].ToString()!="")
				{
					model.UP_degree=int.Parse(dt.Rows[n]["UP_degree"].ToString());
				}
																																				model.UP_high_school= dt.Rows[n]["UP_high_school"].ToString();
																																model.UP_CEE_number= dt.Rows[n]["UP_CEE_number"].ToString();
																																model.UP_AEE_number= dt.Rows[n]["UP_AEE_number"].ToString();
																																model.UP_AEE_picture= dt.Rows[n]["UP_AEE_picture"].ToString();
																																model.UP_PE_Iphone= dt.Rows[n]["UP_PE_Iphone"].ToString();
																																model.UP_PE_Aphone= dt.Rows[n]["UP_PE_Aphone"].ToString();
																												if(dt.Rows[n]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(dt.Rows[n]["UP_province"].ToString());
				}
																																				model.UP_address= dt.Rows[n]["UP_address"].ToString();
																																model.UP_receiver= dt.Rows[n]["UP_receiver"].ToString();
																																model.UP_receiver_phone= dt.Rows[n]["UP_receiver_phone"].ToString();
																																model.UP_postal_code= dt.Rows[n]["UP_postal_code"].ToString();
																												if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= dt.Rows[n]["UP_CCOM_number"].ToString();
																												if(dt.Rows[n]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(dt.Rows[n]["UP_calculation_status"].ToString());
				}
																																																if(dt.Rows[n]["UP_overseas"].ToString()!="")
				{
					if((dt.Rows[n]["UP_overseas"].ToString()=="1")||(dt.Rows[n]["UP_overseas"].ToString().ToLower()=="true"))
					{
					model.UP_overseas= true;
					}
					else
					{
					model.UP_overseas= false;
					}
				}
										
				
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