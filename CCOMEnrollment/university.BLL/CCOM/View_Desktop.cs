using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_Desktop
		public partial class View_Desktop
	{
   		     
		private readonly university.DAL.CCOM.View_Desktop dal=new university.DAL.CCOM.View_Desktop();
		public View_Desktop()
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
		public void  Add(university.Model.CCOM.View_Desktop model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Desktop model)
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
		public university.Model.CCOM.View_Desktop GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_Desktop GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_Desktop GetModelByCache()
		{
			
			string CacheKey = "View_DesktopModel-" + ;
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
			return (university.Model.CCOM.View_Desktop)objModel;
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
		public List<university.Model.CCOM.View_Desktop> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_Desktop> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_Desktop> modelList = new List<university.Model.CCOM.View_Desktop>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_Desktop model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_Desktop();					
													if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Sf_id"].ToString()!="")
				{
					model.Sf_id=int.Parse(dt.Rows[n]["Sf_id"].ToString());
				}
																																				model.Sf_url= dt.Rows[n]["Sf_url"].ToString();
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
																if(dt.Rows[n]["Ufd_type"].ToString()!="")
				{
					model.Ufd_type=int.Parse(dt.Rows[n]["Ufd_type"].ToString());
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