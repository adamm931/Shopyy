using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Options;
using Shopyy.Infrastructure.Seed;
using Shopyy.Infrastructure.ServiceInstallers;
using Shopyy.Products.Application;
using Shopyy.Products.Infrastructure;
using Shopyy.Products.Infrastructure.Common;
using Shopyy.Products.Infrastructure.Options;
using Shopyy.Products.Infrastructure.Seed;

namespace Shopyy.Infrastructure.ServiceIntallers
{
    public class ProductsInfrastructureServiceInstaller : InfrastructureServiceInstaller<ProductsDbContext, ProductsSeeder>
    {
        public override void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            base.InstallService(services, configuration);

            services.AddScoped<IProductsAppContext, ProductsAppContext>();
            services.AddScoped<IEnumerationsProvider, EnumerationsProvider>();

            services.BindOptions<ProductsCatalogueDatabaseOptions>(
                configuration,
                AppSettings.ProductsCatalogueDatabaseOptions);

            services.BindOptions<SeedOptions>(
                configuration,
                CommonAppSettings.SeedOptions);
        }
    }
}
