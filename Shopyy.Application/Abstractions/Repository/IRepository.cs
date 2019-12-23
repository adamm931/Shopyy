using Shopyy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopyy.Application.Abstractions.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IEntity, IAggregateRoot
    {
        Task<TEntity> FindAsync(Guid id);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Delete(Guid id);
    }
}
