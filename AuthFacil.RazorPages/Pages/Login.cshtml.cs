using AuthFacil.RazorPages.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthFacil.RazorPages.Pages;

public class LoginModel : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(
        [FromForm, FromQuery] LogInFormModel logInModel)
    {
        // simulando uma validação
        if (logInModel.Username != "admin" || 
            logInModel.Password != "admin")
        {
            ViewData["Fail"] = true;
            return Page();
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

        return RedirectToPage("/Restrito");
    }
}
