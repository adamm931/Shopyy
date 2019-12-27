using Shoppy.Domain.Specification;
using Shopyy.Domain;
using System.Collections.Generic;
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

        Task<IEnumerable<TEntity>> FilterAsync(ISpecification<TEntity> specification = null);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        IUnitOfWork UnitOfWork { get; }
    }
}
