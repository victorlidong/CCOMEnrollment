using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Exam_preliminary_subject
		public partial class Exam_preliminary_subject
	{
   		     
		private readonly university.DAL.CCOM.Exam_preliminary_subject dal=new university.DAL.CCOM.Exam_preliminary_subject();
		public Exam_preliminary_subject()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Eps_id)
		{
			return dal.Exists(Eps_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Exam_preliminary_subject model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Exam_preliminary_subject model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Eps_id)
		{
			
			return dal.Delete(Eps_id);
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
		public bool DeleteList(string Eps_idlist )
		{
			return dal.DeleteList(Eps_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Exam_preliminary_subject GetModel(int Eps_id)
		{
			
			return dal.GetModel(Eps_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Exam_preliminary_subject GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Exam_preliminary_subject GetModelByCache(int Eps_id)
		{
			
			string CacheKey = "Exam_preliminary_subjectModel-" + Eps_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Eps_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Exam_preliminary_subject)objModel;
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
		public List<university.Model.CCOM.Exam_preliminary_subject> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Exam_preliminary_subject> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Exam_preliminary_subject> modelList = new List<university.Model.CCOM.Exam_preliminary_subject>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Exam_preliminary_subject model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Exam_preliminary_subject();					
													if(dt.Rows[n]["Eps_id"].ToString()!="")
				{
					model.Eps_id=int.Parse(dt.Rows[n]["Eps_id"].ToString());
				}
																																if(dt.Rows[n]["Major_id"].ToString()!="")
				{
					model.Major_id=int.Parse(dt.Rows[n]["Major_id"].ToString());
				}
																																if(dt.Rows[n]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(dt.Rows[n]["Esn_id"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
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