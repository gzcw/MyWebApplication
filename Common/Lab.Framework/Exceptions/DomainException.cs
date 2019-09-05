using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    public class DomainException : Exception
    {
        private string _message = string.Empty;

        public DomainException(string message)
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