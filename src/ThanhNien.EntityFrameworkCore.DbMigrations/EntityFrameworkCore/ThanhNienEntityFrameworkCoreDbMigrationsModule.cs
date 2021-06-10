using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ThanhNien.EntityFrameworkCore
{
    [DependsOn(
        typeof(ThanhNienEntityFrameworkCoreModule)
        )]
    public class ThanhNienEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ThanhNienMigrationsDbContext>();
        }
    }
}
