using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//User_sms
		public partial class User_sms
	{
   		     
		private readonly university.DAL.CCOM.User_sms dal=new university.DAL.CCOM.User_sms();
		public User_sms()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long User_sms_id)
		{
			return dal.Exists(User_sms_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long  Add(university.Model.CCOM.User_sms model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.User_sms model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long User_sms_id)
		{
			
			return dal.Delete(User_sms_id);
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
		public bool DeleteList(string User_sms_idlist )
		{
			return dal.DeleteList(User_sms_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_sms GetModel(long User_sms_id)
		{
			
			return dal.GetModel(User_sms_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.User_sms GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.User_sms GetModelByCache(long User_sms_id)
		{
			
			string CacheKey = "User_smsModel-" + User_sms_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(User_sms_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.User_sms)objModel;
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
		public List<university.Model.CCOM.User_sms> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.User_sms> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.User_sms> modelList = new List<university.Model.CCOM.User_sms>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.User_sms model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.User_sms();					
													if(dt.Rows[n]["User_sms_id"].ToString()!="")
				{
					model.User_sms_id=long.Parse(dt.Rows[n]["User_sms_id"].ToString());
				}
																																if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																if(dt.Rows[n]["User_sms_left"].ToString()!="")
				{
					model.User_sms_left=int.Parse(dt.Rows[n]["User_sms_left"].ToString());
				}
																																if(dt.Rows[n]["User_sms_create_time"].ToString()!="")
				{
					model.User_sms_create_time=DateTime.Parse(dt.Rows[n]["User_sms_create_time"].ToString());
				}
																																if(dt.Rows[n]["User_sms_modify_time"].ToString()!="")
				{
					model.User_sms_modify_time=DateTime.Parse(dt.Rows[n]["User_sms_modify_time"].ToString());
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

        /// <summary>
        /// 判断是否首次申请短信
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsFirstApplySmsNumber(long userId)
        {
            var ml = new BLL.CCOM.User_sms().GetModelList(" User_id=" + userId);
            if (ml != null && ml.Count > 0)
                return false;
            return true;
        }
	}
}