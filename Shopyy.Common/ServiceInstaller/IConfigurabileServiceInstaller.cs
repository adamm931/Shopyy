using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shopyy.Common.ServiceInstaller
{
    public interface IConfigurabileServiceInstaller : IInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
