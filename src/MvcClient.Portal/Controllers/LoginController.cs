using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Portal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" },
                Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}