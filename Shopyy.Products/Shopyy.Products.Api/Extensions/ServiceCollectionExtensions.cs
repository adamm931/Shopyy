using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Common.ServiceInstaller.Extensions;
using Shopyy.Products.Application;
using Shopyy.Products.Infrastructure;

namespace Shopyy.ProductsCatalogue.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInstallers(
                configuration,
                typeof(ProductsInfrastructureAssemblyReference),
                typeof(ProductsApplicationAssemblyReference));
        }
    }
}
