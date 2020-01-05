using Microsoft.EntityFrameworkCore;
using Shopyy.Domain.Specification;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using Shopyy.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TEntity> FindAsync(TKey id) => await _table.FindAsync(id);

        public async Task<bool> AnyAsync(ISpecification<TEntity> specification) => await _table.AnyAsync(specification);

        public async Task<long> CountAsync(ISpecification<TEntity> specification) => await _table.LongCountAsync(specification);

        public async Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification) => await _table.SingleOrDefaultAsync(specification);

        public async Task<IQueryable<TEntity>> QueryAsync(ISpecification<TEntity> specification) => await _table.QueryAsync(specification);

        public void Delete(TKey id) => _table.Remove(_table.Find(id));

        public void Add(TEntity entity) => _table.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _table.AddRange(entities);

        public void Update(TEntity entity) => _table.Update(entity);
    }
}
