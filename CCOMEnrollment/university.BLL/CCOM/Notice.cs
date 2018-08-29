using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Notice
		public partial class Notice
	{
   		     
		private readonly university.DAL.CCOM.Notice dal=new university.DAL.CCOM.Notice();
		public Notice()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Notice_id)
		{
			return dal.Exists(Notice_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.Notice model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Notice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Notice_id)
		{
			
			return dal.Delete(Notice_id);
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
		public bool DeleteList(string Notice_idlist )
		{
			return dal.DeleteList(Notice_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice GetModel(long Notice_id)
		{
			
			return dal.GetModel(Notice_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Notice GetModelByCache(long Notice_id)
		{
			
			string CacheKey = "NoticeModel-" + Notice_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Notice_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Notice)objModel;
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
		public List<university.Model.CCOM.Notice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Notice> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Notice> modelList = new List<university.Model.CCOM.Notice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Notice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Notice();					
													if(dt.Rows[n]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(dt.Rows[n]["Notice_id"].ToString());
				}
																																				model.Notice_title= dt.Rows[n]["Notice_title"].ToString();
																																model.Notice_content= dt.Rows[n]["Notice_content"].ToString();
																												if(dt.Rows[n]["Notice_date"].ToString()!="")
				{
					model.Notice_date=DateTime.Parse(dt.Rows[n]["Notice_date"].ToString());
				}
																																if(dt.Rows[n]["Notice_sender_id"].ToString()!="")
				{
					model.Notice_sender_id=long.Parse(dt.Rows[n]["Notice_sender_id"].ToString());
				}
																																				model.Notice_receiver_id= dt.Rows[n]["Notice_receiver_id"].ToString();
																																												if(dt.Rows[n]["Notice_type"].ToString()!="")
				{
					if((dt.Rows[n]["Notice_type"].ToString()=="1")||(dt.Rows[n]["Notice_type"].ToString().ToLower()=="true"))
					{
					model.Notice_type= true;
					}
					else
					{
					model.Notice_type= false;
					}
				}
																				model.Notice_URL= dt.Rows[n]["Notice_URL"].ToString();
																												if(dt.Rows[n]["Notice_type_id"].ToString()!="")
				{
					model.Notice_type_id=long.Parse(dt.Rows[n]["Notice_type_id"].ToString());
				}
																																if(dt.Rows[n]["Notice_last_editor"].ToString()!="")
				{
					model.Notice_last_editor=long.Parse(dt.Rows[n]["Notice_last_editor"].ToString());
				}
																																																if(dt.Rows[n]["Notice_flag"].ToString()!="")
				{
					if((dt.Rows[n]["Notice_flag"].ToString()=="1")||(dt.Rows[n]["Notice_flag"].ToString().ToLower()=="true"))
					{
					model.Notice_flag= true;
					}
					else
					{
					model.Notice_flag= false;
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