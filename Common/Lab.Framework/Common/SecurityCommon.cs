using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace Lab.Framework
{
    public class SecurityCommon
    {
        /// <summary>
        /// 使指定名称的哈希算法加密给定的字符串
        /// </summary>
        /// <param name="source">给定的待加密字符串</param>
        /// <param name="hashName">用于加密的哈希算法名称(例如：SHA、SHA1、MD5、SHA256、SHA384、SHA512等等)</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string source, string hashName)
        {
            byte[] buffer = HashAlgorithm.Create(hashName).ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer)
            {
                builder.Append(num.ToString("X2"));
            }
            return builder.ToString().ToUpper();
        }
    }
}