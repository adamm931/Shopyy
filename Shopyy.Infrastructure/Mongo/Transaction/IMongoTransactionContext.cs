using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Mongo.Transaction
{
    public interface IMongoTransactionContext
    {
        void AddCommand(TransactionCommand command);

        Task CommitAsync();
    }
}
