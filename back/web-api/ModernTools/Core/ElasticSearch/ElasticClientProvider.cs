using Core.Models;
using Nest;
using System;
using MEO = Microsoft.Extensions.Options;

namespace Core.ElasticSearch
{
    //ElasticSearch Client'ın Index'den bağımsız 1 seferlik Singelton ayağa kaldırıldığı sınıf. 
    //Startup.cs=> services.AddSingleton<ElasticClientProvider>();
    public class ElasticClientProvider
    {
        public ElasticClient ElasticClient { get; }
        public string ElasticSearchHost { get; set; }

        public ElasticClientProvider(MEO.IOptions<ElasticConnectionSettings> elasticConfig)
        {
            ElasticSearchHost = elasticConfig.Value.SearchHost;
            ElasticClient = CreateClient();
        }

        private ElasticClient CreateClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .DisableDirectStreaming(true)
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false);
                //.MaxRetryTimeout(TimeSpan.FromMilliseconds(1000))
                //.MaximumRetries(2)
                //.RequestTimeout(TimeSpan.FromMilliseconds(1000))

            return new ElasticClient(connectionSettings);
        }

        //Bu method ile Index ile ElasticClient ayağa kaldırılır.
        private ElasticClient CreateClientWithIndex(string defaultIndex)
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false)
                .DefaultIndex(defaultIndex);

            return new ElasticClient(connectionSettings);
        }
    }
}
