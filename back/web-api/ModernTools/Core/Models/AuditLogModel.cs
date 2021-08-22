using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AuditLogModel
    {
        public int UserID { get; set; }
        public string JsonModel { get; set; }
        public string ClassName { get; set; }
        public string Operation { get; set; }
        public DateTime PostDate { get; set; }
    }
}
