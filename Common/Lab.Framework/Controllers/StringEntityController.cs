using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Lab.Framework
{
    /// <summary>
    /// 实体主键为String类型的控制器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StringEntityController<T> : BaseController
       where T : BaseEntity, new()
    {
        ///// <summary>
        ///// 获取当前实体的所有查询数据
        ///// </summary>
        //public virtual IQueryable<T> GetAll(bool includeDeleted = false)
        //{
        //    var query = ModelQuery.Default.ISession.Query<T>();
        //    if (includeDeleted == false)
        //    {
        //        query = query.Where(p => p.IsDeleted == false);
        //    }
        //    return query;
        //}
        ///// <summary>
        ///// 获取指定实体的所有查询数据
        ///// </summary>
        //public virtual IQueryable<TEntity> GetAll<TEntity>(bool includeDeleted = false) where TEntity : GuidModel, new()
        //{
        //    var query = ModelQuery.Default.ISession.Query<TEntity>();
        //    if (includeDeleted == false)
        //    {
        //        query = query.Where(p => p.IsDeleted == false);
        //    }
        //    return query;
        //}
        /// <summary>
        /// 加载表格数据
        /// </summary>
        public virtual ActionResult GetPaged(int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = string.Format("SELECT * FROM {0}", typeof(T).Name);

            return PagedQuery(sql, page, rows, filters, orders);
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        public virtual ActionResult GetTreePaged1(int page, int rows, List<MyFilter> filters, string orders = "", int? ID = null)
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = string.Format("SELECT * FROM {0}", typeof(T).Name);
            return TreePagedQuery(sql, page, rows, filters, orders, ID: ID);
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        public virtual ActionResult PagedQuery(string sql, int page, int rows, List<MyFilter> filters, string orders = "", bool filterDeleted = false, string columns = "")
        {
            var result = getPagedData<T>(sql, page, rows, filters, orders, filterDeleted, columns);

            return Json_Get(new { total = result.total, rows = result.rows });
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        public virtual ActionResult TreePagedQuery(string sql, int page, int rows, List<MyFilter> filters, string orders = "", int? ID = null)
        {
            var result = getTreePagedData<T>(sql, page, rows, filters, orders);

            if (ID.HasValue)
            {
                return Json_Get(result.rows);
            }
            return Json_Get(new { total = result.total, rows = result.rows });
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        public virtual ActionResult GetData(List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = string.Format("select * from {0}", typeof(T).Name);

            var data = QueryService.GetData(sql, filters, orders);

            return Json_Get(data);
        }

        //public ActionResult JsonInfo(bool success, string msg = "", object userData = null)
        //{
        //    return Json(new { success = success, msg = msg, UserData = userData }, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="page">页码</param>
        /// <param name="rows">行号</param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns>分页数据</returns>
        public virtual PagedResult getPagedData<TModel>(string sql, int page, int rows, List<MyFilter> filters, string orders = "", bool filterDeleted = false, string columns = "")
        {
            return QueryService.CreatePagedSQLQuery(sql, page, rows, filters, orders);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="page">页码</param>
        /// <param name="rows">行号</param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns>分页数据</returns>
        public virtual PagedResult getTreePagedData<TModel>(string sql, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            return QueryService.CreateTreePagedSQLQuery(sql, page, rows, filters, orders);
        }


        ///// <summary>
        ///// 获取分页数据
        ///// </summary>
        ///// <param name="sql">SQL语句</param>
        ///// <param name="page">页码</param>
        ///// <param name="rows">行号</param>
        ///// <param name="filters"></param>
        ///// <param name="orders"></param>
        ///// <returns>分页数据</returns>
        //public virtual PagedResult<dynamic> getTreePagedData<TModel>(int page, int rows, string sql, List<MyFilter> filters, string orders = "", string id = "")
        //{
        //    return QueryService1.CreateTreePagedSQLQuery(page,rows,sql, filters, orders, id);
        //}

        /// <summary>
        /// 加载表单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult LoadForm(string id)
        {
            var entity = new T();
            if (!string.IsNullOrEmpty(id))
            {
                entity = NH.GetSession<T>().Get<T>(id);
            }
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult SaveEntity()
        {
            try
            {
                var entity = GetUpdateModel();
                entity.SaveOrUpdate();
                return Json(new { success = true, entity = entity });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }

        /// <summary>
        /// 获取从表单提交更新后的实体
        /// </summary>
        /// <param name="dao">数据访问对象</param>
        /// <returns>实体对象</returns>
        public virtual T GetUpdateModel(string[] excludeProperties = null, string idField = "ID")
        {
            var Id = string.Empty;
            if (this.ValueProvider.GetValue(idField) != null)
            {
                Id = this.ValueProvider.GetValue(idField).AttemptedValue;
            }
            var entity = string.IsNullOrWhiteSpace(Id) ? new T() : NH.GetSession<T>().Get<T>(Id);
            if (entity == null)
            {
                entity = new T();
            }

            try
            {
                UpdateModel(entity);
            }
            catch (InvalidOperationException ex)
            {
                var errorMsg = string.Empty;
                foreach (var item in ModelState.Values.Where(x => x.Errors.Count > 0))
                {
                    errorMsg += item.Errors.First().ErrorMessage + "。";
                }
                throw new Exception(errorMsg, ex);
            }
            return entity;
        }

        //public A GetUpdateModel<A>(A entity, string prefix = null, string[] includeProperties = null, string[] excludeProperties = null) where A : GuidModel, new()
        //{
        //    try
        //    {
        //        var array = new List<string>();
        //        array.Add("Id");
        //        if (excludeProperties != null)
        //        {
        //            array.AddRange(excludeProperties);
        //        }
        //        UpdateModel(entity, null, null, array.ToArray());
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        var errorMsg = string.Empty;
        //        foreach (var item in ModelState.Values.Where(x => x.Errors.Count > 0))
        //        {
        //            errorMsg += item.Errors.First().ErrorMessage + "。";
        //        }
        //        throw new Exception(errorMsg, ex);
        //    }
        //    return entity;
        //}

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <returns>操作结果</returns>
        public virtual ActionResult DeleteEntities(string[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<T>(id);
                    entity.Delete();
                }
            }
            catch (DataInvalidException ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "删除失败" });
            }
            return Json(new { success = true, msg = "删除成功" });
        }


        /// <summary>
        /// 返回与EasyUI的datagrid相适应的分页数据
        /// <para>此方法把分页结果放置在返回结果的UserData属性中</para>
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="data">返回页数据</param>
        /// <returns>执行结果</returns>
        protected ActionResult Pager(int total, object data)
        {
            return Json(new { total = total, rows = data });
        }

        /// <summary>
        /// 返回与EasyUI的datagrid相适应的分页数据
        /// <para>此方法把分页结果放置在返回结果的UserData属性中</para>
        /// </summary>
        /// <typeparam name="T">结果集类型</typeparam>
        /// <param name="result">分页结果集</param>
        /// <returns>执行结果</returns>
        //protected ActionResult Pager<T>(PagedResult<T> result)
        //{
        //    return Json(new { total = result.TotalItems, rows = result.Items });
        //}

        /// <summary>
        /// 返回与EasyUI的datagrid相适应的分页数据
        /// <para>此方法将直接返回分页结果</para>
        /// </summary>
        /// <param name="total">总记录数</param>&
        /// <param name="data">返回页数据</param>
        /// <returns>执行结果</returns>
        protected ActionResult PagerDirectly(int total, object data)
        {
            return Json(new { total = total, rows = data }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回与EasyUI的datagrid相适应的分页数据
        /// <para>此方法将直接返回分页结果</para>
        /// </summary>
        /// <typeparam name="T">结果集类型</typeparam>
        /// <param name="result">分页结果集</param>
        /// <returns>执行结果</returns>
        //protected ActionResult PagerDirectly<T>(PagedResult<T> result)
        //{
        //    return Json(new { total = result.TotalItems, rows = result.Items }, JsonRequestBehavior.AllowGet);
        //}


        ///// <summary>
        ///// 根据存储过程返回查询数据
        ///// </summary>
        ///// <param name="procedureName"></param>
        ///// <param name="filters"></param>
        ///// <returns></returns>
        //public IList<IDictionary<string, object>> GetDataByProcedure(string procedureName, List<MyFilter> filters = null)
        //{
        //    filters = filters == null ? new List<MyFilter>() : filters;
        //    var conn = new OracleConnection(ConfigurationManager.ConnectionStrings["LandSystem"].ConnectionString);
        //    var cmd = new OracleCommand(procedureName, conn);

        //    var paramsList = ModelQuery.Default.CreateSQLQuery(string.Format("SELECT T.ARGUMENT_NAME FROM user_arguments T WHERE T.OBJECT_NAME='{0}' ORDER BY T.POSITION ASC", procedureName)).List<string>();

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    //var paramers = new HashSet<DbParameter>();

        //    foreach (var item in paramsList)
        //    {
        //        var filter = filters.Where(x => x.property.ToUpper() == item).FirstOrDefault();
        //        if (filter == null)
        //        {
        //            continue;
        //        }
        //        if (OracelTypeDic.ContainsKey(filter.dataType))
        //        {
        //            var param = new OracleParameter()
        //            {
        //                OracleDbType = OracelTypeDic[filter.dataType],
        //                ParameterName = filter.property,
        //                Direction = ParameterDirection.Input
        //            };
        //            if (filter.value == null)
        //            {
        //                param.Value = DBNull.Value;
        //            }
        //            else if (filter.dataType == "date")
        //            {
        //                param.Value = DateTime.Parse(filter.value);
        //            }
        //            else
        //            {
        //                param.Value = filter.value;
        //            }
        //            cmd.Parameters.Add(param);
        //        }
        //    }

        //    var paramer1 = new OracleParameter()
        //    {
        //        OracleDbType = OracleDbType.RefCursor,
        //        ParameterName = "DATATABLE",
        //        Direction = ParameterDirection.Output
        //    };

        //    cmd.Parameters.Add(paramer1);

        //    var da = new OracleDataAdapter(cmd);

        //    da.SelectCommand = cmd;

        //    DataSet ds = new DataSet("dt");

        //    da.Fill(ds, "dt");

        //    return ds.Tables[0].ToIDictionaryList();
        //}
        ///// <summary>
        ///// 根据存储过程返回查询数据
        ///// </summary>
        ///// <param name="procedureName"></param>
        ///// <param name="filters"></param>
        ///// <returns></returns>
        //public IList<IDictionary<string, object>> GetPagedByProcedure(string procedureName, int page, int rows, out int total, List<MyFilter> filters = null)
        //{
        //    filters = filters == null ? new List<MyFilter>() : filters;

        //    filters.Add(new MyFilter() { property = "PAGE", value = page.ToString(), dataType = "number" });
        //    filters.Add(new MyFilter() { property = "ROWS", value = rows.ToString(), dataType = "number" });

        //    var conn = new OracleConnection(ConfigurationManager.ConnectionStrings["LandSystem"].ConnectionString);
        //    var cmd = new OracleCommand(procedureName, conn);

        //    var paramsList = ModelQuery.Default.CreateSQLQuery(string.Format("SELECT T.ARGUMENT_NAME FROM user_arguments T WHERE T.OBJECT_NAME='{0}' ORDER BY T.POSITION ASC", procedureName)).List<string>();

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    foreach (var item in paramsList)
        //    {
        //        var filter = filters.Where(x => x.property.ToUpper() == item).FirstOrDefault();
        //        if (filter == null)
        //        {
        //            continue;
        //        }
        //        if (OracelTypeDic.ContainsKey(filter.dataType))
        //        {
        //            var param = new OracleParameter()
        //            {
        //                OracleDbType = OracelTypeDic[filter.dataType],
        //                ParameterName = filter.property,
        //                Direction = ParameterDirection.Input
        //            };
        //            if (filter.value == null)
        //            {
        //                param.Value = DBNull.Value;
        //            }
        //            else if (filter.dataType == "date")
        //            {
        //                param.Value = DateTime.Parse(filter.value);
        //            }
        //            else
        //            {
        //                param.Value = filter.value;
        //            }
        //            cmd.Parameters.Add(param);
        //        }
        //    }

        //    var paramer1 = new OracleParameter()
        //    {
        //        OracleDbType = OracleDbType.RefCursor,
        //        ParameterName = "DATATABLE",
        //        Direction = ParameterDirection.Output
        //    };
        //    cmd.Parameters.Add(paramer1);

        //    var paramer2 = new OracleParameter()
        //    {
        //        OracleDbType = OracleDbType.Int64,
        //        ParameterName = "TOTAL",
        //        Direction = ParameterDirection.Output
        //    };
        //    cmd.Parameters.Add(paramer2);

        //    DataSet ds = new DataSet("dt");
        //    total = 0;
        //    try
        //    {
        //        conn.Open();

        //        cmd.ExecuteNonQuery();

        //        var da = new OracleDataAdapter();

        //        da.Fill(ds, "dt", paramer1.Value as Oracle.ManagedDataAccess.Types.OracleRefCursor);
        //        total = int.Parse(paramer2.Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return ds.Tables[0].ToIDictionaryList();
        //}

        ///// <summary>
        ///// OracleDbType类型转换
        ///// </summary>
        //private static Dictionary<string, OracleDbType> OracelTypeDic = new Dictionary<string, OracleDbType> 
        //{ 
        //  { "varchar", OracleDbType.Varchar2 },
        //  { "nvarchar", OracleDbType.NVarchar2 },
        //  { "number", OracleDbType.Int64 },
        //  { "date", OracleDbType.Date },
        //  { "long", OracleDbType.Long }
        //};

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="columns">列</param>
        /// <param name="sheetName">导出的Excel文件名称</param>
        /// <returns></returns>
        public FileResult ExportExcel(List<Dictionary<string, object>> data, List<Column> columns, string sheetName = "导出Excel")
        {
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            columns = columns.Where(x => x.hidden != true && !string.IsNullOrEmpty(x.title)).ToList();

            var headerStyle = book.CreateCellStyle();
            var headerFont = book.CreateFont();
            headerFont.IsBold = true;
            headerFont.FontHeightInPoints = 12;
            headerFont.FontName = "宋体";
            headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.SetFont(headerFont);

            for (var i = 0; i < columns.Count; i++)
            {
                var cell = row1.CreateCell(i);
                cell.SetCellValue(columns[i].title);
                sheet1.SetColumnWidth(i, columns[i].width * 40);
                cell.CellStyle = headerStyle;
            }

            var contentStyle = book.CreateCellStyle();
            contentStyle.CloneStyleFrom(headerStyle);
            var contentFont = book.CreateFont();
            contentFont.FontHeightInPoints = 12;
            contentFont.FontName = "宋体";
            contentStyle.SetFont(contentFont);

            for (int i = 0; i < data.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                for (var j = 0; j < columns.Count; j++)
                {
                    //var property = data[i].GetType().GetProperty(columns[j].field);
                    var value = "";
                    if (data[i].ContainsKey(columns[j].field) && data[i][columns[j].field] != null)
                    {
                        value = data[i][columns[j].field].ToString();
                    }
                    var cell = rowtemp.CreateCell(j);
                    cell.SetCellValue(value);

                    cell.CellStyle = contentStyle;
                }
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", sheetName + ".xls");
        }
    }
}
