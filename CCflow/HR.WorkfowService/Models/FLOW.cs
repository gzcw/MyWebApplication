using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 流程
    /// </summary>
    [DataContract]
    public class FLOW : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public FLOW() : base("WF_FLOW") { }
        
        #endregion

        #region 其他方法
        /// <summary>
        /// 重写实体对象哈希值的获取方法
        /// </summary>
        /// <returns>实体对象的哈希值</returns>
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(this.NO);
            sb.Append(this.NAME);
            sb.Append(this.FK_FLOWSORT);
            sb.Append(this.FLOWRUNWAY);
            sb.Append(this.RUNOBJ);
            sb.Append(this.NOTE);
            sb.Append(this.RUNSQL);
            sb.Append(this.NUMOFBILL);
            sb.Append(this.NUMOFDTL);
            sb.Append(this.FLOWAPPTYPE);
            sb.Append(this.ISCANSTART);
            sb.Append(this.AVGDAY);
            sb.Append(this.ISFULLSA);
            sb.Append(this.ISMD5);
            sb.Append(this.IDX);
            sb.Append(this.TIMELINEROLE);
            sb.Append(this.PARAS);
            sb.Append(this.PTABLE);
            sb.Append(this.DATASTOREMODEL);
            sb.Append(this.TITLEROLE);
            sb.Append(this.FLOWMARK);
            sb.Append(this.FLOWEVENTENTITY);
            sb.Append(this.HISTORYFIELDS);
            sb.Append(this.ISGUESTFLOW);
            sb.Append(this.BILLNOFORMAT);
            sb.Append(this.FLOWNOTEEXP);
            sb.Append(this.DRCTRLTYPE);
            sb.Append(this.STARTLIMITROLE);
            sb.Append(this.STARTLIMITPARA);
            sb.Append(this.STARTLIMITALERT);
            sb.Append(this.STARTLIMITWHEN);
            sb.Append(this.STARTGUIDEWAY);
            sb.Append(this.STARTGUIDEPARA1);
            sb.Append(this.STARTGUIDEPARA2);
            sb.Append(this.STARTGUIDEPARA3);
            sb.Append(this.ISRESETDATA);
            sb.Append(this.ISLOADPRIDATA);
            sb.Append(this.CFLOWWAY);
            sb.Append(this.CFLOWPARA);
            sb.Append(this.ISBATCHSTART);
            sb.Append(this.BATCHSTARTFIELDS);
            sb.Append(this.ISAUTOSENDSUBFLOWOVER);
            sb.Append(this.VER);
            sb.Append(this.DESIGNERNO);
            sb.Append(this.DESIGNERNAME);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 编号,-,主键
        /// </summary>
        [DataMember]
        public virtual string NO { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string NAME { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        [DataMember]
        public virtual string FK_FLOWSORT { get; set; }
        /// <summary>
        /// 运行方式,枚举类型:0,手工启动;1,指定人员按时启动;2,数据集按时启动;3,触发式启动;
        /// </summary>
        [DataMember]
        public virtual decimal? FLOWRUNWAY { get; set; }
        /// <summary>
        /// 运行内容
        /// </summary>
        [DataMember]
        public virtual string RUNOBJ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string NOTE { get; set; }
        /// <summary>
        /// 运行SQL
        /// </summary>
        [DataMember]
        public virtual string RUNSQL { get; set; }
        /// <summary>
        /// NUMOFBILL
        /// </summary>
        [DataMember]
        public virtual decimal? NUMOFBILL { get; set; }
        /// <summary>
        /// NUMOFDTL
        /// </summary>
        [DataMember]
        public virtual decimal? NUMOFDTL { get; set; }
        /// <summary>
        /// FLOWAPPTYPE
        /// </summary>
        [DataMember]
        public virtual decimal? FLOWAPPTYPE { get; set; }
        /// <summary>
        /// ISCANSTART
        /// </summary>
        [DataMember]
        public virtual decimal? ISCANSTART { get; set; }
        /// <summary>
        /// AVGDAY
        /// </summary>
        [DataMember]
        public virtual decimal? AVGDAY { get; set; }
        /// <summary>
        /// ISFULLSA
        /// </summary>
        [DataMember]
        public virtual decimal? ISFULLSA { get; set; }
        /// <summary>
        /// ISMD5
        /// </summary>
        [DataMember]
        public virtual decimal? ISMD5 { get; set; }
        /// <summary>
        /// IDX
        /// </summary>
        [DataMember]
        public virtual decimal? IDX { get; set; }
        /// <summary>
        /// TIMELINEROLE
        /// </summary>
        [DataMember]
        public virtual decimal? TIMELINEROLE { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        [DataMember]
        public virtual string PARAS { get; set; }
        /// <summary>
        /// PTABLE
        /// </summary>
        [DataMember]
        public virtual string PTABLE { get; set; }
        /// <summary>
        /// DATASTOREMODEL
        /// </summary>
        [DataMember]
        public virtual decimal? DATASTOREMODEL { get; set; }
        /// <summary>
        /// TITLEROLE
        /// </summary>
        [DataMember]
        public virtual string TITLEROLE { get; set; }
        /// <summary>
        /// FLOWMARK
        /// </summary>
        [DataMember]
        public virtual string FLOWMARK { get; set; }
        /// <summary>
        /// FLOWEVENTENTITY
        /// </summary>
        [DataMember]
        public virtual string FLOWEVENTENTITY { get; set; }
        /// <summary>
        /// HISTORYFIELDS
        /// </summary>
        [DataMember]
        public virtual string HISTORYFIELDS { get; set; }
        /// <summary>
        /// ISGUESTFLOW
        /// </summary>
        [DataMember]
        public virtual decimal? ISGUESTFLOW { get; set; }
        /// <summary>
        /// BILLNOFORMAT
        /// </summary>
        [DataMember]
        public virtual string BILLNOFORMAT { get; set; }
        /// <summary>
        /// FLOWNOTEEXP
        /// </summary>
        [DataMember]
        public virtual string FLOWNOTEEXP { get; set; }
        /// <summary>
        /// DRCTRLTYPE
        /// </summary>
        [DataMember]
        public virtual decimal? DRCTRLTYPE { get; set; }
        /// <summary>
        /// STARTLIMITROLE
        /// </summary>
        [DataMember]
        public virtual decimal? STARTLIMITROLE { get; set; }
        /// <summary>
        /// STARTLIMITPARA
        /// </summary>
        [DataMember]
        public virtual string STARTLIMITPARA { get; set; }
        /// <summary>
        /// STARTLIMITALERT
        /// </summary>
        [DataMember]
        public virtual string STARTLIMITALERT { get; set; }
        /// <summary>
        /// STARTLIMITWHEN
        /// </summary>
        [DataMember]
        public virtual decimal? STARTLIMITWHEN { get; set; }
        /// <summary>
        /// STARTGUIDEWAY
        /// </summary>
        [DataMember]
        public virtual decimal? STARTGUIDEWAY { get; set; }
        /// <summary>
        /// 导航Url
        /// </summary>
        [DataMember]
        public virtual string STARTGUIDEPARA1 { get; set; }
        /// <summary>
        /// STARTGUIDEPARA2
        /// </summary>
        [DataMember]
        public virtual string STARTGUIDEPARA2 { get; set; }
        /// <summary>
        /// STARTGUIDEPARA3
        /// </summary>
        [DataMember]
        public virtual string STARTGUIDEPARA3 { get; set; }
        /// <summary>
        /// ISRESETDATA
        /// </summary>
        [DataMember]
        public virtual decimal? ISRESETDATA { get; set; }
        /// <summary>
        /// ISLOADPRIDATA
        /// </summary>
        [DataMember]
        public virtual decimal? ISLOADPRIDATA { get; set; }
        /// <summary>
        /// CFLOWWAY
        /// </summary>
        [DataMember]
        public virtual decimal? CFLOWWAY { get; set; }
        /// <summary>
        /// CFLOWPARA
        /// </summary>
        [DataMember]
        public virtual string CFLOWPARA { get; set; }
        /// <summary>
        /// ISBATCHSTART
        /// </summary>
        [DataMember]
        public virtual decimal? ISBATCHSTART { get; set; }
        /// <summary>
        /// BATCHSTARTFIELDS
        /// </summary>
        [DataMember]
        public virtual string BATCHSTARTFIELDS { get; set; }
        /// <summary>
        /// ISAUTOSENDSUBFLOWOVER
        /// </summary>
        [DataMember]
        public virtual decimal? ISAUTOSENDSUBFLOWOVER { get; set; }
        /// <summary>
        /// VER
        /// </summary>
        [DataMember]
        public virtual string VER { get; set; }
        /// <summary>
        /// DESIGNERNO
        /// </summary>
        [DataMember]
        public virtual string DESIGNERNO { get; set; }
        /// <summary>
        /// DESIGNERNAME
        /// </summary>
        [DataMember]
        public virtual string DESIGNERNAME { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

