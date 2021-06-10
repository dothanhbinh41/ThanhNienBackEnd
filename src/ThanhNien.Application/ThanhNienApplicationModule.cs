using Volo.Abp.AutoMapper; 
using Volo.Abp.Identity;
using Volo.Abp.Modularity; 
using Volo.Abp.SettingManagement; 

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienDomainModule), 
        typeof(ThanhNienApplicationContractsModule), 
        typeof(AbpSettingManagementApplicationModule)
        )]
    public class ThanhNienApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ThanhNienApplicationModule>();
            });
        }
    }
}
