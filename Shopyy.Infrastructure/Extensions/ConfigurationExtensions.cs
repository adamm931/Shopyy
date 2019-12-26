using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace Shopyy.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void BindOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string key)
            where TOptions : class
        {
            services.Configure<TOptions>(options => configuration
                .GetSection(key)
                .Bind(options));
        }

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
