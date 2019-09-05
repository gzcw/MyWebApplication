using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Models;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 流程Session
    /// </summary>
    public class WFSession
    {
        /// <summary>
        /// 
        /// </summary>
        public static NHibernate.ISession Session
        {
            get
            {
                return SessionManager.GetSession<BWA>();
            }
        }
    }
}
