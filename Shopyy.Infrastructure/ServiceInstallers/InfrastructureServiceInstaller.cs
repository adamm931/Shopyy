using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Common.ServiceInstaller;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Postgres;

namespace Shopyy.Infrastructure.ServiceInstallers
{
    public class InfrastructureServiceInstaller<TDbContext, TSeeder> : IConfigurabileServiceInstaller
        where TDbContext : BaseDbContext
        where TSeeder : class, ISeeder
    {
        public virtual void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // db context
            services.AddDbContext<TDbContext>();

            // transient


            // services.AddTransient<IMongoDatabaseProvider, MongoDatabaseProvider>();
            // services.AddTransient<IMongoClientProvider, MongoClientProvider>();

            // scoped
            services.AddScoped<IDatabaseCreator>(service => service.GetRequiredService<TDbContext>());
            services.AddScoped<IDbTableProvider>(service => service.GetRequiredService<TDbContext>());
            services.AddScoped<ISeeder, TSeeder>();
            services.AddScoped<IUnitOfWork>(service => service.GetRequiredService<TDbContext>());
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

            // services.AddScoped<IMongoTransactionContext, MongoTransactionContext>();
            // services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

            // options
            //services.Configure<MongoDatabaseOptions>(options => configuration
            //    .GetSection(AppSettings.MongoDatabaseOptions)
            //    .Bind(options));

            //services.Configure<ProductsCatalogueDatabaseOptions>(options => configuration
            //    .GetSection(AppSettings.ProductsCatalogueDatabaseOptions)
            //    .Bind(options));
        }
    }
}
