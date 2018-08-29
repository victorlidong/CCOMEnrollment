﻿using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;
namespace university.BLL.CCOM
{
	/// <summary>
	/// Form_value
	/// </summary>
	public partial class Form_value
	{
		private readonly university.DAL.CCOM.Form_value dal=new university.DAL.CCOM.Form_value();
		public Form_value()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Fv_id)
		{
			return dal.Exists(Fv_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(university.Model.CCOM.Form_value model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Form_value model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Fv_id)
		{
			
			return dal.Delete(Fv_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Fv_idlist )
		{
            return dal.DeleteList(Fv_idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Form_value GetModel(long Fv_id)
		{
			
			return dal.GetModel(Fv_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public university.Model.CCOM.Form_value GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public university.Model.CCOM.Form_value GetModelByCache(long Fv_id)
        //{
			
        //    string CacheKey = "Form_valueModel-" + Fv_id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Fv_id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (university.Model.CCOM.Form_value)objModel;
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
		public List<university.Model.CCOM.Form_value> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Form_value> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Form_value> modelList = new List<university.Model.CCOM.Form_value>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Form_value model;
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
