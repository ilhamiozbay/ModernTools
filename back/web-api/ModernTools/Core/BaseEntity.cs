using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class BaseEntity
    {
        //private DateTime dateTime;
        //[NotMapped]
        //public DateTime UsedTime { get { this.dateTime = DateTime.Now; return dateTime; } set { } }
        [NotMapped]
        public DateTime UsedTime => DateTime.Now;
    }
}
