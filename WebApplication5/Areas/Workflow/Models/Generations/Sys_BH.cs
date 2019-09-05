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
    /// 编号规则
    /// </summary>
    public partial class Sys_BH : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private int? _SeriesNumber=null;
		private int? _RestType=null;
		private DateTime _LastDate=DateTime.MinValue;
		private string _Template=null;
		private int? _NumberLength=null;
	
	
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
      /// 编号名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 当前序列号
      /// </summary>
	  [DataMember]
	  public virtual int? SeriesNumber 
	  { 
	     get{return _SeriesNumber;}
	     set{_SeriesNumber=value;}
	  }
	
      /// <summary>
      /// 重置方式
      /// </summary>
	  [DataMember]
	  public virtual int? RestType 
	  { 
	     get{return _RestType;}
	     set{_RestType=value;}
	  }
	
      /// <summary>
      /// 最后生成日期
      /// </summary>
	  [DataMember]
	  public virtual DateTime LastDate 
	  { 
	     get{return _LastDate;}
	     set{_LastDate=value;}
	  }
	
      /// <summary>
      /// 模板
      /// </summary>
	  [DataMember]
	  public virtual string Template 
	  { 
	     get{return _Template;}
	     set{_Template=value;}
	  }
	
      /// <summary>
      /// 编号长度
      /// </summary>
	  [DataMember]
	  public virtual int? NumberLength 
	  { 
	     get{return _NumberLength;}
	     set{_NumberLength=value;}
	  }
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Sys_BHMap : ClassMap<Sys_BH>
    {
        public Sys_BHMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.SeriesNumber);
	        	 Map(m => m.RestType);
	        	 Map(m => m.LastDate);
	        	 Map(m => m.Template);
	        	 Map(m => m.NumberLength);
	        		
						     }
    }
}

