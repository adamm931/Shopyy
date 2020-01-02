using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Shopyy.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        private static readonly MethodInfo SetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set));

        public static void AddToSet(this DbContext context, Type setType, object entity)
        {
            var set = SetMethod
              .MakeGenericMethod(setType)
              .Invoke(context, null);

            var addMethod = set.GetType().GetMethod("Add");

            addMethod.Invoke(set, new[] { entity });
        }
    }
}
