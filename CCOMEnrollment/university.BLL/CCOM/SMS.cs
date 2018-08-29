using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//SMS
		public partial class SMS
	{
   		     
		private readonly university.DAL.CCOM.SMS dal=new university.DAL.CCOM.SMS();
		public SMS()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long SMS_id)
		{
			return dal.Exists(SMS_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.SMS model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.SMS model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long SMS_id)
		{
			
			return dal.Delete(SMS_id);
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
		public bool DeleteList(string SMS_idlist )
		{
			return dal.DeleteList(SMS_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.SMS GetModel(long SMS_id)
		{
			
			return dal.GetModel(SMS_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.SMS GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.SMS GetModelByCache(long SMS_id)
		{
			
			string CacheKey = "SMSModel-" + SMS_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SMS_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.SMS)objModel;
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
		public List<university.Model.CCOM.SMS> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.SMS> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.SMS> modelList = new List<university.Model.CCOM.SMS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.SMS model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.SMS();					
													if(dt.Rows[n]["SMS_id"].ToString()!="")
				{
					model.SMS_id=long.Parse(dt.Rows[n]["SMS_id"].ToString());
				}
																																if(dt.Rows[n]["Notice_id"].ToString()!="")
				{
					model.Notice_id=long.Parse(dt.Rows[n]["Notice_id"].ToString());
				}
																																if(dt.Rows[n]["SMS_sender_id"].ToString()!="")
				{
					model.SMS_sender_id=long.Parse(dt.Rows[n]["SMS_sender_id"].ToString());
				}
																																				model.SMS_receiver_id= dt.Rows[n]["SMS_receiver_id"].ToString();
																																model.SMS_content= dt.Rows[n]["SMS_content"].ToString();
																												if(dt.Rows[n]["SMS_date"].ToString()!="")
				{
					model.SMS_date=DateTime.Parse(dt.Rows[n]["SMS_date"].ToString());
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