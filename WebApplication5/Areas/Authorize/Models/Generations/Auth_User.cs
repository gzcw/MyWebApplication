using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FluentNHibernate.Mapping;
using Lab.Framework;

namespace WebApplication5.Areas.Authorize.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class Auth_User : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private string _Password=null;
		private string _RealName=null;
		private int? _Sex=null;
		private string _DepartmentID=null;
		private string _OfficePhone=null;
		private string _Email=null;
		private int? _ErrorTime=null;
		private bool _Locked=false;
		private bool? _IsValid=null;
		private DateTime? _CreateTime=null;
		private string _Creator=null;
		private bool? _IsDeleted=null;
		private int? _SortNumber=null;
		private string _StationID=null;
	
	
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
      /// 用户名
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 密码
      /// </summary>
	  [DataMember]
	  public virtual string Password 
	  { 
	     get{return _Password;}
	     set{_Password=value;}
	  }
	
      /// <summary>
      /// 真实姓名
      /// </summary>
	  [DataMember]
	  public virtual string RealName 
	  { 
	     get{return _RealName;}
	     set{_RealName=value;}
	  }
	
      /// <summary>
      /// 性别
      /// </summary>
	  [DataMember]
	  public virtual int? Sex 
	  { 
	     get{return _Sex;}
	     set{_Sex=value;}
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
      /// 办公电话
      /// </summary>
	  [DataMember]
	  public virtual string OfficePhone 
	  { 
	     get{return _OfficePhone;}
	     set{_OfficePhone=value;}
	  }
	
      /// <summary>
      /// 电子邮件
      /// </summary>
	  [DataMember]
	  public virtual string Email 
	  { 
	     get{return _Email;}
	     set{_Email=value;}
	  }
	
      /// <summary>
      /// 登陆错误次数
      /// </summary>
	  [DataMember]
	  public virtual int? ErrorTime 
	  { 
	     get{return _ErrorTime;}
	     set{_ErrorTime=value;}
	  }
	
      /// <summary>
      /// 是否锁定
      /// </summary>
	  [DataMember]
	  public virtual bool Locked 
	  { 
	     get{return _Locked;}
	     set{_Locked=value;}
	  }
	
      /// <summary>
      /// 是否有效
      /// </summary>
	  [DataMember]
	  public virtual bool? IsValid 
	  { 
	     get{return _IsValid;}
	     set{_IsValid=value;}
	  }
	
      /// <summary>
      /// 创建时间
      /// </summary>
	  [DataMember]
	  public virtual DateTime? CreateTime 
	  { 
	     get{return _CreateTime;}
	     set{_CreateTime=value;}
	  }
	
      /// <summary>
      /// 创建人
      /// </summary>
	  [DataMember]
	  public virtual string Creator 
	  { 
	     get{return _Creator;}
	     set{_Creator=value;}
	  }
	
      /// <summary>
      /// 是否删除
      /// </summary>
	  [DataMember]
	  public virtual bool? IsDeleted 
	  { 
	     get{return _IsDeleted;}
	     set{_IsDeleted=value;}
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
	
      /// <summary>
      /// 岗位标识
      /// </summary>
	  [DataMember]
	  public virtual string StationID 
	  { 
	     get{return _StationID;}
	     set{_StationID=value;}
	  }
	
	
	
	
	  /// <summary>
      /// Auth_User实体
      /// </summary>
	  public virtual Auth_Department Auth_Department
      {
         set;
         get;
      }
	  /// <summary>
      /// Auth_User实体
      /// </summary>
	  public virtual Auth_Station Auth_Station
      {
         set;
         get;
      }
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Auth_UserMap : ClassMap<Auth_User>
    {
        public Auth_UserMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.Password);
	        	 Map(m => m.RealName);
	        	 Map(m => m.Sex);
	        	 Map(m => m.DepartmentID);
	        	 Map(m => m.OfficePhone);
	        	 Map(m => m.Email);
	        	 Map(m => m.ErrorTime);
	        	 Map(m => m.Locked);
	        	 Map(m => m.IsValid);
	        	 Map(m => m.CreateTime);
	        	 Map(m => m.Creator);
	        	 Map(m => m.IsDeleted);
	        	 Map(m => m.SortNumber);
	        	 Map(m => m.StationID);
	        		
						References<Auth_Department>(r => r.Auth_Department).Column("DepartmentID").Not.Update().Not.Insert().LazyLoad();
	        References<Auth_Station>(r => r.Auth_Station).Column("StationID").Not.Update().Not.Insert().LazyLoad();
	             }
    }
}

