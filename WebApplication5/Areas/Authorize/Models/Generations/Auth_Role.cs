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
    /// 角色
    /// </summary>
    public partial class Auth_Role : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private int? _SortNumber=null;
		private int? _IsValid=null;
		private DateTime? _CreateTime=null;
		private string _Creator=null;
		private int? _IsDeleted=null;
		private string _Desscription=null;
	
	
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
      /// 角色名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
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
      /// 是否有效
      /// </summary>
	  [DataMember]
	  public virtual int? IsValid 
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
	  public virtual int? IsDeleted 
	  { 
	     get{return _IsDeleted;}
	     set{_IsDeleted=value;}
	  }
	
      /// <summary>
      /// Desscription
      /// </summary>
	  [DataMember]
	  public virtual string Desscription 
	  { 
	     get{return _Desscription;}
	     set{_Desscription=value;}
	  }
	
	
	  /// <summary>
      /// Auth_Rlt_RoleAuthorization列表
      /// </summary>
	  public virtual ISet<Auth_Rlt_RoleAuthorization> Auth_Rlt_RoleAuthorization_LIST
      {
         set;
         get;
      }
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Auth_RoleMap : ClassMap<Auth_Role>
    {
        public Auth_RoleMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.SortNumber);
	        	 Map(m => m.IsValid);
	        	 Map(m => m.CreateTime);
	        	 Map(m => m.Creator);
	        	 Map(m => m.IsDeleted);
	        	 Map(m => m.Desscription);
	        		
			     HasMany<Auth_Rlt_RoleAuthorization>(h => h.Auth_Rlt_RoleAuthorization_LIST).LazyLoad().AsSet().KeyColumn("RoleID").Cascade.All().Inverse();
	        			     }
    }
}

