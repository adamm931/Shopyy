using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace Shopyy.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> Column<TEntity, TProperty>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TProperty>> propertySelector,
            string columnName)

            where TEntity : class
        {
            builder.Property(propertySelector).HasColumnName(columnName);

            return builder;
        }
    }
}
