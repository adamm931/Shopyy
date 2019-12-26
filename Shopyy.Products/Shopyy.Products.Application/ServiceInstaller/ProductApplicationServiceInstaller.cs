using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Common.ServiceInstaller;

namespace Shopyy.Products.Application.ServiceInstaller
{
    public class ProductApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddMediatR(typeof(ProductApplicationServiceInstaller).Assembly);
        }
    }
}
