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
    /// 节点人员
    /// </summary>
    public partial class WF_NodeEmp : BaseEntity,ICloneable
    {
		private string _ID=null;
		private int _FK_Node=0;
		private string _FK_Emp=null;
	
	
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
      /// Node(主键)
      /// </summary>
	  [DataMember]
	  public virtual int FK_Node 
	  { 
	     get{return _FK_Node;}
	     set{_FK_Node=value;}
	  }
	
      /// <summary>
      /// 到人员,
      /// </summary>
	  [DataMember]
	  public virtual string FK_Emp 
	  { 
	     get{return _FK_Emp;}
	     set{_FK_Emp=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_NodeEmpMap : ClassMap<WF_NodeEmp>
    {
        public WF_NodeEmpMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.FK_Node);
	        	 Map(m => m.FK_Emp);
	        		
						     }
    }
}

