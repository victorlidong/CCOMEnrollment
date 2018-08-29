using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_AEE_ManegeSubject
		public partial class View_AEE_ManegeSubject
	{
   		     
		private readonly university.DAL.CCOM.View_AEE_ManegeSubject dal=new university.DAL.CCOM.View_AEE_ManegeSubject();
		public View_AEE_ManegeSubject()
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
		public void  Add(university.Model.CCOM.View_AEE_ManegeSubject model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_AEE_ManegeSubject model)
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
		public university.Model.CCOM.View_AEE_ManegeSubject GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_AEE_ManegeSubject GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_AEE_ManegeSubject GetModelByCache()
		{
			
			string CacheKey = "View_AEE_ManegeSubjectModel-" + ;
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
			return (university.Model.CCOM.View_AEE_ManegeSubject)objModel;
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
		public List<university.Model.CCOM.View_AEE_ManegeSubject> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_AEE_ManegeSubject> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_AEE_ManegeSubject> modelList = new List<university.Model.CCOM.View_AEE_ManegeSubject>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_AEE_ManegeSubject model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_AEE_ManegeSubject();					
													if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(dt.Rows[n]["Subject_id"].ToString());
				}
																																				model.Subject_title= dt.Rows[n]["Subject_title"].ToString();
																												if(dt.Rows[n]["Subject_level"].ToString()!="")
				{
					model.Subject_level=int.Parse(dt.Rows[n]["Subject_level"].ToString());
				}
																																if(dt.Rows[n]["Major_Agency_id"].ToString()!="")
				{
					model.Major_Agency_id=int.Parse(dt.Rows[n]["Major_Agency_id"].ToString());
				}
																																if(dt.Rows[n]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(dt.Rows[n]["Ea_id"].ToString());
				}
																																if(dt.Rows[n]["Manage_Agency_id"].ToString()!="")
				{
					model.Manage_Agency_id=int.Parse(dt.Rows[n]["Manage_Agency_id"].ToString());
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