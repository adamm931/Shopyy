using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shopyy.Web.Extensions;
using System.Threading.Tasks;

namespace Shopyy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = await CreateHostBuilder(args)
                .Build()
                .Setup();

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
