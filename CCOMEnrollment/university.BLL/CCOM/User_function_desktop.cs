using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//User_function_desktop
		public partial class User_function_desktop
	{
   		     
		private readonly university.DAL.CCOM.User_function_desktop dal=new university.DAL.CCOM.User_function_desktop();
		public User_function_desktop()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Ufd_id)
		{
			return dal.Exists(Ufd_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.User_function_desktop model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_function_desktop model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Ufd_id)
		{
			
			return dal.Delete(Ufd_id);
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
		public bool DeleteList(string Ufd_idlist )
		{
			return dal.DeleteList(Ufd_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_function_desktop GetModel(int Ufd_id)
		{
			
			return dal.GetModel(Ufd_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_function_desktop GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_function_desktop GetModelByCache(int Ufd_id)
		{
			
			string CacheKey = "User_function_desktopModel-" + Ufd_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Ufd_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_function_desktop)objModel;
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
		public List<university.Model.CCOM.User_function_desktop> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_function_desktop> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_function_desktop> modelList = new List<university.Model.CCOM.User_function_desktop>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_function_desktop model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_function_desktop();					
													if(dt.Rows[n]["Ufd_id"].ToString()!="")
				{
					model.Ufd_id=int.Parse(dt.Rows[n]["Ufd_id"].ToString());
				}
																																if(dt.Rows[n]["Ufd_type"].ToString()!="")
				{
					model.Ufd_type=int.Parse(dt.Rows[n]["Ufd_type"].ToString());
				}
																																if(dt.Rows[n]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(dt.Rows[n]["Sf_id"].ToString());
				}
																																if(dt.Rows[n]["Ufd_sort"].ToString()!="")
				{
					model.Ufd_sort=int.Parse(dt.Rows[n]["Ufd_sort"].ToString());
				}
																																				model.Ufd_name= dt.Rows[n]["Ufd_name"].ToString();
																																model.Ufd_showname= dt.Rows[n]["Ufd_showname"].ToString();
																																model.Ufd_icon= dt.Rows[n]["Ufd_icon"].ToString();
																																model.Ufd_width= dt.Rows[n]["Ufd_width"].ToString();
																																model.Ufd_color= dt.Rows[n]["Ufd_color"].ToString();
																																model.Ufd_remark= dt.Rows[n]["Ufd_remark"].ToString();
																						
				
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