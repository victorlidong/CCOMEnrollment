using System; 
using System.Data;
using System.Collections.Generic; 
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//View_Admin
		public partial class View_Admin
	{
   		     
		private readonly university.DAL.CCOM.View_Admin dal=new university.DAL.CCOM.View_Admin();
		public View_Admin()
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
		public void  Add(university.Model.CCOM.View_Admin model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.View_Admin model)
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
		public bool Delete(int User_id)
		{
			
			return dal.Delete(User_id);
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
		public university.Model.CCOM.View_Admin GetModel()
		{
			
			return dal.GetModel();
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.View_Admin GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.View_Admin GetModelByCache()
		{
			
			string CacheKey = "View_AdminModel-" + ;
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
			return (university.Model.CCOM.View_Admin)objModel;
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
		public List<university.Model.CCOM.View_Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.View_Admin> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.View_Admin> modelList = new List<university.Model.CCOM.View_Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.View_Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.View_Admin();					
													if(dt.Rows[n]["User_id"].ToString()!="")
				{
					model.User_id=long.Parse(dt.Rows[n]["User_id"].ToString());
				}
																																				model.User_number= dt.Rows[n]["User_number"].ToString();
																																model.User_password= dt.Rows[n]["User_password"].ToString();
																																model.User_realname= dt.Rows[n]["User_realname"].ToString();
																												if(dt.Rows[n]["User_ID_number_type"].ToString()!="")
				{
					model.User_ID_number_type=int.Parse(dt.Rows[n]["User_ID_number_type"].ToString());
				}
																																				model.User_ID_number= dt.Rows[n]["User_ID_number"].ToString();
																																												if(dt.Rows[n]["User_gender"].ToString()!="")
				{
					if((dt.Rows[n]["User_gender"].ToString()=="1")||(dt.Rows[n]["User_gender"].ToString().ToLower()=="true"))
					{
					model.User_gender= true;
					}
					else
					{
					model.User_gender= false;
					}
				}
																if(dt.Rows[n]["User_birthday"].ToString()!="")
				{
					model.User_birthday=DateTime.Parse(dt.Rows[n]["User_birthday"].ToString());
				}
																																if(dt.Rows[n]["User_type"].ToString()!="")
				{
					model.User_type=int.Parse(dt.Rows[n]["User_type"].ToString());
				}
																																if(dt.Rows[n]["User_addtime"].ToString()!="")
				{
					model.User_addtime=DateTime.Parse(dt.Rows[n]["User_addtime"].ToString());
				}
																																																if(dt.Rows[n]["User_status"].ToString()!="")
				{
					if((dt.Rows[n]["User_status"].ToString()=="1")||(dt.Rows[n]["User_status"].ToString().ToLower()=="true"))
					{
					model.User_status= true;
					}
					else
					{
					model.User_status= false;
					}
				}
																if(dt.Rows[n]["Agency_id"].ToString()!="")
				{
					model.Agency_id=int.Parse(dt.Rows[n]["Agency_id"].ToString());
				}
																																				model.Agency_name= dt.Rows[n]["Agency_name"].ToString();
																												if(dt.Rows[n]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(dt.Rows[n]["Role_id"].ToString());
				}
																																				model.Role_name= dt.Rows[n]["Role_name"].ToString();
																						
				
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