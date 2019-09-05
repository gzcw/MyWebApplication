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
    /// 流程页面
    /// </summary>
    public partial class WF_Page : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private string _Url=null;
		private int? _SortNumber=null;
	
	
      /// <summary>
      /// 标识
      /// </summary>
	  [DataMember]
	  public virtual string ID 
	  { 
	     get{return _ID;}
	     set{_ID=value;}
	  }
	
      /// <summary>
      /// 页面名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 路径
      /// </summary>
	  [DataMember]
	  public virtual string Url 
	  { 
	     get{return _Url;}
	     set{_Url=value;}
	  }
	
      /// <summary>
      /// 排序号
      /// </summary>
	  [DataMember]
	  public virtual int? SortNumber 
	  { 
	     get{return _SortNumber;}
	     set{_SortNumber=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_PageMap : ClassMap<WF_Page>
    {
        public WF_PageMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.Url);
	        	 Map(m => m.SortNumber);
	        		
						     }
    }
}

