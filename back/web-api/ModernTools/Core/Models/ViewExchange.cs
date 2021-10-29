using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ViewExchange
    {
        public int ID { get; set; }
        public string ExchangeName { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ModDate { get; set; }
    }
}
