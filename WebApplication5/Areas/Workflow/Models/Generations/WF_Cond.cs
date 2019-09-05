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
    /// 流程条件
    /// </summary>
    public partial class WF_Cond : BaseEntity,ICloneable
    {
		private string _MyPK=null;
		private decimal _CondType=0;
		private decimal _DataFrom=0;
		private string _FK_Flow=null;
		private decimal _NodeID=0;
		private decimal _FK_Node=0;
		private string _FK_Attr=null;
		private string _AttrKey=null;
		private string _AttrName=null;
		private string _FK_Operator=null;
		private string _OperatorValue=null;
		private string _OperatorValueT=null;
		private decimal _ToNodeID=0;
		private decimal _ConnJudgeWay=0;
		private decimal _MyPOID=0;
		private decimal _PRI=0;
		private decimal _CondOrAnd=0;
		private string _Note=null;
		private string _AtPara=null;
	
	
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
      /// 条件类型
      /// </summary>
	  [DataMember]
	  public virtual decimal CondType 
	  { 
	     get{return _CondType;}
	     set{_CondType=value;}
	  }
	
      /// <summary>
      /// 条件数据来源0表单,1岗位(对方向条件有效)
      /// </summary>
	  [DataMember]
	  public virtual decimal DataFrom 
	  { 
	     get{return _DataFrom;}
	     set{_DataFrom=value;}
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
      /// 发生的事件MainNode
      /// </summary>
	  [DataMember]
	  public virtual decimal NodeID 
	  { 
	     get{return _NodeID;}
	     set{_NodeID=value;}
	  }
	
      /// <summary>
      /// 节点ID
      /// </summary>
	  [DataMember]
	  public virtual decimal FK_Node 
	  { 
	     get{return _FK_Node;}
	     set{_FK_Node=value;}
	  }
	
      /// <summary>
      /// 属性
      /// </summary>
	  [DataMember]
	  public virtual string FK_Attr 
	  { 
	     get{return _FK_Attr;}
	     set{_FK_Attr=value;}
	  }
	
      /// <summary>
      /// 属性键
      /// </summary>
	  [DataMember]
	  public virtual string AttrKey 
	  { 
	     get{return _AttrKey;}
	     set{_AttrKey=value;}
	  }
	
      /// <summary>
      /// 中文名称
      /// </summary>
	  [DataMember]
	  public virtual string AttrName 
	  { 
	     get{return _AttrName;}
	     set{_AttrName=value;}
	  }
	
      /// <summary>
      /// 运算符号
      /// </summary>
	  [DataMember]
	  public virtual string FK_Operator 
	  { 
	     get{return _FK_Operator;}
	     set{_FK_Operator=value;}
	  }
	
      /// <summary>
      /// 要运算的值
      /// </summary>
	  [DataMember]
	  public virtual string OperatorValue 
	  { 
	     get{return _OperatorValue;}
	     set{_OperatorValue=value;}
	  }
	
      /// <summary>
      /// 要运算的值T
      /// </summary>
	  [DataMember]
	  public virtual string OperatorValueT 
	  { 
	     get{return _OperatorValueT;}
	     set{_OperatorValueT=value;}
	  }
	
      /// <summary>
      /// ToNodeID（对方向条件有效）
      /// </summary>
	  [DataMember]
	  public virtual decimal ToNodeID 
	  { 
	     get{return _ToNodeID;}
	     set{_ToNodeID=value;}
	  }
	
      /// <summary>
      /// 条件关系,枚举类型:0
      /// </summary>
	  [DataMember]
	  public virtual decimal ConnJudgeWay 
	  { 
	     get{return _ConnJudgeWay;}
	     set{_ConnJudgeWay=value;}
	  }
	
      /// <summary>
      /// MyPOID
      /// </summary>
	  [DataMember]
	  public virtual decimal MyPOID 
	  { 
	     get{return _MyPOID;}
	     set{_MyPOID=value;}
	  }
	
      /// <summary>
      /// 计算优先级
      /// </summary>
	  [DataMember]
	  public virtual decimal PRI 
	  { 
	     get{return _PRI;}
	     set{_PRI=value;}
	  }
	
      /// <summary>
      /// 方向条件类型
      /// </summary>
	  [DataMember]
	  public virtual decimal CondOrAnd 
	  { 
	     get{return _CondOrAnd;}
	     set{_CondOrAnd=value;}
	  }
	
      /// <summary>
      /// 备注
      /// </summary>
	  [DataMember]
	  public virtual string Note 
	  { 
	     get{return _Note;}
	     set{_Note=value;}
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
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class WF_CondMap : ClassMap<WF_Cond>
    {
        public WF_CondMap()
        {
		Id(m => m.MyPK).GeneratedBy.UuidHex("D");
				 Map(m => m.CondType);
	        	 Map(m => m.DataFrom);
	        	 Map(m => m.FK_Flow);
	        	 Map(m => m.NodeID);
	        	 Map(m => m.FK_Node);
	        	 Map(m => m.FK_Attr);
	        	 Map(m => m.AttrKey);
	        	 Map(m => m.AttrName);
	        	 Map(m => m.FK_Operator);
	        	 Map(m => m.OperatorValue);
	        	 Map(m => m.OperatorValueT);
	        	 Map(m => m.ToNodeID);
	        	 Map(m => m.ConnJudgeWay);
	        	 Map(m => m.MyPOID);
	        	 Map(m => m.PRI);
	        	 Map(m => m.CondOrAnd);
	        	 Map(m => m.Note);
	        	 Map(m => m.AtPara);
	        		
						     }
    }
}

