﻿
using System;
using System.Data;
using System.Collections;
using BP.DA;
using BP.En;

namespace BP.Sys
{
    /// <summary>
    /// 通用OID实体
    /// </summary>
    public class GEEntityMyPK : Entity
    {
        #region 构造函数
        /// <summary>
        /// 设置或者获取主键值.
        /// </summary>
        public string MyPK
        {
            get
            {
                return this.GetValStrByKey("MyPK");
            }
            set
            {
                this.SetValByKey("MyPK", value);
            }
        }
        /// <summary>
        /// 主键值
        /// </summary>
        public override string PK
        {
            get
            {
                return "MyPK";
            }
        }
        /// <summary>
        ///  主键字段
        /// </summary>
        public override string PKField
        {
            get
            {
                return "MyPK";
            }
        }
        /// <summary>
        /// 转化为类.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.FK_MapData;
        }
        public override string ClassID
        {
            get
            {
                return this.FK_MapData;
            }
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string FK_MapData = null;
        /// <summary>
        /// 通用OID实体
        /// </summary>
        public GEEntityMyPK()
        {
        }
        /// <summary>
        /// 通用OID实体
        /// </summary>
        /// <param name="nodeid">节点ID</param>
        public GEEntityMyPK(string fk_mapdata)
        {
            this.FK_MapData = fk_mapdata;
        }
        /// <summary>
        /// 通用OID实体
        /// </summary>
        /// <param name="nodeid">节点ID</param>
        /// <param name="_oid">OID</param>
        public GEEntityMyPK(string fk_mapdata, string pk)
        {
            this.FK_MapData = fk_mapdata;
            this.PKVal = pk;
            this.Retrieve();
        }
        #endregion

        #region 构造映射.
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override Map EnMap
        {
            get
            {
                if (this._enMap != null)
                    return this._enMap;

                if (this.FK_MapData == null)
                    throw new Exception("没有给" + this.FK_MapData + "值，您不能获取它的Map。");

                this._enMap = BP.Sys.MapData.GenerHisMap(this.FK_MapData);
                return this._enMap;
            }
        }
        /// <summary>
        /// GEEntityMyPKs
        /// </summary>
        public override Entities GetNewEntities
        {
            get
            {
                if (this.FK_MapData == null)
                    return new GEEntityMyPKs();
                return new GEEntityMyPKs(this.FK_MapData);
            }
        }
        #endregion

        /// <summary>
        /// 从另外的一个实体来copy数据.
        /// </summary>
        /// <param name="en"></param>
        public void CopyFromFrm(GEEntityMyPK en)
        {
            //先求出来旧的OID.
            string oldOID = this.MyPK;

            //复制主表数据.
            this.Copy(en);
            this.Save();
            this.MyPK = oldOID;

            //复制从表数据.
            MapDtls dtls = new MapDtls(this.FK_MapData);

            //被copy的明细集合.
            MapDtls dtlsFrom = new MapDtls(en.FK_MapData);

            if (dtls.Count != dtls.Count)
                throw new Exception("@复制的两个表单从表不一致...");

            //序号.
            int i = 0;
            foreach (MapDtl dtl in dtls)
            {
                //删除旧的数据.
                BP.DA.DBAccess.RunSQL("DELETE FROM " + dtl.PTable + " WHERE RefPK=" + this.MyPK);

                //求对应的Idx的，从表配置.
                MapDtl dtlFrom = dtlsFrom[i] as MapDtl;
                GEDtls ensDtlFrom = new GEDtls(dtlFrom.No);
                ensDtlFrom.Retrieve(GEDtlAttr.RefPK, oldOID);

                //创建一个实体.
                GEDtl dtlEnBlank =  new GEDtl(dtl.No); 

                // 遍历数据,执行copy.
                foreach (GEDtl enDtlFrom in ensDtlFrom)
                {
                    dtlEnBlank.Copy(enDtlFrom);
                    dtlEnBlank.RefPK = this.MyPK.ToString();
                    dtlEnBlank.SaveAsNew();
                }
                i++;
            }

            //复制附件数据.
            FrmAttachments aths = new FrmAttachments(this.FK_MapData);
            FrmAttachments athsFrom = new FrmAttachments(en.FK_MapData);
            foreach (FrmAttachment ath in aths)
            {
                //删除数据,防止copy重复
                DBAccess.RunSQL("DELETE FROM Sys_FrmAttachmentDB WHERE FK_MapData='" + this.FK_MapData + "' AND RefPKVal='" + this.MyPK + "'");
                
                foreach (FrmAttachment athFrom in athsFrom)
                {
                    if (athFrom.NoOfObj != ath.NoOfObj)
                        continue;

                    FrmAttachmentDBs athDBsFrom = new FrmAttachmentDBs();
                    athDBsFrom.Retrieve(FrmAttachmentDBAttr.FK_FrmAttachment, athFrom.MyPK, FrmAttachmentDBAttr.RefPKVal, en.MyPK.ToString());
                    foreach (FrmAttachmentDB athDBFrom in athDBsFrom)
                    {
                        athDBFrom.MyPK = BP.DA.DBAccess.GenerGUID();
                        athDBFrom.FK_FrmAttachment = ath.MyPK;
                        athDBFrom.RefPKVal = this.MyPK.ToString();
                        athDBFrom.Insert();
                    }

                }
            }
        }
        /// <summary>
        /// 把当前实体的数据copy到指定的主键数据表里.
        /// </summary>
        /// <param name="oid">指定的主键</param>
        public void CopyToOID(string oid)
        {
            //实例化历史数据表单entity.
            string oidOID = this.MyPK;
            this.MyPK = oid;
            this.Save();

            //复制从表数据.
            MapDtls dtls = new MapDtls(this.FK_MapData);
            foreach (MapDtl dtl in dtls)
            {
                //删除旧的数据.
                BP.DA.DBAccess.RunSQL("DELETE FROM " + dtl.PTable + " WHERE RefPK=" + this.MyPK);

                GEDtls ensDtl = new GEDtls(dtl.No);
                ensDtl.Retrieve(GEDtlAttr.RefPK, oidOID);
                foreach (GEDtl enDtl in ensDtl)
                {
                    enDtl.RefPK = this.MyPK.ToString();
                    enDtl.InsertAsNew();
                }
            }

            //复制附件数据.
            FrmAttachments aths = new FrmAttachments(this.FK_MapData);
            foreach (FrmAttachment ath in aths)
            {
                //删除可能存在的新oid数据。
                DBAccess.RunSQL("DELETE FROM Sys_FrmAttachmentDB WHERE FK_MapData='" + this.FK_MapData + "' AND RefPKVal='" + this.MyPK + "'");

                //找出旧数据.
                FrmAttachmentDBs athDBs = new FrmAttachmentDBs(this.FK_MapData, oidOID.ToString());
                foreach (FrmAttachmentDB athDB in athDBs)
                {
                    FrmAttachmentDB athDB_N = new FrmAttachmentDB();
                    athDB_N.Copy(athDB);

                    athDB_N.FK_MapData = this.FK_MapData;
                    athDB_N.RefPKVal = this.MyPK.ToString();

                    if (athDB_N.HisAttachmentUploadType == AttachmentUploadType.Single)
                    {
                        /*如果是单附件.*/
                        athDB_N.MyPK = athDB_N.FK_FrmAttachment + "_" + this.MyPK;
                        if (athDB_N.IsExits == true)
                            continue;  /*说明上一个节点或者子线程已经copy过了, 但是还有子线程向合流点传递数据的可能，所以不能用break.*/

                        athDB_N.Insert();
                    }
                    else
                    {
                        athDB_N.MyPK = DBAccess.GenerGUID(); 
                        athDB_N.Insert();
                    }
                }
            }
        }
        private ArrayList _Dtls = null;
        public ArrayList Dtls
        {
            get
            {
                if (_Dtls == null)
                    _Dtls = new ArrayList();
                return _Dtls;
            }
        }
    }
    /// <summary>
    /// 通用OID实体s
    /// </summary>
    public class GEEntityMyPKs : Entities
    {
        #region 重载基类方法
        public override string ToString()
        {
            //if (this.FK_MapData == null)
            //    throw new Exception("@没有能 FK_MapData 给值。");
            return this.FK_MapData;
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string FK_MapData = null;
        #endregion

        #region 方法
        /// <summary>
        /// 得到它的 Entity
        /// </summary>
        public override Entity GetNewEntity
        {
            get
            {
                if (this.FK_MapData == null)
                    return new GEEntityMyPK();
                return new GEEntityMyPK(this.FK_MapData);
            }
        }
        /// <summary>
        /// 通用OID实体ID
        /// </summary>
        public GEEntityMyPKs()
        {
        }
        /// <summary>
        /// 通用OID实体ID
        /// </summary>
        /// <param name="fk_mapdtl"></param>
        public GEEntityMyPKs(string fk_mapdata)
        {
            this.FK_MapData = fk_mapdata;
        }
        #endregion

        #region 为了适应自动翻译成java的需要,把实体转换成List.
        /// <summary>
        /// 转化成 java list,C#不能调用.
        /// </summary>
        /// <returns>List</returns>
        public System.Collections.Generic.IList<GEEntityMyPK> ToJavaList()
        {
            return (System.Collections.Generic.IList<GEEntityMyPK>)this;
        }
        /// <summary>
        /// 转化成list
        /// </summary>
        /// <returns>List</returns>
        public System.Collections.Generic.List<GEEntityMyPK> Tolist()
        {
            System.Collections.Generic.List<GEEntityMyPK> list = new System.Collections.Generic.List<GEEntityMyPK>();
            for (int i = 0; i < this.Count; i++)
            {
                list.Add((GEEntityMyPK)this[i]);
            }
            return list;
        }
        #endregion 为了适应自动翻译成java的需要,把实体转换成List.
    }
}
