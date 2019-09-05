using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FluentNHibernate.Mapping;
using Lab.Framework;

namespace WebApplication5.Areas.Business.Models
{
    /// <summary>
    /// 请假管理
    /// </summary>
    public partial class Bus_Leave : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _UserID=null;
		private DateTime? _StartTime=null;
		private DateTime? _EndTime=null;
		private int? _WfState=null;
		private string _Reason=null;
		private int? _WorkID=null;
		private string _DepartmentID=null;
		private string _LeaveType=null;
		private int? _TotalHours=null;
	
	
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
      /// 用户标识
      /// </summary>
	  [DataMember]
	  public virtual string UserID 
	  { 
	     get{return _UserID;}
	     set{_UserID=value;}
	  }
	
      /// <summary>
      /// 开始时间
      /// </summary>
	  [DataMember]
	  public virtual DateTime? StartTime 
	  { 
	     get{return _StartTime;}
	     set{_StartTime=value;}
	  }
	
      /// <summary>
      /// 结束时间
      /// </summary>
	  [DataMember]
	  public virtual DateTime? EndTime 
	  { 
	     get{return _EndTime;}
	     set{_EndTime=value;}
	  }
	
      /// <summary>
      /// 流程状态
      /// </summary>
	  [DataMember]
	  public virtual int? WfState 
	  { 
	     get{return _WfState;}
	     set{_WfState=value;}
	  }
	
      /// <summary>
      /// 请假原因
      /// </summary>
	  [DataMember]
	  public virtual string Reason 
	  { 
	     get{return _Reason;}
	     set{_Reason=value;}
	  }
	
      /// <summary>
      /// 流程工作标识
      /// </summary>
	  [DataMember]
	  public virtual int? WorkID 
	  { 
	     get{return _WorkID;}
	     set{_WorkID=value;}
	  }
	
      /// <summary>
      /// 部门标识
      /// </summary>
	  [DataMember]
	  public virtual string DepartmentID 
	  { 
	     get{return _DepartmentID;}
	     set{_DepartmentID=value;}
	  }
	
      /// <summary>
      /// 请假类型
      /// </summary>
	  [DataMember]
	  public virtual string LeaveType 
	  { 
	     get{return _LeaveType;}
	     set{_LeaveType=value;}
	  }
	
      /// <summary>
      /// 请假总时长
      /// </summary>
	  [DataMember]
	  public virtual int? TotalHours 
	  { 
	     get{return _TotalHours;}
	     set{_TotalHours=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Bus_LeaveMap : ClassMap<Bus_Leave>
    {
        public Bus_LeaveMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.UserID);
	        	 Map(m => m.StartTime);
	        	 Map(m => m.EndTime);
	        	 Map(m => m.WfState);
	        	 Map(m => m.Reason);
	        	 Map(m => m.WorkID);
	        	 Map(m => m.DepartmentID);
	        	 Map(m => m.LeaveType);
	        	 Map(m => m.TotalHours);
	        		
						     }
    }
}

