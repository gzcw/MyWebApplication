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
    /// WF_NodePage
    /// </summary>
    public partial class WF_NodePage : BaseEntity,ICloneable
    {
		private string _ID=null;
		private int _NodeID=0;
		private string _PageID=null;
		private int? _SortNumber=null;
		private int? _Permission=null;
		private string _Params=null;
	
	
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
      /// NodeID
      /// </summary>
	  [DataMember]
	  public virtual int NodeID 
	  { 
	     get{return _NodeID;}
	     set{_NodeID=value;}
	  }
	
      /// <summary>
      /// PageID
      /// </summary>
	  [DataMember]
	  public virtual string PageID 
	  { 
	     get{return _PageID;}
	     set{_PageID=value;}
	  }
	
      /// <summary>
      /// SortNumber
      /// </summary>
	  [DataMember]
	  public virtual int? SortNumber 
	  { 
	     get{return _SortNumber;}
	     set{_SortNumber=value;}
	  }
	
      /// <summary>
      /// Permission
      /// </summary>
	  [DataMember]
	  public virtual int? Permission 
	  { 
	     get{return _Permission;}
	     set{_Permission=value;}
	  }
	
      /// <summary>
      /// Params
      /// </summary>
	  [DataMember]
	  public virtual string Params 
	  { 
	     get{return _Params;}
	     set{_Params=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_NodePageMap : ClassMap<WF_NodePage>
    {
        public WF_NodePageMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.NodeID);
	        	 Map(m => m.PageID);
	        	 Map(m => m.SortNumber);
	        	 Map(m => m.Permission);
	        	 Map(m => m.Params);
	        		
						     }
    }
}

