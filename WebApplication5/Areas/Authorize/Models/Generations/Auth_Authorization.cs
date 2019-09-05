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
    /// 操作权限
    /// </summary>
    public partial class Auth_Authorization : BaseEntity,ICloneable
    {
		private string _ID=null;
		private int? _RType=null;
		private string _Name=null;
		private string _Url=null;
		private string _UrlSign=null;
		private string _Method=null;
		private string _Icon=null;
		private string _ParentID=null;
		private int? _SortNumber=null;
		private int? _IsValid=null;
		private DateTime? _CreateTime=null;
		private string _Creator=null;
		private int? _IsDeleted=null;
	
	
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
      /// 资源类型
      /// </summary>
	  [DataMember]
	  public virtual int? RType 
	  { 
	     get{return _RType;}
	     set{_RType=value;}
	  }
	
      /// <summary>
      /// 资源名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 路径
      /// </summary>
	  [DataMember]
	  public virtual string Url 
	  { 
	     get{return _Url;}
	     set{_Url=value;}
	  }
	
      /// <summary>
      /// 路径参数
      /// </summary>
	  [DataMember]
	  public virtual string UrlSign 
	  { 
	     get{return _UrlSign;}
	     set{_UrlSign=value;}
	  }
	
      /// <summary>
      /// 方法
      /// </summary>
	  [DataMember]
	  public virtual string Method 
	  { 
	     get{return _Method;}
	     set{_Method=value;}
	  }
	
      /// <summary>
      /// 图标
      /// </summary>
	  [DataMember]
	  public virtual string Icon 
	  { 
	     get{return _Icon;}
	     set{_Icon=value;}
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
      /// 创建人
      /// </summary>
	  [DataMember]
	  public virtual DateTime? CreateTime 
	  { 
	     get{return _CreateTime;}
	     set{_CreateTime=value;}
	  }
	
      /// <summary>
      /// 创建时间
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

    public partial class Auth_AuthorizationMap : ClassMap<Auth_Authorization>
    {
        public Auth_AuthorizationMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.RType);
	        	 Map(m => m.Name);
	        	 Map(m => m.Url);
	        	 Map(m => m.UrlSign);
	        	 Map(m => m.Method);
	        	 Map(m => m.Icon);
	        	 Map(m => m.ParentID);
	        	 Map(m => m.SortNumber);
	        	 Map(m => m.IsValid);
	        	 Map(m => m.CreateTime);
	        	 Map(m => m.Creator);
	        	 Map(m => m.IsDeleted);
	        		
			     HasMany<Auth_Rlt_RoleAuthorization>(h => h.Auth_Rlt_RoleAuthorization_LIST).LazyLoad().AsSet().KeyColumn("AuthorizationID").Cascade.All().Inverse();
	        			     }
    }
}

