using System;
using System.Data;
using System.Collections.Generic;
using university.Common;
using university.Model.CCOM;
using System.Web.UI.WebControls;

namespace university.BLL.CCOM
{

    //Nation
    public partial class Nation
    {

        private readonly university.DAL.CCOM.Nation dal = new university.DAL.CCOM.Nation();
        public Nation()
        {

        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Nation_id)
        {
            return dal.Exists(Nation_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(university.Model.CCOM.Nation model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(university.Model.CCOM.Nation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Nation_id)
        {

            return dal.Delete(Nation_id);
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
        public bool DeleteList(string Nation_idlist)
        {
            return dal.DeleteList(Nation_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public university.Model.CCOM.Nation GetModel(int Nation_id)
        {

            return dal.GetModel(Nation_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public university.Model.CCOM.Nation GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }



        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        /*
        public university.Model.CCOM.Nation GetModelByCache(int Nation_id)
        {
			
            string CacheKey = "NationModel-" + Nation_id;
            object objModel = university.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Nation_id);
                    if (objModel != null)
                    {
                        int ModelCache = university.Common.ConfigHelper.GetConfigInt("ModelCache");
                        university.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch{}
            }
            return (university.Model.CCOM.Nation)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<university.Model.CCOM.Nation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<university.Model.CCOM.Nation> DataTableToList(DataTable dt)
        {
            List<university.Model.CCOM.Nation> modelList = new List<university.Model.CCOM.Nation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                university.Model.CCOM.Nation model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new university.Model.CCOM.Nation();
                    if (dt.Rows[n]["Nation_id"].ToString() != "")
                    {
                        model.Nation_id = int.Parse(dt.Rows[n]["Nation_id"].ToString());
                    }
                    model.Nation_name = dt.Rows[n]["Nation_name"].ToString();


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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion

        public void BindDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = this.GetList("");
            ddl.DataSource = ds.Tables[0].DefaultView;
            ddl.DataTextField = "Nation_name";
            ddl.DataValueField = "Nation_id";
            ddl.DataBind();
        }
    }
}