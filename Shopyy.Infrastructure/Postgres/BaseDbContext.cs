using Microsoft.EntityFrameworkCore;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Seed;
using System;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Postgres
{
    public class BaseDbContext : DbContext, IUnitOfWork, IDatabaseCreator, IDbTableProvider, IEnumerationsSeeder
    {
        private readonly IEnumerationsProvider _enumerationsProvider;

        public BaseDbContext(IEnumerationsProvider enumerationsProvider)
        {
            _enumerationsProvider = enumerationsProvider;
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public async Task<bool> CreateAsync(bool recreate = false)
        {
            if (recreate)
            {
                await Database.EnsureDeletedAsync();
            }

            return await Database.EnsureCreatedAsync();
        }

        public DbSet<TEntity> Table<TKey, TEntity>() where TEntity : class, IEntity<TKey>
        {
            return Set<TEntity>();
        }

        public void SeedEnumerations()
        {
            var enumerations = _enumerationsProvider.GetEnumerationsDescriptor();

            foreach (var enumerationPair in enumerations)
            {
                foreach (var enumValue in Enum.GetValues(enumerationPair.Key))
                {
                    var enumEntityType = enumerationPair.Value;
                    this.AddToSet(enumerationPair.Value, Activator.CreateInstance(enumEntityType, enumValue));
                }
            }
        }
    }
}
