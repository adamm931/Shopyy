using MongoDB.Driver;

namespace Shopyy.Infrastructure.Mongo
{
    public interface IMongoDatabaseProvider
    {
        IMongoDatabase Database { get; }

        bool IsCreated { get; }
    }
}
