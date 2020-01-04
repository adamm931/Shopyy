using MongoDB.Driver;
using Shoppy.Domain.Specification;
using Shopyy.Infrastructure.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Extensions
{
    public static class SpecificationExtensions
    {
        public static IQueryable<TEntity> ApplySql<TEntity>(this ISpecification<TEntity> specification, IQueryable<TEntity> query)
            where TEntity : class
        {
            return SqlSpecificationEvaluator<TEntity>.GetQuery(query, specification);
        }

        public static IQueryable<TEntity> ApplyNoSql<TEntity>(this ISpecification<TEntity> specification, IMongoCollection<TEntity> query)
            where TEntity : class
        {
            return SqlSpecificationEvaluator<TEntity>.GetQuery(query.AsQueryable(), specification);
        }

        public static async Task<TEntity> SingleOrDefaultAsync<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class
        {
            return await Task.Run(() => query.SingleOrDefault());
        }

        public static async Task<bool> AnyAsync<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class
        {
            return await Task.Run(() => query.Any());
        }

        public static async Task<long> LongCountAsync<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class
        {
            return await Task.Run(() => query.LongCount());
        }

        public static async Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class
        {
            return await Task.Run(() => query.ToList());
        }
    }
}
