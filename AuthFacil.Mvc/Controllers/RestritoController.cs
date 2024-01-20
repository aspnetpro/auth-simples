using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthFacil.Mvc.Controllers;

[Authorize]
public class RestritoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
