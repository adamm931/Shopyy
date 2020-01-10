using Shopyy.Domain;
using Shopyy.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Application.Abstractions.Repository
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> FindAsync(TKey id);

        Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification);

        Task<bool> AnyAsync(ISpecification<TEntity> specification);

        Task<long> CountAsync(ISpecification<TEntity> specification);

        Task<IQueryable<TEntity>> QueryAsync(ISpecification<TEntity> specification = null);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        IUnitOfWork UnitOfWork { get; }
    }

    public interface IRepository<TEntity> : IRepository<Guid, TEntity>
        where TEntity : class, IEntity
    {
    }
}
