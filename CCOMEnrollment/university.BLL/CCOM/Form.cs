/**  版本信息模板在安装目录下，可自行修改。
* Form.cs
*
* 功 能： N/A
* 类 名： Form
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/30 17:34:25   N/A    初版
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
	/// Form
	/// </summary>
	public partial class Form
	{
		private readonly university.DAL.CCOM.Form dal=new university.DAL.CCOM.Form();
		public Form()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Form_id)
		{
			return dal.Exists(Form_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Form model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Form model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Form_id)
		{
			
			return dal.Delete(Form_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Form_idlist )
		{
            return dal.DeleteList(Form_idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Form GetModel(int Form_id)
		{
			
			return dal.GetModel(Form_id);
		}
        public university.Model.CCOM.Form GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public university.Model.CCOM.Form GetModelByCache(int Form_id)
        //{
			
        //    string CacheKey = "FormModel-" + Form_id;
        //    object objModel = university.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Form_id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (university.Model.CCOM.Form)objModel;
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
		public List<university.Model.CCOM.Form> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Form> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Form> modelList = new List<university.Model.CCOM.Form>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Form model;
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

