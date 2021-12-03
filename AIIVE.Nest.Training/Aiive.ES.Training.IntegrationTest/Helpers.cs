
using Nest;
using System;

namespace Aiive.Nest.Training.IntegrationTest
{
    internal class Helpers
    {
        public ElasticClient CreateElasticClient(string index)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex(index);

            var client = new ElasticClient(settings);
            
            return client;
        }
    }
}
