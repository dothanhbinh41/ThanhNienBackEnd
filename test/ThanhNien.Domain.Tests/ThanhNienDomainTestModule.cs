using ThanhNien.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienEntityFrameworkCoreTestModule)
        )]
    public class ThanhNienDomainTestModule : AbpModule
    {

    }
}