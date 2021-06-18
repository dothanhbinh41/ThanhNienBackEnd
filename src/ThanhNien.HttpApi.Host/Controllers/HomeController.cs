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
            var json = "{\"issuer\":\"https://hcm-humg.edutalk.edu.vn\",\"jwks_uri\":\"https://hcm-humg.edutalk.edu.vn/.well-known/openid-configuration/jwks\",\"authorization_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/authorize\",\"token_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/token\",\"userinfo_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/userinfo\",\"end_session_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/endsession\",\"check_session_iframe\":\"https://hcm-humg.edutalk.edu.vn/connect/checksession\",\"revocation_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/revocation\",\"introspection_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/introspect\",\"device_authorization_endpoint\":\"https://hcm-humg.edutalk.edu.vn/connect/deviceauthorization\",\"frontchannel_logout_supported\":true,\"frontchannel_logout_session_supported\":true,\"backchannel_logout_supported\":true,\"backchannel_logout_session_supported\":true,\"scopes_supported\":[\"openid\",\"profile\",\"email\",\"address\",\"phone\",\"role\",\"Test\",\"offline_access\"],\"claims_supported\":[\"sub\",\"birthdate\",\"family_name\",\"gender\",\"given_name\",\"locale\",\"middle_name\",\"name\",\"nickname\",\"picture\",\"preferred_username\",\"profile\",\"updated_at\",\"website\",\"zoneinfo\",\"email\",\"email_verified\",\"address\",\"phone_number\",\"phone_number_verified\",\"role\"],\"grant_types_supported\":[\"authorization_code\",\"client_credentials\",\"refresh_token\",\"implicit\",\"password\",\"urn:ietf:params:oauth:grant-type:device_code\",\"LinkLogin\"],\"response_types_supported\":[\"code\",\"token\",\"id_token\",\"id_token token\",\"code id_token\",\"code token\",\"code id_token token\"],\"response_modes_supported\":[\"form_post\",\"query\",\"fragment\"],\"token_endpoint_auth_methods_supported\":[\"client_secret_basic\",\"client_secret_post\"],\"id_token_signing_alg_values_supported\":[\"RS256\"],\"subject_types_supported\":[\"public\"],\"code_challenge_methods_supported\":[\"plain\",\"S256\"],\"request_parameter_supported\":true}";
            return new ObjectResult(json);
        }
    }
}
