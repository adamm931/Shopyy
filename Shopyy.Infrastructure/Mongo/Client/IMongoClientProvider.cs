using MongoDB.Driver;

namespace Shopyy.Infrastructure.Mongo.Client
{
    public interface IMongoClientProvider
    {
        IMongoClient Client { get; }
    }
}
