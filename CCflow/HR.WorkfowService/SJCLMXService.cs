using HR.BasicFramework.DataAccess;
////using HR.WorkflowService.DAOs;
using HR.WorkflowService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 收件材料明细服务
    /// </summary>
    public class SJCLMXService
    {
        /// <summary>
        /// 根据办文类型ID创建办文材料明细
        /// </summary>
        /// <param name="sjdId">收件单ID</param>
        /// <param name="bwlxId">办文类型ID</param>
        public static void CreateByBWLXID(string sjdId, string bwlxId)
        {
            //var sjclmxDAO = new SJCLMXDAO();
            //var bwclbwlxrltDAO = new BWLXBWCLRLTDAO();

            var bwclbwlxrltList = DataContextNH.GetByLINQ<BWLXBWCLRLT>(x => x.BWLXID == bwlxId, null, null, null, null);

            foreach (var item in bwclbwlxrltList)
            {
                if (item.BWCL == null)
                {
                    continue;
                }

                var sjclmx = new SJCLMX()
                {
                    ID = Guid.NewGuid().ToString(),
                    SJDID = sjdId,
                    BWCLID = item.BWCLID,
                    CLYS = item.CLYS,
                    CLMC = item.BWCL.CLMC,
                    SJLX = item.BWCL.SJLX,
                    SJSL = item.SJSL,
                    SH = item.SORTORDER,
                    SFLYZMWJ = 1
                };
                DataContextNH.Save<SJCLMX>(sjclmx);
                //sjclmxDAO.Save(sjclmx);
            }
        }
    }
}