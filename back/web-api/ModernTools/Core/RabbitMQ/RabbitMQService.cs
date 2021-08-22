using Core.Models;
using MEO = Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public readonly MEO.IOptions<ModernToolsConfig> _modernToolsConfig;
        public RabbitMQService(MEO.IOptions<ModernToolsConfig> modernToolsConfig)
        {
            _modernToolsConfig = modernToolsConfig;
        }

        public bool Post(string channelName, object data)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = _modernToolsConfig.Value.RabbitMqHostname };

                using (IConnection connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: channelName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
                        string message = JsonConvert.SerializeObject(data);
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                            routingKey: channelName,
                            basicProperties: null,
                            body: body);
                        Console.WriteLine($"Sent Object: {JSON.stringify(data)}");
                        //Console.WriteLine($"Sent Object: {JsonConvert.SerializeObject(data)}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
