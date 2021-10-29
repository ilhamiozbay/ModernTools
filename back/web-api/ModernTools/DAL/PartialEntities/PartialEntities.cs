using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.PartialEntities
{
    public class PartialEntities
    {
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product : BaseEntity, IAuditable { }
    public partial class ExchangeType : BaseEntity { }

    public class ProductMetadata
    {
        [CryptoData(id = 34)]
        public string SeriNo { get; set; }
    }
}
