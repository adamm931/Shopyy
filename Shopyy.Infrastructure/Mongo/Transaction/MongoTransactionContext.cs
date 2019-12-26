using MongoDB.Driver;
using Shopyy.Infrastructure.Mongo.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Mongo.Transaction
{
    public class MongoTransactionContext : IMongoTransactionContext
    {
        private readonly ICollection<TransactionCommand> _commands;
        private readonly IMongoClient _client;

        public MongoTransactionContext(IMongoClientProvider clientProvider)
        {
            _client = clientProvider.Client;
            _commands = new List<TransactionCommand>();
        }

        public void AddCommand(TransactionCommand command)
        {
            _commands.Add(command);
        }

        public async Task SaveAsync()
        {
            if (!_commands.Any())
            {
                return;
            }

            using var session = await _client.StartSessionAsync();

            session.StartTransaction();

            await Task.WhenAll(_commands.Select(command => command.Execute()));

            await session.CommitTransactionAsync();

            _commands.Clear();
        }
    }
}
