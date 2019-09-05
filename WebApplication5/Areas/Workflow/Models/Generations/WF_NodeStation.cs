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
    /// 节点岗位
    /// </summary>
    public partial class WF_NodeStation : BaseEntity,ICloneable
    {
		private string _ID=null;
		private int _FK_Node=0;
		private string _FK_Station=null;
	
	
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
      /// 工作岗位,
      /// </summary>
	  [DataMember]
	  public virtual string FK_Station 
	  { 
	     get{return _FK_Station;}
	     set{_FK_Station=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_NodeStationMap : ClassMap<WF_NodeStation>
    {
        public WF_NodeStationMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.FK_Node);
	        	 Map(m => m.FK_Station);
	        		
						     }
    }
}

