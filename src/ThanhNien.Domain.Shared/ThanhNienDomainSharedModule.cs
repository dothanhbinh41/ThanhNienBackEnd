using ThanhNien.Localization;
using Volo.Abp.AuditLogging;
//using Volo.Abp.BackgroundJobs; 
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity; 
using Volo.Abp.SettingManagement; 
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ThanhNien
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
      //  typeof(AbpBackgroundJobsDomainSharedModule), 
        typeof(AbpIdentityServerDomainSharedModule), 
        typeof(AbpSettingManagementDomainSharedModule)
        )]
    public class ThanhNienDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            ThanhNienGlobalFeatureConfigurator.Configure();
            ThanhNienModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ThanhNienDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ThanhNienResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ThanhNien");

                options.DefaultResourceType = typeof(ThanhNienResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ThanhNien", typeof(ThanhNienResource));
            });
        }
    }
}
