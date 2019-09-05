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
    /// 流程类别
    /// </summary>
    public partial class WF_FlowSort : BaseEntity,ICloneable
    {
		private string _No=null;
		private string _ParentNo=null;
		private string _Name=null;
		private string _OrgNo=null;
		private string _Domain=null;
		private int? _Idx=null;
	
	
      /// <summary>
      /// 编号(主键)
      /// </summary>
	  [DataMember]
	  public virtual string No 
	  { 
	     get{return _No;}
	     set{_No=value;}
	  }
	
      /// <summary>
      /// 父节点No
      /// </summary>
	  [DataMember]
	  public virtual string ParentNo 
	  { 
	     get{return _ParentNo;}
	     set{_ParentNo=value;}
	  }
	
      /// <summary>
      /// 名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 组织编号(0为系统组织)
      /// </summary>
	  [DataMember]
	  public virtual string OrgNo 
	  { 
	     get{return _OrgNo;}
	     set{_OrgNo=value;}
	  }
	
      /// <summary>
      /// 域/系统编号
      /// </summary>
	  [DataMember]
	  public virtual string Domain 
	  { 
	     get{return _Domain;}
	     set{_Domain=value;}
	  }
	
      /// <summary>
      /// Idx
      /// </summary>
	  [DataMember]
	  public virtual int? Idx 
	  { 
	     get{return _Idx;}
	     set{_Idx=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_FlowSortMap : ClassMap<WF_FlowSort>
    {
        public WF_FlowSortMap()
        {
		Id(m => m.No).GeneratedBy.UuidHex("D");
				 Map(m => m.ParentNo);
	        	 Map(m => m.Name);
	        	 Map(m => m.OrgNo);
	        	 Map(m => m.Domain);
	        	 Map(m => m.Idx);
	        		
						     }
    }
}

