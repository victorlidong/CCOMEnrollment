using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Notice_type
		public partial class Notice_type
	{
   		     
		private readonly university.DAL.CCOM.Notice_type dal=new university.DAL.CCOM.Notice_type();
		public Notice_type()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Notice_type_id)
		{
			return dal.Exists(Notice_type_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.Notice_type model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Notice_type model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Notice_type_id)
		{
			
			return dal.Delete(Notice_type_id);
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
		public bool DeleteList(string Notice_type_idlist )
		{
			return dal.DeleteList(Notice_type_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice_type GetModel(long Notice_type_id)
		{
			
			return dal.GetModel(Notice_type_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Notice_type GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Notice_type GetModelByCache(long Notice_type_id)
		{
			
			string CacheKey = "Notice_typeModel-" + Notice_type_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Notice_type_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Notice_type)objModel;
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
		public List<university.Model.CCOM.Notice_type> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Notice_type> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Notice_type> modelList = new List<university.Model.CCOM.Notice_type>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Notice_type model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Notice_type();					
													if(dt.Rows[n]["Notice_type_id"].ToString()!="")
				{
					model.Notice_type_id=long.Parse(dt.Rows[n]["Notice_type_id"].ToString());
				}
																																				model.Notice_type_name= dt.Rows[n]["Notice_type_name"].ToString();
																												if(dt.Rows[n]["Notice_type_creator_id"].ToString()!="")
				{
					model.Notice_type_creator_id=long.Parse(dt.Rows[n]["Notice_type_creator_id"].ToString());
				}
																																if(dt.Rows[n]["Notice_type_date"].ToString()!="")
				{
					model.Notice_type_date=DateTime.Parse(dt.Rows[n]["Notice_type_date"].ToString());
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