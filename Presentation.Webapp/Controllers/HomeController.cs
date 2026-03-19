using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
