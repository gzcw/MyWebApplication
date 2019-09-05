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
    /// 部门
    /// </summary>
    public partial class Auth_Department : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private string _ParentID=null;
		private string _Responsibility=null;
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
      /// 部门名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 上级标识
      /// </summary>
	  [DataMember]
	  public virtual string ParentID 
	  { 
	     get{return _ParentID;}
	     set{_ParentID=value;}
	  }
	
      /// <summary>
      /// 部门职责
      /// </summary>
	  [DataMember]
	  public virtual string Responsibility 
	  { 
	     get{return _Responsibility;}
	     set{_Responsibility=value;}
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
      /// Auth_User列表
      /// </summary>
	  public virtual ISet<Auth_User> Auth_User_LIST
      {
         set;
         get;
      }
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Auth_DepartmentMap : ClassMap<Auth_Department>
    {
        public Auth_DepartmentMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.ParentID);
	        	 Map(m => m.Responsibility);
	        	 Map(m => m.SortNumber);
	        		
			     HasMany<Auth_User>(h => h.Auth_User_LIST).LazyLoad().AsSet().KeyColumn("DepartmentID").Cascade.All().Inverse();
	        			     }
    }
}

