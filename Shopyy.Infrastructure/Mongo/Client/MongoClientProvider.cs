using MongoDB.Driver;

namespace Shopyy.Infrastructure.Mongo.Client
{
    public class MongoClientProvider : IMongoClientProvider
    {
        private IMongoClient client;
        public IMongoClient Client => client ??= CreateClient();

        private IMongoClient CreateClient()
        {
            var connectionString = GetConnectionString();
            var monogUlr = new MongoUrl(connectionString);

            return new MongoClient(monogUlr);
        }

        private string GetConnectionString()
        {
            // TODO: Remove hardcoded value
            return "mongodb://192.168.99.100:27017";
        }
    }
}
