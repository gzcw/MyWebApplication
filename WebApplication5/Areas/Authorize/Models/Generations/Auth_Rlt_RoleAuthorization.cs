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
    /// 角色权限
    /// </summary>
    public partial class Auth_Rlt_RoleAuthorization : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _RoleID=null;
		private string _AuthorizationID=null;
	
	
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
      /// 角色标识
      /// </summary>
	  [DataMember]
	  public virtual string RoleID 
	  { 
	     get{return _RoleID;}
	     set{_RoleID=value;}
	  }
	
      /// <summary>
      /// 操作权限标识
      /// </summary>
	  [DataMember]
	  public virtual string AuthorizationID 
	  { 
	     get{return _AuthorizationID;}
	     set{_AuthorizationID=value;}
	  }
	
	
	
	
	  /// <summary>
      /// Auth_Rlt_RoleAuthorization实体
      /// </summary>
	  public virtual Auth_Authorization Auth_Authorization
      {
         set;
         get;
      }
	  /// <summary>
      /// Auth_Rlt_RoleAuthorization实体
      /// </summary>
	  public virtual Auth_Role Auth_Role
      {
         set;
         get;
      }
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Auth_Rlt_RoleAuthorizationMap : ClassMap<Auth_Rlt_RoleAuthorization>
    {
        public Auth_Rlt_RoleAuthorizationMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.RoleID);
	        	 Map(m => m.AuthorizationID);
	        		
						References<Auth_Authorization>(r => r.Auth_Authorization).Column("AuthorizationID").Not.Update().Not.Insert().LazyLoad();
	        References<Auth_Role>(r => r.Auth_Role).Column("RoleID").Not.Update().Not.Insert().LazyLoad();
	             }
    }
}

