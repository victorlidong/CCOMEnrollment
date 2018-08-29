
using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//机构表
		public partial class Agency
	{
   		     
		private readonly university.DAL.CCOM.Agency dal=new university.DAL.CCOM.Agency();
		public Agency()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Agency_id)
		{
			return dal.Exists(Agency_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Agency model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Agency model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Agency_id)
		{
			
			return dal.Delete(Agency_id);
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
		public bool DeleteList(string Agency_idlist )
		{
			return dal.DeleteList(Agency_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Agency GetModel(int Agency_id)
		{
			
			return dal.GetModel(Agency_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Agency GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Agency GetModelByCache(int Agency_id)
		{
			
			string CacheKey = "AgencyModel-" + Agency_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Agency_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Agency)objModel;
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
		public List<university.Model.CCOM.Agency> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Agency> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Agency> modelList = new List<university.Model.CCOM.Agency>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Agency model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Agency();					
													if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																				model.Agency_name= dt.Rows[n]["Agency_name"].ToString();
																												if(dt.Rows[n]["Agency_father"].ToString()!="")
				{
					model.Agency_father=int.Parse(dt.Rows[n]["Agency_father"].ToString());
				}
																																if(dt.Rows[n]["Agency_type"].ToString()!="")
				{
					model.Agency_type=int.Parse(dt.Rows[n]["Agency_type"].ToString());
				}
																																																if(dt.Rows[n]["Agency_status"].ToString()!="")
				{
					if((dt.Rows[n]["Agency_status"].ToString()=="1")||(dt.Rows[n]["Agency_status"].ToString().ToLower()=="true"))
					{
					model.Agency_status= true;
					}
					else
					{
					model.Agency_status= false;
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


        public Model.CCOM.Agency GetModel(long Agency_id)
        {
            return dal.GetModel(Agency_id);
        }
    }
}