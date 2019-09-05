using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Models
{
    public class User
    {
        public string ID { get; set; }

        public string UserName { get; set; }
        public string RealName { get; set; }

        public Region Region { get; set; }

        public string RegionCode { get; set; }

        public string OfficePhone { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }
    }
}
