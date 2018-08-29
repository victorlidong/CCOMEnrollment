using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_FirstIn_Score
		public partial class View_FirstIn_Score
	{
   		     
		private readonly university.DAL.CCOM.View_FirstIn_Score dal=new university.DAL.CCOM.View_FirstIn_Score();
		public View_FirstIn_Score()
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
		public void  Add(university.Model.CCOM.View_FirstIn_Score model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_FirstIn_Score model)
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
		public university.Model.CCOM.View_FirstIn_Score GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_FirstIn_Score GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_FirstIn_Score GetModelByCache()
		{
			
			string CacheKey = "View_FirstIn_ScoreModel-" + ;
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
			return (university.Model.CCOM.View_FirstIn_Score)objModel;
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
		public List<university.Model.CCOM.View_FirstIn_Score> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_FirstIn_Score> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_FirstIn_Score> modelList = new List<university.Model.CCOM.View_FirstIn_Score>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_FirstIn_Score model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_FirstIn_Score();					
																	model.UP_CCOM_number= dt.Rows[n]["UP_CCOM_number"].ToString();
																												if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																				model.User_realname= dt.Rows[n]["User_realname"].ToString();
																												if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(dt.Rows[n]["Subject_id"].ToString());
				}
																																				model.Subject_title= dt.Rows[n]["Subject_title"].ToString();
																												if(dt.Rows[n]["Major_id"].ToString()!="")
				{
					model.Major_id=int.Parse(dt.Rows[n]["Major_id"].ToString());
				}
																																if(dt.Rows[n]["Efss_score"].ToString()!="")
				{
					model.Efss_score=decimal.Parse(dt.Rows[n]["Efss_score"].ToString());
				}
																																if(dt.Rows[n]["Efss_sequence"].ToString()!="")
				{
					model.Efss_sequence=decimal.Parse(dt.Rows[n]["Efss_sequence"].ToString());
				}
																																if(dt.Rows[n]["UP_calculation_status"].ToString()!="")
				{
					model.UP_calculation_status=int.Parse(dt.Rows[n]["UP_calculation_status"].ToString());
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