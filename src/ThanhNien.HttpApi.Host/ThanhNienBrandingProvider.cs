using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ThanhNien
{
    [Dependency(ReplaceServices = true)]
    public class ThanhNienBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ThanhNien";
    }
}
