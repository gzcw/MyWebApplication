using HR.WorkflowService.Common;
////using HR.WorkflowService.DAOs;
using Iesi.Collections.Generic;
using System;
using System.Runtime.Serialization;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 编号
    /// </summary>
    [DataContract]
    public class BH : CommonEntity
    {
        private readonly object lockObj = new object();

        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BH() : base("BIZ_INFO_BH") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">办文类型ID</param>
        ///<param name="bHMC">编号名称</param>
        ///<param name="cZFS">重置方式,0:没有1：年2：月3：日</param>
        ///<param name="bHBDS">编号表达式</param>
        ///<param name="lSH">当前流水号</param>
        ///<param name="bC">流水号步长</param>
        ///<param name="cD">流水号长度</param>
        ///<param name="bHSM">编号说明</param>
        ///<param name="iSDELETE">是否删除</param>
        ///<param name="iSSHARE">是否共享</param>
        ///<param name="iSVALID">是否有效</param>
        ///<param name="iSCONFIG">是否可配置</param>
        ///<param name="sORTORDER">顺序号</param>
        ///<param name="cREATEPERSONID">创建人ID</param>
        ///<param name="cREATEDATE">创建日期</param>
        ///<param name="mODIFYPERSONID">修改人ID</param>
        ///<param name="mODIFYDATE">修改日期</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        public BH(string iD, string bHMC, decimal? cZFS, string bHBDS, decimal? lSH, decimal? bC, decimal? cD, string bHSM, int iSDELETE, int iSSHARE, int iSVALID, int iSCONFIG, int? sORTORDER, string cREATEPERSONID, DateTime? cREATEDATE, string mODIFYPERSONID, DateTime? mODIFYDATE, int dATAORIGIN)
            : this()
        {
            this.ID = iD;
            this.BHMC = bHMC;
            this.CZFS = cZFS;
            this.BHBDS = bHBDS;
            this.LSH = lSH;
            this.BC = bC;
            this.CD = cD;
            this.BHSM = bHSM;
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
            sb.Append(this.BHMC);
            sb.Append(this.CZFS);
            sb.Append(this.BHBDS);
            sb.Append(this.LSH);
            sb.Append(this.BC);
            sb.Append(this.CD);
            sb.Append(this.BHSM);
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
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 编号名称
        /// </summary>
        [DataMember]
        public virtual string BHMC { get; set; }
        /// <summary>
        /// 重置方式,0:没有1：年2：月3：日
        /// </summary>
        [DataMember]
        public virtual decimal? CZFS { get; set; }
        /// <summary>
        /// 编号表达式
        /// </summary>
        [DataMember]
        public virtual string BHBDS { get; set; }
        /// <summary>
        /// 当前流水号
        /// </summary>
        [DataMember]
        public virtual decimal? LSH { get; set; }
        /// <summary>
        /// 流水号步长
        /// </summary>
        [DataMember]
        public virtual decimal? BC { get; set; }
        /// <summary>
        /// 流水号长度
        /// </summary>
        [DataMember]
        public virtual decimal? CD { get; set; }
        /// <summary>
        /// 编号说明
        /// </summary>
        [DataMember]
        public virtual string BHSM { get; set; }
        #endregion

        #region 手动追加属性

        private static Object thisLock = new Object();

        /// <summary>
        /// 创建编号
        /// </summary>
        /// <param name="workflowName">流程名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="reigon">区域</param>
        /// <param name="xzqhbm">行政区划编码</param>
        /// <returns>编号</returns>
        public virtual string CreateCode(string workflowName = "", string userName = "", string reigon = "", string xzqhbm = "")
        {
            //lock (thisLock)
            //{
                if (this.CZFS.HasValue)
                {
                    switch ((int)this.CZFS.Value)
                    {
                        case 0: //重制方式: 无
                            this.MODIFYDATE = System.DateTime.Today; break;  
                        case 1: //重制方式: 年
                            if (this.MODIFYDATE.Value.Year != System.DateTime.Today.Year)
                            {
                                this.MODIFYDATE = System.DateTime.Today;
                                this.LSH = 0;
                            }
                            break;
                        case 2: //重制方式: 月
                            if (this.MODIFYDATE.Value.Year != System.DateTime.Today.Year || this.MODIFYDATE.Value.Month != System.DateTime.Today.Month)
                            {
                                this.MODIFYDATE = System.DateTime.Today;
                                this.LSH = 0;
                            }
                            break;
                        default://重制方式: 日
                            if (!this.MODIFYDATE.Equals(System.DateTime.Today))
                            {
                                this.MODIFYDATE = System.DateTime.Today;
                                this.LSH = 0;
                            }
                            break;
                    }
                }

                var date = DateTime.Now;

                var result = this.BHBDS
                    .Replace("{Y}", date.Year.ToString())
                    .Replace("{M}", (date.Month + 100).ToString().Substring(1, 2).ToString())
                    .Replace("{D}", (date.Day + 100).ToString().Substring(1, 2).ToString())
                    .Replace("{H}", (date.Hour + 100).ToString().Substring(1, 2).ToString())
                    .Replace("{I}", (date.Minute + 100).ToString().Substring(1, 2).ToString())
                    .Replace("{S}", (date.Second + 100).ToString().Substring(1, 2).ToString())
                    .Replace("{F}", workflowName)
                    .Replace("{U}", userName)
                    .Replace("{N}", GetNextNumber())
                    .Replace("{Q}", reigon)
                    .Replace("{QM}", xzqhbm);

                this.LSH += this.BC;
                DataContextNH.Update<BH>(this);
                return result;
            //}
        }

        /// <summary>
        /// 获取下一个编号
        /// </summary>
        /// <returns>编号</returns>
        private string GetNextNumber()
        {
            if (!LSH.HasValue || !BC.HasValue)
            {
                return "";
            }
            var number = LSH + BC;
            if (!CD.HasValue || number.ToString().Length >= CD)
            {
                return number.ToString();
            }
            var result = number.ToString();
            for (var i = 0; i < (CD - number.ToString().Length); i++)
            {
                result = "0" + result;
            }
            return result;
        }

        #endregion
    }
}

