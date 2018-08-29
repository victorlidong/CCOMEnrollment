using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Examination_room
		public partial class Examination_room
	{
   		     
		private readonly university.DAL.CCOM.Examination_room dal=new university.DAL.CCOM.Examination_room();
		public Examination_room()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Er_id)
		{
			return dal.Exists(Er_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Examination_room model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Examination_room model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Er_id)
		{
			
			return dal.Delete(Er_id);
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
		public bool DeleteList(string Er_idlist )
		{
			return dal.DeleteList(Er_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_room GetModel(int Er_id)
		{
			
			return dal.GetModel(Er_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_room GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Examination_room GetModelByCache(int Er_id)
		{
			
			string CacheKey = "Examination_roomModel-" + Er_id;
			object objModel = university.Model.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Er_id);
					if (objModel != null)
					{
						int ModelCache = university.Model.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Model.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Examination_room)objModel;
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
		public List<university.Model.CCOM.Examination_room> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Examination_room> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Examination_room> modelList = new List<university.Model.CCOM.Examination_room>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Examination_room model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Examination_room();					
													if(dt.Rows[n]["Er_id"].ToString()!="")
				{
					model.Er_id=int.Parse(dt.Rows[n]["Er_id"].ToString());
				}
																																				model.Er_building= dt.Rows[n]["Er_building"].ToString();
																												if(dt.Rows[n]["Er_floor"].ToString()!="")
				{
					model.Er_floor=int.Parse(dt.Rows[n]["Er_floor"].ToString());
				}
																																				model.Er_room= dt.Rows[n]["Er_room"].ToString();
																												if(dt.Rows[n]["Er_capacity"].ToString()!="")
				{
					model.Er_capacity=int.Parse(dt.Rows[n]["Er_capacity"].ToString());
				}
																																				model.Er_remark= dt.Rows[n]["Er_remark"].ToString();
																						
				
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