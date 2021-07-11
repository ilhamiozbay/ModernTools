using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class BaseEntity
    {
        private DateTime _dateTime;

        [NotMapped]
        public DateTime UsedTime { get {
                _dateTime = DateTime.Now;
                return _dateTime;
            } set { } }
    }
}
