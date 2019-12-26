using Microsoft.EntityFrameworkCore;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using Shopyy.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Postgres
{
    public class BaseDbContext : DbContext, IUnitOfWork, IDatabaseCreator, IDbTableProvider
    {
        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public async Task<bool> CreateAsync()
        {
            return await Database.EnsureCreatedAsync();
        }

        public DbSet<TEntity> Table<TKey, TEntity>() where TEntity : class, IEntity<TKey>
        {
            return Set<TEntity>();
        }
    }
}
