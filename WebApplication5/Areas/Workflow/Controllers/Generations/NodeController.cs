using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【审核组件】控制器
    /// </summary>
    public partial class NodeController
    {
        #region 视图

        /// <summary>
        /// 主页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 表单
        /// </summary>
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 流程表单
        /// </summary>
        public ActionResult WfForm()
        {
            return View();
        }

        /// <summary>
        /// 流程列表
        /// </summary>
        public ActionResult WfList()
        {
            return View();
        }

        /// <summary>
        /// 选择
        /// </summary>
        public ActionResult Select()
        {
            return View();
        }

        		/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_Department()
        {
            return View();
        }
				/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_Station()
        {
            return View();
        }
				/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_User()
        {
            return View();
        }
				/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_Page()
        {
            return View();
        }
		
		#endregion
		
        #region 操作

		
		        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override ActionResult SaveEntity()
        {
            try
            {
                var entity = GetUpdateModel(null,"NodeID");
                entity.Save();
                return Json(new { success = true, entity = entity });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }
		
		
		
		
		

		

		
				
        /// <summary>
        /// 获取分页数据NodeDept
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_NodeDept(int FK_Node, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeDept T WHERE T.FK_Node='{0}'", FK_Node);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据NodeDept
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_NodeDept(int FK_Node, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeDept T WHERE T.FK_Node='{0}'", FK_Node);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系WF_NodeDept
        /// </summary>
        public ActionResult SaveRelation_NodeDept(int FK_Node, List<string> FK_DeptS)
        {
            foreach (var item in FK_DeptS)
            {
                var entity = NH.GetSession<WF_Node>().QueryOver<WF_NodeDept>().Where(x => x.FK_Dept == item && x.FK_Node == FK_Node).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new WF_NodeDept()
                    {
                        FK_Node = FK_Node,
                        FK_Dept = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系WF_NodeDept
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_NodeDept(List<WF_NodeDept> list)
        {
            try
            {
                foreach (var item in list)
                {
                    NH.Session.Merge(item);
                    NH.Session.Flush();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 删除关系WF_NodeDept
        /// </summary>
        public ActionResult DeleteRelation_NodeDept(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<WF_NodeDept>(id);
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
        /// 获取分页数据NodeStation
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_NodeStation(int FK_Node, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeStation T WHERE T.FK_Node='{0}'", FK_Node);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据NodeStation
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_NodeStation(int FK_Node, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeStation T WHERE T.FK_Node='{0}'", FK_Node);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系WF_NodeStation
        /// </summary>
        public ActionResult SaveRelation_NodeStation(int FK_Node, List<string> FK_StationS)
        {
            foreach (var item in FK_StationS)
            {
                var entity = NH.GetSession<WF_Node>().QueryOver<WF_NodeStation>().Where(x => x.FK_Station == item && x.FK_Node == FK_Node).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new WF_NodeStation()
                    {
                        FK_Node = FK_Node,
                        FK_Station = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系WF_NodeStation
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_NodeStation(List<WF_NodeStation> list)
        {
            try
            {
                foreach (var item in list)
                {
                    NH.Session.Merge(item);
                    NH.Session.Flush();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 删除关系WF_NodeStation
        /// </summary>
        public ActionResult DeleteRelation_NodeStation(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<WF_NodeStation>(id);
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
        /// 获取分页数据NodeEmp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_NodeEmp(int FK_Node, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeEmp T WHERE T.FK_Node='{0}'", FK_Node);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据NodeEmp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_NodeEmp(int FK_Node, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodeEmp T WHERE T.FK_Node='{0}'", FK_Node);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系WF_NodeEmp
        /// </summary>
        public ActionResult SaveRelation_NodeEmp(int FK_Node, List<string> FK_EmpS)
        {
            foreach (var item in FK_EmpS)
            {
                var entity = NH.GetSession<WF_Node>().QueryOver<WF_NodeEmp>().Where(x => x.FK_Emp == item && x.FK_Node == FK_Node).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new WF_NodeEmp()
                    {
                        FK_Node = FK_Node,
                        FK_Emp = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系WF_NodeEmp
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_NodeEmp(List<WF_NodeEmp> list)
        {
            try
            {
                foreach (var item in list)
                {
                    NH.Session.Merge(item);
                    NH.Session.Flush();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 删除关系WF_NodeEmp
        /// </summary>
        public ActionResult DeleteRelation_NodeEmp(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<WF_NodeEmp>(id);
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
        /// 获取分页数据NodePage
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_NodePage(int NodeID, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodePage T WHERE T.NodeID='{0}'", NodeID);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据NodePage
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_NodePage(int NodeID, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_WF_NodePage T WHERE T.NodeID='{0}'", NodeID);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系WF_NodePage
        /// </summary>
        public ActionResult SaveRelation_NodePage(int NodeID, List<string> PageIDS)
        {
            foreach (var item in PageIDS)
            {
                var entity = NH.GetSession<WF_Node>().QueryOver<WF_NodePage>().Where(x => x.PageID == item && x.NodeID == NodeID).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new WF_NodePage()
                    {
                        NodeID = NodeID,
                        PageID = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系WF_NodePage
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_NodePage(List<WF_NodePage> list)
        {
            try
            {
                foreach (var item in list)
                {
                    NH.Session.Merge(item);
                    NH.Session.Flush();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 删除关系WF_NodePage
        /// </summary>
        public ActionResult DeleteRelation_NodePage(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<WF_NodePage>(id);
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
		
				#endregion
    }
}
