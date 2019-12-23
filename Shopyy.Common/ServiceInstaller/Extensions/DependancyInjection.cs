using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopyy.Common.ServiceInstaller.Extensions
{
    public static class DependancyInjection
    {
        public static void AddInstallers(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] assemblyTypes)
        {
            var exportedTypes = assemblyTypes
                .SelectMany(asmType => asmType.Assembly.GetExportedTypes());

            GetInstallers<IConfigurabileServiceInstaller>(exportedTypes)
                .ForEach(installer => installer.InstallService(services, configuration));

            GetInstallers<IServiceInstaller>(exportedTypes)
                .ForEach(installer => installer.InstallService(services));
        }

        private static IEnumerable<TInstaller> GetInstallers<TInstaller>(IEnumerable<Type> exportedTypes)
            where TInstaller : IInstaller
        {
            return exportedTypes
                .Where(type => typeof(TInstaller).IsAssignableFrom(type))
                .Select(type => (TInstaller)Activator.CreateInstance(type));
        }
    }
}
