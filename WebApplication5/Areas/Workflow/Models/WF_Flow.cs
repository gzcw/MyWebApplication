using System.Runtime.Serialization;

namespace WebApplication5.Areas.Workflow.Models
{
    /// <summary>
    /// 报表定义
    /// </summary>
    public partial class WF_Flow
    {
        [DataMember]
        public virtual string FK_FlowSortName
        {
            get
            {
                if (this.WF_FlowSort != null)
                {
                    return this.WF_FlowSort.Name;
                }
                return null;
            }
        }
    }
}

