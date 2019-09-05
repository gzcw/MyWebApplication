using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    public class LoginOffException : Exception
    {
        private string _message = string.Empty;

        public LoginOffException(string message)
        {
            this._message = message;
        }
        public LoginOffException()
        {
            this._message = "请重新登陆！";
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