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
    }
}
