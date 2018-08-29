
using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//子功能表
		public partial class Son_function
	{
   		     
		private readonly university.DAL.CCOM.Son_function dal=new university.DAL.CCOM.Son_function();
		public Son_function()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Sf_id)
		{
			return dal.Exists(Sf_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Son_function model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Son_function model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Sf_id)
		{
			
			return dal.Delete(Sf_id);
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
		public bool DeleteList(string Sf_idlist )
		{
			return dal.DeleteList(Sf_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Son_function GetModel(int Sf_id)
		{
			
			return dal.GetModel(Sf_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Son_function GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Son_function GetModelByCache(int Sf_id)
		{
			
			string CacheKey = "Son_functionModel-" + Sf_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Sf_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Son_function)objModel;
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
		public List<university.Model.CCOM.Son_function> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Son_function> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Son_function> modelList = new List<university.Model.CCOM.Son_function>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Son_function model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Son_function();					
													if(dt.Rows[n]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(dt.Rows[n]["Sf_id"].ToString());
				}
																																				model.Sf_name= dt.Rows[n]["Sf_name"].ToString();
																																model.Sf_url= dt.Rows[n]["Sf_url"].ToString();
																												if(dt.Rows[n]["Sf_sort"].ToString()!="")
				{
					model.Sf_sort=int.Parse(dt.Rows[n]["Sf_sort"].ToString());
				}
																																																if(dt.Rows[n]["Sf_status"].ToString()!="")
				{
					if((dt.Rows[n]["Sf_status"].ToString()=="1")||(dt.Rows[n]["Sf_status"].ToString().ToLower()=="true"))
					{
					model.Sf_status= true;
					}
					else
					{
					model.Sf_status= false;
					}
				}
																if(dt.Rows[n]["Ff_ID"].ToString()!="")
				{
					model.Ff_ID=int.Parse(dt.Rows[n]["Ff_ID"].ToString());
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