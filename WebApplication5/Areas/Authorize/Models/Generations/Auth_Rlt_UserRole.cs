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
    /// 用户角色
    /// </summary>
    public partial class Auth_Rlt_UserRole : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _UserID=null;
		private string _RoleID=null;
	
	
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
      /// 角色标识
      /// </summary>
	  [DataMember]
	  public virtual string RoleID 
	  { 
	     get{return _RoleID;}
	     set{_RoleID=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Auth_Rlt_UserRoleMap : ClassMap<Auth_Rlt_UserRole>
    {
        public Auth_Rlt_UserRoleMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.UserID);
	        	 Map(m => m.RoleID);
	        		
						     }
    }
}

