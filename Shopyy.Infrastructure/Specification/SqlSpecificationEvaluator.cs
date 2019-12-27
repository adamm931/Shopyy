using Microsoft.EntityFrameworkCore;
using Shoppy.Domain.Specification;
using System.Linq;

namespace Shopyy.Infrastructure.Specification
{
    public class SqlSpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> input, ISpecification<TEntity> specification)
        {
            var query = input;

            query = specification.IncludeStrings
                .Aggregate(query, (current, next) => current.Include(next));

            query = specification.Includes
                .Aggregate(query, (current, next) => current.Include(next));

            query = query.Where(specification.Criteria);

            return query;
        }
    }
}
