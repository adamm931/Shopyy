using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopyy.Application.Mapping;
using Shopyy.Common.Extensions;
using Shopyy.Common.ServiceInstaller;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Options;
using Shopyy.Products.Application.Services;
using Shopyy.Products.Domain.Interfacaes;

namespace Shopyy.Products.Application.ServiceInstaller
{
    public class ProductApplicationServiceInstaller : IConfigurabileServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISkuProvider, SkuProvider>();
            services.BindOptions<SkuOptions>(configuration, AppSettings.SkuOptions);

            services.AddMediatR(typeof(ProductApplicationServiceInstaller).Assembly);
            services.AddAutoMapper(
                typeof(ProductApplicationServiceInstaller).Assembly,
                typeof(CommonProfile).Assembly);

        }
    }
}
