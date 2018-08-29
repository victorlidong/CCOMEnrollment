using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Examination_subject_nature
		public partial class Examination_subject_nature
	{
   		     
		private readonly university.DAL.CCOM.Examination_subject_nature dal=new university.DAL.CCOM.Examination_subject_nature();
		public Examination_subject_nature()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Esn_id)
		{
			return dal.Exists(Esn_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Examination_subject_nature model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Examination_subject_nature model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Esn_id)
		{
			
			return dal.Delete(Esn_id);
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
		public bool DeleteList(string Esn_idlist )
		{
			return dal.DeleteList(Esn_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_subject_nature GetModel(int Esn_id)
		{
			
			return dal.GetModel(Esn_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Examination_subject_nature GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Examination_subject_nature GetModelByCache(int Esn_id)
		{
			
			string CacheKey = "Examination_subject_natureModel-" + Esn_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Esn_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Examination_subject_nature)objModel;
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
		public List<university.Model.CCOM.Examination_subject_nature> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Examination_subject_nature> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Examination_subject_nature> modelList = new List<university.Model.CCOM.Examination_subject_nature>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Examination_subject_nature model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Examination_subject_nature();					
													if(dt.Rows[n]["Esn_id"].ToString()!="")
				{
					model.Esn_id=int.Parse(dt.Rows[n]["Esn_id"].ToString());
				}
																																				model.Esn_title= dt.Rows[n]["Esn_title"].ToString();
																																model.Esn_content= dt.Rows[n]["Esn_content"].ToString();
																																												if(dt.Rows[n]["Esn_type"].ToString()!="")
				{
					if((dt.Rows[n]["Esn_type"].ToString()=="1")||(dt.Rows[n]["Esn_type"].ToString().ToLower()=="true"))
					{
					model.Esn_type= true;
					}
					else
					{
					model.Esn_type= false;
					}
				}
																																if(dt.Rows[n]["Esn_instrument_status"].ToString()!="")
				{
					if((dt.Rows[n]["Esn_instrument_status"].ToString()=="1")||(dt.Rows[n]["Esn_instrument_status"].ToString().ToLower()=="true"))
					{
					model.Esn_instrument_status= true;
					}
					else
					{
					model.Esn_instrument_status= false;
					}
				}
																if(dt.Rows[n]["Esn_Mi_id"].ToString()!="")
				{
					model.Esn_Mi_id=int.Parse(dt.Rows[n]["Esn_Mi_id"].ToString());
				}
																																if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
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