using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.SettingManagement;

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienDomainSharedModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class ThanhNienApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            ThanhNienDtoExtensions.Configure();
        }
    }
}
