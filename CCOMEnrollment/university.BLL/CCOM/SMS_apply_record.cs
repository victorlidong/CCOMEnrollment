using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//SMS_apply_record
		public partial class SMS_apply_record
	{
   		     
		private readonly university.DAL.CCOM.SMS_apply_record dal=new university.DAL.CCOM.SMS_apply_record();
		public SMS_apply_record()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long SMS_apply_id)
		{
			return dal.Exists(SMS_apply_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.SMS_apply_record model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.SMS_apply_record model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long SMS_apply_id)
		{
			
			return dal.Delete(SMS_apply_id);
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
		public bool DeleteList(string SMS_apply_idlist )
		{
			return dal.DeleteList(SMS_apply_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.SMS_apply_record GetModel(long SMS_apply_id)
		{
			
			return dal.GetModel(SMS_apply_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.SMS_apply_record GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.SMS_apply_record GetModelByCache(long SMS_apply_id)
		{
			
			string CacheKey = "SMS_apply_recordModel-" + SMS_apply_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SMS_apply_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.SMS_apply_record)objModel;
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
		public List<university.Model.CCOM.SMS_apply_record> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.SMS_apply_record> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.SMS_apply_record> modelList = new List<university.Model.CCOM.SMS_apply_record>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.SMS_apply_record model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.SMS_apply_record();					
													if(dt.Rows[n]["SMS_apply_id"].ToString()!="")
				{
					model.SMS_apply_id=long.Parse(dt.Rows[n]["SMS_apply_id"].ToString());
				}
																																if(dt.Rows[n]["SMS_apply_number"].ToString()!="")
				{
					model.SMS_apply_number=int.Parse(dt.Rows[n]["SMS_apply_number"].ToString());
				}
																																if(dt.Rows[n]["SMS_apply_status"].ToString()!="")
				{
					model.SMS_apply_status=int.Parse(dt.Rows[n]["SMS_apply_status"].ToString());
				}
																																				model.SMS_apply_reason= dt.Rows[n]["SMS_apply_reason"].ToString();
																												if(dt.Rows[n]["SMS_apply_type"].ToString()!="")
				{
					model.SMS_apply_type=int.Parse(dt.Rows[n]["SMS_apply_type"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["SMS_give_number"].ToString()!="")
				{
					model.SMS_give_number=int.Parse(dt.Rows[n]["SMS_give_number"].ToString());
				}
																																if(dt.Rows[n]["SMS_apply_time"].ToString()!="")
				{
					model.SMS_apply_time=DateTime.Parse(dt.Rows[n]["SMS_apply_time"].ToString());
				}
																																				model.SMS_check_reason= dt.Rows[n]["SMS_check_reason"].ToString();
																						
				
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
        #region  ExtensionMethod
        public bool IsApplyStatus(long userId, int status)
        {
            var ml = new BLL.CCOM.SMS_apply_record().GetModelList(" User_id=" + userId + " and SMS_apply_status=" + status);
            if (ml != null && ml.Count > 0)
                return true;
            return false;
        }
        #endregion  ExtensionMethod
	}
}