using Shopyy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopyy.Application.Abstractions.Repository
{
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        Task<TEntity> FindAsync(TKey id);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        IUnitOfWork UnitOfWork { get; }
    }
}
