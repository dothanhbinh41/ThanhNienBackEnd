using System;
using System.Collections.Generic;
using System.Text;
using ThanhNien.Localization;
using Volo.Abp.Application.Services;

namespace ThanhNien
{
    /* Inherit your application services from this class.
     */
    public abstract class ThanhNienAppService : ApplicationService
    {
        protected ThanhNienAppService()
        {
            LocalizationResource = typeof(ThanhNienResource);
        }
    }
}
