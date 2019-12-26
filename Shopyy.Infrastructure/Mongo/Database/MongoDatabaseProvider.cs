using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Mongo.Client;
using Shopyy.Infrastructure.Mongo.Database;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Mongo
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider, IDatabaseCreator
    {
        private readonly IMongoClient _client;
        private readonly MongoDatabaseOptions _databaseOptions;

        public MongoDatabaseProvider(
            IMongoClientProvider clientProvider,
            IOptions<MongoDatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
            _client = clientProvider.Client;
        }

        public IMongoDatabase Database => _client.GetDatabase(_databaseOptions.Name);

        private async Task<bool> HasDatabaseName()
        {
            var cursor = await _client.ListDatabaseNamesAsync();

            while (await cursor.MoveNextAsync())
            {
                if (cursor.Current.Contains(_databaseOptions.Name))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> CreateAsync()
        {
            var databaseExists = await HasDatabaseName();

            if (databaseExists)
            {
                return false;
            }

            // this will initialize database when called first time
            _client.GetDatabase(_databaseOptions.Name);

            return true;
        }
    }
}
