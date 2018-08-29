using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Judge
		public partial class Judge
	{
   		     
		private readonly university.DAL.CCOM.Judge dal=new university.DAL.CCOM.Judge();
		public Judge()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int Judge_id)
		{
			return dal.Exists(Judge_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Judge model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Judge model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Judge_id)
		{
			
			return dal.Delete(Judge_id);
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
		public bool DeleteList(string Judge_idlist )
		{
			return dal.DeleteList(Judge_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Judge GetModel(int Judge_id)
		{
			
			return dal.GetModel(Judge_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Judge GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Judge GetModelByCache(int Judge_id)
		{
			
			string CacheKey = "JudgeModel-" + Judge_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Judge_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Judge)objModel;
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
		public List<university.Model.CCOM.Judge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Judge> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Judge> modelList = new List<university.Model.CCOM.Judge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Judge model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Judge();					
													if(dt.Rows[n]["Judge_id"].ToString()!="")
				{
					model.Judge_id=int.Parse(dt.Rows[n]["Judge_id"].ToString());
				}
																																				model.Judge_name= dt.Rows[n]["Judge_name"].ToString();
																																model.Judge_staff_number= dt.Rows[n]["Judge_staff_number"].ToString();
																																model.Judge_department= dt.Rows[n]["Judge_department"].ToString();
																																model.Judge_title= dt.Rows[n]["Judge_title"].ToString();
																						
				
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