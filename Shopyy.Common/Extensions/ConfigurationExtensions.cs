using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shopyy.Common.Extensions
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
    }
}
