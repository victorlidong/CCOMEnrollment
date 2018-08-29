/**  版本信息模板在安装目录下，可自行修改。
* Software_accept.cs
*
* 功 能： N/A
* 类 名： Software_accept
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:44   N/A    初版
*
* Copyright (c) 2012 university Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;
namespace university.BLL.CCOM
{
	/// <summary>
	/// Software_accept
	/// </summary>
	public partial class Software_accept
	{
		private readonly university.DAL.CCOM.Software_accept dal=new university.DAL.CCOM.Software_accept();
		public Software_accept()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Sa_id)
		{
			return dal.Exists(Sa_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Software_accept model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Software_accept model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Sa_id)
		{
			
			return dal.Delete(Sa_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Sa_idlist )
		{
            return dal.DeleteList(Sa_idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Software_accept GetModel(long Sa_id)
		{
			
			return dal.GetModel(Sa_id);
		}
        public university.Model.CCOM.Software_accept GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
        ///// </summary>
        //public university.Model.CCOM.Software_accept GetModelByCache(long Sa_id)
        //{
			
        //    string CacheKey = "Software_acceptModel-" + Sa_id;
        //    object objModel = university.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Sa_id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (university.Model.CCOM.Software_accept)objModel;
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
		public List<university.Model.CCOM.Software_accept> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Software_accept> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Software_accept> modelList = new List<university.Model.CCOM.Software_accept>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Software_accept model;
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

