using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthFacil.RazorPages.Pages;

[Authorize]
public class RestritoModel : PageModel
{
    public void OnGet()
    {
    }
}
