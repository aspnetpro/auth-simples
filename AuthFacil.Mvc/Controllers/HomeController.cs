using Microsoft.AspNetCore.Mvc;

namespace AuthFacil.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
