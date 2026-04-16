using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        [HttpGet]
        [Route("profile")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("profile")]
        public IActionResult UpdateProfile()
        {
            return RedirectToAction("Index");
        }
    }
}
