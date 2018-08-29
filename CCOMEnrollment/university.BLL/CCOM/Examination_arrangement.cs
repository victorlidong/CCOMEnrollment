using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Examination_arrangement
		public partial class Examination_arrangement
	{
   		     
		private readonly university.DAL.CCOM.Examination_arrangement dal=new university.DAL.CCOM.Examination_arrangement();
		public Examination_arrangement()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Ea_id)
		{
			return dal.Exists(Ea_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Examination_arrangement model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Examination_arrangement model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Ea_id)
		{
			
			return dal.Delete(Ea_id);
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
		public bool DeleteList(string Ea_idlist )
		{
			return dal.DeleteList(Ea_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_arrangement GetModel(int Ea_id)
		{
			
			return dal.GetModel(Ea_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_arrangement GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Examination_arrangement GetModelByCache(int Ea_id)
		{
			
			string CacheKey = "Examination_arrangementModel-" + Ea_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Ea_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Examination_arrangement)objModel;
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
		public List<university.Model.CCOM.Examination_arrangement> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Examination_arrangement> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Examination_arrangement> modelList = new List<university.Model.CCOM.Examination_arrangement>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Examination_arrangement model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Examination_arrangement();					
													if(dt.Rows[n]["Ea_id"].ToString()!="")
				{
					model.Ea_id=int.Parse(dt.Rows[n]["Ea_id"].ToString());
				}
																																				model.Ea_name= dt.Rows[n]["Ea_name"].ToString();
																												if(dt.Rows[n]["Ea_starttime"].ToString()!="")
				{
					model.Ea_starttime=DateTime.Parse(dt.Rows[n]["Ea_starttime"].ToString());
				}
																																if(dt.Rows[n]["Ea_endtime"].ToString()!="")
				{
					model.Ea_endtime=DateTime.Parse(dt.Rows[n]["Ea_endtime"].ToString());
				}
																																if(dt.Rows[n]["Ea_room"].ToString()!="")
				{
					model.Ea_room=int.Parse(dt.Rows[n]["Ea_room"].ToString());
				}
																																if(dt.Rows[n]["Ea_restroom"].ToString()!="")
				{
					model.Ea_restroom=int.Parse(dt.Rows[n]["Ea_restroom"].ToString());
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