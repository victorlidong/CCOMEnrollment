using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Examination_CEE_score
		public partial class Examination_CEE_score
	{
   		     
		private readonly university.DAL.CCOM.Examination_CEE_score dal=new university.DAL.CCOM.Examination_CEE_score();
		public Examination_CEE_score()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CEE_id)
		{
			return dal.Exists(CEE_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Examination_CEE_score model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Examination_CEE_score model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CEE_id)
		{
			
			return dal.Delete(CEE_id);
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
		public bool DeleteList(string CEE_idlist )
		{
			return dal.DeleteList(CEE_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_CEE_score GetModel(int CEE_id)
		{
			
			return dal.GetModel(CEE_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_CEE_score GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Examination_CEE_score GetModelByCache(int CEE_id)
		{
			
			string CacheKey = "Examination_CEE_scoreModel-" + CEE_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CEE_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Examination_CEE_score)objModel;
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
		public List<university.Model.CCOM.Examination_CEE_score> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Examination_CEE_score> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Examination_CEE_score> modelList = new List<university.Model.CCOM.Examination_CEE_score>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Examination_CEE_score model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Examination_CEE_score();					
													if(dt.Rows[n]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(dt.Rows[n]["CEE_id"].ToString());
				}
																																if(dt.Rows[n]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(dt.Rows[n]["CEE_Chinese_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(dt.Rows[n]["CEE_Math_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(dt.Rows[n]["CEE_English_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(dt.Rows[n]["CEE_comprehensive_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(dt.Rows[n]["CEE_extra_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(dt.Rows[n]["CEE_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(dt.Rows[n]["CEE_type"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																																if(dt.Rows[n]["CEE_status"].ToString()!="")
				{
					if((dt.Rows[n]["CEE_status"].ToString()=="1")||(dt.Rows[n]["CEE_status"].ToString().ToLower()=="true"))
					{
					model.CEE_status= true;
					}
					else
					{
					model.CEE_status= false;
					}
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