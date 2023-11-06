using BlazorMinimalApis.Lib.Routing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BlazorMinimalApis.Api.Identity;

public class IdentityHandler : PageHandler
{
    public async Task<IResult> Login(HttpContext context)
    {
        await context.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = "/" });
        return Redirect("/");

    }

    public async Task<IResult> Logout(HttpContext context)
    {
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await context.SignOutAsync("Auth0", new AuthenticationProperties() { RedirectUri = "/" });
        context.Session.Clear();
        return Redirect("/");
    }
}