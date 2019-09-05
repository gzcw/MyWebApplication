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
    /// 流程工作者
    /// </summary>
    public partial class WF_GenerWorkerList : BaseEntity,ICloneable
    {
		private int _WorkID=0;
		private string _FK_Emp=null;
		private int _FK_Node=0;
		private int? _FID=null;
		private string _FK_EmpText=null;
		private string _FK_NodeText=null;
		private string _FK_Flow=null;
		private string _FK_Dept=null;
		private string _SDT=null;
		private string _DTOfWarning=null;
		private string _RDT=null;
		private string _CDT=null;
		private int? _IsEnable=null;
		private int? _IsRead=null;
		private int? _IsPass=null;
		private int? _WhoExeIt=null;
		private string _Sender=null;
		private int? _PRI=null;
		private int? _PressTimes=null;
		private string _DTOfHungUp=null;
		private string _DTOfUnHungUp=null;
		private int? _HungUpTimes=null;
		private string _GuestNo=null;
		private string _GuestName=null;
		private string _AtPara=null;
	
	
      /// <summary>
      /// 工作ID(主键)
      /// </summary>
	  [DataMember]
	  public virtual int WorkID 
	  { 
	     get{return _WorkID;}
	     set{_WorkID=value;}
	  }
	
      /// <summary>
      /// 人员(主键)
      /// </summary>
	  [DataMember]
	  public virtual string FK_Emp 
	  { 
	     get{return _FK_Emp;}
	     set{_FK_Emp=value;}
	  }
	
      /// <summary>
      /// 节点ID(主键)
      /// </summary>
	  [DataMember]
	  public virtual int FK_Node 
	  { 
	     get{return _FK_Node;}
	     set{_FK_Node=value;}
	  }
	
      /// <summary>
      /// 流程ID
      /// </summary>
	  [DataMember]
	  public virtual int? FID 
	  { 
	     get{return _FID;}
	     set{_FID=value;}
	  }
	
      /// <summary>
      /// 人员名称
      /// </summary>
	  [DataMember]
	  public virtual string FK_EmpText 
	  { 
	     get{return _FK_EmpText;}
	     set{_FK_EmpText=value;}
	  }
	
      /// <summary>
      /// 节点名称
      /// </summary>
	  [DataMember]
	  public virtual string FK_NodeText 
	  { 
	     get{return _FK_NodeText;}
	     set{_FK_NodeText=value;}
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
      /// 使用部门
      /// </summary>
	  [DataMember]
	  public virtual string FK_Dept 
	  { 
	     get{return _FK_Dept;}
	     set{_FK_Dept=value;}
	  }
	
      /// <summary>
      /// 应完成日期
      /// </summary>
	  [DataMember]
	  public virtual string SDT 
	  { 
	     get{return _SDT;}
	     set{_SDT=value;}
	  }
	
      /// <summary>
      /// 警告日期
      /// </summary>
	  [DataMember]
	  public virtual string DTOfWarning 
	  { 
	     get{return _DTOfWarning;}
	     set{_DTOfWarning=value;}
	  }
	
      /// <summary>
      /// 记录时间
      /// </summary>
	  [DataMember]
	  public virtual string RDT 
	  { 
	     get{return _RDT;}
	     set{_RDT=value;}
	  }
	
      /// <summary>
      /// 完成时间
      /// </summary>
	  [DataMember]
	  public virtual string CDT 
	  { 
	     get{return _CDT;}
	     set{_CDT=value;}
	  }
	
      /// <summary>
      /// 是否可用
      /// </summary>
	  [DataMember]
	  public virtual int? IsEnable 
	  { 
	     get{return _IsEnable;}
	     set{_IsEnable=value;}
	  }
	
      /// <summary>
      /// 是否读取
      /// </summary>
	  [DataMember]
	  public virtual int? IsRead 
	  { 
	     get{return _IsRead;}
	     set{_IsRead=value;}
	  }
	
      /// <summary>
      /// 是否通过(对合流节点有效)
      /// </summary>
	  [DataMember]
	  public virtual int? IsPass 
	  { 
	     get{return _IsPass;}
	     set{_IsPass=value;}
	  }
	
      /// <summary>
      /// 谁执行它
      /// </summary>
	  [DataMember]
	  public virtual int? WhoExeIt 
	  { 
	     get{return _WhoExeIt;}
	     set{_WhoExeIt=value;}
	  }
	
      /// <summary>
      /// 发送人
      /// </summary>
	  [DataMember]
	  public virtual string Sender 
	  { 
	     get{return _Sender;}
	     set{_Sender=value;}
	  }
	
      /// <summary>
      /// 优先级
      /// </summary>
	  [DataMember]
	  public virtual int? PRI 
	  { 
	     get{return _PRI;}
	     set{_PRI=value;}
	  }
	
      /// <summary>
      /// 催办次数
      /// </summary>
	  [DataMember]
	  public virtual int? PressTimes 
	  { 
	     get{return _PressTimes;}
	     set{_PressTimes=value;}
	  }
	
      /// <summary>
      /// 挂起时间
      /// </summary>
	  [DataMember]
	  public virtual string DTOfHungUp 
	  { 
	     get{return _DTOfHungUp;}
	     set{_DTOfHungUp=value;}
	  }
	
      /// <summary>
      /// 预计解除挂起时间
      /// </summary>
	  [DataMember]
	  public virtual string DTOfUnHungUp 
	  { 
	     get{return _DTOfUnHungUp;}
	     set{_DTOfUnHungUp=value;}
	  }
	
      /// <summary>
      /// 挂起次数
      /// </summary>
	  [DataMember]
	  public virtual int? HungUpTimes 
	  { 
	     get{return _HungUpTimes;}
	     set{_HungUpTimes=value;}
	  }
	
      /// <summary>
      /// 外部用户编号
      /// </summary>
	  [DataMember]
	  public virtual string GuestNo 
	  { 
	     get{return _GuestNo;}
	     set{_GuestNo=value;}
	  }
	
      /// <summary>
      /// 外部用户名称
      /// </summary>
	  [DataMember]
	  public virtual string GuestName 
	  { 
	     get{return _GuestName;}
	     set{_GuestName=value;}
	  }
	
      /// <summary>
      /// AtPara
      /// </summary>
	  [DataMember]
	  public virtual string AtPara 
	  { 
	     get{return _AtPara;}
	     set{_AtPara=value;}
	  }



        public override bool Equals(object obj)
        {
            var second = obj as WF_GenerWorkerList;
            return this.WorkID == second.WorkID && this.FK_Node == second.FK_Node && this.FK_Emp == second.FK_Emp;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_GenerWorkerListMap : ClassMap<WF_GenerWorkerList>
    {
        public WF_GenerWorkerListMap()
        {
            CompositeId().KeyProperty(x => x.WorkID, "WorkID").KeyProperty(x => x.FK_Node, "FK_Node").KeyProperty(x => x.FK_Emp, "FK_Emp");

            //Id(m => m.WorkID).GeneratedBy.SequenceIdentity();
            //		 Map(m => m.FK_Emp);
            //       	 Map(m => m.FK_Node);
            Map(m => m.FID);
	        	 Map(m => m.FK_EmpText);
	        	 Map(m => m.FK_NodeText);
	        	 Map(m => m.FK_Flow);
	        	 Map(m => m.FK_Dept);
	        	 Map(m => m.SDT);
	        	 Map(m => m.DTOfWarning);
	        	 Map(m => m.RDT);
	        	 Map(m => m.CDT);
	        	 Map(m => m.IsEnable);
	        	 Map(m => m.IsRead);
	        	 Map(m => m.IsPass);
	        	 Map(m => m.WhoExeIt);
	        	 Map(m => m.Sender);
	        	 Map(m => m.PRI);
	        	 Map(m => m.PressTimes);
	        	 Map(m => m.DTOfHungUp);
	        	 Map(m => m.DTOfUnHungUp);
	        	 Map(m => m.HungUpTimes);
	        	 Map(m => m.GuestNo);
	        	 Map(m => m.GuestName);
	        	 Map(m => m.AtPara);
	        		
						     }
    }
}

