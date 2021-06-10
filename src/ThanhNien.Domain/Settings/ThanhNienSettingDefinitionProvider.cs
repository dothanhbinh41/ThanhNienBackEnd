using Volo.Abp.Settings;

namespace ThanhNien.Settings
{
    public class ThanhNienSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ThanhNienSettings.MySetting1));
        }
    }
}
