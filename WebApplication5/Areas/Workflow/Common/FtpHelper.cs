using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HR.Workflow.Common
{
    /// <summary>
    /// Ftp帮助类
    /// </summary>
    public class FtpHelper
    {
        /// <summary>
        /// Ftp服务器配置
        /// </summary>
        public static string FtpServer = ConfigurationManager.AppSettings["FtpServer"];
        /// <summary>
        /// Ftp服务器对应的http路径
        /// </summary>
        public static string FtpServerHttp = ConfigurationManager.AppSettings["FtpServerHttp"];
        /// <summary>
        /// Ftp用户名称
        /// </summary>
        public static string FtpUserID = ConfigurationManager.AppSettings["FtpUserID"];
        /// <summary>
        /// Ftp密码
        /// </summary>
        public static string FtpPassword = ConfigurationManager.AppSettings["FtpPassword"];

        /// <summary>
        /// 上传文件至ftp服务器
        /// </summary>
        /// <param name="localFile">本地文件</param>
        /// <param name="path">ftp文件路径</param>
        /// <param name="ftpFileName">文件名</param>
        /// <param name="create">是否新建</param>
        /// <returns>操作结果</returns>
        public static string fileUpload(MemoryStream localFile, string path, string ftpFileName, bool create)
        {
            bool success = false;
            FtpWebRequest ftpWebRequest = null;
            Stream localFileStream = null;
            Stream requestStream = null;
            try
            {
                FtpCheckDirectoryExist(path);
                string uri = FtpServer + path + "/" + ftpFileName;
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                if (create)
                {
                    ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                }
                else
                {
                    ftpWebRequest.Method = WebRequestMethods.Ftp.AppendFile;
                }
                ftpWebRequest.Credentials = new NetworkCredential(FtpUserID, FtpPassword);
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.ContentLength = localFile.Length;
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                localFileStream = localFile;
                requestStream = ftpWebRequest.GetRequestStream();
                contentLen = localFileStream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    requestStream.Write(buff, 0, contentLen);
                    contentLen = localFileStream.Read(buff, 0, buffLength);
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
                if (localFileStream != null)
                {
                    localFileStream.Close();
                }
            }
            return string.Format("{0}{1}/{2}", FtpServerHttp, path, ftpFileName);
        }

        /// <summary>
        /// 判断目录是否存在，没有则创建
        /// </summary>
        /// <param name="destFilePath">目标文件路径</param>
        public static void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = destFilePath;
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(FtpServer + curDir, FtpUserID, FtpPassword);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <param name="ftpUserID">用户名</param>
        /// <param name="ftpPassword">用户密码</param>
        /// <returns>操作成功与否</returns>
        public static Boolean FtpMakeDir(string directory, string ftpUserID, string ftpPassword)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(directory);
            req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }

        /// <summary>
        /// 转换特殊符号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>转换后的字符串</returns>
        public static string To16(string name)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in name.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 16));
            }
            return sb.ToString();
        }
    }
}