﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopyy.Domain.Specification
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Criteria { get; }

        List<string> IncludeStrings { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

    }
}
