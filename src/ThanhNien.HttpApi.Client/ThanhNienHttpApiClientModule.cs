using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienApplicationContractsModule),
        typeof(AbpSettingManagementHttpApiClientModule)
    )]
    public class ThanhNienHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ThanhNienApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
