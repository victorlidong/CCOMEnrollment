using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//User_extra_value
		public partial class User_extra_value
	{
   		     
		private readonly university.DAL.CCOM.User_extra_value dal=new university.DAL.CCOM.User_extra_value();
		public User_extra_value()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Uev_id)
		{
			return dal.Exists(Uev_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(university.Model.CCOM.User_extra_value model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_extra_value model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Uev_id)
		{
			
			return dal.Delete(Uev_id);
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
		public university.Model.CCOM.User_extra_value GetModel(long Uev_id)
		{
			
			return dal.GetModel(Uev_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_extra_value GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_extra_value GetModelByCache(long Uev_id)
		{
			
			string CacheKey = "User_extra_valueModel-" + Uev_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Uev_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_extra_value)objModel;
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
		public List<university.Model.CCOM.User_extra_value> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_extra_value> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_extra_value> modelList = new List<university.Model.CCOM.User_extra_value>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_extra_value model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_extra_value();					
													if(dt.Rows[n]["Uev_id"].ToString()!="")
				{
					model.Uev_id=long.Parse(dt.Rows[n]["Uev_id"].ToString());
				}
																																if(dt.Rows[n]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(dt.Rows[n]["Ue_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																				model.Uev_value= dt.Rows[n]["Uev_value"].ToString();
																						
				
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