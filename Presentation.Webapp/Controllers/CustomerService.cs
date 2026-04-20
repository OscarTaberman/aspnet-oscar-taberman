using Microsoft.AspNetCore.Mvc;

namespace Presentation.Webapp.Controllers;

public class CustomerService : Controller
{
    [Route("customer-service")]
    public IActionResult Index()
    {
        return View();
    }
}
