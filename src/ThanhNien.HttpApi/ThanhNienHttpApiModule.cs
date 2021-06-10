using Localization.Resources.AbpUi;
using ThanhNien.Localization; 
using Volo.Abp.Localization;
using Volo.Abp.Modularity; 
using Volo.Abp.SettingManagement; 

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienApplicationContractsModule), 
        typeof(AbpSettingManagementHttpApiModule)
        )]
    public class ThanhNienHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ThanhNienResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
