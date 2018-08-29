using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;
using System.Web.UI.WebControls;

namespace university.BLL.CCOM{

	 	//Politics
		public partial class Politics
	{
   		     
		private readonly university.DAL.CCOM.Politics dal=new university.DAL.CCOM.Politics();
		public Politics()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Politics_id)
		{
			return dal.Exists(Politics_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Politics model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Politics model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Politics_id)
		{
			
			return dal.Delete(Politics_id);
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
		public bool DeleteList(string Politics_idlist )
		{
			return dal.DeleteList(Politics_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Politics GetModel(int Politics_id)
		{
			
			return dal.GetModel(Politics_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Politics GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Politics GetModelByCache(int Politics_id)
		{
			
			string CacheKey = "PoliticsModel-" + Politics_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Politics_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Politics)objModel;
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
		public List<university.Model.CCOM.Politics> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Politics> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Politics> modelList = new List<university.Model.CCOM.Politics>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Politics model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Politics();					
													if(dt.Rows[n]["Politics_id"].ToString()!="")
				{
					model.Politics_id=int.Parse(dt.Rows[n]["Politics_id"].ToString());
				}
																																				model.Politics_name= dt.Rows[n]["Politics_name"].ToString();
																						
				
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


        public void BindDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = this.GetList("");
            ddl.DataSource = ds.Tables[0].DefaultView;
            ddl.DataTextField = "Politics_name";
            ddl.DataValueField = "Politics_id";
            ddl.DataBind();
        }
    }
}