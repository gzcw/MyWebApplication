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
    /// 节点方向信息
    /// </summary>
    public partial class WF_Direction : BaseEntity,ICloneable
    {
		private string _MyPK=null;
		private string _FK_Flow=null;
		private decimal _Node=0;
		private decimal _ToNode=0;
		private decimal _IsCanBack=0;
		private string _Dots=null;
	
	
      /// <summary>
      /// 主键MyPK(主键)
      /// </summary>
	  [DataMember]
	  public virtual string MyPK 
	  { 
	     get{return _MyPK;}
	     set{_MyPK=value;}
	  }
	
      /// <summary>
      /// 流程
      /// </summary>
	  [DataMember]
	  public virtual string FK_Flow 
	  { 
	     get{return _FK_Flow;}
	     set{_FK_Flow=value;}
	  }
	
      /// <summary>
      /// 从节点
      /// </summary>
	  [DataMember]
	  public virtual decimal Node 
	  { 
	     get{return _Node;}
	     set{_Node=value;}
	  }
	
      /// <summary>
      /// 到节点
      /// </summary>
	  [DataMember]
	  public virtual decimal ToNode 
	  { 
	     get{return _ToNode;}
	     set{_ToNode=value;}
	  }
	
      /// <summary>
      /// 是否可以原路返回(对后退线有效)
      /// </summary>
	  [DataMember]
	  public virtual decimal IsCanBack 
	  { 
	     get{return _IsCanBack;}
	     set{_IsCanBack=value;}
	  }
	
      /// <summary>
      /// 轨迹信息
      /// </summary>
	  [DataMember]
	  public virtual string Dots 
	  { 
	     get{return _Dots;}
	     set{_Dots=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_DirectionMap : ClassMap<WF_Direction>
    {
        public WF_DirectionMap()
        {
		Id(m => m.MyPK).GeneratedBy.UuidHex("D");
				 Map(m => m.FK_Flow);
	        	 Map(m => m.Node);
	        	 Map(m => m.ToNode);
	        	 Map(m => m.IsCanBack);
	        	 Map(m => m.Dots);
	        		
						     }
    }
}

