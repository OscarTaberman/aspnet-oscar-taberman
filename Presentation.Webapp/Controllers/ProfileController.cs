using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers
{
    public class ProfileController : Controller
    {
        [Route("profile")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
