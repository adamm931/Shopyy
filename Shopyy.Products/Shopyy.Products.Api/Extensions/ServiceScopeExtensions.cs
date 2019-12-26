using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopyy.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Shopyy.Web.Extensions
{
    public static class ServiceScopeExtensions
    {
        public static async Task<IHost> Setup(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            await scope
                .ServiceProvider
                .GetRequiredService<ISeeder>()
                .SeedAsync();

            return host;
        }
    }
}
