using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Framework
{
    public class Column
    {
        public string field { get; set; }
        public string title { get; set; }
        public int width { get; set; }
        public bool? hidden { get; set; }
    }
}