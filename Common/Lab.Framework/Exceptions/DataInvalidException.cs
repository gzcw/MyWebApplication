using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    /// <summary>
    /// 数据不合法异常
    /// </summary>
    public class DataInvalidException : Exception
    {
        private string _message = string.Empty;

        public DataInvalidException(string message)
        {
            this._message = message;

        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}