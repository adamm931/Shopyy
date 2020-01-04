using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Common.ServiceInstaller;
using Shopyy.Products.Application.Services;
using Shopyy.Products.Domain.Interfacaes;

namespace Shopyy.Products.Application.ServiceInstaller
{
    public class ProductApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddScoped<ISkuProvider, SkuProvider>();

            services.AddMediatR(typeof(ProductApplicationServiceInstaller).Assembly);
            services.AddAutoMapper(typeof(ProductApplicationServiceInstaller).Assembly);
        }
    }
}
