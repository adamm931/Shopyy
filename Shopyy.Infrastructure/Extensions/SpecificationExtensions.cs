using MongoDB.Driver;
using Shopyy.Domain.Specification;
using Shopyy.Infrastructure.Specification;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Extensions
{
    public static class SpecificationExtensions
    {
        #region Queryable

        public static async Task<TEntity> SingleOrDefaultAsync<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
            => await Task.Run(() => query.ApplySpec(specification).SingleOrDefault());

        public static async Task<bool> AnyAsync<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
            => await Task.Run(() => query.ApplySpec(specification).Any());

        public static async Task<long> LongCountAsync<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
            => await Task.Run(() => query.ApplySpec(specification).LongCount());

        public static async Task<IQueryable<TEntity>> QueryAsync<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
            => await Task.Run(() => query.ApplySpec(specification));

        #endregion

        #region Mongo Queriable

        public static async Task<TEntity> SingleOrDefaultAsync<TEntity>(this IMongoCollection<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
            => await collection.AsQueryable().SingleOrDefaultAsync(specification);

        public static async Task<bool> AnyAsync<TEntity>(this IMongoCollection<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
            => await collection.AsQueryable().AnyAsync(specification);

        public static async Task<long> LongCountAsync<TEntity>(this IMongoCollection<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
            => await collection.AsQueryable().LongCountAsync(specification);

        public static async Task<IQueryable<TEntity>> QueryAsync<TEntity>(this IMongoCollection<TEntity> collection, ISpecification<TEntity> specification)
            where TEntity : class
            => await collection.AsQueryable().QueryAsync(specification);

        #endregion

        #region Private

        private static IQueryable<TEntity> ApplySpec<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : class
            => SqlSpecificationEvaluator<TEntity>.GetQuery(query, specification);

        #endregion
    }
}
