using MongoDB.Driver;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using Shopyy.Infrastructure.Mongo;
using Shopyy.Infrastructure.Mongo.Transaction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Persistance
{
    public class MongoRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>// , IAggregateRoot
    {
        private readonly IMongoTransactionContext _transaction;
        private readonly IMongoDatabaseProvider _databaseProvider;

        private IMongoCollection<TEntity> _collection;
        private IMongoCollection<TEntity> Collection
            => _collection ??= (_databaseProvider
                .Database
                .GetCollection<TEntity>(typeof(TEntity).Name));

        public IUnitOfWork UnitOfWork { get; }

        public MongoRepository(
            IMongoTransactionContext transaction,
            IUnitOfWork unitOfWork,
            IMongoDatabaseProvider databaseProvider)
        {
            _transaction = transaction;
            _databaseProvider = databaseProvider;

            UnitOfWork = unitOfWork;
        }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return (await Collection.FindAsync(entity => entity.Id.Equals(id))).SingleOrDefault();
        }

        public void Add(TEntity entity)
        {
            var command = (TransactionCommand)(() => Collection.InsertOneAsync(entity));
            _transaction.AddCommand(command);
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            var command = (TransactionCommand)(() => Collection.InsertManyAsync(entity));
            _transaction.AddCommand(command);
        }

        public void Delete(TKey id)
        {
            var command = (TransactionCommand)(() => Collection.DeleteOneAsync(entity => entity.Id.Equals(id)));
            _transaction.AddCommand(command);
        }

        public void Update(TEntity entity)
        {
            var command = (TransactionCommand)(() => Collection.ReplaceOneAsync(document => document.Id.Equals(entity.Id), entity));
            _transaction.AddCommand(command);
        }
    }
}
