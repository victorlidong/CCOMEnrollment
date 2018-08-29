using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_User_CEE
		public partial class View_User_CEE
	{
   		     
		private readonly university.DAL.CCOM.View_User_CEE dal=new university.DAL.CCOM.View_User_CEE();
		public View_User_CEE()
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
		public void  Add(university.Model.CCOM.View_User_CEE model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_User_CEE model)
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
		public university.Model.CCOM.View_User_CEE GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_User_CEE GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_User_CEE GetModelByCache()
		{
			
			string CacheKey = "View_User_CEEModel-" + ;
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
			return (university.Model.CCOM.View_User_CEE)objModel;
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
		public List<university.Model.CCOM.View_User_CEE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_User_CEE> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_User_CEE> modelList = new List<university.Model.CCOM.View_User_CEE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_User_CEE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_User_CEE();					
													if(dt.Rows[n]["CEE_extra_score"].ToString()!="")
				{
					model.CEE_extra_score=decimal.Parse(dt.Rows[n]["CEE_extra_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_comprehensive_score"].ToString()!="")
				{
					model.CEE_comprehensive_score=decimal.Parse(dt.Rows[n]["CEE_comprehensive_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_score"].ToString()!="")
				{
					model.CEE_score=decimal.Parse(dt.Rows[n]["CEE_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_type"].ToString()!="")
				{
					model.CEE_type=int.Parse(dt.Rows[n]["CEE_type"].ToString());
				}
																																if(dt.Rows[n]["CEE_English_score"].ToString()!="")
				{
					model.CEE_English_score=decimal.Parse(dt.Rows[n]["CEE_English_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_Math_score"].ToString()!="")
				{
					model.CEE_Math_score=decimal.Parse(dt.Rows[n]["CEE_Math_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_Chinese_score"].ToString()!="")
				{
					model.CEE_Chinese_score=decimal.Parse(dt.Rows[n]["CEE_Chinese_score"].ToString());
				}
																																if(dt.Rows[n]["CEE_id"].ToString()!="")
				{
					model.CEE_id=int.Parse(dt.Rows[n]["CEE_id"].ToString());
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
																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["UP_province"].ToString()!="")
				{
					model.UP_province=int.Parse(dt.Rows[n]["UP_province"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																				model.UP_CCOM_number= dt.Rows[n]["UP_CCOM_number"].ToString();
																																model.User_realname= dt.Rows[n]["User_realname"].ToString();
																												if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																				model.UP_CEE_number= dt.Rows[n]["UP_CEE_number"].ToString();
																						
				
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