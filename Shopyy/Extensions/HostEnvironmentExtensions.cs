using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shopyy.Web.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static IConfiguration BuildConfiguration(this IHostEnvironment enviroment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(enviroment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{enviroment.EnvironmentName}.json", optional: true)
                .Build();
        }
    }
}
