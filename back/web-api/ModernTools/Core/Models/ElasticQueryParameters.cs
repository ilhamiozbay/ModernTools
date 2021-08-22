using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ElasticQueryParameters
    {
        public int? UserId { get; set; }
        public DateTime? BeginDate { get; set; } = DateTime.Parse("1900-01-01");
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public int Page { get; set; } = 0;
        public int RowCount { get; set; } = 10;
    }
}
