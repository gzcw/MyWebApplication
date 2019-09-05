using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    public class PagedResult
    {
        public long total { get; set; }
        public IEnumerable<dynamic> rows { get; set; }
    }
}