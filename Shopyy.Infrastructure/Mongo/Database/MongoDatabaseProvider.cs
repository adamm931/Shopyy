using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shopyy.Infrastructure.Mongo.Client;
using Shopyy.Infrastructure.Mongo.Database;
using System;
using System.Linq;

namespace Shopyy.Infrastructure.Mongo
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        private readonly IMongoClient _client;
        private readonly DatabaseOptions _databaseOptions;

        public MongoDatabaseProvider(
            IMongoClientProvider clientProvider,
            IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
            _client = clientProvider.Client;

            Database = _client.GetDatabase(_databaseOptions.Name);
        }

        public IMongoDatabase Database { get; }

        private bool? _isCreated;
        public bool IsCreated => _isCreated ??= HasDatabaseName();

        private bool HasDatabaseName()
        {
            var cursor = _client.ListDatabaseNames();

            while (cursor.MoveNext())
            {
                if (cursor.Current.Contains(_databaseOptions.Name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
