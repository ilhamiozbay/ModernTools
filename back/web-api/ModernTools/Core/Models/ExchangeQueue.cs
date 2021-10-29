using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public enum ExchangeParseType
    {
        DOLAR=1,
        EURO=2,
        STERLIN=3,
        
        [Display(Name="GRAM ALTIN")]
        GRAM_ALTIN=4
    }

    public class ExchangeQueue
    {
        public decimal? Price { get; set; }
        public string Name { get; set; }
        public int? ExchangeType { get; set; }
        public string ExchangeName { get; set; }
        public int ProductID { get; set; }
        public decimal? TrPrice { get; set; }
        public decimal? ExchangeValue { get; set; }
        public string ConnectionID { get; set; }
        public int? TotalCount { get; set; }
        public string SeriNo { get; set; }
    }
}
