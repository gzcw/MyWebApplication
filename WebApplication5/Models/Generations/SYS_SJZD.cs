using FluentNHibernate.Mapping;
using Lab.Framework;
using System;
using System.Runtime.Serialization;

namespace WebApplication5.Models
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public partial class SYS_SJZD : StringEntity, ICloneable
    {
        private string _NAME = null;
        private string _SZ = null;
        private string _ZDBM = null;
        private string _ZDMC = null;
        private decimal? _PARENTID = null;


        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        /// <summary>
        /// 数值
        /// </summary>
        [DataMember]
        public virtual string SZ
        {
            get { return _SZ; }
            set { _SZ = value; }
        }

        /// <summary>
        /// 字典名称
        /// </summary>
        [DataMember]
        public virtual string ZDMC
        {
            get { return _ZDMC; }
            set { _ZDMC = value; }
        }

        /// <summary>
        /// 字典编码
        /// </summary>
        [DataMember]
        public virtual string ZDBM
        {
            get { return _ZDBM; }
            set { _ZDBM = value; }
        }

        /// <summary>
        /// 上级字典
        /// </summary>
        [DataMember]
        public virtual decimal? PARENTID
        {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }





        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class SYS_SJZDMap : ClassMap<SYS_SJZD>
    {
        public SYS_SJZDMap()
        {
            Id(m => m.ID).GeneratedBy.UuidHex("D");
            Map(m => m.NAME);
            Map(m => m.SZ);
            Map(m => m.ZDBM);
            Map(m => m.ZDMC);
            Map(m => m.PARENTID);

        }
    }
}

