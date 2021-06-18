using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ThanhNien.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return new ObjectResult("");
        }


        [Route("/.well-known/openid-configuration")]
        public ActionResult FixError()
        {
            return new ObjectResult("");
        }
    }
}
