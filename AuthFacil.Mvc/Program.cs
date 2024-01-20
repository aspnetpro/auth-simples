using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// aqui
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie((options) =>
    {
        options.LoginPath = "/login";
    });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllerRoute(
    name: "Home.Index",
    pattern: "",
    defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(
    name: "Auth.Login",
    pattern: "login",
    defaults: new { controller = "Auth", action = "Login" });
app.MapControllerRoute(
    name: "Auth.Logout",
    pattern: "logout",
    defaults: new { controller = "Auth", action = "Logout" });
app.MapControllerRoute(
    name: "Restrito.Index",
    pattern: "restrito",
    defaults: new { controller = "Restrito", action = "Index" });


app.Run();
