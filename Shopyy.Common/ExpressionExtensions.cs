using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shopyy.Common
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TObject, bool>> And<TObject>(this Expression<Func<TObject, bool>> left, Expression<Func<TObject, bool>> right)
        {
            var rightInvoked = Expression.Invoke(right, left.Parameters.Cast<Expression>());

            return Expression
                .Lambda<Func<TObject, bool>>(Expression.AndAlso(left.Body, rightInvoked), left.Parameters);
        }

        public static Expression<Func<TObject, bool>> Or<TObject>(this Expression<Func<TObject, bool>> left, Expression<Func<TObject, bool>> right)
        {
            var rightInvoked = Expression.Invoke(right, left.Parameters.Cast<Expression>());

            return Expression
                .Lambda<Func<TObject, bool>>(Expression.OrElse(left.Body, rightInvoked), left.Parameters);
        }
    }
}
