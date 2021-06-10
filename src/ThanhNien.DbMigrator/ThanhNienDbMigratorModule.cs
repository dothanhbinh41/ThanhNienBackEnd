using ThanhNien.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ThanhNien.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ThanhNienEntityFrameworkCoreDbMigrationsModule),
        typeof(ThanhNienApplicationContractsModule)
        )]
    public class ThanhNienDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
