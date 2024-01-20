using AuthFacil.Mvc.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthFacil.Mvc.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromForm] LoginFormModel logInModel)
    {
        // simulando uma validação
        if (logInModel.Username != "admin" ||
            logInModel.Password != "admin")
        {
            ViewBag.Fail = true;
            return View();
        }

        // simulando um usuario no sistema
        var user = new
        {
            Id = Guid.NewGuid(),
            Name = "Administrador"
        };

        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        ];
        var authScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        var identity = new ClaimsIdentity(claims, authScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(authScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = logInModel.RememberMe
            });

        if (!String.IsNullOrWhiteSpace(logInModel.ReturnUrl))
        {
            return Redirect(logInModel.ReturnUrl);
        }

        return RedirectToRoute("Restrito.Index");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToRoute("Auth.Login");
    }
}
