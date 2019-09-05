using WebApplication5.Models;
using Lab.CommonBussiness.Helpers;
using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    /// <summary>
    /// 【附件名称】控制器
    /// </summary>
    public partial class AttachmentController : StringEntityController<Sys_Attachment>
    {
        #region 视图

        public ActionResult NewUp()
        {
            return View();
        }

        #endregion

        #region 视图
        public ActionResult BwaFuJian()
        {
            return View();
        }

        public ActionResult FuJianFrame()
        {
            return View();
        }

        public ActionResult NewUpFrame()
        {
            return View();
        }

        public ActionResult FolderForm()
        {
            return View();
        }

        public ActionResult FileForm()
        {
            return View();
        }

        public ActionResult FuJian()
        {
            return View();
        }
        #endregion


        public ActionResult GetTreeDataByRecordID(string recordID, string category = "", string orders = "")
        {
            if (string.IsNullOrEmpty(recordID))
            {
                return Json_Get(new List<string>());
            }
            var sql = string.Format("SELECT * FROM Sys_Attachment T WHERE T.RecordID='{0}' AND T.Category='{1}'", recordID, category);
            var parentRecords = QueryService.GetData(sql + " AND (T.ParentID IS NULL OR T.ParentID='')", null, orders).Select(x => x as ExpandoObject).ToList();
            var allRecords = QueryService.GetData(sql, null, orders).Select(x => x as ExpandoObject).ToList();
            TreeHelper.FillChildren(ref parentRecords, allRecords, "ID", "ParentID", "Name");
            return Json_Get(parentRecords);
        }

        /// <summary>
        /// 根据RecordId、fjlb查找数据
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fjlb"></param>
        /// <returns></returns>
        public ActionResult GetDataByRecordId(string recordId, string fjlb, string orders)
        {
            var sql = string.Format("SELECT T.*,REPLACE(T.NAME,T.FILETYPE,'') AS ShortName FROM Ls_Common_Fj T WHERE T.RecordID='{0}' AND T.Category='{1}' AND T.ISDELETED=0", recordId, fjlb);

            var data = QueryService.GetData(sql, new List<MyFilter>(), orders);

            return Json_Get(data);
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="DocType"></param>
        /// <param name="bwaID"></param>
        /// <param name="file"></param>
        /// <summary>
        //[HttpPost]
        //public ActionResult UploadFuJian(string recordId, string fjlb = "document")
        //{
        //    var file = Request.Files[0];

        //    if (string.IsNullOrEmpty(recordId))
        //    {
        //        throw new Exception("recordId不能为空");
        //    }

        //    if (file != null && file.ContentLength > 0)
        //    {
        //        try
        //        {
        //            var httpDirectory = string.Format("{0}/{1}/{2}/", FtpServerHttp, recordId, fjlb);
        //            //用全角#替换半角#，避免下载、预览时出错
        //            var ftpFileName = Path.GetFileName(file.FileName.Substring(0, file.FileName.LastIndexOf('.')).Replace("#", "＃").Replace("+", "＋")) + Path.GetExtension(file.FileName).ToLower();

        //            var filePath = string.Format("/{0}/{1}", recordId, fjlb);
        //            var uploadSuccess = fileUpload(file, filePath, ftpFileName, true);

        //            if (uploadSuccess == false)
        //            {
        //                return Json(new { success = false });
        //            }

        //            var entity = new Sys_Attachment()
        //            {
        //                NAME = ftpFileName.Replace("#", "＃").Replace("+", "＋"),
        //                PATH = httpDirectory + ftpFileName.Replace("#", "＃").Replace("+", "＋"),
        //                FILETYPE = Path.GetExtension(ftpFileName).ToLower(),
        //                ISDIRECTORY = false,
        //                CREATOR = User.Identity.Name,
        //                CREATETIME = DateTime.Now,
        //                RecordID = recordId,
        //                SortNumber = 100,
        //                PARENTID = "",
        //                Category = fjlb
        //            };
        //            entity.Save();
        //            return Json(new { name = ftpFileName.Replace("#", "＃").Replace("+", "＋"), path = httpDirectory + ftpFileName.Replace("#", "＃").Replace("+", "＋"), success = true });

        //        }
        //        catch (Exception)
        //        {
        //            return Json(new { success = false });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new { success = false });
        //    }
        //}


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件流</returns>
        public ActionResult DownFile(string filePath, string fileName = "")
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = filePath.Split('/').Last();
                fileName = fileName.Split('\\').Last();
            }


            System.Net.WebClient myWebClient = new System.Net.WebClient();
            try
            {
                var stream = myWebClient.OpenRead(filePath);

                return File(stream, "APPLICATION/OCTET-STREAM", HttpUtility.UrlEncode(fileName, Encoding.GetEncoding("UTF-8")));
            }
            catch (Exception)
            {
            }
            return View("Error");
        }

        /// <summary>
        /// 上传文件的action方法
        /// </summary>
        /// <param name="category">附件类别</param>
        /// <param name="recordID">记录ID</param>
        /// <param name="parentID">父记录ID(已弃用)</param>
        /// <returns>操作结果</returns>
        [HttpPost]
        public ActionResult Upload(string fileName, string category, string recordID, string parentID = "")
        {
            HttpPostedFileBase file = Request.Files["file"];

            if (string.IsNullOrEmpty(recordID))
            {
                throw new Exception("recordId不能为空");
            }

            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // var httpDirectory = string.Format("/{0}/{1}/", recordId, fjlb);
                    //用全角#替换半角#，避免下载、预览时出错
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.')).Replace("#", "＃") + Path.GetExtension(fileName).ToLower();

                    int chunk = Request.Params["chunk"] != null ? int.Parse(Request.Params["chunk"]) : 0;

                    var folderPath = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"Attachments\{0}\{1}", recordID, category);
                    var filePath = string.Format(@"{0}\{1}", folderPath, (object)fileName);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var uploadSuccess = fileUpload(file, filePath, chunk == 0);

                    if (uploadSuccess == false)
                    {
                        return Json(new { success = false, message = "保存文件失败，请联系管理员。" });
                    }

                    if (chunk == 0)
                    {
                        //获取排序号最大的附件，并把排序号+1作为新附件的排序号
                        var sortNumber = NH.Session.QueryOver<Sys_Attachment>().Where(x => x.RecordID == recordID && x.Category == category).List().Max(x => x.SortNumber);
                        sortNumber = sortNumber.HasValue ? sortNumber.Value + 1 : 1;
                        //初始化新附件信息
                        var entity = new Sys_Attachment()
                        {
                            Name = fileName.Replace("#", "＃").Replace("+", "＋"),
                            Path = string.Format("/Attachments/{0}/{1}/{2}", recordID, category, fileName),
                            FileType = Path.GetExtension(fileName).ToLower(),
                            IsDirectory = false,
                            Creator = User.Identity.Name,
                            CreateTime = DateTime.Now,
                            RecordID = recordID,
                            SortNumber = sortNumber,
                            ParentID = parentID,
                            Category = category
                        };
                        entity.Save();
                    }
                    return Json_Get(new { success = true });

                }
                catch (Exception)
                {
                    return Json_Get(new { success = false });
                }
            }
            else
            {
                throw new Exception("文件上传失败，请重新上传");
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">本地文件</param>
        /// <param name="ftpPath">ftp文件路径</param>
        /// <param name="ftpFileName">文件名</param>
        /// <param name="create">是否新建</param>
        /// <returns>操作结果</returns>
        public bool fileUpload(HttpPostedFileBase file, string filePath, bool create)
        {
            bool success = false;
            //FtpWebRequest ftpWebRequest = null;
            Stream localFileStream = null;
            Stream fileStream = null;
            try
            {
                //var uploadFile = System.IO.File.Open()
                //FtpCheckDirectoryExist(ftpPath);
                //string uri = FtpServer + ftpPath + "/" + ftpFileName;
                //ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                if (create)
                {
                    fileStream = System.IO.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
                }
                else
                {
                    fileStream = System.IO.File.Open(filePath, FileMode.Append, FileAccess.ReadWrite);
                }
                //ftpWebRequest.Credentials = new NetworkCredential(FtpUserID, FtpPassword);
                //ftpWebRequest.UseBinary = true;
                //ftpWebRequest.KeepAlive = false;
                //ftpWebRequest.ContentLength = file.ContentLength;
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                localFileStream = file.InputStream;
                //requestStream = ftpWebRequest.GetRequestStream();
                contentLen = localFileStream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    fileStream.Write(buff, 0, contentLen);
                    contentLen = localFileStream.Read(buff, 0, buffLength);
                }
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (localFileStream != null)
                {
                    localFileStream.Close();
                }
            }
            return success;
        }

        /// <summary>
        /// 得到当前指定业务所上传的附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetFuJianList(string Id, string tablename, string wjlxxf)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(Id))
            {
                if (wjlxxf == "undefined")
                {
                    wjlxxf = "";
                }
                Guid guid = new Guid(Id);
                List<NewsClassJson> list = new List<NewsClassJson>();

                if (tablename == "undefined")
                {
                    list = GridClassJson.LinqJsonTree(guid, "", wjlxxf, null);
                }
                else
                {
                    list = GridClassJson.LinqJsonTree(guid, tablename, wjlxxf, null);
                }

                //JavaScriptSerializer jss = new JavaScriptSerializer();
                //result = jss.Serialize(list);
                return new JsonResult() { Data = list };
            }
            else
            {
                return new JsonResult() { Data = new List<NewsClassJson>() };
            }
        }

        /// <summary>
        /// 文件夹列表
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fjlb"></param>
        /// <param name="wjlxxf"></param>
        /// <returns></returns>
        public ActionResult GetFolderList(string recordID, string category, string orders = "SortNumber")
        {
            if (string.IsNullOrEmpty(recordID))
            {
                return Json_Get(new List<string>());
            }
            var sql = string.Format("SELECT * FROM Sys_Attachment T WHERE T.IsDirectory=1 AND T.RecordID='{0}' AND T.Category='{1}'", recordID, category);
            var parentRecords = QueryService.GetData(sql + " AND (T.ParentID IS NULL OR T.ParentID='')", null, orders).Select(x => x as ExpandoObject).ToList();
            var allRecords = QueryService.GetData(sql, null, orders).Select(x => x as ExpandoObject).ToList();
            TreeHelper.FillChildren(ref parentRecords, allRecords, "ID", "ParentID", "Name");
            return Json_Get(parentRecords);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public override ActionResult DeleteEntities(string[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<Sys_Attachment>(id);
                    if (entity.Creator != User.Identity.Name && User.Identity.Name != "admin")
                    {
                        throw new DomainException(string.Format("您没有权限删除附件【{0}】！", entity.Name));
                    }
                    entity.Delete();
                }
            }
            catch (DomainException ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "删除失败" });
            }
            return Json(new { success = true, msg = "删除成功" });
        }

        //排序
        public ActionResult SortOrder(string id, string type)
        {
            try
            {
                var entity1 = NH.Session.Get<Sys_Attachment>(int.Parse(id));
                Sys_Attachment entity2 = null;
                if (type == "up")
                {
                    entity2 = NH.Session.QueryOver<Sys_Attachment>()
                            .Where(x => x.RecordID == entity1.RecordID && x.Category == entity1.Category && x.SortNumber < entity1.SortNumber)
                            .OrderBy(x => x.SortNumber).Desc
                            .List().FirstOrDefault();
                }
                else if (type == "down")
                {
                    entity2 = NH.Session.QueryOver<Sys_Attachment>()
                            .Where(x => x.RecordID == entity1.RecordID && x.Category == entity1.Category && x.SortNumber > entity1.SortNumber)
                            .OrderBy(x => x.SortNumber).Asc
                            .List().FirstOrDefault();
                }
                if (entity2 != null)
                {
                    var tempSortOrder = entity1.SortNumber;
                    entity1.SortNumber = entity2.SortNumber;
                    entity2.SortNumber = tempSortOrder;
                    entity1.Save();
                    entity2.Save();
                }
            }
            catch (DomainException ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "排序失败" });
            }
            return Json(new { success = true, msg = "排序成功" });
        }

        public ActionResult DownloadAll(string ids)
        {
            string zipFileName = Request.PhysicalApplicationPath + "TempFiles\\" + Guid.NewGuid().ToString() + ".zip";
            string downloadName = string.Empty;
            if (!Directory.Exists(Request.PhysicalApplicationPath + "TempFiles"))
            {
                Directory.CreateDirectory(Request.PhysicalApplicationPath + "TempFiles");
            }
            using (ZipArchive arc = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                string[] idsArray = ids.Split(',');
                foreach (var id in idsArray)
                {
                    var entity = NH.Session.Get<Sys_Attachment>(id);
                    if (!string.IsNullOrEmpty(entity.Path))
                    {
                        string fileName = entity.Name;
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = entity.Path.Split('/').Last();
                            fileName = entity.Path.Split('\\').Last();
                        }
                        downloadName = fileName;
                        var filePath = Request.PhysicalApplicationPath + entity.Path.TrimStart('/').Replace("/", "\\");
                        arc.CreateEntryFromFile(filePath, fileName);
                    }
                }
            }
            return File(zipFileName, "APPLICATION/OCTET-STREAM", HttpUtility.UrlEncode(downloadName + "等.zip", Encoding.GetEncoding("UTF-8")));
        }
    }


    public class NewsClassJson
    {
        /// <summary> 
        /// ID
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string text { get; set; }

        /// 子类
        /// </summary>
        public List<NewsClassJson> children { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string filePath { get; set; }

        /// <summary>
        /// 递归(得到支持commontree数的json数据)
        /// </summary>
        /// <param name="dxId">业务实体ID</param>
        /// <param name="parentId">树级展示ID</param>
        /// <returns></returns>
        public static List<NewsClassJson> LinqJsonTree(Guid dxId, string tablename, string wjlxxf, string parentId)
        {
            throw new Exception();
        }

        /// <summary>
        /// 查看
        /// </summary>
        public string CK { get; set; }


        /// <summary>
        /// checkBox
        /// </summary>
        public string checkBox { get; set; }

    }

    #region 构建Json数据源的数据格式(支持EasyUI GridTree)
    public class GridClassJson
    {
        /// <summary> 
        /// ID
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 子类
        /// </summary>
        public List<NewsClassJson> children { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 文件id
        /// </summary>
        public Guid Wjid { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string viewUrl { get; set; }
        /// <summary>
        /// 递归(得到支持gridtree数的json数据)
        /// </summary>
        /// <param name="dxId">业务项目ID</param>
        /// <param name="parentId">树级ID</param>
        /// <returns></returns>
        public static List<NewsClassJson> LinqJsonTree(Guid dxId, string tablename, string wjlxxf, string parentId)
        {
            throw new Exception();
        }

        /// <summary>
        /// 递归(得到支持gridtree数的json数据)
        /// </summary>
        public static List<NewsClassJson> LinqJsonGridTree(Guid xmguid, string lab, string parentId, Guid fjid)
        {
            throw new Exception();
        }
        public static void DelChildrenTreeFjb(string parentid)
        {
            throw new Exception();
        }
        #endregion
    }
}
