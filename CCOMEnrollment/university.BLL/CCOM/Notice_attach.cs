using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Notice_attach
		public partial class Notice_attach
	{
   		     
		private readonly university.DAL.CCOM.Notice_attach dal=new university.DAL.CCOM.Notice_attach();
		public Notice_attach()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Notice_attach_id)
		{
			return dal.Exists(Notice_attach_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.Notice_attach model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Notice_attach model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Notice_attach_id)
		{
			
			return dal.Delete(Notice_attach_id);
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
		public bool DeleteList(string Notice_attach_idlist )
		{
			return dal.DeleteList(Notice_attach_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice_attach GetModel(long Notice_attach_id)
		{
			
			return dal.GetModel(Notice_attach_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice_attach GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Notice_attach GetModelByCache(long Notice_attach_id)
		{
			
			string CacheKey = "Notice_attachModel-" + Notice_attach_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Notice_attach_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Notice_attach)objModel;
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
		public List<university.Model.CCOM.Notice_attach> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Notice_attach> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Notice_attach> modelList = new List<university.Model.CCOM.Notice_attach>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Notice_attach model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Notice_attach();					
													if(dt.Rows[n]["Notice_attach_id"].ToString()!="")
				{
					model.Notice_attach_id=long.Parse(dt.Rows[n]["Notice_attach_id"].ToString());
				}
																																if(dt.Rows[n]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(dt.Rows[n]["Notice_id"].ToString());
				}
																																				model.Notice_attach_name= dt.Rows[n]["Notice_attach_name"].ToString();
																																model.Notice_attach_address= dt.Rows[n]["Notice_attach_address"].ToString();
																						
				
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