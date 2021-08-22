using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ElasticConnectionSettings
    {
        public string SearchHost { get; set; }
        public string LoginIndex { get; set; }
        public string ErrorIndex { get; set; }
        public string AuditIndex { get; set; }
    }
}
