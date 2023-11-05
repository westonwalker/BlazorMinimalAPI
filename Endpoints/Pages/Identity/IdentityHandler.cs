using BlazorMinimalApis.Lib.Routing;
namespace BlazorMinimalApis.Endpoints.Pages.Identity;

public class IdentityHandler : PageHandler
{
    public IResult Login()
    {
        return Page<Login>();
    }

    public IResult Logout()
    {
        return Page<Logout>();
    }
}