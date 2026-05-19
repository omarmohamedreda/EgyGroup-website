using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers
{
    [Route("language")]
    public class LanguageController : Controller
    {
        [HttpGet("set/{culture}")]
        public IActionResult Set(string culture, string returnUrl = "/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}