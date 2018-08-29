using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Transcript
		public partial class Transcript
	{
   		     
		private readonly university.DAL.CCOM.Transcript dal=new university.DAL.CCOM.Transcript();
		public Transcript()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Transcript_id)
		{
			return dal.Exists(Transcript_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Transcript model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Transcript model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Transcript_id)
		{
			
			return dal.Delete(Transcript_id);
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
		public bool DeleteList(string Transcript_idlist )
		{
			return dal.DeleteList(Transcript_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Transcript GetModel(int Transcript_id)
		{
			
			return dal.GetModel(Transcript_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Transcript GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Transcript GetModelByCache(int Transcript_id)
		{
			
			string CacheKey = "TranscriptModel-" + Transcript_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Transcript_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Transcript)objModel;
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
		public List<university.Model.CCOM.Transcript> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Transcript> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Transcript> modelList = new List<university.Model.CCOM.Transcript>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Transcript model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Transcript();					
													if(dt.Rows[n]["Transcript_id"].ToString()!="")
				{
					model.Transcript_id=int.Parse(dt.Rows[n]["Transcript_id"].ToString());
				}
																																if(dt.Rows[n]["Transcript_AEE_score"].ToString()!="")
				{
					model.Transcript_AEE_score=decimal.Parse(dt.Rows[n]["Transcript_AEE_score"].ToString());
				}
																																if(dt.Rows[n]["Transcript_AEE_sequence"].ToString()!="")
				{
					model.Transcript_AEE_sequence=decimal.Parse(dt.Rows[n]["Transcript_AEE_sequence"].ToString());
				}
																																if(dt.Rows[n]["Transcript_AEE_ranking"].ToString()!="")
				{
					model.Transcript_AEE_ranking=int.Parse(dt.Rows[n]["Transcript_AEE_ranking"].ToString());
				}
																																if(dt.Rows[n]["Transcript_CEE_score"].ToString()!="")
				{
					model.Transcript_CEE_score=decimal.Parse(dt.Rows[n]["Transcript_CEE_score"].ToString());
				}
																																if(dt.Rows[n]["Transcript_CEE_convert_score"].ToString()!="")
				{
					model.Transcript_CEE_convert_score=decimal.Parse(dt.Rows[n]["Transcript_CEE_convert_score"].ToString());
				}
																																																if(dt.Rows[n]["Transcript_passline"].ToString()!="")
				{
					if((dt.Rows[n]["Transcript_passline"].ToString()=="1")||(dt.Rows[n]["Transcript_passline"].ToString().ToLower()=="true"))
					{
					model.Transcript_passline= true;
					}
					else
					{
					model.Transcript_passline= false;
					}
				}
																if(dt.Rows[n]["Transcript_type"].ToString()!="")
				{
					model.Transcript_type=int.Parse(dt.Rows[n]["Transcript_type"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["Transcript_score"].ToString()!="")
				{
					model.Transcript_score=decimal.Parse(dt.Rows[n]["Transcript_score"].ToString());
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