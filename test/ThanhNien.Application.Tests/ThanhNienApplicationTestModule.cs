using Volo.Abp.Modularity;

namespace ThanhNien
{
    [DependsOn(
        typeof(ThanhNienApplicationModule),
        typeof(ThanhNienDomainTestModule)
        )]
    public class ThanhNienApplicationTestModule : AbpModule
    {

    }
}