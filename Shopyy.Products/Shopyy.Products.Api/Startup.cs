using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopyy.Common.ServiceInstaller.Extensions;
using Shopyy.Products.Infrastructure;
using Shopyy.Web.Extensions;

namespace Shopyy
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            Configuration = environment.BuildConfiguration();
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInstallers(Configuration, typeof(ProductsInfrastructureAssemblyReference));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
