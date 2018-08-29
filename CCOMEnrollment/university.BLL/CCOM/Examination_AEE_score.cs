using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Examination_AEE_score
		public partial class Examination_AEE_score
	{
   		     
		private readonly university.DAL.CCOM.Examination_AEE_score dal=new university.DAL.CCOM.Examination_AEE_score();
		public Examination_AEE_score()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AEE_id)
		{
			return dal.Exists(AEE_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Examination_AEE_score model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Examination_AEE_score model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AEE_id)
		{
			
			return dal.Delete(AEE_id);
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
		public bool DeleteList(string AEE_idlist )
		{
			return dal.DeleteList(AEE_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_AEE_score GetModel(int AEE_id)
		{
			
			return dal.GetModel(AEE_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_AEE_score GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Examination_AEE_score GetModelByCache(int AEE_id)
		{
			
			string CacheKey = "Examination_AEE_scoreModel-" + AEE_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AEE_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Examination_AEE_score)objModel;
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
		public List<university.Model.CCOM.Examination_AEE_score> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Examination_AEE_score> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Examination_AEE_score> modelList = new List<university.Model.CCOM.Examination_AEE_score>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Examination_AEE_score model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Examination_AEE_score();					
													if(dt.Rows[n]["AEE_id"].ToString()!="")
				{
					model.AEE_id=int.Parse(dt.Rows[n]["AEE_id"].ToString());
				}
																																if(dt.Rows[n]["AEE_score"].ToString()!="")
				{
					model.AEE_score=decimal.Parse(dt.Rows[n]["AEE_score"].ToString());
				}
																																if(dt.Rows[n]["AEE_sequence"].ToString()!="")
				{
					model.AEE_sequence=decimal.Parse(dt.Rows[n]["AEE_sequence"].ToString());
				}
																																if(dt.Rows[n]["AEE_ranking"].ToString()!="")
				{
					model.AEE_ranking=int.Parse(dt.Rows[n]["AEE_ranking"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
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