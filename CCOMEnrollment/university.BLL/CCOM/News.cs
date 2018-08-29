using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//News
		public partial class News
	{
   		     
		private readonly university.DAL.CCOM.News dal=new university.DAL.CCOM.News();
		public News()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int News_id)
		{
			return dal.Exists(News_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.News model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.News model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int News_id)
		{
			
			return dal.Delete(News_id);
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
		public bool DeleteList(string News_idlist )
		{
			return dal.DeleteList(News_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.News GetModel(int News_id)
		{
			
			return dal.GetModel(News_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.News GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.News GetModelByCache(int News_id)
		{
			
			string CacheKey = "NewsModel-" + News_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(News_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.News)objModel;
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
		public List<university.Model.CCOM.News> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.News> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.News> modelList = new List<university.Model.CCOM.News>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.News model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.News();					
													if(dt.Rows[n]["News_id"].ToString()!="")
				{
					model.News_id=int.Parse(dt.Rows[n]["News_id"].ToString());
				}
																																if(dt.Rows[n]["News_type_id"].ToString()!="")
				{
					model.News_type_id=int.Parse(dt.Rows[n]["News_type_id"].ToString());
				}
																																				model.News_title= dt.Rows[n]["News_title"].ToString();
																												if(dt.Rows[n]["News_creator_id"].ToString()!="")
				{
					model.News_creator_id=int.Parse(dt.Rows[n]["News_creator_id"].ToString());
				}
																																				model.News_content= dt.Rows[n]["News_content"].ToString();
																												if(dt.Rows[n]["News_date"].ToString()!="")
				{
					model.News_date=DateTime.Parse(dt.Rows[n]["News_date"].ToString());
				}
																																				model.News_URL= dt.Rows[n]["News_URL"].ToString();
																												if(dt.Rows[n]["News_readnumber"].ToString()!="")
				{
					model.News_readnumber=int.Parse(dt.Rows[n]["News_readnumber"].ToString());
				}
																																if(dt.Rows[n]["News_last_editor"].ToString()!="")
				{
					model.News_last_editor=int.Parse(dt.Rows[n]["News_last_editor"].ToString());
				}
																																																if(dt.Rows[n]["News_top"].ToString()!="")
				{
					if((dt.Rows[n]["News_top"].ToString()=="1")||(dt.Rows[n]["News_top"].ToString().ToLower()=="true"))
					{
					model.News_top= true;
					}
					else
					{
					model.News_top= false;
					}
				}
																if(dt.Rows[n]["News_top_time"].ToString()!="")
				{
					model.News_top_time=int.Parse(dt.Rows[n]["News_top_time"].ToString());
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