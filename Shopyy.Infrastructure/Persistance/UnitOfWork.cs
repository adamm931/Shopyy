using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain.Entities;
using Shopyy.Infrastructure.Mongo.Transaction;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoTransactionContext _context;

        public UnitOfWork(
            IRepository<Product> products,
            IMongoTransactionContext context)
        {
            Products = products;

            _context = context;
        }

        public IRepository<Product> Products { get; }

        public async Task SaveChangesAsync()
        {
            await _context.CommitAsync();
        }
    }
}
