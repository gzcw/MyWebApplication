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
    /// 报表定义
    /// </summary>
    public partial class WF_Flow : BaseEntity,ICloneable
    {
		private string _No=null;
		private string _FK_FlowSort=null;
		private string _Name=null;
		private string _FlowMark=null;
		private string _FlowEventEntity=null;
		private string _TitleRole=null;
		private int? _IsCanStart=null;
		private int? _IsFullSA=null;
		private int? _IsAutoSendSubFlowOver=null;
		private int? _IsGuestFlow=null;
		private int? _FlowAppType=null;
		private int? _TimelineRole=null;
		private int? _Draft=null;
		private int? _FlowDeleteRole=null;
		private string _HelpUrl=null;
		private string _SysType=null;
		private string _Tester=null;
		private string _NodeAppType=null;
		private string _NodeAppTypeText=null;
		private int? _ChartType=null;
		private string _HostRun=null;
		private int? _IsBatchStart=null;
		private string _BatchStartFields=null;
		private string _HistoryFields=null;
		private int? _IsResetData=null;
		private int? _IsLoadPriData=null;
		private int? _IsDBTemplate=null;
		private int? _IsStartInMobile=null;
		private int? _IsMD5=null;
		private int? _DataStoreModel=null;
		private string _PTable=null;
		private string _FlowNoteExp=null;
		private string _BillNoFormat=null;
		private string _DesignerNo=null;
		private string _DesignerName=null;
		private string _DesignTime=null;
		private string _Note=null;
		private int? _FlowRunWay=null;
		private string _RunObj=null;
		private string _RunSQL=null;
		private int? _NumOfBill=null;
		private int? _NumOfDtl=null;
		private decimal? _AvgDay=null;
		private int? _Idx=null;
		private string _Paras=null;
		private int? _DRCtrlType=null;
		private int? _StartLimitRole=null;
		private string _StartLimitPara=null;
		private string _StartLimitAlert=null;
		private int? _StartLimitWhen=null;
		private int? _StartGuideWay=null;
		private string _StartGuideLink=null;
		private string _StartGuideLab=null;
		private string _StartGuidePara1=null;
		private string _StartGuidePara2=null;
		private string _StartGuidePara3=null;
		private string _Ver=null;
		private string _AtPara=null;
		private int? _DTSWay=null;
		private string _DTSDBSrc=null;
		private string _DTSBTable=null;
		private string _DTSBTablePK=null;
		private int? _DTSTime=null;
		private string _DTSSpecNodes=null;
		private int? _DTSField=null;
		private string _DTSFields=null;
		private int? _PStarter=null;
		private int? _PWorker=null;
		private int? _PCCer=null;
		private int? _PMyDept=null;
		private int? _PPMyDept=null;
		private int? _PPDept=null;
		private int? _PSameDept=null;
		private int? _PSpecDept=null;
		private string _PSpecDeptExt=null;
		private int? _PSpecSta=null;
		private string _PSpecStaExt=null;
		private int? _PSpecGroup=null;
		private string _PSpecGroupExt=null;
		private int? _PSpecEmp=null;
		private string _PSpecEmpExt=null;
		private int? _MyDeptRole=null;
		private string _BHID=null;
	
	
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
      /// 流程类别,
      /// </summary>
	  [DataMember]
	  public virtual string FK_FlowSort 
	  { 
	     get{return _FK_FlowSort;}
	     set{_FK_FlowSort=value;}
	  }
	
      /// <summary>
      /// 流程名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 流程标记
      /// </summary>
	  [DataMember]
	  public virtual string FlowMark 
	  { 
	     get{return _FlowMark;}
	     set{_FlowMark=value;}
	  }
	
      /// <summary>
      /// 流程事件实体
      /// </summary>
	  [DataMember]
	  public virtual string FlowEventEntity 
	  { 
	     get{return _FlowEventEntity;}
	     set{_FlowEventEntity=value;}
	  }
	
      /// <summary>
      /// 标题生成规则
      /// </summary>
	  [DataMember]
	  public virtual string TitleRole 
	  { 
	     get{return _TitleRole;}
	     set{_TitleRole=value;}
	  }
	
      /// <summary>
      /// 可以独立启动否？(独立启动的流程可以显示在发起流程列表里)
      /// </summary>
	  [DataMember]
	  public virtual int? IsCanStart 
	  { 
	     get{return _IsCanStart;}
	     set{_IsCanStart=value;}
	  }
	
      /// <summary>
      /// 是否自动计算未来的处理人？
      /// </summary>
	  [DataMember]
	  public virtual int? IsFullSA 
	  { 
	     get{return _IsFullSA;}
	     set{_IsFullSA=value;}
	  }
	
      /// <summary>
      /// 为子流程时结束规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? IsAutoSendSubFlowOver 
	  { 
	     get{return _IsAutoSendSubFlowOver;}
	     set{_IsAutoSendSubFlowOver=value;}
	  }
	
      /// <summary>
      /// 是否外部用户参与流程(非组织结构人员参与的流程)
      /// </summary>
	  [DataMember]
	  public virtual int? IsGuestFlow 
	  { 
	     get{return _IsGuestFlow;}
	     set{_IsGuestFlow=value;}
	  }
	
      /// <summary>
      /// 流程应用类型,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? FlowAppType 
	  { 
	     get{return _FlowAppType;}
	     set{_FlowAppType=value;}
	  }
	
      /// <summary>
      /// 时效性规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? TimelineRole 
	  { 
	     get{return _TimelineRole;}
	     set{_TimelineRole=value;}
	  }
	
      /// <summary>
      /// 草稿规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? Draft 
	  { 
	     get{return _Draft;}
	     set{_Draft=value;}
	  }
	
      /// <summary>
      /// 流程实例删除规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? FlowDeleteRole 
	  { 
	     get{return _FlowDeleteRole;}
	     set{_FlowDeleteRole=value;}
	  }
	
      /// <summary>
      /// 帮助文档
      /// </summary>
	  [DataMember]
	  public virtual string HelpUrl 
	  { 
	     get{return _HelpUrl;}
	     set{_HelpUrl=value;}
	  }
	
      /// <summary>
      /// 系统类型
      /// </summary>
	  [DataMember]
	  public virtual string SysType 
	  { 
	     get{return _SysType;}
	     set{_SysType=value;}
	  }
	
      /// <summary>
      /// 发起测试人
      /// </summary>
	  [DataMember]
	  public virtual string Tester 
	  { 
	     get{return _Tester;}
	     set{_Tester=value;}
	  }
	
      /// <summary>
      /// 业务类型枚举(可为Null)
      /// </summary>
	  [DataMember]
	  public virtual string NodeAppType 
	  { 
	     get{return _NodeAppType;}
	     set{_NodeAppType=value;}
	  }
	
      /// <summary>
      /// 业务类型枚举(可为Null)
      /// </summary>
	  [DataMember]
	  public virtual string NodeAppTypeText 
	  { 
	     get{return _NodeAppTypeText;}
	     set{_NodeAppTypeText=value;}
	  }
	
      /// <summary>
      /// 节点图形类型,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? ChartType 
	  { 
	     get{return _ChartType;}
	     set{_ChartType=value;}
	  }
	
      /// <summary>
      /// 运行主机(IP+端口)
      /// </summary>
	  [DataMember]
	  public virtual string HostRun 
	  { 
	     get{return _HostRun;}
	     set{_HostRun=value;}
	  }
	
      /// <summary>
      /// 是否可以批量发起流程？(如果是就要设置发起的需要填写的字段,多个用逗号分开)
      /// </summary>
	  [DataMember]
	  public virtual int? IsBatchStart 
	  { 
	     get{return _IsBatchStart;}
	     set{_IsBatchStart=value;}
	  }
	
      /// <summary>
      /// 发起字段s
      /// </summary>
	  [DataMember]
	  public virtual string BatchStartFields 
	  { 
	     get{return _BatchStartFields;}
	     set{_BatchStartFields=value;}
	  }
	
      /// <summary>
      /// 历史查看字段
      /// </summary>
	  [DataMember]
	  public virtual string HistoryFields 
	  { 
	     get{return _HistoryFields;}
	     set{_HistoryFields=value;}
	  }
	
      /// <summary>
      /// 是否启用开始节点数据重置按钮？
      /// </summary>
	  [DataMember]
	  public virtual int? IsResetData 
	  { 
	     get{return _IsResetData;}
	     set{_IsResetData=value;}
	  }
	
      /// <summary>
      /// 是否自动装载上一笔数据？
      /// </summary>
	  [DataMember]
	  public virtual int? IsLoadPriData 
	  { 
	     get{return _IsLoadPriData;}
	     set{_IsLoadPriData=value;}
	  }
	
      /// <summary>
      /// 是否启用数据模版？
      /// </summary>
	  [DataMember]
	  public virtual int? IsDBTemplate 
	  { 
	     get{return _IsDBTemplate;}
	     set{_IsDBTemplate=value;}
	  }
	
      /// <summary>
      /// 是否可以在手机里启用？(如果发起表单特别复杂就不要在手机里启用了)
      /// </summary>
	  [DataMember]
	  public virtual int? IsStartInMobile 
	  { 
	     get{return _IsStartInMobile;}
	     set{_IsStartInMobile=value;}
	  }
	
      /// <summary>
      /// 是否是数据加密流程(MD5数据加密防篡改)
      /// </summary>
	  [DataMember]
	  public virtual int? IsMD5 
	  { 
	     get{return _IsMD5;}
	     set{_IsMD5=value;}
	  }
	
      /// <summary>
      /// 流程数据存储模式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? DataStoreModel 
	  { 
	     get{return _DataStoreModel;}
	     set{_DataStoreModel=value;}
	  }
	
      /// <summary>
      /// 流程数据存储表
      /// </summary>
	  [DataMember]
	  public virtual string PTable 
	  { 
	     get{return _PTable;}
	     set{_PTable=value;}
	  }
	
      /// <summary>
      /// 备注的表达式
      /// </summary>
	  [DataMember]
	  public virtual string FlowNoteExp 
	  { 
	     get{return _FlowNoteExp;}
	     set{_FlowNoteExp=value;}
	  }
	
      /// <summary>
      /// 单据编号格式
      /// </summary>
	  [DataMember]
	  public virtual string BillNoFormat 
	  { 
	     get{return _BillNoFormat;}
	     set{_BillNoFormat=value;}
	  }
	
      /// <summary>
      /// 设计者编号
      /// </summary>
	  [DataMember]
	  public virtual string DesignerNo 
	  { 
	     get{return _DesignerNo;}
	     set{_DesignerNo=value;}
	  }
	
      /// <summary>
      /// 设计者名称
      /// </summary>
	  [DataMember]
	  public virtual string DesignerName 
	  { 
	     get{return _DesignerName;}
	     set{_DesignerName=value;}
	  }
	
      /// <summary>
      /// 创建时间
      /// </summary>
	  [DataMember]
	  public virtual string DesignTime 
	  { 
	     get{return _DesignTime;}
	     set{_DesignTime=value;}
	  }
	
      /// <summary>
      /// 流程描述
      /// </summary>
	  [DataMember]
	  public virtual string Note 
	  { 
	     get{return _Note;}
	     set{_Note=value;}
	  }
	
      /// <summary>
      /// 启动方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? FlowRunWay 
	  { 
	     get{return _FlowRunWay;}
	     set{_FlowRunWay=value;}
	  }
	
      /// <summary>
      /// 运行内容
      /// </summary>
	  [DataMember]
	  public virtual string RunObj 
	  { 
	     get{return _RunObj;}
	     set{_RunObj=value;}
	  }
	
      /// <summary>
      /// 流程结束执行后执行的SQL
      /// </summary>
	  [DataMember]
	  public virtual string RunSQL 
	  { 
	     get{return _RunSQL;}
	     set{_RunSQL=value;}
	  }
	
      /// <summary>
      /// 是否有单据
      /// </summary>
	  [DataMember]
	  public virtual int? NumOfBill 
	  { 
	     get{return _NumOfBill;}
	     set{_NumOfBill=value;}
	  }
	
      /// <summary>
      /// NumOfDtl
      /// </summary>
	  [DataMember]
	  public virtual int? NumOfDtl 
	  { 
	     get{return _NumOfDtl;}
	     set{_NumOfDtl=value;}
	  }
	
      /// <summary>
      /// 平均运行用天
      /// </summary>
	  [DataMember]
	  public virtual decimal? AvgDay 
	  { 
	     get{return _AvgDay;}
	     set{_AvgDay=value;}
	  }
	
      /// <summary>
      /// 显示顺序号(在发起列表中)
      /// </summary>
	  [DataMember]
	  public virtual int? Idx 
	  { 
	     get{return _Idx;}
	     set{_Idx=value;}
	  }
	
      /// <summary>
      /// 参数
      /// </summary>
	  [DataMember]
	  public virtual string Paras 
	  { 
	     get{return _Paras;}
	     set{_Paras=value;}
	  }
	
      /// <summary>
      /// 部门查询权限控制方式
      /// </summary>
	  [DataMember]
	  public virtual int? DRCtrlType 
	  { 
	     get{return _DRCtrlType;}
	     set{_DRCtrlType=value;}
	  }
	
      /// <summary>
      /// 启动限制规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? StartLimitRole 
	  { 
	     get{return _StartLimitRole;}
	     set{_StartLimitRole=value;}
	  }
	
      /// <summary>
      /// 规则参数
      /// </summary>
	  [DataMember]
	  public virtual string StartLimitPara 
	  { 
	     get{return _StartLimitPara;}
	     set{_StartLimitPara=value;}
	  }
	
      /// <summary>
      /// 限制提示
      /// </summary>
	  [DataMember]
	  public virtual string StartLimitAlert 
	  { 
	     get{return _StartLimitAlert;}
	     set{_StartLimitAlert=value;}
	  }
	
      /// <summary>
      /// 提示时间
      /// </summary>
	  [DataMember]
	  public virtual int? StartLimitWhen 
	  { 
	     get{return _StartLimitWhen;}
	     set{_StartLimitWhen=value;}
	  }
	
      /// <summary>
      /// 前置导航方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? StartGuideWay 
	  { 
	     get{return _StartGuideWay;}
	     set{_StartGuideWay=value;}
	  }
	
      /// <summary>
      /// 右侧的连接
      /// </summary>
	  [DataMember]
	  public virtual string StartGuideLink 
	  { 
	     get{return _StartGuideLink;}
	     set{_StartGuideLink=value;}
	  }
	
      /// <summary>
      /// 连接标签
      /// </summary>
	  [DataMember]
	  public virtual string StartGuideLab 
	  { 
	     get{return _StartGuideLab;}
	     set{_StartGuideLab=value;}
	  }
	
      /// <summary>
      /// 参数1
      /// </summary>
	  [DataMember]
	  public virtual string StartGuidePara1 
	  { 
	     get{return _StartGuidePara1;}
	     set{_StartGuidePara1=value;}
	  }
	
      /// <summary>
      /// 参数2
      /// </summary>
	  [DataMember]
	  public virtual string StartGuidePara2 
	  { 
	     get{return _StartGuidePara2;}
	     set{_StartGuidePara2=value;}
	  }
	
      /// <summary>
      /// 参数3
      /// </summary>
	  [DataMember]
	  public virtual string StartGuidePara3 
	  { 
	     get{return _StartGuidePara3;}
	     set{_StartGuidePara3=value;}
	  }
	
      /// <summary>
      /// 版本号
      /// </summary>
	  [DataMember]
	  public virtual string Ver 
	  { 
	     get{return _Ver;}
	     set{_Ver=value;}
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
	
      /// <summary>
      /// 同步方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? DTSWay 
	  { 
	     get{return _DTSWay;}
	     set{_DTSWay=value;}
	  }
	
      /// <summary>
      /// 数据库,
      /// </summary>
	  [DataMember]
	  public virtual string DTSDBSrc 
	  { 
	     get{return _DTSDBSrc;}
	     set{_DTSDBSrc=value;}
	  }
	
      /// <summary>
      /// 业务表名
      /// </summary>
	  [DataMember]
	  public virtual string DTSBTable 
	  { 
	     get{return _DTSBTable;}
	     set{_DTSBTable=value;}
	  }
	
      /// <summary>
      /// 业务表主键
      /// </summary>
	  [DataMember]
	  public virtual string DTSBTablePK 
	  { 
	     get{return _DTSBTablePK;}
	     set{_DTSBTablePK=value;}
	  }
	
      /// <summary>
      /// 执行同步时间点,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? DTSTime 
	  { 
	     get{return _DTSTime;}
	     set{_DTSTime=value;}
	  }
	
      /// <summary>
      /// 指定的节点ID
      /// </summary>
	  [DataMember]
	  public virtual string DTSSpecNodes 
	  { 
	     get{return _DTSSpecNodes;}
	     set{_DTSSpecNodes=value;}
	  }
	
      /// <summary>
      /// 要同步的字段计算方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? DTSField 
	  { 
	     get{return _DTSField;}
	     set{_DTSField=value;}
	  }
	
      /// <summary>
      /// 要同步的字段s,中间用逗号分开.
      /// </summary>
	  [DataMember]
	  public virtual string DTSFields 
	  { 
	     get{return _DTSFields;}
	     set{_DTSFields=value;}
	  }
	
      /// <summary>
      /// 发起人可看(必选)
      /// </summary>
	  [DataMember]
	  public virtual int? PStarter 
	  { 
	     get{return _PStarter;}
	     set{_PStarter=value;}
	  }
	
      /// <summary>
      /// 参与人可看(必选)
      /// </summary>
	  [DataMember]
	  public virtual int? PWorker 
	  { 
	     get{return _PWorker;}
	     set{_PWorker=value;}
	  }
	
      /// <summary>
      /// 被抄送人可看(必选)
      /// </summary>
	  [DataMember]
	  public virtual int? PCCer 
	  { 
	     get{return _PCCer;}
	     set{_PCCer=value;}
	  }
	
      /// <summary>
      /// 本部门人可看
      /// </summary>
	  [DataMember]
	  public virtual int? PMyDept 
	  { 
	     get{return _PMyDept;}
	     set{_PMyDept=value;}
	  }
	
      /// <summary>
      /// 直属上级部门可看(比如:我是)
      /// </summary>
	  [DataMember]
	  public virtual int? PPMyDept 
	  { 
	     get{return _PPMyDept;}
	     set{_PPMyDept=value;}
	  }
	
      /// <summary>
      /// 上级部门可看
      /// </summary>
	  [DataMember]
	  public virtual int? PPDept 
	  { 
	     get{return _PPDept;}
	     set{_PPDept=value;}
	  }
	
      /// <summary>
      /// 平级部门可看
      /// </summary>
	  [DataMember]
	  public virtual int? PSameDept 
	  { 
	     get{return _PSameDept;}
	     set{_PSameDept=value;}
	  }
	
      /// <summary>
      /// 指定部门可看
      /// </summary>
	  [DataMember]
	  public virtual int? PSpecDept 
	  { 
	     get{return _PSpecDept;}
	     set{_PSpecDept=value;}
	  }
	
      /// <summary>
      /// 部门编号
      /// </summary>
	  [DataMember]
	  public virtual string PSpecDeptExt 
	  { 
	     get{return _PSpecDeptExt;}
	     set{_PSpecDeptExt=value;}
	  }
	
      /// <summary>
      /// 指定的岗位可看
      /// </summary>
	  [DataMember]
	  public virtual int? PSpecSta 
	  { 
	     get{return _PSpecSta;}
	     set{_PSpecSta=value;}
	  }
	
      /// <summary>
      /// 岗位编号
      /// </summary>
	  [DataMember]
	  public virtual string PSpecStaExt 
	  { 
	     get{return _PSpecStaExt;}
	     set{_PSpecStaExt=value;}
	  }
	
      /// <summary>
      /// 指定的权限组可看
      /// </summary>
	  [DataMember]
	  public virtual int? PSpecGroup 
	  { 
	     get{return _PSpecGroup;}
	     set{_PSpecGroup=value;}
	  }
	
      /// <summary>
      /// 权限组
      /// </summary>
	  [DataMember]
	  public virtual string PSpecGroupExt 
	  { 
	     get{return _PSpecGroupExt;}
	     set{_PSpecGroupExt=value;}
	  }
	
      /// <summary>
      /// 指定的人员可看
      /// </summary>
	  [DataMember]
	  public virtual int? PSpecEmp 
	  { 
	     get{return _PSpecEmp;}
	     set{_PSpecEmp=value;}
	  }
	
      /// <summary>
      /// 指定的人员编号
      /// </summary>
	  [DataMember]
	  public virtual string PSpecEmpExt 
	  { 
	     get{return _PSpecEmpExt;}
	     set{_PSpecEmpExt=value;}
	  }
	
      /// <summary>
      /// 本部门发起的流程,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int? MyDeptRole 
	  { 
	     get{return _MyDeptRole;}
	     set{_MyDeptRole=value;}
	  }
	
      /// <summary>
      /// BHID
      /// </summary>
	  [DataMember]
	  public virtual string BHID 
	  { 
	     get{return _BHID;}
	     set{_BHID=value;}
	  }
	
	
	
	
	  /// <summary>
      /// WF_Flow实体
      /// </summary>
	  public virtual WF_FlowSort WF_FlowSort
      {
         set;
         get;
      }
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_FlowMap : ClassMap<WF_Flow>
    {
        public WF_FlowMap()
        {
		Id(m => m.No).GeneratedBy.UuidHex("D");
				 Map(m => m.FK_FlowSort);
	        	 Map(m => m.Name);
	        	 Map(m => m.FlowMark);
	        	 Map(m => m.FlowEventEntity);
	        	 Map(m => m.TitleRole);
	        	 Map(m => m.IsCanStart);
	        	 Map(m => m.IsFullSA);
	        	 Map(m => m.IsAutoSendSubFlowOver);
	        	 Map(m => m.IsGuestFlow);
	        	 Map(m => m.FlowAppType);
	        	 Map(m => m.TimelineRole);
	        	 Map(m => m.Draft);
	        	 Map(m => m.FlowDeleteRole);
	        	 Map(m => m.HelpUrl);
	        	 Map(m => m.SysType);
	        	 Map(m => m.Tester);
	        	 Map(m => m.NodeAppType);
	        	 Map(m => m.NodeAppTypeText);
	        	 Map(m => m.ChartType);
	        	 Map(m => m.HostRun);
	        	 Map(m => m.IsBatchStart);
	        	 Map(m => m.BatchStartFields);
	        	 Map(m => m.HistoryFields);
	        	 Map(m => m.IsResetData);
	        	 Map(m => m.IsLoadPriData);
	        	 Map(m => m.IsDBTemplate);
	        	 Map(m => m.IsStartInMobile);
	        	 Map(m => m.IsMD5);
	        	 Map(m => m.DataStoreModel);
	        	 Map(m => m.PTable);
	        	 Map(m => m.FlowNoteExp);
	        	 Map(m => m.BillNoFormat);
	        	 Map(m => m.DesignerNo);
	        	 Map(m => m.DesignerName);
	        	 Map(m => m.DesignTime);
	        	 Map(m => m.Note);
	        	 Map(m => m.FlowRunWay);
	        	 Map(m => m.RunObj);
	        	 Map(m => m.RunSQL);
	        	 Map(m => m.NumOfBill);
	        	 Map(m => m.NumOfDtl);
	        	 Map(m => m.AvgDay);
	        	 Map(m => m.Idx);
	        	 Map(m => m.Paras);
	        	 Map(m => m.DRCtrlType);
	        	 Map(m => m.StartLimitRole);
	        	 Map(m => m.StartLimitPara);
	        	 Map(m => m.StartLimitAlert);
	        	 Map(m => m.StartLimitWhen);
	        	 Map(m => m.StartGuideWay);
	        	 Map(m => m.StartGuideLink);
	        	 Map(m => m.StartGuideLab);
	        	 Map(m => m.StartGuidePara1);
	        	 Map(m => m.StartGuidePara2);
	        	 Map(m => m.StartGuidePara3);
	        	 Map(m => m.Ver);
	        	 Map(m => m.AtPara);
	        	 Map(m => m.DTSWay);
	        	 Map(m => m.DTSDBSrc);
	        	 Map(m => m.DTSBTable);
	        	 Map(m => m.DTSBTablePK);
	        	 Map(m => m.DTSTime);
	        	 Map(m => m.DTSSpecNodes);
	        	 Map(m => m.DTSField);
	        	 Map(m => m.DTSFields);
	        	 Map(m => m.PStarter);
	        	 Map(m => m.PWorker);
	        	 Map(m => m.PCCer);
	        	 Map(m => m.PMyDept);
	        	 Map(m => m.PPMyDept);
	        	 Map(m => m.PPDept);
	        	 Map(m => m.PSameDept);
	        	 Map(m => m.PSpecDept);
	        	 Map(m => m.PSpecDeptExt);
	        	 Map(m => m.PSpecSta);
	        	 Map(m => m.PSpecStaExt);
	        	 Map(m => m.PSpecGroup);
	        	 Map(m => m.PSpecGroupExt);
	        	 Map(m => m.PSpecEmp);
	        	 Map(m => m.PSpecEmpExt);
	        	 Map(m => m.MyDeptRole);
	        	 Map(m => m.BHID);
	        		
						References<WF_FlowSort>(r => r.WF_FlowSort).Column("FK_FlowSort").Not.Update().Not.Insert().LazyLoad();
	             }
    }
}

