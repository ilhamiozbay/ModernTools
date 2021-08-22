using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RabbitMQ
{
    public interface IRabbitMQService
    {
        public bool Post(string channelName, object data);
    }
}
