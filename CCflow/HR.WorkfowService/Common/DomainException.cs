using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 领域层异常
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DomainException(string message)
            : base(message)
        {

        }
    }
}
