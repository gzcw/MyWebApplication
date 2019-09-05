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
    /// 岗位
    /// </summary>
    public partial class Auth_Station : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
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
      /// 岗位名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 岗位职责
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

    public partial class Auth_StationMap : ClassMap<Auth_Station>
    {
        public Auth_StationMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.Responsibility);
	        	 Map(m => m.SortNumber);
	        		
			     HasMany<Auth_User>(h => h.Auth_User_LIST).LazyLoad().AsSet().KeyColumn("StationID").Cascade.All().Inverse();
	        			     }
    }
}

