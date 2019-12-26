using Microsoft.EntityFrameworkCore;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Postgres
{
    public class PostgresRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbSet<TEntity> _table;

        public PostgresRepository(IDbTableProvider context, IUnitOfWork unitOfWork)
        {
            _table = context.Table<TKey, TEntity>();
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public void Delete(TKey id)
        {
            _table.Remove(_table.Find(id));
        }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _table.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
