using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 申请人
    /// </summary>
    [DataContract]
    public class SQR : CommonEntity
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public SQR() : base("BIZ_INFO_SQR") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
		///<param name="bSID">标识ID：对于带有版本的对象，这是各版本的唯一标识ID</param>
		///<param name="sQRLX">申请人类型。1为申请人，2为单位</param>
		///<param name="jGDM">机构代码，申请代码</param>
		///<param name="sQRMC">申请人名称</param>
		///<param name="sQRZJLX">申请人证件类型</param>
		///<param name="sQRZJH">申请人证件号</param>
		///<param name="zGBMDM">主管部门代码</param>
		///<param name="zGBM">主管部门</param>
		///<param name="dWXZ">单位性质</param>
		///<param name="fRDBXM">法人代表姓名</param>
		///<param name="fRDBZJLX">法人代表证件类型</param>
		///<param name="fRDBZJH">法人代表证件号</param>
		///<param name="fRDBDHHM">法人代表电话号码</param>
		///<param name="fRZW">法人职务</param>
		///<param name="sJHM">法人手机号码</param>
		///<param name="lXDH">联系电话</param>
		///<param name="cZHM">传真号码</param>
		///<param name="eMAIL">电子邮件</param>
		///<param name="tXDZ">通信地址</param>
		///<param name="yZBM">邮政编码</param>
		///<param name="nYHKBS">农业人口标识：１为农业，０为非农</param>
		///<param name="zXBS">注销标识：1正常，2历史，-1为注销</param>
		///<param name="kHYH">开户银行</param>
		///<param name="yHZH">银行账号</param>
		///<param name="zCZJ">注册资金</param>
		///<param name="zJLY">资金来源</param>
		///<param name="iSDELETE">是否删除</param>
		///<param name="iSSHARE">是否共享</param>
		///<param name="iSVALID">是否有效</param>
		///<param name="iSCONFIG">是否可配置</param>
		///<param name="sORTORDER">顺序号</param>
		///<param name="cREATEPERSONID">创建人ID</param>
		///<param name="cREATEDATE">创建日期</param>
		///<param name="mODIFYPERSONID">修改人</param>
		///<param name="mODIFYDATE">修改日期</param>
		///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
		///<param name="oRGANIZATIONID">组织机构部门</param>
		///<param name="pREVIOUSID">历史数据ID</param>
		///<param name="gSZZBH">工商执照编号(单位)</param>
        public SQR(string iD, string bSID, int sQRLX, string jGDM, string sQRMC, string sQRZJLX, string sQRZJH, string zGBMDM, string zGBM, string dWXZ, string fRDBXM, string fRDBZJLX, string fRDBZJH, string fRDBDHHM, string fRZW, string sJHM, string lXDH, string cZHM, string eMAIL, string tXDZ, string yZBM, int nYHKBS, int zXBS, string kHYH, string yHZH, double? zCZJ, string zJLY, int iSDELETE, int iSSHARE, int iSVALID, int iSCONFIG, int sORTORDER, string cREATEPERSONID, DateTime cREATEDATE, string mODIFYPERSONID, DateTime mODIFYDATE, int dATAORIGIN, string oRGANIZATIONID, string pREVIOUSID, string gSZZBH)
            : this()
        {
            this.ID = iD;
            this.BSID = bSID;
            this.SQRLX = sQRLX;
            this.JGDM = jGDM;
            this.SQRMC = sQRMC;
            this.SQRZJLX = sQRZJLX;
            this.SQRZJH = sQRZJH;
            this.ZGBMDM = zGBMDM;
            this.ZGBM = zGBM;
            this.DWXZ = dWXZ;
            this.FRDBXM = fRDBXM;
            this.FRDBZJLX = fRDBZJLX;
            this.FRDBZJH = fRDBZJH;
            this.FRDBDHHM = fRDBDHHM;
            this.FRZW = fRZW;
            this.SJHM = sJHM;
            this.LXDH = lXDH;
            this.CZHM = cZHM;
            this.EMAIL = eMAIL;
            this.TXDZ = tXDZ;
            this.YZBM = yZBM;
            this.NYHKBS = nYHKBS;
            this.ZXBS = zXBS;
            this.KHYH = kHYH;
            this.YHZH = yHZH;
            this.ZCZJ = zCZJ;
            this.ZJLY = zJLY;
            this.ISDELETE = iSDELETE;
            this.ISSHARE = iSSHARE;
            this.ISVALID = iSVALID;
            this.ISCONFIG = iSCONFIG;
            this.SORTORDER = sORTORDER;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.MODIFYDATE = mODIFYDATE;
            this.DATAORIGIN = dATAORIGIN;
            this.ORGANIZATIONID = oRGANIZATIONID;
            this.PREVIOUSID = pREVIOUSID;
            this.GSZZBH = gSZZBH;
        }
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
            sb.Append(this.BSID);
            sb.Append(this.SQRLX);
            sb.Append(this.JGDM);
            sb.Append(this.SQRMC);
            sb.Append(this.SQRZJLX);
            sb.Append(this.SQRZJH);
            sb.Append(this.ZGBMDM);
            sb.Append(this.ZGBM);
            sb.Append(this.DWXZ);
            sb.Append(this.FRDBXM);
            sb.Append(this.FRDBZJLX);
            sb.Append(this.FRDBZJH);
            sb.Append(this.FRDBDHHM);
            sb.Append(this.FRZW);
            sb.Append(this.SJHM);
            sb.Append(this.LXDH);
            sb.Append(this.CZHM);
            sb.Append(this.EMAIL);
            sb.Append(this.TXDZ);
            sb.Append(this.YZBM);
            sb.Append(this.NYHKBS);
            sb.Append(this.ZXBS);
            sb.Append(this.KHYH);
            sb.Append(this.YHZH);
            sb.Append(this.ZCZJ);
            sb.Append(this.ZJLY);
            sb.Append(this.ISDELETE);
            sb.Append(this.ISSHARE);
            sb.Append(this.ISVALID);
            sb.Append(this.ISCONFIG);
            sb.Append(this.SORTORDER);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.MODIFYDATE);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.ORGANIZATIONID);
            sb.Append(this.PREVIOUSID);
            sb.Append(this.GSZZBH);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 标识ID：对于带有版本的对象，这是各版本的唯一标识ID
        /// </summary>
        [DataMember]
        public virtual string BSID { get; set; }
        /// <summary>
        /// 申请人类型。1为申请人，2为单位
        /// </summary>
        [DataMember]
        public virtual int SQRLX { get; set; }
        /// <summary>
        /// 机构代码，申请代码
        /// </summary>
        [DataMember]
        public virtual string JGDM { get; set; }
        /// <summary>
        /// 申请人名称
        /// </summary>
        [DataMember]
        public virtual string SQRMC { get; set; }
        /// <summary>
        /// 申请人证件类型
        /// </summary>
        [DataMember]
        public virtual string SQRZJLX { get; set; }
        /// <summary>
        /// 申请人证件号
        /// </summary>
        [DataMember]
        public virtual string SQRZJH { get; set; }
        /// <summary>
        /// 主管部门代码
        /// </summary>
        [DataMember]
        public virtual string ZGBMDM { get; set; }
        /// <summary>
        /// 主管部门
        /// </summary>
        [DataMember]
        public virtual string ZGBM { get; set; }
        /// <summary>
        /// 单位性质
        /// </summary>
        [DataMember]
        public virtual string DWXZ { get; set; }
        /// <summary>
        /// 法人代表姓名
        /// </summary>
        [DataMember]
        public virtual string FRDBXM { get; set; }
        /// <summary>
        /// 法人代表证件类型
        /// </summary>
        [DataMember]
        public virtual string FRDBZJLX { get; set; }
        /// <summary>
        /// 法人代表证件号
        /// </summary>
        [DataMember]
        public virtual string FRDBZJH { get; set; }
        /// <summary>
        /// 法人代表电话号码
        /// </summary>
        [DataMember]
        public virtual string FRDBDHHM { get; set; }
        /// <summary>
        /// 法人职务
        /// </summary>
        [DataMember]
        public virtual string FRZW { get; set; }
        /// <summary>
        /// 法人手机号码
        /// </summary>
        [DataMember]
        public virtual string SJHM { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public virtual string LXDH { get; set; }
        /// <summary>
        /// 传真号码
        /// </summary>
        [DataMember]
        public virtual string CZHM { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [DataMember]
        public virtual string EMAIL { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        [DataMember]
        public virtual string TXDZ { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [DataMember]
        public virtual string YZBM { get; set; }
        /// <summary>
        /// 农业人口标识：１为农业，０为非农
        /// </summary>
        [DataMember]
        public virtual int NYHKBS { get; set; }
        /// <summary>
        /// 注销标识：1正常，2历史，-1为注销
        /// </summary>
        [DataMember]
        public virtual int ZXBS { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        [DataMember]
        public virtual string KHYH { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        [DataMember]
        public virtual string YHZH { get; set; }
        /// <summary>
        /// 注册资金
        /// </summary>
        [DataMember]
        public virtual double? ZCZJ { get; set; }
        /// <summary>
        /// 资金来源
        /// </summary>
        [DataMember]
        public virtual string ZJLY { get; set; }
        /// <summary>
        /// 历史数据ID
        /// </summary>
        [DataMember]
        public virtual string PREVIOUSID { get; set; }
        /// <summary>
        /// 工商执照编号(单位)
        /// </summary>
        [DataMember]
        public virtual string GSZZBH { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string LXR { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

