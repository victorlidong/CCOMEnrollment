using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM
{
	/// <summary>
	/// 报名周期表
	/// </summary>
	public partial class Week_log
	{
		private readonly university.DAL.CCOM.Week_log dal=new university.DAL.CCOM.Week_log();
		public Week_log()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Weeklog_id)
		{
			return dal.Exists(Weeklog_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Week_log model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Week_log model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Weeklog_id)
		{
			
			return dal.Delete(Weeklog_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Weeklog_idlist )
		{
            return dal.DeleteList(Weeklog_idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Week_log GetModel(long Weeklog_id)
		{
			
			return dal.GetModel(Weeklog_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public university.Model.CCOM.Week_log GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public university.Model.CCOM.Week_log GetModelByCache(long Weeklog_id)
        //{
			
        //    string CacheKey = "Week_logModel-" + Weeklog_id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Weeklog_id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (university.Model.CCOM.Week_log)objModel;
        //}

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
		public List<university.Model.CCOM.Week_log> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Week_log> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Week_log> modelList = new List<university.Model.CCOM.Week_log>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Week_log model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

