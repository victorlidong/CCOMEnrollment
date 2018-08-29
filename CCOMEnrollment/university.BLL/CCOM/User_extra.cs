using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//User_extra
		public partial class User_extra
	{
   		     
		private readonly university.DAL.CCOM.User_extra dal=new university.DAL.CCOM.User_extra();
		public User_extra()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Ue_id)
		{
			return dal.Exists(Ue_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.User_extra model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_extra model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Ue_id)
		{
			
			return dal.Delete(Ue_id);
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
		public bool DeleteList(string Ue_idlist )
		{
			return dal.DeleteList(Ue_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_extra GetModel(int Ue_id)
		{
			
			return dal.GetModel(Ue_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_extra GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_extra GetModelByCache(int Ue_id)
		{
			
			string CacheKey = "User_extraModel-" + Ue_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Ue_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_extra)objModel;
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
		public List<university.Model.CCOM.User_extra> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_extra> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_extra> modelList = new List<university.Model.CCOM.User_extra>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_extra model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_extra();					
													if(dt.Rows[n]["Ue_id"].ToString()!="")
				{
					model.Ue_id=int.Parse(dt.Rows[n]["Ue_id"].ToString());
				}
																																				model.Ue_name= dt.Rows[n]["Ue_name"].ToString();
																												if(dt.Rows[n]["Ue_type"].ToString()!="")
				{
					model.Ue_type=int.Parse(dt.Rows[n]["Ue_type"].ToString());
				}
																																																if(dt.Rows[n]["Ue_null"].ToString()!="")
				{
					if((dt.Rows[n]["Ue_null"].ToString()=="1")||(dt.Rows[n]["Ue_null"].ToString().ToLower()=="true"))
					{
					model.Ue_null= true;
					}
					else
					{
					model.Ue_null= false;
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