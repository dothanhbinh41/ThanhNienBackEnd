using ThanhNien.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ThanhNien.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ThanhNienController : AbpController
    {
        protected ThanhNienController()
        {
            LocalizationResource = typeof(ThanhNienResource);
        }
    }
}