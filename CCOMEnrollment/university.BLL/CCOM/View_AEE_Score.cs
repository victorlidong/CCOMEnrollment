using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_AEE_Score
		public partial class View_AEE_Score
	{
   		     
		private readonly university.DAL.CCOM.View_AEE_Score dal=new university.DAL.CCOM.View_AEE_Score();
		public View_AEE_Score()
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
		public void  Add(university.Model.CCOM.View_AEE_Score model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_AEE_Score model)
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
		public university.Model.CCOM.View_AEE_Score GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_AEE_Score GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_AEE_Score GetModelByCache()
		{
			
			string CacheKey = "View_AEE_ScoreModel-" + ;
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
			return (university.Model.CCOM.View_AEE_Score)objModel;
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
		public List<university.Model.CCOM.View_AEE_Score> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_AEE_Score> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_AEE_Score> modelList = new List<university.Model.CCOM.View_AEE_Score>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_AEE_Score model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_AEE_Score();					
													if(dt.Rows[n]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(dt.Rows[n]["UP_calculation_status"].ToString());
				}
																																				model.UP_CCOM_number= dt.Rows[n]["UP_CCOM_number"].ToString();
																												if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																				model.User_realname= dt.Rows[n]["User_realname"].ToString();
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