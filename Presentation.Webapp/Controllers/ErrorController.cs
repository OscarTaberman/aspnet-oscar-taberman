using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers;

public class ErrorController : Controller
{
    [Route("404")]
    public IActionResult Index()
    {
        return View("404");
    }
}
