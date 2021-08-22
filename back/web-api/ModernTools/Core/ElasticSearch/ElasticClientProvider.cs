using Core.Models;
using Nest;
using System;
using MEO = Microsoft.Extensions.Options;

namespace Core.ElasticSearch
{
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
