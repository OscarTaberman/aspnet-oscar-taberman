using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers
{
    public class AccountController : Controller
    {
        [Route("account")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
