using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;

namespace university.BLL.CCOM{

	 	//Fractional_line
		public partial class Fractional_line
	{
   		     
		private readonly university.DAL.CCOM.Fractional_line dal=new university.DAL.CCOM.Fractional_line();
		public Fractional_line()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Fl_id)
		{
			return dal.Exists(Fl_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(university.Model.CCOM.Fractional_line model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(university.Model.CCOM.Fractional_line model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Fl_id)
		{
			
			return dal.Delete(Fl_id);
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
		public bool DeleteList(string Fl_idlist )
		{
			return dal.DeleteList(Fl_idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Fractional_line GetModel(int Fl_id)
		{
			
			return dal.GetModel(Fl_id);
		}
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public university.Model.CCOM.Fractional_line GetModel(string strWhere)
		{
			
			return dal.GetModel(strWhere);
		}
		
		

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		/*
		public university.Model.CCOM.Fractional_line GetModelByCache(int Fl_id)
		{
			
			string CacheKey = "Fractional_lineModel-" + Fl_id;
			object objModel = university.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Fl_id);
					if (objModel != null)
					{
						int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
						university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (university.Model.CCOM.Fractional_line)objModel;
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
		public List<university.Model.CCOM.Fractional_line> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<university.Model.CCOM.Fractional_line> DataTableToList(DataTable dt)
		{
			List<university.Model.CCOM.Fractional_line> modelList = new List<university.Model.CCOM.Fractional_line>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				university.Model.CCOM.Fractional_line model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new university.Model.CCOM.Fractional_line();					
													if(dt.Rows[n]["Fl_id"].ToString()!="")
				{
					model.Fl_id=int.Parse(dt.Rows[n]["Fl_id"].ToString());
				}
																																if(dt.Rows[n]["Fl_Province"].ToString()!="")
				{
					model.Fl_Province=int.Parse(dt.Rows[n]["Fl_Province"].ToString());
				}
																																if(dt.Rows[n]["WenKeYiBen"].ToString()!="")
				{
					model.WenKeYiBen=decimal.Parse(dt.Rows[n]["WenKeYiBen"].ToString());
				}
																																if(dt.Rows[n]["LiKeYiBen"].ToString()!="")
				{
					model.LiKeYiBen=decimal.Parse(dt.Rows[n]["LiKeYiBen"].ToString());
				}
																																if(dt.Rows[n]["WenKeErBen"].ToString()!="")
				{
					model.WenKeErBen=decimal.Parse(dt.Rows[n]["WenKeErBen"].ToString());
				}
																																if(dt.Rows[n]["LiKeErBen"].ToString()!="")
				{
					model.LiKeErBen=decimal.Parse(dt.Rows[n]["LiKeErBen"].ToString());
				}
																																if(dt.Rows[n]["WenKeSanBen"].ToString()!="")
				{
					model.WenKeSanBen=decimal.Parse(dt.Rows[n]["WenKeSanBen"].ToString());
				}
																																if(dt.Rows[n]["LiKeSanBen"].ToString()!="")
				{
					model.LiKeSanBen=decimal.Parse(dt.Rows[n]["LiKeSanBen"].ToString());
				}
																																if(dt.Rows[n]["WenKeYiShuXian"].ToString()!="")
				{
					model.WenKeYiShuXian=decimal.Parse(dt.Rows[n]["WenKeYiShuXian"].ToString());
				}
																																if(dt.Rows[n]["LiKeYiShuXian"].ToString()!="")
				{
					model.LiKeYiShuXian=decimal.Parse(dt.Rows[n]["LiKeYiShuXian"].ToString());
				}
																																if(dt.Rows[n]["WenKeZongFen"].ToString()!="")
				{
					model.WenKeZongFen=decimal.Parse(dt.Rows[n]["WenKeZongFen"].ToString());
				}
																																if(dt.Rows[n]["LiKeZongFen"].ToString()!="")
				{
					model.LiKeZongFen=decimal.Parse(dt.Rows[n]["LiKeZongFen"].ToString());
				}
																																if(dt.Rows[n]["Period_id"].ToString()!="")
				{
					model.Period_id=int.Parse(dt.Rows[n]["Period_id"].ToString());
				}
																																if(dt.Rows[n]["Fl_addtime"].ToString()!="")
				{
					model.Fl_addtime=DateTime.Parse(dt.Rows[n]["Fl_addtime"].ToString());
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