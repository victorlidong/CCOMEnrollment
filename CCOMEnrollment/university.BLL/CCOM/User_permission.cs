using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//用户权限对应表
		public partial class User_permission
	{
   		     
		private readonly university.DAL.CCOM.User_permission dal=new university.DAL.CCOM.User_permission();
		public User_permission()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Upe_id)
		{
			return dal.Exists(Upe_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.User_permission model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_permission model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Upe_id)
		{
			
			return dal.Delete(Upe_id);
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
		public bool DeleteList(string Upe_idlist )
		{
			return dal.DeleteList(Upe_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_permission GetModel(long Upe_id)
		{
			
			return dal.GetModel(Upe_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_permission GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_permission GetModelByCache(long Upe_id)
		{
			
			string CacheKey = "User_permissionModel-" + Upe_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Upe_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_permission)objModel;
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
		public List<university.Model.CCOM.User_permission> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_permission> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_permission> modelList = new List<university.Model.CCOM.User_permission>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_permission model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_permission();					
													if(dt.Rows[n]["Upe_id"].ToString()!="")
				{
					model.Upe_id=long.Parse(dt.Rows[n]["Upe_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(dt.Rows[n]["Sf_id"].ToString());
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