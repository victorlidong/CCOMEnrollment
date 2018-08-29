using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Exam_preliminary_subject_score
		public partial class Exam_preliminary_subject_score
	{
   		     
		private readonly university.DAL.CCOM.Exam_preliminary_subject_score dal=new university.DAL.CCOM.Exam_preliminary_subject_score();
		public Exam_preliminary_subject_score()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Epss)
		{
			return dal.Exists(Epss);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Exam_preliminary_subject_score model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Exam_preliminary_subject_score model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Epss)
		{
			
			return dal.Delete(Epss);
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
		public bool DeleteList(string Epsslist )
		{
			return dal.DeleteList(Epsslist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Exam_preliminary_subject_score GetModel(int Epss)
		{
			
			return dal.GetModel(Epss);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Exam_preliminary_subject_score GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Exam_preliminary_subject_score GetModelByCache(int Epss)
		{
			
			string CacheKey = "Exam_preliminary_subject_scoreModel-" + Epss;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Epss);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Exam_preliminary_subject_score)objModel;
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
		public List<university.Model.CCOM.Exam_preliminary_subject_score> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Exam_preliminary_subject_score> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Exam_preliminary_subject_score> modelList = new List<university.Model.CCOM.Exam_preliminary_subject_score>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Exam_preliminary_subject_score model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Exam_preliminary_subject_score();					
													if(dt.Rows[n]["Epss"].ToString()!="")
				{
					model.Epss=int.Parse(dt.Rows[n]["Epss"].ToString());
				}
																																if(dt.Rows[n]["Eps_id"].ToString()!="")
				{
					model.Eps_id=int.Parse(dt.Rows[n]["Eps_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Epss_score"].ToString()!="")
				{
					model.Epss_score=decimal.Parse(dt.Rows[n]["Epss_score"].ToString());
				}
																																if(dt.Rows[n]["Epss_sequence"].ToString()!="")
				{
					model.Epss_sequence=decimal.Parse(dt.Rows[n]["Epss_sequence"].ToString());
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