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
    /// 流程实例
    /// </summary>
    public partial class WF_GenerWorkFlow : BaseEntity,ICloneable
    {
		private int _WorkID=0;
		private int? _FID=null;
		private string _FK_FlowSort=null;
		private string _SysType=null;
		private string _FK_Flow=null;
		private string _FlowName=null;
		private string _Title=null;
		private int? _WFSta=null;
		private int? _WFState=null;
		private string _Starter=null;
		private string _StarterName=null;
		private string _Sender=null;
		private string _RDT=null;
		private string _SendDT=null;
		private int? _FK_Node=null;
		private string _NodeName=null;
		private string _FK_Dept=null;
		private string _DeptName=null;
		private int? _PRI=null;
		private string _SDTOfNode=null;
		private string _SDTOfFlow=null;
		private string _PFlowNo=null;
		private int? _PWorkID=null;
		private int? _PNodeID=null;
		private int? _PFID=null;
		private string _PEmp=null;
		private string _GuestNo=null;
		private string _GuestName=null;
		private string _BillNo=null;
		private string _FlowNote=null;
		private string _TodoEmps=null;
		private int? _TodoEmpsNum=null;
		private int? _TaskSta=null;
		private string _AtPara=null;
		private string _Emps=null;
		private string _GUID=null;
		private string _FK_NY=null;
		private int? _WeekNum=null;
		private int? _TSpan=null;
		private int? _TodoSta=null;
		private string _Domain=null;
		private int? _MyNum=null;
		private string _YWH=null;
	
	
      /// <summary>
      /// WorkID
      /// </summary>
	  [DataMember]
	  public virtual int WorkID 
	  { 
	     get{return _WorkID;}
	     set{_WorkID=value;}
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
      /// 类别,
      /// </summary>
	  [DataMember]
	  public virtual string FK_FlowSort 
	  { 
	     get{return _FK_FlowSort;}
	     set{_FK_FlowSort=value;}
	  }
	
      /// <summary>
      /// 系统类别
      /// </summary>
	  [DataMember]
	  public virtual string SysType 
	  { 
	     get{return _SysType;}
	     set{_SysType=value;}
	  }
	
      /// <summary>
      /// 流程,
      /// </summary>
	  [DataMember]
	  public virtual string FK_Flow 
	  { 
	     get{return _FK_Flow;}
	     set{_FK_Flow=value;}
	  }
	
      /// <summary>
      /// 流程名称
      /// </summary>
	  [DataMember]
	  public virtual string FlowName 
	  { 
	     get{return _FlowName;}
	     set{_FlowName=value;}
	  }
	
      /// <summary>
      /// 标题
      /// </summary>
	  [DataMember]
	  public virtual string Title 
	  { 
	     get{return _Title;}
	     set{_Title=value;}
	  }
	
      /// <summary>
      /// 流程状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? WFSta 
	  { 
	     get{return _WFSta;}
	     set{_WFSta=value;}
	  }
	
      /// <summary>
      /// 流程状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? WFState 
	  { 
	     get{return _WFState;}
	     set{_WFState=value;}
	  }
	
      /// <summary>
      /// 发起人
      /// </summary>
	  [DataMember]
	  public virtual string Starter 
	  { 
	     get{return _Starter;}
	     set{_Starter=value;}
	  }
	
      /// <summary>
      /// 发起人
      /// </summary>
	  [DataMember]
	  public virtual string StarterName 
	  { 
	     get{return _StarterName;}
	     set{_StarterName=value;}
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
      /// 记录日期
      /// </summary>
	  [DataMember]
	  public virtual string RDT 
	  { 
	     get{return _RDT;}
	     set{_RDT=value;}
	  }
	
      /// <summary>
      /// 流程活动时间
      /// </summary>
	  [DataMember]
	  public virtual string SendDT 
	  { 
	     get{return _SendDT;}
	     set{_SendDT=value;}
	  }
	
      /// <summary>
      /// 节点
      /// </summary>
	  [DataMember]
	  public virtual int? FK_Node 
	  { 
	     get{return _FK_Node;}
	     set{_FK_Node=value;}
	  }
	
      /// <summary>
      /// 当前节点名称
      /// </summary>
	  [DataMember]
	  public virtual string NodeName 
	  { 
	     get{return _NodeName;}
	     set{_NodeName=value;}
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
	
      /// <summary>
      /// 部门名称
      /// </summary>
	  [DataMember]
	  public virtual string DeptName 
	  { 
	     get{return _DeptName;}
	     set{_DeptName=value;}
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
      /// 节点应完成时间
      /// </summary>
	  [DataMember]
	  public virtual string SDTOfNode 
	  { 
	     get{return _SDTOfNode;}
	     set{_SDTOfNode=value;}
	  }
	
      /// <summary>
      /// 流程应完成时间
      /// </summary>
	  [DataMember]
	  public virtual string SDTOfFlow 
	  { 
	     get{return _SDTOfFlow;}
	     set{_SDTOfFlow=value;}
	  }
	
      /// <summary>
      /// 父流程编号
      /// </summary>
	  [DataMember]
	  public virtual string PFlowNo 
	  { 
	     get{return _PFlowNo;}
	     set{_PFlowNo=value;}
	  }
	
      /// <summary>
      /// 父流程ID
      /// </summary>
	  [DataMember]
	  public virtual int? PWorkID 
	  { 
	     get{return _PWorkID;}
	     set{_PWorkID=value;}
	  }
	
      /// <summary>
      /// 父流程调用节点
      /// </summary>
	  [DataMember]
	  public virtual int? PNodeID 
	  { 
	     get{return _PNodeID;}
	     set{_PNodeID=value;}
	  }
	
      /// <summary>
      /// 父流程调用的PFID
      /// </summary>
	  [DataMember]
	  public virtual int? PFID 
	  { 
	     get{return _PFID;}
	     set{_PFID=value;}
	  }
	
      /// <summary>
      /// 子流程的调用人
      /// </summary>
	  [DataMember]
	  public virtual string PEmp 
	  { 
	     get{return _PEmp;}
	     set{_PEmp=value;}
	  }
	
      /// <summary>
      /// 客户编号
      /// </summary>
	  [DataMember]
	  public virtual string GuestNo 
	  { 
	     get{return _GuestNo;}
	     set{_GuestNo=value;}
	  }
	
      /// <summary>
      /// 客户名称
      /// </summary>
	  [DataMember]
	  public virtual string GuestName 
	  { 
	     get{return _GuestName;}
	     set{_GuestName=value;}
	  }
	
      /// <summary>
      /// 单据编号
      /// </summary>
	  [DataMember]
	  public virtual string BillNo 
	  { 
	     get{return _BillNo;}
	     set{_BillNo=value;}
	  }
	
      /// <summary>
      /// 备注
      /// </summary>
	  [DataMember]
	  public virtual string FlowNote 
	  { 
	     get{return _FlowNote;}
	     set{_FlowNote=value;}
	  }
	
      /// <summary>
      /// 待办人员
      /// </summary>
	  [DataMember]
	  public virtual string TodoEmps 
	  { 
	     get{return _TodoEmps;}
	     set{_TodoEmps=value;}
	  }
	
      /// <summary>
      /// 待办人员数量
      /// </summary>
	  [DataMember]
	  public virtual int? TodoEmpsNum 
	  { 
	     get{return _TodoEmpsNum;}
	     set{_TodoEmpsNum=value;}
	  }
	
      /// <summary>
      /// 共享状态
      /// </summary>
	  [DataMember]
	  public virtual int? TaskSta 
	  { 
	     get{return _TaskSta;}
	     set{_TaskSta=value;}
	  }
	
      /// <summary>
      /// 参数(流程运行设置临时存储的参数)
      /// </summary>
	  [DataMember]
	  public virtual string AtPara 
	  { 
	     get{return _AtPara;}
	     set{_AtPara=value;}
	  }
	
      /// <summary>
      /// 参与人
      /// </summary>
	  [DataMember]
	  public virtual string Emps 
	  { 
	     get{return _Emps;}
	     set{_Emps=value;}
	  }
	
      /// <summary>
      /// GUID
      /// </summary>
	  [DataMember]
	  public virtual string GUID 
	  { 
	     get{return _GUID;}
	     set{_GUID=value;}
	  }
	
      /// <summary>
      /// 月份,
      /// </summary>
	  [DataMember]
	  public virtual string FK_NY 
	  { 
	     get{return _FK_NY;}
	     set{_FK_NY=value;}
	  }
	
      /// <summary>
      /// 周次
      /// </summary>
	  [DataMember]
	  public virtual int? WeekNum 
	  { 
	     get{return _WeekNum;}
	     set{_WeekNum=value;}
	  }
	
      /// <summary>
      /// 时间间隔
      /// </summary>
	  [DataMember]
	  public virtual int? TSpan 
	  { 
	     get{return _TSpan;}
	     set{_TSpan=value;}
	  }
	
      /// <summary>
      /// 待办状态
      /// </summary>
	  [DataMember]
	  public virtual int? TodoSta 
	  { 
	     get{return _TodoSta;}
	     set{_TodoSta=value;}
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
      /// 个数
      /// </summary>
	  [DataMember]
	  public virtual int? MyNum 
	  { 
	     get{return _MyNum;}
	     set{_MyNum=value;}
	  }
	
      /// <summary>
      /// YWH
      /// </summary>
	  [DataMember]
	  public virtual string YWH 
	  { 
	     get{return _YWH;}
	     set{_YWH=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_GenerWorkFlowMap : ClassMap<WF_GenerWorkFlow>
    {
        public WF_GenerWorkFlowMap()
        {
		Id(m => m.WorkID).GeneratedBy.SequenceIdentity();
				 Map(m => m.FID);
	        	 Map(m => m.FK_FlowSort);
	        	 Map(m => m.SysType);
	        	 Map(m => m.FK_Flow);
	        	 Map(m => m.FlowName);
	        	 Map(m => m.Title);
	        	 Map(m => m.WFSta);
	        	 Map(m => m.WFState);
	        	 Map(m => m.Starter);
	        	 Map(m => m.StarterName);
	        	 Map(m => m.Sender);
	        	 Map(m => m.RDT);
	        	 Map(m => m.SendDT);
	        	 Map(m => m.FK_Node);
	        	 Map(m => m.NodeName);
	        	 Map(m => m.FK_Dept);
	        	 Map(m => m.DeptName);
	        	 Map(m => m.PRI);
	        	 Map(m => m.SDTOfNode);
	        	 Map(m => m.SDTOfFlow);
	        	 Map(m => m.PFlowNo);
	        	 Map(m => m.PWorkID);
	        	 Map(m => m.PNodeID);
	        	 Map(m => m.PFID);
	        	 Map(m => m.PEmp);
	        	 Map(m => m.GuestNo);
	        	 Map(m => m.GuestName);
	        	 Map(m => m.BillNo);
	        	 Map(m => m.FlowNote);
	        	 Map(m => m.TodoEmps);
	        	 Map(m => m.TodoEmpsNum);
	        	 Map(m => m.TaskSta);
	        	 Map(m => m.AtPara);
	        	 Map(m => m.Emps);
	        	 Map(m => m.GUID);
	        	 Map(m => m.FK_NY);
	        	 Map(m => m.WeekNum);
	        	 Map(m => m.TSpan);
	        	 Map(m => m.TodoSta);
	        	 Map(m => m.Domain);
	        	 Map(m => m.MyNum);
	        	 Map(m => m.YWH);
	        		
						     }
    }
}

