using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers
{
    public class AccountController : Controller
    {
        [Route("account/register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("account/signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("account/setpassword")]
        public IActionResult SetPassword()
        {
            return View();
        }
    }
}
