using ThanhNien.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ThanhNien.Permissions
{
    public class ThanhNienPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ThanhNienPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ThanhNienPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ThanhNienResource>(name);
        }
    }
}
