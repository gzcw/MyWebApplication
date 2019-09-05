////using HR.WorkflowService.DAOs;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;
using System.Linq;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 节点
    /// </summary>
    [DataContract]
    public class NODE : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public NODE() : base("WF_NODE") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="nODEID">NodeID,-,主键</param>
        ///<param name="nAME">名称</param>
        ///<param name="sTEP">流程步骤</param>
        ///<param name="fK_FLOW">FK_Flow</param>
        ///<param name="cHECKNODES">工作节点s</param>
        ///<param name="dELIVERYWAY">访问规则</param>
        ///<param name="iSTASK">允许分配工作否?</param>
        ///<param name="iSRM">是否起用投递路径自动记忆功能?</param>
        ///<param name="iSGUESTNODE">是否是客户执行节点</param>
        ///<param name="fOCUSFIELD">焦点字段</param>
        ///<param name="dELIVERYPARAS">访问规则设置</param>
        ///<param name="wHOEXEIT">谁执行它</param>
        ///<param name="fORMTYPE">表单类型</param>
        ///<param name="fORMURL">表单URL</param>
        ///<param name="nODEFRMID">节点表单ID</param>
        ///<param name="tURNTODEAL">转向处理</param>
        ///<param name="tURNTODEALDOC">发送后提示信息</param>
        ///<param name="rEADRECEIPTS">已读回执</param>
        ///<param name="cONDMODEL">方向条件控制规则</param>
        ///<param name="dTFROM">生命周期从</param>
        ///<param name="dTTO">生命周期到</param>
        ///<param name="sAVEMODEL">保存模式</param>
        ///<param name="cANCELROLE">撤销规则</param>
        ///<param name="bATCHROLE">批处理</param>
        ///<param name="bATCHPARAS">参数</param>
        ///<param name="rUNMODEL">运行模式(对普通节点有效)</param>
        ///<param name="tHREADKILLROLE">子线程删除方式</param>
        ///<param name="iSALLOWREPEATEMPS">是否允许子线程接受人员重复(对子线程点有效)?</param>
        ///<param name="sUBTHREADTYPE">子线程ID</param>
        ///<param name="pASSRATE">通过率</param>
        ///<param name="sUBFLOWSTARTWAY">子线程启动方式</param>
        ///<param name="sUBFLOWSTARTPARAS">启动参数</param>
        ///<param name="tODOLISTMODEL">是否是队列节点</param>
        ///<param name="aUTOJUMPROLE0">处理人就是提交人0</param>
        ///<param name="aUTOJUMPROLE1">处理人已经出现过1</param>
        ///<param name="aUTOJUMPROLE2">处理人与上一步相同2</param>
        ///<param name="wHENNOWORKER">未找到处理人时</param>
        ///<param name="sENDLAB">发送按钮标签</param>
        ///<param name="sENDJS">按钮JS函数</param>
        ///<param name="sAVELAB">保存按钮标签</param>
        ///<param name="sAVEENABLE">是否启用</param>
        ///<param name="tHREADLAB">子线程按钮标签</param>
        ///<param name="tHREADENABLE">是否启用</param>
        ///<param name="sUBFLOWLAB">子流程按钮标签</param>
        ///<param name="sUBFLOWCTRLROLE">控制规则,枚举类型:0,无;1,不可以删除子流程;2,可以删除子流程;</param>
        ///<param name="jUMPWAYLAB">跳转按钮标签</param>
        ///<param name="jUMPWAY">是否启用</param>
        ///<param name="jUMPSQL">可跳转的节点</param>
        ///<param name="rETURNLAB">退回按钮标签</param>
        ///<param name="rETURNROLE">是否启用</param>
        ///<param name="iSBACKTRACKING">是否可以在退回后原路返回(只有启用退回功能才有效)</param>
        ///<param name="rETURNFIELD">退回信息填写字段</param>
        ///<param name="cCLAB">抄送按钮标签</param>
        ///<param name="cCROLE">抄送规则,枚举类型:0,不能抄送;1,手工抄送;2,自动抄送;3,手工与自动;4,按表单SysCCEmps字段计算;</param>
        ///<param name="cCWRITETO">抄送数据写入规则</param>
        ///<param name="sHIFTLAB">移交按钮标签</param>
        ///<param name="sHIFTENABLE">是否启用</param>
        ///<param name="dELLAB">删除流程按钮标签</param>
        ///<param name="dELENABLE">是否启用</param>
        ///<param name="eNDFLOWLAB">结束流程按钮标签</param>
        ///<param name="eNDFLOWENABLE">是否启用</param>
        ///<param name="pRINTDOCLAB">打印单据按钮标签</param>
        ///<param name="pRINTDOCENABLE">是否启用</param>
        ///<param name="tRACKLAB">轨迹按钮标签</param>
        ///<param name="tRACKENABLE">是否启用</param>
        ///<param name="hUNGLAB">挂起按钮标签</param>
        ///<param name="hUNGENABLE">是否启用</param>
        ///<param name="sELECTACCEPTERLAB">接受人按钮标签</param>
        ///<param name="sELECTACCEPTERENABLE">方式,枚举类型:0,不启用;1,单独启用;2,在发送前打开;</param>
        ///<param name="sEARCHLAB">查询按钮标签</param>
        ///<param name="sEARCHENABLE">是否启用</param>
        ///<param name="wORKCHECKLAB">审核按钮标签</param>
        ///<param name="wORKCHECKENABLE">是否启用</param>
        ///<param name="bATCHLAB">批量审核标签</param>
        ///<param name="bATCHENABLE">是否启用</param>
        ///<param name="aSKFORLAB">加签标签</param>
        ///<param name="aSKFORENABLE">是否启用</param>
        ///<param name="wEBOFFICE">公文标签</param>
        ///<param name="wEBOFFICEENABLE">文档启用方式,枚举类型:0,不启用;1,按钮方式;2,标签页方式;</param>
        ///<param name="wARNINGDAYS">警告期限(0不警告)</param>
        ///<param name="dEDUCTDAYS">限期(天)</param>
        ///<param name="dEDUCTCENT">扣分(每延期1天扣)</param>
        ///<param name="mAXDEDUCTCENT">最高扣分</param>
        ///<param name="sWINKCENT">工作得分</param>
        ///<param name="oUTTIMEDEAL">超时处理方式</param>
        ///<param name="dOOUTTIME">超时处理内容</param>
        ///<param name="dOOUTTIMECOND">执行超时条件</param>
        ///<param name="cHWAY">考核方式,枚举类型:0,不考核;1,按时效;2,按工作量;</param>
        ///<param name="wORKLOAD">工作量(单位:分钟)</param>
        ///<param name="iSEVAL">是否工作质量考核</param>
        ///<param name="fWCSTA">审核组件状态,枚举类型:0,禁用;1,启用;2,只读;</param>
        ///<param name="fWCSHOWMODEL">显示方式,枚举类型:0,表格方式;1,自由模式;</param>
        ///<param name="fWCTYPE">审核组件,枚举类型:0,审核组件;1,日志组件;</param>
        ///<param name="fWCTRACKENABLE">轨迹图是否显示？</param>
        ///<param name="fWCLISTENABLE">是否显示历史审核信息？(否,历史信息仅出现意见框)</param>
        ///<param name="fWCISSHOWALLSTEP">在轨迹表里是否显示未发生的步骤？</param>
        ///<param name="fWCOPLABEL">操作名词(审核/审阅/批示)</param>
        ///<param name="fWCDEFINFO">默认审核信息</param>
        ///<param name="sIGANTUREENABEL">是否显示数字签名？</param>
        ///<param name="fWCISFULLINFO">如果用户未审核是否按照默认意见填充？</param>
        ///<param name="fWC_H">高度</param>
        ///<param name="fWC_W">宽度</param>
        ///<param name="iSCHECKSUBFLOWOVER">(当前节点为父流程时)是否检查子流程完成后父流程才能执行</param>
        ///<param name="dOCLEFTWORD">公文左边词语(多个用@符合隔开)</param>
        ///<param name="dOCRIGHTWORD">公文右边词语(多个用@符合隔开)</param>
        ///<param name="oFFICEOPEN">打开本地标签</param>
        ///<param name="oFFICEOPENENABLE">是否启用</param>
        ///<param name="oFFICEOPENTEMPLATE">打开模板标签</param>
        ///<param name="oFFICEOPENTEMPLATEENABLE">是否启用</param>
        ///<param name="oFFICESAVE">保存标签</param>
        ///<param name="oFFICESAVEENABLE">是否启用</param>
        ///<param name="oFFICEACCEPT">接受修订标签</param>
        ///<param name="oFFICEACCEPTENABLE">是否启用</param>
        ///<param name="oFFICEREFUSE">拒绝修订标签</param>
        ///<param name="oFFICEREFUSEENABLE">是否启用</param>
        ///<param name="oFFICEOVER">套红标签</param>
        ///<param name="oFFICEOVERENABLE">是否启用</param>
        ///<param name="oFFICEMARKS">是否查看用户留痕</param>
        ///<param name="oFFICEREADONLY">是否只读</param>
        ///<param name="oFFICEPRINT">打印标签</param>
        ///<param name="oFFICEPRINTENABLE">是否启用</param>
        ///<param name="oFFICESEAL">签章标签</param>
        ///<param name="oFFICESEALENABLE">是否启用</param>
        ///<param name="oFFICEINSERTFLOW">插入流程标签</param>
        ///<param name="oFFICEINSERTFLOWENABEL">是否启用</param>
        ///<param name="oFFICEINSERTFENGXIAN">插入风险点标签</param>
        ///<param name="oFFICEINSERTFENGXIANENABEL">是否启用</param>
        ///<param name="oFFICENODEINFO">是否记录节点信息</param>
        ///<param name="oFFICERESAVEPDF">是否该自动保存为PDF</param>
        ///<param name="oFFICEDOWNLAB">下载按钮标签</param>
        ///<param name="oFFICEISDOWN">是否启用</param>
        ///<param name="oFFICEISMARKS">是否进入留痕模式</param>
        ///<param name="mPHONE_WORKMODEL">手机工作模式,枚举类型:0,原生态;1,浏览器;2,禁用;</param>
        ///<param name="mPHONE_SRCMODEL">手机屏幕模式,枚举类型:0,强制横屏;1,强制竖屏;2,由重力感应决定;</param>
        ///<param name="mPAD_WORKMODEL">平板工作模式,枚举类型:0,原生态;1,浏览器;2,禁用;</param>
        ///<param name="mPAD_SRCMODEL">平板屏幕模式,枚举类型:0,强制横屏;1,强制竖屏;2,由重力感应决定;</param>
        ///<param name="fWC_X">位置X</param>
        ///<param name="fWC_Y">位置Y</param>
        ///<param name="sELECTORMODEL">窗口模式,枚举类型:0,按岗位;1,按部门;2,按人员;3,按SQL;4,自定义Url;</param>
        ///<param name="sELECTORP1">参数1</param>
        ///<param name="sELECTORP2">参数2</param>
        ///<param name="sELECTORDBSHOWWAY">数据显示方式,枚举类型:0,表格显示;1,树形显示;</param>
        ///<param name="cCCTRLWAY">控制方式,枚举类型:</param>
        ///<param name="cCSQL">SQL表达式</param>
        ///<param name="cCTITLE">抄送标题</param>
        ///<param name="cCDOC">抄送内容(标题与内容支持变量)</param>
        ///<param name="nODEWORKTYPE">节点类型</param>
        ///<param name="fLOWNAME">流程名</param>
        ///<param name="fK_FLOWSORT">FK_FlowSort</param>
        ///<param name="fK_FLOWSORTT">FK_FlowSortT</param>
        ///<param name="fRMATTR">FrmAttr</param>
        ///<param name="dOC">描述</param>
        ///<param name="iSCANRPT">是否可以查看工作报告?</param>
        ///<param name="iSCANOVER">是否可以终止流程</param>
        ///<param name="iSSECRET">是否是保密步骤</param>
        ///<param name="iSCANDELFLOW">是否可以删除流程</param>
        ///<param name="iSHANDOVER">是否可以移交</param>
        ///<param name="nODEPOSTYPE">位置</param>
        ///<param name="iSCCFLOW">是否有流程完成条件</param>
        ///<param name="hISSTAS">岗位</param>
        ///<param name="hISDEPTSTRS">部门</param>
        ///<param name="hISTONDS">转到的节点</param>
        ///<param name="hISBILLIDS">单据IDs</param>
        ///<param name="hISSUBFLOWS">HisSubFlows</param>
        ///<param name="pTABLE">物理表</param>
        ///<param name="sHOWSHEETS">显示的表单</param>
        ///<param name="gROUPSTANDS">岗位分组节点</param>
        ///<param name="x">X坐标</param>
        ///<param name="y">Y坐标</param>
        ///<param name="aTPARA">AtPara</param>
        public NODE(string nODEID, string nAME, decimal? sTEP, string fK_FLOW, string cHECKNODES, decimal? dELIVERYWAY, decimal iSTASK, decimal iSRM, decimal iSGUESTNODE, string fOCUSFIELD, string dELIVERYPARAS, decimal wHOEXEIT, decimal fORMTYPE, string fORMURL, string nODEFRMID, decimal tURNTODEAL, string tURNTODEALDOC, decimal rEADRECEIPTS, decimal cONDMODEL, string dTFROM, string dTTO, decimal sAVEMODEL, decimal cANCELROLE, decimal bATCHROLE, string bATCHPARAS, decimal rUNMODEL, decimal tHREADKILLROLE, decimal iSALLOWREPEATEMPS, decimal sUBTHREADTYPE, decimal? pASSRATE, decimal sUBFLOWSTARTWAY, string sUBFLOWSTARTPARAS, decimal tODOLISTMODEL, decimal aUTOJUMPROLE0, decimal aUTOJUMPROLE1, decimal aUTOJUMPROLE2, decimal wHENNOWORKER, string sENDLAB, string sENDJS, string sAVELAB, decimal sAVEENABLE, string tHREADLAB, decimal tHREADENABLE, string sUBFLOWLAB, decimal sUBFLOWCTRLROLE, string jUMPWAYLAB, decimal jUMPWAY, string jUMPSQL, string rETURNLAB, decimal rETURNROLE, decimal iSBACKTRACKING, string rETURNFIELD, string cCLAB, decimal cCROLE, decimal cCWRITETO, string sHIFTLAB, decimal sHIFTENABLE, string dELLAB, decimal dELENABLE, string eNDFLOWLAB, decimal eNDFLOWENABLE, string pRINTDOCLAB, decimal pRINTDOCENABLE, string tRACKLAB, decimal tRACKENABLE, string hUNGLAB, decimal hUNGENABLE, string sELECTACCEPTERLAB, decimal sELECTACCEPTERENABLE, string sEARCHLAB, decimal sEARCHENABLE, string wORKCHECKLAB, decimal wORKCHECKENABLE, string bATCHLAB, decimal bATCHENABLE, string aSKFORLAB, decimal aSKFORENABLE, string wEBOFFICE, decimal wEBOFFICEENABLE, decimal? wARNINGDAYS, decimal? dEDUCTDAYS, decimal? dEDUCTCENT, decimal? mAXDEDUCTCENT, decimal? sWINKCENT, decimal oUTTIMEDEAL, string dOOUTTIME, string dOOUTTIMECOND, decimal cHWAY, decimal? wORKLOAD, decimal iSEVAL, decimal fWCSTA, decimal fWCSHOWMODEL, decimal fWCTYPE, decimal fWCTRACKENABLE, decimal fWCLISTENABLE, decimal fWCISSHOWALLSTEP, string fWCOPLABEL, string fWCDEFINFO, decimal sIGANTUREENABEL, decimal fWCISFULLINFO, decimal? fWC_H, decimal? fWC_W, decimal iSCHECKSUBFLOWOVER, string dOCLEFTWORD, string dOCRIGHTWORD, string oFFICEOPEN, decimal oFFICEOPENENABLE, string oFFICEOPENTEMPLATE, decimal oFFICEOPENTEMPLATEENABLE, string oFFICESAVE, decimal oFFICESAVEENABLE, string oFFICEACCEPT, decimal oFFICEACCEPTENABLE, string oFFICEREFUSE, decimal oFFICEREFUSEENABLE, string oFFICEOVER, decimal oFFICEOVERENABLE, decimal oFFICEMARKS, decimal oFFICEREADONLY, string oFFICEPRINT, decimal oFFICEPRINTENABLE, string oFFICESEAL, decimal oFFICESEALENABLE, string oFFICEINSERTFLOW, decimal oFFICEINSERTFLOWENABEL, string oFFICEINSERTFENGXIAN, decimal oFFICEINSERTFENGXIANENABEL, decimal oFFICENODEINFO, decimal oFFICERESAVEPDF, string oFFICEDOWNLAB, decimal oFFICEISDOWN, decimal oFFICEISMARKS, decimal mPHONE_WORKMODEL, decimal mPHONE_SRCMODEL, decimal mPAD_WORKMODEL, decimal mPAD_SRCMODEL, decimal? fWC_X, decimal? fWC_Y, decimal sELECTORMODEL, string sELECTORP1, string sELECTORP2, decimal sELECTORDBSHOWWAY, decimal cCCTRLWAY, string cCSQL, string cCTITLE, string cCDOC, decimal nODEWORKTYPE, string fLOWNAME, string fK_FLOWSORT, string fK_FLOWSORTT, string fRMATTR, string dOC, decimal iSCANRPT, decimal iSCANOVER, decimal iSSECRET, decimal iSCANDELFLOW, decimal iSHANDOVER, decimal nODEPOSTYPE, decimal iSCCFLOW, string hISSTAS, string hISDEPTSTRS, string hISTONDS, string hISBILLIDS, string hISSUBFLOWS, string pTABLE, string sHOWSHEETS, string gROUPSTANDS, decimal x, decimal y, string aTPARA)
            : this()
        {
            this.NODEID = nODEID;
            this.NAME = nAME;
            this.STEP = sTEP;
            this.FK_FLOW = fK_FLOW;
            this.CHECKNODES = cHECKNODES;
            this.DELIVERYWAY = dELIVERYWAY;
            this.ISTASK = iSTASK;
            this.ISRM = iSRM;
            this.ISGUESTNODE = iSGUESTNODE;
            this.FOCUSFIELD = fOCUSFIELD;
            this.DELIVERYPARAS = dELIVERYPARAS;
            this.WHOEXEIT = wHOEXEIT;
            this.FORMTYPE = fORMTYPE;
            this.FORMURL = fORMURL;
            this.NODEFRMID = nODEFRMID;
            this.TURNTODEAL = tURNTODEAL;
            this.TURNTODEALDOC = tURNTODEALDOC;
            this.READRECEIPTS = rEADRECEIPTS;
            this.CONDMODEL = cONDMODEL;
            this.DTFROM = dTFROM;
            this.DTTO = dTTO;
            this.SAVEMODEL = sAVEMODEL;
            this.CANCELROLE = cANCELROLE;
            this.BATCHROLE = bATCHROLE;
            this.BATCHPARAS = bATCHPARAS;
            this.RUNMODEL = rUNMODEL;
            this.THREADKILLROLE = tHREADKILLROLE;
            this.ISALLOWREPEATEMPS = iSALLOWREPEATEMPS;
            this.SUBTHREADTYPE = sUBTHREADTYPE;
            this.PASSRATE = pASSRATE;
            this.SUBFLOWSTARTWAY = sUBFLOWSTARTWAY;
            this.SUBFLOWSTARTPARAS = sUBFLOWSTARTPARAS;
            this.TODOLISTMODEL = tODOLISTMODEL;
            this.AUTOJUMPROLE0 = aUTOJUMPROLE0;
            this.AUTOJUMPROLE1 = aUTOJUMPROLE1;
            this.AUTOJUMPROLE2 = aUTOJUMPROLE2;
            this.WHENNOWORKER = wHENNOWORKER;
            this.SENDLAB = sENDLAB;
            this.SENDJS = sENDJS;
            this.SAVELAB = sAVELAB;
            this.SAVEENABLE = sAVEENABLE;
            this.THREADLAB = tHREADLAB;
            this.THREADENABLE = tHREADENABLE;
            this.SUBFLOWLAB = sUBFLOWLAB;
            this.SUBFLOWCTRLROLE = sUBFLOWCTRLROLE;
            this.JUMPWAYLAB = jUMPWAYLAB;
            this.JUMPWAY = jUMPWAY;
            this.JUMPSQL = jUMPSQL;
            this.RETURNLAB = rETURNLAB;
            this.RETURNROLE = rETURNROLE;
            this.ISBACKTRACKING = iSBACKTRACKING;
            this.RETURNFIELD = rETURNFIELD;
            this.CCLAB = cCLAB;
            this.CCROLE = cCROLE;
            this.CCWRITETO = cCWRITETO;
            this.SHIFTLAB = sHIFTLAB;
            this.SHIFTENABLE = sHIFTENABLE;
            this.DELLAB = dELLAB;
            this.DELENABLE = dELENABLE;
            this.ENDFLOWLAB = eNDFLOWLAB;
            this.ENDFLOWENABLE = eNDFLOWENABLE;
            this.PRINTDOCLAB = pRINTDOCLAB;
            this.PRINTDOCENABLE = pRINTDOCENABLE;
            this.TRACKLAB = tRACKLAB;
            this.TRACKENABLE = tRACKENABLE;
            this.HUNGLAB = hUNGLAB;
            this.HUNGENABLE = hUNGENABLE;
            this.SELECTACCEPTERLAB = sELECTACCEPTERLAB;
            this.SELECTACCEPTERENABLE = sELECTACCEPTERENABLE;
            this.SEARCHLAB = sEARCHLAB;
            this.SEARCHENABLE = sEARCHENABLE;
            this.WORKCHECKLAB = wORKCHECKLAB;
            this.WORKCHECKENABLE = wORKCHECKENABLE;
            this.BATCHLAB = bATCHLAB;
            this.BATCHENABLE = bATCHENABLE;
            this.ASKFORLAB = aSKFORLAB;
            this.ASKFORENABLE = aSKFORENABLE;
            this.WEBOFFICE = wEBOFFICE;
            this.WEBOFFICEENABLE = wEBOFFICEENABLE;
            this.WARNINGDAYS = wARNINGDAYS;
            this.DEDUCTDAYS = dEDUCTDAYS;
            this.DEDUCTCENT = dEDUCTCENT;
            this.MAXDEDUCTCENT = mAXDEDUCTCENT;
            this.SWINKCENT = sWINKCENT;
            this.OUTTIMEDEAL = oUTTIMEDEAL;
            this.DOOUTTIME = dOOUTTIME;
            this.DOOUTTIMECOND = dOOUTTIMECOND;
            this.CHWAY = cHWAY;
            this.WORKLOAD = wORKLOAD;
            this.ISEVAL = iSEVAL;
            this.FWCSTA = fWCSTA;
            this.FWCSHOWMODEL = fWCSHOWMODEL;
            this.FWCTYPE = fWCTYPE;
            this.FWCTRACKENABLE = fWCTRACKENABLE;
            this.FWCLISTENABLE = fWCLISTENABLE;
            this.FWCISSHOWALLSTEP = fWCISSHOWALLSTEP;
            this.FWCOPLABEL = fWCOPLABEL;
            this.FWCDEFINFO = fWCDEFINFO;
            this.SIGANTUREENABEL = sIGANTUREENABEL;
            this.FWCISFULLINFO = fWCISFULLINFO;
            this.FWC_H = fWC_H;
            this.FWC_W = fWC_W;
            this.ISCHECKSUBFLOWOVER = iSCHECKSUBFLOWOVER;
            this.DOCLEFTWORD = dOCLEFTWORD;
            this.DOCRIGHTWORD = dOCRIGHTWORD;
            this.OFFICEOPEN = oFFICEOPEN;
            this.OFFICEOPENENABLE = oFFICEOPENENABLE;
            this.OFFICEOPENTEMPLATE = oFFICEOPENTEMPLATE;
            this.OFFICEOPENTEMPLATEENABLE = oFFICEOPENTEMPLATEENABLE;
            this.OFFICESAVE = oFFICESAVE;
            this.OFFICESAVEENABLE = oFFICESAVEENABLE;
            this.OFFICEACCEPT = oFFICEACCEPT;
            this.OFFICEACCEPTENABLE = oFFICEACCEPTENABLE;
            this.OFFICEREFUSE = oFFICEREFUSE;
            this.OFFICEREFUSEENABLE = oFFICEREFUSEENABLE;
            this.OFFICEOVER = oFFICEOVER;
            this.OFFICEOVERENABLE = oFFICEOVERENABLE;
            this.OFFICEMARKS = oFFICEMARKS;
            this.OFFICEREADONLY = oFFICEREADONLY;
            this.OFFICEPRINT = oFFICEPRINT;
            this.OFFICEPRINTENABLE = oFFICEPRINTENABLE;
            this.OFFICESEAL = oFFICESEAL;
            this.OFFICESEALENABLE = oFFICESEALENABLE;
            this.OFFICEINSERTFLOW = oFFICEINSERTFLOW;
            this.OFFICEINSERTFLOWENABEL = oFFICEINSERTFLOWENABEL;
            this.OFFICEINSERTFENGXIAN = oFFICEINSERTFENGXIAN;
            this.OFFICEINSERTFENGXIANENABEL = oFFICEINSERTFENGXIANENABEL;
            this.OFFICENODEINFO = oFFICENODEINFO;
            this.OFFICERESAVEPDF = oFFICERESAVEPDF;
            this.OFFICEDOWNLAB = oFFICEDOWNLAB;
            this.OFFICEISDOWN = oFFICEISDOWN;
            this.OFFICEISMARKS = oFFICEISMARKS;
            this.MPHONE_WORKMODEL = mPHONE_WORKMODEL;
            this.MPHONE_SRCMODEL = mPHONE_SRCMODEL;
            this.MPAD_WORKMODEL = mPAD_WORKMODEL;
            this.MPAD_SRCMODEL = mPAD_SRCMODEL;
            this.FWC_X = fWC_X;
            this.FWC_Y = fWC_Y;
            this.SELECTORMODEL = sELECTORMODEL;
            this.SELECTORP1 = sELECTORP1;
            this.SELECTORP2 = sELECTORP2;
            this.SELECTORDBSHOWWAY = sELECTORDBSHOWWAY;
            this.CCCTRLWAY = cCCTRLWAY;
            this.CCSQL = cCSQL;
            this.CCTITLE = cCTITLE;
            this.CCDOC = cCDOC;
            this.NODEWORKTYPE = nODEWORKTYPE;
            this.FLOWNAME = fLOWNAME;
            this.FK_FLOWSORT = fK_FLOWSORT;
            this.FK_FLOWSORTT = fK_FLOWSORTT;
            this.FRMATTR = fRMATTR;
            this.DOC = dOC;
            this.ISCANRPT = iSCANRPT;
            this.ISCANOVER = iSCANOVER;
            this.ISSECRET = iSSECRET;
            this.ISCANDELFLOW = iSCANDELFLOW;
            this.ISHANDOVER = iSHANDOVER;
            this.NODEPOSTYPE = nODEPOSTYPE;
            this.ISCCFLOW = iSCCFLOW;
            this.HISSTAS = hISSTAS;
            this.HISDEPTSTRS = hISDEPTSTRS;
            this.HISTONDS = hISTONDS;
            this.HISBILLIDS = hISBILLIDS;
            this.HISSUBFLOWS = hISSUBFLOWS;
            this.PTABLE = pTABLE;
            this.SHOWSHEETS = sHOWSHEETS;
            this.GROUPSTANDS = gROUPSTANDS;
            this.X = x;
            this.Y = y;
            this.ATPARA = aTPARA;
        }
        #endregion

        #region 其他方法
        /// <summary>
        /// 重写实体对象哈希值的获取方法
        /// </summary>
        /// <returns>实体对象的哈希值</returns>
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(this.NODEID);
            sb.Append(this.NAME);
            sb.Append(this.STEP);
            sb.Append(this.FK_FLOW);
            sb.Append(this.CHECKNODES);
            sb.Append(this.DELIVERYWAY);
            sb.Append(this.ISTASK);
            sb.Append(this.ISRM);
            sb.Append(this.ISGUESTNODE);
            sb.Append(this.FOCUSFIELD);
            sb.Append(this.DELIVERYPARAS);
            sb.Append(this.WHOEXEIT);
            sb.Append(this.FORMTYPE);
            sb.Append(this.FORMURL);
            sb.Append(this.NODEFRMID);
            sb.Append(this.TURNTODEAL);
            sb.Append(this.TURNTODEALDOC);
            sb.Append(this.READRECEIPTS);
            sb.Append(this.CONDMODEL);
            sb.Append(this.DTFROM);
            sb.Append(this.DTTO);
            sb.Append(this.SAVEMODEL);
            sb.Append(this.CANCELROLE);
            sb.Append(this.BATCHROLE);
            sb.Append(this.BATCHPARAS);
            sb.Append(this.RUNMODEL);
            sb.Append(this.THREADKILLROLE);
            sb.Append(this.ISALLOWREPEATEMPS);
            sb.Append(this.SUBTHREADTYPE);
            sb.Append(this.PASSRATE);
            sb.Append(this.SUBFLOWSTARTWAY);
            sb.Append(this.SUBFLOWSTARTPARAS);
            sb.Append(this.TODOLISTMODEL);
            sb.Append(this.AUTOJUMPROLE0);
            sb.Append(this.AUTOJUMPROLE1);
            sb.Append(this.AUTOJUMPROLE2);
            sb.Append(this.WHENNOWORKER);
            sb.Append(this.SENDLAB);
            sb.Append(this.SENDJS);
            sb.Append(this.SAVELAB);
            sb.Append(this.SAVEENABLE);
            sb.Append(this.THREADLAB);
            sb.Append(this.THREADENABLE);
            sb.Append(this.SUBFLOWLAB);
            sb.Append(this.SUBFLOWCTRLROLE);
            sb.Append(this.JUMPWAYLAB);
            sb.Append(this.JUMPWAY);
            sb.Append(this.JUMPSQL);
            sb.Append(this.RETURNLAB);
            sb.Append(this.RETURNROLE);
            sb.Append(this.ISBACKTRACKING);
            sb.Append(this.RETURNFIELD);
            sb.Append(this.CCLAB);
            sb.Append(this.CCROLE);
            sb.Append(this.CCWRITETO);
            sb.Append(this.SHIFTLAB);
            sb.Append(this.SHIFTENABLE);
            sb.Append(this.DELLAB);
            sb.Append(this.DELENABLE);
            sb.Append(this.ENDFLOWLAB);
            sb.Append(this.ENDFLOWENABLE);
            sb.Append(this.PRINTDOCLAB);
            sb.Append(this.PRINTDOCENABLE);
            sb.Append(this.TRACKLAB);
            sb.Append(this.TRACKENABLE);
            sb.Append(this.HUNGLAB);
            sb.Append(this.HUNGENABLE);
            sb.Append(this.SELECTACCEPTERLAB);
            sb.Append(this.SELECTACCEPTERENABLE);
            sb.Append(this.SEARCHLAB);
            sb.Append(this.SEARCHENABLE);
            sb.Append(this.WORKCHECKLAB);
            sb.Append(this.WORKCHECKENABLE);
            sb.Append(this.BATCHLAB);
            sb.Append(this.BATCHENABLE);
            sb.Append(this.ASKFORLAB);
            sb.Append(this.ASKFORENABLE);
            sb.Append(this.WEBOFFICE);
            sb.Append(this.WEBOFFICEENABLE);
            sb.Append(this.WARNINGDAYS);
            sb.Append(this.DEDUCTDAYS);
            sb.Append(this.DEDUCTCENT);
            sb.Append(this.MAXDEDUCTCENT);
            sb.Append(this.SWINKCENT);
            sb.Append(this.OUTTIMEDEAL);
            sb.Append(this.DOOUTTIME);
            sb.Append(this.DOOUTTIMECOND);
            sb.Append(this.CHWAY);
            sb.Append(this.WORKLOAD);
            sb.Append(this.ISEVAL);
            sb.Append(this.FWCSTA);
            sb.Append(this.FWCSHOWMODEL);
            sb.Append(this.FWCTYPE);
            sb.Append(this.FWCTRACKENABLE);
            sb.Append(this.FWCLISTENABLE);
            sb.Append(this.FWCISSHOWALLSTEP);
            sb.Append(this.FWCOPLABEL);
            sb.Append(this.FWCDEFINFO);
            sb.Append(this.SIGANTUREENABEL);
            sb.Append(this.FWCISFULLINFO);
            sb.Append(this.FWC_H);
            sb.Append(this.FWC_W);
            sb.Append(this.ISCHECKSUBFLOWOVER);
            sb.Append(this.DOCLEFTWORD);
            sb.Append(this.DOCRIGHTWORD);
            sb.Append(this.OFFICEOPEN);
            sb.Append(this.OFFICEOPENENABLE);
            sb.Append(this.OFFICEOPENTEMPLATE);
            sb.Append(this.OFFICEOPENTEMPLATEENABLE);
            sb.Append(this.OFFICESAVE);
            sb.Append(this.OFFICESAVEENABLE);
            sb.Append(this.OFFICEACCEPT);
            sb.Append(this.OFFICEACCEPTENABLE);
            sb.Append(this.OFFICEREFUSE);
            sb.Append(this.OFFICEREFUSEENABLE);
            sb.Append(this.OFFICEOVER);
            sb.Append(this.OFFICEOVERENABLE);
            sb.Append(this.OFFICEMARKS);
            sb.Append(this.OFFICEREADONLY);
            sb.Append(this.OFFICEPRINT);
            sb.Append(this.OFFICEPRINTENABLE);
            sb.Append(this.OFFICESEAL);
            sb.Append(this.OFFICESEALENABLE);
            sb.Append(this.OFFICEINSERTFLOW);
            sb.Append(this.OFFICEINSERTFLOWENABEL);
            sb.Append(this.OFFICEINSERTFENGXIAN);
            sb.Append(this.OFFICEINSERTFENGXIANENABEL);
            sb.Append(this.OFFICENODEINFO);
            sb.Append(this.OFFICERESAVEPDF);
            sb.Append(this.OFFICEDOWNLAB);
            sb.Append(this.OFFICEISDOWN);
            sb.Append(this.OFFICEISMARKS);
            sb.Append(this.MPHONE_WORKMODEL);
            sb.Append(this.MPHONE_SRCMODEL);
            sb.Append(this.MPAD_WORKMODEL);
            sb.Append(this.MPAD_SRCMODEL);
            sb.Append(this.FWC_X);
            sb.Append(this.FWC_Y);
            sb.Append(this.SELECTORMODEL);
            sb.Append(this.SELECTORP1);
            sb.Append(this.SELECTORP2);
            sb.Append(this.SELECTORDBSHOWWAY);
            sb.Append(this.CCCTRLWAY);
            sb.Append(this.CCSQL);
            sb.Append(this.CCTITLE);
            sb.Append(this.CCDOC);
            sb.Append(this.NODEWORKTYPE);
            sb.Append(this.FLOWNAME);
            sb.Append(this.FK_FLOWSORT);
            sb.Append(this.FK_FLOWSORTT);
            sb.Append(this.FRMATTR);
            sb.Append(this.DOC);
            sb.Append(this.ISCANRPT);
            sb.Append(this.ISCANOVER);
            sb.Append(this.ISSECRET);
            sb.Append(this.ISCANDELFLOW);
            sb.Append(this.ISHANDOVER);
            sb.Append(this.NODEPOSTYPE);
            sb.Append(this.ISCCFLOW);
            sb.Append(this.HISSTAS);
            sb.Append(this.HISDEPTSTRS);
            sb.Append(this.HISTONDS);
            sb.Append(this.HISBILLIDS);
            sb.Append(this.HISSUBFLOWS);
            sb.Append(this.PTABLE);
            sb.Append(this.SHOWSHEETS);
            sb.Append(this.GROUPSTANDS);
            sb.Append(this.X);
            sb.Append(this.Y);
            sb.Append(this.ATPARA);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// NodeID,-,主键
        /// </summary>
        [DataMember]
        public virtual string NODEID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string NAME { get; set; }
        /// <summary>
        /// 流程步骤
        /// </summary>
        [DataMember]
        public virtual decimal? STEP { get; set; }
        /// <summary>
        /// FK_Flow
        /// </summary>
        [DataMember]
        public virtual string FK_FLOW { get; set; }
        /// <summary>
        /// 工作节点s
        /// </summary>
        [DataMember]
        public virtual string CHECKNODES { get; set; }
        /// <summary>
        /// 访问规则
        /// </summary>
        [DataMember]
        public virtual decimal? DELIVERYWAY { get; set; }
        /// <summary>
        /// 允许分配工作否?
        /// </summary>
        [DataMember]
        public virtual decimal ISTASK { get; set; }
        /// <summary>
        /// 是否起用投递路径自动记忆功能?
        /// </summary>
        [DataMember]
        public virtual decimal ISRM { get; set; }
        /// <summary>
        /// 是否是客户执行节点
        /// </summary>
        [DataMember]
        public virtual decimal ISGUESTNODE { get; set; }
        /// <summary>
        /// 焦点字段
        /// </summary>
        [DataMember]
        public virtual string FOCUSFIELD { get; set; }
        /// <summary>
        /// 访问规则设置
        /// </summary>
        [DataMember]
        public virtual string DELIVERYPARAS { get; set; }
        /// <summary>
        /// 谁执行它
        /// </summary>
        [DataMember]
        public virtual decimal WHOEXEIT { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        [DataMember]
        public virtual decimal FORMTYPE { get; set; }
        /// <summary>
        /// 表单URL
        /// </summary>
        [DataMember]
        public virtual string FORMURL { get; set; }
        /// <summary>
        /// 节点表单ID
        /// </summary>
        [DataMember]
        public virtual string NODEFRMID { get; set; }
        /// <summary>
        /// 转向处理
        /// </summary>
        [DataMember]
        public virtual decimal TURNTODEAL { get; set; }
        /// <summary>
        /// 发送后提示信息
        /// </summary>
        [DataMember]
        public virtual string TURNTODEALDOC { get; set; }
        /// <summary>
        /// 已读回执
        /// </summary>
        [DataMember]
        public virtual decimal READRECEIPTS { get; set; }
        /// <summary>
        /// 方向条件控制规则
        /// </summary>
        [DataMember]
        public virtual decimal CONDMODEL { get; set; }
        /// <summary>
        /// 生命周期从
        /// </summary>
        [DataMember]
        public virtual string DTFROM { get; set; }
        /// <summary>
        /// 生命周期到
        /// </summary>
        [DataMember]
        public virtual string DTTO { get; set; }
        /// <summary>
        /// 保存模式
        /// </summary>
        [DataMember]
        public virtual decimal SAVEMODEL { get; set; }
        /// <summary>
        /// 撤销规则
        /// </summary>
        [DataMember]
        public virtual decimal CANCELROLE { get; set; }
        /// <summary>
        /// 批处理
        /// </summary>
        [DataMember]
        public virtual decimal BATCHROLE { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        [DataMember]
        public virtual string BATCHPARAS { get; set; }
        /// <summary>
        /// 运行模式(对普通节点有效)
        /// </summary>
        [DataMember]
        public virtual decimal RUNMODEL { get; set; }
        /// <summary>
        /// 子线程删除方式
        /// </summary>
        [DataMember]
        public virtual decimal THREADKILLROLE { get; set; }
        /// <summary>
        /// 是否允许子线程接受人员重复(对子线程点有效)?
        /// </summary>
        [DataMember]
        public virtual decimal ISALLOWREPEATEMPS { get; set; }
        /// <summary>
        /// 子线程ID
        /// </summary>
        [DataMember]
        public virtual decimal SUBTHREADTYPE { get; set; }
        /// <summary>
        /// 通过率
        /// </summary>
        [DataMember]
        public virtual decimal? PASSRATE { get; set; }
        /// <summary>
        /// 子线程启动方式
        /// </summary>
        [DataMember]
        public virtual decimal SUBFLOWSTARTWAY { get; set; }
        /// <summary>
        /// 启动参数
        /// </summary>
        [DataMember]
        public virtual string SUBFLOWSTARTPARAS { get; set; }
        /// <summary>
        /// 是否是队列节点
        /// </summary>
        [DataMember]
        public virtual decimal TODOLISTMODEL { get; set; }
        /// <summary>
        /// 处理人就是提交人0
        /// </summary>
        [DataMember]
        public virtual decimal AUTOJUMPROLE0 { get; set; }
        /// <summary>
        /// 处理人已经出现过1
        /// </summary>
        [DataMember]
        public virtual decimal AUTOJUMPROLE1 { get; set; }
        /// <summary>
        /// 处理人与上一步相同2
        /// </summary>
        [DataMember]
        public virtual decimal AUTOJUMPROLE2 { get; set; }
        /// <summary>
        /// 未找到处理人时
        /// </summary>
        [DataMember]
        public virtual decimal WHENNOWORKER { get; set; }
        /// <summary>
        /// 发送按钮标签
        /// </summary>
        [DataMember]
        public virtual string SENDLAB { get; set; }
        /// <summary>
        /// 按钮JS函数
        /// </summary>
        [DataMember]
        public virtual string SENDJS { get; set; }
        /// <summary>
        /// 保存按钮标签
        /// </summary>
        [DataMember]
        public virtual string SAVELAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal SAVEENABLE { get; set; }
        /// <summary>
        /// 子线程按钮标签
        /// </summary>
        [DataMember]
        public virtual string THREADLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal THREADENABLE { get; set; }
        /// <summary>
        /// 子流程按钮标签
        /// </summary>
        [DataMember]
        public virtual string SUBFLOWLAB { get; set; }
        /// <summary>
        /// 控制规则,枚举类型:0,无;1,不可以删除子流程;2,可以删除子流程;
        /// </summary>
        [DataMember]
        public virtual decimal SUBFLOWCTRLROLE { get; set; }
        /// <summary>
        /// 跳转按钮标签
        /// </summary>
        [DataMember]
        public virtual string JUMPWAYLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal JUMPWAY { get; set; }
        /// <summary>
        /// 可跳转的节点
        /// </summary>
        [DataMember]
        public virtual string JUMPSQL { get; set; }
        /// <summary>
        /// 退回按钮标签
        /// </summary>
        [DataMember]
        public virtual string RETURNLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal RETURNROLE { get; set; }
        /// <summary>
        /// 是否可以在退回后原路返回(只有启用退回功能才有效)
        /// </summary>
        [DataMember]
        public virtual decimal ISBACKTRACKING { get; set; }
        /// <summary>
        /// 退回信息填写字段
        /// </summary>
        [DataMember]
        public virtual string RETURNFIELD { get; set; }
        /// <summary>
        /// 抄送按钮标签
        /// </summary>
        [DataMember]
        public virtual string CCLAB { get; set; }
        /// <summary>
        /// 抄送规则,枚举类型:0,不能抄送;1,手工抄送;2,自动抄送;3,手工与自动;4,按表单SysCCEmps字段计算;
        /// </summary>
        [DataMember]
        public virtual decimal CCROLE { get; set; }
        /// <summary>
        /// 抄送数据写入规则
        /// </summary>
        [DataMember]
        public virtual decimal CCWRITETO { get; set; }
        /// <summary>
        /// 移交按钮标签
        /// </summary>
        [DataMember]
        public virtual string SHIFTLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal SHIFTENABLE { get; set; }
        /// <summary>
        /// 删除流程按钮标签
        /// </summary>
        [DataMember]
        public virtual string DELLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal DELENABLE { get; set; }
        /// <summary>
        /// 结束流程按钮标签
        /// </summary>
        [DataMember]
        public virtual string ENDFLOWLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal ENDFLOWENABLE { get; set; }
        /// <summary>
        /// 打印单据按钮标签
        /// </summary>
        [DataMember]
        public virtual string PRINTDOCLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal PRINTDOCENABLE { get; set; }
        /// <summary>
        /// 轨迹按钮标签
        /// </summary>
        [DataMember]
        public virtual string TRACKLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal TRACKENABLE { get; set; }
        /// <summary>
        /// 挂起按钮标签
        /// </summary>
        [DataMember]
        public virtual string HUNGLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal HUNGENABLE { get; set; }
        /// <summary>
        /// 接受人按钮标签
        /// </summary>
        [DataMember]
        public virtual string SELECTACCEPTERLAB { get; set; }
        /// <summary>
        /// 方式,枚举类型:0,不启用;1,单独启用;2,在发送前打开;
        /// </summary>
        [DataMember]
        public virtual decimal SELECTACCEPTERENABLE { get; set; }
        /// <summary>
        /// 查询按钮标签
        /// </summary>
        [DataMember]
        public virtual string SEARCHLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal SEARCHENABLE { get; set; }
        /// <summary>
        /// 审核按钮标签
        /// </summary>
        [DataMember]
        public virtual string WORKCHECKLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal WORKCHECKENABLE { get; set; }
        /// <summary>
        /// 批量审核标签
        /// </summary>
        [DataMember]
        public virtual string BATCHLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal BATCHENABLE { get; set; }
        /// <summary>
        /// 加签标签
        /// </summary>
        [DataMember]
        public virtual string ASKFORLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal ASKFORENABLE { get; set; }
        /// <summary>
        /// 公文标签
        /// </summary>
        [DataMember]
        public virtual string WEBOFFICE { get; set; }
        /// <summary>
        /// 文档启用方式,枚举类型:0,不启用;1,按钮方式;2,标签页方式;
        /// </summary>
        [DataMember]
        public virtual decimal WEBOFFICEENABLE { get; set; }
        /// <summary>
        /// 警告期限(0不警告)
        /// </summary>
        [DataMember]
        public virtual decimal? WARNINGDAYS { get; set; }
        /// <summary>
        /// 限期(天)
        /// </summary>
        [DataMember]
        public virtual decimal? DEDUCTDAYS { get; set; }
        /// <summary>
        /// 扣分(每延期1天扣)
        /// </summary>
        [DataMember]
        public virtual decimal? DEDUCTCENT { get; set; }
        /// <summary>
        /// 最高扣分
        /// </summary>
        [DataMember]
        public virtual decimal? MAXDEDUCTCENT { get; set; }
        /// <summary>
        /// 工作得分
        /// </summary>
        [DataMember]
        public virtual decimal? SWINKCENT { get; set; }
        /// <summary>
        /// 超时处理方式
        /// </summary>
        [DataMember]
        public virtual decimal OUTTIMEDEAL { get; set; }
        /// <summary>
        /// 超时处理内容
        /// </summary>
        [DataMember]
        public virtual string DOOUTTIME { get; set; }
        /// <summary>
        /// 执行超时条件
        /// </summary>
        [DataMember]
        public virtual string DOOUTTIMECOND { get; set; }
        /// <summary>
        /// 考核方式,枚举类型:0,不考核;1,按时效;2,按工作量;
        /// </summary>
        [DataMember]
        public virtual decimal CHWAY { get; set; }
        /// <summary>
        /// 工作量(单位:分钟)
        /// </summary>
        [DataMember]
        public virtual decimal? WORKLOAD { get; set; }
        /// <summary>
        /// 是否工作质量考核
        /// </summary>
        [DataMember]
        public virtual decimal ISEVAL { get; set; }
        /// <summary>
        /// 审核组件状态,枚举类型:0,禁用;1,启用;2,只读;
        /// </summary>
        [DataMember]
        public virtual decimal FWCSTA { get; set; }
        /// <summary>
        /// 显示方式,枚举类型:0,表格方式;1,自由模式;
        /// </summary>
        [DataMember]
        public virtual decimal FWCSHOWMODEL { get; set; }
        /// <summary>
        /// 审核组件,枚举类型:0,审核组件;1,日志组件;
        /// </summary>
        [DataMember]
        public virtual decimal FWCTYPE { get; set; }
        /// <summary>
        /// 轨迹图是否显示？
        /// </summary>
        [DataMember]
        public virtual decimal FWCTRACKENABLE { get; set; }
        /// <summary>
        /// 是否显示历史审核信息？(否,历史信息仅出现意见框)
        /// </summary>
        [DataMember]
        public virtual decimal FWCLISTENABLE { get; set; }
        /// <summary>
        /// 在轨迹表里是否显示未发生的步骤？
        /// </summary>
        [DataMember]
        public virtual decimal FWCISSHOWALLSTEP { get; set; }
        /// <summary>
        /// 操作名词(审核/审阅/批示)
        /// </summary>
        [DataMember]
        public virtual string FWCOPLABEL { get; set; }
        /// <summary>
        /// 默认审核信息
        /// </summary>
        [DataMember]
        public virtual string FWCDEFINFO { get; set; }
        /// <summary>
        /// 是否显示数字签名？
        /// </summary>
        [DataMember]
        public virtual decimal SIGANTUREENABEL { get; set; }
        /// <summary>
        /// 如果用户未审核是否按照默认意见填充？
        /// </summary>
        [DataMember]
        public virtual decimal FWCISFULLINFO { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [DataMember]
        public virtual decimal? FWC_H { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DataMember]
        public virtual decimal? FWC_W { get; set; }
        /// <summary>
        /// (当前节点为父流程时)是否检查子流程完成后父流程才能执行
        /// </summary>
        [DataMember]
        public virtual decimal ISCHECKSUBFLOWOVER { get; set; }
        /// <summary>
        /// 公文左边词语(多个用@符合隔开)
        /// </summary>
        [DataMember]
        public virtual string DOCLEFTWORD { get; set; }
        /// <summary>
        /// 公文右边词语(多个用@符合隔开)
        /// </summary>
        [DataMember]
        public virtual string DOCRIGHTWORD { get; set; }
        /// <summary>
        /// 打开本地标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEOPEN { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEOPENENABLE { get; set; }
        /// <summary>
        /// 打开模板标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEOPENTEMPLATE { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEOPENTEMPLATEENABLE { get; set; }
        /// <summary>
        /// 保存标签
        /// </summary>
        [DataMember]
        public virtual string OFFICESAVE { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICESAVEENABLE { get; set; }
        /// <summary>
        /// 接受修订标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEACCEPT { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEACCEPTENABLE { get; set; }
        /// <summary>
        /// 拒绝修订标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEREFUSE { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEREFUSEENABLE { get; set; }
        /// <summary>
        /// 套红标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEOVER { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEOVERENABLE { get; set; }
        /// <summary>
        /// 是否查看用户留痕
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEMARKS { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEREADONLY { get; set; }
        /// <summary>
        /// 打印标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEPRINT { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEPRINTENABLE { get; set; }
        /// <summary>
        /// 签章标签
        /// </summary>
        [DataMember]
        public virtual string OFFICESEAL { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICESEALENABLE { get; set; }
        /// <summary>
        /// 插入流程标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEINSERTFLOW { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEINSERTFLOWENABEL { get; set; }
        /// <summary>
        /// 插入风险点标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEINSERTFENGXIAN { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEINSERTFENGXIANENABEL { get; set; }
        /// <summary>
        /// 是否记录节点信息
        /// </summary>
        [DataMember]
        public virtual decimal OFFICENODEINFO { get; set; }
        /// <summary>
        /// 是否该自动保存为PDF
        /// </summary>
        [DataMember]
        public virtual decimal OFFICERESAVEPDF { get; set; }
        /// <summary>
        /// 下载按钮标签
        /// </summary>
        [DataMember]
        public virtual string OFFICEDOWNLAB { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEISDOWN { get; set; }
        /// <summary>
        /// 是否进入留痕模式
        /// </summary>
        [DataMember]
        public virtual decimal OFFICEISMARKS { get; set; }
        /// <summary>
        /// 手机工作模式,枚举类型:0,原生态;1,浏览器;2,禁用;
        /// </summary>
        [DataMember]
        public virtual decimal MPHONE_WORKMODEL { get; set; }
        /// <summary>
        /// 手机屏幕模式,枚举类型:0,强制横屏;1,强制竖屏;2,由重力感应决定;
        /// </summary>
        [DataMember]
        public virtual decimal MPHONE_SRCMODEL { get; set; }
        /// <summary>
        /// 平板工作模式,枚举类型:0,原生态;1,浏览器;2,禁用;
        /// </summary>
        [DataMember]
        public virtual decimal MPAD_WORKMODEL { get; set; }
        /// <summary>
        /// 平板屏幕模式,枚举类型:0,强制横屏;1,强制竖屏;2,由重力感应决定;
        /// </summary>
        [DataMember]
        public virtual decimal MPAD_SRCMODEL { get; set; }
        /// <summary>
        /// 位置X
        /// </summary>
        [DataMember]
        public virtual decimal? FWC_X { get; set; }
        /// <summary>
        /// 位置Y
        /// </summary>
        [DataMember]
        public virtual decimal? FWC_Y { get; set; }
        /// <summary>
        /// 窗口模式,枚举类型:0,按岗位;1,按部门;2,按人员;3,按SQL;4,自定义Url;
        /// </summary>
        [DataMember]
        public virtual decimal SELECTORMODEL { get; set; }
        /// <summary>
        /// 参数1
        /// </summary>
        [DataMember]
        public virtual string SELECTORP1 { get; set; }
        /// <summary>
        /// 参数2
        /// </summary>
        [DataMember]
        public virtual string SELECTORP2 { get; set; }
        /// <summary>
        /// 数据显示方式,枚举类型:0,表格显示;1,树形显示;
        /// </summary>
        [DataMember]
        public virtual decimal SELECTORDBSHOWWAY { get; set; }
        /// <summary>
        /// 控制方式,枚举类型:
        /// </summary>
        [DataMember]
        public virtual decimal CCCTRLWAY { get; set; }
        /// <summary>
        /// SQL表达式
        /// </summary>
        [DataMember]
        public virtual string CCSQL { get; set; }
        /// <summary>
        /// 抄送标题
        /// </summary>
        [DataMember]
        public virtual string CCTITLE { get; set; }
        /// <summary>
        /// 抄送内容(标题与内容支持变量)
        /// </summary>
        [DataMember]
        public virtual string CCDOC { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        [DataMember]
        public virtual decimal NODEWORKTYPE { get; set; }
        /// <summary>
        /// 流程名
        /// </summary>
        [DataMember]
        public virtual string FLOWNAME { get; set; }
        /// <summary>
        /// FK_FlowSort
        /// </summary>
        [DataMember]
        public virtual string FK_FLOWSORT { get; set; }
        /// <summary>
        /// FK_FlowSortT
        /// </summary>
        [DataMember]
        public virtual string FK_FLOWSORTT { get; set; }
        /// <summary>
        /// FrmAttr
        /// </summary>
        [DataMember]
        public virtual string FRMATTR { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string DOC { get; set; }
        /// <summary>
        /// 是否可以查看工作报告?
        /// </summary>
        [DataMember]
        public virtual decimal ISCANRPT { get; set; }
        /// <summary>
        /// 是否可以终止流程
        /// </summary>
        [DataMember]
        public virtual decimal ISCANOVER { get; set; }
        /// <summary>
        /// 是否是保密步骤
        /// </summary>
        [DataMember]
        public virtual decimal ISSECRET { get; set; }
        /// <summary>
        /// 是否可以删除流程
        /// </summary>
        [DataMember]
        public virtual decimal ISCANDELFLOW { get; set; }
        /// <summary>
        /// 是否可以移交
        /// </summary>
        [DataMember]
        public virtual decimal ISHANDOVER { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        [DataMember]
        public virtual decimal NODEPOSTYPE { get; set; }
        /// <summary>
        /// 是否有流程完成条件
        /// </summary>
        [DataMember]
        public virtual decimal ISCCFLOW { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        [DataMember]
        public virtual string HISSTAS { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [DataMember]
        public virtual string HISDEPTSTRS { get; set; }
        /// <summary>
        /// 转到的节点
        /// </summary>
        [DataMember]
        public virtual string HISTONDS { get; set; }
        /// <summary>
        /// 单据IDs
        /// </summary>
        [DataMember]
        public virtual string HISBILLIDS { get; set; }
        /// <summary>
        /// HisSubFlows
        /// </summary>
        [DataMember]
        public virtual string HISSUBFLOWS { get; set; }
        /// <summary>
        /// 物理表
        /// </summary>
        [DataMember]
        public virtual string PTABLE { get; set; }
        /// <summary>
        /// 显示的表单
        /// </summary>
        [DataMember]
        public virtual string SHOWSHEETS { get; set; }
        /// <summary>
        /// 岗位分组节点
        /// </summary>
        [DataMember]
        public virtual string GROUPSTANDS { get; set; }
        /// <summary>
        /// X坐标
        /// </summary>
        [DataMember]
        public virtual decimal X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        [DataMember]
        public virtual decimal Y { get; set; }
        /// <summary>
        /// AtPara
        /// </summary>
        [DataMember]
        public virtual string ATPARA { get; set; }
        #endregion

        #region 手动追加属性
        /// <summary>
        /// 节点岗位名称
        /// </summary>
        [DataMember]
        public virtual string STATION
        {
            get
            {
                var nodeStationList = DataContextNH.GetByLINQ<NODESTATION>(x => x.FK_NODE.ToString() == NODEID, null, null, null, null).Where(x => x != null);
                //var dao = new NODESTATIONDAO();
                //var nodeStationList = dao.FindByLinq(x => x.FK_NODE.ToString() == NODEID).Where(x => x != null);
                return string.Join(",", nodeStationList.Select(x => x.FK_STATION));
            }
        }

        #endregion
    }
}

