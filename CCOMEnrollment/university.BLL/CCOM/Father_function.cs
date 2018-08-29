
using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//父功能表
		public partial class Father_function
	{
   		     
		private readonly university.DAL.CCOM.Father_function dal=new university.DAL.CCOM.Father_function();
		public Father_function()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Ff_id)
		{
			return dal.Exists(Ff_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Father_function model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Father_function model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Ff_id)
		{
			
			return dal.Delete(Ff_id);
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
		public bool DeleteList(string Ff_idlist )
		{
			return dal.DeleteList(Ff_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Father_function GetModel(int Ff_id)
		{
			
			return dal.GetModel(Ff_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Father_function GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Father_function GetModelByCache(int Ff_id)
		{
			
			string CacheKey = "Father_functionModel-" + Ff_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Ff_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Father_function)objModel;
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
		public List<university.Model.CCOM.Father_function> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Father_function> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Father_function> modelList = new List<university.Model.CCOM.Father_function>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Father_function model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Father_function();					
													if(dt.Rows[n]["Ff_id"].ToString()!="")
				{
					model.Ff_id=int.Parse(dt.Rows[n]["Ff_id"].ToString());
				}
																																				model.Ff_name= dt.Rows[n]["Ff_name"].ToString();
																												if(dt.Rows[n]["Ff_fatherID"].ToString()!="")
				{
					model.Ff_fatherID=int.Parse(dt.Rows[n]["Ff_fatherID"].ToString());
				}
																																if(dt.Rows[n]["Ff_sort"].ToString()!="")
				{
					model.Ff_sort=int.Parse(dt.Rows[n]["Ff_sort"].ToString());
				}
																																																if(dt.Rows[n]["Ff_disable"].ToString()!="")
				{
					if((dt.Rows[n]["Ff_disable"].ToString()=="1")||(dt.Rows[n]["Ff_disable"].ToString().ToLower()=="true"))
					{
					model.Ff_disable= true;
					}
					else
					{
					model.Ff_disable= false;
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