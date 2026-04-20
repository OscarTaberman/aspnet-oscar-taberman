using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers;

public class MembershipController : Controller
{
    [Route("membership")]
    public IActionResult Index()
    {
        return View();
    }
}
