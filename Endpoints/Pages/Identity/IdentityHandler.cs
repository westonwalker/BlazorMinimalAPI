using BlazorMinimalApis.Lib.Routing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BlazorMinimalApis.Endpoints.Pages.Identity;

public class IdentityHandler : PageHandler
{
    public async Task<IResult> Login(HttpContext context)
    {
        await context.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = "/" });
        return Results.Redirect("/");

    }

    public async Task<IResult> Logout(HttpContext context)
    {
        if (context.Request.Cookies.Count > 0)
        {
            var siteCookies = context.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
            foreach (var cookie in siteCookies)
            {
                context.Response.Cookies.Delete(cookie.Key);
            }
        }

        await context.SignOutAsync("Auth0", new AuthenticationProperties());
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        context.Session.Clear();

        return Results.Redirect("/");
    }
}