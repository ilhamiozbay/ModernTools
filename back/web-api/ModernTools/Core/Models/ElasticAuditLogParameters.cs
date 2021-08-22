using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ElasticAuditLogParameters : ElasticQueryParameters
    {
        public string ClassName { get; set; } = "";
        public string Operation { get; set; } = "Update";
        public string Content { get; set; } = "";
    }
}
