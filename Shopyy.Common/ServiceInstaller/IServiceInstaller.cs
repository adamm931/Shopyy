using Microsoft.Extensions.DependencyInjection;

namespace Shopyy.Common.ServiceInstaller
{
    public interface IServiceInstaller : IInstaller
    {
        void InstallService(IServiceCollection services);
    }
}
