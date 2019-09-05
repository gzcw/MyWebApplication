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
    /// 审核组件
    /// </summary>
    public partial class WF_Node : BaseEntity,ICloneable
    {
		private int _NodeID=0;
		private int _Step=0;
		private string _FK_Flow=null;
		private string _FlowName=null;
		private string _Name=null;
		private string _Tip=null;
		private int _WhoExeIt=0;
		private int _ReadReceipts=0;
		private int _CondModel=0;
		private int _CancelRole=0;
		private int _CancelDisWhenRead=0;
		private int _IsTask=0;
		private int _IsExpSender=0;
		private int _IsRM=0;
		private int _IsGuestNode=0;
		private string _DTFrom=null;
		private string _DTTo=null;
		private int _IsBUnit=0;
		private string _FocusField=null;
		private int _NodeAppType=0;
		private int _FWCSta=0;
		private string _SelfParas=null;
		private int _RunModel=0;
		private int _SubThreadType=0;
		private decimal _PassRate=0;
		private int _SubFlowStartWay=0;
		private string _SubFlowStartParas=null;
		private int _ThreadIsCanDel=0;
		private int _ThreadIsCanShift=0;
		private int _IsAllowRepeatEmps=0;
		private int _AutoRunEnable=0;
		private string _AutoRunParas=null;
		private int _AutoJumpRole0=0;
		private int _AutoJumpRole1=0;
		private int _AutoJumpRole2=0;
		private int _WhenNoWorker=0;
		private string _SendLab=null;
		private string _SendJS=null;
		private string _SaveLab=null;
		private int _SaveEnable=0;
		private string _ThreadLab=null;
		private int _ThreadEnable=0;
		private int _ThreadKillRole=0;
		private string _JumpWayLab=null;
		private int _JumpWay=0;
		private string _JumpToNodes=null;
		private string _ReturnLab=null;
		private int _ReturnRole=0;
		private string _ReturnAlert=null;
		private int _IsBackTracking=0;
		private string _ReturnField=null;
		private string _ReturnReasonsItems=null;
		private int _ReturnOneNodeRole=0;
		private string _CCLab=null;
		private int _CCRole=0;
		private int _CCWriteTo=0;
		private string _DoOutTime=null;
		private string _DoOutTimeCond=null;
		private string _ShiftLab=null;
		private int _ShiftEnable=0;
		private string _DelLab=null;
		private int _DelEnable=0;
		private string _EndFlowLab=null;
		private int _EndFlowEnable=0;
		private string _ShowParentFormLab=null;
		private int _ShowParentFormEnable=0;
		private string _OfficeBtnLab=null;
		private int _OfficeBtnEnable=0;
		private string _PrintHtmlLab=null;
		private int _PrintHtmlEnable=0;
		private string _PrintPDFLab=null;
		private int _PrintPDFEnable=0;
		private int _PrintPDFModle=0;
		private string _PrintZipLab=null;
		private int _PrintZipEnable=0;
		private string _PrintDocLab=null;
		private int _PrintDocEnable=0;
		private string _TrackLab=null;
		private int _TrackEnable=0;
		private string _HungLab=null;
		private int _HungEnable=0;
		private string _SearchLab=null;
		private int _SearchEnable=0;
		private string _WorkCheckLab=null;
		private int _WorkCheckEnable=0;
		private string _AskforLab=null;
		private int _AskforEnable=0;
		private string _HuiQianLab=null;
		private int _HuiQianRole=0;
		private string _TCLab=null;
		private int _TCEnable=0;
		private string _WebOffice=null;
		private int _WebOfficeEnable=0;
		private string _PRILab=null;
		private int _PRIEnable=0;
		private string _AllotLab=null;
		private int _AllotEnable=0;
		private string _FocusLab=null;
		private int _FocusEnable=0;
		private string _ConfirmLab=null;
		private int _ConfirmEnable=0;
		private string _ListLab=null;
		private int _ListEnable=0;
		private string _BatchLab=null;
		private int _BatchEnable=0;
		private decimal _TimeLimit=0;
		private int _TWay=0;
		private int _TAlertRole=0;
		private int _TAlertWay=0;
		private decimal _WarningDay=0;
		private int _WAlertRole=0;
		private int _WAlertWay=0;
		private decimal _TCent=0;
		private int _CHWay=0;
		private int _IsEval=0;
		private int _OutTimeDeal=0;
		private int _CCIsAttr=0;
		private string _CCFormAttr=null;
		private int _CCIsStations=0;
		private int _CCStaWay=0;
		private int _CCIsDepts=0;
		private int _CCIsEmps=0;
		private int _CCIsSQLs=0;
		private string _CCSQL=null;
		private string _CCTitle=null;
		private string _CCDoc=null;
		private string _FWCLab=null;
		private int _FWCShowModel=0;
		private int _FWCType=0;
		private string _FWCNodeName=null;
		private int _FWCAth=0;
		private int _FWCTrackEnable=0;
		private int _FWCListEnable=0;
		private int _FWCIsShowAllStep=0;
		private string _FWCOpLabel=null;
		private string _FWCDefInfo=null;
		private int _SigantureEnabel=0;
		private int _FWCIsFullInfo=0;
		private decimal _FWC_X=0;
		private decimal _FWC_Y=0;
		private decimal _FWC_H=0;
		private decimal _FWC_W=0;
		private string _FWCFields=null;
		private int _FWCIsShowTruck=0;
		private int _FWCIsShowReturnMsg=0;
		private int _FWCOrderModel=0;
		private int _FWCMsgShow=0;
		private string _ICON=null;
		private int _NodeWorkType=0;
		private string _FrmAttr=null;
		private string _Doc=null;
		private int _DeliveryWay=0;
		private string _DeliveryParas=null;
		private string _NodeFrmID=null;
		private int _SaveModel=0;
		private int _IsCanDelFlow=0;
		private int _TodolistModel=0;
		private int _TeamLeaderConfirmRole=0;
		private string _TeamLeaderConfirmDoc=null;
		private int _IsHandOver=0;
		private int _BlockModel=0;
		private string _BlockExp=null;
		private string _BlockAlert=null;
		private string _SFActiveFlows=null;
		private int _BatchRole=0;
		private int _BatchListCount=0;
		private string _BatchParas=null;
		private int _FormType=0;
		private string _FormUrl=null;
		private int _TurnToDeal=0;
		private string _TurnToDealDoc=null;
		private int _NodePosType=0;
		private int _IsCCFlow=0;
		private string _HisStas=null;
		private string _HisDeptStrs=null;
		private string _HisToNDs=null;
		private string _HisBillIDs=null;
		private string _HisSubFlows=null;
		private string _PTable=null;
		private string _GroupStaNDs=null;
		private int _X=0;
		private int _Y=0;
		private string _RefOneFrmTreeType=null;
		private string _AtPara=null;
		private string _CheckNodes=null;
		private string _FrmTrackLab=null;
		private int _FrmTrackSta=0;
		private decimal _FrmTrack_X=0;
		private decimal _FrmTrack_Y=0;
		private decimal _FrmTrack_H=0;
		private decimal _FrmTrack_W=0;
		private string _FrmThreadLab=null;
		private int _FrmThreadSta=0;
		private decimal _FrmThread_X=0;
		private decimal _FrmThread_Y=0;
		private decimal _FrmThread_H=0;
		private decimal _FrmThread_W=0;
		private string _SFLab=null;
		private int _SFSta=0;
		private int _SFShowModel=0;
		private string _SFCaption=null;
		private string _SFDefInfo=null;
		private decimal _SF_X=0;
		private decimal _SF_Y=0;
		private decimal _SF_H=0;
		private decimal _SF_W=0;
		private string _SFFields=null;
		private int _SFShowCtrl=0;
		private int _SFOpenType=0;
		private string _FTCLab=null;
		private int _FTCSta=0;
		private int _FTCWorkModel=0;
		private decimal _FTC_X=0;
		private decimal _FTC_Y=0;
		private decimal _FTC_H=0;
		private decimal _FTC_W=0;
		private string _OfficeOpen=null;
		private int _OfficeOpenEnable=0;
		private string _OfficeOpenTemplate=null;
		private int _OfficeOpenTemplateEnable=0;
		private string _OfficeSave=null;
		private int _OfficeSaveEnable=0;
		private string _OfficeAccept=null;
		private int _OfficeAcceptEnable=0;
		private string _OfficeRefuse=null;
		private int _OfficeRefuseEnable=0;
		private string _OfficeOver=null;
		private int _OfficeOverEnable=0;
		private int _OfficeMarks=0;
		private int _OfficeReadOnly=0;
		private string _OfficePrint=null;
		private int _OfficePrintEnable=0;
		private string _OfficeSeal=null;
		private int _OfficeSealEnable=0;
		private string _OfficeInsertFlow=null;
		private int _OfficeInsertFlowEnable=0;
		private int _OfficeNodeInfo=0;
		private int _OfficeReSavePDF=0;
		private string _OfficeDownLab=null;
		private int _OfficeDownEnable=0;
		private int _OfficeIsMarks=0;
		private string _OfficeTemplate=null;
		private int _OfficeIsParent=0;
		private int _OfficeIsTrueTH=0;
		private string _OfficeTHTemplate=null;
		private int _WebOfficeFrmModel=0;
		private int _SelectorModel=0;
		private string _FK_SQLTemplate=null;
		private string _FK_SQLTemplateText=null;
		private int _IsAutoLoadEmps=0;
		private int _IsSimpleSelector=0;
		private int _IsEnableDeptRange=0;
		private int _IsEnableStaRange=0;
		private string _SelectorP1=null;
		private string _SelectorP2=null;
		private string _SelectorP3=null;
		private string _SelectorP4=null;
		private string _SelectAccepterLab=null;
		private int _SelectAccepterEnable=0;
		private string _CHLab=null;
		private int _CHEnable=0;
		private string _OfficeOpenLab=null;
		private string _OfficeOpenTemplateLab=null;
		private string _OfficeSaveLab=null;
		private string _OfficeAcceptLab=null;
		private string _OfficeRefuseLab=null;
		private string _OfficeOverLab=null;
		private int _OfficeMarksEnable=0;
		private string _OfficePrintLab=null;
		private string _OfficeSealLab=null;
		private string _OfficeInsertFlowLab=null;
		private int _OfficeTHEnable=0;
	
	
      /// <summary>
      /// 节点ID(主键)
      /// </summary>
	  [DataMember]
	  public virtual int NodeID 
	  { 
	     get{return _NodeID;}
	     set{_NodeID=value;}
	  }
	
      /// <summary>
      /// 步骤
      /// </summary>
	  [DataMember]
	  public virtual int Step 
	  { 
	     get{return _Step;}
	     set{_Step=value;}
	  }
	
      /// <summary>
      /// 流程编号
      /// </summary>
	  [DataMember]
	  public virtual string FK_Flow 
	  { 
	     get{return _FK_Flow;}
	     set{_FK_Flow=value;}
	  }
	
      /// <summary>
      /// 流程名
      /// </summary>
	  [DataMember]
	  public virtual string FlowName 
	  { 
	     get{return _FlowName;}
	     set{_FlowName=value;}
	  }
	
      /// <summary>
      /// 节点名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 操作提示
      /// </summary>
	  [DataMember]
	  public virtual string Tip 
	  { 
	     get{return _Tip;}
	     set{_Tip=value;}
	  }
	
      /// <summary>
      /// 谁执行它,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int WhoExeIt 
	  { 
	     get{return _WhoExeIt;}
	     set{_WhoExeIt=value;}
	  }
	
      /// <summary>
      /// 已读回执,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int ReadReceipts 
	  { 
	     get{return _ReadReceipts;}
	     set{_ReadReceipts=value;}
	  }
	
      /// <summary>
      /// 方向条件控制规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int CondModel 
	  { 
	     get{return _CondModel;}
	     set{_CondModel=value;}
	  }
	
      /// <summary>
      /// 撤销规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int CancelRole 
	  { 
	     get{return _CancelRole;}
	     set{_CancelRole=value;}
	  }
	
      /// <summary>
      /// 对方已经打开就不能撤销
      /// </summary>
	  [DataMember]
	  public virtual int CancelDisWhenRead 
	  { 
	     get{return _CancelDisWhenRead;}
	     set{_CancelDisWhenRead=value;}
	  }
	
      /// <summary>
      /// 允许分配工作否?
      /// </summary>
	  [DataMember]
	  public virtual int IsTask 
	  { 
	     get{return _IsTask;}
	     set{_IsTask=value;}
	  }
	
      /// <summary>
      /// 本节点接收人不允许包含上一步发送人
      /// </summary>
	  [DataMember]
	  public virtual int IsExpSender 
	  { 
	     get{return _IsExpSender;}
	     set{_IsExpSender=value;}
	  }
	
      /// <summary>
      /// 是否启用投递路径自动记忆功能?
      /// </summary>
	  [DataMember]
	  public virtual int IsRM 
	  { 
	     get{return _IsRM;}
	     set{_IsRM=value;}
	  }
	
      /// <summary>
      /// 是否打开即审批?
      /// </summary>
	  [DataMember]
	  public virtual int IsGuestNode 
	  { 
	     get{return _IsGuestNode;}
	     set{_IsGuestNode=value;}
	  }
	
      /// <summary>
      /// 生命周期从
      /// </summary>
	  [DataMember]
	  public virtual string DTFrom 
	  { 
	     get{return _DTFrom;}
	     set{_DTFrom=value;}
	  }
	
      /// <summary>
      /// 生命周期到
      /// </summary>
	  [DataMember]
	  public virtual string DTTo 
	  { 
	     get{return _DTTo;}
	     set{_DTTo=value;}
	  }
	
      /// <summary>
      /// 是否是节点模版（业务单元）?
      /// </summary>
	  [DataMember]
	  public virtual int IsBUnit 
	  { 
	     get{return _IsBUnit;}
	     set{_IsBUnit=value;}
	  }
	
      /// <summary>
      /// 焦点字段
      /// </summary>
	  [DataMember]
	  public virtual string FocusField 
	  { 
	     get{return _FocusField;}
	     set{_FocusField=value;}
	  }
	
      /// <summary>
      /// 节点业务类型
      /// </summary>
	  [DataMember]
	  public virtual int NodeAppType 
	  { 
	     get{return _NodeAppType;}
	     set{_NodeAppType=value;}
	  }
	
      /// <summary>
      /// 审核组件状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCSta 
	  { 
	     get{return _FWCSta;}
	     set{_FWCSta=value;}
	  }
	
      /// <summary>
      /// 自定义参数
      /// </summary>
	  [DataMember]
	  public virtual string SelfParas 
	  { 
	     get{return _SelfParas;}
	     set{_SelfParas=value;}
	  }
	
      /// <summary>
      /// 节点类型,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int RunModel 
	  { 
	     get{return _RunModel;}
	     set{_RunModel=value;}
	  }
	
      /// <summary>
      /// 子线程类型,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SubThreadType 
	  { 
	     get{return _SubThreadType;}
	     set{_SubThreadType=value;}
	  }
	
      /// <summary>
      /// 完成通过率
      /// </summary>
	  [DataMember]
	  public virtual decimal PassRate 
	  { 
	     get{return _PassRate;}
	     set{_PassRate=value;}
	  }
	
      /// <summary>
      /// 子线程启动方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SubFlowStartWay 
	  { 
	     get{return _SubFlowStartWay;}
	     set{_SubFlowStartWay=value;}
	  }
	
      /// <summary>
      /// 启动参数
      /// </summary>
	  [DataMember]
	  public virtual string SubFlowStartParas 
	  { 
	     get{return _SubFlowStartParas;}
	     set{_SubFlowStartParas=value;}
	  }
	
      /// <summary>
      /// 是否可以删除子线程(当前节点已经发送出去的线程，并且当前节点是分流，或者分合流有效，在子线程退回后的操作)？
      /// </summary>
	  [DataMember]
	  public virtual int ThreadIsCanDel 
	  { 
	     get{return _ThreadIsCanDel;}
	     set{_ThreadIsCanDel=value;}
	  }
	
      /// <summary>
      /// 是否可以移交子线程(当前节点已经发送出去的线程，并且当前节点是分流，或者分合流有效，在子线程退回后的操作)？
      /// </summary>
	  [DataMember]
	  public virtual int ThreadIsCanShift 
	  { 
	     get{return _ThreadIsCanShift;}
	     set{_ThreadIsCanShift=value;}
	  }
	
      /// <summary>
      /// 是否允许子线程接受人员重复(仅当分流点向子线程发送时有效)?
      /// </summary>
	  [DataMember]
	  public virtual int IsAllowRepeatEmps 
	  { 
	     get{return _IsAllowRepeatEmps;}
	     set{_IsAllowRepeatEmps=value;}
	  }
	
      /// <summary>
      /// 是否启用自动运行？(仅当分流点向子线程发送时有效)
      /// </summary>
	  [DataMember]
	  public virtual int AutoRunEnable 
	  { 
	     get{return _AutoRunEnable;}
	     set{_AutoRunEnable=value;}
	  }
	
      /// <summary>
      /// 自动运行SQL
      /// </summary>
	  [DataMember]
	  public virtual string AutoRunParas 
	  { 
	     get{return _AutoRunParas;}
	     set{_AutoRunParas=value;}
	  }
	
      /// <summary>
      /// 处理人就是发起人
      /// </summary>
	  [DataMember]
	  public virtual int AutoJumpRole0 
	  { 
	     get{return _AutoJumpRole0;}
	     set{_AutoJumpRole0=value;}
	  }
	
      /// <summary>
      /// 处理人已经出现过
      /// </summary>
	  [DataMember]
	  public virtual int AutoJumpRole1 
	  { 
	     get{return _AutoJumpRole1;}
	     set{_AutoJumpRole1=value;}
	  }
	
      /// <summary>
      /// 处理人与上一步相同
      /// </summary>
	  [DataMember]
	  public virtual int AutoJumpRole2 
	  { 
	     get{return _AutoJumpRole2;}
	     set{_AutoJumpRole2=value;}
	  }
	
      /// <summary>
      /// (是)找不到人就跳转,(否)提示错误.
      /// </summary>
	  [DataMember]
	  public virtual int WhenNoWorker 
	  { 
	     get{return _WhenNoWorker;}
	     set{_WhenNoWorker=value;}
	  }
	
      /// <summary>
      /// 发送按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string SendLab 
	  { 
	     get{return _SendLab;}
	     set{_SendLab=value;}
	  }
	
      /// <summary>
      /// 发送按钮JS函数
      /// </summary>
	  [DataMember]
	  public virtual string SendJS 
	  { 
	     get{return _SendJS;}
	     set{_SendJS=value;}
	  }
	
      /// <summary>
      /// 保存按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string SaveLab 
	  { 
	     get{return _SaveLab;}
	     set{_SaveLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int SaveEnable 
	  { 
	     get{return _SaveEnable;}
	     set{_SaveEnable=value;}
	  }
	
      /// <summary>
      /// 子线程按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ThreadLab 
	  { 
	     get{return _ThreadLab;}
	     set{_ThreadLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ThreadEnable 
	  { 
	     get{return _ThreadEnable;}
	     set{_ThreadEnable=value;}
	  }
	
      /// <summary>
      /// 子线程删除方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int ThreadKillRole 
	  { 
	     get{return _ThreadKillRole;}
	     set{_ThreadKillRole=value;}
	  }
	
      /// <summary>
      /// 跳转按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string JumpWayLab 
	  { 
	     get{return _JumpWayLab;}
	     set{_JumpWayLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int JumpWay 
	  { 
	     get{return _JumpWay;}
	     set{_JumpWay=value;}
	  }
	
      /// <summary>
      /// 可跳转的节点
      /// </summary>
	  [DataMember]
	  public virtual string JumpToNodes 
	  { 
	     get{return _JumpToNodes;}
	     set{_JumpToNodes=value;}
	  }
	
      /// <summary>
      /// 退回按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ReturnLab 
	  { 
	     get{return _ReturnLab;}
	     set{_ReturnLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ReturnRole 
	  { 
	     get{return _ReturnRole;}
	     set{_ReturnRole=value;}
	  }
	
      /// <summary>
      /// 被退回后信息提示
      /// </summary>
	  [DataMember]
	  public virtual string ReturnAlert 
	  { 
	     get{return _ReturnAlert;}
	     set{_ReturnAlert=value;}
	  }
	
      /// <summary>
      /// 是否可以原路返回(启用退回功能才有效)
      /// </summary>
	  [DataMember]
	  public virtual int IsBackTracking 
	  { 
	     get{return _IsBackTracking;}
	     set{_IsBackTracking=value;}
	  }
	
      /// <summary>
      /// 退回信息填写字段
      /// </summary>
	  [DataMember]
	  public virtual string ReturnField 
	  { 
	     get{return _ReturnField;}
	     set{_ReturnField=value;}
	  }
	
      /// <summary>
      /// 退回原因
      /// </summary>
	  [DataMember]
	  public virtual string ReturnReasonsItems 
	  { 
	     get{return _ReturnReasonsItems;}
	     set{_ReturnReasonsItems=value;}
	  }
	
      /// <summary>
      /// 单节点退回规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int ReturnOneNodeRole 
	  { 
	     get{return _ReturnOneNodeRole;}
	     set{_ReturnOneNodeRole=value;}
	  }
	
      /// <summary>
      /// 抄送按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string CCLab 
	  { 
	     get{return _CCLab;}
	     set{_CCLab=value;}
	  }
	
      /// <summary>
      /// 抄送规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int CCRole 
	  { 
	     get{return _CCRole;}
	     set{_CCRole=value;}
	  }
	
      /// <summary>
      /// 抄送数据写入规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int CCWriteTo 
	  { 
	     get{return _CCWriteTo;}
	     set{_CCWriteTo=value;}
	  }
	
      /// <summary>
      /// 超时处理内容
      /// </summary>
	  [DataMember]
	  public virtual string DoOutTime 
	  { 
	     get{return _DoOutTime;}
	     set{_DoOutTime=value;}
	  }
	
      /// <summary>
      /// 执行超时的条件
      /// </summary>
	  [DataMember]
	  public virtual string DoOutTimeCond 
	  { 
	     get{return _DoOutTimeCond;}
	     set{_DoOutTimeCond=value;}
	  }
	
      /// <summary>
      /// 移交按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ShiftLab 
	  { 
	     get{return _ShiftLab;}
	     set{_ShiftLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ShiftEnable 
	  { 
	     get{return _ShiftEnable;}
	     set{_ShiftEnable=value;}
	  }
	
      /// <summary>
      /// 删除流程按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string DelLab 
	  { 
	     get{return _DelLab;}
	     set{_DelLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int DelEnable 
	  { 
	     get{return _DelEnable;}
	     set{_DelEnable=value;}
	  }
	
      /// <summary>
      /// 结束流程按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string EndFlowLab 
	  { 
	     get{return _EndFlowLab;}
	     set{_EndFlowLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int EndFlowEnable 
	  { 
	     get{return _EndFlowEnable;}
	     set{_EndFlowEnable=value;}
	  }
	
      /// <summary>
      /// 查看父流程按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ShowParentFormLab 
	  { 
	     get{return _ShowParentFormLab;}
	     set{_ShowParentFormLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ShowParentFormEnable 
	  { 
	     get{return _ShowParentFormEnable;}
	     set{_ShowParentFormEnable=value;}
	  }
	
      /// <summary>
      /// 公文按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeBtnLab 
	  { 
	     get{return _OfficeBtnLab;}
	     set{_OfficeBtnLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeBtnEnable 
	  { 
	     get{return _OfficeBtnEnable;}
	     set{_OfficeBtnEnable=value;}
	  }
	
      /// <summary>
      /// 打印Html标签
      /// </summary>
	  [DataMember]
	  public virtual string PrintHtmlLab 
	  { 
	     get{return _PrintHtmlLab;}
	     set{_PrintHtmlLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int PrintHtmlEnable 
	  { 
	     get{return _PrintHtmlEnable;}
	     set{_PrintHtmlEnable=value;}
	  }
	
      /// <summary>
      /// 打印pdf标签
      /// </summary>
	  [DataMember]
	  public virtual string PrintPDFLab 
	  { 
	     get{return _PrintPDFLab;}
	     set{_PrintPDFLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int PrintPDFEnable 
	  { 
	     get{return _PrintPDFEnable;}
	     set{_PrintPDFEnable=value;}
	  }
	
      /// <summary>
      /// PDF打印规则,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int PrintPDFModle 
	  { 
	     get{return _PrintPDFModle;}
	     set{_PrintPDFModle=value;}
	  }
	
      /// <summary>
      /// 打包下载zip按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string PrintZipLab 
	  { 
	     get{return _PrintZipLab;}
	     set{_PrintZipLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int PrintZipEnable 
	  { 
	     get{return _PrintZipEnable;}
	     set{_PrintZipEnable=value;}
	  }
	
      /// <summary>
      /// 打印单据按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string PrintDocLab 
	  { 
	     get{return _PrintDocLab;}
	     set{_PrintDocLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int PrintDocEnable 
	  { 
	     get{return _PrintDocEnable;}
	     set{_PrintDocEnable=value;}
	  }
	
      /// <summary>
      /// 轨迹按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string TrackLab 
	  { 
	     get{return _TrackLab;}
	     set{_TrackLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int TrackEnable 
	  { 
	     get{return _TrackEnable;}
	     set{_TrackEnable=value;}
	  }
	
      /// <summary>
      /// 挂起按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string HungLab 
	  { 
	     get{return _HungLab;}
	     set{_HungLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int HungEnable 
	  { 
	     get{return _HungEnable;}
	     set{_HungEnable=value;}
	  }
	
      /// <summary>
      /// 查询按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string SearchLab 
	  { 
	     get{return _SearchLab;}
	     set{_SearchLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int SearchEnable 
	  { 
	     get{return _SearchEnable;}
	     set{_SearchEnable=value;}
	  }
	
      /// <summary>
      /// 审核按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string WorkCheckLab 
	  { 
	     get{return _WorkCheckLab;}
	     set{_WorkCheckLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int WorkCheckEnable 
	  { 
	     get{return _WorkCheckEnable;}
	     set{_WorkCheckEnable=value;}
	  }
	
      /// <summary>
      /// 加签标签
      /// </summary>
	  [DataMember]
	  public virtual string AskforLab 
	  { 
	     get{return _AskforLab;}
	     set{_AskforLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int AskforEnable 
	  { 
	     get{return _AskforEnable;}
	     set{_AskforEnable=value;}
	  }
	
      /// <summary>
      /// 会签标签
      /// </summary>
	  [DataMember]
	  public virtual string HuiQianLab 
	  { 
	     get{return _HuiQianLab;}
	     set{_HuiQianLab=value;}
	  }
	
      /// <summary>
      /// 会签模式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int HuiQianRole 
	  { 
	     get{return _HuiQianRole;}
	     set{_HuiQianRole=value;}
	  }
	
      /// <summary>
      /// 流转自定义
      /// </summary>
	  [DataMember]
	  public virtual string TCLab 
	  { 
	     get{return _TCLab;}
	     set{_TCLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int TCEnable 
	  { 
	     get{return _TCEnable;}
	     set{_TCEnable=value;}
	  }
	
      /// <summary>
      /// 公文标签
      /// </summary>
	  [DataMember]
	  public virtual string WebOffice 
	  { 
	     get{return _WebOffice;}
	     set{_WebOffice=value;}
	  }
	
      /// <summary>
      /// 文档启用方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int WebOfficeEnable 
	  { 
	     get{return _WebOfficeEnable;}
	     set{_WebOfficeEnable=value;}
	  }
	
      /// <summary>
      /// 重要性
      /// </summary>
	  [DataMember]
	  public virtual string PRILab 
	  { 
	     get{return _PRILab;}
	     set{_PRILab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int PRIEnable 
	  { 
	     get{return _PRIEnable;}
	     set{_PRIEnable=value;}
	  }
	
      /// <summary>
      /// 分配按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string AllotLab 
	  { 
	     get{return _AllotLab;}
	     set{_AllotLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int AllotEnable 
	  { 
	     get{return _AllotEnable;}
	     set{_AllotEnable=value;}
	  }
	
      /// <summary>
      /// 关注
      /// </summary>
	  [DataMember]
	  public virtual string FocusLab 
	  { 
	     get{return _FocusLab;}
	     set{_FocusLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int FocusEnable 
	  { 
	     get{return _FocusEnable;}
	     set{_FocusEnable=value;}
	  }
	
      /// <summary>
      /// 确认按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ConfirmLab 
	  { 
	     get{return _ConfirmLab;}
	     set{_ConfirmLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ConfirmEnable 
	  { 
	     get{return _ConfirmEnable;}
	     set{_ConfirmEnable=value;}
	  }
	
      /// <summary>
      /// 列表按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string ListLab 
	  { 
	     get{return _ListLab;}
	     set{_ListLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int ListEnable 
	  { 
	     get{return _ListEnable;}
	     set{_ListEnable=value;}
	  }
	
      /// <summary>
      /// 批量审核标签
      /// </summary>
	  [DataMember]
	  public virtual string BatchLab 
	  { 
	     get{return _BatchLab;}
	     set{_BatchLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int BatchEnable 
	  { 
	     get{return _BatchEnable;}
	     set{_BatchEnable=value;}
	  }
	
      /// <summary>
      /// 限期(天)
      /// </summary>
	  [DataMember]
	  public virtual decimal TimeLimit 
	  { 
	     get{return _TimeLimit;}
	     set{_TimeLimit=value;}
	  }
	
      /// <summary>
      /// 时间计算方式
      /// </summary>
	  [DataMember]
	  public virtual int TWay 
	  { 
	     get{return _TWay;}
	     set{_TWay=value;}
	  }
	
      /// <summary>
      /// 逾期提醒规则
      /// </summary>
	  [DataMember]
	  public virtual int TAlertRole 
	  { 
	     get{return _TAlertRole;}
	     set{_TAlertRole=value;}
	  }
	
      /// <summary>
      /// 逾期提醒方式
      /// </summary>
	  [DataMember]
	  public virtual int TAlertWay 
	  { 
	     get{return _TAlertWay;}
	     set{_TAlertWay=value;}
	  }
	
      /// <summary>
      /// 工作预警(天)
      /// </summary>
	  [DataMember]
	  public virtual decimal WarningDay 
	  { 
	     get{return _WarningDay;}
	     set{_WarningDay=value;}
	  }
	
      /// <summary>
      /// 预警提醒规则
      /// </summary>
	  [DataMember]
	  public virtual int WAlertRole 
	  { 
	     get{return _WAlertRole;}
	     set{_WAlertRole=value;}
	  }
	
      /// <summary>
      /// 预警提醒方式
      /// </summary>
	  [DataMember]
	  public virtual int WAlertWay 
	  { 
	     get{return _WAlertWay;}
	     set{_WAlertWay=value;}
	  }
	
      /// <summary>
      /// 扣分(每延期1小时)
      /// </summary>
	  [DataMember]
	  public virtual decimal TCent 
	  { 
	     get{return _TCent;}
	     set{_TCent=value;}
	  }
	
      /// <summary>
      /// 考核方式
      /// </summary>
	  [DataMember]
	  public virtual int CHWay 
	  { 
	     get{return _CHWay;}
	     set{_CHWay=value;}
	  }
	
      /// <summary>
      /// 是否工作质量考核
      /// </summary>
	  [DataMember]
	  public virtual int IsEval 
	  { 
	     get{return _IsEval;}
	     set{_IsEval=value;}
	  }
	
      /// <summary>
      /// 超时处理方式
      /// </summary>
	  [DataMember]
	  public virtual int OutTimeDeal 
	  { 
	     get{return _OutTimeDeal;}
	     set{_OutTimeDeal=value;}
	  }
	
      /// <summary>
      /// 按表单字段抄送
      /// </summary>
	  [DataMember]
	  public virtual int CCIsAttr 
	  { 
	     get{return _CCIsAttr;}
	     set{_CCIsAttr=value;}
	  }
	
      /// <summary>
      /// 抄送人员字段
      /// </summary>
	  [DataMember]
	  public virtual string CCFormAttr 
	  { 
	     get{return _CCFormAttr;}
	     set{_CCFormAttr=value;}
	  }
	
      /// <summary>
      /// 按照岗位抄送
      /// </summary>
	  [DataMember]
	  public virtual int CCIsStations 
	  { 
	     get{return _CCIsStations;}
	     set{_CCIsStations=value;}
	  }
	
      /// <summary>
      /// 抄送岗位计算方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int CCStaWay 
	  { 
	     get{return _CCStaWay;}
	     set{_CCStaWay=value;}
	  }
	
      /// <summary>
      /// 按照部门抄送
      /// </summary>
	  [DataMember]
	  public virtual int CCIsDepts 
	  { 
	     get{return _CCIsDepts;}
	     set{_CCIsDepts=value;}
	  }
	
      /// <summary>
      /// 按照人员抄送
      /// </summary>
	  [DataMember]
	  public virtual int CCIsEmps 
	  { 
	     get{return _CCIsEmps;}
	     set{_CCIsEmps=value;}
	  }
	
      /// <summary>
      /// 按照SQL抄送
      /// </summary>
	  [DataMember]
	  public virtual int CCIsSQLs 
	  { 
	     get{return _CCIsSQLs;}
	     set{_CCIsSQLs=value;}
	  }
	
      /// <summary>
      /// SQL表达式
      /// </summary>
	  [DataMember]
	  public virtual string CCSQL 
	  { 
	     get{return _CCSQL;}
	     set{_CCSQL=value;}
	  }
	
      /// <summary>
      /// 抄送标题
      /// </summary>
	  [DataMember]
	  public virtual string CCTitle 
	  { 
	     get{return _CCTitle;}
	     set{_CCTitle=value;}
	  }
	
      /// <summary>
      /// 抄送内容(标题与内容支持变量)
      /// </summary>
	  [DataMember]
	  public virtual string CCDoc 
	  { 
	     get{return _CCDoc;}
	     set{_CCDoc=value;}
	  }
	
      /// <summary>
      /// 显示标签
      /// </summary>
	  [DataMember]
	  public virtual string FWCLab 
	  { 
	     get{return _FWCLab;}
	     set{_FWCLab=value;}
	  }
	
      /// <summary>
      /// 显示方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCShowModel 
	  { 
	     get{return _FWCShowModel;}
	     set{_FWCShowModel=value;}
	  }
	
      /// <summary>
      /// 审核组件,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCType 
	  { 
	     get{return _FWCType;}
	     set{_FWCType=value;}
	  }
	
      /// <summary>
      /// 节点意见名称
      /// </summary>
	  [DataMember]
	  public virtual string FWCNodeName 
	  { 
	     get{return _FWCNodeName;}
	     set{_FWCNodeName=value;}
	  }
	
      /// <summary>
      /// 附件上传,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCAth 
	  { 
	     get{return _FWCAth;}
	     set{_FWCAth=value;}
	  }
	
      /// <summary>
      /// 轨迹图是否显示？
      /// </summary>
	  [DataMember]
	  public virtual int FWCTrackEnable 
	  { 
	     get{return _FWCTrackEnable;}
	     set{_FWCTrackEnable=value;}
	  }
	
      /// <summary>
      /// 历史审核信息是否显示？(否,仅出现意见框)
      /// </summary>
	  [DataMember]
	  public virtual int FWCListEnable 
	  { 
	     get{return _FWCListEnable;}
	     set{_FWCListEnable=value;}
	  }
	
      /// <summary>
      /// 在轨迹表里是否显示所有的步骤？
      /// </summary>
	  [DataMember]
	  public virtual int FWCIsShowAllStep 
	  { 
	     get{return _FWCIsShowAllStep;}
	     set{_FWCIsShowAllStep=value;}
	  }
	
      /// <summary>
      /// 操作名词(审核/审阅/批示)
      /// </summary>
	  [DataMember]
	  public virtual string FWCOpLabel 
	  { 
	     get{return _FWCOpLabel;}
	     set{_FWCOpLabel=value;}
	  }
	
      /// <summary>
      /// 默认审核信息
      /// </summary>
	  [DataMember]
	  public virtual string FWCDefInfo 
	  { 
	     get{return _FWCDefInfo;}
	     set{_FWCDefInfo=value;}
	  }
	
      /// <summary>
      /// 操作人是否显示为图片签名？
      /// </summary>
	  [DataMember]
	  public virtual int SigantureEnabel 
	  { 
	     get{return _SigantureEnabel;}
	     set{_SigantureEnabel=value;}
	  }
	
      /// <summary>
      /// 如果用户未审核是否按照默认意见填充？
      /// </summary>
	  [DataMember]
	  public virtual int FWCIsFullInfo 
	  { 
	     get{return _FWCIsFullInfo;}
	     set{_FWCIsFullInfo=value;}
	  }
	
      /// <summary>
      /// 位置X
      /// </summary>
	  [DataMember]
	  public virtual decimal FWC_X 
	  { 
	     get{return _FWC_X;}
	     set{_FWC_X=value;}
	  }
	
      /// <summary>
      /// 位置Y
      /// </summary>
	  [DataMember]
	  public virtual decimal FWC_Y 
	  { 
	     get{return _FWC_Y;}
	     set{_FWC_Y=value;}
	  }
	
      /// <summary>
      /// 高度(0=100%)
      /// </summary>
	  [DataMember]
	  public virtual decimal FWC_H 
	  { 
	     get{return _FWC_H;}
	     set{_FWC_H=value;}
	  }
	
      /// <summary>
      /// 宽度(0=100%)
      /// </summary>
	  [DataMember]
	  public virtual decimal FWC_W 
	  { 
	     get{return _FWC_W;}
	     set{_FWC_W=value;}
	  }
	
      /// <summary>
      /// 审批格式字段
      /// </summary>
	  [DataMember]
	  public virtual string FWCFields 
	  { 
	     get{return _FWCFields;}
	     set{_FWCFields=value;}
	  }
	
      /// <summary>
      /// 是否显示未审核的轨迹？
      /// </summary>
	  [DataMember]
	  public virtual int FWCIsShowTruck 
	  { 
	     get{return _FWCIsShowTruck;}
	     set{_FWCIsShowTruck=value;}
	  }
	
      /// <summary>
      /// 是否显示退回信息？
      /// </summary>
	  [DataMember]
	  public virtual int FWCIsShowReturnMsg 
	  { 
	     get{return _FWCIsShowReturnMsg;}
	     set{_FWCIsShowReturnMsg=value;}
	  }
	
      /// <summary>
      /// 协作模式下操作员显示顺序,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCOrderModel 
	  { 
	     get{return _FWCOrderModel;}
	     set{_FWCOrderModel=value;}
	  }
	
      /// <summary>
      /// 审核意见显示方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FWCMsgShow 
	  { 
	     get{return _FWCMsgShow;}
	     set{_FWCMsgShow=value;}
	  }
	
      /// <summary>
      /// 节点ICON图片路径
      /// </summary>
	  [DataMember]
	  public virtual string ICON 
	  { 
	     get{return _ICON;}
	     set{_ICON=value;}
	  }
	
      /// <summary>
      /// 节点类型
      /// </summary>
	  [DataMember]
	  public virtual int NodeWorkType 
	  { 
	     get{return _NodeWorkType;}
	     set{_NodeWorkType=value;}
	  }
	
      /// <summary>
      /// FrmAttr
      /// </summary>
	  [DataMember]
	  public virtual string FrmAttr 
	  { 
	     get{return _FrmAttr;}
	     set{_FrmAttr=value;}
	  }
	
      /// <summary>
      /// 描述
      /// </summary>
	  [DataMember]
	  public virtual string Doc 
	  { 
	     get{return _Doc;}
	     set{_Doc=value;}
	  }
	
      /// <summary>
      /// 访问规则
      /// </summary>
	  [DataMember]
	  public virtual int DeliveryWay 
	  { 
	     get{return _DeliveryWay;}
	     set{_DeliveryWay=value;}
	  }
	
      /// <summary>
      /// 访问规则设置
      /// </summary>
	  [DataMember]
	  public virtual string DeliveryParas 
	  { 
	     get{return _DeliveryParas;}
	     set{_DeliveryParas=value;}
	  }
	
      /// <summary>
      /// 节点表单ID
      /// </summary>
	  [DataMember]
	  public virtual string NodeFrmID 
	  { 
	     get{return _NodeFrmID;}
	     set{_NodeFrmID=value;}
	  }
	
      /// <summary>
      /// 保存模式
      /// </summary>
	  [DataMember]
	  public virtual int SaveModel 
	  { 
	     get{return _SaveModel;}
	     set{_SaveModel=value;}
	  }
	
      /// <summary>
      /// 是否可以删除流程
      /// </summary>
	  [DataMember]
	  public virtual int IsCanDelFlow 
	  { 
	     get{return _IsCanDelFlow;}
	     set{_IsCanDelFlow=value;}
	  }
	
      /// <summary>
      /// 多人处理规则
      /// </summary>
	  [DataMember]
	  public virtual int TodolistModel 
	  { 
	     get{return _TodolistModel;}
	     set{_TodolistModel=value;}
	  }
	
      /// <summary>
      /// 组长确认规则
      /// </summary>
	  [DataMember]
	  public virtual int TeamLeaderConfirmRole 
	  { 
	     get{return _TeamLeaderConfirmRole;}
	     set{_TeamLeaderConfirmRole=value;}
	  }
	
      /// <summary>
      /// 组长确认设置内容
      /// </summary>
	  [DataMember]
	  public virtual string TeamLeaderConfirmDoc 
	  { 
	     get{return _TeamLeaderConfirmDoc;}
	     set{_TeamLeaderConfirmDoc=value;}
	  }
	
      /// <summary>
      /// 是否可以移交
      /// </summary>
	  [DataMember]
	  public virtual int IsHandOver 
	  { 
	     get{return _IsHandOver;}
	     set{_IsHandOver=value;}
	  }
	
      /// <summary>
      /// 阻塞模式
      /// </summary>
	  [DataMember]
	  public virtual int BlockModel 
	  { 
	     get{return _BlockModel;}
	     set{_BlockModel=value;}
	  }
	
      /// <summary>
      /// 阻塞表达式
      /// </summary>
	  [DataMember]
	  public virtual string BlockExp 
	  { 
	     get{return _BlockExp;}
	     set{_BlockExp=value;}
	  }
	
      /// <summary>
      /// 被阻塞提示信息
      /// </summary>
	  [DataMember]
	  public virtual string BlockAlert 
	  { 
	     get{return _BlockAlert;}
	     set{_BlockAlert=value;}
	  }
	
      /// <summary>
      /// 可触发的子流程编号(多个用逗号分开)
      /// </summary>
	  [DataMember]
	  public virtual string SFActiveFlows 
	  { 
	     get{return _SFActiveFlows;}
	     set{_SFActiveFlows=value;}
	  }
	
      /// <summary>
      /// 批处理
      /// </summary>
	  [DataMember]
	  public virtual int BatchRole 
	  { 
	     get{return _BatchRole;}
	     set{_BatchRole=value;}
	  }
	
      /// <summary>
      /// 批处理数量
      /// </summary>
	  [DataMember]
	  public virtual int BatchListCount 
	  { 
	     get{return _BatchListCount;}
	     set{_BatchListCount=value;}
	  }
	
      /// <summary>
      /// 参数
      /// </summary>
	  [DataMember]
	  public virtual string BatchParas 
	  { 
	     get{return _BatchParas;}
	     set{_BatchParas=value;}
	  }
	
      /// <summary>
      /// 表单类型
      /// </summary>
	  [DataMember]
	  public virtual int FormType 
	  { 
	     get{return _FormType;}
	     set{_FormType=value;}
	  }
	
      /// <summary>
      /// 表单URL
      /// </summary>
	  [DataMember]
	  public virtual string FormUrl 
	  { 
	     get{return _FormUrl;}
	     set{_FormUrl=value;}
	  }
	
      /// <summary>
      /// 转向处理
      /// </summary>
	  [DataMember]
	  public virtual int TurnToDeal 
	  { 
	     get{return _TurnToDeal;}
	     set{_TurnToDeal=value;}
	  }
	
      /// <summary>
      /// 发送后提示信息
      /// </summary>
	  [DataMember]
	  public virtual string TurnToDealDoc 
	  { 
	     get{return _TurnToDealDoc;}
	     set{_TurnToDealDoc=value;}
	  }
	
      /// <summary>
      /// 位置
      /// </summary>
	  [DataMember]
	  public virtual int NodePosType 
	  { 
	     get{return _NodePosType;}
	     set{_NodePosType=value;}
	  }
	
      /// <summary>
      /// 是否有流程完成条件
      /// </summary>
	  [DataMember]
	  public virtual int IsCCFlow 
	  { 
	     get{return _IsCCFlow;}
	     set{_IsCCFlow=value;}
	  }
	
      /// <summary>
      /// 岗位
      /// </summary>
	  [DataMember]
	  public virtual string HisStas 
	  { 
	     get{return _HisStas;}
	     set{_HisStas=value;}
	  }
	
      /// <summary>
      /// 部门
      /// </summary>
	  [DataMember]
	  public virtual string HisDeptStrs 
	  { 
	     get{return _HisDeptStrs;}
	     set{_HisDeptStrs=value;}
	  }
	
      /// <summary>
      /// 转到的节点
      /// </summary>
	  [DataMember]
	  public virtual string HisToNDs 
	  { 
	     get{return _HisToNDs;}
	     set{_HisToNDs=value;}
	  }
	
      /// <summary>
      /// 单据IDs
      /// </summary>
	  [DataMember]
	  public virtual string HisBillIDs 
	  { 
	     get{return _HisBillIDs;}
	     set{_HisBillIDs=value;}
	  }
	
      /// <summary>
      /// HisSubFlows
      /// </summary>
	  [DataMember]
	  public virtual string HisSubFlows 
	  { 
	     get{return _HisSubFlows;}
	     set{_HisSubFlows=value;}
	  }
	
      /// <summary>
      /// 物理表
      /// </summary>
	  [DataMember]
	  public virtual string PTable 
	  { 
	     get{return _PTable;}
	     set{_PTable=value;}
	  }
	
      /// <summary>
      /// 岗位分组节点
      /// </summary>
	  [DataMember]
	  public virtual string GroupStaNDs 
	  { 
	     get{return _GroupStaNDs;}
	     set{_GroupStaNDs=value;}
	  }
	
      /// <summary>
      /// X坐标
      /// </summary>
	  [DataMember]
	  public virtual int X 
	  { 
	     get{return _X;}
	     set{_X=value;}
	  }
	
      /// <summary>
      /// Y坐标
      /// </summary>
	  [DataMember]
	  public virtual int Y 
	  { 
	     get{return _Y;}
	     set{_Y=value;}
	  }
	
      /// <summary>
      /// 独立表单类型
      /// </summary>
	  [DataMember]
	  public virtual string RefOneFrmTreeType 
	  { 
	     get{return _RefOneFrmTreeType;}
	     set{_RefOneFrmTreeType=value;}
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
      /// 工作节点s
      /// </summary>
	  [DataMember]
	  public virtual string CheckNodes 
	  { 
	     get{return _CheckNodes;}
	     set{_CheckNodes=value;}
	  }
	
      /// <summary>
      /// 显示标签
      /// </summary>
	  [DataMember]
	  public virtual string FrmTrackLab 
	  { 
	     get{return _FrmTrackLab;}
	     set{_FrmTrackLab=value;}
	  }
	
      /// <summary>
      /// 组件状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FrmTrackSta 
	  { 
	     get{return _FrmTrackSta;}
	     set{_FrmTrackSta=value;}
	  }
	
      /// <summary>
      /// 位置X
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmTrack_X 
	  { 
	     get{return _FrmTrack_X;}
	     set{_FrmTrack_X=value;}
	  }
	
      /// <summary>
      /// 位置Y
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmTrack_Y 
	  { 
	     get{return _FrmTrack_Y;}
	     set{_FrmTrack_Y=value;}
	  }
	
      /// <summary>
      /// 高度
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmTrack_H 
	  { 
	     get{return _FrmTrack_H;}
	     set{_FrmTrack_H=value;}
	  }
	
      /// <summary>
      /// 宽度
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmTrack_W 
	  { 
	     get{return _FrmTrack_W;}
	     set{_FrmTrack_W=value;}
	  }
	
      /// <summary>
      /// 显示标签
      /// </summary>
	  [DataMember]
	  public virtual string FrmThreadLab 
	  { 
	     get{return _FrmThreadLab;}
	     set{_FrmThreadLab=value;}
	  }
	
      /// <summary>
      /// 组件状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FrmThreadSta 
	  { 
	     get{return _FrmThreadSta;}
	     set{_FrmThreadSta=value;}
	  }
	
      /// <summary>
      /// 位置X
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmThread_X 
	  { 
	     get{return _FrmThread_X;}
	     set{_FrmThread_X=value;}
	  }
	
      /// <summary>
      /// 位置Y
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmThread_Y 
	  { 
	     get{return _FrmThread_Y;}
	     set{_FrmThread_Y=value;}
	  }
	
      /// <summary>
      /// 高度
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmThread_H 
	  { 
	     get{return _FrmThread_H;}
	     set{_FrmThread_H=value;}
	  }
	
      /// <summary>
      /// 宽度
      /// </summary>
	  [DataMember]
	  public virtual decimal FrmThread_W 
	  { 
	     get{return _FrmThread_W;}
	     set{_FrmThread_W=value;}
	  }
	
      /// <summary>
      /// 显示标签
      /// </summary>
	  [DataMember]
	  public virtual string SFLab 
	  { 
	     get{return _SFLab;}
	     set{_SFLab=value;}
	  }
	
      /// <summary>
      /// 父子流程状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SFSta 
	  { 
	     get{return _SFSta;}
	     set{_SFSta=value;}
	  }
	
      /// <summary>
      /// 显示方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SFShowModel 
	  { 
	     get{return _SFShowModel;}
	     set{_SFShowModel=value;}
	  }
	
      /// <summary>
      /// 连接标题
      /// </summary>
	  [DataMember]
	  public virtual string SFCaption 
	  { 
	     get{return _SFCaption;}
	     set{_SFCaption=value;}
	  }
	
      /// <summary>
      /// 可启动的子流程编号(多个用逗号分开)
      /// </summary>
	  [DataMember]
	  public virtual string SFDefInfo 
	  { 
	     get{return _SFDefInfo;}
	     set{_SFDefInfo=value;}
	  }
	
      /// <summary>
      /// 位置X
      /// </summary>
	  [DataMember]
	  public virtual decimal SF_X 
	  { 
	     get{return _SF_X;}
	     set{_SF_X=value;}
	  }
	
      /// <summary>
      /// 位置Y
      /// </summary>
	  [DataMember]
	  public virtual decimal SF_Y 
	  { 
	     get{return _SF_Y;}
	     set{_SF_Y=value;}
	  }
	
      /// <summary>
      /// 高度
      /// </summary>
	  [DataMember]
	  public virtual decimal SF_H 
	  { 
	     get{return _SF_H;}
	     set{_SF_H=value;}
	  }
	
      /// <summary>
      /// 宽度
      /// </summary>
	  [DataMember]
	  public virtual decimal SF_W 
	  { 
	     get{return _SF_W;}
	     set{_SF_W=value;}
	  }
	
      /// <summary>
      /// 审批格式字段
      /// </summary>
	  [DataMember]
	  public virtual string SFFields 
	  { 
	     get{return _SFFields;}
	     set{_SFFields=value;}
	  }
	
      /// <summary>
      /// 显示控制方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SFShowCtrl 
	  { 
	     get{return _SFShowCtrl;}
	     set{_SFShowCtrl=value;}
	  }
	
      /// <summary>
      /// 打开子流程显示,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SFOpenType 
	  { 
	     get{return _SFOpenType;}
	     set{_SFOpenType=value;}
	  }
	
      /// <summary>
      /// 显示标签
      /// </summary>
	  [DataMember]
	  public virtual string FTCLab 
	  { 
	     get{return _FTCLab;}
	     set{_FTCLab=value;}
	  }
	
      /// <summary>
      /// 组件状态,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FTCSta 
	  { 
	     get{return _FTCSta;}
	     set{_FTCSta=value;}
	  }
	
      /// <summary>
      /// 工作模式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int FTCWorkModel 
	  { 
	     get{return _FTCWorkModel;}
	     set{_FTCWorkModel=value;}
	  }
	
      /// <summary>
      /// 位置X
      /// </summary>
	  [DataMember]
	  public virtual decimal FTC_X 
	  { 
	     get{return _FTC_X;}
	     set{_FTC_X=value;}
	  }
	
      /// <summary>
      /// 位置Y
      /// </summary>
	  [DataMember]
	  public virtual decimal FTC_Y 
	  { 
	     get{return _FTC_Y;}
	     set{_FTC_Y=value;}
	  }
	
      /// <summary>
      /// 高度
      /// </summary>
	  [DataMember]
	  public virtual decimal FTC_H 
	  { 
	     get{return _FTC_H;}
	     set{_FTC_H=value;}
	  }
	
      /// <summary>
      /// 宽度
      /// </summary>
	  [DataMember]
	  public virtual decimal FTC_W 
	  { 
	     get{return _FTC_W;}
	     set{_FTC_W=value;}
	  }
	
      /// <summary>
      /// 打开本地标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOpen 
	  { 
	     get{return _OfficeOpen;}
	     set{_OfficeOpen=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeOpenEnable 
	  { 
	     get{return _OfficeOpenEnable;}
	     set{_OfficeOpenEnable=value;}
	  }
	
      /// <summary>
      /// 打开模板标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOpenTemplate 
	  { 
	     get{return _OfficeOpenTemplate;}
	     set{_OfficeOpenTemplate=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeOpenTemplateEnable 
	  { 
	     get{return _OfficeOpenTemplateEnable;}
	     set{_OfficeOpenTemplateEnable=value;}
	  }
	
      /// <summary>
      /// 保存标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeSave 
	  { 
	     get{return _OfficeSave;}
	     set{_OfficeSave=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeSaveEnable 
	  { 
	     get{return _OfficeSaveEnable;}
	     set{_OfficeSaveEnable=value;}
	  }
	
      /// <summary>
      /// 接受修订标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeAccept 
	  { 
	     get{return _OfficeAccept;}
	     set{_OfficeAccept=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeAcceptEnable 
	  { 
	     get{return _OfficeAcceptEnable;}
	     set{_OfficeAcceptEnable=value;}
	  }
	
      /// <summary>
      /// 拒绝修订标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeRefuse 
	  { 
	     get{return _OfficeRefuse;}
	     set{_OfficeRefuse=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeRefuseEnable 
	  { 
	     get{return _OfficeRefuseEnable;}
	     set{_OfficeRefuseEnable=value;}
	  }
	
      /// <summary>
      /// 套红按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOver 
	  { 
	     get{return _OfficeOver;}
	     set{_OfficeOver=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeOverEnable 
	  { 
	     get{return _OfficeOverEnable;}
	     set{_OfficeOverEnable=value;}
	  }
	
      /// <summary>
      /// 是否查看用户留痕
      /// </summary>
	  [DataMember]
	  public virtual int OfficeMarks 
	  { 
	     get{return _OfficeMarks;}
	     set{_OfficeMarks=value;}
	  }
	
      /// <summary>
      /// 是否只读
      /// </summary>
	  [DataMember]
	  public virtual int OfficeReadOnly 
	  { 
	     get{return _OfficeReadOnly;}
	     set{_OfficeReadOnly=value;}
	  }
	
      /// <summary>
      /// 打印按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficePrint 
	  { 
	     get{return _OfficePrint;}
	     set{_OfficePrint=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficePrintEnable 
	  { 
	     get{return _OfficePrintEnable;}
	     set{_OfficePrintEnable=value;}
	  }
	
      /// <summary>
      /// 签章按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeSeal 
	  { 
	     get{return _OfficeSeal;}
	     set{_OfficeSeal=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeSealEnable 
	  { 
	     get{return _OfficeSealEnable;}
	     set{_OfficeSealEnable=value;}
	  }
	
      /// <summary>
      /// 插入流程标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeInsertFlow 
	  { 
	     get{return _OfficeInsertFlow;}
	     set{_OfficeInsertFlow=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeInsertFlowEnable 
	  { 
	     get{return _OfficeInsertFlowEnable;}
	     set{_OfficeInsertFlowEnable=value;}
	  }
	
      /// <summary>
      /// 是否记录节点信息
      /// </summary>
	  [DataMember]
	  public virtual int OfficeNodeInfo 
	  { 
	     get{return _OfficeNodeInfo;}
	     set{_OfficeNodeInfo=value;}
	  }
	
      /// <summary>
      /// 是否该自动保存为PDF
      /// </summary>
	  [DataMember]
	  public virtual int OfficeReSavePDF 
	  { 
	     get{return _OfficeReSavePDF;}
	     set{_OfficeReSavePDF=value;}
	  }
	
      /// <summary>
      /// 下载按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeDownLab 
	  { 
	     get{return _OfficeDownLab;}
	     set{_OfficeDownLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int OfficeDownEnable 
	  { 
	     get{return _OfficeDownEnable;}
	     set{_OfficeDownEnable=value;}
	  }
	
      /// <summary>
      /// 是否进入留痕模式
      /// </summary>
	  [DataMember]
	  public virtual int OfficeIsMarks 
	  { 
	     get{return _OfficeIsMarks;}
	     set{_OfficeIsMarks=value;}
	  }
	
      /// <summary>
      /// 指定文档模板
      /// </summary>
	  [DataMember]
	  public virtual string OfficeTemplate 
	  { 
	     get{return _OfficeTemplate;}
	     set{_OfficeTemplate=value;}
	  }
	
      /// <summary>
      /// 是否使用父流程的文档
      /// </summary>
	  [DataMember]
	  public virtual int OfficeIsParent 
	  { 
	     get{return _OfficeIsParent;}
	     set{_OfficeIsParent=value;}
	  }
	
      /// <summary>
      /// 是否自动套红
      /// </summary>
	  [DataMember]
	  public virtual int OfficeIsTrueTH 
	  { 
	     get{return _OfficeIsTrueTH;}
	     set{_OfficeIsTrueTH=value;}
	  }
	
      /// <summary>
      /// 自动套红模板
      /// </summary>
	  [DataMember]
	  public virtual string OfficeTHTemplate 
	  { 
	     get{return _OfficeTHTemplate;}
	     set{_OfficeTHTemplate=value;}
	  }
	
      /// <summary>
      /// 表单工作方式,枚举类型:
      /// </summary>
	  [DataMember]
	  public virtual int WebOfficeFrmModel 
	  { 
	     get{return _WebOfficeFrmModel;}
	     set{_WebOfficeFrmModel=value;}
	  }
	
      /// <summary>
      /// 显示方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SelectorModel 
	  { 
	     get{return _SelectorModel;}
	     set{_SelectorModel=value;}
	  }
	
      /// <summary>
      /// SQL模版
      /// </summary>
	  [DataMember]
	  public virtual string FK_SQLTemplate 
	  { 
	     get{return _FK_SQLTemplate;}
	     set{_FK_SQLTemplate=value;}
	  }
	
      /// <summary>
      /// SQL模版
      /// </summary>
	  [DataMember]
	  public virtual string FK_SQLTemplateText 
	  { 
	     get{return _FK_SQLTemplateText;}
	     set{_FK_SQLTemplateText=value;}
	  }
	
      /// <summary>
      /// 是否自动加载上一次选择的人员？
      /// </summary>
	  [DataMember]
	  public virtual int IsAutoLoadEmps 
	  { 
	     get{return _IsAutoLoadEmps;}
	     set{_IsAutoLoadEmps=value;}
	  }
	
      /// <summary>
      /// 是否单项选择(只能选择一个人)？
      /// </summary>
	  [DataMember]
	  public virtual int IsSimpleSelector 
	  { 
	     get{return _IsSimpleSelector;}
	     set{_IsSimpleSelector=value;}
	  }
	
      /// <summary>
      /// 是否启用部门搜索范围限定(对使用通用人员选择器有效)？
      /// </summary>
	  [DataMember]
	  public virtual int IsEnableDeptRange 
	  { 
	     get{return _IsEnableDeptRange;}
	     set{_IsEnableDeptRange=value;}
	  }
	
      /// <summary>
      /// 是否启用岗位搜索范围限定(对使用通用人员选择器有效)？
      /// </summary>
	  [DataMember]
	  public virtual int IsEnableStaRange 
	  { 
	     get{return _IsEnableStaRange;}
	     set{_IsEnableStaRange=value;}
	  }
	
      /// <summary>
      /// 分组参数:可以为空,比如:SELECT
      /// </summary>
	  [DataMember]
	  public virtual string SelectorP1 
	  { 
	     get{return _SelectorP1;}
	     set{_SelectorP1=value;}
	  }
	
      /// <summary>
      /// 操作员数据源:比如:SELECT
      /// </summary>
	  [DataMember]
	  public virtual string SelectorP2 
	  { 
	     get{return _SelectorP2;}
	     set{_SelectorP2=value;}
	  }
	
      /// <summary>
      /// 默认选择的数据源:比如:SELECT
      /// </summary>
	  [DataMember]
	  public virtual string SelectorP3 
	  { 
	     get{return _SelectorP3;}
	     set{_SelectorP3=value;}
	  }
	
      /// <summary>
      /// 强制选择的数据源:比如:SELECT
      /// </summary>
	  [DataMember]
	  public virtual string SelectorP4 
	  { 
	     get{return _SelectorP4;}
	     set{_SelectorP4=value;}
	  }
	
      /// <summary>
      /// 接受人按钮标签
      /// </summary>
	  [DataMember]
	  public virtual string SelectAccepterLab 
	  { 
	     get{return _SelectAccepterLab;}
	     set{_SelectAccepterLab=value;}
	  }
	
      /// <summary>
      /// 方式,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual int SelectAccepterEnable 
	  { 
	     get{return _SelectAccepterEnable;}
	     set{_SelectAccepterEnable=value;}
	  }
	
      /// <summary>
      /// 节点时限
      /// </summary>
	  [DataMember]
	  public virtual string CHLab 
	  { 
	     get{return _CHLab;}
	     set{_CHLab=value;}
	  }
	
      /// <summary>
      /// 是否启用
      /// </summary>
	  [DataMember]
	  public virtual int CHEnable 
	  { 
	     get{return _CHEnable;}
	     set{_CHEnable=value;}
	  }
	
      /// <summary>
      /// 打开本地标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOpenLab 
	  { 
	     get{return _OfficeOpenLab;}
	     set{_OfficeOpenLab=value;}
	  }
	
      /// <summary>
      /// 打开模板标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOpenTemplateLab 
	  { 
	     get{return _OfficeOpenTemplateLab;}
	     set{_OfficeOpenTemplateLab=value;}
	  }
	
      /// <summary>
      /// 保存标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeSaveLab 
	  { 
	     get{return _OfficeSaveLab;}
	     set{_OfficeSaveLab=value;}
	  }
	
      /// <summary>
      /// 接受修订标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeAcceptLab 
	  { 
	     get{return _OfficeAcceptLab;}
	     set{_OfficeAcceptLab=value;}
	  }
	
      /// <summary>
      /// 拒绝修订标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeRefuseLab 
	  { 
	     get{return _OfficeRefuseLab;}
	     set{_OfficeRefuseLab=value;}
	  }
	
      /// <summary>
      /// 套红标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeOverLab 
	  { 
	     get{return _OfficeOverLab;}
	     set{_OfficeOverLab=value;}
	  }
	
      /// <summary>
      /// 是否查看用户留痕
      /// </summary>
	  [DataMember]
	  public virtual int OfficeMarksEnable 
	  { 
	     get{return _OfficeMarksEnable;}
	     set{_OfficeMarksEnable=value;}
	  }
	
      /// <summary>
      /// 打印标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficePrintLab 
	  { 
	     get{return _OfficePrintLab;}
	     set{_OfficePrintLab=value;}
	  }
	
      /// <summary>
      /// 签章标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeSealLab 
	  { 
	     get{return _OfficeSealLab;}
	     set{_OfficeSealLab=value;}
	  }
	
      /// <summary>
      /// 插入流程标签
      /// </summary>
	  [DataMember]
	  public virtual string OfficeInsertFlowLab 
	  { 
	     get{return _OfficeInsertFlowLab;}
	     set{_OfficeInsertFlowLab=value;}
	  }
	
      /// <summary>
      /// 是否自动套红
      /// </summary>
	  [DataMember]
	  public virtual int OfficeTHEnable 
	  { 
	     get{return _OfficeTHEnable;}
	     set{_OfficeTHEnable=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_NodeMap : ClassMap<WF_Node>
    {
        public WF_NodeMap()
        {
		Id(m => m.NodeID).GeneratedBy.SequenceIdentity();
				 Map(m => m.Step);
	        	 Map(m => m.FK_Flow);
	        	 Map(m => m.FlowName);
	        	 Map(m => m.Name);
	        	 Map(m => m.Tip);
	        	 Map(m => m.WhoExeIt);
	        	 Map(m => m.ReadReceipts);
	        	 Map(m => m.CondModel);
	        	 Map(m => m.CancelRole);
	        	 Map(m => m.CancelDisWhenRead);
	        	 Map(m => m.IsTask);
	        	 Map(m => m.IsExpSender);
	        	 Map(m => m.IsRM);
	        	 Map(m => m.IsGuestNode);
	        	 Map(m => m.DTFrom);
	        	 Map(m => m.DTTo);
	        	 Map(m => m.IsBUnit);
	        	 Map(m => m.FocusField);
	        	 Map(m => m.NodeAppType);
	        	 Map(m => m.FWCSta);
	        	 Map(m => m.SelfParas);
	        	 Map(m => m.RunModel);
	        	 Map(m => m.SubThreadType);
	        	 Map(m => m.PassRate);
	        	 Map(m => m.SubFlowStartWay);
	        	 Map(m => m.SubFlowStartParas);
	        	 Map(m => m.ThreadIsCanDel);
	        	 Map(m => m.ThreadIsCanShift);
	        	 Map(m => m.IsAllowRepeatEmps);
	        	 Map(m => m.AutoRunEnable);
	        	 Map(m => m.AutoRunParas);
	        	 Map(m => m.AutoJumpRole0);
	        	 Map(m => m.AutoJumpRole1);
	        	 Map(m => m.AutoJumpRole2);
	        	 Map(m => m.WhenNoWorker);
	        	 Map(m => m.SendLab);
	        	 Map(m => m.SendJS);
	        	 Map(m => m.SaveLab);
	        	 Map(m => m.SaveEnable);
	        	 Map(m => m.ThreadLab);
	        	 Map(m => m.ThreadEnable);
	        	 Map(m => m.ThreadKillRole);
	        	 Map(m => m.JumpWayLab);
	        	 Map(m => m.JumpWay);
	        	 Map(m => m.JumpToNodes);
	        	 Map(m => m.ReturnLab);
	        	 Map(m => m.ReturnRole);
	        	 Map(m => m.ReturnAlert);
	        	 Map(m => m.IsBackTracking);
	        	 Map(m => m.ReturnField);
	        	 Map(m => m.ReturnReasonsItems);
	        	 Map(m => m.ReturnOneNodeRole);
	        	 Map(m => m.CCLab);
	        	 Map(m => m.CCRole);
	        	 Map(m => m.CCWriteTo);
	        	 Map(m => m.DoOutTime);
	        	 Map(m => m.DoOutTimeCond);
	        	 Map(m => m.ShiftLab);
	        	 Map(m => m.ShiftEnable);
	        	 Map(m => m.DelLab);
	        	 Map(m => m.DelEnable);
	        	 Map(m => m.EndFlowLab);
	        	 Map(m => m.EndFlowEnable);
	        	 Map(m => m.ShowParentFormLab);
	        	 Map(m => m.ShowParentFormEnable);
	        	 Map(m => m.OfficeBtnLab);
	        	 Map(m => m.OfficeBtnEnable);
	        	 Map(m => m.PrintHtmlLab);
	        	 Map(m => m.PrintHtmlEnable);
	        	 Map(m => m.PrintPDFLab);
	        	 Map(m => m.PrintPDFEnable);
	        	 Map(m => m.PrintPDFModle);
	        	 Map(m => m.PrintZipLab);
	        	 Map(m => m.PrintZipEnable);
	        	 Map(m => m.PrintDocLab);
	        	 Map(m => m.PrintDocEnable);
	        	 Map(m => m.TrackLab);
	        	 Map(m => m.TrackEnable);
	        	 Map(m => m.HungLab);
	        	 Map(m => m.HungEnable);
	        	 Map(m => m.SearchLab);
	        	 Map(m => m.SearchEnable);
	        	 Map(m => m.WorkCheckLab);
	        	 Map(m => m.WorkCheckEnable);
	        	 Map(m => m.AskforLab);
	        	 Map(m => m.AskforEnable);
	        	 Map(m => m.HuiQianLab);
	        	 Map(m => m.HuiQianRole);
	        	 Map(m => m.TCLab);
	        	 Map(m => m.TCEnable);
	        	 Map(m => m.WebOffice);
	        	 Map(m => m.WebOfficeEnable);
	        	 Map(m => m.PRILab);
	        	 Map(m => m.PRIEnable);
	        	 Map(m => m.AllotLab);
	        	 Map(m => m.AllotEnable);
	        	 Map(m => m.FocusLab);
	        	 Map(m => m.FocusEnable);
	        	 Map(m => m.ConfirmLab);
	        	 Map(m => m.ConfirmEnable);
	        	 Map(m => m.ListLab);
	        	 Map(m => m.ListEnable);
	        	 Map(m => m.BatchLab);
	        	 Map(m => m.BatchEnable);
	        	 Map(m => m.TimeLimit);
	        	 Map(m => m.TWay);
	        	 Map(m => m.TAlertRole);
	        	 Map(m => m.TAlertWay);
	        	 Map(m => m.WarningDay);
	        	 Map(m => m.WAlertRole);
	        	 Map(m => m.WAlertWay);
	        	 Map(m => m.TCent);
	        	 Map(m => m.CHWay);
	        	 Map(m => m.IsEval);
	        	 Map(m => m.OutTimeDeal);
	        	 Map(m => m.CCIsAttr);
	        	 Map(m => m.CCFormAttr);
	        	 Map(m => m.CCIsStations);
	        	 Map(m => m.CCStaWay);
	        	 Map(m => m.CCIsDepts);
	        	 Map(m => m.CCIsEmps);
	        	 Map(m => m.CCIsSQLs);
	        	 Map(m => m.CCSQL);
	        	 Map(m => m.CCTitle);
	        	 Map(m => m.CCDoc);
	        	 Map(m => m.FWCLab);
	        	 Map(m => m.FWCShowModel);
	        	 Map(m => m.FWCType);
	        	 Map(m => m.FWCNodeName);
	        	 Map(m => m.FWCAth);
	        	 Map(m => m.FWCTrackEnable);
	        	 Map(m => m.FWCListEnable);
	        	 Map(m => m.FWCIsShowAllStep);
	        	 Map(m => m.FWCOpLabel);
	        	 Map(m => m.FWCDefInfo);
	        	 Map(m => m.SigantureEnabel);
	        	 Map(m => m.FWCIsFullInfo);
	        	 Map(m => m.FWC_X);
	        	 Map(m => m.FWC_Y);
	        	 Map(m => m.FWC_H);
	        	 Map(m => m.FWC_W);
	        	 Map(m => m.FWCFields);
	        	 Map(m => m.FWCIsShowTruck);
	        	 Map(m => m.FWCIsShowReturnMsg);
	        	 Map(m => m.FWCOrderModel);
	        	 Map(m => m.FWCMsgShow);
	        	 Map(m => m.ICON);
	        	 Map(m => m.NodeWorkType);
	        	 Map(m => m.FrmAttr);
	        	 Map(m => m.Doc);
	        	 Map(m => m.DeliveryWay);
	        	 Map(m => m.DeliveryParas);
	        	 Map(m => m.NodeFrmID);
	        	 Map(m => m.SaveModel);
	        	 Map(m => m.IsCanDelFlow);
	        	 Map(m => m.TodolistModel);
	        	 Map(m => m.TeamLeaderConfirmRole);
	        	 Map(m => m.TeamLeaderConfirmDoc);
	        	 Map(m => m.IsHandOver);
	        	 Map(m => m.BlockModel);
	        	 Map(m => m.BlockExp);
	        	 Map(m => m.BlockAlert);
	        	 Map(m => m.SFActiveFlows);
	        	 Map(m => m.BatchRole);
	        	 Map(m => m.BatchListCount);
	        	 Map(m => m.BatchParas);
	        	 Map(m => m.FormType);
	        	 Map(m => m.FormUrl);
	        	 Map(m => m.TurnToDeal);
	        	 Map(m => m.TurnToDealDoc);
	        	 Map(m => m.NodePosType);
	        	 Map(m => m.IsCCFlow);
	        	 Map(m => m.HisStas);
	        	 Map(m => m.HisDeptStrs);
	        	 Map(m => m.HisToNDs);
	        	 Map(m => m.HisBillIDs);
	        	 Map(m => m.HisSubFlows);
	        	 Map(m => m.PTable);
	        	 Map(m => m.GroupStaNDs);
	        	 Map(m => m.X);
	        	 Map(m => m.Y);
	        	 Map(m => m.RefOneFrmTreeType);
	        	 Map(m => m.AtPara);
	        	 Map(m => m.CheckNodes);
	        	 Map(m => m.FrmTrackLab);
	        	 Map(m => m.FrmTrackSta);
	        	 Map(m => m.FrmTrack_X);
	        	 Map(m => m.FrmTrack_Y);
	        	 Map(m => m.FrmTrack_H);
	        	 Map(m => m.FrmTrack_W);
	        	 Map(m => m.FrmThreadLab);
	        	 Map(m => m.FrmThreadSta);
	        	 Map(m => m.FrmThread_X);
	        	 Map(m => m.FrmThread_Y);
	        	 Map(m => m.FrmThread_H);
	        	 Map(m => m.FrmThread_W);
	        	 Map(m => m.SFLab);
	        	 Map(m => m.SFSta);
	        	 Map(m => m.SFShowModel);
	        	 Map(m => m.SFCaption);
	        	 Map(m => m.SFDefInfo);
	        	 Map(m => m.SF_X);
	        	 Map(m => m.SF_Y);
	        	 Map(m => m.SF_H);
	        	 Map(m => m.SF_W);
	        	 Map(m => m.SFFields);
	        	 Map(m => m.SFShowCtrl);
	        	 Map(m => m.SFOpenType);
	        	 Map(m => m.FTCLab);
	        	 Map(m => m.FTCSta);
	        	 Map(m => m.FTCWorkModel);
	        	 Map(m => m.FTC_X);
	        	 Map(m => m.FTC_Y);
	        	 Map(m => m.FTC_H);
	        	 Map(m => m.FTC_W);
	        	 Map(m => m.OfficeOpen);
	        	 Map(m => m.OfficeOpenEnable);
	        	 Map(m => m.OfficeOpenTemplate);
	        	 Map(m => m.OfficeOpenTemplateEnable);
	        	 Map(m => m.OfficeSave);
	        	 Map(m => m.OfficeSaveEnable);
	        	 Map(m => m.OfficeAccept);
	        	 Map(m => m.OfficeAcceptEnable);
	        	 Map(m => m.OfficeRefuse);
	        	 Map(m => m.OfficeRefuseEnable);
	        	 Map(m => m.OfficeOver);
	        	 Map(m => m.OfficeOverEnable);
	        	 Map(m => m.OfficeMarks);
	        	 Map(m => m.OfficeReadOnly);
	        	 Map(m => m.OfficePrint);
	        	 Map(m => m.OfficePrintEnable);
	        	 Map(m => m.OfficeSeal);
	        	 Map(m => m.OfficeSealEnable);
	        	 Map(m => m.OfficeInsertFlow);
	        	 Map(m => m.OfficeInsertFlowEnable);
	        	 Map(m => m.OfficeNodeInfo);
	        	 Map(m => m.OfficeReSavePDF);
	        	 Map(m => m.OfficeDownLab);
	        	 Map(m => m.OfficeDownEnable);
	        	 Map(m => m.OfficeIsMarks);
	        	 Map(m => m.OfficeTemplate);
	        	 Map(m => m.OfficeIsParent);
	        	 Map(m => m.OfficeIsTrueTH);
	        	 Map(m => m.OfficeTHTemplate);
	        	 Map(m => m.WebOfficeFrmModel);
	        	 Map(m => m.SelectorModel);
	        	 Map(m => m.FK_SQLTemplate);
	        	 Map(m => m.FK_SQLTemplateText);
	        	 Map(m => m.IsAutoLoadEmps);
	        	 Map(m => m.IsSimpleSelector);
	        	 Map(m => m.IsEnableDeptRange);
	        	 Map(m => m.IsEnableStaRange);
	        	 Map(m => m.SelectorP1);
	        	 Map(m => m.SelectorP2);
	        	 Map(m => m.SelectorP3);
	        	 Map(m => m.SelectorP4);
	        	 Map(m => m.SelectAccepterLab);
	        	 Map(m => m.SelectAccepterEnable);
	        	 Map(m => m.CHLab);
	        	 Map(m => m.CHEnable);
	        	 Map(m => m.OfficeOpenLab);
	        	 Map(m => m.OfficeOpenTemplateLab);
	        	 Map(m => m.OfficeSaveLab);
	        	 Map(m => m.OfficeAcceptLab);
	        	 Map(m => m.OfficeRefuseLab);
	        	 Map(m => m.OfficeOverLab);
	        	 Map(m => m.OfficeMarksEnable);
	        	 Map(m => m.OfficePrintLab);
	        	 Map(m => m.OfficeSealLab);
	        	 Map(m => m.OfficeInsertFlowLab);
	        	 Map(m => m.OfficeTHEnable);
	        		
						     }
    }
}

