using Shopyy.Application.Abstractions.Repository;

namespace Shopyy.Infrastructure.Mongo.Transaction
{
    public interface IMongoTransactionContext : IUnitOfWork
    {
        void AddCommand(TransactionCommand command);
    }
}
