using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FluentNHibernate.Mapping;
using Lab.Framework;

namespace WebApplication5.Areas.Workflow.Models
{
    /// <summary>
    /// 节点部门
    /// </summary>
    public partial class WF_NodeDept : BaseEntity,ICloneable
    {
		private string _ID=null;
		private int _FK_Node=0;
		private string _FK_Dept=null;
	
	
      /// <summary>
      /// ID
      /// </summary>
	  [DataMember]
	  public virtual string ID 
	  { 
	     get{return _ID;}
	     set{_ID=value;}
	  }
	
      /// <summary>
      /// 节点(主键)
      /// </summary>
	  [DataMember]
	  public virtual int FK_Node 
	  { 
	     get{return _FK_Node;}
	     set{_FK_Node=value;}
	  }
	
      /// <summary>
      /// 部门,
      /// </summary>
	  [DataMember]
	  public virtual string FK_Dept 
	  { 
	     get{return _FK_Dept;}
	     set{_FK_Dept=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_NodeDeptMap : ClassMap<WF_NodeDept>
    {
        public WF_NodeDeptMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.FK_Node);
	        	 Map(m => m.FK_Dept);
	        		
						     }
    }
}

