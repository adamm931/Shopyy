using Microsoft.EntityFrameworkCore;
using Shoppy.Domain.Specification;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using Shopyy.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Postgres
{
    public class EfRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbSet<TEntity> _table;

        public EfRepository(IDbTableProvider context, IUnitOfWork unitOfWork)
        {
            _table = context.Table<TKey, TEntity>();

            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            return await specification.ApplySql(_table)
                .AnyAsync();
        }

        public async Task<long> CountAsync(ISpecification<TEntity> specification)
        {
            return await specification.ApplySql(_table)
                .LongCountAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return await specification.ApplySql(_table)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(ISpecification<TEntity> specification)
        {
            return await specification.ApplySql(_table)
                .ToListAsync();
        }

        public void Delete(TKey id)
        {
            _table.Remove(_table.Find(id));
        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
