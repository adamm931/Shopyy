using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Common.ServiceInstaller;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Mongo;
using Shopyy.Infrastructure.Mongo.Client;
using Shopyy.Infrastructure.Mongo.Database;
using Shopyy.Infrastructure.Mongo.Transaction;
using Shopyy.Infrastructure.Persistance;
using Shopyy.Infrastructure.Seed;

namespace Shopyy.Infrastructure.ServiceIntallers
{
    public class InfrastructureServiceInstaller : IConfigurabileServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // transient
            services.AddTransient<ISeeder, Seeder>();
            services.AddTransient<IMongoDatabaseProvider, MongoDatabaseProvider>();
            services.AddTransient<IMongoClientProvider, MongoClientProvider>();

            // scoped
            services.AddScoped<IMongoTransactionContext, MongoTransactionContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

            // options
            services.Configure<DatabaseOptions>(options => configuration
                .GetSection(AppSettings.MongoDatabaseOptions)
                .Bind(options));
        }
    }
}
