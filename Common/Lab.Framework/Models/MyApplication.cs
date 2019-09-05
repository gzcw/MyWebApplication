using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    public class MyApplication
    {
        private static string _ScriptVersion;
        public static string ScriptVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_ScriptVersion))
                {
                    _ScriptVersion = Guid.NewGuid().ToString();
                }
                return _ScriptVersion;
            }
        }
    }
}