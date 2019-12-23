using MongoDB.Driver;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain.Interfaces;
using Shopyy.Infrastructure.Mongo;
using Shopyy.Infrastructure.Mongo.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Persistance
{
    public class MongoRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity, IAggregateRoot
    {
        private readonly IMongoTransactionContext _transaction;
        private readonly IMongoDatabaseProvider _databaseProvider;

        private IMongoCollection<TEntity> _collection;
        private IMongoCollection<TEntity> Collection
            => _collection ??= (_databaseProvider
                .Database
                .GetCollection<TEntity>(typeof(TEntity).Name));

        public MongoRepository(
            IMongoTransactionContext transaction,
            IMongoDatabaseProvider databaseProvider)
        {
            _transaction = transaction;
            _databaseProvider = databaseProvider;
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return (await Collection.FindAsync(entity => entity.Id == id)).SingleOrDefault();
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

        public void Delete(Guid id)
        {
            var command = (TransactionCommand)(() => Collection.DeleteOneAsync(entity => entity.Id == id));
            _transaction.AddCommand(command);
        }

        public void Update(TEntity entity)
        {
            var command = (TransactionCommand)(() => Collection.ReplaceOneAsync(document => document.Id == entity.Id, entity));
            _transaction.AddCommand(command);
        }
    }
}
