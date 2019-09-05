using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FluentNHibernate.Mapping;
using Lab.Framework;

namespace WebApplication5.Models
{
    /// <summary>
    /// 附件名称
    /// </summary>
    public partial class Sys_Attachment : BaseEntity,ICloneable
    {
		private string _ID=null;
		private string _Name=null;
		private string _FileType=null;
		private int? _FileSize=null;
		private bool _IsDirectory=false;
		private string _RecordID=null;
		private string _ParentID=null;
		private string _Category=null;
		private string _Path=null;
        private string _Creator = ApplicationUser.Current.RealName;
        private DateTime _CreateTime = DateTime.Now;
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
      /// 名称
      /// </summary>
	  [DataMember]
	  public virtual string Name 
	  { 
	     get{return _Name;}
	     set{_Name=value;}
	  }
	
      /// <summary>
      /// 文件类型
      /// </summary>
	  [DataMember]
	  public virtual string FileType 
	  { 
	     get{return _FileType;}
	     set{_FileType=value;}
	  }
	
      /// <summary>
      /// 文件大小
      /// </summary>
	  [DataMember]
	  public virtual int? FileSize 
	  { 
	     get{return _FileSize;}
	     set{_FileSize=value;}
	  }
	
      /// <summary>
      /// 是否目录
      /// </summary>
	  [DataMember]
	  public virtual bool IsDirectory 
	  { 
	     get{return _IsDirectory;}
	     set{_IsDirectory=value;}
	  }
	
      /// <summary>
      /// 引用记录标识
      /// </summary>
	  [DataMember]
	  public virtual string RecordID 
	  { 
	     get{return _RecordID;}
	     set{_RecordID=value;}
	  }
	
      /// <summary>
      /// 父记录标识
      /// </summary>
	  [DataMember]
	  public virtual string ParentID 
	  { 
	     get{return _ParentID;}
	     set{_ParentID=value;}
	  }
	
      /// <summary>
      /// 附件类别
      /// </summary>
	  [DataMember]
	  public virtual string Category 
	  { 
	     get{return _Category;}
	     set{_Category=value;}
	  }
	
      /// <summary>
      /// 附件路径
      /// </summary>
	  [DataMember]
	  public virtual string Path 
	  { 
	     get{return _Path;}
	     set{_Path=value;}
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
      /// 创建时间
      /// </summary>
	  [DataMember]
	  public virtual DateTime CreateTime 
	  { 
	     get{return _CreateTime;}
	     set{_CreateTime=value;}
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
	
	
	
	
	
      public virtual object Clone()
      {
          return this.MemberwiseClone();
      }
    }

    public partial class Sys_AttachmentMap : ClassMap<Sys_Attachment>
    {
        public Sys_AttachmentMap()
        {
		Id(m => m.ID).GeneratedBy.UuidHex("D");
				 Map(m => m.Name);
	        	 Map(m => m.FileType);
	        	 Map(m => m.FileSize);
	        	 Map(m => m.IsDirectory);
	        	 Map(m => m.RecordID);
	        	 Map(m => m.ParentID);
	        	 Map(m => m.Category);
	        	 Map(m => m.Path);
	        	 Map(m => m.Creator);
	        	 Map(m => m.CreateTime);
	        	 Map(m => m.SortNumber);
	        		
						     }
    }
}

