using System;
using System.Collections.Generic;

namespace DAL.PartialEntities
{
    
    [AttributeUsage(AttributeTargets.All)]
    public class CryptoData : System.Attribute
    {
        public CryptoData()
        {

        }

        public int id { get; set; }
    }
}
