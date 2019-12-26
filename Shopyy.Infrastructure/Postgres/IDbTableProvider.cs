using Microsoft.EntityFrameworkCore;
using Shopyy.Domain;

namespace Shopyy.Infrastructure.Postgres
{
    public interface IDbTableProvider
    {
        DbSet<TEntity> Table<TKey, TEntity>() where TEntity : class, IEntity<TKey>;
    }
}
