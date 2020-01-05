using Shopyy.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopyy.Domain.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public Specification()
        {
            IncludeStrings = new List<string>();
            Includes = new List<Expression<Func<TEntity, object>>>();
            Criteria = _ => true;
        }

        public List<string> IncludeStrings { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; }

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        protected void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected void AddAnd(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = Criteria.And(criteria);
        }

        protected void AddOr(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = Criteria.Or(criteria);
        }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
