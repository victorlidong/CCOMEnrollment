using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Subject
		public partial class Subject
	{
   		     
		private readonly university.DAL.CCOM.Subject dal=new university.DAL.CCOM.Subject();
		public Subject()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Subject_id)
		{
			return dal.Exists(Subject_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Subject model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Subject model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Subject_id)
		{
			
			return dal.Delete(Subject_id);
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
		public bool DeleteList(string Subject_idlist )
		{
			return dal.DeleteList(Subject_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Subject GetModel(int Subject_id)
		{
			
			return dal.GetModel(Subject_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Subject GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Subject GetModelByCache(int Subject_id)
		{
			
			string CacheKey = "SubjectModel-" + Subject_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Subject_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Subject)objModel;
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
		public List<university.Model.CCOM.Subject> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Subject> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Subject> modelList = new List<university.Model.CCOM.Subject>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Subject model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Subject();					
													if(dt.Rows[n]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(dt.Rows[n]["Subject_id"].ToString());
				}
																																				model.Subject_title= dt.Rows[n]["Subject_title"].ToString();
																																												if(dt.Rows[n]["Subject_type"].ToString()!="")
				{
					if((dt.Rows[n]["Subject_type"].ToString()=="1")||(dt.Rows[n]["Subject_type"].ToString().ToLower()=="true"))
					{
					model.Subject_type= true;
					}
					else
					{
					model.Subject_type= false;
					}
				}
																if(dt.Rows[n]["Value_type"].ToString()!="")
				{
					model.Value_type=int.Parse(dt.Rows[n]["Value_type"].ToString());
				}
																																if(dt.Rows[n]["Value_count"].ToString()!="")
				{
					model.Value_count=int.Parse(dt.Rows[n]["Value_count"].ToString());
				}
																																if(dt.Rows[n]["Manage_Agency_id"].ToString()!="")
				{
					model.Manage_Agency_id=int.Parse(dt.Rows[n]["Manage_Agency_id"].ToString());
				}
																																if(dt.Rows[n]["Major_Agency_id"].ToString()!="")
				{
					model.Major_Agency_id=int.Parse(dt.Rows[n]["Major_Agency_id"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["Subject_weight"].ToString()!="")
				{
					model.Subject_weight=decimal.Parse(dt.Rows[n]["Subject_weight"].ToString());
				}
																																if(dt.Rows[n]["Subject_level"].ToString()!="")
				{
					model.Subject_level=int.Parse(dt.Rows[n]["Subject_level"].ToString());
				}
																																				model.Subject_description= dt.Rows[n]["Subject_description"].ToString();
																												if(dt.Rows[n]["Fs_id"].ToString()!="")
				{
					model.Fs_id=int.Parse(dt.Rows[n]["Fs_id"].ToString());
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